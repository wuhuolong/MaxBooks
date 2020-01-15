using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using Utils;
using System;
using SGameEngine;

namespace xc
{
    namespace ui.ugui
    {
        [wxb.Hotfix]
        public class UICreateActorWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            /// <summary>
            /// 生成新名字按钮
            /// </summary>
            Button mGenerateNameButton;

            /// <summary>
            /// 进入游戏的按钮
            /// </summary>
            Button mEnterGameButton;

            /// <summary>
            /// 退出按钮 
            /// </summary>
            Button mExitButton;

            /// <summary>
            /// 职业描述的根节点
            /// </summary>
            Transform mVocationDesc;

            /// <summary>
            /// 创建角色的名字输入框
            /// </summary>
            InputField mNameInputField;

            /// <summary>
            /// 右上角
            /// </summary>
            GameObject mRightButtom;

            /// <summary>
            /// 右边
            /// </summary>
            GameObject mRight;

            /// <summary>
            /// 所有的角色按钮
            /// </summary>
            Dictionary<uint, Button> mActorButtons = new Dictionary<uint, Button>();

            /// <summary>
            /// 默认选择的角色，从1开始
            /// </summary>
            int mDefaultSelectIndex = 1;

            /// <summary>
            /// 当前选中的职业类型，从1开始
            /// </summary>
            uint mVocationId = 0;

            /// <summary>
            /// 可创建玩家的数量
            /// </summary>
            public int mActorNum = 4;

            /// <summary>
            /// 等待角色加载的协程
            /// </summary>
            Coroutine mWaitCoroutine;

            /// <summary>
            /// 所有的预加载资源
            /// </summary>
            List<AssetResource> mPreloadAssetResource = new List<AssetResource>();

            /// <summary>
            /// 隐藏loading界面的协程
            /// </summary>
            Coroutine mHideLoadingBKCoroutine;

            /// <summary>
            /// 健康提示
            /// </summary>
            GameObject mHealthTips;

            /// <summary>
            /// 创建新职业角色按钮，给策划临时用的，需要隐藏
            /// </summary>
            Button mCreateNewRoleButton;

            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------

            private List<GameObject> mActorPic = new List<GameObject>();


            public UICreateActorWindow()
            {
                //过审后还原
                mPrefabName = SDKHelper.GetPrefabName("UICreateActorWindow", true);
            }








            protected override void InitUI()
            {
                base.InitUI();

                mEnterGameButton = FindChild("EnterGameButton").GetComponent<Button>();
                mExitButton = FindChild("ExitButton").GetComponent<Button>();
                mGenerateNameButton = FindChild("GenerateNameButton").GetComponent<Button>();
                mNameInputField = FindChild("NameInputField").GetComponent<InputField>();
                mVocationDesc = FindChild("VocationDesc").transform;
                mRightButtom = FindChild("RightButtom");
                mRight = FindChild("Right");
                mHealthTips = FindChild("HealthTips");
                mHealthTips.SetActive(false);
                mCreateNewRoleButton = FindChild("CreateNewRoleButton").GetComponent<Button>();
                mCreateNewRoleButton.gameObject.SetActive(false);

                // 获取最大可创建角色数量
                var role_ids = GameConstHelper.GetUintList("GAME_AVAILABLE_ROLE_ID");
                mActorNum = role_ids.Count;
                // 获取创角按钮
                mActorButtons.Clear();



                if (AuditManager.Instance.AuditAndIOS())
                {
                    for (int i = 0; i < mActorNum; ++i)
                    {
                        var btn_game_object = FindChild(string.Format("VocationButton{0}", i + 1));
                        if (btn_game_object != null)
                        {
                            btn_game_object.gameObject.SetActive(false);
                        }
                    }
                    //int[] actorList = new int[] { 2, 1 ,3 };
                    List<uint> actorList = SDKHelper.GetRoleList();
                    if (actorList != null)
                    {
                        bool isShowActorBtn = actorList.Count > 1;

                        for (int i = 0; i < actorList.Count; i++)
                        {
                            int career = (int)actorList[i];
                            var btn_game_object = FindChild(string.Format("VocationButton{0}", career));
                            if (btn_game_object != null)
                            {
                                btn_game_object.gameObject.SetActive(isShowActorBtn);
                                btn_game_object.transform.Find("CheckMask").gameObject.SetActive(false);
                                btn_game_object.transform.Find("Background").gameObject.SetActive(true);
                                mActorButtons.Add((uint)career, btn_game_object.GetComponent<Button>());
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < mActorNum; ++i)
                    {
                        var btn_game_object = FindChild(string.Format("VocationButton{0}", i + 1));
                        if (btn_game_object != null)
                        {
                            mActorButtons.Add((uint)(i + 1), btn_game_object.GetComponent<Button>());
                        }
                    }
                }
                mEnterGameButton.onClick.AddListener(OnClickEnterGameBtn);
                mExitButton.onClick.AddListener(OnClickExitBtn);
                mGenerateNameButton.onClick.AddListener(OnClickNameBtn);
                foreach (var kv in mActorButtons)
                {
                    var btn = kv.Value;
                    if(btn != null)
                        btn.onClick.AddListener(() => {OnClickActorBtn(kv.Key); });
                }
                mCreateNewRoleButton.onClick.AddListener(OnClickCreateNewRoleButton);


                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject go = FindChild("ActorPic" + (i + 1).ToString());
                        if (go != null)
                        {
                            LoadMaJiaImage majia = go.AddComponent<LoadMaJiaImage>();
                            var picName = string.Format("ActorPic{0}.png", (i + 1));
                            majia.mPath = ResNameMapping.Instance.GetMappingName(picName);
                            majia.SetFailCallBack(() =>
                            {
                                RawImage image = majia.GetComponent<RawImage>();
                                if (image != null)
                                    image.color = new Color(0, 0, 0, 0);
                            });
                            mActorPic.Add(go);
                        }
                    }
                }
                


                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_CREATE_ROLE, HandleCreateRole);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_RANDNAME_UPDATE, OnRandNameUpdate);
            }

            protected override void UnInitUI()
            {
                if (mCheckCoroutine != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mCheckCoroutine);
                    mCheckCoroutine = null;
                }

                mGenerateNameButton.onClick.RemoveAllListeners();
                mExitButton.onClick.RemoveAllListeners();
                mEnterGameButton.onClick.RemoveAllListeners();
                foreach (var kv in mActorButtons)
                {
                    kv.Value.onClick.RemoveAllListeners();
                }
                mCreateNewRoleButton.onClick.RemoveAllListeners();

                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_CREATE_ROLE, HandleCreateRole);
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_RANDNAME_UPDATE, OnRandNameUpdate);

                base.UnInitUI();
            }
            
            protected override void ResetUI()
            {
                base.ResetUI();

                RefreshDescription();
                mNameInputField.text = "";

                if (xc.Const.Region == xc.RegionType.SEASIA) {
                    if (xc.Const.Language == xc.LanguageType.VIETNAMESE) {
                        mHealthTips.SetActive(true);
                    }
                }

                // 创建角色UI必处于游戏初始化状态
                UIManager.GetInstance().ShowLoadingBK(true);
                UIManager.Instance.SetLoadingTip(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_88"));

                mWaitCoroutine = MainGame.HeartBehavior.StartCoroutine(WaitActorLoad());

                // 进入创角场景
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.EnterCreateActorScene);
            }

            protected override void HideUI()
            {
                base.HideUI();

                if(mWaitCoroutine != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mWaitCoroutine);
                    mWaitCoroutine = null;
                }

                if (mHideLoadingBKCoroutine != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mHideLoadingBKCoroutine);
                    mHideLoadingBKCoroutine = null;
                }

                foreach (var asset in mPreloadAssetResource)
                {
                    asset.destroy();
                }
                mPreloadAssetResource.Clear();
            }

            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            IEnumerator WaitActorLoad()
            {
                while(CreateActorScene.Instance == null || CreateActorScene.Instance.LoadFinish == false || CreateActorScene.Instance.TimelinesIsLoadFinished == false)
                {
                    yield return null;
                }

                var isAuditAndIos = AuditManager.Instance.AuditAndIOS();
                if (!isAuditAndIos || (isAuditAndIos && !SDKHelper.GetSwitchModel()))
                {
                    var preload_infos = DBPreloadInfo.Instance.PreloadInfos;
                    if (preload_infos.Count > 0)
                    {
                        mPreloadAssetResource.Clear();
                        foreach (var info in preload_infos)
                        {
                            var object_asset = new AssetResource();
                            mPreloadAssetResource.Add(object_asset);
                            MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset("Assets/" + info.asset_path, typeof(UnityEngine.Object), object_asset));
                        }

                        float star_wait_time = Time.unscaledTime;

                        // 等待所有资源加载完毕
                        while (true)
                        {
                            // 最多等待20s
                            if (Time.unscaledTime - star_wait_time > 20.0f)
                            {
                                Debug.LogError("WaitActorLoad: wait preload asset for long time");
                                break;
                            }

                            bool all_loaded = true;
                            foreach (var info in mPreloadAssetResource)
                            {
                                if (info.asset_ == null)
                                {
                                    all_loaded = false;
                                    break;
                                }
                            }

                            if (all_loaded)
                                break;
                            else
                                yield return null;
                        }
                    }
                }

                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                {
                    GameObjectControl control = Game.Instance.GameObjectControl;
                    if (control != null)
                    {
                        if (control.scene != null && control.uiPanel != null)
                        {
                            control.scene.SetActive(!AuditManager.Instance.Open);
                            control.uiPanel.SetActive(AuditManager.Instance.Open);
                        }
                    }
                }

                //int[] actorList = new int[] { 2, 1, 3 };
                if (AuditManager.Instance.AuditAndIOS())
                {
                    List<uint> actorList = SDKHelper.GetRoleList();
                    if (actorList != null && actorList.Count >= 1)
                        mDefaultSelectIndex = (int)actorList[0];
                }

                OnClickActorBtn((uint)mDefaultSelectIndex);

                // 等待一帧才隐藏loading界面，避免播放剧情前穿帮
                mHideLoadingBKCoroutine = MainGame.HeartBehavior.StartCoroutine(EndFrameHideLoadingBK());
            }

            IEnumerator EndFrameHideLoadingBK()
            {
                yield return new WaitForEndOfFrame();

                UIManager.Instance.ShowLoadingBK(false);

                //UINotice.Instance.ShowMessage("灰度服测试补丁");
            }

            /// <summary>
            /// 请求玩家名字
            /// </summary>
            void RequestRoleName()
            {
                uint sex = 1;
                var voc_info = DBVocationInfo.Instance.GetVocationInfo(mVocationId);
                if (voc_info != null)
                    sex = (uint)voc_info.sex_type;

                var get_rand_name = new C2SAccGetRandName();
                get_rand_name.sex = sex;
                get_rand_name.language = TranslateManager.GetInstance().ConvertToServerLang(Const.Language);
                NetClient.GetBaseClient().SendData<C2SAccGetRandName>(NetMsg.MSG_ACC_GET_RAND_NAME, get_rand_name);
            }

            /// <summary>
            /// 设置职业描述的图片
            /// </summary>
            void RefreshDescription()
            {
                for (int i = 0; i < mVocationDesc.childCount; ++i)
                {
                    var child_trans = mVocationDesc.GetChild(i);
                    child_trans.gameObject.SetActive(false);
                }

                if (AuditManager.Instance.AuditAndIOS())
                {
                    return;
                }


                var voc_info = DBVocationInfo.Instance.GetVocationInfo(mVocationId);
                if(voc_info != null)
                {
                    Transform trans = mVocationDesc.Find(voc_info.vocation_desc);
                    if (trans != null)
                        trans.gameObject.SetActive(true);
                }
            }

            #region 控件消息
            /// <summary>
            /// 点击角色职业的按钮
            /// </summary>
            /// <param name="vocation"></param>
            void OnClickActorBtn(uint vocation)
            {
                // 设置当前的CheckMask
                var cur_select_btn = mActorButtons[vocation].transform;
                cur_select_btn.Find("CheckMask").gameObject.SetActive(true); 
                cur_select_btn.Find("Background").gameObject.SetActive(false);
                if (mVocationId == vocation)
                {
                    return;
                }

                // 设置之前的CheckMask
                if (mVocationId != 0)
                {
                    var last_select_btn = mActorButtons[mVocationId].transform;
                    last_select_btn.Find("CheckMask").gameObject.SetActive(false);
                    last_select_btn.Find("Background").gameObject.SetActive(true);
                }

                if (CreateActorScene.Instance && CreateActorScene.Instance.SelectActorByVocation(vocation, () =>
                {
                    if (IsShow == true)
                    {
                        mRightButtom.SetActive(true);
                        mRight.SetActive(true);
                    }
                }))
                {

                    if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                    {
                        for (int i = 0; i < mActorPic.Count; i++)
                        {
                            if (mActorPic[i] != null)
                            {
                                RawImage image = mActorPic[i].GetComponent<RawImage>();
                                if (image != null && image.texture != null)
                                    mActorPic[i].gameObject.SetActive(i + 1 == vocation);
                            }
                        }
                    }

                    mVocationId = vocation;
                    RequestRoleName();

                    PreviewLight.SelectLight(1,mVocationId);
                    RefreshDescription();

                    if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                        return;

                    mRightButtom.SetActive(false);
                    mRight.SetActive(false);

                    if (AuditManager.Instance.AuditAndIOS() == false)
                    {
                        mRightButtom.SetActive(true);
                        mRight.SetActive(true);
                    }

                }
            }

            /// <summary>
            /// 点击获取名字的按钮
            /// </summary>
            void OnClickNameBtn()
            {
                RequestRoleName();
            }

            /// <summary>
            /// 点击退出按钮
            /// </summary>
            void OnClickExitBtn()
            {
                if (Game.GetInstance().CharacterList.Count == 0)
                {
                    if (Const.Region == RegionType.CHINA)
                    {
                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                    }
                    else
                    {
                        if (Const.Region == RegionType.KOREA)
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_END, new CEventBaseArgs());

                        Close();
                        GlobalConfig globalConfig = GlobalConfig.GetInstance();
                        if (globalConfig.IsEnterSDK)
                        {
                            UIManager.Instance.ShowWindow("UIQuickLoginWindow", true);
                        }
                        else
                        {
                            if (Game.Instance.IsSkillEditorScene == false)
                            {
                                UIManager.Instance.ShowWindow("UILoginWindow");
                            }
                        }
                    }
                }
                else
                {
                    SceneHelp.Instance.SwitchPreposeScene(GlobalConst.SelectActorScene, false);// 选角场景
                    MainGame.HeartBehavior.StartCoroutine(ui.ugui.UIManager.Instance.SwitchUI("UISelectActorWindow", false));
                }
            }

            Coroutine mCheckCoroutine = null;

            /// <summary>
            /// 点击创建角色的按钮
            /// </summary>
            void OnClickEnterGameBtn()
            {
                if (mCheckCoroutine != null)
                    return;

                if (Const.Region == RegionType.KOREA)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_END, new CEventBaseArgs());
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CREATEACTOR_TO_GAMESCENE_BEGIN, new CEventBaseArgs());
                }
                mCheckCoroutine = MainGame.HeartBehavior.StartCoroutine(StartLogingCheck());
            }

            /// <summary>
            /// 进行更新检查
            /// </summary>
            /// <returns></returns>
            IEnumerator StartLogingCheck()
            {
                // 读取游戏常量表的配置
                bool isSupportGrayServer = false;
#if UNITY_IPHONE
                if (GameConstHelper.GetUint("GAME_SYS_IS_SUPPORT_GRAY_SERVER_IOS") > 0)
                {
                    isSupportGrayServer = true;
                }
#else
                if (GameConstHelper.GetUint("GAME_SYS_IS_SUPPORT_GRAY_SERVER") > 0)
                {
                    isSupportGrayServer = true;
                }
#endif

                // 检查当前包是否支持灰度服的更新检查
                if (!GrayServerManager.Instance.IsSupportGrayServer() || !isSupportGrayServer)
                {
                    OnEnterGame();
                    yield break;
                }

                // 上次登录的服务器ID与当前服务器ID相同时，不需要检查灰度服更新
                var lastServerId = GrayServerManager.Instance.GetLoginServer();
                var curServerId = 0;
                if (GlobalConfig.Instance.LoginInfo != null && GlobalConfig.Instance.LoginInfo.ServerInfo != null)
                {
                    curServerId = GlobalConfig.Instance.LoginInfo.ServerInfo.SId;
                }
                if (lastServerId == curServerId)
                {
                    OnEnterGame();
                    yield break;
                }

                // 记录最新的服务器ID
                GrayServerManager.Instance.RecordLoginServer(curServerId);

#if UNITY_EDITOR
                // editor下使用android的资源来测试
                var server_url = @"http://s01.huiwaninfo.net:8087/XControl/v2/servlet/UpdateCheck?game_mark=zl_cehua&platform=android&appv=2.0.0&libv=0.0.0&imei=359786050902015&device_mark=&cpu=Intel&extend=&api_ver=1.0&res_v=1&res_v=1";
#else
                var server_url = DBOSManager.getOSBridge().getUpdateCheckUrl();
#endif

                // 获取最新资源版本
                GrayServerManager.Instance.SetUpdateURL(server_url);
                yield return MainGame.HeartBehavior.StartCoroutine(GrayServerManager.Instance.CheckUpdate(curServerId));
                var updateInfo = GrayServerManager.Instance.UpdateInfo;

                bool needUpdate = false;
                if (updateInfo != null)
                {
                    // 判断是否有更新
                    var versionInfo = VersionInfoManager.Instance.LocalVersionInfo;
                    if (versionInfo != null)
                    {
                        foreach (var info in versionInfo)
                        {
                            var local_version = info.Value;
                            var server_version = 0;
                            if (updateInfo.TryGetValue(info.Key, out server_version))
                            {
                                if (local_version < server_version)
                                {
                                    needUpdate = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (mCheckCoroutine != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mCheckCoroutine);
                    mCheckCoroutine = null;
                }

                // 有更新时需要重新启动游戏
                if (needUpdate)
                {
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg("检测到游戏资源有更新，请重启游戏进行更新操作。", (x) => {DBOSManager.getOSBridge().reboot();
                    });
                }
                else
                    OnEnterGame();
            }

            /// <summary>
            /// 进入游戏
            /// </summary>
            void OnEnterGame()
            {
                string char_name = mNameInputField.text;

                // 判断是否输入了角色名
                if (char_name.Length <= 0)
                {
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL1")); //请输入角色名
                    return;
                }

                // 韩国版的角色名字和聊天敏感字库读取不同的表，其他
                if (Const.Region == RegionType.KOREA)
                {
                    // 判断角色名字是否合法
                    if (SensitiveWordsFilterPlayerName.Instance.IsInputUserNameLegal(char_name) == false)
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL2")); //角色名请使用汉字，英文或者数字
                        return;
                    }

                    // 判断角色名中的敏感字符
                    if (SensitiveWordsFilterPlayerName.GetInstance().IsHaveSensitiveWords(char_name))
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL3"));//角色名中包含敏感字符
                        return;
                    }
                }
                else
                {
                    // 判断角色名字是否合法
                    if (SensitiveWordsFilter.Instance.IsInputUserNameLegal(char_name, Const.Region) == false)
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL2")); //角色名请使用汉字，英文或者数字
                        return;
                    }

                    // 判断角色名中的敏感字符
                    if (SensitiveWordsFilter.GetInstance().IsHaveSensitiveWords(char_name))
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL3"));//角色名中包含敏感字符
                        return;
                    }
                }

                // 判断角色名字是否超长
                var utf8_parse = new Utf8Parse(char_name);
                float role_name_len = utf8_parse.GetWordLenByRule();
                if (role_name_len > (float)GameConstHelper.GetFloat("GAME_NAME_MAX_COUNT"))
                {
                    UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("NAME_COUNT_EXCEED"));
                    GameDebug.Log("role_name_len:" + role_name_len);
                    return;
                }

                if (GlobalConfig.GetInstance().LoginInfo == null || GlobalConfig.GetInstance().LoginInfo.ServerInfo == null)
                {
                    return;
                }

                // 发送创建角色的协议
                var create_role = new C2SCreateRole();
                create_role.name = System.Text.Encoding.UTF8.GetBytes(char_name); ;
                create_role.rid = mVocationId; // actor type, 从1开始
                create_role.server_id = (uint)GlobalConfig.GetInstance().LoginInfo.ServerInfo.SId;
                if (string.IsNullOrEmpty(GlobalConfig.GetInstance().LoginInfo.ProviderPassport))
                    create_role.chn_passport = System.Text.Encoding.UTF8.GetBytes("provider_passport");
                else
                    create_role.chn_passport = System.Text.Encoding.UTF8.GetBytes(GlobalConfig.GetInstance().LoginInfo.ProviderPassport);

                
                if (AuditManager.Instance.AuditAndIOS())
                {
                    SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                    if (sdkConfig != null)
                    {
                        create_role.majia_id = sdkConfig.copy_bag_id;
                        create_role.majia_pack = sdkConfig.copy_bag_id;
                    }
                }
                else
                {
                    SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                    if (sdkConfig != null)
                    {
                        create_role.majia_id = 0;
                        create_role.majia_pack = sdkConfig.copy_bag_id;
                    }
                }
                ControlServerLogHelper.CreatePkgAccPhoneInfos(create_role.phone_info);

                NetClient.GetBaseClient().SendData<C2SCreateRole>(NetMsg.MSG_CREATE_ROLE, create_role);

                if (Const.Region == RegionType.KOREA)
                {
                    var ret = UserPlayerPrefs.Instance.GetInt(BuriedPointConst.koreaFirstCreateCharacter, 0);
                    if (ret == 0)
                    {
                        UserPlayerPrefs.Instance.SetInt(BuriedPointConst.koreaFirstCreateCharacter, 1);
                        UserPlayerPrefs.Instance.Save();
                        BuriedPointHelper.ReportAppsflyerEvnet("af_character");
                    }
                }

                // 保存创建角色的名字
                GlobalConfig.GetInstance().LoginInfo.Name = char_name;

                // 记录上一次选中的职业
                GlobalSettings.GetInstance().LastActorIndex = Game.GetInstance().CharacterList.Count;
                GlobalSettings.GetInstance().Save();

                Game.Instance.IsCreateRoleEnter = true;


                UIManager.Instance.ShowWaitScreen(true);

                // 点击创角按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickCreateActorButton);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.create_role);

                // 点击选角按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickSelectActorButton);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.select_role);
            }

            void OnClickCreateNewRoleButton()
            {
                string char_name = mNameInputField.text;

                // 判断是否输入了角色名
                if (char_name.Length <= 0)
                {
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL1")); //请输入角色名
                    return;
                }

                // 韩国版的角色名字和聊天敏感字库读取不同的表，其他
                if (Const.Region == RegionType.KOREA)
                {
                    // 判断角色名字是否合法
                    if (SensitiveWordsFilterPlayerName.Instance.IsInputUserNameLegal(char_name) == false)
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL2")); //角色名请使用汉字，英文或者数字
                        return;
                    }

                    // 判断角色名中的敏感字符
                    if (SensitiveWordsFilterPlayerName.GetInstance().IsHaveSensitiveWords(char_name))
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL3"));//角色名中包含敏感字符
                        return;
                    }
                }
                else
                {
                    // 判断角色名字是否合法
                    if (SensitiveWordsFilter.Instance.IsInputUserNameLegal(char_name, Const.Region) == false)
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL2")); //角色名请使用汉字，英文或者数字
                        return;
                    }

                    // 判断角色名中的敏感字符
                    if (SensitiveWordsFilter.GetInstance().IsHaveSensitiveWords(char_name))
                    {
                        ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("CREATE_ROLE_FAIL3"));//角色名中包含敏感字符
                        return;
                    }
                }

                // 判断角色名字是否超长
                var utf8_parse = new Utf8Parse(char_name);
                float role_name_len = utf8_parse.GetWordLenByRule();
                if (role_name_len > (float)GameConstHelper.GetFloat("GAME_NAME_MAX_COUNT"))
                {
                    UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("NAME_COUNT_EXCEED"));
                    GameDebug.Log("role_name_len:" + role_name_len);
                    return;
                }

                if (GlobalConfig.GetInstance().LoginInfo == null || GlobalConfig.GetInstance().LoginInfo.ServerInfo == null)
                {
                    return;
                }

                mVocationId = 4;

                // 发送创建角色的协议
                var create_role = new C2SCreateRole();
                create_role.name = System.Text.Encoding.UTF8.GetBytes(char_name); ;
                create_role.rid = mVocationId; // actor type, 从1开始
                create_role.server_id = (uint)GlobalConfig.GetInstance().LoginInfo.ServerInfo.SId;
                if (string.IsNullOrEmpty(GlobalConfig.GetInstance().LoginInfo.ProviderPassport))
                    create_role.chn_passport = System.Text.Encoding.UTF8.GetBytes("provider_passport");
                else
                    create_role.chn_passport = System.Text.Encoding.UTF8.GetBytes(GlobalConfig.GetInstance().LoginInfo.ProviderPassport);


                if (AuditManager.Instance.AuditAndIOS())
                {
                    SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                    if (sdkConfig != null)
                    {
                        create_role.majia_id = sdkConfig.copy_bag_id;
                        create_role.majia_pack = sdkConfig.copy_bag_id;
                    }
                }
                else
                {
                    SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                    if (sdkConfig != null)
                    {
                        create_role.majia_id = 0;
                        create_role.majia_pack = sdkConfig.copy_bag_id;
                    }
                }
                ControlServerLogHelper.CreatePkgAccPhoneInfos(create_role.phone_info);

                NetClient.GetBaseClient().SendData<C2SCreateRole>(NetMsg.MSG_CREATE_ROLE, create_role);

                // 保存创建角色的名字
                GlobalConfig.GetInstance().LoginInfo.Name = char_name;

                // 记录上一次选中的职业
                GlobalSettings.GetInstance().LastActorIndex = Game.GetInstance().CharacterList.Count;
                GlobalSettings.GetInstance().Save();

                Game.Instance.IsCreateRoleEnter = true;


                UIManager.Instance.ShowWaitScreen(true);

                // 点击创角按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickCreateActorButton);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.create_role);

                // 点击选角按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickSelectActorButton);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.select_role);
            }
#endregion

            #region 网络消息
            /// <summary>
            /// 响应注册的网络消息
            /// </summary>
            /// <param name="protocol"></param>
            /// <param name="data"></param>
            void HandleCreateRole(ushort protocol, byte[] data)
            {
                if (protocol != NetMsg.MSG_CREATE_ROLE)
                    return;

                var create_role = S2CPackBase.DeserializePack<S2CCreateRole>(data);
                if (create_role.result != 1) // 创建不成功
                {
                    string content = ""; 
                    
                    DBErrorCode db_error_code = (DBErrorCode)DBManager.GetInstance().GetDB(typeof(DBErrorCode).Name);
                    DBErrorCode.ErrorInfo errorInfo = db_error_code.GetErrorInfo(create_role.result);
                    if (errorInfo == null) 
                        content = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_35");
                    else
                        content = errorInfo.mDesc;

                    GameDebug.LogError(string.Format("服务端报错: {0}", content));
                    UINotice.GetInstance().ShowMessage(content);

                    UIManager.Instance.ShowWaitScreen(false);
                    return; 
                }
                    
                // 保存本地玩家ID
                UnitID uid = new UnitID();
                uid.type = (byte)EUnitType.UNITTYPE_PLAYER;
                uid.obj_idx = (uint)create_role.uuid;
                Game.GetInstance().LocalPlayerID = uid;
                Game.GetInstance().LocalPlayerTypeID = ActorHelper.RoleIdToTypeId(mVocationId);
                Game.GetInstance().LocalPlayerName = mNameInputField.text;

                // 保存角色职业信息
                GlobalConfig.GetInstance().LoginInfo.RId = create_role.uuid.ToString();
                GlobalConfig.GetInstance().LoginInfo.Job = mVocationId.ToString();
                GlobalConfig.GetInstance().LoginInfo.Level = "0";
                GlobalConfig.GetInstance().LoginInfo.CreateRoleTime = create_role.now.ToString();

                // 通知服务端
                var enter_game = new C2SEnterGame();
                enter_game.uuid = create_role.uuid;
                NetClient.GetBaseClient().SendData<C2SEnterGame>(NetMsg.MSG_ENTER_GAME, enter_game);

                // 通知控制服
                ControlServerLogHelper.GetInstance().PostRoleInfo();

                // 通知sdk，sendRoleInfo2SDK要求等级最小为1，需要特殊处理
                GlobalConfig.GetInstance().LoginInfo.Level = "1";
                SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.CREATE_ROLE);

                // 创角埋点数据上报
                if (xc.Const.Region == xc.RegionType.KOREA)
                {
                    xc.BuriedPointHelper.ReportTapjoyEvnet("account generate");
                }

                // 注册FCM
                DBOSManager.getOSBridge().registerFCM();

                // 注册推送服务
                DBOSManager.getOSBridge().registerPush();
            }
#endregion

#region 客户端消息
            /// <summary>
            /// 响应名字更新的事件
            /// </summary>
            /// <param name="data"></param>
            void OnRandNameUpdate(CEventBaseArgs data)
            {
                if (mNameInputField != null)
                {
                    string role_name = (string)data.arg;
                    if (string.IsNullOrEmpty(role_name) == false)
                        mNameInputField.text = role_name;
                }
            }
#endregion
        }
    }
}

