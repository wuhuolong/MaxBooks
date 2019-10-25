using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : UIBase
{
    public Transform Parent;
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
