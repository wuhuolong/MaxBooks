using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc.ui;

namespace xc
{
    namespace ui
    {
        public class UIPanelFrameRotaionComponent : MonoBehaviour
        {
            public GameObject mNextObj;
            public GameObject mNowObj;
            private float Duration = 0.0f;

            private TweenRotation NowRotaion;
            private TweenRotation NextRotaion;
            public AudioClip RotationSound;
            public int State = 1;
            // Use this for initialization
            void Start()
            {
                
            }
            
            // Update is called once per frame
            void Update()
            {
            }

            public void Show(GameObject nowGo ,  GameObject nextGo  ,float duration)
            {
                int next = (int)Mathf.Abs(nextGo.transform.localRotation.eulerAngles.y);
                int now =  (int)Mathf.Abs(nowGo.transform.localRotation.eulerAngles.y);
                if(Mathf.Abs(next - now) < 90)
                    return;
                gameObject.layer = LayerMask.NameToLayer("UI2");
                NowRotaion = nowGo.GetComponent<TweenRotation>();
                if(NowRotaion != null)
                {
                    GameObject.Destroy(NowRotaion);
                    NowRotaion = null;
                }
                NowRotaion = nowGo.AddComponent<TweenRotation>();


                mNowObj = nowGo;
                mNextObj = nextGo;
                Duration = duration;
//                IsStart = true;
                Quaternion qua = mNowObj.transform.localRotation;
                qua.eulerAngles = Vector3.zero;
                mNowObj.transform.localRotation = qua;

                qua = mNextObj.transform.localRotation;
                qua.eulerAngles = new Vector3(0 , 90 , 0);
                mNextObj.transform.localRotation = qua;

                NowRotaion.from = Vector3.zero;
                NowRotaion.to = new Vector3(0 , -90 ,0);
                NowRotaion.duration = Duration/2;
                NowRotaion.ResetToBeginning();
                EventDelegate.Add(NowRotaion.onFinished ,  NowRoationFinsh);
                NowRotaion.PlayForward();
                mNextObj.SetActive(false);
                if(RotationSound !=null )
                    NGUITools.PlaySound(RotationSound, xc.GlobalSettings.GetInstance().SFXVolume, 1);
            }

            void NowRoationFinsh()
            {

                mNextObj.SetActive(true);
                EventDelegate.Remove(NowRotaion.onFinished ,  NowRoationFinsh);
                NextRotaion = mNextObj.GetComponent<TweenRotation>();
                if(NextRotaion != null)
                {
                    GameObject.Destroy(NextRotaion);
                    NextRotaion = null;
                }

                mNowObj.SetActive(false);
                NextRotaion = mNextObj.AddComponent<TweenRotation>();
                NextRotaion.from = new  Vector3(0 , 90 , 0);
                NextRotaion.to = Vector3.zero;
                NextRotaion.duration =Duration/2;
                NextRotaion.ResetToBeginning();
                NextRotaion.PlayForward();
                
                EventDelegate.Add(NextRotaion.onFinished ,  NextRoationFinsh);
            }

            public void SetState(int state , GameObject nowGo ,  GameObject nextGo)
            {
                State = state;
                Quaternion qua = new Quaternion();
                mNowObj = nowGo;
                mNextObj = nextGo;
                switch(State)
                {
                    case 1:
                        qua = mNowObj.transform.localRotation;
                        qua.eulerAngles = Vector3.zero;
                        mNowObj.transform.localRotation = qua;
                        
                        qua = mNextObj.transform.localRotation;
                        qua.eulerAngles = new Vector3(0 , 90 , 0);
                        mNextObj.transform.localRotation = qua;
                        mNowObj.SetActive(true);
                        mNextObj.SetActive(false);
                        break;
                    case 2:
                        qua = mNextObj.transform.localRotation;
                        qua.eulerAngles = Vector3.zero;
                        mNextObj.transform.localRotation = qua;

                        qua = mNowObj.transform.localRotation;
                        qua.eulerAngles = new Vector3(0 , 90 , 0);
                        mNowObj.transform.localRotation = qua;
                        mNowObj.SetActive(false);
                        mNextObj.SetActive(true);
                        break;
                }
            }

            void NextRoationFinsh()
            {
                if(State == 1)
                    State = 2;
                else
                    State = 1;
                gameObject.layer = LayerMask.NameToLayer("UI");
            }

            void OnEnable()
            {                
                gameObject.layer = LayerMask.NameToLayer("UI");
            }
            
            void Awake()
            {

            }
        }
    }
}


