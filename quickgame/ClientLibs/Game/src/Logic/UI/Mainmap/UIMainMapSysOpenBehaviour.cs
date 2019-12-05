//-------------------------------------------
//  File:UIMainMapSysOpenBehaviour
//  Desc: 系统开放的组件
//  Author: Raorui 重构
//  Date: 2017.11.22
//-------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui;
using Utils;
using Net;
using xc.protocol;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIMainMapSysOpenBehaviour : IUIBehaviour
    {
        List<GameObject> mSysBtnRootList = new List<GameObject>();

        /// <summary>
        /// 左下角系统按钮的模版物体
        /// </summary>
        GameObject mSysBtnObj;

        /// <summary>
        /// 右上角系统按钮的模版物体
        /// </summary>
        GameObject mTRSysBtnObj;

        /// <summary>
        /// 右侧系统按钮的模版物体
        /// </summary>
        GameObject mRightSysBtnObj;


        Vector2 mAnchorMin = new Vector2(0, 1);
        Vector2 mAnchorMax = new Vector2(0, 1);

        //--------------------------------------------------------
        //  左下角系统按钮的相关对象
        //--------------------------------------------------------
        /// <summary>
        /// 左下角系统按钮的根节点物体
        /// </summary>
        GameObject mLBSysBtns;

        /// <summary>
        /// 左下角系统按钮的配置列表
        /// </summary>
        List<DBSysConfig.SysConfig> mLBSysConfigs = new List<DBSysConfig.SysConfig>();

        /// <summary>
        /// 左下角系统按钮的组件
        /// </summary>
        Dictionary<uint, UISysConfigBtn> mLBSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();

        /// <summary>
        /// 隐藏在可展开系统按钮下的系统id
        /// key=被隐藏的系统id,value=隐藏在哪个系统id下面
        /// </summary>
        Dictionary<uint, uint> mExpandableSysBtnsDic = new Dictionary<uint, uint>();

        /// <summary>
        /// 左下角系统按钮伸缩栏上的红点物体
        /// </summary>
        GameObject mLbSysBtnTotalRed;

        //--------------------------------------------------------
        //  右上角系统按钮的相关对象
        //--------------------------------------------------------

        /// <summary>
        /// 右上角系统按钮组的根节点
        /// </summary>
        GameObject mTRSysBtnRoot;

        /// <summary>
        /// 右上角系统按钮的配置信息
        /// </summary>
        List<DBSysConfig.SysConfig> mTRSysConfigs = new List<DBSysConfig.SysConfig>();

        /// <summary>
        /// 右上角系统按钮的组件
        /// </summary>
        Dictionary<uint, UISysConfigBtn> mTRSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();

        /// <summary>
        /// 右上角系统按钮伸缩栏上的红点物体
        /// </summary>
        GameObject mTRPackUpBtnRedPoint;

        //--------------------------------------------------------
        //  右侧系统按钮组的相关对象
        //--------------------------------------------------------
        /// <summary>
        /// 右侧系统按钮的跟节点
        /// </summary>
        GameObject mRightSysBtns;

        GameObject mBagRedPoint;    //背包图标红点

        /// <summary>
        /// 右侧系统按钮的配置
        /// </summary>
        List<DBSysConfig.SysConfig> mRightSysConfigs = new List<DBSysConfig.SysConfig>();

        /// <summary>
        /// 右侧系统按钮的组件
        /// </summary>
        Dictionary<uint, UISysConfigBtn> mRightSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();
        //--------------------------------------------------------

        public Dictionary<uint, Dictionary<uint, bool>> AllSysRedPoint = new Dictionary<uint, Dictionary<uint, bool>>();//紅點集合

        private SafeCoroutine.Coroutine mPlayOpenSysRoutine = null;

        float SYS_OPEN_BTN_FLY_DURATION = 1.5f;/// 按钮飞过去的时间

        float SYS_OPEN_BTN_TR_DURATION = 0.3f;/// 右上角切换时间

        float SYS_OPEN_BTN_LB_DURATION = 0.4f;/// 左下角切换时间

        float SYS_OPEN_BTN_RIGHT_DURATION = 0.3f;/// 右边停留时间

        float SYS_OPEN_BTN_FLY_END_DURATION = 0.5f;///多个系统开启时，下一个的等待时间

        float SYS_WAIT_DURATION = 10.0f;//开启后如果没点后自动播放动画

        /// <summary>
        /// 在屏幕中央等待玩家点击的系统按钮
        /// </summary>
        GameObject mLBWaitSysBtnObj;
        GameObject mTRWaitSysBtnObj;
        GameObject mRightWaitSysBtnObj;

        /// <summary>
        /// 等待的系统按钮初始位置
        /// </summary>
        Vector2 mLBWaitSysBtnPos;
        Vector2 mTRWaitSysBtnPos;
        Vector2 mRightWaitSysBtnPos;

        GameObject m_IconpanelObj;

        /// <summary>
        /// 在屏幕中央等待玩家点击的系统按钮的背景
        /// </summary>
        GameObject m_WaitBgObj;

        /// <summary>
        /// 震屏组件
        /// </summary>
        CameraCurveShake m_Shake;

        /// <summary>
        /// 在屏幕中央等待玩家点击系统按钮的黑色蒙板
        /// </summary>
        GameObject m_WaitMaskObj;

        Timer WaitTimer;

        Button SysPanelButton;

        Vector3 mOpenScale = new Vector3(0.67f, 0.67f, 1);

        bool mStart = false;

        //--------------------------------------------------------
        //  属性访问器
        //--------------------------------------------------------
        #region PROPERTY_VISIT

        /// <summary>
        /// 系统开放的动画是否正在播放过程中
        /// </summary>
        public bool IsSysOpenPlaying
        {
            get { return mStart; }
        }
        #endregion

        //--------------------------------------------------------
        //  接口函数
        //--------------------------------------------------------
        #region INNER_FUNC
        public override void InitBehaviour()
        {
            base.InitBehaviour();
            mSysBtnObj = Window.FindChild("SysBtnObj");
            mTRSysBtnObj = Window.FindChild("TRSysBtnObj");
            mRightSysBtnObj = Window.FindChild("RightSysBtnObj");

            mSysBtnObj.SetActive(false);
            mTRSysBtnObj.SetActive(false);
            mRightSysBtnObj.SetActive(false);

            mLBSysBtns = Window.FindChild("LBSysBtns");
            mTRSysBtnRoot = Window.FindChild("TRSysBtns");
            mRightSysBtns = Window.FindChild("RightSysBtns");
            mBagRedPoint = Window.FindChild("BagRedPoint");

            mSysBtnRootList.Clear();
            mSysBtnRootList.Add(mLBSysBtns);
            mSysBtnRootList.Add(mTRSysBtnRoot);
            mSysBtnRootList.Add(mRightSysBtns);

            mLbSysBtnTotalRed = Window.FindChild("BLPackUpBtnRedPoint");
            mLbSysBtnTotalRed.SetActive(true);
            mTRPackUpBtnRedPoint = Window.FindChild("TRPackUpBtnRedPoint");
            mTRPackUpBtnRedPoint.SetActive(true);
            m_IconpanelObj = Window.FindChild("IconPanel");

            mLBWaitSysBtnObj = m_IconpanelObj.transform.Find("LBWaitSysBtn").gameObject;
            mTRWaitSysBtnObj = m_IconpanelObj.transform.Find("TRWaitSysBtn").gameObject;
            mRightWaitSysBtnObj = m_IconpanelObj.transform.Find("RightWaitSysBtn").gameObject;
            mLBWaitSysBtnPos = mLBWaitSysBtnObj.GetComponent<RectTransform>().anchoredPosition;
            mTRWaitSysBtnPos = mTRWaitSysBtnObj.GetComponent<RectTransform>().anchoredPosition;
            mRightWaitSysBtnPos = mRightWaitSysBtnObj.GetComponent<RectTransform>().anchoredPosition;
            mLBWaitSysBtnObj.transform.Find("SysBtn").Find("Text").GetComponent<Text>().text = "";
            mTRWaitSysBtnObj.transform.Find("SysBtn").Find("Text").GetComponent<Text>().text = "";
            mRightWaitSysBtnObj.transform.Find("SysBtn").Find("Text").GetComponent<Text>().text = "";
            mLBWaitSysBtnObj.SetActive(false);
            mTRWaitSysBtnObj.SetActive(false);
            mRightWaitSysBtnObj.SetActive(false);

            SysPanelButton = Window.FindChild("SysPanel").GetComponent<Button>();

            m_WaitBgObj = UIHelper.FindChild(SysPanelButton.gameObject, "BgPanel");
            m_Shake = UIHelper.FindChild(m_WaitBgObj, "EF_UI_gongxihuode_03").GetComponent<CameraCurveShake>();
            m_WaitMaskObj = UIHelper.FindChild(SysPanelButton.gameObject, "WaitMask");
            SysPanelButton.gameObject.SetActive(false);
            SysPanelButton.onClick.AddListener(OnClickSysOpenBtn);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NEW_WAITING_SYS, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_TRANSFER_FINISH_SHOW_SUC, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_GOD_WARE_ANI_FINISH, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysRealOpen);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_BTN_CLOSE, OnSysRealClose);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MAINMAP_CLICK_BL_PACKUP_BTN, OnClickPackUpBtn);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MAINMAP_SWTICH_TR_SYSBTN, OnMainmapTRSysBtnChange); 
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, OnSysOpenListUpdate);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_STATE_CHANGED, OnActivityStateChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NEW_REDPOINT_SHOW, OnNewRedpointShow);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_UPDATE_SYS_SHOW_CHANGE, OnActivityStateChange);

            // 读取系统开放表，根据系统按钮的位置放到对应的按钮组中
            var AllList = DBManager.Instance.GetDB<DBSysConfig>().GetAllSysConfig();
            for (int i = 0; i < AllList.Count; i++)
            {
                var config = AllList[i];

                Dictionary<uint, bool> sysReds;
                if (AllSysRedPoint.TryGetValue(config.MainMapSysBtnId, out sysReds))
                {
                    if (sysReds.ContainsKey(config.Id) == false)
                    {
                        AllSysRedPoint[config.MainMapSysBtnId].Add(config.Id, false);
                    }
                }
                else
                {
                    sysReds = new Dictionary<uint, bool>();
                    sysReds.Add(config.Id, false);
                    AllSysRedPoint.Add(config.MainMapSysBtnId, sysReds);
                }

                // 设置系统按钮组
                switch (config.Pos)
                {
                    case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                        {
                            mLBSysConfigs.Add(config);
                            break;
                        }

                    case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                        {
                            mTRSysConfigs.Add(config);
                            break;
                        }
                    case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                        {
                            mRightSysConfigs.Add(config);
                            break;
                        }
                }

                //只有韩国版开放可展开按钮
                if (Const.Region == RegionType.KOREA)
                {
                    //是否隐藏在可展开按钮下
                    if (config.DropDown.Count > 0 && config.DropDownType == 1)
                    {
                        List<uint> parentRedPointIds = new List<uint> { config.Id };
                        DBRedPoint dbRedPoint = DBManager.Instance.GetDB<DBRedPoint>();
                        foreach (uint id in config.DropDown)
                        {
                            if (mExpandableSysBtnsDic.ContainsKey(id))
                                continue;
                            mExpandableSysBtnsDic.Add(id, config.Id);
                            //添加红点规则
                            dbRedPoint.AddRedPointData(id, parentRedPointIds);
                        }
                    }
                }
            }

            //左下角的按钮组要根据分辨率调整宽度
            RectTransform mLBSysBtnsRect = mLBSysBtns.GetComponent<RectTransform>();
            float btn_size_x = 112;
            var grid_layout = mLBSysBtnsRect.GetComponent<GridLayoutGroup>();
            if(grid_layout != null)
            {
                btn_size_x = grid_layout.cellSize.x;
            }
            CanvasScaler canvasScaler = this.Window.mUIObject.GetComponent<CanvasScaler>();
            float width = canvasScaler.referenceResolution.x;
            if (canvasScaler.matchWidthOrHeight == 1)
            {
                width = Screen.width * canvasScaler.referenceResolution.y / Screen.height;
            }
            Vector2 rect = mLBSysBtnsRect.sizeDelta;
            rect.x = width - btn_size_x;
            mLBSysBtnsRect.sizeDelta = rect;



            // 根据列表配置创建系统按钮
            InitCreateSysBtn(mLBSysConfigs, ref mLBSysBtnsDic, mLBSysBtns, 0); // 左下角的按钮组
            InitCreateSysBtn(mTRSysConfigs, ref mTRSysBtnsDic, mTRSysBtnRoot, 1); // 右上角的按钮组
            InitCreateSysBtn(mRightSysConfigs, ref mRightSysBtnsDic, mRightSysBtns, 2); // 右侧的系统按钮组
        }

        public override void DestroyBehaviour()
        {
            base.DestroyBehaviour();

            mSysBtnRootList.Clear();

            mLBSysBtnsDic.Clear();
            mLBSysConfigs.Clear();

            mTRSysBtnsDic.Clear();
            mTRSysConfigs.Clear();

            mRightSysBtnsDic.Clear();
            mRightSysConfigs.Clear();

            mExpandableSysBtnsDic.Clear();

            GuideManager.Instance.ResetEnableRef();

            if (mPlayOpenSysRoutine != null)
            {
                mPlayOpenSysRoutine.Stop();
                mPlayOpenSysRoutine = null;
            }
            if (WaitTimer != null)
            {
                WaitTimer.Destroy();
                WaitTimer = null;
            }
            mStart = false;
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NEW_WAITING_SYS, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_TRANSFER_FINISH_SHOW_SUC, OnNewWaitingSysEvent);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysRealOpen);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_BTN_CLOSE, OnSysRealClose);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MAINMAP_CLICK_BL_PACKUP_BTN, OnClickPackUpBtn);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MAINMAP_SWTICH_TR_SYSBTN, OnMainmapTRSysBtnChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, OnSysOpenListUpdate);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_STATE_CHANGED, OnActivityStateChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NEW_REDPOINT_SHOW, OnNewRedpointShow);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_UPDATE_SYS_SHOW_CHANGE, OnActivityStateChange);
        }

        public override void EnableBehaviour(bool isEnable)
        {
            base.EnableBehaviour(isEnable);
            mStart = false;

            if (IsEnable)
            {
                if (mPlayOpenSysRoutine != null)
                {
                    mPlayOpenSysRoutine.Stop();
                    mPlayOpenSysRoutine = null;
                }

                if (WaitTimer != null)
                {
                    WaitTimer.Destroy();
                    WaitTimer = null;
                }

                SysPanelButton.gameObject.SetActive(false);

                InitSysBtnState(mLBSysConfigs, mLBSysBtnsDic);
                InitSysBtnState(mTRSysConfigs, mTRSysBtnsDic);
                InitSysBtnState(mRightSysConfigs, mRightSysBtnsDic);
                if (SysConfigManager.Instance.IsWaiting())
                {
                    if(SceneHelp.Instance.IsInWildInstance())
                    {
                        TargetPathManager.Instance.StopPlayerAndReset();//有系统开启停止寻路
                        OnNewWaitingSysEvent(null);
                    }
                    else
                        ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                }
            }
        }
        #endregion

        //--------------------------------------------------------
        //  客户端事件
        //--------------------------------------------------------
        #region CLIENT_EVENT
        /// <summary>
        /// 点击左下角的展开系统按钮
        /// </summary>
        /// <param name="evt"></param>
        private void OnClickPackUpBtn(CEventBaseArgs evt)
        {
            if (IsEnable == false || evt == null || evt.arg == null)
                return;

            //是否展开所有按钮
            bool is_open_btns = (bool)evt.arg;
            if (is_open_btns)
                mLbSysBtnTotalRed.SetActive(false);
            else
                mLbSysBtnTotalRed.SetActive(true);
        }

        /// <summary>
        /// 响应主ui右上角按钮切换的逻辑
        /// </summary>
        /// <param name="param"></param>
        void OnMainmapTRSysBtnChange(CEventBaseArgs param)
        {
            if (IsEnable == false || param == null)
                return;

            if (param.arg == null)
                return;

            bool is_show = (bool)param.arg;
            mTRPackUpBtnRedPoint.SetActive(is_show);
        }

        /// <summary>
        /// 响应系统开放列表的消息(可能Behavior激活之后才收到系统开放列表)
        /// </summary>
        /// <param name="args"></param>
        private void OnSysOpenListUpdate(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            EnableBehaviour(true);
        }

        /// <summary>
        /// 响应系统开放的消息
        /// </summary>
        /// <param name="args"></param>
        private void OnSysRealOpen(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            if (args.arg != null)
            {
                DBSysConfig.SysConfig config = args.arg as DBSysConfig.SysConfig;
                bool isOpen = true;
                if (config.HideBtnWhenActNotOpen == true)
                {
                    if (ActivityHelper.GetActivityInfo<bool>(config.Id, "IsOpen") == false)
                    {
                        isOpen = false;
                    }
                }

                if (isOpen == true)
                {
                    var btn = GetConfingBtn(config);
                    if (btn != null)
                    {
                        btn.IsDynamicShow = true;
                        btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                        var btn_root = GetBtnRoot(config);
                        if(btn_root != null)
                            LayoutRebuilder.ForceRebuildLayoutImmediate(btn_root);
                    }
                }
            }
        }

        /// <summary>
        /// 响应系统关闭的消息
        /// </summary>
        /// <param name="args"></param>
        private void OnSysRealClose(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            if (args.arg != null)
            {
                DBSysConfig.SysConfig config = args.arg as DBSysConfig.SysConfig;
                var btn = GetConfingBtn(config);
                if (btn != null)
                {
                    btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
                    var btn_root = GetBtnRoot(config);
                    if(btn_root != null)
                        LayoutRebuilder.ForceRebuildLayoutImmediate(btn_root);
                }
            }
        }

        /// <summary>
        /// 响应有新的开放系统开放的消息
        /// </summary>
        /// <param name="args"></param>
        private void OnNewWaitingSysEvent(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            TryToStartToPlayWaitingBtn();
        }

        /// <summary>
        /// 响应网络重连后的消息
        /// </summary>
        /// <param name="args"></param>
        public void OnNetReconnect(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            // 在某些情况下，GridLayout没有生效，需要重新激活
            foreach(var root in mSysBtnRootList)
            {
                var root_trans = root.GetComponent<RectTransform>();
                if(root_trans != null)
                    LayoutRebuilder.ForceRebuildLayoutImmediate(root_trans);
            }

            foreach (var kv in mTRSysBtnsDic)
            {
                if (kv.Value.m_FixedPos == UISysConfigBtn.FixType.FIX_WHEN_REDPOINT && kv.Value.IsRedPointShow())
                {
                    var tween_alpha = kv.Value.Btn.GetComponent<TweenAlpha>();
                    if (tween_alpha != null)
                    {
                        tween_alpha.value = 1;
                    }
                    var tween_pos = kv.Value.Btn.GetComponent<TweenPosition>();
                    if (tween_pos != null)
                    {
                        tween_pos.value = new Vector3(0, 0, 0);
                    }
                }
            }
        }

        private void OnActivityStateChange(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            if (args.arg == null)
                return;

            uint activityId = 0;
            uint.TryParse(args.arg.ToString(), out activityId);
            DBSysConfig.SysConfig config = DBSysConfig.Instance.GetConfigById(activityId);
            if (config == null)
                return;

            bool isOpen = false;
            if (SysConfigManager.Instance.CheckSysHasOpenIgnoreActivity(activityId))
            {
                if (ActivityHelper.GetActivityInfo<bool>(config.Id, "IsOpen"))
                {
                    isOpen = true;
                }
                else
                {
                    isOpen = !config.HideBtnWhenActNotOpen;
                }
            }

            var btn = GetConfingBtn(config);
            if (btn == null)
                return;

            if (isOpen)
            {
                btn.IsDynamicShow = true;
                btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
            }
            else
            {
                btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
            }

            var btn_root = GetBtnRoot(config);
            if (btn_root != null)
                LayoutRebuilder.ForceRebuildLayoutImmediate(btn_root);
        }

        private void OnNewRedpointShow(CEventBaseArgs args)
        {
            if (args == null || args.arg == null)
                return;
            string str = (string)(args.arg);
            uint redPointId = 0;
            if (uint.TryParse(str, out redPointId) == false)
                return;

            foreach (var kv in mTRSysBtnsDic)
            {
                if (redPointId == kv.Value.UIMainBtnId)
                {
                    var tween_alpha = kv.Value.Btn.GetComponent<TweenAlpha>();
                    if (tween_alpha != null)
                    {
                        tween_alpha.value = 1;
                    }
                    var tween_pos = kv.Value.Btn.GetComponent<TweenPosition>();
                    if (tween_pos != null)
                    {
                        tween_pos.value = new Vector3(0, 0, 0);
                    }
                }
            }
        }
        #endregion

        //--------------------------------------------------------
        //  UI控件事件
        //--------------------------------------------------------
        #region UI_EVENT
        /// <summary>
        /// 点击系统展示按钮
        /// </summary>
        void OnClickSysOpenBtn()
        {
            if (mPlayOpenSysRoutine != null)
                return;

            mPlayOpenSysRoutine = SafeCoroutine.CoroutineManager.StartCoroutine(PlayOpenSysAnimRoutine());
        }

        /// <summary>
        /// 所有系统按钮的点击事件
        /// </summary>
        /// <param name="param"></param>
        void OnClickBtn(params object[] param)
        {
            if (IsEnable == false)
                return;

            if (param != null && param.Length > 0)
            {
                DBSysConfig.SysConfig Config = param[0] as DBSysConfig.SysConfig;
                //如果有下拉窗，则需要传递停靠对象
                if (Config.DropDown != null && Config.DropDown.Count > 0)
                {
                    GameObject AnchoredObj = param[1] as GameObject;
                    RouterManager.Instance.GenericGoToSysWindow(Config.Id, AnchoredObj);
                }
                else
                {
                    RouterManager.Instance.GenericGoToSysWindow(Config.Id);
                }
            }
        }

        #endregion

        //--------------------------------------------------------
        //  内部函数调用
        //--------------------------------------------------------
        #region PRIVATE_FUNC
        public void TryToStartToPlayWaitingBtn()
        {
            if (mPlayOpenSysRoutine != null)
                return;

            var waiting_sys_list = SysConfigManager.Instance.GetAllWaitingSysList();
            if (waiting_sys_list.Count <= 0)
                return;

            // 剧情动画播放的时候不显示系统开放动画
            if (TimelineManager.Instance.IsPlaying() == true)
            {
                return;
            }

            waiting_sys_list.Sort();
            var waiting_config = waiting_sys_list[0];

            if (waiting_config.NeedAnim == true && waiting_config.MainMapSysBtnId != GameConst.SYS_OPEN_TREASURE)
            {
                // 当系统开放的动画展示不需要等待或者等待的过程已经完成的时候，才立即播放动画
                if (waiting_config.IsWaitingSystem == false || waiting_config.IsWaitFinished)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_OPEN_ANIM_START, new CEventBaseArgs(waiting_config.Id));
                    SysPanelButton.gameObject.SetActive(true);
                    SetWaitSysBtn(waiting_config);
                    GameObject waitSysBtnObj = null;
                    switch (waiting_config.Pos)
                    {
                        case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                            waitSysBtnObj = mLBWaitSysBtnObj;
                            break;
                        case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                            waitSysBtnObj = mTRWaitSysBtnObj;
                            break;
                        case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                            waitSysBtnObj = mRightWaitSysBtnObj;
                            break;
                    }
                    waitSysBtnObj.transform.Find("SysBtn").Find("Text").gameObject.SetActive(false); ;
                }
                else
                    return;

                mStart = true;
                if (WaitTimer != null)
                {
                    WaitTimer.Destroy();
                    WaitTimer = null;
                }
                float time = SYS_WAIT_DURATION * 1000;
                WaitTimer = new Utils.Timer(time, false, time,
                       (dt) =>
                       {
                           if (mPlayOpenSysRoutine == null)
                               OnClickSysOpenBtn();
                       });
            }
            else
            {
                // 不需要播放动画的时候直接开放系统
                SysConfigManager.GetInstance().OpenSys(waiting_config);
                GameDebug.LogRed("waiting_sys_list.count:" + waiting_sys_list.Count);
                if (waiting_sys_list.Count > 0)
                    OnClickSysOpenBtn();
            }
        }

        /// <summary>
        /// 设置屏幕中央系统展示按钮的信息(图标和文本)
        /// </summary>
        /// <param name="config"></param>
        private void SetWaitSysBtn(DBSysConfig.SysConfig config)
        {
            SysPanelButton.gameObject.SetActive(true);
            GameObject waitSysBtnObj = null;
            switch (config.Pos)
            {
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                    waitSysBtnObj = mLBWaitSysBtnObj;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                    waitSysBtnObj = mTRWaitSysBtnObj;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                    waitSysBtnObj = mRightWaitSysBtnObj;
                    break;
            }
            waitSysBtnObj.SetActive(true);
            Image icon = waitSysBtnObj.transform.Find("SysBtn").Find("SysIcon").GetComponent<Image>();
            Text titleText = UIHelper.FindChild(m_WaitBgObj, "BgTitleText").GetComponent<Text>();
            titleText.text = config.BtnText;
            Text descText = UIHelper.FindChild(m_WaitBgObj, "WaitSysText").GetComponent<Text>();
            descText.text = config.Desc;
            m_Shake.enabled = true;
            if (Window != null)
            {
                icon.sprite = Window.LoadSprite(config.BtnSprite);
            }
        }

        /// <summary>
        /// 播放系统开放动画的协程
        /// </summary>
        /// <returns></returns>
        private IEnumerator PlayOpenSysAnimRoutine()
        {
            yield return new SafeCoroutine.SafeWaitForSeconds(0);
            // 暂停新手引导
            GuideManager.Instance.Pause();

            while (true)// 完成所有的需要开放的系统才能结束
            {
                // 剧情动画播放的时候不显示系统开放动画
                if (TimelineManager.Instance.IsPlaying() == true)
                {
                    ResetAllWaitSysBtns();
                    m_WaitBgObj.SetActive(true);
                    m_WaitMaskObj.GetComponent<Image>().color = Color.white;
                    SysPanelButton.gameObject.SetActive(false);
                    mPlayOpenSysRoutine = null;
                    mStart = false;
                    if (WaitTimer != null)
                    {
                        WaitTimer.Destroy();
                        WaitTimer = null;
                    }
                    GuideManager.Instance.Resume();
                    yield break;
                }

                var waiting_sys_list = SysConfigManager.Instance.GetAllWaitingSysList();
                GameDebug.LogRed("waiting_sys_list.count:" + waiting_sys_list.Count);
                // 没有需要播放的开放动画时，将屏幕中央的系统展示按钮放回到IconPanel中
                if (waiting_sys_list == null || waiting_sys_list.Count <= 0)
                {
                    ResetAllWaitSysBtns();
                    m_WaitBgObj.SetActive(true);
                    m_WaitMaskObj.GetComponent<Image>().color = Color.white;
                    SysPanelButton.gameObject.SetActive(false);
                    break;
                }

                // 获取第一个需要展示的开放系统
                var waiting_config = waiting_sys_list[0];
                if (waiting_config.NeedAnim == false || SysConfigManager.Instance.SkipSysOpen)// 如果不需要播放动画，则直接开放该系统
                {
                    ResetWaitSysBtn(waiting_config.Pos);
                    m_WaitBgObj.SetActive(true);
                    m_WaitMaskObj.GetComponent<Image>().color = Color.white;
                    SysPanelButton.gameObject.SetActive(false);
                    SysConfigManager.GetInstance().OpenSys(waiting_config);
                    continue;
                }
                // 获取开放系统对应的按钮控件
                UISysConfigBtn btn = GetConfingBtn(waiting_config);

                GameObject waitSysBtnObj = null;
                switch (waiting_config.Pos)
                {
                    case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                        waitSysBtnObj = mLBWaitSysBtnObj;
                        break;
                    case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                        waitSysBtnObj = mTRWaitSysBtnObj;
                        break;
                    case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                        waitSysBtnObj = mRightWaitSysBtnObj;
                        break;
                }

                if (btn == null)// 按钮为空时
                {
                    waitSysBtnObj.SetActive(true);
                    m_WaitBgObj.SetActive(true);
                    m_WaitMaskObj.GetComponent<Image>().color = Color.white;
                    waitSysBtnObj.transform.localPosition = Vector3.zero;
                    waitSysBtnObj.transform.localScale = Vector3.one;
                    SysPanelButton.gameObject.SetActive(false);
                    SysConfigManager.GetInstance().OpenSys(waiting_config);
                    continue;
                }
                // 设置展示按钮的信息
                SetWaitSysBtn(waiting_config);

                mStart = true;

                //先展开系统按钮栏
                switch (waiting_config.Pos)
                {
                    case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("LBRect"));
                        yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_LB_DURATION);
                        break;
                    case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("TRRect"));
                        yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_TR_DURATION);
                        break;
                    case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                        yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_RIGHT_DURATION);
                        break;
                }

                // 将系统展示按钮设置到实际开放的按钮上，并播放按钮飞行的动画
                Vector3 local_open_pos = GetWillOpenPosition(btn); // 获取飞向的坐标相对位置
                btn.GetComponent<RectTransform>().anchoredPosition = local_open_pos;
                Vector3 open_pos = btn.transform.position;
                ResetWaitSysBtn(waiting_config.Pos);
                m_WaitBgObj.SetActive(false);
                m_WaitMaskObj.GetComponent<Image>().color = Color.clear;

                // 显示系统按钮的文本信息
                waitSysBtnObj.SetActive(true);
                GameObject sys_text_object = waitSysBtnObj.transform.Find("SysBtn").Find("Text").gameObject;
                sys_text_object.SetActive(true);
                sys_text_object.GetComponent<Text>().text = waiting_config.BtnText;

                TweenPosition.Begin(waitSysBtnObj, SYS_OPEN_BTN_FLY_DURATION, open_pos, true);

                GameDebug.LogRed("[PlayOpenSysAnimRoutine]SYS_OPEN_BTN_FLY_DURATION");

                // 飞到一半再重设系统按钮根节点的Layout
                yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_FLY_DURATION*0.85f);
                // 根据当前系统的开放状态设置按钮的显示
                if (btn.CurrentState == UISysConfigBtn.SysState.NotOpen && !waiting_config.InitNeedShow)
                {
                    btn.SetSysBtnState(UISysConfigBtn.SysState.OpenHideBtn);
                }
                var rect = GetBtnRoot(waiting_config);
                if(rect != null)
                    LayoutRebuilder.ForceRebuildLayoutImmediate(rect);

                yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_FLY_DURATION*0.15f);

                SysConfigManager.GetInstance().OpenSys(waiting_config);
                sys_text_object.SetActive(false);
                ResetWaitSysBtn(waiting_config.Pos);
                m_Shake.enabled = false;
                m_WaitBgObj.SetActive(true);
                m_WaitMaskObj.GetComponent<Image>().color = Color.white;
                SysPanelButton.gameObject.SetActive(false);
                btn.IsDynamicShow = true;
                btn.SetSysBtnState(UISysConfigBtn.SysState.Open);

                yield return new SafeCoroutine.SafeWaitForSeconds(SYS_OPEN_BTN_FLY_END_DURATION);
            }

            GuideManager.Instance.Resume();
            mPlayOpenSysRoutine = null;
            mStart = false;

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_OPEN_ANIM_END, null);
        }

        private void ResetAllWaitSysBtns()
        {
            ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_LBBTN_POS);
            ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_TRBTN_POS);
            ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_RIGHT_POS);
        }

        private void ResetWaitSysBtn(DBSysConfig.ESysBtnPos btnPos)
        {
            GameObject waitSysBtnObj = null;
            switch (btnPos)
            {
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                    waitSysBtnObj = mLBWaitSysBtnObj;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                    waitSysBtnObj = mTRWaitSysBtnObj;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                    waitSysBtnObj = mRightWaitSysBtnObj;
                    break;
            }
            waitSysBtnObj.transform.SetParent(m_IconpanelObj.transform);
            switch (btnPos)
            {
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                    waitSysBtnObj.GetComponent<RectTransform>().anchoredPosition = mLBWaitSysBtnPos;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                    waitSysBtnObj.GetComponent<RectTransform>().anchoredPosition = mTRWaitSysBtnPos;
                    break;
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                    waitSysBtnObj.GetComponent<RectTransform>().anchoredPosition = mRightWaitSysBtnPos;
                    break;
            }
            waitSysBtnObj.SetActive(false);
            waitSysBtnObj.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// 根据配置来获取系统按钮所在按钮组的根节点
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private RectTransform GetBtnRoot(DBSysConfig.SysConfig config)
        {
            RectTransform rect = null;
            switch (config.Pos)
            {
                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                    {
                        var child_trans = mTRSysBtnRoot.transform.Find(config.SubPos.ToString());
                        if (child_trans != null)
                            rect = child_trans.GetComponent<RectTransform>();
                        else
                            GameDebug.LogError(string.Format("GetBtnRoot获取子节点为空, id: {0}, sub_pos: {1}", config.Id, config.SubPos));
                        break;
                    }
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                    {
                        rect = mLBSysBtns.GetComponent<RectTransform>();
                        break;
                    }
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                    {
                        rect = mRightSysBtns.GetComponent<RectTransform>();
                        break;
                    }
            }
            return rect;
        }

        /// <summary>
        /// 获取当前按钮在开放后的相对位置
        /// </summary>
        public Vector3 GetWillOpenPosition(UISysConfigBtn config_btn)
        {
            if (config_btn.Param != null && config_btn.Param.Length > 0)
            {
                var sys_config = config_btn.Param[0] as DBSysConfig.SysConfig;
                if (sys_config != null)
                {
                    var btn_root = GetBtnRoot(sys_config);
                    if (btn_root != null)
                    {
                        // 获取排版在x,y方向上的间隔
                        float btn_size_x = 112;
                        float btn_size_y = 112;
                        float btn_space_x = 0;
                        float btn_space_y = 0;
                        var grid_layout = btn_root.GetComponent<GridLayoutGroup>();
                        uint max_column = 0; 
                        if (grid_layout != null)
                        {
                            btn_size_x = grid_layout.cellSize.x;
                            btn_size_y = grid_layout.cellSize.y;
                            btn_space_x = grid_layout.spacing.x;
                            btn_space_y = grid_layout.spacing.y;

                            // 计算最大可排多少列
                            if(btn_size_x+ btn_space_x > 0)
                                max_column = (uint)(btn_root.sizeDelta.x / (btn_size_x + btn_space_x));
                        }

                        Vector3 btn_pos = Vector3.zero; // 按钮的位置
                        switch (sys_config.Pos)
                        {
                            case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS: // 右上方的按钮组
                                {
                                    uint show_index = 0;
                                    foreach (var btn in mTRSysBtnsDic.Values)
                                    {
                                        if (btn.CurrentState == UISysConfigBtn.SysState.NotOpen)
                                            continue;

                                        if (btn.m_SubPos != sys_config.SubPos)
                                            continue;

                                        if (btn.m_SortIndex < config_btn.m_SortIndex)
                                            show_index++;
                                    }

                                    // 最多排两列
                                    uint x_index = show_index % max_column;
                                    uint y_index = show_index / max_column;

                                    btn_pos.x = (0.5f + x_index) * btn_size_x + btn_space_x * x_index;
                                    btn_pos.x = btn_root.rect.width - btn_pos.x;// 因为按钮根节点是右上方对齐的,因为x方向需要翻转
                                    btn_pos.y = (-0.5f - y_index) * btn_size_y - btn_space_y * y_index;
                                    break;
                                }
                            case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS: // 左下方的按钮组
                                {
                                    uint show_index = 0;
                                    foreach (var btn in mLBSysBtnsDic.Values)
                                    {
                                        if (btn.CurrentState == UISysConfigBtn.SysState.NotOpen)
                                            continue;

                                        if (btn.m_SortIndex < config_btn.m_SortIndex)
                                            show_index++;
                                    }

                                    //需求修改为支持多行
                                    uint x_index = show_index % max_column;
                                    uint y_index = show_index / max_column;
                                    btn_pos.y = (-0.5f + y_index) * btn_size_y + btn_space_y * y_index;
                                    if(y_index > 0)
                                    {
                                        //第2排开始反向
                                        btn_pos.x = (-0.5f + max_column - x_index) * btn_size_x + btn_space_x * (max_column - x_index);
                                    }
                                    else
                                    {
                                        btn_pos.x = (0.5f + x_index) * btn_size_x + btn_space_x * x_index;
                                    }

                                    
                                    //btn_pos.x = (0.5f + show_index) * btn_size_x + btn_space_x * show_index;
                                    //btn_pos.y = -btn_size_y * 0.5f;
                                    break;
                                }
                            case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS: // 右侧的按钮组
                                {
                                    uint show_index = 0;
                                    foreach (var btn in mRightSysBtnsDic.Values)
                                    {
                                        if (btn.CurrentState == UISysConfigBtn.SysState.NotOpen)
                                            continue;

                                        if (btn.m_SortIndex < config_btn.m_SortIndex)
                                            show_index++;
                                    }

                                    // 暂时只有一行
                                    btn_pos.x = (0.5f + show_index) * btn_size_x + btn_space_x * show_index;
                                    btn_pos.x = btn_root.rect.width - btn_pos.x;// 因为按钮根节点是右上方对齐的,因为x方向需要翻转
                                    btn_pos.y = -btn_size_y * 0.5f;
                                    break; ;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        GameDebug.LogRed("[GetOpenPosition]btn_pos: " + btn_pos.ToString());
                        return btn_pos;
                    }
                }
            }

            GameDebug.LogError("[GetOpenPosition]Position is invaild");
            return Vector3.zero;
        }

        public void InitSysBtnState(List<DBSysConfig.SysConfig> configs, Dictionary<uint, UISysConfigBtn> dic)
        {
            foreach (var kv in dic)
            {

                if (AuditManager.Instance.ContainShieldSId(kv.Key))
                {
                    kv.Value.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
                    continue;
                }

                // 获取所有主系统ID为kv.Key的按钮
                var list = configs.FindAll(delegate (DBSysConfig.SysConfig config) { return config.MainMapSysBtnId == kv.Key; });
                bool isOpen = false;
                if (list != null)
                {
                    // 如果有一个系统开启，则当前的系统按钮组是开启的
                    for (int i = 0; i < list.Count; i++)
                    {
                        var sysConfig = list[i];
                        var sysIdClose = sysConfig.SysIdClosePresent;
                        if (SysConfigManager.GetInstance().CheckSysHasOpened(sysConfig.Id))
                        {
                            // 当HideBtnWhenActNotOpen是true时，需要判断活动是否开启
                            if (sysConfig.HideBtnWhenActNotOpen == true)
                            {
                                if (ActivityHelper.GetActivityInfo<bool>(sysConfig.Id, "IsOpen") == true)
                                {
                                    if(sysIdClose == 0 || !SysConfigManager.GetInstance().CheckSysHasOpened(sysIdClose))
                                    {
                                        isOpen = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // 关联系统id为0或者系统还未开启
                                if (sysIdClose == 0 || !SysConfigManager.GetInstance().CheckSysHasOpened(sysIdClose))
                                {
                                    isOpen = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                DBSysConfig.SysConfig _config = DBManager.Instance.GetDB<DBSysConfig>().GetFirstMainId(kv.Key);


                if ((_config != null) && (_config.Id == GameConst.SYS_OPEN_LEAGUE_READY || _config.Id == GameConst.SYS_OPEN_LEAGUE_QUALIFY || _config.Id == GameConst.SYS_OPEN_LEAGUE)) // 帮派联赛系统按钮
                {
                    if (isOpen)
                    {
                        //预告和联赛icon 不共存
                        if (ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_LEAGUE_PRE_SHOW))
                        {
                            isOpen = false;
                        }
                    }
                }

                if (isOpen == false)
                {
                    if (_config == null)
                        kv.Value.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
                    else if (_config.InitNeedShow && !_config.HideBtnWhenActNotOpen)
                    {
                        kv.Value.SetSysBtnState(UISysConfigBtn.SysState.NotOpenLock);
                    }
                    else
                    {
                        kv.Value.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
                    }
                }
                else
                {
                    kv.Value.IsDynamicShow = true;
                    kv.Value.SetSysBtnState(UISysConfigBtn.SysState.Open);
                    //ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHECKPOINT, new CEventBaseArgs(_config.Id));
                }
            }
        }

        public UISysConfigBtn CreateConfigBtn(DBSysConfig.SysConfig config, Transform parent_trans, uint sort_index)
        {
            if (config == null)
                return null;
            // 打宝有特殊的按钮
            if (config.MainMapSysBtnId == GameConst.SYS_OPEN_TREASURE)
                return null;

            // 寻找对应的模型按钮进行实例化
            GameObject go = null;
            Vector3 scale = Vector3.one;
            byte pos;
            switch (config.Pos)
            {
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                {
                    // 左下角
                    go = GameObject.Instantiate(mSysBtnObj);
                    pos = 0;
                    break;
                }

                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                {
                    // 右上角
                    go = GameObject.Instantiate(mTRSysBtnObj);
                    pos = 1;
                    break;
                }
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                {
                    // 右侧
                    go = GameObject.Instantiate(mRightSysBtnObj);
                    pos = 2;
                    break;
                }
                default:
                {
                    // 右上角
                    go = GameObject.Instantiate(mTRSysBtnObj);
                    pos = 1;
                    break;
                }
            }

            // 设置位置和缩放
            var rect_trans = go.GetComponent<RectTransform>();
            rect_trans.anchorMin = mAnchorMin;
            rect_trans.anchorMax = mAnchorMax;

            go.transform.SetParent(parent_trans);
            go.transform.localScale = scale;
            go.transform.localPosition = Vector3.zero;

            // 添加UISysConfigBtn组件
            UISysConfigBtn config_btn = go.GetComponent<UISysConfigBtn>();
            if (config_btn == null)
                config_btn = go.AddComponent<UISysConfigBtn>();

            config_btn.Init(config.MainMapSysBtnId, sort_index, config.SubPos, (uint)config.FixedPos, config.ShowBg, config.BtnText, Window.LoadSprite(config.BtnSprite), OnClickBtn, config, go);
            go.name = config.MainMapSysBtnId.ToString();
            go.SetActive(true);

            // 添加小红点组件
            Transform sys_btn_transform = go.transform.Find("SysBtn");
            RedPoint red_pint = sys_btn_transform.gameObject.GetComponent<RedPoint>();
            if (red_pint == null)
            {
                red_pint = sys_btn_transform.gameObject.AddComponent<RedPoint>();
                if (pos == 0)
                {//左下
                    red_pint.DeltaX = 59f;
                    red_pint.DeltaY = -21f;
                }
                else
                {
                    red_pint.DeltaX = 59f;
                    red_pint.DeltaY = -21f;
                }
                red_pint.Scale = 1.0f;
                red_pint.RefreshPosAndScale();
            }
            red_pint.mPointKey = config.MainMapSysBtnId;
            if (config.MainMapSysBtnId == GameConst.SYS_OPEN_BAG)
            {
                red_pint.AssignRedPointObj = mBagRedPoint;
                RectTransform bag_red_point_transform = mBagRedPoint.GetComponent<RectTransform>();
                bag_red_point_transform.SetParent(sys_btn_transform, false);
                bag_red_point_transform.localEulerAngles = Vector3.zero;
                bag_red_point_transform.localScale = Vector3.one;
                bag_red_point_transform.anchoredPosition3D = new Vector3(-21.68f, -16.15f, 0);
            }

            // 添加特殊按钮组件
            if (config.Id == GameConst.SYS_OPEN_LEAGUE_READY || config.Id == GameConst.SYS_OPEN_LEAGUE_QUALIFY || config.Id == GameConst.SYS_OPEN_LEAGUE) // 帮派联赛系统按钮
            {
                UIGuildLeagueSysBtn guildLeagueSysBtn = go.AddComponent<UIGuildLeagueSysBtn>();
                guildLeagueSysBtn.Init();
            }

            if (config.UIBehavior.Count > 0)
            {
                for (int idx = 0; idx < config.UIBehavior.Count; idx++)
                {
                    string scriptPath = config.UIBehavior[idx];
                    if (string.IsNullOrEmpty(scriptPath))
                    {
                        continue;
                    }

                    bool isLuaClass = false;
                    if (scriptPath.StartsWith("#"))
                    {
                        isLuaClass = true;
                        scriptPath = scriptPath.Substring(1);
                        //Debug.Log("LuaMonoBehaviour # " + scriptPath);
                    }

                    if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(scriptPath))
                    {
                        if (isLuaClass)
                        {
                            LuaClassBehaviour com = go.AddComponent<LuaClassBehaviour>();
                            com.Init(scriptPath);
                        }
                        else
                        {
                            LuaMonoBehaviour com = go.AddComponent<LuaMonoBehaviour>();
                            com.Init(scriptPath);
                        }
                    }
                    else
                    {
                        System.Type t = System.Type.GetType(scriptPath);
                        if (t != null)
                        {
                            go.AddComponent(t);
                        }
                    }
                }
            }

            return config_btn;
        }


        /// <summary>
        /// 根据系统配置创建系统按钮
        /// </summary>
        /// <param name="configs"></param>
        /// <param name="dic"></param>
        /// <param name="root"></param>
        /// <param name="pos"> 系统按钮的位置: 0 为左下角 1 为右上角 2 为右侧</param>
        public void InitCreateSysBtn(List<DBSysConfig.SysConfig> configs, ref Dictionary<uint, UISysConfigBtn> dic, GameObject root, byte pos)
        {
            uint sort_index = 1;
            for (int i = 0; i < configs.Count; i++)
            {
                var config = configs[i];

                // 打宝有特殊的按钮
                if (config.MainMapSysBtnId == GameConst.SYS_OPEN_TREASURE)
                    continue;

                if (dic.ContainsKey(config.MainMapSysBtnId))
                    continue;

                // 只需要初始化MainMapSysBtnId为自己的按钮
                if (config.MainMapSysBtnId != config.Id)
                    continue;

                //只有韩国版开放可展开按钮
                if (Const.Region == RegionType.KOREA)
                {
                    //如果被隐藏在可展开系统按钮下面，则不在主界面创建按钮
                    if (mExpandableSysBtnsDic.ContainsKey(config.Id))
                        continue;
                }

                // 寻找对应的模型按钮进行实例化
                GameObject go = null;
                Vector3 scale = Vector3.one;
                if (pos == 0) // 左下角
                {
                    go = GameObject.Instantiate(mSysBtnObj);
                }
                else if (pos == 1) // 右上角
                {
                    go = GameObject.Instantiate(mTRSysBtnObj);
                }
                else if (pos == 2) // 右侧
                {
                    go = GameObject.Instantiate(mRightSysBtnObj);
                }

                // 设置位置和缩放
                var rect_trans = go.GetComponent<RectTransform>();
                rect_trans.anchorMin = mAnchorMin;
                rect_trans.anchorMax = mAnchorMax;

                // 右上角的按钮的跟节点需要根据行数来确定
                var parent_trans = root.transform;
                if (pos == 1)
                {
                    var trans = parent_trans.Find(config.SubPos.ToString());
                    if (trans != null)
                        parent_trans = trans;
                    else
                        GameDebug.LogError("[InitCreateSysBtn] cannot find trans root, sub_pos: "+ config.SubPos);
                }
                go.transform.SetParent(parent_trans);
                go.transform.localScale = scale;
                go.transform.localPosition = Vector3.zero;

                // 添加UISysConfigBtn组件
                UISysConfigBtn config_btn = go.GetComponent<UISysConfigBtn>();
                if (config_btn == null)
                    config_btn = go.AddComponent<UISysConfigBtn>();
             
                config_btn.Init(config.MainMapSysBtnId, sort_index, config.SubPos, (uint)config.FixedPos, config.ShowBg, config.BtnText, Window.LoadSprite(config.BtnSprite), OnClickBtn, config, go);
                go.name = config.MainMapSysBtnId.ToString();
                go.SetActive(true);
                dic.Add(config.MainMapSysBtnId, config_btn);

                // 添加小红点组件
                Transform sys_btn_transform = go.transform.Find("SysBtn");
                RedPoint red_pint = sys_btn_transform.gameObject.GetComponent<RedPoint>();
                if (red_pint == null)
                {
                    red_pint = sys_btn_transform.gameObject.AddComponent<RedPoint>();
                    if (pos == 0)
                    {//左下
                        red_pint.DeltaX = 59f;
                        red_pint.DeltaY = -21f;
                    }
                    else
                    {
                        red_pint.DeltaX = 59f;
                        red_pint.DeltaY = -21f;
                    }
                    red_pint.Scale = 1.0f;
                    red_pint.RefreshPosAndScale();
                }
                red_pint.mPointKey = config.MainMapSysBtnId;
                if (config.MainMapSysBtnId == GameConst.SYS_OPEN_BAG)
                {
                    red_pint.AssignRedPointObj = mBagRedPoint;
                    RectTransform bag_red_point_transform = mBagRedPoint.GetComponent<RectTransform>();
                    bag_red_point_transform.SetParent(sys_btn_transform, false);
                    bag_red_point_transform.localEulerAngles = Vector3.zero;
                    bag_red_point_transform.localScale = Vector3.one;
                    bag_red_point_transform.anchoredPosition3D = new Vector3(-21.68f, -16.15f, 0);
                }

                // 添加特殊按钮组件
                if (config.Id == GameConst.SYS_OPEN_LEAGUE_READY || config.Id == GameConst.SYS_OPEN_LEAGUE_QUALIFY || config.Id == GameConst.SYS_OPEN_LEAGUE) // 帮派联赛系统按钮
                {
                    UIGuildLeagueSysBtn guildLeagueSysBtn = go.AddComponent<UIGuildLeagueSysBtn>();
                    guildLeagueSysBtn.Init();
                }
                //else if (config.Id == GameConst.SYS_OPEN_ONLINE_REWARD) //在线奖励系统按钮
                //{
                //    go.AddComponent<UIOnlineRewardSysBtn>();
                //}
                //else if (config.Id == GameConst.SYS_OPEN_PAY)  //充值按钮
                //{
                //    LuaMonoBehaviour com = go.AddComponent<LuaMonoBehaviour>();
                //    com.Init("Model/Pay/UIPaySysBtn");
                //}
                //else if (config.Id == GameConst.SYS_OPEN_QUEST_ESCORT_DOUBLE_REWARD)  //护送女神双倍奖励按钮
                //{
                //    LuaMonoBehaviour com = go.AddComponent<LuaMonoBehaviour>();
                //    com.Init("Model/Task/UIEscortTaskDoubleRewardSysBtn");
                //}

                if(config.UIBehavior.Count > 0)
                {
                    for(int idx = 0;idx < config.UIBehavior.Count; idx++)
                    {
                        string scriptPath = config.UIBehavior[idx];
                        if (string.IsNullOrEmpty(scriptPath))
                        {
                            continue;
                        }

                        bool isLuaClass = false;
                        if (scriptPath.StartsWith("#"))
                        {
                            isLuaClass = true;
                            scriptPath = scriptPath.Substring(1);
                            //Debug.Log("LuaMonoBehaviour # " + scriptPath);
                        }

                        if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(scriptPath))
                        {
                            if (isLuaClass)
                            {
                                LuaClassBehaviour com = go.AddComponent<LuaClassBehaviour>();
                                com.Init(scriptPath);
                            }
                            else
                            {
                                LuaMonoBehaviour com = go.AddComponent<LuaMonoBehaviour>();
                                com.Init(scriptPath);
                            }
                        }
                        else
                        {
                            System.Type t = System.Type.GetType(scriptPath);
                            if (t != null)
                            {
                                go.AddComponent(t);
                            }
                        }
                    }
                }

                sort_index++;
            }
        }
        #endregion

        //--------------------------------------------------------
        //  外部接口函数
        //--------------------------------------------------------
        #region PUBLIC_FUNC
        /// <summary>
        /// 根据系统开放的配置来获取对应的按钮组件
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public UISysConfigBtn GetConfingBtn(DBSysConfig.SysConfig config)
        {
            UISysConfigBtn sys_config_btn = null;
            switch (config.Pos)
            {
                case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                    {
                        mTRSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out sys_config_btn);
                        break;
                    }
                case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                    {
                        mLBSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out sys_config_btn);
                        break;
                    }
                case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
                    {
                        mRightSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out sys_config_btn);
                        break;
                    }
            }

            return sys_config_btn;
        }
        #endregion
    }
}
