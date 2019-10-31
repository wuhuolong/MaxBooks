using UnityEngine;
using System.Collections;

public class ShowFPS_OnGUI : MonoBehaviour
{

    public float fpsMeasuringDelta = 1.0f;

    private float timePassed;
    private int m_FrameCount = 0;
    private float m_FPS = 0.0f;
    private float m_MS = 0.0f;

    private void Start()
    {
        timePassed = 0.0f;
    }

    private void Update()
    {
        m_FrameCount = m_FrameCount + 1;
        //Debug.Log(string.Format("timePassed={0},deltaTime={1},m_FrameCount={2}",
        //Debug.Log(string.Format("timePassed={0},deltaTime={1},m_FrameCount={2}", timePassed, Time.deltaTime,m_FrameCount));
        timePassed = timePassed + Time.deltaTime;

        if (timePassed > fpsMeasuringDelta)
        {
            m_FPS = m_FrameCount;/// timePassed;
            m_MS = 1.0f / m_FrameCount;
            //Debug.Log("set fps data");
            timePassed = 0.0f;
            m_FrameCount = 0;
        }
    }

    private void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(1.0f, 0.5f, 0.0f);   //设置字体颜色的
#if UNITY_EDITOR
        bb.fontSize = 20;       //当然，这是字体大小
#else
        bb.fontSize = 60;       //当然，这是字体大小
#endif

        //居中显示FPS
        GUILayout.BeginHorizontal();
        GUILayout.Label(/*new Rect((Screen.width / 2) - 40, 0, 200, 200),*/ "FPS: " + m_FPS, bb);
        GUILayout.Space(50);
        GUILayout.Label( m_MS.ToString("0.0000") + " ms", bb);
        GUILayout.EndHorizontal();
    }
}