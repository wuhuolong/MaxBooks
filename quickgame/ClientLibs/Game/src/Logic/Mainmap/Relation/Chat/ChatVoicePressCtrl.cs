using UnityEngine;
using System.Text;
using System.Collections;
using xc;

[wxb.Hotfix]
public class ChatVoicePressCtrl : MonoBehaviour
{
    /// <summary>
    /// 触发录音的时间
    /// </summary>
    float triggerTime = float.MaxValue;

    /// <summary>
    /// 按住持续多久时间开始录音
    /// </summary>
    float pressTime = 1.0f;

    public float PressTime
    {
        set
        {
            pressTime = value;
        }
    }

    /// <summary>
    /// 是否正在录音
    /// </summary>
    bool isRecording = false;

    void Update()
    {
        if (!isRecording && Time.time > triggerTime)
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHAT_VOICE_START_MESSAGE, new CEventBaseArgs(this));
            isRecording = true;
        }
    }

    void OnPress(bool isDown)
    {
        if (isDown)
        {
            triggerTime = Time.time + pressTime;
        }
        else
        {
            triggerTime = float.MaxValue;
            if (isRecording)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHAT_VOICE_END_MESSAGE, new CEventBaseArgs(this));
                isRecording = false;
            }
            else
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHAT_VOICE_CLICK_MESSAGE, new CEventBaseArgs(this));
        }
    }
}