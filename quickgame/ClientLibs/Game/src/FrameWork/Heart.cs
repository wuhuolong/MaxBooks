using System;
using System.Collections;
using UnityEngine;

namespace xc
{
	public class Heart : MonoBehaviour
	{
		Game mGame;
		void Awake()
		{
			mGame = Game.GetInstance();
		}
		
		void Update()
		{
			mGame.Update();
		}
		
		void LateUpdate()
		{
			GameInput.GetInstance().Update();
		}

        public void SystemMessage(string param)
        {
            if (param == "SDKInitFinish")
            {
                Debug.Log("[PlatformMsg]SDKInitFinish]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_INITED, null);
            }
            else if (param == "SDKLoginSuccess")
            {
                Debug.Log("[PlatformMsg]SDKLoginSuccess]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_LOGINSUCC, null);
            }
            else if (param == "NotifyToURL")
            {
                Debug.Log("[PlatformMsg]NotifyToURL]");
                IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                string url = bridge.getNotifyURL();
                if (!string.IsNullOrEmpty(url))
                {
                    bridge.openWebView(url);
                }
            }
            else if (param == "FinishedLogout")
            {
                Debug.Log("[FinishedLogout]");
                xc.ControlServerLogHelper.Instance.PostPlayerFollowRecord(xc.PlayerFollowRecordSceneId.FinishedLogout);
                Game.GetInstance().Rebot();
            }
            else if (param == "BindVerifyCodeSendSuc")
            {
                Debug.Log("[SDK BindVerifyCodeSendSuc]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_SEND_VERIFY_CODE_RET, new CEventBaseArgs(true));
            }
            else if (param == "BindVerifyCodeSendFail")
            {
                Debug.Log("[SDK BindVerifyCodeSendFail]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_SEND_VERIFY_CODE_RET, new CEventBaseArgs(false));
            }
            else if (param == "BindPhoneNumSuc")
            {
                Debug.Log("[SDK BindPhoneNumSuc]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_BIND_PHONE_RET, new CEventBaseArgs(true));
            }
            else if (param == "BindPhoneNumFail")
            {
                Debug.Log("[SDK BindPhoneNumFail]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_BIND_PHONE_RET, new CEventBaseArgs(false));
            }
            else if (param == "Binded") // 旧端使用的是Binded事件
            {
                Debug.Log("[SDK Phone Number Binded]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_BIND_PHONE_RET, new CEventBaseArgs(true));
            }
            else if (param == "DoFacebookShareSuccess")
            {
                Debug.Log("[SDK DoFacebookShareSuccess]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_FACEBOOK_SHARE_SUCCESS, new CEventBaseArgs(true));
            }
            else if (param == "DoFacebookShareFailed")
            {
                Debug.Log("[SDK DoFacebookShareFailed]");
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_FACEBOOK_SHARE_FAILED, new CEventBaseArgs(true));
            }
        }

        public void SystemMessageEx(string param)
        {
            /*{
                "action":"PayCallback",
                "code":1,  // 1:成功 -1:取消
                "msg":"支付成功"

            }*/

            var json_object = MiniJSON.JsonDecode(param);
            if (json_object == null)
            {
                Debug.LogError("SystemMessageEx: json is invalid");
                return;
            }

            Hashtable param_info = json_object as Hashtable;
            if (param_info == null)
            {
                Debug.LogError("SystemMessageEx: param_info is invalid");
                return;
            }

            string action = param_info["action"].ToString();
            if(action == "PayCallback") // 支付的回调
            {
                int code = int.Parse(param_info["code"].ToString());
                string msg = param_info["msg"].ToString();
                if (code == 1)// 成功或者取消的时候才提示
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("PAY_NOTICE_SUCC")); 
                }
                else if (code == -1)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("PAY_NOTICE_CANCEL"));
                }
                else
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("PAY_NOTICE_FAIL"));
                }
            }
        }

        public void OnApplicationQuit()
        {
            Game.GetInstance().Quit(false);
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_APPLICATION_PAUSE, new CEventBaseArgs(pauseStatus));
        }
    }
}
