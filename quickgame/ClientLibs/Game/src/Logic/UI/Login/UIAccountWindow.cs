using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using xc;
using UnityEngine.UI;

namespace xc.ui.ugui
{
    public class UIAccountWindow : UIBaseWindow
    {
        public enum EMessageBoxType
        {
            MT_OK = 1,
            MT_OK_Cancel,
        };

        public class ServerInfo
        {
            public uint m_Id;
            public string m_Ip;
            public string m_Name;

            public ServerInfo(uint id, string ip, string name)
            {
                m_Id = id;
                m_Ip = ip;
                m_Name = name;
            }
        }

        // 登陆
        Toggle mDebugToggle;
        Button mLoginButton;
        InputField mAccountInput;
        InputField mServerInput;
        Image m_SelectImage;
        InputField mSuperTicketInput;
        InputField mHostURLInput;
        InputField mGameMarkInput;
        InputField mServerTypeInput;

        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public UIAccountWindow()
        {
            mWndName = "UIAccountWindow";
        }

        //--------------------------------------------------------
        //  虚函数
        //--------------------------------------------------------
        protected override void InitUI()
        {
            base.InitUI();

            mDebugToggle = FindChild("DebugToggle").GetComponent<Toggle>();
            mLoginButton = FindChild("LoginButton").GetComponent<Button>();
            mAccountInput = FindChild("AccountInput").GetComponent<InputField>();

            mSuperTicketInput = FindChild("SuperTicketInput").GetComponent<InputField>();
            mHostURLInput = FindChild("HostURLInput").GetComponent<InputField>();
            mGameMarkInput = FindChild("GameMarkInput").GetComponent<InputField>();
            mServerTypeInput = FindChild("ServerTypeInput").GetComponent<InputField>();

            mServerInput = FindChild<InputField>("ServerInput");

            mLoginButton.onClick.AddListener(OnClickLoginButton);
        }

        protected override void UnInitUI()
        {
            mLoginButton.onClick.RemoveAllListeners();
            //mServerListBtn.onClick.RemoveAllListeners();
            base.UnInitUI();
        }

        protected override void ResetUI()
        {
            base.ResetUI();

            if (mAccountInput != null)
            {
                mAccountInput.text = GlobalSettings.GetInstance().LastAccount;
            }

            if (mServerInput != null)
            {
                if(!string.IsNullOrEmpty(GlobalSettings.GetInstance().LastServer))
                {
                    mServerInput.text = GlobalSettings.GetInstance().LastServer;
                }
                else
                    SelectServer(0);
            }

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            globalConfig.LoginInfo.AccName = GlobalSettings.GetInstance().LastAccount;
        }

        protected override void HideUI()
        {
            base.HideUI();
        }

        //--------------------------------------------------------
        //  控件消息
        //--------------------------------------------------------

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        void OnClickLoginButton()
        {



#if UNITY_ANDROID
            GameDebug.LogError("hasNotch: " + DBOSManager.getDBOSManager().getBridge().hasNotch().ToString());
            GameDebug.LogError("getNotchSize: " + DBOSManager.getDBOSManager().getBridge().getNotchSize().ToString());
            GameDebug.LogError("Screen.safeArea: " + Screen.safeArea.ToString());
            GameDebug.LogError("StartTimeStamp: " + GlobalConfig.Instance.StartTimeStamp);
#endif

            Game game = xc.Game.GetInstance();
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            
            //快捷登录界面增加超级ticket，可直接登录外网服务器
            string superTicketStr = mSuperTicketInput.text;

            if (!string.IsNullOrEmpty(superTicketStr))
            {
                globalConfig.LoginInfo.Ticket = superTicketStr;
            }

            if (!string.IsNullOrEmpty(mHostURLInput.text))
            {
                GlobalConfig.DebugHostURL = mHostURLInput.text;
                globalConfig.ResetHostURL();
            }
            if (!string.IsNullOrEmpty(mGameMarkInput.text))
            {
                GlobalConfig.DebugGameMark = mGameMarkInput.text;
            }
            if (!string.IsNullOrEmpty(mServerTypeInput.text))
            {
                GlobalConfig.DebugServerType = int.Parse(mServerTypeInput.text);
            }

            if (mDebugToggle.isOn)
            {
                globalConfig.IsDebugMode = true;
                game.GameMode = (Game.EGameMode)((int)game.GameMode | (int)Game.EGameMode.GM_Debug);
                // 关卡测试
                SceneHelp.Instance.SwitchPreposeScene(GlobalConst.DefaultTestScene, true);
                game.GetFSM().React((uint)GameEvent.GE_SWITCH_PLAYING_TEST);
            }
            else
            {
                bool local_server = false;

#if UNITY_ANDROID || UNITY_IPHONE
                local_server = false;
#else
                string server_file = Application.streamingAssetsPath + "/server.txt";
                if (File.Exists(server_file))
                {
                    string accountStr = mAccountInput.text;
                    if (string.IsNullOrEmpty(accountStr))
                    {
                        UINotice.Instance.ShowMessage("请先输入账号");
                        return;
                    }

                    string server_ip = File.ReadAllText(server_file);
                    if (string.IsNullOrEmpty(server_ip) == false)
                    {
                        globalConfig.IsDebugMode = false;
                        globalConfig.LoginInfo.AccName = accountStr;
                        game.Account = accountStr;
                        GlobalSettings.GetInstance().LastAccount = accountStr;
                        GlobalSettings.GetInstance().LastServer = server_ip;

                        xc.ServerInfo server_info = new xc.ServerInfo();
                        server_info.Url = server_ip;
                        server_info.SId = 1;
                        GlobalConfig.GetInstance().LoginInfo.ServerInfo = server_info;
                        GlobalSettings.GetInstance().Save();

                        local_server = true;
                        LoginServer(server_ip);
                    }
                }
#endif

                if (local_server == false)
                    OnClickServerListButton();
            }
        }

        /// <summary>
        /// 点击选择服务器列表的按钮
        /// </summary>
        void OnClickServerListButton()
        {
            string accountStr = mAccountInput.text;
            if (string.IsNullOrEmpty(accountStr))
            {
                UINotice.Instance.ShowMessage("请先输入账号");
                return;
            }

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            globalConfig.LoginInfo.AccName = accountStr;
            Game.GetInstance().Account = accountStr;
            GlobalSettings.GetInstance().LastAccount = accountStr;
            GlobalSettings.GetInstance().Save();

            Close();

            UIManager.Instance.ShowWindow("UILoginWindow");

            //UIManager.Instance.ShowWindow("UIServerListWindow",1);
        }

        /// <summary>
        /// 点击服务器的按钮
        /// </summary>
        void OnClickServerButton(string ip, Button cur_btn)
        {
            if(mServerInput != null)
                mServerInput.text = ip;

            if(m_SelectImage != null && cur_btn != null)
            {
                m_SelectImage.transform.SetParent(cur_btn.transform);
                m_SelectImage.transform.localPosition = Vector3.zero;
                m_SelectImage.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// 选中某一服务器
        /// table_id : 服务器列表中的id
        /// </summary>
        void SelectServer(uint table_id)
        {
            List<Dictionary<string, string>> data_server_info = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "server_info", "id", table_id);

            if (data_server_info.Count > 0)
            {
                Dictionary<string, string> data = data_server_info[0];
                string ip = data["ip"];
                OnClickServerButton(ip, null);
            }
        }
        //--------------------------------------------------------
        // 内部调用
        //--------------------------------------------------------

        /// <summary>
        /// 根据获取的服务器信息来进行登陆
        /// </summary>
        void LoginServer(string url)
        {
            // 登陆服务器
            string[] ips = url.Split(':');
            Game game = Game.GetInstance();
            game.ServerIP = ips[0];
            game.ServerPort = DBTextResource.ParseI(ips[1]);
            game.ServerID = 1;

            game.GameMode = (Game.EGameMode)((int)game.GameMode | (int)xc.Game.EGameMode.GM_Net);
            game.Login();
        }
    }
}
