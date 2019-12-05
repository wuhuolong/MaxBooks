using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using xc;
using Utils;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIManager : xc.Singleton<UIManager>
    {
        /// <summary>
        /// 切换地图后重新打开窗口的参数
        /// </summary>
        class ReopenInfo
        {
            /// <summary>
            /// 窗口名字
            /// </summary>
            public string Name;

            /// <summary>
            /// 是否是系统窗口
            /// </summary>
            public bool IsSystemWindow;

            /// <summary>
            /// 是否触发主UI的动画
            /// </summary>
            public bool IsMainmapSwitch;

            /// <summary>
            /// 子系统的信息
            /// </summary>
            public System.Object SubSystemInfo;
        }

        public enum RefreshOrder
        {
            All = 0,//只有包含pop 跟normal
            Normal,
            Pop,
        }

        public const string MainPanelName = "UIMainmapWindow";

        public static bool IsPopBackWin = false;    //是否正在返回之前的界面
        private UICacheManager cache;

        public UICacheManager UICache
        {
            get
            {
                if (cache == null)
                {
                    cache = new UICacheManager();
                }

                return cache;
            }
        }

        private string mCurUIName;
        public UIMainCtrl MainCtrl { get; set; }
        private Dictionary<string, UIBaseWindow> mWindows;

        /// <summary>
        /// 记录所有窗口是否曾以系统窗口类型打开
        /// </summary>
        private Dictionary<string, bool> mOpenedSysWindow = new Dictionary<string, bool>();

        /// <summary>
        /// 记录所有以系统窗口类型打开的正在展示的窗口
        /// </summary>
        private List<string> mOpeningSysWin = new List<string>();

        public const string DynamicPath = "Assets/Res/UI/Widget/Dynamic/";
        public const string PresetPath = "Assets/Res/UI/Widget/Preset/";

        /// <summary>
        /// 5s检查一次需要关闭的面板
        /// </summary>
        private readonly float mRealDestroyWinTime = 5.0f;

        private Dictionary<UIType, UILayerInfo> LayerInfos;

        public readonly int MaxDepth = 200;

        public UIBaseWindow ModalWindow = null;
        public UILoadingWindow LoadingWindow = null;

        /// <summary>
        /// 打开主UI界面的同时需要打开的其他界面(目前在Lua中有使用)
        /// </summary>
        public string IsBackMainMapShowWin = "";

        private Utils.Timer mTimer;

        private Dictionary<string, bool> loadingWindows;
        private List<string> needCloseWindowsAfterResLoad;
        private List<ReopenInfo> mReopenWindows = new List<ReopenInfo>();

        public UILayerInfo GetLayerInfo(UIType type)
        {
            return LayerInfos[type];
        }

        public UIManager()
        {
            LayerInfos = new Dictionary<UIType, UILayerInfo>();

            LayerInfos.Add(UIType.Hud, new UILayerInfo(1, UIType.Hud, 11));
            LayerInfos.Add(UIType.Normal, new UILayerInfo(2, UIType.Normal, 10));
            LayerInfos.Add(UIType.Loading, new UILayerInfo(3, UIType.Loading, 9));
            LayerInfos.Add(UIType.Pop, new UILayerInfo(4, UIType.Pop, 8));

            loadingWindows = new Dictionary<string, bool>();
            needCloseWindowsAfterResLoad = new List<string>();
            mWindows = new Dictionary<string, UIBaseWindow>();
            MainCtrl = null;
            xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.SubscribeClientEvent(ClientEventType.ugui.UICoreEvent.UILOADDONE, OnResourceLoadDone);
            xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.SubscribeClientEvent(ClientEventType.ugui.UICoreEvent.LEVEL_CHANGE, OnLevelChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, OnFinishSwitchScene);
        }

        public void Reset()
        {
            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }

            if (UICache != null)
            {
                UICache.Reset();
            }

            mTimer = new Utils.Timer((int)(mRealDestroyWinTime * 1000), true, Mathf.Infinity, RealTimerRemove);

            IsBackMainMapShowWin = "";
        }

        public IEnumerator SwitchUI(string uiName, bool hideLoadingBk = true)
        {
            if (uiName == "" || mCurUIName == uiName)
                yield break;

            mCurUIName = uiName;

            ClearUI();
            ShowLoadingBK(true);
            ShowWindow(uiName);
            if (hideLoadingBk)
                ShowLoadingBK(false);
        }

        private void OnLevelChange(xc.ClientEventBaseArgs args)
        {
            //************************************
            // 场景切换清掉面板從新打開必要面板
            //************************************
            List<string> removeList = new List<string>();
            foreach (var kv in mWindows)
            {
                if (kv.Value.WindowType != UIType.Loading)
                {
                    if (!kv.Value.IsGlobal)
                    {
                        if (kv.Value.mUIObject != null)
                        {
                            kv.Value.Destroy();
                            DestroyWindowGameObject((GameObject)kv.Value.mUIObject);
                            removeList.Add(kv.Key);
                        }
                    }
                    else
                    {
                        kv.Value.Show();
                    }
                }
            }

            for (int i = 0; i < removeList.Count; i++)
            {
                if (mWindows.ContainsKey(removeList[i]))
                {
                    mWindows.Remove(removeList[i]);
                }
            }
        }

        /// <summary>
        /// 响应完成加载场景资源的消息
        /// </summary>
        /// <param name="arg"></param>
        void OnFinishSwitchScene(CEventBaseArgs arg)
        {
            // 当前处于普通野外的时候，才重新弹出窗口
            if(SceneHelp.Instance.IsInNormalWild(SceneHelp.Instance.CurSceneID))
            {
                foreach (var info in mReopenWindows)
                {
                    if (info.IsSystemWindow)
                    {
                        if(info.SubSystemInfo != null)
                            ShowSysWindowEx(info.Name, info.IsMainmapSwitch, info.SubSystemInfo);
                        else
                            ShowSysWindowEx(info.Name, info.IsMainmapSwitch);
                    }
                    else
                        ShowWindow(info.Name);
                }
            }
            

            mReopenWindows.Clear();
        }

#if !DISABLE_LUA

        public bool IsLuaScriptExist(string lua_script)
        {
            if (LuaScriptMgr.Instance == null)
                return false;

            return LuaScriptMgr.Instance.IsLuaScriptExist(lua_script);
        }

#endif

        public void SetLoadingTip(string text)
        {
            if (LoadingWindow != null)
            {
                LoadingWindow.SetLoadingTip(text);
            }
        }

        public void ShowLoadingBK(bool isShow)
        {
            if (LoadingWindow != null)
            {
                LoadingWindow.ShowLoadingBK(isShow);
            }
        }

        public bool LoadingBKIsShow
        {
            get
            {
                if (LoadingWindow != null)
                {
                    return LoadingWindow.LoadingBKIsShow;
                }

                return false;
            }
        }

        public void ShowWaitScreen(bool isShow, float wait_time = 10.0f)
        {
            if (LoadingWindow != null)
            {
                LoadingWindow.ShowWaitScreen(isShow, wait_time);
            }
        }

        public void UpdateLoadingBar(double process)
        {
            if (LoadingWindow != null)
            {
                if (process > 1.0f)
                {
                    process = 1.0f;
                }
                LoadingWindow.UpdateLoadingBar(process);
            }
        }

        /// <summary>
        /// 面板资源完成的回调
        /// </summary>
        /// <param name="args"></param>
        private void OnResourceLoadDone(xc.ClientEventBaseArgs args)
        {
            if (args.Arg == null)
                return;
            UIBaseWindow baseWin = (UIBaseWindow)args.Arg;

            //移除加载窗口
            loadingWindows.Remove(baseWin.mWndName);

            //如果资源加载发现字典没有改面板表面是野窗口
            if (mWindows.ContainsValue(baseWin) == false)
            {
                // 如果在字典中找不到，则说明之前进行了销毁操作，不需要再次调用Destroy @fix by raorui
                //baseWin.Destroy();
                DestroyWindowGameObject((GameObject)baseWin.mUIObject);

                return;
            }
            //断线重连中直接销毁窗口
            if (NetReconnect.Instance.IsReconnect && baseWin.mWndName != "UIAutoConnectWindow")
            {
                DestroyWindowGameObject((GameObject)baseWin.mUIObject);
                if (needCloseWindowsAfterResLoad.Contains(baseWin.mWndName))
                {
                    needCloseWindowsAfterResLoad.Remove(baseWin.mWndName);
                }
                if (mWindows.ContainsKey(baseWin.mWndName))
                {
                    mWindows.Remove(baseWin.mWndName);
                }
                return;
            }
            //************************************
            // 资源加载完开始初始化数据调用InitData 跟show同时调整Zorder
            //************************************
            //AddZOrder(baseWin);

            //var go = baseWin.mUIObject;
            //go.SetActive(true);
            baseWin.InitData();
            if (ModalWindow != null && ModalWindow.mWndName != baseWin.mWndName)
                return;
            if (baseWin.IsModal)//模態窗口衹能唯一如果未銷毀不會打開新的模態
                ModalWindow = baseWin;
            baseWin.Show();

            for (int i = 0; i < needCloseWindowsAfterResLoad.Count; i ++)
            {
                if (baseWin.mWndName == needCloseWindowsAfterResLoad[i])
                {
                    needCloseWindowsAfterResLoad.RemoveAt(i);
                    CloseWindow(baseWin.mWndName);
                    return;
                }
            }
        }

        public void Update()
        {

            using (var iter = mWindows.Values.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    if (iter.Current.IsShow && iter.Current.Behaviours.Count > 0)
                    {
                        foreach (var Behaviour in iter.Current.Behaviours)
                        {
                            if (Behaviour.Value is UILuaBehaviour)//2017.5.5lua下的组件不调用update
                                continue;
                            else
                                Behaviour.Value.UpdateBehaviour();
                        }
                    }
                }
            }
                //foreach (var kv in mWindows)
                //{
                //    if (kv.Value.IsShow && kv.Value.Behaviours.Count > 0)
                //    {
                //        foreach (var Behaviour in kv.Value.Behaviours)
                //        {
                //            if (Behaviour.Value is UILuaBehaviour)//2017.5.5lua下的组件不调用update
                //                continue;
                //            else
                //                Behaviour.Value.UpdateBehaviour();
                //        }
                //    }
                //}

            this.UICache.Update();
        }

        //************************************
        // 每个一段时间查找界面的IsDestroy == true销毁并移除
        //************************************
        private void DestroyWindowGameObject(GameObject obj)
        {
            if (obj != null)
            {
                UnityEngine.GameObject.DestroyImmediate(obj);
                //CommonTool.DestroyObjectImmediate(obj);
            }
        }

        private List<string> tempRemoveList = new List<string>();

        [XLua.BlackList]
        public void RealTimerRemove(float delta)
        {
            if (delta > 0)
                return;

            tempRemoveList.Clear();
            foreach (var kv in mWindows)
            {
                if (kv.Value.mUIObject == null && kv.Value.IsLoadDone)
                {
                    //???
                    GameObject go = kv.Value.mUIObject;
                    kv.Value.Destroy();
                    DestroyWindowGameObject(go);
                    tempRemoveList.Add(kv.Key);
                }
                else
                {
                    if (!kv.Value.IsGlobal && !kv.Value.IsShow)
                    {
                        //卸载掉非全局隐藏的面板
                        var window = kv.Value;
                        if (window.WindowCloseTime != -1 && ((window.WindowCloseTime + window.DestroyDelayTime) < Time.realtimeSinceStartup))
                        {
                            kv.Value.Destroy();
                            GameObject go = kv.Value.mUIObject;
                            DestroyWindowGameObject(go);
                            tempRemoveList.Add(kv.Key);
                        }
                    }
                }
            }
            for (int i = 0; i < tempRemoveList.Count; i++)
            {
                mWindows.Remove(tempRemoveList[i]);
            }
        }

        /// <summary>
        /// 获取那些已经显示的面板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UIBaseWindow GetWindow(string name)
        {

            UIBaseWindow baseWin;
            mWindows.TryGetValue(name, out baseWin);

            if (baseWin != null && baseWin.IsShow)
            {
                return baseWin;
            }

            return null;

        }

        /// <summary>
        /// 获取那些已经存在的面板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UIBaseWindow GetExistingWindow(string name)
        {
            UIBaseWindow baseWin;
            mWindows.TryGetValue(name, out baseWin);

            if (baseWin != null)
            {
                return baseWin;
            }

            return null;
        }

        /// <summary>
        /// 根据面板类型找出需要关闭的系统面板集合,正在显示的和正在下载的都需要关闭
        /// </summary>
        /// <param uiType="uiType"></param>
        /// <returns></returns>
        public List<UIBaseWindow> GetNeedCloseSystemWindowsByType(UIType uiType)
        {
            List<UIBaseWindow> wins = new List<UIBaseWindow>();

            foreach (var kv in mWindows)
            {
                if (kv.Value.WindowType == uiType && (kv.Value.IsShow || !kv.Value.IsLoadDone))
                {
                    wins.Add(kv.Value);
                }
            }
            return wins;
        }

        protected bool CheckWindowDownloaded(string winName)
        {
//             if (winName == "UIMountWindow")
//             {
//                 var content = DBConstText.GetText("DOWNLOAD_PATCH_TIPS");
//                 ui.UIWidgetHelp.Instance.ShowNoticeDlg(ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, content,
//                     (param) =>
//                     {
//                         ui.ugui.UIManager.Instance.ShowSysWindow("UIPatchWindow", 1);
//                     }, null);
//                 return false;
//             }
            
            int patch_id = UIHelper.GetWindowPatchId(winName);
            if (patch_id >= 0)
            {
                bool is_loaded = xpatch.XPatchManager.Instance.IsPatchDownloaded(patch_id);

//                 if(patch_id > 0)
//                     is_loaded = false;
                if (is_loaded)
                    return true;
                else
                {
                    //需要下载最新资源才能体验当前内容
                    var content = DBConstText.GetText("DOWNLOAD_PATCH_TIPS");
                    ui.UIWidgetHelp.Instance.ShowNoticeDlg(ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, content,
                        (param) => { ui.ugui.UIManager.Instance.ShowSysWindow("UIPatchWindow", patch_id); }, null);
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 根据传入的layer强制设置window层级
        /// </summary>
        /// <param name="winName">window名字</param>
        /// <param name="layer">window层级</param>
        /// <param name="param">window参数</param>
        public void ShowWindowLayer(string winName, int layer, params object[] param)
        {
            ShowWindow(winName, param);

            UIBaseWindow baseWindow = null;
            mWindows.TryGetValue(winName, out baseWindow);

            if (baseWindow != null && layer != 0)
                baseWindow.SetLayerDirectIndex(layer);
        }


        //************************************
        // 打开单个指定面板（不包含子面板）
        //************************************
        public void ShowWindow(string winName, params object[] param)
        {
            if (MainCtrl == null)
                return;
            if (CheckWindowDownloaded(winName) == false)
            {
                return;
            }

            if (ModalWindow != null && ModalWindow.IsShow)
            {
                GameDebug.LogWarning(string.Format("当前有模态窗口{0}打开，所以{1}无法打开", ModalWindow.mWndName, winName));
            }

            if (loadingWindows.ContainsKey(winName))
            {
                GameDebug.Log("当前窗口正在加载中:" + winName);
                if (needCloseWindowsAfterResLoad.Contains(winName))
                {
                    needCloseWindowsAfterResLoad.Remove(winName);
                    SetWindowDynOrder(GetExistingWindow(winName));
                }
                return;
            }

            string info = string.Format("show window: {0}", winName);
            BuglyAgent.PrintLog(LogSeverity.LogInfo, info);

            UIBaseWindow baseWin = null;
            if (mWindows.TryGetValue(winName, out baseWin))
            {
                if (baseWin.WinState == WinowState.ResLoadDone)
                {
                    baseWin.ShowParam = param;
                    if (MainCtrl != null)
                    {
                        MainCtrl.CreateAndCheckMoneyBar(baseWin, baseWin.mUIObject, winName, baseWin.CurrencyScale,
                            false);
                        //创建概率公示按钮
                        MainCtrl.CreateAndCheckProbabilityBtn(baseWin, baseWin.mUIObject, winName, baseWin.CurrencyScale, false);
                        //创建七日退款按钮
                        MainCtrl.CreateAndCheckRefundBtn(baseWin, baseWin.mUIObject, winName, baseWin.CurrencyScale, false);
                    }

                    baseWin.Show();
                }
            }
            else
            {
#if !DISABLE_LUA
                string lua_script = "";
                string path = UIHelper.GetLuaWindowPath(winName);
                if (path.CompareTo(string.Empty) == 0)
                    lua_script = string.Format("newUI.{0}", winName);
                else
                    lua_script = string.Format("newUI.{0}.{1}", path, winName);

                //Debug.Log(lua_script);

                if (IsLuaScriptExist(lua_script))
                {
                    baseWin = new UILuaBaseWindow(winName, lua_script);
                }
                else
#endif
                {
                    System.Type t = System.Type.GetType("xc.ui.ugui." + winName);

                    if (t != null)
                    {
                        if (t.IsSubclassOf(typeof(UIBaseWindow)))
                        {
                            baseWin = (UIBaseWindow)System.Activator.CreateInstance(t);
                        }
                        else
                        {
                            GameDebug.Log("use reflection create ugui panel :" + winName);
                            FieldInfo prefabNameField = t.GetField("mWndName", BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public);
                            if (prefabNameField == null)
                            {
                                Debug.LogError(string.Format("the type {0} should cantains a static string field named mPrefabName", t));
                                return;
                            }
                            string prefabName = prefabNameField.GetValue(null) as string;
                            baseWin = new UIBaseWindow(prefabName);
                        }
                    }
                }
                if (baseWin == null)
                {
                    Debug.LogError("UIManager.CreateWindow error:" + winName);
                    return;
                }

                if (baseWin.WinState == WinowState.ResNoLoad)
                {
                    ///这里如果面板时动态的，则预先计算好动态层级
                    this.SetWindowDynOrder(baseWin);

                    baseWin.ShowParam = param;
                    mWindows.Add(winName, baseWin);
                    baseWin.WinState = WinowState.ResLoading;
                    loadingWindows.Add(winName, true);
                    MainCtrl.StartCoroutine(MainCtrl.CreateWindowFromPrefab(baseWin.mWndName, baseWin));
                }
            }

            if (baseWin != null)
                baseWin.IsSystemWindow = false;

            // 如果之前已经设置为true，而在Pop窗口的时候会又调用ShowWindow
            // 此处需要判断下之前是否设置过
            if(!mOpenedSysWindow.ContainsKey(winName))
                mOpenedSysWindow[winName] = false;
        }

        /// <summary>
        /// 在面板显示之前和初始化之前设置好面板的层级,动态层级的前后关系由ShowWindow的调用顺序来决定,每个层级会有10个层的间隔用来给粒子特效使用
        /// </summary>
        /// <param name="baseWin"></param>
        public void SetWindowDynOrder(UIBaseWindow baseWin)
        {
            //静态面板不设置
            if (baseWin.staticLayerIndex != -1)
            {
                return;
            }

            UILayerInfo info = this.GetLayerInfo(baseWin.WindowType);

            int index = info.GetNewDynamicLayerIndex(baseWin);

            baseWin.SetDynamicLayerIndex(index);
        }

        /// <summary>
        /// 移除动态面板所在层级的堆栈信息
        /// </summary>
        /// <param name="win"></param>
        public void RemoveWindowDynOrder(UIBaseWindow win)
        {
            if (win.staticLayerIndex != -1)
            {
                return;
            }

            UILayerInfo info = this.GetLayerInfo(win.WindowType);

            info.RemoveDynamicLayerIndex(win);
        }

        /// <summary>
        /// 销毁窗口(因为热更界面的需要，只在Editor中调用，其他地方不能使用)
        /// </summary>
        /// <param name="name"></param>
        public void DestroyWindow(string name)
        {
            UIBaseWindow baseWin;
            if (mWindows.TryGetValue(name, out baseWin))
            {
                if (baseWin.mUIObject != null)
                {
                    baseWin.Destroy();
                    DestroyWindowGameObject((GameObject)baseWin.mUIObject);
                    mWindows.Remove(name);
                }
            }
            else
            {
                GameDebug.LogWarning(string.Format("DestroyWindow {0} is null", name));
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="name"></param>
        public void CloseWindow(string name)
        {
            string info = string.Format("close window: {0}", name);
            BuglyAgent.PrintLog(LogSeverity.LogInfo, info);

            //************************************
            // 这里调用navgationctr 处理面板的队列已经面板的zOrder以及SetSiblingIndex
            //************************************
            UIBaseWindow baseWin;
            if (mWindows.TryGetValue(name, out baseWin))
            {
                //把资源没有下载完成的面板加入关闭列表，资源下载完成时自动关闭
                for (int i = 0; i < baseWin.SubWindow.Count; i++)
                {
                    string subWindow = baseWin.SubWindow[i];
                    if (loadingWindows.ContainsKey(subWindow) && !needCloseWindowsAfterResLoad.Contains(subWindow))
                    {
                        needCloseWindowsAfterResLoad.Add(subWindow);
                    }
                }
                if (loadingWindows.ContainsKey(name) && !needCloseWindowsAfterResLoad.Contains(name))
                {
                    needCloseWindowsAfterResLoad.Add(name);
                    RemoveWindowDynOrder(baseWin);
                    return;
                }
                if (!baseWin.IsShow)
                    return;

                baseWin.Close();
                if (baseWin.IsModal)
                {
                    ModalWindow = null;
                }
                //查找是否含有子面板 并且保存
                baseWin.BackupOpenSubWindows.Clear();
                for (int i = 0; i < baseWin.SubWindow.Count; i++)
                {
                    string winName = baseWin.SubWindow[i];
                    UIBaseWindow subWindw = null;
                    mWindows.TryGetValue(winName, out subWindw);
                    if (subWindw != null)
                    {
                        if (subWindw.IsShow && winName != "UIGoodsTipsWindow" 
                            && winName != "UIEquipmentTipsWindow")
                        {
                            UIBaseWindow.BackupWin back_struct = new UIBaseWindow.BackupWin();
                            back_struct.WinName = winName;
                            back_struct.ShowParam = subWindw.ShowParam;
                            baseWin.BackupOpenSubWindows.Add(back_struct);
                        }
                        subWindw.Close();
                    }
                }

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CLOSE_WIN, new CEventBaseArgs(name));
            }
        }

        //************************************
        // 隐藏所有已打开的面板（在剧情系统中使用，一般不需要在其他地方调用）
        //************************************
        public void CloseAllWindow()
        {
            xc.ui.ugui.UIMainCtrl.MainCam.enabled = false;

            mOpeningSysWin.Clear();
            UpdateSysUIMaskBg();
        }

        /// <summary>
        /// 关闭除了主UI的所有窗口(断线重连时候用)
        /// </summary>
        public void CloseAllWindowExcept(bool record = false)
        {
            UINavgationCtrl.Instance.Clear();

            string except = "UIGuideWindow";

            List<string> windows_list = SGameEngine.Pool<string>.List.New(mWindows.Keys.Count);
            foreach (var k in mWindows.Keys)
            {
                windows_list.Add(k);
            }

            foreach (string win_name in windows_list)
            {
                if (win_name == except)
                {
                    // FIXME
                    // 此处会造成引导模型消失，暂时先屏蔽
                    //GuideManager.Instance.Pause();
                }
                else
                {
                    var wnd = mWindows[win_name];
                    if (wnd == null)
                        continue;

                    // 记录当前打开界面的信息
                    if (record)
                    {
                        //如果当前界面是打开状态，并且reopen配置为true
                        var info = DBUIManager.Instance.GetData(wnd.mWndName);
                        if (wnd.IsShow && info!= null && info.reopen)
                        {
                            var reopenInfo = new ReopenInfo();
                            reopenInfo.Name = wnd.mWndName;
                            reopenInfo.IsSystemWindow = wnd.IsSystemWindow;
                            reopenInfo.IsMainmapSwitch = wnd.IsMainmapSwitch;
                            reopenInfo.SubSystemInfo = wnd.SubSystemInfo;
                            mReopenWindows.Add(reopenInfo);
                        }
                    }

                    if (wnd.ReconnectHandle == 0)// 不处理
                    {
                        continue;
                    }
                    else if(wnd.ReconnectHandle == 1) // 关闭
                    {
                        if (wnd.IsSystemWindow)
                            CloseSysWindow(win_name);
                        else
                            CloseWindow(win_name);
                    }
                    else // 打开
                    {
                        if(wnd.IsShow == false)
                        {
                            UIManager.Instance.ShowSysWindow(win_name);
                        }
                    }
                }
            }

            SGameEngine.Pool<string>.List.Free(windows_list);

            UINavgationCtrl.Instance.Clear();

            // 通知主UI播放收回的动画
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_SWITCH_ANIMATION, new CEventBaseArgs(true));
        }

        /// <summary>
        /// 切换位面副本的时候根据配置表清除界面
        /// </summary>
        public void CloseWindowsWhenSwitchPlaneInstance()
        {
            List<string> windows_list = SGameEngine.Pool<string>.List.New(mWindows.Keys.Count);
            foreach (var k in mWindows.Keys)
            {
                windows_list.Add(k);
            }
            UINavgationCtrl.Instance.Clear();
            string except = "UIGuideWindow";
            foreach (string win_name in windows_list)
            {
                if (win_name == except)
                {
                    // FIXME
                    // 此处会造成引导模型消息，暂时先屏蔽
                    //GuideManager.Instance.Pause();
                }
                else
                {
                    var wnd = mWindows[win_name];
                    if (wnd == null)
                        continue;

                    if (wnd.StayWhenSwitchPlaneInstance == false)
                    {
                        if (wnd.IsSystemWindow)
                            CloseSysWindow(win_name, false);
                        else
                            CloseWindow(win_name);
                    }
                }
            }

            SGameEngine.Pool<string>.List.Free(windows_list);
            UINavgationCtrl.Instance.Clear();
        }


        //************************************
        // 显示所有已打开的面板
        //************************************
        public void ShowAllWindow()
        {
            xc.ui.ugui.UIMainCtrl.MainCam.enabled = true;

            UpdateSysUIMaskBg();
        }

        /// <summary>
        /// 删除所有的ui窗口
        /// </summary>
        public void ClearUI()
        {
            List<UIBaseWindow> NeedRemoveList = new List<UIBaseWindow>();
            Dictionary<string, UIBaseWindow> DontRemoveList = new Dictionary<string, UIBaseWindow>();
            foreach (var kv in mWindows)
            {
                if (kv.Value.WindowType != UIType.Loading)
                {
                    if (kv.Value.mUIObject != null)
                    {
                        NeedRemoveList.Add(kv.Value);
                    }
                }
                else
                {
                    if (DontRemoveList.ContainsKey(kv.Key) == false)
                    {
                        DontRemoveList.Add(kv.Key, kv.Value);
                    }
                }
            }
            for (int i = 0; i < NeedRemoveList.Count; i ++)
            {
                NeedRemoveList[i].Destroy();
                DestroyWindowGameObject((GameObject)NeedRemoveList[i].mUIObject);
            }
            NeedRemoveList.Clear();
            NeedRemoveList = null;
            mWindows.Clear();

            loadingWindows.Clear();
            if (MainCtrl != null)
                MainCtrl.ClearAllChildWindow();

            foreach (var kv in DontRemoveList)
            {
                mWindows.Add(kv.Key, kv.Value);
            }
            mCurUIName = "";

            UINavgationCtrl.Instance.Clear();
            mOpenedSysWindow.Clear();
            mOpeningSysWin.Clear();

            UpdateSysUIMaskBg();
        }

        public void Dispose()
        {
            this.ClearUI();
            UICache.Dispose();
            cache = null;
        }

        /// <summary>
        /// 获取当前窗口管理类中的所有窗口
        /// </summary>
        public Dictionary<string, UIBaseWindow> AllWindow
        {
            get { return mWindows; }
        }

        /// <summary>
        ///  打开一个系统的窗口
        /// </summary>
        /// <param name="winName">窗口的名字</param>
        /// <param name="mainmap_switch">是否触发主UI的动画</param>
        /// <param name="param">窗口的参数</param>
        public void ShowSysWindowEx(string winName, bool mainmap_switch, params object[] param)
        {
            if (CheckWindowDownloaded(winName) == false)
            {
                return;
            }

            if (ModalWindow != null && ModalWindow.IsShow)
            {
                GameDebug.LogWarning(string.Format("当前有模态窗口{0}打开，所以{1}无法打开", ModalWindow.mWndName, winName));
            }

            UIBaseWindow win = null;
            mWindows.TryGetValue(winName, out win);
            // 显示其他窗口的时候，需要发消息触发主UI的关闭动画
            if (winName.CompareTo(MainPanelName) != 0 && (win == null || (win != null && win.IsShow == false)))
            {
                if (mainmap_switch)
                {
                    if (IsOpeningSysWinExceptMainmapWin() == false)
                    {
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_SWITCH_ANIMATION, new CEventBaseArgs(false));
                    }
                }
            }
            // 当前需要显示的是主UI时，需要将IsBackMainMapShowWin指定的窗口也显示出来
            else if (winName.CompareTo(MainPanelName) == 0 && IsBackMainMapShowWin.CompareTo("") != 0 && SceneHelp.Instance.IsInInstance == false)
            {
                ShowSysWindow(IsBackMainMapShowWin);
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.OPEN_SYS_WIN, new CEventBaseArgs(winName));

            UINavgationCtrl.Instance.Push(winName, param);

            mWindows.TryGetValue(winName, out win);
            if (win != null)
            {
                win.IsSystemWindow = true;
                win.IsMainmapSwitch = mainmap_switch;
            }
               
            if (winName != "UIChatWindow")  //聊天框特殊处理，不算作系统窗口
                mOpenedSysWindow[winName] = true;

            if (!mOpeningSysWin.Contains(winName))
                mOpeningSysWin.Add(winName);

            UpdateSysUIMaskBg();
        }

        public void ShowSysWindow(string winName, params object[] param)
        {
            ShowSysWindowEx(winName, true, param);
        }

        /// <summary>
        /// 关闭一个系统的窗口
        /// </summary>
        /// <param name="winName"></param>
        /// <param name="isPlayMainMapAni"></param>
        public void CloseSysWindow(string winName, bool isPlayMainMapAni = true)
        {
            UIBaseWindow win = null;

            win = this.GetWindow(winName);
            //mWindows.TryGetValue(winName, out win);

            if (mOpeningSysWin.Contains(winName))
                mOpeningSysWin.Remove(winName);

            if (win == null)
            {
                return;
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CLOSE_SYS_WIN, new CEventBaseArgs(winName));

            // 如果在弹出当前窗口的时候，打开了其他系统窗口，则不需要显示主UI
            bool open_other_sys_window = UINavgationCtrl.Instance.Pop(winName);

            if (!open_other_sys_window && isPlayMainMapAni && winName.CompareTo(MainPanelName) != 0 && UINavgationCtrl.Instance.GetStackLen() == 0)
            {
                if (IsOpeningSysWinExceptMainmapWin() == false)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_SWITCH_ANIMATION, new CEventBaseArgs(true));
                }
            }

            UpdateSysUIMaskBg();

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CLOSE_WIN, new CEventBaseArgs(winName));
        }

        /// <summary>
        /// 是否曾以系统窗口的方式打开
        /// </summary>
        /// <param name="wnd_name"></param>
        public bool IsOpenedSysWindow(string wnd_name)
        {
            bool open_by_sys = false;
            mOpenedSysWindow.TryGetValue(wnd_name, out open_by_sys);
            return open_by_sys;
        }

        /// <summary>
        /// 是否正在打开除了主界面之外的系统界面
        /// </summary>
        /// <returns></returns>
        public bool IsOpeningSysWinExceptMainmapWin()
        {
            foreach (string winName in mOpeningSysWin)
            {
                // 聊天框特殊处理，不算作系统窗口
                if (winName.Equals("UIChatWindow") == false && winName.Equals("UIMainmapWindow") == false && GetWindow(winName) != null)
                {
                    return true;
                }
            }

            return false;
        }

        //************************************
        // 根据当前windowType找出IsShow的面板集合
        //************************************
        public List<UIBaseWindow> GetStateIsShowWindowByWindowType(UIType uiType, bool isShow)
        {
            List<UIBaseWindow> wins = new List<UIBaseWindow>();

            foreach (var kv in mWindows)
            {
                if (kv.Value.WindowType == uiType && kv.Value.IsShow == isShow)
                {
                    wins.Add(kv.Value);
                }
            }
            return wins;
        }

        private const int MIN_LAYER = 0;
        private const int MAX_LAYER = 5000;
        private const float MIN_DIS = 10f;
        private const float MAX_DIS = 3000f;

        /// <summary>
        /// 最大layer 0 ~ 6000映射到10~1800
        /// </summary>
        /// <param name="orderInLayer"></param>
        /// <returns></returns>
        public float GetPlaneDistance(int orderInLayer)
        {
            orderInLayer = Mathf.Clamp(orderInLayer, MIN_LAYER, MAX_LAYER);

            return MAX_DIS - (MIN_DIS + ((MAX_DIS - MIN_DIS) / (MAX_LAYER - MIN_LAYER)) * (float)orderInLayer);
        }

        /// <summary>
        /// 系统UI界面mask背景图
        /// </summary>
        void UpdateSysUIMaskBg()
        {

            //bool isShowMsk = false;

            //for (int i = 0; i < mOpeningSysWin.Count; i++)
            //{
            //    string winName = mOpeningSysWin[i];

            //    if (!string.IsNullOrEmpty(winName) && !winName.Equals(MainPanelName))
            //    {
            //        isShowMsk = true;
            //        break;
            //    }
            //}

            //MainCtrl.UIMask.SetActive(isShowMsk);
        }

        /// <summary>
        /// 点击返回键时调用，关闭配置相关的界面
        /// </summary>
        /// <returns></returns>
        public bool TryCloseAllWindow()
        {
            bool isHasClose = false;
            UINavgationCtrl.Instance.Clear();

            List<string> windows_list = SGameEngine.Pool<string>.List.New(mWindows.Keys.Count);
            foreach (var k in mWindows.Keys) {
                windows_list.Add(k);
            }

            foreach (string win_name in windows_list) {
                var wnd = mWindows[win_name];
                if (wnd == null)
                    continue;

                if (wnd.IsShow == false)
                    continue;

                if (wnd.ReturnHandle == 0)// 不处理
                {
                    continue;
                }
                else if (wnd.ReturnHandle == 1) // 关闭
                {
                    isHasClose = true;
                    if (wnd.IsSystemWindow) {
                        CloseSysWindow(win_name);
                    }
                    else {
                        CloseWindow(win_name);
                    }
                }
                else // 打开
                {
                    if (wnd.IsShow == false) {
                        UIManager.Instance.ShowSysWindow(win_name);
                    }
                }
            }

            SGameEngine.Pool<string>.List.Free(windows_list);

            UINavgationCtrl.Instance.Clear();

            // 通知主UI播放收回的动画
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_SWITCH_ANIMATION, new CEventBaseArgs(true));

            return isHasClose;
        }

    }
}