using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISimTips : UITips
{
    public Text[] m_Txts;
    GameObject curText;
    bool showText;
    protected override void InitComp()
    {
        
    }
    protected override void InitData()
    {
        
    }
    public override void OnShowTips()
    {
        showText = true;
        curText = m_Txts[0].gameObject;
        curText.SetActive(true);
        curText.transform.position = new Vector3(0, 0, 0.5f);
        curText.transform.localScale = Vector3.one;
        m_Txts[0].text = argc[0].ToString();
    }

    private void Update()
    {
        if(showText)
        {
            curText.transform.Translate(Vector3.up * Time.deltaTime);
            if (curText.transform.position.y >= 0.5f)
            {
                showText = false;
                curText.SetActive(false);
            }
        }
    }

    public void BtnClickOk()
    {

    }

    public void BtnClickCancel()
    {

    }
}
