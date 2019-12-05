using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc
{
    [AddComponentMenu("CustomComponent/RawImageLocalize")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(UnityEngine.UI.RawImage))]
    public class RawImageLocalize : MonoBehaviour
    {
        [Serializable]
        private class LocalizeRawImageItem
        {
            public LanguageType language;
            public Texture texture;
        }
        [SerializeField]
        private List<LocalizeRawImageItem> localizedRawImages = new List<LocalizeRawImageItem>();

        private bool isInitialized = false;

        private void Awake()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            OnLocalize();
        }

        public void AddTexture(LanguageType lang, Texture image)
        {
            for (int i = 0; i < localizedRawImages.Count; i++)
            {
                var localizeData = localizedRawImages[i];
                if (localizeData.language == lang)
                {
                    localizeData.texture = image;
                    return;
                }
            }
            localizedRawImages.Add(new LocalizeRawImageItem(){language = lang, texture = image});
        }

        public void ClearTextures()
        {
            localizedRawImages.Clear();
        }

        //本地化处理
        private void OnLocalize()
        {
            //避免重复初始化
            if (isInitialized == true)
                return;
            var rawImageComponent = this.gameObject.GetComponent<RawImage>();
            if (rawImageComponent == null)
                return;
            var localizedTexture = GetLocalizedTexture();
            var originalTexture = rawImageComponent.texture;
            //同名才替换，确保代码设置的Texture不会被替换掉
            if (localizedTexture != null && originalTexture != null && originalTexture.name.Equals(localizedTexture.name))
            {
                rawImageComponent.texture = localizedTexture;
            }

            isInitialized = true;
        }

        private Texture GetLocalizedTexture()
        {
            foreach (LocalizeRawImageItem imageItem in localizedRawImages)
            {
                if (imageItem.language == Const.Language)
                    return imageItem.texture;
            }

            return null;
        }
    }
}
