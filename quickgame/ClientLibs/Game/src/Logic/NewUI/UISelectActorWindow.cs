//-------------------------------------
// File: UISelectActorWindow.cs
// Desc: 选择角色的面板
// Author: raorui
// Date: 2017.10.16
//-------------------------------------
using UnityEngine;
using UnityEngine.UI;
using Net;
using System.Collections;
using System.Collections.Generic;
using xc.protocol;
using Utils;
using SGameEngine;

namespace xc
{
    namespace ui.ugui
    {
        [wxb.Hotfix]
        public class UISelectActorWindow : UIBaseWindow
        {
            public int ACTOR_MAX_NUM = 4;// 可以创建的最大角色数量

            /// <summary>
            /// 开始按钮
            /// </summary>
            Button mStartButton;

            /// <summary>
            /// 删除角色按钮
            /// </summary>
            Button mRemoveButton;

            /// <summary>
            /// 当前选中服务器的文本
            /// </summary>
            Text mServerText;

            /// <summary>
            /// 当前选中角色的战力信息
            /// </summary>
            Text mPowerText;

            /// <summary>
            /// 返回按钮
            /// </summary>
            Button mExitButton;

            /// <summary>
            /// 职业描述的根节点物体
            /// </summary>
            GameObject m_VocationDescRoot;

            /// <summary>
            /// 选择角色的按钮
            /// </summary>
            List<Button> mActorButton = new List<Button>();

            /// <summary>
            /// 加载的角色列表
            /// </summary>
            List<ClientModel> mActorGameObjects = new List<ClientModel>();

            /// <summary>
            /// 已经拥有角色的信息
            /// </summary>
            List<PkgPlayerBrief> mData;

            /// <summary>
            /// 当前已经选中的角色索引
            /// </summary>
            int mSelectIndex = -1;

            /// <summary>
            /// 所有的预加载资源
            /// </summary>
            List<AssetResource> mPreloadAssetResource = new List<AssetResource>();



            private List<GameObject> mActorPic = new List<GameObject>();

            /// <summary>
            /// 健康提示
            /// </summary>
            GameObject mHealthTips;

            /// <summary>
            /// 根据当前角色列表设置选择、创建角色按钮的显示
            /// </summary>
            private void SetData(List<PkgPlayerBrief> data)
            {
                mData = data;

                UpdateButtonList();

                if (data.Count > 0)
                {
                    if (mSelectIndex < 0 || mSelectIndex > data.Count - 1)
                    {
                        if (GlobalSettings.GetInstance().LastAccount.ToLower() == Game.GetInstance().Account.ToLower() &&
                            GlobalSettings.GetInstance().LastActorIndex < data.Count)
                            mSelectIndex = GlobalSettings.GetInstance().LastActorIndex;
                        else
                            mSelectIndex = 0;
                    }
                }
                else
                {
                    mSelectIndex = -1;
                }
            }


            public UISelectActorWindow()
            {
                //过审后还原
                //mPrefabName = SDKHelper.GetPrefabName("UISelectActorWindow", true);
            }


            protected override void InitUI()
            {
                base.InitUI();

                GameObject childObj = FindChild("StartButton");
                mStartButton = childObj.GetComponent<Button>();
                mRemoveButton = FindChild("RemoveButton").GetComponent<Button>();
                mExitButton = FindChild("ExitButton").GetComponent<Button>();
                m_VocationDescRoot = FindChild("VocationDesc");
                mPowerText = FindChild("PowerText").GetComponent<Text>();
                mHealthTips = FindChild("HealthTips");
                mHealthTips.SetActive(false);

                for (int i =0; i< ACTOR_MAX_NUM; ++i)
                {
                    string btnName = string.Format("Actor{0}Button", i + 1);
                    childObj = FindChild(btnName);
                    Button btn = childObj.GetComponent<Button>();
                    mActorButton.Add(btn);
                    //mActorGameObjects.Add(null);
                }

                mServerText = FindChild("ServerText").GetComponent<Text>();

                if (mUIObject.GetComponent<AutoScale>() == null)
                    mUIObject.AddComponent<AutoScale>();

                for (int i = 0; i < mActorButton.Count; ++i)
                {
                    int actor_index = i;
                    mActorButton[i].onClick.AddListener(() => { OnClickActor(actor_index); });
                }

                mStartButton.onClick.AddListener(OnClickStart);
                mRemoveButton.onClick.AddListener(OnClickRemove);
                mExitButton.onClick.AddListener(OnClickExit);


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




                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DELETE_ROLE, HandleDeleteRole);
            }

            protected override void UnInitUI()
            {
                if (mCheckCoroutine != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mCheckCoroutine);
                    mCheckCoroutine = null;
                }

                for (int i = 0; i < mActorButton.Count; ++i)
                {
                    mActorButton[i].onClick.RemoveAllListeners();
                }

                mStartButton.onClick.RemoveAllListeners();
                mRemoveButton.onClick.RemoveAllListeners();
                mExitButton.onClick.RemoveAllListeners();

                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_DELETE_ROLE, HandleDeleteRole);

                // 删除加载的角色
                for (int i=0; i< mActorGameObjects.Count; ++i)
                {
                    ClientModel go = mActorGameObjects [i];
                    if (go != null)
                    {
                        ActorManager.Instance.DestroyActor(go.UID);
                    }
                    mActorGameObjects [i] = null;
                    ObjCachePoolMgr.Instance.OnDestroyScene();
                }
            }

            protected override void ResetUI()
            {
                base.ResetUI();

                if (xc.Const.Region == xc.RegionType.SEASIA) {
                    if (xc.Const.Language == xc.LanguageType.VIETNAMESE) {
                        mHealthTips.SetActive(true);
                    }
                }

                ui.ugui.UIManager.GetInstance().ShowLoadingBK(true);
                ui.ugui.UIManager.GetInstance().SetLoadingTip(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_89"));

                // 删除加载的角色
                for (int i=0; i< mActorGameObjects.Count; ++i)
                {
                    ClientModel actor = mActorGameObjects [i];
                    if (actor != null)
                    {
                        actor.mVisibleCtrl.SetActorVisible(true, VisiblePriority.EXCEPT);
                        ActorManager.Instance.DestroyActor(actor.UID);
                        mActorGameObjects [i] = null;
                    }
                }

                // 设置角色列表的数据
                SetData(Game.GetInstance().CharacterList);

                UpdateServerName();

                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                {
                    MainGame.HeartBehavior.StartCoroutine(DelayShowWindow());
                }
                else
                {
                    MainGame.HeartBehavior.StartCoroutine(WaitForSelectAcotor());
                }

                // 进入选角场景
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.EnterSelectActorScene);
            }

            protected override void HideUI()
            {
                base.HideUI();

                foreach (var asset in mPreloadAssetResource)
                {
                    asset.destroy();
                }
                mPreloadAssetResource.Clear();
            }

            private IEnumerator DelayShowWindow()
            {
                yield return new WaitForSeconds(0.5f);

                OnAllActorLoaded();
            }

            public IEnumerator WaitForSelectAcotor()
            {
                while (SelectActorScene.Instance == null)
                {
                    yield return new WaitForEndOfFrame();
                }

                /*var preload_infos = DBPreloadInfo.Instance.PreloadInfos;
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
                        if(Time.unscaledTime - star_wait_time > 20.0f)
                        {
                            Debug.LogError("WaitForSelectAcotor: wait preload asset for long time");
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
                }*/

                // 创建角色
                for (int i = 0; i < ACTOR_MAX_NUM; ++i)
                {
                    CreateActor(i);
                }
            }

            /// <summary>
            /// 刷新角色选择列表按钮的显示
            /// </summary>
            public void UpdateButtonList()
            {
                for (int i = 0; i<ACTOR_MAX_NUM; ++i)
                {
                    Transform btn_trans = mActorButton[i].transform;
                    Transform select_trans = btn_trans.Find("Select");
                    Transform create_trans = btn_trans.Find("Create");

                    // 当前具备的角色数据
                    if (i<mData.Count)
                    {
                        select_trans.gameObject.SetActive(true);
                        create_trans.gameObject.SetActive(false);

                        string name = System.Text.Encoding.UTF8.GetString(mData[i].name);
                        select_trans.Find("Normal/NameText").GetComponent<Text>().text = name;
                        select_trans.Find("Selected/NameText").GetComponent<Text>().text = name;

                        uint peakLevel = 0;
                        bool isPeak = TransferHelper.IsPeak(mData[i].level, out peakLevel, mData[i].transfer);
                        if (isPeak == true)
                        {
                            select_trans.Find("Normal/LevelPanel/PeakLevelIconImage").gameObject.SetActive(true);
                            select_trans.Find("Selected/LevelPanel/PeakLevelIconImage").gameObject.SetActive(true);
                            select_trans.Find("Normal/LevelPanel/LevelText").GetComponent<Text>().text = peakLevel.ToString();
                            select_trans.Find("Selected/LevelPanel/LevelText").GetComponent<Text>().text = peakLevel.ToString();
                        }
                        else
                        {
                            select_trans.Find("Normal/LevelPanel/PeakLevelIconImage").gameObject.SetActive(false);
                            select_trans.Find("Selected/LevelPanel/PeakLevelIconImage").gameObject.SetActive(false);
                            select_trans.Find("Normal/LevelPanel/LevelText").GetComponent<Text>().text = "LV." + peakLevel.ToString();
                            select_trans.Find("Selected/LevelPanel/LevelText").GetComponent<Text>().text = "LV." + peakLevel.ToString();
                        }
                    }
                    // 还有可创建的空位
                    else if(i<Game.GetInstance().CharactorMaxCount)
                    {
                        select_trans.gameObject.SetActive(false);
                        create_trans.gameObject.SetActive(true);
                    }
                    // 剩下的不能创建
                    else
                    {
                        select_trans.gameObject.SetActive(false);
                        create_trans.gameObject.SetActive(true);
                    }
                }
            }

            // 重置删除按钮状态
            public void SetDeleteBtnState(int index)
            {
                if (IsCanRemove(mData[index]))
                    SetReomveBtnActive(true);
                else
                    SetReomveBtnActive(false);
            }

            // 设置删除按钮状态
            public void SetReomveBtnActive(bool bRet)
            {
                mRemoveButton.gameObject.SetActive(bRet);
            }

            // 判断是否符合删除条件
            public bool IsCanRemove(PkgPlayerBrief pkgPlayerBrief)
            {
                //@hzb 服务端删除字段
                //return pkgPlayerBrief.level < 10 && pkgPlayerBrief.is_charge != 1;
                return pkgPlayerBrief.level < 10;
            }

            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            Coroutine mCheckCoroutine = null;
            public void OnClickStart()
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
            public IEnumerator StartLogingCheck()
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
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg("检测到游戏资源有更新，请重启游戏进行更新操作。", (x) =>
                    {
                        DBOSManager.getOSBridge().reboot();
                    });
                }
                else
                    OnEnterGame();
            }

            // 点击开始，进入游戏
            public void OnEnterGame()
            {
                if (mSelectIndex < 0)
                {
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_90"));
                    return;
                }
                
                // 保存本地玩家ID
                UnitID uid = new UnitID();
                uid.type = (byte)EUnitType.UNITTYPE_PLAYER;
                uid.obj_idx = (uint)mData [mSelectIndex].uuid;
                
                Game.GetInstance().LocalPlayerID = uid;
                Game.GetInstance().LocalPlayerTypeID = ActorHelper.RoleIdToTypeId(mData [mSelectIndex].rid);
                Game.GetInstance().LocalPlayerName = System.Text.Encoding.UTF8.GetString(mData [mSelectIndex].name);

                // 保存选择的角色索引
                GlobalSettings.GetInstance().LastActorIndex = mSelectIndex;
                GlobalSettings.GetInstance().Save();
                
                // Enter Game
                C2SEnterGame c2sEnterGame = new C2SEnterGame();
                c2sEnterGame.uuid = mData[mSelectIndex].uuid;
                NetClient.GetBaseClient().SendData<C2SEnterGame>(NetMsg.MSG_ENTER_GAME, c2sEnterGame);

                GlobalConfig.GetInstance().LoginInfo.Name = System.Text.Encoding.UTF8.GetString(mData[mSelectIndex].name);
                GlobalConfig.GetInstance().LoginInfo.RId = mData [mSelectIndex].uuid.ToString();
                GlobalConfig.GetInstance().LoginInfo.Job = mData [mSelectIndex].rid.ToString();
                GlobalConfig.GetInstance().LoginInfo.Level = mData[mSelectIndex].level.ToString();
                ControlServerLogHelper.GetInstance().PostRoleInfo();

                // 注册FCM
                DBOSManager.getOSBridge().registerFCM();

                DBOSManager.getOSBridge().registerPush();

                // 为确保进入场景的角色等级判断正确，这里要赋值给LocalPlayerManager
                LocalPlayerManager.Instance.LocalActorAttribute.Level = mData[mSelectIndex].level;

                Game.Instance.IsCreateRoleEnter = false;

                xc.ui.ugui.UIManager.Instance.ShowWaitScreen(true);

                // 点击选角按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickSelectActorButton);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.select_role);
            }

            // 响应删除角色按钮点击
            public void OnClickRemove()
            {
                if (mSelectIndex < 0)
                {
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_90"));
                    return;
                }

                UIWidgetHelp.Instance.ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, "", xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_91"),
                (param) =>
                {
                    //发送删除角色网络
                    C2SDeleteRole c2sDeleteRole = new C2SDeleteRole();
                    c2sDeleteRole.uuid = mData[mSelectIndex].uuid;
                    NetClient.GetBaseClient().SendData<C2SDeleteRole>(NetMsg.MSG_DELETE_ROLE, c2sDeleteRole);
                }, null, null, null, xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel);
            }

            // 响应退出按钮点击
            public void OnClickExit()
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

            // 点击选择角色按钮
            public void OnClickActor(int btnIdx)
            {
                if(btnIdx < Game.GetInstance().CharactorMaxCount)
                {
                    OnClickActorImpl(btnIdx);
                }
                else
                {
                    SetReomveBtnActive(false);

                    string text = DBConstText.GetText("CREATE_ACTOR_SLOT_EMPTY");
                    if(string.IsNullOrEmpty(text))
                        text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_92");

                    UIWidgetHelp.GetInstance().ShowNoticeDlg(UINoticeWindow.EWindowType.WT_OK , text , null , null );
                }
            }

            public void OnClickActorImpl(int index)
            {
                if (mSelectIndex == index)
                    return;

                if (index < mData.Count)
                {
                    if (mSelectIndex != index)
                    {
                        mSelectIndex = index;
                        ShowActor(index);
                    }
                }
                else// 当选中的角色类型当前没有创建时，转到创建角色界面
                {
                    mSelectIndex = -1;

                    UIManager.Instance.ShowLoadingBK(true);

                    SceneHelp.Instance.SwitchPreposeScene(GlobalConst.CreateActorScene, false);// 创角场景

                    MainGame.HeartBehavior.StartCoroutine(ui.ugui.UIManager.Instance.SwitchUI("UICreateActorWindow", false));
                }
            }

            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            public void UpdateServerName()
            {
                if (GlobalConfig.GetInstance().LoginInfo.ServerInfo != null)
                    SetServerName(GlobalConfig.GetInstance().LoginInfo.ServerInfo.Name);
            }

            public void SetServerName(string serverName)
            {
                mServerText.text = serverName;
            }

            // 创建对应的角色
            public void CreateActor(int index)
            {
                if (index >= 0 && index < mData.Count)
                {

                    //if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetRoleList() != null)
                    //{
                    //    List<uint> npc_id = SDKHelper.GetRoleList();
                    //    int rid = (int)mData[index].rid - 1;
                    //    UnitID actor_uid = ClientModel.CreateClientModelByActorIdForLua(ActorHelper.RoleIdToCreateTypeId(npc_id[rid]), OnResLoaded);
                    //    var client_model = ActorManager.Instance.GetActor(actor_uid) as ClientModel;
                    //    client_model.AttackSpeed = 1.0f;
                    //    mActorGameObjects.Add(client_model);
                    //    return;
                    //}



                    uint type_idx = ActorHelper.RoleIdToTypeId(mData [index].rid); 

                    List<uint> model_list = new List<uint>();
                    List<uint> fashion_list = new List<uint>();
                    ActorHelper.GetModelFashionList(mData[index].shows, model_list, fashion_list);

                    if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel() && SDKHelper.GetFashion() != 0)
                    {
                        fashion_list.Add(SDKHelper.GetFashion());
                    }

                    var model_id_list = ActorManager.ReplaceModelList(model_list, (Actor.EVocationType)mData [index].rid, true);
                    ClientModel actor = ClientModel.CreateClientModel(type_idx, mData[index].uuid, model_id_list, fashion_list, mData[index].effects, OnResLoaded,false,true);
                    // 攻速必须为1，不然出场特效与动作匹配不上
                    actor.AttackSpeed = 1.0f;
                    mActorGameObjects.Add(actor);
                    actor.Freeze(DBActor.UF_ANIMATION);
                }
            }

            public void OnResLoaded(Actor actor)
            {
                if(SelectActorScene.Instance != null)
                {
                    //actor.WeaponEffectCtrl.InitWeaponEffect(info.AOIPlayer.weapon_effect_index);
                    //actor.ClearTextMesh();

                    GameObject go = actor.GetModelParent();
                    Transform actorPos = SelectActorScene.Instance.ActorPos;
                    go.transform.parent = actorPos;
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localRotation = Quaternion.identity;
                    go.transform.localScale = Vector3.one;

                    int layer = LayerMask.NameToLayer("UIPreview");
                    actor.mAvatarCtrl.SetLayer(layer);
                }
                    
                actor.mVisibleCtrl.SetActorVisible(false, VisiblePriority.EXCEPT);
                foreach (var item in mActorGameObjects)
                {
                    if (item != null && !item.IsResLoaded)
                    {
                        return;
                    }
                }

                OnAllActorLoaded();
            }

            public void ResetPos()
            {
                Transform actorPos = SelectActorScene.Instance.ActorPos;
                foreach (var item in mActorGameObjects)
                {
                    if(item  == null)
                    {
                        continue;
                    }
                    GameObject go = item.GetModelParent();
                    if (item.IsResLoaded)
                    {
                        go.transform.parent = actorPos;
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localRotation = Quaternion.identity;
                        go.transform.localScale = Vector3.one;
                    }
                }
            }

            // 所有的角色都加载完毕
            public void OnAllActorLoaded()
            {
                if (SelectActorScene.Instance != null)
                {
                    ResetPos();
                }

                UIManager.GetInstance().ShowLoadingBK(false);

                if (!IsShow)
                    return;

                int index = mSelectIndex;
                mSelectIndex = -1;
                OnClickActor(index);

                //test
                //Game.Instance.GameObjectControl.scene.SetActive(false);
                //Game.Instance.GameObjectControl.uiPanel.SetActive(true);

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


            }

            public void ShowActorPic(uint roleId)
            {
                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                {
                    for (int i = 0; i < mActorPic.Count; i++)
                    {
                        if (mActorPic[i] != null)
                        {
                            // 需要判断image.texture是否已加载成功;
                            // gameObject.SetActive(false)会把已启动的协程停止，导致图片不会加载
                            RawImage image = mActorPic[i].GetComponent<RawImage>();
                            if (image != null && image.texture != null)
                                mActorPic[i].gameObject.SetActive(i == roleId);
                        }
                    }
                }
            }


            // 显示当前选中的角色
            public void ShowActor(int index)
            {
                for(int i = 0; i < m_VocationDescRoot.transform.childCount; ++i)
                {
                    m_VocationDescRoot.transform.GetChild(i).gameObject.SetActive(false);
                }

                for (int i=0; i<ACTOR_MAX_NUM; ++i)
                {
                    if (i >= mData.Count)
                        continue;

                    var select_trans = mActorButton[i].transform.Find("Select");
                    var voc_info = DBVocationInfo.Instance.GetVocationInfo(mData[i].rid);

                    if (i == index)
                    {
                        select_trans.Find("Normal").gameObject.SetActive(false);
                        select_trans.Find("Selected").gameObject.SetActive(true);
                        select_trans.Find("IconImage").GetComponent<Image>().sprite = LoadSprite(voc_info.vocation_image_select);

                        if (AuditManager.Instance.AuditAndIOS() == false)
                        {
                            var desc_trans = m_VocationDescRoot.transform.Find(voc_info.vocation_desc);
                            if (desc_trans != null)
                            {
                                var desc_object = desc_trans.gameObject;
                                desc_object.SetActive(true);
                                SetTransferImage(desc_object.transform.Find("Image").GetComponent<Image>(), mData[i].transfer, mData[i].rid);
                            }
                        }

                        ShowActorPic(mData[i].rid - 1);
                    }
                    else
                    {
                        select_trans.Find("Normal").gameObject.SetActive(true);
                        select_trans.Find("Selected").gameObject.SetActive(false);
                        select_trans.Find("IconImage").GetComponent<Image>().sprite = LoadSprite(voc_info.vocation_image);
                    }
                }

                SetDeleteBtnState(index);

                SelectActor(index);
            }

            public void SetTransferImage(Image image, uint transferLevel, uint initVocation)
            {
                object[] param = { transferLevel, initVocation };
                System.Type[] returnType = { typeof(string) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "DBTransfer_GetYellowImageName", param, returnType);
                if (objs != null && objs.Length > 0 && objs[0] != null)
                {
                    image.sprite = LoadSprite((string)objs[0]);
                }
            }

            public void SelectActor(int actor_index)
            {
                if(!IsShow)
                    return;
                
                for (int i=0; i< mActorGameObjects.Count; ++i)
                {
                    Actor actor = mActorGameObjects [i];
                    if (actor != null)
                    {
                        actor.mVisibleCtrl.SetActorVisible(i == actor_index, VisiblePriority.EXCEPT);
                    }
                }
                
                if (actor_index >= 0 && actor_index < mActorGameObjects.Count)
                {
                    Actor selectObj = mActorGameObjects [actor_index];
                    if(selectObj != null)// 在切场景时，有可能选中的角色已经被销毁
                    {
                        if(SelectActorScene.Instance != null)
                            SelectActorScene.Instance.PreviewObject = selectObj.GetModelParent();
                        PreviewLight.SelectLight(1,mData[actor_index].rid);
                    }
                }

                if (actor_index < mData.Count)
                {
                    string name = System.Text.Encoding.UTF8.GetString(mData[actor_index].name);
                    mPowerText.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_93") + ActorHelper.GetDisplayBattlePower(mData[actor_index].battle_power);
                }
            }
            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------

            //--------------------------------------------------------
            //  网络消息
            //--------------------------------------------------------
            public void HandleDeleteRole(ushort protocol, byte[] data)
            {
                if (protocol != NetMsg.MSG_DELETE_ROLE)
                    return;

                S2CDeleteRole s2cDeleteRolePack = S2CPackBase.DeserializePack<S2CDeleteRole>(data);

                //此时还不知道客户端还不知道服务器当前时间，所以改为直接返回倒计时
                float delta = s2cDeleteRolePack.deadline;// - Game.Instance.ServerTime;
                if (delta > 0)
                {
                    string s = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_94"), Utils.Timer.GetFMTTime2(delta * 1000));
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(s);
                    return;
                }

                if (s2cDeleteRolePack.result != 1) // 删除不成功
                {
                    return;
                }

                // 删除选中的角色
                if (mActorGameObjects.Count > mSelectIndex)
                {
                    ClientModel actor = mActorGameObjects[mSelectIndex];
                    if (actor != null)
                    {
                        actor.mVisibleCtrl.SetActorVisible(true, VisiblePriority.EXCEPT);
                        ActorManager.Instance.DestroyActor(actor.UID);
                        mActorGameObjects.RemoveAt(mSelectIndex);
                    }
                }
                // 删除角色数据
                mData.RemoveAt(mSelectIndex);

                // 刷新角色选择框以及显示新角色
                UpdateButtonList();

                if (mSelectIndex > 0)
                {
                    mSelectIndex -= 1;
                    ShowActor(mSelectIndex);
                }
                else if (mSelectIndex == 0)
                {
                    //没有角色了
                    if (mData.Count == 0)
                    {
                        SetReomveBtnActive(false);
                        mSelectIndex = -1;
                        mPowerText.text = "";
                    }
                    else
                    {
                        ShowActor(0);
                    }
                }
            }
        }
    }
}
