using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAtlas : MonoBehaviour
{
    public Texture2D mainText;
    public Image Sp;
   [SerializeField] public List<Sprite> spriteLists;


    /// <summary>
    /// 根据图片名称获取sprite
    /// </summary>
    /// <param name="spritename">图片名称</param>
    /// <returns></returns>
    public Sprite GetSprite(string spritename)
    {
        if (spriteLists == null || spriteLists.Count == 0)
        {
            Debug.LogError("获取的图集为空");
            return null;
        }
        return spriteLists.Find((Sprite s) => { return s.name == spritename; });
    }

    /// <summary>
    /// 设置Image的Sprite
    /// </summary>
    /// <param name="im">Image</param>
    /// <param name="spritename">图片名称</param>
    public void SetSprite(ref Image im, string spritename)
    {

        if (im == null)
        {
            return;
        }
        Sprite sp = GetSprite(spritename);
        if (sp != null)
        {
            im.overrideSprite = sp;
        }
        else
        {
            Debug.Log("图集没有对应的图片:" + spritename);
        }
    }

    public void SetSprite(string spritename)
    {

        Sprite sp = GetSprite(spritename);
        if (sp != null)
        {
            Sp.overrideSprite = sp;
        }
        else
        {
            Debug.Log("图集没有对应的图片:" + spritename);
        }
    }
}
