using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : UIWindows
{
    uint levelID;
    LevelData data;
    X.Res.ValueConfig_ARRAY value;
    public Text[] starRatingTexts;
    public RectTransform[] shadows;
    private bool isShadow = false;
    private Vector3 shadowMax = new Vector3(50.0f, 50.0f, 50.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private string shadowType = "shadowType";
    private int type;

    private bool canEnter = false;

    //Google.Protobuf.Collections.RepeatedField<int>[] starRaings;
    private void OnEnable()
    {
        //UIMgr.ShowPage(UIPageEnum.Play_Page);
        levelID = LevelMgr.GetInstance().GetCurLevelID();
        data = LevelMgr.GetInstance().GetLevelConfig(levelID);
        value = LevelMgr.GetInstance().GetValueConfig();
        ShadowInit();
        Invoke("CanEnter", 1.0f);
        OnShow();
    }

    private void ShadowInit()
    {
        
        for(int i=0;i<shadows.Length;i++)
        {
            shadows[i].localScale = Vector3.zero;
        }
        
        canEnter = false;
        //shadows[type].localScale = shadowOrigion;
        isShadow = false;
    }

    private void CanEnter()
    {
        canEnter = true;
    }

    private void FixedUpdate()
    {
        if(isShadow)
        {
            if(shadows[type].localScale!=shadowMin)
            {
                shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeed);
                
                if(Mathf.Abs(shadows[type].localScale.x-shadowMin.x)<=0.01f)
                {
                    shadows[type].localScale = Vector3.zero;
                    isShadow = false;
                    UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
                }
            }
        }
    }

    public void OnShow()
    {
        if (gameObject.name == "UITips(Clone)")
        {
            LoadStarTips();
        }
    }
    protected override void InitComp()
    {

    }

    protected override void InitData()
    {

    }
    private void LoadStarTips()
    {
        //加载评星提示
        if(data.Config.Rating1==0)
        {
            starRatingTexts[0].text = "完成关卡！";
        }
        LoadRating(data.Config.Rating2, 0);
        LoadRating(data.Config.Rating3, 1);
    }

    public void ClickEnter()
    {
        //随机加载阴影图
        type = Random.Range(0, 3);
        type = 1;
        XPlayerPrefs.SetInt(shadowType, type);
        Debug.Log("pre" + shadowType + type);

        if (canEnter)
        {
            shadows[type].localScale = shadowMax;
            isShadow = true;
            canEnter = false;
        }
    }

    private void LoadRating(Google.Protobuf.Collections.RepeatedField<int> rating,int index)
    {
        switch (rating[0])
        {
            case 1:
                
                string time = rating[1].ToString();
                string text = string.Format(value.Items[1].RatingName, time);
                starRatingTexts[index + 1].text = text;
                break;
            case 2:
                starRatingTexts[index + 1].text = value.Items[2].RatingName;
                break;
        }
    }
}
