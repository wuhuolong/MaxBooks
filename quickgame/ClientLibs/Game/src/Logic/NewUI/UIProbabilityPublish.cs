using System;
using System.Collections.Generic;
using System.Linq;
using Net;
using UnityEngine;
using UnityEngine.UI;
using xc.protocol;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIProbabilityPublish : MonoBehaviour
    {

        private Button mShowBtn;
        private string mOpenURL;
        private uint mSysID;
        void Awake()
        {
            mShowBtn = UIHelper.FindChildInHierarchy(gameObject.transform, "ShowButton").GetComponent<Button>();
            mShowBtn.onClick.RemoveAllListeners();
            mShowBtn.onClick.AddListener(OnClickShowBtn);
            //Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_KR_PROB_URL, HandleReceiveURL);
        }

        void OnDestroy()
        {
            //Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_KR_PROB_URL, HandleReceiveURL);
        }

        void HandleReceiveURL(ushort protocol, byte[] data)
        {
            if (protocol != NetMsg.MSG_KR_PROB_URL)
                return;
            var url_data = S2CPackBase.DeserializePack<S2CKrProbUrl>(data);
            if (url_data == null || url_data.sys_id != mSysID)
                return;
            string url = System.Text.Encoding.UTF8.GetString(url_data.url.First());
            SetOpenURL(url);
        }

        public void SetSysID(uint sys_id)
        {
            mSysID = sys_id;
            //var prob_url = new C2SKrProbUrl();
            //prob_url.sys_id = sys_id;
            //NetClient.GetBaseClient().SendData<C2SKrProbUrl>(NetMsg.MSG_KR_PROB_URL, prob_url);
        }

        public void SetOpenURL(string url)
        {
            mOpenURL = url;
        }

        void OnClickShowBtn()
        {
            if (!string.IsNullOrEmpty(mOpenURL))
            {
                Application.OpenURL(mOpenURL);
            }
        }
    }
}
