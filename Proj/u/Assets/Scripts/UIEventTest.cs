using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        UIEvent.Broadcast(UIEvent.UI_TEST1, 123);
        UIEvent.Broadcast(UIEvent.UI_TEST2, "F U");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        UIEvent.RegEvent(UIEvent.UI_TEST1, OnDoSth);
        UIEvent.RegEvent(UIEvent.UI_TEST2, OnDoSth1);
        UIEvent.RegEvent(UIEvent.UI_TEST1, OnDoSth2);
        UIEvent.PrintState();
    }

    private void OnDisable()
    {
        UIEvent.UnRegEvent(UIEvent.UI_TEST1, OnDoSth);
        UIEvent.UnRegEvent(UIEvent.UI_TEST2, OnDoSth1);
        UIEvent.UnRegEvent(UIEvent.UI_TEST1, OnDoSth2);
        UIEvent.PrintState();
    }

    private void OnDoSth(params object[] argv)
    {
        Debug.Log("OnDoSth");
    }
    private void OnDoSth1(params object[] argv)
    {
        Debug.Log("OnDoSth1 ==>"+ argv[0]);
    }
    private void OnDoSth2(params object[] argv)
    {
        Debug.Log("OnDoSth2 ==>"+ argv[0]);
    }
}
