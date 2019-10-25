using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIUseRecTips : MonoBehaviour
{
    private Action m_comfirm_ac;
    private Action m_cancel_ac;


    public void Show(params object[] argc)
    {
        m_cancel_ac = argc[0] as Action;
        m_comfirm_ac = argc[1] as Action;
        gameObject.SetActive(true);
    }
    private void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnClickComfirm()
    {
        if (m_comfirm_ac != null)
        {
            m_comfirm_ac();
        }
        Close();
    }

    public void OnClickCancel()
    {
        if (m_cancel_ac != null)
        {
            m_cancel_ac();
        }
        Close();
    }
}
