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

    public enum LockState
    {
        NOStart = 0,
        CDIng,
        CDEnd,
        Open,
    }

    public class UINewLockCDSlot : MonoBehaviour
    {
        private uint CDTime;//时间戳
        private uint StartTime;
        private bool Is_CD = false;
        private float DetalTime;
        private float ZDetalRotation;
        private RectTransform CdImageTrans;
        private Image mLockImage;
        private Text TimeText;
        public delegate void OnClickFunc(UINewLockCDSlot item);
        public OnClickFunc mFunc;
        public System.Object mParam;
        public LockState State { get; set; }
        private Button ItemButton;

        private bool isCdListener = false;


        public static UINewLockCDSlot Bind(GameObject obj)
        {
            if (obj.GetComponent<UINewLockCDSlot>() == null)
            {
                obj.AddComponent<UINewLockCDSlot>();
            }
            var slot = obj.GetComponent<UINewLockCDSlot>();
            slot.CheckRef();
            return slot;
        }

        private void CheckRef()
        {
            var empty_node_trans = transform.Find("EmptyNode");
            if (empty_node_trans == null)// 兼容之前的旧UI
                empty_node_trans = transform;

            Transform child_trans = null;
            if (CdImageTrans == null)
            {
                child_trans = empty_node_trans.Find("CDImage");
                if(child_trans != null)
                    CdImageTrans = child_trans.GetComponent<RectTransform>();
            }

            if (mLockImage == null)
            {
                child_trans = empty_node_trans.Find("LockImage");
                if (child_trans != null)
                    mLockImage = child_trans.GetComponent<Image>();
            }

            if (TimeText == null)
            {
                child_trans = empty_node_trans.Find("Text");
                if (child_trans != null)
                    TimeText = child_trans.GetComponent<Text>();
            }

            if (ItemButton == null)
            {
                ItemButton = transform.GetComponent<Button>();
                if(ItemButton == null)
                {
                    var lock_trans = empty_node_trans.Find("LockPanel");
                    if(lock_trans != null)
                        ItemButton = lock_trans.GetComponent<Button>();
                }
                    
                if(ItemButton != null)
                {
                    ItemButton.onClick.RemoveAllListeners();
                    ItemButton.onClick.AddListener(OnClickGoodsBtn);
                }
            }

            Is_CD = false;
            mFunc = null;
            State = LockState.Open;
            mParam = null;
        }

        public void OnDestroy()
        {
            mFunc = null;
            mParam = null;

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
        }

        public void Dispose()
        {
            mFunc = null;
            mParam = null;

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
        }


        public void SetClickCallback(OnClickFunc func, System.Object param = null)
        {
            this.mFunc = func;
            this.mParam = param;
        }

        /// <summary>
        /// 传的时间戳 设置倒计时开始或者倒计时结束
        /// </summary>
        /// <param name="time"></param>
        public void RestTime(uint start_cd, uint cd)
        {
            ZDetalRotation = 0;
            CDTime = 0;

            if(TimeText != null)
                CommonTool.SetActive(TimeText.gameObject, true);

            if (cd > Game.GetInstance().ServerTime)
            {
                Is_CD = true;
                CDTime = cd;
                StartTime = start_cd;
                //gameObject.SetActive(true);
                var detal = (float)(CDTime - StartTime);
                var star_detal = Mathf.Abs((float)(Game.GetInstance().ServerTime - StartTime));
                ZDetalRotation = (1 - star_detal / detal) * 360.0f;
                if(CdImageTrans != null)
                {
                    CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, ZDetalRotation);
                    CdImageTrans.gameObject.SetActive(true);
                }
                
                State = LockState.CDIng;
                if (mLockImage != null)
                {
                    CommonTool.SetActive(mLockImage.gameObject, true);
                    mLockImage.color = new Color(255.0f, 255.0f,255.0f,128.0f);
                }
                
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
            }
            else
            {
                Is_CD = false;
                CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, 360);

                if (CdImageTrans != null && TimeText != null)
                {
                    CommonTool.SetActive(CdImageTrans.gameObject, false);
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
                if(TimeText != null)
                    CommonTool.SetActive(TimeText.gameObject, true);

                if (CdImageTrans != null && TimeText != null)
                {
                    if (CDTime < Game.GetInstance().ServerTime)
                    {
                        Is_CD = false;
                        CommonTool.SetActive(CdImageTrans.gameObject, false);
                        TimeText.text = DBConstText.GetText("BAG_UNLOCK1");
                        DetalTime = 0;
                        CdImageTrans.localEulerAngles = new Vector3(CdImageTrans.localEulerAngles.x, CdImageTrans.localEulerAngles.y, 360);
                    }
                    else
                    {

                        var detal = (float)(CDTime - StartTime);
                        var star_detal = Mathf.Abs((float)(Game.GetInstance().ServerTime - StartTime));
                        ZDetalRotation = (1 - star_detal / detal) * 360.0f;
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

            if (mLockImage != null)
            {
                CommonTool.SetActive(mLockImage.gameObject, true);
                mLockImage.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            }

            if(CdImageTrans != null)
            {
                CommonTool.SetActive(CdImageTrans.gameObject, false);
            }

            if(TimeText != null)
                TimeText.text = "";
            State = LockState.NOStart;
        }

        public void Clear()
        {
            if(TimeText != null)
            {
                CommonTool.SetActive(TimeText.gameObject, false);
            }

            if (mLockImage != null)
            {
                CommonTool.SetActive(mLockImage.gameObject, false);
            }

            if(CdImageTrans != null)
            {
                CommonTool.SetActive(CdImageTrans.gameObject, false);
            }

            Is_CD = false;
            State = LockState.Open;
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


