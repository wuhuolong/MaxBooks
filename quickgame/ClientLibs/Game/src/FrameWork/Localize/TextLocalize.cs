using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace xc
{
    [AddComponentMenu("CustomComponent/TextLocalize")]
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    [DisallowMultipleComponent]
    public class TextLocalize : MonoBehaviour
    {
        //原始内容
        [Header("原始文本")]
        [SerializeField]
        private string rawContent;
        [Header("原始文本大小")]
        [SerializeField]
        private int fontSize;
        //[Serializable]
        //private class LocalizeTextData
        //{
        //    public LanguageType lang;
        //    public Vector3 anchoredPos;
        //    public Font font;
        //}

        //[Header("本地化配置")]
        //[SerializeField]
        //private List<LocalizeTextData> localizeTextDatas = new List<LocalizeTextData>();

        //private bool isInitialized = false;

//        private void Awake()
//        {
//#if UNITY_EDITOR
//            if (!Application.isPlaying) return;
//#endif
//            OnLocalize();
//        }

        //public void AddFont(LanguageType lang, Font font)
        //{
        //    for (int i = 0; i < localizeTextDatas.Count; i++)
        //    {
        //        LocalizeTextData textData = localizeTextDatas[i];
        //        if (textData.lang == lang)
        //        {
        //            textData.font = font;
        //            return;
        //        }
        //    }
        //    //如果到这里，说明还没有相关本地化数据，新建一个
        //    LocalizeTextData textDataTemp = new LocalizeTextData();
        //    textDataTemp.lang = lang;
        //    textDataTemp.font = font;
        //    localizeTextDatas.Add(textDataTemp);
        //}

        public void AddText(string text, int size)
        {
            rawContent = text;
            fontSize = size;
        }

        public string GetText()
        {
            return rawContent;
        }

        //本地化处理
        //void OnLocalize()
        //{
        //    //避免重复初始化
        //    if (isInitialized == true)
        //        return;
        //    var textComponent = this.gameObject.GetComponent<Text>();
        //    if (textComponent == null)
        //        return;
        //    if (DBManager.Instance.IsLoadAllFinished)
        //    {
        //        if (!string.IsNullOrEmpty(rawContent))
        //        {
        //            string currentText = textComponent.text;
        //            //当前的文本内容和本地化数据中记录的文本内容一致，表示文本没有被代码动态设置过
        //            //如果是代码动态设置的，直接就是本地化内容，这里就不用再次本地化处理了
        //            if (!string.IsNullOrEmpty(currentText) && currentText.Equals(rawContent))
        //            {
        //                var localizedContent = xc.DBTranslate.Instance.GetTranslateText("", currentText);
        //                textComponent.text = localizedContent;
        //            }
        //        }
        //    }

        //    //直接该引用了，不需要这部分，先注释掉
        //    /*
        //    var localizeTextData = GetLocalizedTextData();
        //    if (localizeTextData != null)
        //    {
        //        //如果为零就表示不需要本地化处理
        //        if (localizeTextData.anchoredPos.Equals(Vector3.zero) == false)
        //            textComponent.rectTransform.anchoredPosition3D = localizeTextData.anchoredPos;
        //        if (localizeTextData.font != null)
        //            textComponent.font = localizeTextData.font;
        //    }
            
        //    textComponent.fontSize = fontSize;
        //    */
        //    isInitialized = true;
        //}

        //private LocalizeTextData GetLocalizedTextData()
        //{
        //    foreach (var textItem in localizeTextDatas)
        //    {
        //        if (textItem.lang == Const.Language)
        //            return textItem;
        //    }

        //    return null;
        //}

        //public void ClearLocalizedData()
        //{
        //    localizeTextDatas.Clear();
        //}
    }
}
