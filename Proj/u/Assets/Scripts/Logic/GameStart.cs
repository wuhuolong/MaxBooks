using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    UIBase m_uiroot;
    GameKernel kernel;
    private void Awake()
    {
        kernel = GameKernel.GetInstance();
        kernel.Init();
    }
    void Start()
    {
        kernel.OnStart();
    }
}
