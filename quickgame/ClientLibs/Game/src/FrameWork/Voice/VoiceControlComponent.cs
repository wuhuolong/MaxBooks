using gcloud_voice;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace xc
{
    [wxb.Hotfix]
    public class VoiceControlComponent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public enum State : byte
        {
            Idle = 0,
            Recording,
            Cancel
        }
        private State mState = State.Idle;

        private Timer mPressDownTimer;

        private float mPressTime = 0.0f;

        public uint Tag
        {
            set
            {
                mTag = value;
            }
            get
            {
                return mTag;
            }
        }
        private uint mTag = 0;

        public float DelayTime {
            set
            {
                mDelayTime = value;
            }
            get
            {
                return mDelayTime;
            }
        }
        private float mDelayTime = 0.0f;

        public float RecordMaxTime
        {
            set
            {
                mRecordMaxTime = value;
            }
            get
            {
                return mRecordMaxTime;
            }
        }
        private float mRecordMaxTime = 20000.0f;

        public float RecordMinTime
        {
            set
            {
                mRecordMinTime = value;
            }
            get
            {
                return mRecordMinTime;
            }
        }
        private float mRecordMinTime = 1000.0f;

        public float Intevel
        {
            set
            {
                mIntevel = value;
            }
            get
            {
                return mIntevel;
            }
        }
        private float mIntevel = 100.0f;

        public delegate void OnClickDelegate();
        public OnClickDelegate OnClickFunc;

        public void Start()
        {
        }

        public void OnDestroy()
        {
            if (mPressDownTimer != null)
            {
                mPressDownTimer.Destroy();
                mPressDownTimer = null;
            }
        }

        public void OnDisable()
        {
            StopRecord(false);
            if (mPressDownTimer != null)
            {
                mPressDownTimer.Destroy();
                mPressDownTimer = null;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (VoiceManager.Instance.IsUnloading)
            {
                if (VoiceManager.Instance.IsUploadingOverTime)
                {
                    VoiceManager.Instance.IsUnloading = false;
                }
                else
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_19"));
                    return;
                }
            }

            if (mPressDownTimer != null)
            {
                mPressDownTimer.Destroy();
                mPressDownTimer = null;
            }
            float max_press_time = RecordMaxTime + DelayTime;
            mPressDownTimer = new Utils.Timer(max_press_time, false, Intevel,
                      (dt) =>
                      {
                          mPressTime = max_press_time - dt;
                          if (mState == State.Idle && mPressTime > DelayTime)
                          {
                              mState = State.Recording;
                              VoiceManager.Instance.StartRecord();
                              ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_START_RECORD, new CEventBaseArgs());
                          }

                          if (dt <= 0)
                              StopRecord(true);
                      });
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (mPressDownTimer != null)
            {
                mPressDownTimer.Destroy();
                mPressDownTimer = null;
            }

            if (DelayTime > 0.0f && mPressTime < DelayTime)
            {
                if (OnClickFunc != null)
                    OnClickFunc();
                //ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_VOICE_CONTROL_POINTER_CLICK, new CEventUintArgs(Tag));
            }
            else
            {
                bool is_hover = false;
                foreach (var v in eventData.hovered)
                {
                    if (this.gameObject == v)
                    {
                        is_hover = true;
                        break;
                    }
                }
                StopRecord(is_hover);
            }

            mPressTime = 0.0f;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_VOICE_CONTROL_POINTER_ENTER, new CEventBaseArgs()); 
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_VOICE_CONTROL_POINTER_EXIT, new CEventBaseArgs());
        }

        protected void StopRecord(bool upload_file)
        {
            if (mState == State.Recording)
            {

                VoiceManager.Instance.StopRecord();
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_STOP_RECORD, new CEventBaseArgs());

                if (upload_file)
                {
                    if (mPressTime - DelayTime > RecordMinTime)
                    {
                        VoiceManager.Instance.UploadFile();
                    }
                    else
                    {
                        if (VoiceManager.Instance.IsCanSendByGameLogic)
                        {
                            // 录音时间太短
                            UINotice.Instance.ShowMessage(DBConstText.GetText("GAME_CHAT_RECORD_TIPS1"));
                        }
                    }
                }
            }
                
            mState = State.Idle;
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            if (VoiceManager.Instance.VoiceEngine == null)
            {
                return;
            }

            if (pauseStatus)
            {
                VoiceManager.Instance.VoiceEngine.Pause();
            }
            else
            {
                VoiceManager.Instance.VoiceEngine.Resume();
            }
        }
    }
}
