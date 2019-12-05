using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace xc
{
    [RequireComponent(typeof(Image))]
    [wxb.Hotfix]
    public class UIChatBubbleWidget : MonoBehaviour
    {
        class BubbleInfo
        {
            // 用于回收
            public string mFileName;
            public GameObject mBubbleObject;

            public BubbleInfo(string file_name, GameObject gameObj)
            {
                mFileName = file_name;
                mBubbleObject = gameObj;
            }
        }

        private Image mDefaultImage;



        public uint mShowingId = 0;
        public string mShowingFileName = string.Empty;
        public bool mFlip = false;

        //正在显示的图像信息信息
        private BubbleInfo mShowingInfo;
        private Coroutine coroutine;

        //------------------- message starrt -----------------------------------------------
        void Awake()
        {
          
        }

        void Start()
        {
            //Clean();

            //SetModelId(500001);
        }

        void OnDestroy()
        {
            StopLoadCoroutine();
            //Clean();
        }


        //------------------- message end -----------------------------------------------
        public void SetModelId(uint modelId)
        {
            if (mShowingId == modelId)
            {
                //Debug.Log("UIChatBubbleWidget mShowingId == SetModelId ");
                return;
            }
            if (modelId == 0 || !ActorUtils.Instance.HasExistResourceAvatarPartId(modelId))
            {
                Clean();
                return;
            }
            mShowingFileName = ActorUtils.Instance.GetFileNameByModelId(modelId);
            if (mShowingFileName == string.Empty)
            {
                Clean();
                return;
            }
            mShowingId = modelId;
            StopLoadCoroutine();
            coroutine = ResourceLoader.Instance.StartCoroutine(Load(mShowingFileName));
        }

        public void Clean()
        {
            StopLoadCoroutine();
            mShowingId = 0;
            mShowingFileName = string.Empty;
            RemoveChatBubble();
        }

        public void UpdateFlip()
        {
            if (mShowingInfo == null || mShowingInfo.mBubbleObject == null)
                return;
            RectTransform rect = mShowingInfo.mBubbleObject.GetComponent<RectTransform>();
            rect.localEulerAngles = new Vector3(0, mFlip ? 180 : 0, 0);
        }

        public IEnumerator Load(string fileName)
        {
            RemoveChatBubble();
            //yield return new WaitForEndOfFrame();
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(fileName, ObjCachePoolType.UI_PREFAB, fileName, ow));
            GameObject bubbleGO = ow.obj as GameObject;
            if (bubbleGO == null)
            {
                //Debug.Log("UIChatBubbleWidget bubbleGO null ");
                yield break;
            }
            RectTransform rect = bubbleGO.GetComponent<RectTransform>();
            if (rect == null)
            {
                //Debug.Log("UIChatBubbleWidget bubbleGO rect ");
                yield break;
            }
            GameObject.DontDestroyOnLoad(bubbleGO);
            if (this == null || gameObject == null || transform == null || fileName != mShowingFileName)
            {
                //Debug.Log("UIChatBubbleWidget bubbleGO return ");
                ObjCachePoolMgr.Instance.RecyclePrefab(bubbleGO, ObjCachePoolType.UI_PREFAB, fileName);
                yield break;
            }

            RemoveChatBubble();

            rect.SetParent(transform);
            rect.SetAsFirstSibling();
            //美术资源制作要复合规格
            rect.localScale = Vector3.one;
            rect.anchoredPosition3D = Vector3.zero;
            rect.sizeDelta = Vector2.zero;



            LayoutElement layout = bubbleGO.GetComponent<LayoutElement>();
            if (layout == null)
            {
                layout = bubbleGO.AddComponent<LayoutElement>();
            }
            layout.ignoreLayout = true;

            mShowingInfo = new BubbleInfo(fileName, bubbleGO);
            //mDefaultImage.enabled = false;
            SetDefaultImageEnabled(false);

            UpdateFlip();
            StopLoadCoroutine();
        }

        public void RemoveChatBubble()
        {
            SetDefaultImageEnabled(true);

            if (mShowingInfo == null)
                return;
            ObjCachePoolMgr.Instance.RecyclePrefab(mShowingInfo.mBubbleObject, ObjCachePoolType.UI_PREFAB, mShowingInfo.mFileName);
            mShowingInfo = null;

            //Debug.Log("UIChatBubbleWidget RemoveChatBubble ");
        }

        public void SetDefaultImageEnabled(bool enabled)
        {
            if (mDefaultImage == null)
            {
                mDefaultImage = GetComponent<Image>();
                if (mDefaultImage != null)
                {
                    mDefaultImage.enabled = enabled;
                }
            }
            else
            {
                mDefaultImage.enabled = enabled;
            }
        }


        public void StopLoadCoroutine()
        {
            //if (coroutine != null)
            //{
            //    ResourceLoader.Instance.StopCoroutine(coroutine);
            //    coroutine = null;
            //}
        }
    }
}
