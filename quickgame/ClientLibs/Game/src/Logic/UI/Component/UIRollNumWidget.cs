using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using xc.ui.ugui;

public class UIRollNumWidget : MonoBehaviour
{
    private Text mLabel;
    private float mStayTime = 0.1f;//停留时间
    private float mCountTime = 0.0f;//每次滚动调用时间
    private float mRollTime = 0.5f;//完全滚动完总时间（未包含停留时间）
    private bool mIsStart = false;
    public delegate void Finish(GameObject go , UIRollNumWidget wid);
    public Finish mOnFinish;
    private float mTime = 0;
    private int mNum;
    private int mNewNum;
    private uint mCount;
    private uint mNumCount = 0;//计数增加从0增加
    private float mTimeScale = 1;   //时间的放缩比

    public float RollTime
    {
        set {
            mRollTime = value;
        }
    }

    //最大个6位数可设置
    public void Show(int num , int newNum, float timeScale)
    {
        mNum = num;
        mNewNum = newNum;
        mNumCount = 0;
        mCount = (uint)Mathf.Abs(mNewNum - num);
        mIsStart = true;
        mCountTime = (float)mCount/mRollTime;
        mTimeScale = timeScale;
        SetLabelText();
    }

    public void SetNewNum(int newNum)
    {
        Show(mNum + (int)mNumCount, newNum, mTimeScale);
    }

    public float TimeScale
    {
        get { return mTimeScale; }
        set { mTimeScale = value; }
    }

    public void Stop()
    {
        mIsStart = false;
    }

    public void Awake()
    {
        mLabel = UIHelper.FindChild(gameObject, "NumLabel").GetComponent<Text>();
    }
    // Use this for initialization
    void Start()
    {

    }

    void SetLabelText()
    {
        mLabel.text = (mNum + mNumCount).ToString();
//         if ((mNewNum - mNum) < 0)
//         {
//             mLabel.text = "-"+ (mNum + mNumCount);
//         }
//         else
//         {
//             mLabel.text = "+"+ (mNum + mNumCount);
//         }
            
    }

    // Update is called once per frame
    void Update()
    {
        if(mIsStart == true)
        {
            float pass_time = Time.deltaTime * mTimeScale;
           if (mNumCount < mCount)
            {
                float deta = (float)(mCountTime* pass_time);
                if(deta < 1.0f)
                    deta = 1.0f;
                mNumCount += (uint)deta;
                if(mNumCount > mCount)
                {
                    mNumCount = mCount;
                    mTime = 0;
                }
                 SetLabelText();
            }
            else if(mNumCount == mCount)
            {
                if(mTime >= mStayTime)
                {
                    mTime = 0;
                    mIsStart = false;
                    if(mOnFinish != null)
                    mOnFinish(gameObject , this);
                }
            }
            mTime += pass_time;
        }
    }

}

