using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using xc;
using SGameEngine;
using System;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UILoadingWindow : UIBaseWindow
    {
        protected Text mLoadingTipLabel;
        protected bool mBackgroundIsShow = false;
        protected Slider mLoadingSlider;
        protected Text mProgressLabel;
        protected bool mIsShowInstanceLoginBg = false;
        protected GameObject mWaitScreen;

        public MessageBoxUI MessageBox;
        public GameObject Background;

        private IUIBehaviour luabehaviour = null;
        private IUIBehaviour mPeak3PLoadingWindowBehaviour = null;

        //private GameObject mLoadingBgDefault;
        //private GameObject mLoadingBg;
        //private RawImage mLoadingBgImage;

        private RawImage mLoadingBgDefaultImage;

        protected override void InitUI()
        {
            mWaitScreen = FindChild("Wait");
            Background = FindChild("Frame");
            mLoadingTipLabel = FindChild<Text>("TipLabel");
            mLoadingSlider = FindChild<Slider>("Progress Bar");
            mProgressLabel = FindChild<Text>("ProgressLabel");
            MessageBox = FindChild<MessageBoxUI>("MessageBox");

            //mLoadingBgDefault = FindChild("LoadingBgDefault");
            //mLoadingBg = FindChild("LoadingBg");
            //mLoadingBgImage = mLoadingBg.GetComponent<RawImage>();

#if UNITY_ANDROID
            mLoadingBgDefaultImage = FindChild<RawImage>("LoadingBgDefault");
            // 安卓平台从assets文件夹查找是否存在"loading_bg.jpg"图片，存在则优先显示
            string imageFileName = "loading_bg.jpg";
            byte[] imageData = DBOSManager.getDBOSManager().getBridge().loadExternalFileData(imageFileName);
            if (imageData != null)
            {
                TextureFormat textureFormat = TextureFormat.DXT1;
                int width = Screen.currentResolution.width;
                int height = Screen.currentResolution.height;

                Texture2D newTexture2D = new Texture2D(width, height, textureFormat, false);
                newTexture2D.LoadImage(imageData);
                mLoadingBgDefaultImage.texture = newTexture2D;
            }
            else
            {
                //GameDebug.LogError("Error, Can not load loading image: " + imageFileName);
            }
#endif
            if (Const.Region == RegionType.KOREA)
            {
                RectTransform loading_bg_default = FindChild<RectTransform>("LoadingBgDefault");
                if (loading_bg_default != null && loading_bg_default.parent != null)
                {
                    var parent_size = mUIObject.GetComponent<RectTransform>().sizeDelta;
                    var screen_width = parent_size.x;
                    var cur_scale = screen_width / parent_size.y;
                    var min_scale = 1334.0f / 750;
                    if (cur_scale < min_scale)
                    {
                        var height = screen_width / min_scale;
                        var width = height * min_scale;
                        loading_bg_default.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                    }
                }
            }


            if (Const.Region != RegionType.CHINA)
            {
                // 隐藏健康提示
                var frame_trans = FindChild<Transform>("Frame");
                if (frame_trans != null)
                {
                    var health_text = frame_trans.Find("Text");
                    if (health_text != null)
                    {
                        health_text.gameObject.SetActive(false);
                    }
                }
            }

            base.InitUI();
        }
        //private void LoadBGConfig()
        //{
        //    List<Dictionary<string, string>> data_loading_texture = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_loading_texture");

        //}

        public UILoadingWindow()
        {
            IsLoadDone = false;
            mWndName = GetType().Name;
            //LoadDB();
            WindowType = UIType.Loading;
            IsGlobal = true;
        }
        private IEnumerator WaitForShow(GameObject obj, bool isShow, float time)
        {
            yield return new WaitForSeconds(time);
            if (obj != null)
            {
                obj.SetActive(isShow);
            }
        }

        public void ShowWaitScreen(bool isShow, float wait_time = 10.0f)
        {
            if (mWaitScreen == null)
            {
                return;
            }
            GameObject obj = mWaitScreen;
            if (isShow)
            {
                if (obj.activeSelf)
                    return;

                obj.SetActive(true);
                if (UIManager.Instance.MainCtrl != null)
                    UIManager.Instance.MainCtrl.StartCoroutine(WaitForShow(obj, false, wait_time));
            }
            else
            {
                obj.SetActive(false);
            }
        }

        public void SetLoadingTip(string text)
        {
            if (mLoadingTipLabel != null)
                mLoadingTipLabel.text = text;
        }

        public void ShowLoadingBK(bool isShow)
        {
            if (mLoadingSlider == null || Background == null || mProgressLabel == null)
                return;
            ShowWaitScreen(false);
            if (isShow)
            {
                if (mBackgroundIsShow == false)
                {
                    mBackgroundIsShow = true;
                    mLoadingSlider.value = 0;
                    mProgressLabel.text = "0/0";
                    Background.SetActive(true);
                    EnableLuaBehaviour(true);
                    SetLoadingImage(true, false);
                }
            }
            else
            {
                if (mBackgroundIsShow)
                {
                    mBackgroundIsShow = false;
                    mLoadingSlider.value = 1;
                    mProgressLabel.text = "100/100";
                    Background.SetActive(false);
                    EnableLuaBehaviour(false);
                    SetLoadingImage(false, false);
                }
            }
        }

        private GameObject canObj;

        private GameObject loadObj;
        private RawImage loadImage;
        private Texture loadTexture;
        private GameObject closeObj;
        private RawImage closeImage;
        private Texture closeTexture;
        public void SetLoadingImage (bool isShow, bool needDestroy)
        {
            if (AuditManager.Instance.Open == false)
                return;
            if (GlobalConfig.Instance.PlatformName != "ios")
                return;


            if (isShow) {
                
                if (canObj == null) {
                    
                    canObj = new GameObject ("canObj");
                    canObj.name = "canObj";
                    canObj.transform.parent = UIManager.Instance.MainCtrl.LoadingRoot;
                    canObj.layer = 5;
                    canObj.transform.localScale = Vector3.one;
                    canObj.transform.localPosition = Vector3.zero;
                    canObj.gameObject.SetActive (false);

                    GameObject backImg = new GameObject("backImg");
                    backImg.transform.parent = Background.transform;
                    RawImage backRaw = backImg.AddComponent<RawImage>();
                    backRaw.color = Color.black;
                    RectTransform rectCan = mUIObject.GetComponent<RectTransform>();
                    backRaw.GetComponent<RectTransform>().sizeDelta = new Vector2(rectCan.rect.width, rectCan.rect.height);
                    backRaw.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    backRaw.transform.localScale = Vector3.one;

                    Canvas canvas = canObj.AddComponent<Canvas> ();
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                    canvas.worldCamera = xc.ui.ugui.UIMainCtrl.MainCam;
                    canvas.sortingOrder = 10001;
                    CanvasScaler canvas_scale = canObj.AddComponent<CanvasScaler> ();
                    canvas_scale.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                    canvas_scale.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;
                    canvas_scale.referenceResolution = new Vector2 (1334, 750);

                    canvas.gameObject.AddComponent<GraphicRaycaster> ();

                    loadObj = new GameObject ("loadObj");
                    loadObj.transform.parent = canObj.transform;//Background.transform;
                    loadImage = loadObj.AddComponent<RawImage> ();

                    LoadMaJiaImage majia = loadImage.gameObject.AddComponent<LoadMaJiaImage>();
                    var picName = "LoadRaw.png";
                    majia.mPath = ResNameMapping.Instance.GetMappingName(picName);
                    loadImage.rectTransform.sizeDelta = new Vector2 (1334, 750);
                    loadImage.rectTransform.anchoredPosition = Vector2.zero;
                    loadImage.gameObject.transform.localScale = Vector3.one;


                    //closeObj = new GameObject ("closeBtn");
                    //closeObj.transform.parent = loadObj.transform;
                    //closeImage = closeObj.AddComponent<RawImage> ();
                    //closeTexture = Resources.Load ("CloseBtn") as Texture;
                    //closeImage.texture = closeTexture;
                    //closeImage.gameObject.transform.localScale = Vector3.one;
                    //closeImage.rectTransform.anchorMin = Vector2.one;
                    //closeImage.rectTransform.anchorMax = Vector2.one;
                    //closeImage.rectTransform.sizeDelta = new Vector2 (64, 128);
                    //closeImage.rectTransform.anchoredPosition = new Vector2 (-61, -179);
                    //EventTriggerListener.GetListener (closeImage.gameObject).onPointerClick += ClickClose;

                }
                canObj.gameObject.SetActive (true);
                loadObj.SetActive (true);
                mLoadingSlider.gameObject.SetActive (false);
                mProgressLabel.gameObject.SetActive (false);
            } else {
                

                loadObj.SetActive (false);
                mLoadingSlider.gameObject.SetActive (true);
                mProgressLabel.gameObject.SetActive (true);
                if (needDestroy) {

                    //Resources.UnloadAsset (closeTexture);
                    //closeTexture = null;
                    //GameObject.Destroy (closeImage);
                    //closeImage = null;

                    Resources.UnloadAsset (loadTexture);
                    loadTexture = null;
                    GameObject.Destroy (loadObj);
                    loadObj = null;
                }
            }
        }

        private void ClickClose(GameObject go)
        {
            loadObj.gameObject.SetActive(false);
            mLoadingSlider.gameObject.SetActive(true);
            mProgressLabel.gameObject.SetActive(true);
        }



        protected override void UnInitUI()
        {
            base.UnInitUI();
            SetLoadingImage(false,  true);
        }




        public bool LoadingBKIsShow
        {
            get
            {
                return mBackgroundIsShow;
            }
        }

        public void UpdateLoadingBar(double process)
        {
            if (mLoadingSlider == null || mProgressLabel == null)
                return;
            ShowWaitScreen(false);
            if (mBackgroundIsShow)
            {
                mLoadingSlider.value = (float)process;
                //mLoadingSprite.width = (int)(660 * process);
                mProgressLabel.text = (int)(process * 100) + "/100";
            }
            else
            {
                mLoadingSlider.value = 1;
                //mLoadingSprite.width = 660;
                mProgressLabel.text = "100/100";
            }
        }

        //public void InitLoadingBG(Action action)
        //{
        //    ResourceLoader.Instance.LoadAssetAsync("Assets/Res/UI/Textures/Background/New_Loading_2.jpg", (ar) => 
        //    {
        //        if( ar.asset_ != null)
        //        {
        //            mLoadingBgImage.texture = (Texture)ar.asset_;
        //            mLoadingBg.SetActive(true);
        //        }
        //        action();
        //    });
        //}

        public void EnableLuaBehaviour(bool isEnable)
        {
            if (luabehaviour == null)
            {
                luabehaviour = AddBehaviour("UILoadingWindowBehaviour");
                if(luabehaviour != null)
                {
                    luabehaviour.EnableBehaviour(isEnable);
                }
            }
            else
            {
                luabehaviour.EnableBehaviour(isEnable);
            }

            if (mPeak3PLoadingWindowBehaviour == null)
            {
                mPeak3PLoadingWindowBehaviour = AddBehaviour("Peak3P/UIPeak3PLoadingWindowBehaviour");
                if (mPeak3PLoadingWindowBehaviour != null)
                {
                    mPeak3PLoadingWindowBehaviour.EnableBehaviour(isEnable);
                }
            }
            else
            {
                mPeak3PLoadingWindowBehaviour.EnableBehaviour(isEnable);
            }
        }
    }
}
