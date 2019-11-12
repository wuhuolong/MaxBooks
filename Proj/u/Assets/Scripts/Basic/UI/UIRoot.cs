using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : UIBase
{
    public Transform m_Left;
    public Transform m_Right;
    public Transform Parent;

    public Vector3 LeftPoint
    {
        get
        {
            return m_Left.transform.position;
        }
    }
    public Vector3 RightPoint
    {
        get
        {
            return m_Right.transform.position;
        }
    }
    public Camera Cam;
    protected override void InitComp()
    {

    }

    protected override void InitData()
    {
        if (GameConfig.IsDebug)
        {
            Cam.gameObject.AddComponent<ShowFPS_OnGUI>();
        }
    }
}
