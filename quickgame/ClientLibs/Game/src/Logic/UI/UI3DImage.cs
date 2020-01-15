/*----------------------------------------------------------------
// 文件名： UI3DImage.cs
// 文件功能描述： 挂接在3D对象上的图片组件
//----------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using xc.ui.ugui;

[wxb.Hotfix]
public class UI3DImage : UI3DWidget
{
    public static Vector3 TeamIconScreenOffset = new Vector3(0, 30, 0); // 队伍标识距离头顶高度  (UI界面距离)

    public new class StyleInfo : UI3DWidget.StyleInfo
    {
        public string SpritName = "";
        public int SpriteWidth = 0;
        public int SpriteHeight = 0;
    }

    public void ResetStyleInfo(StyleInfo info)
    {
        base.ResetStyleInfo(info);

        SpritName = info.SpritName;
        if (Sprite != null && info.SpriteWidth > 0 && info.SpriteHeight > 0)
        {
            Sprite.rectTransform.sizeDelta = new Vector2(info.SpriteWidth, info.SpriteHeight);
        }
    }

    Image mSprite;
	string mSpriteName;

    protected override void Init()
    {
        base.Init();

        mSprite = mTrans.Find("Image").GetComponent<Image>();
    }

    protected override string RootName
    {
        get
        {
            return "3DImage";
        }
    }

    public Image Sprite
    {
        get { return mSprite; }
    }

	public string SpritName
	{
		set
		{
			mSpriteName = value;
			if (mSprite != null)
			{
				mSprite.sprite = mHudActorWin.LoadSprite(mSpriteName) ;
                mSprite.SetNativeSize();
			}
		}
	}

	public int Width
	{
		get
		{
			if (mSprite != null)
			{
				return (int)mSprite.rectTransform.sizeDelta.x;
			}

			return 0;
		}
        set
        {
            if (mSprite != null)
            {
                mSprite.rectTransform.sizeDelta.Set((float)value , mSprite.rectTransform.sizeDelta.y);
            }
        }
	}

    public int Height
    {
        get
        {
            if(mSprite != null)
            {
                return (int)mSprite.rectTransform.sizeDelta.y;
            }

            return 0;
        }
        set
        {
            if (mSprite != null)
            { 
                
                mSprite.rectTransform.sizeDelta.Set(mSprite.rectTransform.sizeDelta.x ,(float)value);
            }
        }
    }
}
