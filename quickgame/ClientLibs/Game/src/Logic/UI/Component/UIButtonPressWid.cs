using UnityEngine;
using System.Collections;

public class UIButtonPressWid : MonoBehaviour
{
    private float mDeltTime = 0;
    private float mDely = 0;
    private float mMaxDely = 0;
    public delegate void OnPressCallBack(int mCount);
    public OnPressCallBack onPressFunc;
    public int mCount = 0;
    // Use this for initialization
    void Start()
    {
    
    }
    //max_dely最短间隔时间
    public void SetButtonPressParam(float dely , float max_dely)
    {
        mDely = dely;
        mMaxDely = max_dely;
    }

    public void ClearCount()
    {
        mCount = 0;
    }

    public void Stop()
    {
        mCount = 0;
        mDely = 0;
        mMaxDely = 0;
        mDeltTime = 0;
        mCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(mDely != 0)
        {
            if(mDeltTime > mDely)
            {
                mDeltTime = 0;
                if(mMaxDely < mDely)
                    mDely -= 0.1f;
                mCount = mCount + 1;
                onPressFunc(mCount);
            }
            mDeltTime += Time.deltaTime;
        }

    }
}

