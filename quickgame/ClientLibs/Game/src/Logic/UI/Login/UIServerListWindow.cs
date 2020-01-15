using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using xc.Maths;

namespace xc.ui.ugui
{

    /// <summary>
    /// 选择服务器列表面板，只负责选择服务器
    /// </summary>
    [wxb.Hotfix]
    public class UIServerListWindow : UIBaseWindow
    {
        //--------------------------------------------------------
        //  变量定义
        //--------------------------------------------------------
        ServerInfo mSelectedServerInfo;

        List<Utils.DecimalTimer> mMaintainingServerTimers;

        // 选服界面
        Button mCloseServerListPanelButton;

        // 大区列表界面
        GameObject mRegionListContent;
        GameObject mRegionItem;
        ScrollViewEx mRegionListScrollViewEx;
        List<RegionInfo> mRegionList;
        GameObject mOriginalSelectedRegionItem; // 初始选中的大区item
        int mCurSelectedRegionItemIndex;    // 当前选中大区item的index
        GameObject mLastSelectedRegionItemCheckMark;    // 上一次选中的大区的CheckMark

        // 已有角色界面
        GameObject mHaveRoleServerListPanel;
        GameObject mHaveRoleServerListContent;
        GameObject mHaveRoleServerItem;
        SpriteList mRoleHeadSpriteList;

        // 推荐界面
        GameObject mRecommendServerListPanel;
        GameObject mRecommendServerListContent;
        GameObject mRecommendServerItem;
        GameObject mWillOpenServerListContent;
        GameObject mWillOpenServerItem;

        // 普通服务器列表界面
        GameObject mNormalServerListPanel;
        GameObject mNormalServerListContent;
        GameObject mNormalServerItem;




        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public UIServerListWindow()
        {
            //过审后不需还原
            mPrefabName = SDKHelper.GetPrefabName("UIServerListWindow", false);

        }
                    
        //--------------------------------------------------------
        //  虚函数
        //--------------------------------------------------------
        protected override void InitUI()
        {
            base.InitUI();

            mSelectedServerInfo = null;
            mMaintainingServerTimers = new List<Utils.DecimalTimer>();
            mMaintainingServerTimers.Clear();

            // 选服界面
            mCloseServerListPanelButton = FindChild<Button>("CloseServerListPanelButton");
            mCloseServerListPanelButton.onClick.AddListener(OnClickCloseServerListPanelButton);

            // 大区列表界面
            mRegionListContent = FindChild<Transform>("RegionListContent").gameObject;
            mRegionItem = FindChild<Transform>("RegionItem").gameObject;
            mRegionItem.SetActive(false);
            mRegionListScrollViewEx = FindChild<ScrollViewEx>("RegionListScrollView");
            mRegionListScrollViewEx.LoopItemRefreshData = UpdateRegionItem;

            // 已有角色界面
            mHaveRoleServerListPanel = FindChild<Transform>("HaveRoleServerListPanel").gameObject;
            mHaveRoleServerListContent = FindChild<Transform>("HaveRoleServerListContent").gameObject;
            mHaveRoleServerItem = FindChild<Transform>("HaveRoleServerItem").gameObject;
            mHaveRoleServerItem.SetActive(false);
            mRoleHeadSpriteList = FindChild<Transform>("RoleHeadPanel").GetComponent<SpriteList>();

            // 推荐界面
            mRecommendServerListPanel = FindChild<Transform>("RecommendServerListPanel").gameObject;
            mRecommendServerListContent = FindChild<Transform>("RecommendServerListContent").gameObject;
            mRecommendServerItem = FindChild<Transform>("RecommendServerItem").gameObject;
            mRecommendServerItem.SetActive(false);
            mWillOpenServerListContent = FindChild<Transform>("WillOpenServerListContent").gameObject;
            mWillOpenServerItem = FindChild<Transform>("WillOpenServerItem").gameObject;
            mWillOpenServerItem.SetActive(false);

            // 普通服务器列表界面
            mNormalServerListPanel = FindChild<Transform>("NormalServerListPanel").gameObject;
            mNormalServerListContent = FindChild<Transform>("NormalServerListContent").gameObject;
            mNormalServerItem = FindChild<Transform>("NormalServerItem").gameObject;
            mNormalServerItem.SetActive(false);
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            mCloseServerListPanelButton.onClick.RemoveAllListeners();

            DestoryMaintainingServerTimers();

            ServerListHelper.Instance.ClearAllCallback();
        }
        
        protected override void ResetUI()
        {
            base.ResetUI();
            //UpdateLoginNotice();
            //SetSelectedServerInfo(null);
            mSelectedServerInfo = null;
            UpdateServerLogic();
        }

        public void UpdateServerLogic()
        {
            ShowServerListPanel();
        }

        protected override void HideUI()
        {
            base.HideUI();
        }

        public void GetAllRegionFinished(List<RegionInfo> regionList)
        {
            UIManager.Instance.ShowWaitScreen(false);

            mRegionList = regionList;

            mOriginalSelectedRegionItem = null;
            mCurSelectedRegionItemIndex = 1;    // 默认选中推荐大区，index是1
            int regionCount = 0;
            if (regionList != null)
            {
                regionCount = regionList.Count;
            }
            mRegionListScrollViewEx.dataCount = regionCount + 2;   // 大区列表长度加上已有角色和推荐列表，所以要+2

            if (mOriginalSelectedRegionItem != null)
            {
                mLastSelectedRegionItemCheckMark = mOriginalSelectedRegionItem.transform.Find("Background/Checkmark").gameObject;
            }

            ShowRecommendServerListPanel();
        }

        public void ShowServerListPanel()
        {
            mHaveRoleServerListPanel.SetActive(false);
            mRecommendServerListPanel.SetActive(false);
            mNormalServerListPanel.SetActive(false);

            DestoryMaintainingServerTimers();

            mRegionListScrollViewEx.dataCount = 0;

            UIManager.Instance.ShowWaitScreen(true);
            mRegionList = null;
            ServerListHelper.Instance.GetAllRegion(GetAllRegionFinished);
        }

        public Button UpdateOneRegionItem(GameObject item, int index, string regionName, string toggleName, UnityEngine.Events.UnityAction clickCallback)
        {
            item.name = toggleName;
            Transform itemTrans = item.transform;

            // 名字
            Text nameText = itemTrans.Find("NameText").GetComponent<Text>();
            nameText.text = regionName;

            // 选中效果
            GameObject checkMark = itemTrans.Find("Background/Checkmark").gameObject;
            if (mCurSelectedRegionItemIndex == index)
            {
                checkMark.SetActive(true);
            }
            else
            {
                checkMark.SetActive(false);
            }

            Button button = itemTrans.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (mLastSelectedRegionItemCheckMark != null)
                {
                    mLastSelectedRegionItemCheckMark.SetActive(false);
                }
                checkMark.SetActive(true);
                mLastSelectedRegionItemCheckMark = checkMark;

                if (clickCallback != null)
                {
                    clickCallback();
                }
            });

            return button;
        }

        public bool UpdateRegionItem(GameObject go, int index)
        {
            if (index == 0) // 已有角色服务器
            {
                UpdateOneRegionItem(go, index, DBConstText.GetText("HAVE_ROLE_REGION"), "Region_HaveRole", () =>
                {
                    ShowHaveRoleServerListPanel();

                    mCurSelectedRegionItemIndex = index;
                });
            }
            else if (index == 1)    // 推荐服务器
            {
                Button button = UpdateOneRegionItem(go, index, DBConstText.GetText("RECOMMEND_REGION"), "Region_Recommend", () =>
                {
                    ShowRecommendServerListPanel();

                    mCurSelectedRegionItemIndex = index;
                });

                if (mOriginalSelectedRegionItem == null)
                {
                    mOriginalSelectedRegionItem = button.gameObject;
                }
            }
            else if (index > 1)  // 普通的服务器
            {
                if (mRegionList.Count > 0)
                {
                    RegionInfo regionInfo = mRegionList[index - 2];
                    UpdateOneRegionItem(go, index, regionInfo.Name, "Region_" + regionInfo.Id, () =>
                    {
                        ShowNormalServerListPanel(regionInfo.Id);

                        mCurSelectedRegionItemIndex = index;
                    });
                }
            }

            return true;
        }

        public void GetServerDataFinished(List<RegionInfo> regionList, List<ServerInfo> serverList, int lastLoginServerId)
        {
            UIManager.Instance.ShowWaitScreen(false);

            if (serverList != null)
            {
                foreach (ServerInfo serverInfo in ServerListHelper.GetHaveRoleServerList(serverList))
                {
                    InsertOneHaveRoleServerItem(serverInfo);
                }
            }
        }

        public void ShowHaveRoleServerListPanel()
        {
            mHaveRoleServerListPanel.SetActive(true);
            mRecommendServerListPanel.SetActive(false);
            mNormalServerListPanel.SetActive(false);

            DestoryMaintainingServerTimers();

            RemoveAllChildrenExcludeList(mHaveRoleServerListContent.transform, new List<string> { "HaveRoleServerItem" });

            ServerListHelper.Instance.ClearAllCallback();

            UIManager.Instance.ShowWaitScreen(true);
            ServerListHelper.Instance.GetServerData(GetServerDataFinished);
        }

        public void InsertOneHaveRoleServerItem(ServerInfo serverInfo)
        {
            GameObject item = GameObject.Instantiate(mHaveRoleServerItem);
            item.SetActive(true);
            item.name = "Server_" + serverInfo.ServerId;
            Transform itemTrans = item.transform;
            itemTrans.SetParent(mHaveRoleServerListContent.transform);
            itemTrans.localScale = Vector3.one;
            itemTrans.localPosition = Vector3.zero;

            // 名字
            Text nameText = itemTrans.Find("NameText").GetComponent<Text>();
            nameText.text = serverInfo.Name;

            // 状态
            Image stateImage = itemTrans.Find("StateImage").GetComponent<Image>();
            stateImage.sprite = GetSpriteByState(serverInfo.State);

            // 类型
            GameObject tag = itemTrans.Find("Tag").gameObject;
            if (serverInfo.Type == EServerType.New || serverInfo.Type == EServerType.RecommendAndNew)
            {
                tag.SetActive(true);
            }
            else
            {
                tag.SetActive(false);
            }

            // 角色头像
            GameObject roleHead = itemTrans.Find("RoleHeadPanel").Find("RoleHead").gameObject;
            roleHead.SetActive(false);
            if (serverInfo.RoleList != null)
            {
                foreach (ServerRoleInfo serverRoleInfo in serverInfo.RoleList)
                {
                    InsertOneServerRoleHead(roleHead, serverRoleInfo);
                }
            }

            // 按钮
            Button button = itemTrans.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (ServerListHelper.Instance.CheckServerState(serverInfo, false) == true)
                {
                    SetSelectedServerInfo(serverInfo);
                    OnClickCloseServerListPanelButton();
                }
                else
                {
                    ServerListHelper.GetInstance().CheckServerStateAndEnter(serverInfo, (ServerInfo retServerInfo, bool canEnter) =>
                    {
                        if (canEnter == true)
                        {
                            SetSelectedServerInfo(serverInfo);
                            OnClickCloseServerListPanelButton();
                        }
                        else
                        {
                            ServerListHelper.Instance.CheckServerState(serverInfo, false);

                            // 推荐别的服务器需要关闭服务器列表界面
                            if (serverInfo != null && serverInfo.State == EServerState.NotRecomm)
                            {
                                OnClickCloseServerListPanelButton();
                            }
                        }
                    }, false);
                }
            });
        }

        public void InsertOneServerRoleHead(GameObject roleHead, ServerRoleInfo serverRoleInfo)
        {
            GameObject item = GameObject.Instantiate(roleHead);
            item.SetActive(true);
            item.name = "ServerRole_" + serverRoleInfo.RoleId;
            Transform itemTrans = item.transform;
            itemTrans.SetParent(roleHead.transform.parent);
            itemTrans.localScale = Vector3.one;
            itemTrans.localPosition = Vector3.zero;

            // 等级，新角色控制服会发0过来，强制显示成1
            Text levelText = itemTrans.Find("Text").GetComponent<Text>();
            if (serverRoleInfo.Level <= 0)
            {
                levelText.text = "1";
            }
            else
            {
                // 巅峰等级
                Image lvBGImage = itemTrans.Find("LvBG").GetComponent<Image>();
                Image peakLvBGImage = itemTrans.Find("PeakLvBG").GetComponent<Image>();
                uint peakLevel = 0;
                bool isPeak = TransferHelper.IsPeak((uint)serverRoleInfo.Level, out peakLevel, serverRoleInfo.TransferLv);
                if (isPeak == true)
                {
                    lvBGImage.gameObject.SetActive(false);
                    peakLvBGImage.gameObject.SetActive(true);
                }
                else
                {
                    lvBGImage.gameObject.SetActive(true);
                    peakLvBGImage.gameObject.SetActive(false);
                }
                levelText.text = peakLevel.ToString();
            }

            // 头像
            Image headImage = itemTrans.Find("HeadImage").GetComponent<Image>();
            headImage.sprite = mRoleHeadSpriteList.LoadSprite(RoleHelp.GetPlayerIconName((uint)serverRoleInfo.IconId, serverRoleInfo.TransferLv, false));
        }

        public void ShowRecommendServerListPanel()
        {
            mHaveRoleServerListPanel.SetActive(false);
            mRecommendServerListPanel.SetActive(true);
            mNormalServerListPanel.SetActive(false);

            DestoryMaintainingServerTimers();

            RemoveAllChildrenExcludeList(mRecommendServerListContent.transform, new List<string> { "RecommendServerItem" });
            RemoveAllChildrenExcludeList(mWillOpenServerListContent.transform, new List<string> { "WillOpenServerItem" });

            ServerListHelper.Instance.ClearAllCallback();

            UIManager.Instance.ShowWaitScreen(true);
            ServerListHelper.Instance.GetAllRecommServer(GetAllRecommServerFinished);
        }

        public void GetAllRecommServerFinished(List<ServerInfo> recomServerList, List<ServerInfo> willOpenServerList, List<ServerInfo> loginServerList)
        {
            UIManager.Instance.ShowWaitScreen(false);

            RemoveAllChildrenExcludeList(mRecommendServerListContent.transform, new List<string> { "RecommendServerItem" });
            RemoveAllChildrenExcludeList(mWillOpenServerListContent.transform, new List<string> { "WillOpenServerItem" });

            if (recomServerList != null)
            {
                foreach (ServerInfo serverInfo in recomServerList)
                {
                    InsertOneNormalServerItem(mRecommendServerListContent, mRecommendServerItem, serverInfo);
                }
            }
            if (willOpenServerList != null)
            {
                foreach (ServerInfo serverInfo in willOpenServerList)
                {
                    InsertOneWillOpenServerItem(serverInfo);
                }
            }
        }

        public void InsertOneWillOpenServerItem(ServerInfo serverInfo)
        {
            GameObject item = GameObject.Instantiate(mWillOpenServerItem);
            item.SetActive(true);
            item.name = "Server_" + serverInfo.ServerId;
            Transform itemTrans = item.transform;
            itemTrans.SetParent(mWillOpenServerListContent.transform);
            itemTrans.localScale = Vector3.one;
            itemTrans.localPosition = Vector3.zero;

            // 名字
            Text nameText = itemTrans.Find("NameText").GetComponent<Text>();
            nameText.text = serverInfo.Name;

            // 时间
            Text timeText = itemTrans.Find("TimeText").GetComponent<Text>();
            if (serverInfo.CountDownTime > 0)
            {
                Utils.DecimalTimer timer = new Utils.DecimalTimer((decimal)(serverInfo.CountDownTime) * 1000, false, 1000, (decimal remainTime, Utils.DecimalTimer t) =>
                {
                    if (remainTime <= 0)
                    {
                        timeText.text = "";
                        t.Destroy();
                        mMaintainingServerTimers.Remove(t);
                        
                        GameObject.DestroyImmediate(item);
                    }
                    else
                    {
                        timeText.text = DBConstText.GetText("MAINTAINING_REMAIN_TIME") + TimeTraslateHMS.GetFMTTime(remainTime);
                    }
                }, null);
                mMaintainingServerTimers.Add(timer);
            }
            else
            {
                timeText.text = "";
            }

            // 状态
            Image stateImage = itemTrans.Find("StateImage").GetComponent<Image>();
            stateImage.sprite = GetSpriteByState(serverInfo.State);

            // 按钮
            Button button = itemTrans.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (ServerListHelper.Instance.CheckServerState(serverInfo, false) == true)
                {
                    SetSelectedServerInfo(serverInfo);
                    OnClickCloseServerListPanelButton();
                }
                else
                {
                    ServerListHelper.GetInstance().CheckServerStateAndEnter(serverInfo, (ServerInfo retServerInfo, bool canEnter) =>
                    {
                        if (canEnter == true)
                        {
                            SetSelectedServerInfo(serverInfo);
                            OnClickCloseServerListPanelButton();
                        }
                        else
                        {
                            ServerListHelper.Instance.CheckServerState(serverInfo, false);

                            // 推荐别的服务器需要关闭服务器列表界面
                            if (serverInfo != null && serverInfo.State == EServerState.NotRecomm)
                            {
                                OnClickCloseServerListPanelButton();
                            }
                        }
                    }, false);
                }
            });
        }

        public void ShowNormalServerListPanel(int regionId)
        {
            mHaveRoleServerListPanel.SetActive(false);
            mRecommendServerListPanel.SetActive(false);
            mNormalServerListPanel.SetActive(true);

            DestoryMaintainingServerTimers();

            RemoveAllChildrenExcludeList(mNormalServerListContent.transform, new List<string> { "NormalServerItem" });

            ServerListHelper.Instance.ClearAllCallback();

            UIManager.Instance.ShowWaitScreen(true);
            ServerListHelper.Instance.GetServerList(regionId, GetServerListFinished);
        }

        public void GetServerListFinished(List<ServerInfo> serverList)
        {
            UIManager.Instance.ShowWaitScreen(false);

            if (serverList != null)
            {
                foreach (ServerInfo serverInfo in serverList)
                {
                    InsertOneNormalServerItem(mNormalServerListContent, mNormalServerItem, serverInfo);
                }
            }
        }

        public void InsertOneNormalServerItem(GameObject parent, GameObject obj, ServerInfo serverInfo)
        {
            GameObject item = GameObject.Instantiate(obj);
            item.SetActive(true);
            item.name = "Server_" + serverInfo.ServerId;
            Transform itemTrans = item.transform;
            itemTrans.SetParent(parent.transform);
            itemTrans.localScale = Vector3.one;
            itemTrans.localPosition = Vector3.zero;

            // 名字
            Text nameText = itemTrans.Find("NameText").GetComponent<Text>();
            nameText.text = serverInfo.Name;

            // 状态
            Image stateImage = itemTrans.Find("StateImage").GetComponent<Image>();
            stateImage.sprite = GetSpriteByState(serverInfo.State);

            // 类型
            GameObject tag = itemTrans.Find("Tag").gameObject;
            if (serverInfo.Type == EServerType.New || serverInfo.Type == EServerType.RecommendAndNew)
            {
                tag.SetActive(true);
            }
            else
            {
                tag.SetActive(false);
            }

            // 角色数量
            Text roleNumText = itemTrans.Find("Role").Find("Text").GetComponent<Text>();
            if (serverInfo.RoleList == null || serverInfo.RoleList.Count == 0)
            {
                roleNumText.text = "x0";
                roleNumText.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                roleNumText.text = "x" + serverInfo.RoleList.Count;
                roleNumText.transform.parent.gameObject.SetActive(true);
            }

            // cd
            Text cdText = itemTrans.Find("CDText").GetComponent<Text>();
            if ((serverInfo.State == EServerState.WillOpen || serverInfo.State == EServerState.Maintaining) && serverInfo.CountDownTime > 0)
            {
                cdText.gameObject.SetActive(true);

                Utils.DecimalTimer timer = new Utils.DecimalTimer((decimal)(serverInfo.CountDownTime) * 1000, false, 1000, (decimal remainTime, Utils.DecimalTimer t) =>
                {
                    if (remainTime <= 0)
                    {
                        cdText.text = "";
                        // 维护倒计时完毕就默认为畅通吧
                        stateImage.sprite = GetSpriteByState(EServerState.Smooth);

                        t.Destroy();
                        mMaintainingServerTimers.Remove(t);
                    }
                    else
                    {
                        cdText.text = DBConstText.GetText("MAINTAINING_REMAIN_TIME") + TimeTraslateHMS.GetFMTTime(remainTime);
                    }
                }, null);
                mMaintainingServerTimers.Add(timer);
            }
            else
            {
                cdText.gameObject.SetActive(false);
            }

            // 按钮
            Button button = itemTrans.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (ServerListHelper.Instance.CheckServerState(serverInfo, false) == true)
                {
                    SetSelectedServerInfo(serverInfo);
                    OnClickCloseServerListPanelButton();
                }
                else
                {
                    ServerListHelper.GetInstance().CheckServerStateAndEnter(serverInfo, (ServerInfo retServerInfo, bool canEnter) =>
                    {
                        if (canEnter == true)
                        {
                            SetSelectedServerInfo(serverInfo);
                            OnClickCloseServerListPanelButton();
                        }
                        else
                        {
                            ServerListHelper.Instance.CheckServerState(serverInfo, false);

                            // 推荐别的服务器需要关闭服务器列表界面
                            if (serverInfo != null && serverInfo.State == EServerState.NotRecomm)
                            {
                                OnClickCloseServerListPanelButton();
                            }
                        }
                    }, false);
                }
            });
        }

        public void RemoveAllChildrenExcludeList(Transform parent, List<string> excludedNameList)
        {
            List<Transform> childrenToDestroy = new List<Transform>();
            childrenToDestroy.Clear();
            for (int i = 0; i < parent.childCount; ++i)
            {
                Transform child = parent.GetChild(i);
                bool isExclude = false;
                foreach (string excludedName in excludedNameList)
                {
                    if (child.name == excludedName)
                    {
                        isExclude = true;
                        break;
                    }
                }
                if (isExclude == false)
                {
                    childrenToDestroy.Add(child);
                }
            }
            foreach (Transform child in childrenToDestroy)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
        }

        public void SetSelectedServerInfo(ServerInfo serverInfo)
        {
            mSelectedServerInfo = serverInfo;

            //if (serverInfo == null)
            //{
            //    mSelectedServerStateImage.sprite = GetSpriteByState(0);
            //    mSelectedServerNameText.text = "";
            //}
            //else
            //{
            //    mSelectedServerStateImage.sprite = GetSpriteByState(serverInfo.State);
            //    mSelectedServerNameText.text = serverInfo.Name;
            //}

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SELECT_SERVER, new CEventBaseArgs(mSelectedServerInfo));
        }

        public Sprite GetSpriteByState(EServerState state)
        {
            CanvasInfo info = mUIObject.GetComponent<CanvasInfo>();
            if (info == null)
            {
                GameDebug.LogError(string.Format("UIServerListWindow.GetSpriteByState {0}  CanvasInfo is null", mWndName));
                return null;
            }

            Sprite sprite = null;
            if (state == EServerState.Smooth)
            {
                sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality");
            }
            else if (state == EServerState.Full)
            {
                sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality_2");
            }
            else
            {
                sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality_3");
            }
            return sprite;
        }

        public void DestoryMaintainingServerTimers()
        {
            foreach (var timer in mMaintainingServerTimers)
            {
                timer.Destroy();
            }
            mMaintainingServerTimers.Clear();
        }


        public void OnClickCloseServerListPanelButton()
        {
            DestoryMaintainingServerTimers();

            UIManager.Instance.CloseWindow("UIServerListWindow");
        }
    }   
}
