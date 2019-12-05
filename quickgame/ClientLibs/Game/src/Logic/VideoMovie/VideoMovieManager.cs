using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace xc
{
    public class VideoMovieManager : xc.Singleton<VideoMovieManager>
    {
        private bool playing;
        private VideoPlayer player;
        private Button touchVideoBtn;
        private Button exitVideoBtn;
        private bool loopPlay;
        private bool needPlayWhenPrepared;
        public bool InitVideo(Transform container)
        {
            Debug.Log("VideoMovieManager.StartVideo");
            if (playing)
                return false;
            if (container == null)
                return false;
            while (container.childCount > 0)
            {
                Transform child = container.GetChild(0);
                child.parent = null;
                GameObject.Destroy(child.gameObject);
            }

            player = CreatePlayer(container);
            if (player == null)
            {
                return false;
            }
            player.transform.parent.gameObject.SetActive(false);
            playing = false;
            loopPlay = true;
            needPlayWhenPrepared = false;
            return true;
        }

        public void EndPlay()
        {
            Debug.Log("VideoMovieManager.EndPlay");
            if (!playing)
                return;
            if (player != null)
            {
                player.Stop();
                player.transform.parent.gameObject.SetActive(false);
            }
            if(touchVideoBtn != null)
                touchVideoBtn.gameObject.SetActive(false);
            if(exitVideoBtn != null)
                exitVideoBtn.gameObject.SetActive(false);
            playing = false;
        }

        private VideoPlayer CreatePlayer(Transform container)
        {
            if (Const.Region != RegionType.KOREA)
                return null;
            string path = "VideoMovie/VideoPlayer";
            var prefab = Resources.Load<GameObject>(path);
            if (prefab == null)
            {
                Debug.Log("VideoPlayer load fail");
                return null;
            }
            GameObject playerGO = GameObject.Instantiate(prefab) as GameObject;
            playerGO.SetActive(true);
            var rect = playerGO.GetComponent<RectTransform>();
            rect.SetParent(container);
            rect.localScale = Vector3.one;
            rect.localPosition = Vector3.zero;
            rect.sizeDelta = Vector2.zero;
            var playerComponent = playerGO.GetComponentInChildren<VideoPlayer>();
            var audioCourceComponent = playerGO.GetComponentInChildren<AudioSource>();
            touchVideoBtn = playerGO.transform.Find("TouchButton").GetComponent<Button>();
            touchVideoBtn.onClick.RemoveAllListeners();
            touchVideoBtn.onClick.AddListener(() =>
            {
                if (exitVideoBtn != null)
                {
                    var exitBtnActive = exitVideoBtn.gameObject.activeSelf;
                    exitVideoBtn.gameObject.SetActive(!exitBtnActive);
                }
            });
            touchVideoBtn.gameObject.SetActive(false);
            exitVideoBtn = playerGO.transform.Find("SkipButton").GetComponent<Button>();
            exitVideoBtn.onClick.RemoveAllListeners();
            exitVideoBtn.onClick.AddListener(() =>
            {
                VideoMovieManager.Instance.EndPlay();
            });
            exitVideoBtn.gameObject.SetActive(false);
            // Obtain the location of the video clip.
            if (playerComponent.isPlaying)
                playerComponent.Stop();
            playerComponent.url = Path.Combine(Application.streamingAssetsPath, "loading_movie.mp4");
            if (audioCourceComponent != null)
            {
                playerComponent.audioOutputMode = VideoAudioOutputMode.AudioSource;
                playerComponent.SetTargetAudioSource(0, audioCourceComponent);
                playerComponent.EnableAudioTrack(0, true);
            }

            playerComponent.prepareCompleted += OnPlayerPrepared;
            playerComponent.Prepare();
            playerComponent.isLooping = loopPlay;
            playerComponent.playOnAwake = false;
            playerComponent.aspectRatio = VideoAspectRatio.Stretch;
            return playerComponent;
        }

        private void OnPlayerPrepared(VideoPlayer player)
        {
            if (needPlayWhenPrepared)
                Play();
        }

        public bool IsReady()
        {
            if (player != null)
            {
                return player.isPrepared;
            }
            return false;
        }

        public void Play()
        {
            //点击视频的按钮此时就要显示，以防黑屏无法播放视频的时候也可以让玩家退出
            touchVideoBtn.gameObject.SetActive(true);
            if (IsReady())
            {
                player.transform.parent.gameObject.SetActive(true);
                RectTransform target = player.GetComponent<RectTransform>();
                RectTransform fullScreen = target.parent.GetComponent<RectTransform>();
                player.Play();
                Resize(target, fullScreen, player);
                playing = true;
            }
            else
            {
                player.transform.parent.gameObject.SetActive(true);
                player.Prepare();
                player.isLooping = loopPlay;
                player.aspectRatio = VideoAspectRatio.Stretch;
                player.playOnAwake = false;
                needPlayWhenPrepared = true;
            }
        }

        private void Resize(RectTransform target, RectTransform fullScreenRec, VideoPlayer player)
        {
            //Debug.Log("VideoClip.width:" + player.clip.width);
            //Debug.Log("VideoClip.height:" + player.clip.height);
            //Debug.Log("Screen.width:" + Screen.width);
            //Debug.Log("Screen.height:" + Screen.height);
            if (target == null || fullScreenRec == null || player == null)
                return;
            //float screenWidth = Screen.width;
            //float screenHeight = Screen.height;
            float screenWidth = fullScreenRec.rect.width;
            float screenHeight = fullScreenRec.rect.height;
            float videoWidth = player.clip == null ? 1334 : player.clip.width;
            float videoHeight = player.clip == null ? 750 : player.clip.height;
            //屏幕分辨率
            float videoRatio = videoWidth / videoHeight;
            //先让视频宽度填满屏幕，判断视频高度是否足够显示
            float newWidth = screenWidth;
            float newHeight = newWidth / videoRatio;
            //如果高度可以放入屏幕内，则符合要求
            if (newHeight <= screenHeight)
            {
                target.sizeDelta = new Vector2(newWidth, newHeight);
            }
            //如果高度不满足要求，则以视频高度填满屏幕，让视频宽度适配
            else
            {
                newHeight = screenHeight;
                newWidth = newHeight * videoRatio;
                if (newWidth <= screenWidth)
                {
                    target.sizeDelta = new Vector2(newWidth, newHeight);
                }
                else
                {
                    target.sizeDelta = new Vector2(screenWidth, screenHeight);
                }
            }
        }
    }
}
