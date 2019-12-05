using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using SGameEngine;
using xc.ui.ugui;
using UnityEngine.UI;

namespace xc
{
    [RequireComponent(typeof(RectTransform))]
    public class UIPhotoFrameWidget : MonoBehaviour
    {
        //ui设计规格是 80 * 80
        private const int DefaultSize = 80;

        class PhotoFrameInfo
        {
            // 用于回收
            public string mFileName;
            public GameObject mPhotoFrameObject;
            private GameObject mImage;
            private GreyMaterialComponent mGrey;

            public PhotoFrameInfo(string file_name, GameObject gameObj)
            {
                mFileName = file_name;
                mPhotoFrameObject = gameObj;
                if (mPhotoFrameObject != null)
                {
                    mImage = UIHelper.FindChild(mPhotoFrameObject, "Image");
                    if(mImage == null)
                    {
                        Image[] imageList = mPhotoFrameObject.GetComponentsInChildren<Image>();
                        if(imageList.Length > 0)
                        {
                            mImage = imageList[0].gameObject;
                        }
                    }
                }
            }

            public void SetGrey(bool isGrey)
            {
                if (mImage == null)
                    return;
                if (mGrey == null)
                {
                    mGrey = mImage.GetComponent<GreyMaterialComponent>();
                    if (mGrey == null)
                    {
                        mGrey = mImage.AddComponent<GreyMaterialComponent>();
                    }
                }
                mGrey.IsGrey = isGrey;
            }
        }

        public uint mShowingId = 0;
        public string mShowingFileName = string.Empty;

        private RectTransform mRect;
        private bool mIsGrey = false; //变灰
        private PhotoFrameInfo mShowingInfo; //正在显示的图像信息信息
        private Coroutine loadingCoroutine; //加载协程

        //------------------- message starrt -----------------------------------------------
        void Awake()
        {
            mRect = GetComponent<RectTransform>();
            Clean();
        }

        void Start()
        {
            //if(mShowingId != 0)
            //{
            //    uint id = mShowingId;
            //    Clean();
            //    SetModelId(id);
            //}
        }

        void OnDestroy()
        {
            StopLoadCoroutine();
        }


        //------------------- message end -----------------------------------------------


        public bool SetModelId(uint modelId)
        {

            if (modelId == 0 || !ActorUtils.Instance.HasExistResourceAvatarPartId(modelId))
            {
                Clean();
                return false;
            }
            if (mShowingId == modelId)
            {
                return true;
            }

            mShowingFileName = ActorUtils.Instance.GetFileNameByModelId(modelId);
            if (mShowingFileName == string.Empty)
            {
                Clean();
                return false;
            }
            mShowingId = modelId;
            mIsGrey = false; // 默认不灰
            StopLoadCoroutine();
            loadingCoroutine = ResourceLoader.Instance.StartCoroutine(Load(mShowingFileName));
            return true;
        }

        public void SetGrey(bool isGrey)
        {
            mIsGrey = isGrey;
            if (mShowingInfo != null )
            {
                mShowingInfo.SetGrey(isGrey);
            }
        }

        public void Clean()
        {
            //Debug.Log("UIPhotoFrameWidget clean");
            StopLoadCoroutine();
            mShowingId = 0;
            mShowingFileName = string.Empty;
            RemovePhotoFrame();
        }



        IEnumerator Load(string fileName)
        {
            RemovePhotoFrame();
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(fileName, ObjCachePoolType.UI_PREFAB, fileName, ow));
            GameObject photoFrameGO = ow.obj as GameObject;
            if (photoFrameGO == null)
            {
                //Debug.Log("UIPhotoFrameWidget photoFrameGO null ");
                yield break;
            }
            RectTransform rect = photoFrameGO.GetComponent<RectTransform>();
            if (rect == null)
            {
                //Debug.Log("UIPhotoFrameWidget photoFrameGO rect ");
                yield break;
            }
            GameObject.DontDestroyOnLoad(photoFrameGO);
            if (this == null || gameObject == null || transform == null || fileName != mShowingFileName)
            {
                //Debug.Log("UIPhotoFrameWidget photoFrameGO return ");
                ObjCachePoolMgr.Instance.RecyclePrefab(photoFrameGO, ObjCachePoolType.UI_PREFAB, fileName);
                yield break;
            }

            RemovePhotoFrame();
            rect.parent = transform;
            rect.SetAsFirstSibling();
            rect.localEulerAngles = Vector3.zero;
            float scale = mRect.sizeDelta.x / DefaultSize;
            rect.localScale = new Vector3(scale, scale, 1);
            //rect.anchorMin = new Vector2(0, 1);
            //rect.anchorMax = new Vector2(0, 1);
            //rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition3D = Vector3.zero;

            mShowingInfo = new PhotoFrameInfo(fileName, photoFrameGO);
            mShowingInfo.SetGrey(mIsGrey);


            StopLoadCoroutine();
        }

        private void RemovePhotoFrame()
        {
            if (mShowingInfo == null)
                return;
            ObjCachePoolMgr.Instance.RecyclePrefab(mShowingInfo.mPhotoFrameObject, ObjCachePoolType.UI_PREFAB, mShowingInfo.mFileName);
            mShowingInfo = null;

            //Debug.Log("UIPhotoFrameWidget RemovePhotoFrame ");
        }

        private void StopLoadCoroutine()
        {
            //if (loadingCoroutine != null)
            //{
            //    ResourceLoader.Instance.StopCoroutine(loadingCoroutine);
            //    loadingCoroutine = null;
            //}
        }




    }
}
