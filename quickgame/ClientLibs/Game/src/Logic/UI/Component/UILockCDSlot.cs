//************************************
// 用作处理倒计时锁住的组件 使用的是改变rotation
//************************************
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Utils;
namespace xc.ui
{
   

    public class UILockCDSlot:MonoBehaviour
    {
        private uint CDTime;//时间戳
        private uint StartTime;
        private bool Is_CD = false;
        private float DetalTime;
        private float ZDetalRotation;
        private RectTransform CdImageTrans;
        private GameObject LockObj;
        private Text TimeText;
        public delegate void OnClickFunc( UILockCDSlot item);
        public OnClickFunc mFunc;
        public System.Object mParam;
        public LockState State { get; set; }
        private Button ItemButton;


        public static void Bind(GameObject obj)
        {
            if (obj.GetComponent<UILockCDSlot>() == null)
            {
                obj.AddComponent<UILockCDSlot>();
            }
        }

        /// <summary>
        /// 传的时间戳 设置倒计时开始或者倒计时结束
        /// </summary>
        /// <param name="time"></param>
        public void RestTime(uint start_cd,uint cd)
        {
            ZDetalRotation = 0;
            CDTime = 0;
            if (cd > Game.GetInstance().ServerTime)
            {
                Is_CD = true;
                CDTime = cd;
                StartTime = start_cd;
                gameObject.SetActive(true);
                var detal = (float)(CDTime - StartTime);
                var star_detal = Mathf.Abs((float)(Game.GetInstance().ServerTime - StartTime));
                ZDetalRotation = (1 - star_detal / detal) * 360.0f;
                CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, ZDetalRotation);
                CdImageTrans.gameObject.SetActive(true);
                State = LockState.CDIng;
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
            }
            else
            {
                Is_CD = false;
                CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, 360);
                gameObject.SetActive(true);
                if (CdImageTrans != null && TimeText != null)
                {
                    CdImageTrans.gameObject.SetActive(false);
                    TimeText.text = DBConstText.GetText("BAG_UNLOCK1");
                }
                State = LockState.CDEnd;
            }
        }
        /// <summary>
        ///服务器更新时间
        /// </summary>
        /// <param name="data"></param>
        void OnServerTimeUpdate(CEventBaseArgs data)
        {
            if (Is_CD == true)
            {
                if (CdImageTrans != null && TimeText != null)
                {
                    if (CDTime < Game.GetInstance().ServerTime)
                    {
                        Is_CD = false;
                        CdImageTrans.gameObject.SetActive(false);
                        TimeText.text = DBConstText.GetText("BAG_UNLOCK1");
                        DetalTime = 0;
                        CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, 360);
                    }
                    else
                    {

                        var detal = (float)(CDTime - StartTime);
                        var star_detal = Mathf.Abs((float)(Game.GetInstance().ServerTime - StartTime));
                        ZDetalRotation = (1- star_detal / detal) * 360.0f;
                        var cdEnd = CDTime - Game.GetInstance().ServerTime;
                        CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, ZDetalRotation);
                        TimeText.text = DateHelper.GetMMSS(cdEnd);
                    }
                }
            }
        }
        /// <summary>
        /// 设置没有开启倒计时状态
        /// </summary>
        public void SetNoStart()
        {
            gameObject.SetActive(true);
            if (CdImageTrans != null && TimeText != null)
            {
                CdImageTrans.gameObject.SetActive(false);
                TimeText.text = "";
            }
            State = LockState.NOStart;
        }

        public void Clear()
        {
            gameObject.SetActive(false);
            Is_CD = false;
            State = LockState.Open;
        }

        public void Init(OnClickFunc func, System.Object param = null)
        {
            if (CdImageTrans == null)
                CdImageTrans = transform.Find("CDImage").GetComponent<RectTransform>();
            if (TimeText == null)
                TimeText = transform.Find("Text").GetComponent<Text>();
            if (LockObj == null)
                LockObj = transform.Find("LockImage").gameObject;
            if (ItemButton == null)
            {
                ItemButton = gameObject.GetComponent<Button>();
                if (ItemButton != null)
                {
                    ItemButton.onClick.RemoveAllListeners();
                    ItemButton.onClick.AddListener(OnClickGoodsBtn);
                }
            }
            gameObject.SetActive(false);
            Is_CD = false;
            mFunc = func;
            State = LockState.Open;
            mParam = param;
        }

        void OnClickGoodsBtn()
        {
            if (mFunc != null)
            {
                mFunc(this);
            }
        }

        private void OnDisable()
        {
            Is_CD = false;
        }

        void Update()
        {
            
        }
    }
}


