using System.Collections.Generic;
using UnityEngine;

namespace xc.ui.ugui
{
    public enum UIType
    {
        Normal = 0,
        Hud,
        Loading,
        Pop,
    }

    public enum WinowState
    {
        ResNoLoad = 0,
        ResLoading,
        ResLoadDone,
    }

    [wxb.Hotfix]
    public class UIBaseWindow
    {
        /// <summary>
        /// 是否是通过ShowSysWindow接口打开的
        /// </summary>
        public bool IsSystemWindow = false;

        /// <summary>
        /// 打开界面的时候，是否触发主UI的动画
        /// </summary>
        public bool IsMainmapSwitch = false;

        /// <summary>
        /// 子系统的信息
        /// </summary>
        public System.Object SubSystemInfo;

        /// <summary>
        /// 延迟销毁时间
        /// </summary>
        public float DestroyDelayTime
        {
            get
            {
                if (mInfo != null)
                    return mInfo.destroy_delay_time;
                else
                {
                    if (SystemInfo.systemMemorySize <= 1024)
                        return 10.0f;
                    else
                        return 20.0f;
                }
            }
        }

        public float WindowCloseTime = -1f;

        public Dictionary<string, IUIBehaviour> Behaviours = new Dictionary<string, IUIBehaviour>();//这个用做通的behaviour
        public string mWndName;
        public string mPrefabName;
        public GameObject mUIObject;//原始prefab
        public bool IsLoadDone = false;

        public enum CloseWinsType : byte
        {
            None = 0,
            GoodsAndEquipTips = 1,
        }

        public CloseWinsType mCloseWinsType
        {
            get
            {
                if (mInfo != null)
                    return (CloseWinsType)mInfo.close_wins_type_when_show;
                else
                    return CloseWinsType.None;
            }
        }

        /// <summary>
        /// 断线重连后窗口的处理逻辑 (0: 不处理 1: 关闭 2：打开)
        /// </summary>
        public uint ReconnectHandle
        {
            get
            {
                if (mInfo != null)
                    return mInfo.reconnect_handle;
                else
                    return 0;
            }
        }

        /// <summary>
        /// 点击返回键的处理逻辑 (0: 不处理 1: 关闭 2：打开)
        /// </summary>
        public uint ReturnHandle
        {
            get
            {
                if (mInfo != null)
                    return mInfo.return_handle;
                else
                    return 0;
            }
        }

        /// <summary>
        /// 切换位面副本时候的窗口是否保留
        /// </summary>
        public bool StayWhenSwitchPlaneInstance
        {
            get
            {
                if (mInfo != null)
                    return mInfo.stay_when_switch_plane_instance;
                else
                    return false;
            }
        }

        /// <summary>
        /// 是否为模态窗口
        /// </summary>
        public bool IsModal
        {
            get
            {
                if (mInfo != null)
                    return mInfo.is_modal;
                else
                    return false;
            }
        }

        public bool IsGlobal = false; //是否为全局用于Hud层、或特殊面板

        public bool IsShow = false;
        public UIType WindowType = UIType.Normal; //面板类型

        public object[] ShowParam = null;//参数
        public List<string> SubWindow = new List<string>();//子面板
        public List<string> InitOpenWindows = new List<string>();//初始打开的子面板

        public void SetShowParam(params object[] new_show_param)
        {
            ShowParam = new_show_param;
        }

        public class BackupWin
        {
            public string WinName;
            public object[] ShowParam;
        }

        public List<BackupWin> BackupOpenSubWindows = new List<BackupWin>();//用作关闭（hide）时保存当前打开的子面板列表
        public WinowState WinState = WinowState.ResNoLoad;

        public string LuaPath
        {
            get
            {
                if (mInfo != null)
                    return mInfo.lua_path;
                else
                    return "";
            }
        }

        public bool IsBackMainMapOpen = false;

        private Canvas canvas;

        public int staticLayerIndex = -1;

        /// <summary>
        /// 用来标记是否是第一次显示，第一次显示时的层级关系由外部初始化时算好确定，后面的层级关系由show方法来确定。
        /// </summary>
        private bool firstDynCaculate = true;

        /// <summary>
        /// 面板第一次显示
        /// </summary>
        private bool firstShow = true;

        private int dynamicLayerIndex = -1;

        private int directLayerIndex = -1;

        /// <summary>
        /// string 类型参数，可用使用分割符拼接参数
        /// </summary>
        public string UpdateParam;

        public void SetCanvasOrderInLayer(int orderInLayer)
        {
            if (canvas == null)
            {
                canvas = mUIObject.GetComponent<Canvas>();
            }
            canvas.sortingOrder = orderInLayer;
            float planeDistance = UIManager.Instance.GetPlaneDistance(canvas.sortingOrder);
            canvas.planeDistance = planeDistance;
        }

        public void SetDynamicLayerIndex(int layer)
        {
            this.dynamicLayerIndex = layer;
        }


        //用于直接设置layer 忽略staticLayerIndex这个值 
        public void SetLayerDirectIndex(int layer)
        {
            this.directLayerIndex = layer;
            if (mUIObject != null)
            {
                SetCanvasOrderInLayer(layer);
            }
        }



        /// <summary>
        /// 记录当前面板使用到的cache信息
        /// </summary>
        private Dictionary<string, List<GameObject>> cacheInfos;

        /// <summary>
        /// 专门用来存储物品对象信息
        /// </summary>
        private List<GameObject> cacheItems;

        public GameObject MoneyBarObj = null;
        public GameObject ProbabilityBtnObj = null;
        public GameObject RefundBtnObj = null;
        public string Param1_str = "";
        public float CurrencyScale = 1;

        public Canvas GetCanvas()
        {
            if (canvas == null)
            {
                this.mUIObject.GetComponent<Canvas>();
            }

            return this.canvas;
        }

        public UIBaseWindow()
        {
            IsLoadDone = false;
            mWndName = GetType().Name;
            mPrefabName = mWndName;
            LoadDB();
            InitCache();
        }

        private void InitCache()
        {
            cacheInfos = new Dictionary<string, List<GameObject>>();
            cacheItems = new List<GameObject>();
        }

        public UIBaseWindow(string winName)
        {
            mWndName = winName;
            mPrefabName = mWndName;
            IsLoadDone = false;
            LoadDB();
            InitCache();
        }

        private DBUIManager.UIInfo mInfo = null;

        //初始讀專門的配置表獲取 IsGlobal  、supportBack、WindowType
        protected void LoadDB()
        {
            var ui_info = DBUIManager.Instance.GetData(mWndName);
            if (ui_info != null)
            {
                mInfo = ui_info;

                IsGlobal = ui_info.is_global;
                WindowType = (UIType)ui_info.ui_type;

                SubWindow.Clear();
                if (string.IsNullOrEmpty(mInfo.sub_panels) == false)
                {
                    var raw = mInfo.sub_panels.Replace("[", "").Replace("]", "");
                    string[] results = raw.Split(',');
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (results[i].CompareTo(string.Empty) != 0)
                            SubWindow.Add(results[i]);
                    }
                }

                InitOpenWindows.Clear();
                if (string.IsNullOrEmpty(mInfo.init_open_panels) == false)
                {
                    var raw = mInfo.init_open_panels.Replace("[", "").Replace("]", "");
                    string[] results = raw.Split(',');
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (results[i].CompareTo(string.Empty) != 0)
                            InitOpenWindows.Add(results[i]);
                    }
                }

                int static_index = mInfo.static_layer_index;
                this.staticLayerIndex = UIManager.Instance.GetLayerInfo(WindowType).GetStaticLayerIndex(static_index);
            }
        }

        public virtual void Show()
        {
            IsShow = true;

            ///第一次显示在初始化方法中去计算层级,防止初始化函数中也存在显示面板的方法
            if (!firstShow)
            {
                CaculateLayer();
            }

            foreach (var kv in Behaviours)
            {
                if (kv.Value.isInit == false)
                {
                    kv.Value.InitBehaviour();
                }
                kv.Value.EnableBehaviour(true);
            }

            IsBackMainMapOpen = false;
            if (UIManager.Instance.IsBackMainMapShowWin.CompareTo(mWndName) == 0)
            {
                UIManager.Instance.IsBackMainMapShowWin = "";
            }

            ResetUI();

            this.WindowCloseTime = -1f;

            //计算面板距离,orderInLayer已经计算好

            firstShow = false;

            if (mCloseWinsType == CloseWinsType.GoodsAndEquipTips)
            {//要关闭物品TIPS和装备tips
                UIManager.Instance.CloseWindow("UIGoodsTipsWindow");
                UIManager.Instance.CloseWindow("UIEquipmentTipsWindow");
                UIManager.Instance.CloseWindow("UINumericKeyboardWindow");
                UIManager.Instance.CloseWindow("UILessGoldTipsWindow");
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.SHOW_WIN, new CEventBaseArgs(mWndName));
        }

        private void CaculateLayer()
        {
            if (mUIObject)
            {
                if (canvas == null)
                {
                    canvas = mUIObject.GetComponent<Canvas>();
                }

                SetUIActive(true);
                if (mUIObject.activeSelf != true)
                    mUIObject.SetActive(true);

                CaculateStaticLayer();
                CaculateDynamicLayer();
            }
        }

        private void CaculateDynamicLayer()
        {
            if (staticLayerIndex != -1)
            {
                return;
            }

            if (firstDynCaculate)
            {
                ///第一次显示的动态层级会在初始化前算好

                if (this.dynamicLayerIndex != -1)
                {
                    this.SetCanvasOrderInLayer(this.dynamicLayerIndex);
                }
                else
                {
                    if (!mWndName.Equals("UILoadingWindow"))
                        GameDebug.LogWarning("ui dynamic layer error,wnd_name:" + mWndName);
                }
            }
            else
            {
                ///非第一次的动态层级在这里计算
                UIManager.Instance.SetWindowDynOrder(this);

                this.SetCanvasOrderInLayer(this.dynamicLayerIndex);
            }

            firstDynCaculate = false;
        }

        /// <summary>
        /// 计算静态层级
        /// </summary>
        private void CaculateStaticLayer()
        {
            if (this.staticLayerIndex == -1)
            {
                return;
            }

            if (mUIObject == null)
            {
                return;
            }
            if (directLayerIndex != -1)
                this.SetCanvasOrderInLayer(directLayerIndex);
            else
                this.SetCanvasOrderInLayer(staticLayerIndex);
        }

        ////初始化绑定数据包含变量赋值、协议、事件、这里是UI资源完全加载完毕等
        protected virtual void InitUI()
        {
            //如有需要AddBehaviour
        }

        /// <summary>
        /// 窗口资源加载完毕后调用
        /// </summary>
        public virtual void InitData()
        {
            IsLoadDone = true;
            WinState = WinowState.ResLoadDone;

            canvas = mUIObject.GetComponent<Canvas>();

            if (firstShow)
            {
                ///第一次显示在这里计算层级
                CaculateLayer();
            }

            InitUI();

            var all_shield_widget = DBWidgetShield.Instance.GetAllWidget(this.mWndName);
            if (all_shield_widget != null)
            {
                foreach (var info in all_shield_widget)
                {
                    var widget = mUIObject.transform.Find(info.path);
                    if (widget != null)
                    {
                        if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                        {
                            if ((info.is_audit && AuditManager.Instance.ContainShieldWId((uint)info.id))
                                || !info.is_audit)
                            {
                                widget.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            if (!info.is_audit)
                                widget.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        //内部的Show
        protected virtual void ResetUI()
        {
        }

        //close后会先调用，如果一定时间没在重新打开直接外部调用Destroy（）
        protected virtual void HideUI()
        {
        }

        //销毁时会调用这里用来处理反注册消息跟事件
        protected virtual void UnInitUI()
        {
            IsLoadDone = false;
        }

        public virtual void Close()
        {
            if (!IsShow)
            {
                return;
            }
            IsShow = false;

            if (IsModal)
            {
                UIManager.Instance.ModalWindow = null;
            }

            foreach (var kv in Behaviours)
            {
                kv.Value.EnableBehaviour(false);
            }
            directLayerIndex = -1;
            IsShow = false;
            SetUIActive(false);
            HideUI();
            WindowCloseTime = Time.realtimeSinceStartup;

            ///隐藏时需要移除掉动态层级栈的信息，否则会造成内存泄漏
            UIManager.Instance.RemoveWindowDynOrder(this);
        }

        public virtual void Destroy()
        {
            if (IsShow)
            {
                UIManager.Instance.CloseWindow(this.mWndName);
            }

            //这里再移除一次，确保堆栈正确。
            UIManager.Instance.RemoveWindowDynOrder(this);

            IsShow = false;

            foreach (var kv in Behaviours)
            {
                kv.Value.DestroyBehaviour();
            }
            Behaviours.Clear();
            UnInitUI();
            BackupOpenSubWindows.Clear();

            this.FreeAllItemGameObj();
            this.DestroyAllTemplates();
        }

        /// <summary>
        /// 设置ui的可见性
        /// </summary>
        /// <param name="active"></param>
        private void SetUIActive(bool active)
        {
            /*if (mUIObject != null)
            {
                if(mUIObject.activeSelf != active)
                    mUIObject.SetActive(active);
            }*/

            if (canvas == null)
                return;

            if (canvas.enabled != active)
                canvas.enabled = active;

            if (active)
            {
                if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
                {
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                }
            }
            else
            {
                if (canvas.renderMode != RenderMode.WorldSpace)
                {
                    canvas.renderMode = RenderMode.WorldSpace;
                    var local_pos = canvas.transform.localPosition;
                    local_pos.x = -1000.0f;
                    canvas.transform.localPosition = local_pos;
                }
            }
        }

        //内部接口
        public IUIBehaviour AddBehaviour(string name)
        {
            IUIBehaviour uiBehaviour = null;
            System.Type t = System.Type.GetType("xc.ui.ugui." + name);
            if (t != null && t.IsSubclassOf(typeof(IUIBehaviour)))
            {
                uiBehaviour = (IUIBehaviour)System.Activator.CreateInstance(t);
                uiBehaviour.Window = this;
                Behaviours.Add(name, uiBehaviour);
                return uiBehaviour;
            }

            if (LuaScriptMgr.Instance == null || !LuaScriptMgr.Instance.IsLoaded())
            {
                return null;
            }
            string lua_script = "";
            if (LuaPath.CompareTo(string.Empty) == 0)
                lua_script = string.Format("newUI.{0}", name);
            else
                lua_script = string.Format("newUI.{0}.{1}", LuaPath, name);
            if (LuaScriptMgr.Instance.IsLuaScriptExist(lua_script))
            {
                uiBehaviour = new UILuaBehaviour(this, lua_script);
                Behaviours.Add(name, uiBehaviour);
                return uiBehaviour;
            }
            else
            {
                Debug.LogError(string.Format("{0}未找到名字为{1}的组件", mWndName, name));
                return null;
            }
        }

        /// <summary>
        /// 添加命名空间为xc.ui.ugui.name的组件，无返回值
        /// </summary>
        /// <param name="name"></param>
        public void AppendBehaviour(string name)
        {
            IUIBehaviour uiBehaviour = null;
            System.Type t = System.Type.GetType("xc.ui.ugui." + name);
            if (t != null && t.IsSubclassOf(typeof(IUIBehaviour)))
            {
                uiBehaviour = (IUIBehaviour)System.Activator.CreateInstance(t);
                uiBehaviour.Window = this;
                Behaviours.Add(name, uiBehaviour);
                return;
            }

            if (LuaScriptMgr.Instance == null || !LuaScriptMgr.Instance.IsLoaded())
            {
                return;
            }

            string lua_script = "";
            if (LuaPath.CompareTo(string.Empty) == 0)
                lua_script = string.Format("newUI.{0}", name);
            else
                lua_script = string.Format("newUI.{0}.{1}", LuaPath, name);
            if (LuaScriptMgr.Instance.IsLuaScriptExist(lua_script))
            {
                uiBehaviour = new UILuaBehaviour(this, lua_script);
                Behaviours.Add(name, uiBehaviour);
                return;
            }
            else
            {
                Debug.LogError(string.Format("{0}未找到名字为{1}的组件", mWndName, name));
                return;
            }
        }

        public IUIBehaviour GetBehaviour(string name)
        {
            IUIBehaviour uiBehaviour = null;
            if (Behaviours.TryGetValue(name, out uiBehaviour))
                return uiBehaviour;
            return null;
        }

        public GameObject FindChild(string childName)
        {
            return FindChild(mUIObject, childName);
        }

        public T FindChild<T>(string childName) where T : Component
        {
            GameObject child = FindChild(childName);
            if (child)
                return child.GetComponent<T>();
            else
                return null;
        }

        public GameObject FindChild(GameObject parent, string childName)
        {
            if (parent == null)
            {
                return null;
            }

            Transform trans = UIHelper.FindChildInHierarchy(parent.transform, childName);
            if (trans != null)
                return trans.gameObject;
            else
                return null;
        }

        public T FindChild<T>(GameObject parent, string childName) where T : Component
        {
            GameObject child = FindChild(parent, childName);
            if (child)
                return child.GetComponent<T>();
            else
                return null;
        }

        public Sprite LoadSprite(string spriteName)
        {
            return UIHelper.LoadSpriteByBaseWindow(this, spriteName);
        }

        public Material LoadMaterial(string materialName)
        {
            return UIHelper.LoadMaterialByBaseWindow(this, materialName);
        }

        public AudioClip LoadAudioClip(string audioClipName)
        {
            return UIHelper.LoadAudioClipByBaseWindow(this, audioClipName);
        }

        public GameObject FindWidgetByPath(string widgetPath)
        {
            if (mUIObject == null)
            {
                return null;
            }

            var trans = mUIObject.transform;
            var objNames = widgetPath.Split(new char[] { '/' });

            return FindWidgetByPath(trans, objNames, 0);
        }

        public GameObject FindWidgetByPath(Transform trans, string[] obj_names, int begin_idx)
        {
            var name = obj_names[begin_idx];
            for (int i = 0; i < trans.childCount; i++)
            {
                var child_trans = trans.GetChild(i);
                if (child_trans.name == name)
                {
                    if (begin_idx >= obj_names.Length - 1)
                        return child_trans.gameObject;

                    var widget = FindWidgetByPath(child_trans, obj_names, begin_idx + 1);
                    if (widget != null)
                        return widget;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="name"></param>
        /// <param name="template"></param>
        /// <param name="releaseTime"></param>
        public void AddTemplate(string name, GameObject template, float releaseTime = 10f)
        {
            if (cacheInfos.ContainsKey(name))
            {
                return;
            }

            cacheInfos.Add(name, new List<GameObject>());

            UIManager.Instance.UICache.AddTemplate(name, template, releaseTime);
        }

        /// <summary>
        /// 获取模板注册实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <param name="isActive"></param>
        /// <param name="changeTransform"></param>
        /// <returns></returns>
        public GameObject GetTemplateInstance(string name, Transform parent, bool isActive)
        {
            if (!cacheInfos.ContainsKey(name))
            {
                GameDebug.LogError("not exist template " + name);
                return null;
            }
            GameObject obj = UIManager.Instance.UICache.GetTemplate(name, parent, isActive);
            cacheInfos[name].Add(obj);

            return obj;
        }

        public GameObject GetTemplateInstanceEx(string name, Transform parent, bool isActive, int sort)
        {
            if (!cacheInfos.ContainsKey(name))
            {
                GameDebug.LogError("not exist template " + name);
                return null;
            }

            GameObject obj = UIManager.Instance.UICache.GetTemplate(name, parent, isActive);
            obj.transform.SetSiblingIndex(sort);
            cacheInfos[name].Add(obj);

            return obj;
        }

        /// <summary>
        /// 全部放回缓存池
        /// </summary>
        public void FreeAllTemplateInstance()
        {
            foreach (var name in cacheInfos.Keys)
            {
                FreeTemplateInstance(name);
            }
        }

        /// <summary>
        /// 所有对象放回缓存池
        /// </summary>
        public void FreeTemplateInstance(string name)
        {
            if (!cacheInfos.ContainsKey(name))
            {
                return;
            }

            var list = cacheInfos[name];
            foreach (var gameobj in list)
            {
                UIManager.Instance.UICache.FreeTemplate(name, gameobj);
            }
            list.Clear();
        }

        /// <summary>
        /// 释放单独的一个UI缓冲到缓冲池
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public void FreeTemplateInstanceGameObject(string name, GameObject obj)
        {
            if (!cacheInfos.ContainsKey(name))
            {
                return;
            }

            var list = cacheInfos[name];

            if (list.Contains(obj))
            {
                list.Remove(obj);
            }
            else
            {
                GameDebug.LogError("不是UI缓存对象:" + name);
            }

            UIManager.Instance.UICache.FreeTemplate(name, obj);
        }

        /// <summary>
        /// 移除模板
        /// </summary>
        /// <param name="name"></param>
        public void RemoveTemplate(string name)
        {
            if (!cacheInfos.ContainsKey(name))
            {
                return;
            }

            FreeTemplateInstance(name);
            UIManager.Instance.UICache.RemoveTemplate(name);
        }

        public UICacheManager GetUICacheManager()
        {
            return UIManager.Instance.UICache;
        }

        /// <summary>
        /// 获取物品缓冲
        /// </summary>
        /// <returns></returns>
        public GameObject GetItemGameObj(Transform parent)
        {
            var gameobj = UIManager.Instance.UICache.GetItemGameObj(parent);

            cacheItems.Add(gameobj);

            return gameobj;
        }

        /// <summary>
        /// 获取物品缓冲
        /// </summary>
        /// <returns></returns>
        public GameObject GetItemGameObjEx(Transform parent, int sort)
        {
            var gameobj = UIManager.Instance.UICache.GetItemGameObj(parent);

            gameobj.transform.SetSiblingIndex(sort);
            cacheItems.Add(gameobj);

            return gameobj;
        }

        /// <summary>
        /// 释放单个物品图标
        /// </summary>
        /// <param name="obj"></param>
        public void FreeItemGameObj(GameObject obj)
        {
#if UNITY_EDITOR
            if (!cacheItems.Contains(obj))
            {
                GameDebug.LogError("ui base window cache item not contain!!!!");
            }
#endif
            UIManager.Instance.UICache.FreeItemGameObj(obj);
            cacheItems.Remove(obj);
        }

        /// <summary>
        /// 回收所有物品缓冲
        /// </summary>
        public void FreeAllItemGameObj()
        {
            foreach (var gameobj in cacheItems)
            {
                UIManager.Instance.UICache.FreeItemGameObj(gameobj);
            }

            cacheItems.Clear();
        }

        /// <summary>
        /// 回收所有UI缓冲
        /// </summary>
        private void DestroyAllTemplates()
        {
            foreach (string key in cacheInfos.Keys)
            {
                this.RemoveTemplate(key);
            }

            cacheInfos.Clear();
        }
    }
}