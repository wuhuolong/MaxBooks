//************************************
//  File: UIMainCtrl.cs
//  Desc: 用于挂载到相机上的组件并处理协程加载跟下放接口作用
//  Author: Raorui 重构
//  Date: 2017.11.22
//************************************
using SGameEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using xc;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIMainCtrl : MonoBehaviour
    {
        private static Camera mCam;

        /// <summary>
        /// 全屏后处理的相机
        /// </summary>
        private static Camera mPostCamera;

        private Transform mCacheTrans;
        private Transform mHudRoot;//hud节点
        private Transform mNormalRoot;//普通面板节点
        private Transform mLoadingRoot;//Loading节点
        private Transform mPopRoot;//弹出框节点
        private float delay = 0;//资源延迟下载时间，用于模拟下载速度慢的情况

        public Transform HudRoot { get { return mHudRoot; } }
        public Transform NormalRoot { get { return mNormalRoot; } }
        public Transform LoadingRoot { get { return mLoadingRoot; } }
        public Transform PopRoot { get { return mPopRoot; } }
        public EventSystem EventSystemCom;
        public StandaloneInputModule InputModule;
        public const string UIResPrefix = "Assets/Res/UI/Widget/Preset/";
        public const string UIKoreanResPrefix = "Assets/Res/UIKorean/Widget/Preset/";
        public const string UICopyBagResPrefix = "Assets/Res/UI/CopyBag/";
        public const int MainCamMinDepth = 0;
        public const int MainCamMaxDepth = 3300;
        public PrefabResource mCurrencyRes;
        public PrefabResource mProbabilityRes;
        public PrefabResource mRefundRes;

        // Use this for initialization

        public static Camera MainCam
        {
            get { return mCam; }
        }

        public static Camera PostCamera
        {
            get { return mPostCamera; }
        }

        public float Delay
        {
            set { delay = value; }
        }


        private void Start()
        {
            UIManager.Instance.MainCtrl = this;
            UIHelper.InitLoginAllUI();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            mCacheTrans = gameObject.transform;
            mCam = mCacheTrans.Find("UICamera").GetComponent<Camera>();
            mCam.nearClipPlane = MainCamMinDepth;
            mCam.farClipPlane = MainCamMaxDepth;
            int invisible_mask = 1 << LayerMask.NameToLayer("Hide");
            mCam.cullingMask = ~invisible_mask & mCam.cullingMask;

            // 获取后处理的相机组件
            var post_camera_trans = mCacheTrans.Find("PostCamera");
            if(post_camera_trans != null)
                mPostCamera = post_camera_trans.GetComponent<Camera>();

            EventSystemCom = mCacheTrans.Find("EventSystem").GetComponent<EventSystem>();
            InputModule = mCacheTrans.Find("EventSystem").GetComponent<StandaloneInputModule>();
            mHudRoot = mCacheTrans.Find("HudRoot");
            mNormalRoot = mCacheTrans.Find("NormalRoot");
            mLoadingRoot = mCacheTrans.Find("LoadingRoot");
            mPopRoot = mCacheTrans.Find("PopRoot");
        }

        private void LateUpdate()
        {
            //************************************
            // 下发UIManager的Update
            //************************************
        }

        /// <summary>
        /// 加载UI资源
        /// </summary>
        /// <param name="wndName"></param>
        /// <param name="baseWin"></param>
        /// <returns></returns>
        public IEnumerator CreateWindowFromPrefab(string wndName, UIBaseWindow baseWin)
        {
            float start_time = Time.unscaledTime;

            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            bool _reserve_asset = (wndName == UIManager.MainPanelName); // 是否保存ui界面的assetbundle资源

            // 根据窗口类型设置不同的挂点
            UIType type = UIHelper.GetUITypeByWindowName(wndName);
            Transform parent_trans = null;
            switch (type)
            {
                case UIType.Hud:
                    {
                        parent_trans = mHudRoot;
                        break;
                    }
                case UIType.Pop:
                    {
                        parent_trans = mPopRoot;
                        break;
                    }
                case UIType.Normal:
                    {
                        parent_trans = mNormalRoot;
                        break;
                    }
                default:
                    {
                        //只有loading
                        parent_trans = mLoadingRoot;
                        break;
                    }
            }

            // 加载ui界面
            PrefabResource pr = new PrefabResource();
            var res_prefix = UIResPrefix;
            //             if (Const.Language == LanguageType.KOREAN)
            //             {
            //                 res_prefix = UIKoreanResPrefix;
            //             }
#if UNITY_IPHONE
            if (string.IsNullOrEmpty(baseWin.mPrefabName) == false && SDKHelper.GetSDKWinList().Contains(baseWin.mPrefabName))
                res_prefix = UICopyBagResPrefix;
#endif
            if (baseWin.mPrefabName != null)
                yield return StartCoroutine(ResourceLoader.Instance.load_prefab(string.Format("{0}{1}.prefab", res_prefix, baseWin.mPrefabName), pr, false, _reserve_asset, parent_trans));
            else
                yield return StartCoroutine(ResourceLoader.Instance.load_prefab(string.Format("{0}{1}.prefab", res_prefix, wndName), pr, false, _reserve_asset, parent_trans));

            GameObject obj = pr.obj_;
            if (obj == null)
                yield break;

            //设置Canvas组件的参数
            Canvas canvas = obj.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("ui not have canvas " + wndName);
                canvas = obj.AddComponent<Canvas>();
            }

            //canvas.pixelPerfect = true;
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = mCam;
            //canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.None;// AdditionalCanvasShaderChannels.TexCoord1;// | AdditionalCanvasShaderChannels.Tangent;
            canvas.sortingLayerName = "Default";

            // 检查GraphicRaycaster组件
            var ray_caster = obj.GetComponent<GraphicRaycaster>();
            if (ray_caster == null)
            {
                Debug.LogError("ui not have canvas raycaster " + wndName);
                obj.AddComponent<GraphicRaycaster>();
            }

            // 设置CanvasScaler组件的参数
            var canvas_scaler = obj.GetComponent<CanvasScaler>();
            if (canvas_scaler == null)
            {
                Debug.LogError("ui not have canvas scalar " + wndName);
                canvas_scaler = obj.AddComponent<CanvasScaler>();
            }

            canvas_scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas_scaler.referencePixelsPerUnit = 100;
            float currency_scale = 1;
            currency_scale = canvas_scaler.referenceResolution.x / 1920;
            if (canvas_scaler.referenceResolution.x != 1920 && canvas_scaler.referenceResolution.x != 1334)
                canvas_scaler.referenceResolution = new Vector2(1280, 720);
            if(Screen.width/(float)Screen.height > 1.778f)
                canvas_scaler.matchWidthOrHeight = 1;
            else
                canvas_scaler.matchWidthOrHeight = 0;
            baseWin.CurrencyScale = currency_scale;

            // 设置界面的外部参数
            string param1_str = "";
            if(baseWin.ShowParam != null && baseWin.ShowParam.Length > 0 && baseWin.ShowParam[0] != null)
                param1_str = baseWin.ShowParam[0].ToString();
            baseWin.Param1_str = param1_str;

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            if(!obj.activeSelf)
                obj.SetActive(true);
            obj.name = obj.name.Replace("(Clone)", "");
            baseWin.mUIObject = obj;
            //从ui加载出来的原始prefab有标志Atlas资源是否可以被回收的作用，不能删除,详见host_res_to_gameobj的代码
            //GameObject.Destroy(obj);

            float cost_time = Time.unscaledTime - start_time;

            // 创建界面的货币栏
            if (mCurrencyRes == null)
            {
                mCurrencyRes = new PrefabResource();
                yield return StartCoroutine(ResourceLoader.Instance.load_prefab("Assets/Res/UI/Widget/Preset/UICurrencyWindow.prefab", mCurrencyRes, true));
                if (mCurrencyRes.obj_ == null)
                    yield break;

                mCurrencyRes.obj_.SetActive(false);
            }
            CreateAndCheckMoneyBar(baseWin, obj, wndName, currency_scale, true);

            if (Const.Region == RegionType.KOREA)
            {
                //创建概率展示按钮
                if (mProbabilityRes == null)
                {
                    mProbabilityRes = new PrefabResource();
                    yield return StartCoroutine(ResourceLoader.Instance.load_prefab(
                        "Assets/Res/UI/Widget/Preset/UIProbabilityPublish.prefab", mProbabilityRes, true));
                    if (mProbabilityRes.obj_ == null)
                        yield break;
                    mProbabilityRes.obj_.SetActive(false);
                }
                CreateAndCheckProbabilityBtn(baseWin, obj, wndName, currency_scale, true);

                //创建七日退款按钮
                if (mRefundRes == null)
                {
                    mRefundRes = new PrefabResource();
                    yield return StartCoroutine(ResourceLoader.Instance.load_prefab(
                        "Assets/Res/UI/Widget/Preset/UIPolicyStatement.prefab", mRefundRes, true));
                    if (mRefundRes.obj_ == null)
                        yield break;
                    mRefundRes.obj_.SetActive(false);
                }
                CreateAndCheckRefundBtn(baseWin, obj, wndName, currency_scale, true);
            }

            //Debug.LogError("load window " + wndName + " cost: " + cost_time);
            xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.FireEvent(ClientEventType.ugui.UICoreEvent.UILOADDONE, new xc.ClientEventBaseArgs(baseWin));
        }

        public void CreateAndCheckMoneyBar(UIBaseWindow baseWin, GameObject parentGo, string windName, float scale, bool is_force_update)
        {
            if (baseWin == null)
                return;
            string param1_str = "";
            if (baseWin.ShowParam != null && baseWin.ShowParam.Length > 0 && baseWin.ShowParam[0] != null)
                param1_str = baseWin.ShowParam[0].ToString();
            if (is_force_update || (baseWin.Param1_str != param1_str))
            {
                baseWin.Param1_str = param1_str;
                if (baseWin.MoneyBarObj != null)
                    GameObject.DestroyImmediate(baseWin.MoneyBarObj);
                baseWin.MoneyBarObj = UIWidgetHelp.Instance.CreateAndCheckMoneyBar(parentGo, windName, scale, param1_str);
            }
        }

        public void CreateAndCheckProbabilityBtn(UIBaseWindow baseWin, GameObject parentGo, string windName,
            float scale, bool is_force_update)
        {
            if (Const.Region != RegionType.KOREA)
                return;
            if (baseWin == null)
                return;
            string param1_str = "";
            if (baseWin.ShowParam != null && baseWin.ShowParam.Length > 0 && baseWin.ShowParam[0] != null)
                param1_str = baseWin.ShowParam[0].ToString();
            if (is_force_update || (baseWin.Param1_str != param1_str))
            {
                baseWin.Param1_str = param1_str;
                if (baseWin.ProbabilityBtnObj != null)
                    GameObject.DestroyImmediate(baseWin.ProbabilityBtnObj);
                baseWin.ProbabilityBtnObj =
                    UIWidgetHelp.Instance.CreateAndCheckProbabilityBtn(parentGo, windName, scale, param1_str);
            }
        }

        public void CreateAndCheckRefundBtn(UIBaseWindow baseWin, GameObject parentGo, string windName,
            float scale, bool is_force_update)
        {
            if (Const.Region != RegionType.KOREA)
                return;
            if (baseWin == null)
                return;
            string param1_str = "";
            if (baseWin.ShowParam != null && baseWin.ShowParam.Length > 0 && baseWin.ShowParam[0] != null)
                param1_str = baseWin.ShowParam[0].ToString();
            if (is_force_update || (baseWin.Param1_str != param1_str))
            {
                baseWin.Param1_str = param1_str;
                if (baseWin.RefundBtnObj != null)
                    GameObject.DestroyImmediate(baseWin.RefundBtnObj);
                baseWin.RefundBtnObj =
                    UIWidgetHelp.Instance.CreateAndCheckRefundBtn(parentGo, windName, scale, param1_str);
            }
        }

        /// <summary>
        /// 删除所有子窗口的资源
        /// </summary>
        public void ClearAllChildWindow()
        {
            // hud窗口
            Transform child_trans;
            int child_count = mHudRoot.childCount;
            for (int i = 0; i < child_count; ++i)
            {
                child_trans = mHudRoot.GetChild(0);
                UnityEngine.GameObject.DestroyImmediate(child_trans.gameObject);
            }

            // 普通窗口
            child_count = mNormalRoot.childCount;
            for (int i = 0; i < child_count; ++i)
            {
                child_trans = mNormalRoot.GetChild(0);
                UnityEngine.GameObject.DestroyImmediate(child_trans.gameObject);
            }

            // 弹出窗口
            child_count = mPopRoot.childCount;
            for (int i = 0; i < child_count; ++i)
            {
                child_trans = mPopRoot.GetChild(0);
                UnityEngine.GameObject.DestroyImmediate(child_trans.gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            StopCoroutine("CreateWindowFromPrefab");
        }

        private void OnDestroy()
        {
            StopCoroutine("CreateWindowFromPrefab");
        }
    }
}