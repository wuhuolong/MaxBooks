using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LanguaMark : MonoBehaviour
{
    private Text m_txt;
    public uint m_Lang_ID;
    void Start()
    {
        m_txt = GetComponent<Text>();
        LanguageMgr.GetInstance().GetLangStrByID(m_txt, m_Lang_ID);
    }

}
