using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugFPS : MonoBehaviour
{
    public bool DrawFPS = true;
    public float FPSUpdateWaitTime;
    protected int mFPS;

	/// <summary>
	/// 当前程序运行的帧率
	/// </summary>
	public int FPS
	{
		get
		{
			return mFPS;
		}
	}

    protected GUIStyle fpsStyle = new GUIStyle();
	protected Rect fpsRT = new Rect(Screen.width - 100, 10, 80, 20);

    public virtual void Awake()
    {
        DrawFPS = true;
        
        if (FPSUpdateWaitTime == 0)
            FPSUpdateWaitTime = 0.5f;

        fpsStyle.alignment = TextAnchor.MiddleRight;
    }

    void OnGUI()
    {
        // FPS
        if (DrawFPS)
        {
            int fps = mFPS;
            if (fps > 27)
                fpsStyle.normal.textColor = Color.green;
            else if (fps > 24)
                fpsStyle.normal.textColor = Color.yellow;
            else
                fpsStyle.normal.textColor = Color.red;
            
            fpsRT.x = Screen.width - 100;
            string text = string.Format("{0}", fps);
            GUI.Label(fpsRT, text, fpsStyle);
        }
    }
    
	protected float mLastTime = 0;
    protected int mFrameCount = 0;
    
    void Start()
    {
        mLastTime = Time.realtimeSinceStartup;
        mFrameCount = 0;
    }
    
    // Update is called once per frame
	public virtual void Update()
    {
        float now = Time.realtimeSinceStartup;
        mFrameCount++;
        
        if (now >= mLastTime + FPSUpdateWaitTime)
        {
            float fps = mFrameCount / (now - mLastTime);
            mFPS = (int)fps;
            mFrameCount = 0;
            mLastTime = now;
        }
    }
}
