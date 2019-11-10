using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITipsLabel : UITips
{
    public Text m_Txt;
    private static int m_Distance = 50;
    private static int m_FloatTime = 2;
    private Vector3 m_Origin_Pos;
    private Coroutine co;

    public override void OnShowTips()
    {
        if (co != null)
        {
            StopCoroutine(co);
        }
        co = StartCoroutine(TipsMove());
    }

    protected override void InitComp()
    {
        m_Origin_Pos = m_Txt.transform.position;
    }

    protected override void InitData()
    {

    }

    //private void OnEnable()
    //{
    //}

    IEnumerator TipsMove()
    {
        m_Txt.text = (string)argv[0];
        m_Txt.gameObject.SetActive(true);
        yield return new WaitForSeconds(m_FloatTime);
        m_Txt.gameObject.SetActive(false);
        co = null;
        Close();
    }
}
