using System.Collections;
using UnityEngine;

namespace xc
{
    public class GameLocalizeHelper
    {
        public static IEnumerator CoLoadLocalizeFile(string path)
        {
            SGameEngine.AssetResource result = new SGameEngine.AssetResource();

            yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(TextAsset), result));

            if (result.asset_ == null)
            {
                yield break;
            }

            TextAsset textAsset = result.asset_ as TextAsset;
            if (textAsset == null || textAsset.text == null)
            {
                Debug.LogError("加载本地化文件失败：" + path);
                yield break;
            }

            string content = textAsset.text;
            LocalizeManager.Instance.ParseLocalizationData(content);

            result.destroy();
        }
    }
}
