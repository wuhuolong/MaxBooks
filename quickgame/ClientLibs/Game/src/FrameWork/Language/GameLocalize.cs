/// <summary>
/// UI界面中语言本地化
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using xc;

[AddComponentMenu("CustomComponent/GameLocalize")]
public class GameLocalize : MonoBehaviour
{
    /// <summary>
    /// 对应GameLocalize表中的key
    /// </summary>
    public string key;

    /// <summary>
    /// 设置对应的文本
    /// </summary>
    public string value
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                var lbl = GetComponent<Text>();

                if (lbl != null)
                {
                    lbl.text = value;
                }
                else
                {
                    Input input = GetComponent<Input>();
                    //input. = value;
                }

            }
        }
    }


    void Awake ()
    {
        #if UNITY_EDITOR
        if (!Application.isPlaying) return;
        #endif

        OnLocalize();
    }
    

    void OnLocalize ()
    {
        // key 为空时，使用本身文本的变量作为key
        if (string.IsNullOrEmpty(key))
        {
            var lbl = GetComponent<Text>();
            if (lbl != null) key = lbl.text;
        }

        if (!string.IsNullOrEmpty(key)) value = DBGameLocalize.GetText(key);
    }
}
