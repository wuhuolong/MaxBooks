using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc
{
    [AddComponentMenu("CustomComponent/ImageLocalize")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class ImageLocalize : MonoBehaviour
    {
        [Serializable]
        private class LocalizeImageItem
        {
            public LanguageType language;
            public Sprite sprite;
        }
        [SerializeField]
        private List<LocalizeImageItem> localizedImages = new List<LocalizeImageItem>();
        private bool isInitialized = false;
        private void Awake()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            OnLocalize();
        }

        public void AddSprite(LanguageType lang, Sprite image)
        {
            for (int i = 0; i < localizedImages.Count; i++)
            {
                var localizeData = localizedImages[i];
                if (localizeData.language == lang)
                {
                    localizeData.sprite = image;
                    return;
                }
            }
            localizedImages.Add(new LocalizeImageItem(){language = lang, sprite = image});
        }

        public void ClearSprites()
        {
            localizedImages.Clear();
        }

        //本地化处理
        private void OnLocalize()
        {
            //避免重复初始化
            if (isInitialized == true)
                return;
            var imageComponent = this.gameObject.GetComponent<Image>();
            if (imageComponent == null)
                return;
            var localizedImage = GetLocalizedSprite();
            var originalImage = imageComponent.sprite;
            //同名才替换，确保代码设置的精灵不会被替换掉
            if (localizedImage != null && originalImage != null && originalImage.name.Equals(localizedImage.name))
            {
                imageComponent.sprite = localizedImage;
            }

            isInitialized = true;
        }

        private Sprite GetLocalizedSprite()
        {
            foreach (LocalizeImageItem imageItem in localizedImages)
            {
                if (imageItem.language == Const.Language)
                    return imageItem.sprite;
            }

            return null;
        }
    }
}
