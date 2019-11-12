using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UIMask : UIBase
{
    public bool isHaveClickCallback { get; set; }
    
    protected override void InitComp()
    {

    }

    protected override void InitData()
    {

    }

    public void OnPointerClick()
    {
        if (isHaveClickCallback)
        {
            UIMgr.GetInstance().Pop();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
