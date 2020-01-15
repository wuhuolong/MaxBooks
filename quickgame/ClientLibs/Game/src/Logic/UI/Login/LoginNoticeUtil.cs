using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.ui.ugui
{
    public static class LoginNoticeUtil
    {
        public static void ShowNormalNotice()
        {
            //这里先获取后台通告信息
            string loginNoticeUrl = GlobalConfig.GetInstance().LoginNoticeUrl;

            GameDebug.Log("获取游戏公告" + loginNoticeUrl);

            MainGame.HttpRequest.GET(loginNoticeUrl, OnGetLoginNoticeInfo, false);
        }

        public static bool CheckData(string reply, out LoginNoticeData data)
        {
            data = new LoginNoticeData();

            data.FromJson(reply);
            if (data.result != 1)
            {
                GameDebug.LogError("解析公告失败: " + reply);
                return false;
            }

            return true;
        }

        private static void OnGetLoginNoticeInfo(string url, string error, string reply, object userData)
        {
            bool fromServerList = (bool)userData;

            if (string.IsNullOrEmpty(error) == false)
            {
                UIManager.Instance.ShowWaitScreen(false);

                GameDebug.LogError("获取游戏公告失败: " + error);
                string err = DBConstText.GetText("GET_LOGIN_NOTICE_INFO_FAIL");
#if UNITY_EDITOR
                err += error;
#endif
                UIWidgetHelp.GetInstance().ShowNoticeDlg(err);

                return;
            }

            LoginNoticeData data;
            if (!CheckData(reply, out data))
            {

                UIManager.Instance.ShowWaitScreen(false);

                GameDebug.LogError("获取游戏公告失败: " + error);
                string err = DBConstText.GetText("GET_LOGIN_NOTICE_INFO_FAIL");

                UIWidgetHelp.GetInstance().ShowNoticeDlg(err);

                return;
            }

            if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                return;

            //获取成功解析成功

            UIManager.Instance.ShowWindow("UILoginNoticeWindow", data, false);

            //if (string.IsNullOrEmpty(data.content) == false)
            //{
            //}
        }
    }
}
