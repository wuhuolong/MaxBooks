using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace xc
{
    namespace ui
    {
        public class UIPagePoint : MonoBehaviour
        {
            private List<UISprite> mPoints = new List<UISprite>();
            private UIAtlas mAtlas;
            // Use this for initialization
            void Start()
            {

            }

            public void OnScorllUpdate(int now_page)
            {
                for (int i = 0 ; i < mPoints.Count ; i ++)
                {
                    mPoints[i].spriteName = "dian2";  
                    mPoints[i].MakePixelPerfect();
                }
                mPoints[now_page - 1].atlas = mAtlas;
                mPoints[now_page - 1].spriteName = "dian1";  
                mPoints[now_page - 1].MakePixelPerfect();
            }

            public void initPagePoint(int total_num)
            {
                for (int i = 0 ; i < mPoints.Count ; i ++)
                {
                    GameObject.Destroy( mPoints[i].gameObject);
                }
                mPoints.Clear();
                mAtlas = Resources.Load("UI/Atlas/AtlasCommon", typeof(UIAtlas)) as UIAtlas;
                for(int i = 0 ; i < total_num ; i ++)
                {;
                    UISprite sprite = NGUITools.AddSprite(gameObject , mAtlas , "next page01");
                    sprite.MakePixelPerfect();
                    sprite.gameObject.transform.localPosition = new Vector3(i*20 , 0 ,0);
                    sprite.gameObject.transform.localScale = Vector3.one;
                    sprite.depth = 5;
                    mPoints.Add(sprite);
                }
                mPoints[0].spriteName = "next page02";   
                mPoints[0].MakePixelPerfect();
            }
            void OnDestroy()
            {
                for (int i = 0 ; i < mPoints.Count ; i ++)
                {
                    GameObject.Destroy( mPoints[i].gameObject);
                }
                mPoints.Clear();
            }

        }
    }
}


