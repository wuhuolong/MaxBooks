using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using xc.ui;
using SGameEngine;
using Utils;
using xc.ui.ugui;
using System;

namespace xc
{
    namespace ui
    {
        [DisallowMultipleComponent]
        [wxb.Hotfix]
        public class UIItemNewSlot : MonoBehaviour
        {
            private const string DISCOUNT_IMAGE_NAME_PREFIX = "Mainwindow@Discount_";
            public static bool m_is_load_effectIcon = false;
            private static uint m_effectIcon_frame_count;
            private static float m_effectIcon_frame_width;
            private static float m_effectIcon_frame_height;
            private static float m_effectIcon_frame_rect_x;
            private static float m_effectIcon_frame_rect_y;
            private static uint m_effectIcon_frame_col_num;
            private static float m_effectIcon_frame_interval;
            private static bool m_effectIcon_frame_is_loop;
            private static uint m_effectIcon_frame_start_frame;
            public const uint GOODS_ID_EXP_JADE = 20060;    //经验玉的物品ID
            public static void InitEffectIconParam()
            {
                if (m_is_load_effectIcon)
                    return;
                m_is_load_effectIcon = true;
                m_effectIcon_frame_count = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_COUNT");
                m_effectIcon_frame_width = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_WIDTH");
                m_effectIcon_frame_height = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_HEIGHT");
                m_effectIcon_frame_rect_x = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_RECT_X");
                m_effectIcon_frame_rect_y = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_RECT_Y");
                m_effectIcon_frame_col_num = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_COL_NUM");
                m_effectIcon_frame_interval = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_INTERVAL");
                m_effectIcon_frame_is_loop = GameConstHelper.GetString("GAME_GOODS_EFFECT_ICON_FRAME_IS_LOOP") == "1";
                m_effectIcon_frame_start_frame = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_START_FRAME");
            }


            public Goods ItemInfo;
            public GameObject SelectWid { get; set; }
            public int mShowType { get; set; } //0不显示 1显示背包内属性 2tips属性
            RawImage mUITexture;
            UGUIFrameAnimation mUITexture_frameAnim;    //帧动画组件
            public Material mTextureMaterial = null;
            public GameObject mBindObj { get; set; }
            public Image mEquippedSprite { get; set; }
            public delegate void OnClickCustomFunc(System.Object obj, UIItemNewSlot item);
            public delegate void OnClickFunc(Goods goods);

            /// <summary>
            /// 是否显示背景框
            /// </summary>
            public bool m_IsFrameSprShow = true;

            /// <summary>
            /// 是否显示圆形背景框
            /// </summary>
            public bool m_IsCircleBkgShow = false;


            /// <summary>
            /// 是否可以显示圆形的背景（默认是不显示）
            /// </summary>
            private bool m_CanShowCircleBkg = false;

            /// <summary>
            /// 是否显示对应的品质框
            /// </summary>
            public bool m_IsQualitySprShow = true;


            public UIItemNewSlot ReplaceItemPrefab(float scale, bool newInstance = true)
            {
                var itemObj = this.ReplaceItemPrefab(newInstance);

                var slotRect = itemObj.GetComponent<RectTransform>();
                slotRect.localScale = new Vector3(scale, scale, scale);

                return itemObj;
            }

            public UIItemNewSlot ReplaceItemPrefab(RectTransform rectTrans, bool newInstance = true)
            {
                var itemObj = this.ReplaceItemPrefab(newInstance);

                var slotRect = itemObj.GetComponent<RectTransform>();
                slotRect.localScale = rectTrans.localScale;

                return itemObj;
            }



            /// <summary>
            /// 替换prefab,返回一个新的对象,并设置在当前位置，设置当前gameobject为false,设置新返回的对象为true
            /// </summary>
            public UIItemNewSlot ReplaceItemPrefab(bool newInstace = true)
            {
                // 设置旧的物品框不参与Layout计算
                var layout_element = gameObject.GetComponent<LayoutElement>();
                if (layout_element == null)
                    layout_element = gameObject.AddComponent<LayoutElement>();
                layout_element.ignoreLayout = true;

                RectTransform rect = this.GetComponent<RectTransform>();
                var cache_trans = this.transform;

                GameObject obj = UIManager.Instance.UICache.GetItemGameObj(cache_trans.parent, newInstace);

                var slot = UIItemNewSlot.Bind(obj, TargetPanel, ClipPanel);

                //obj.transform.SetParent(cache_trans.parent, false);
                obj.transform.SetSiblingIndex(cache_trans.GetSiblingIndex());

                RectTransform slotRect = slot.GetComponent<RectTransform>();

                slotRect.sizeDelta = rect.sizeDelta;

                slotRect.pivot = rect.pivot;
                slotRect.localPosition = rect.localPosition;
                slotRect.localRotation = rect.localRotation;
                slotRect.localScale = rect.localScale;
                slotRect.localEulerAngles = rect.localEulerAngles;
                slotRect.anchorMin = rect.anchorMin;
                slotRect.anchorMax = rect.anchorMax;
                slotRect.anchoredPosition = rect.anchoredPosition;
                slotRect.anchoredPosition3D = rect.anchoredPosition3D;
                slotRect.sizeDelta = rect.sizeDelta;

                CommonTool.SetActive(this.gameObject, false);

                slot.gameObject.name = this.gameObject.name;
                this.gameObject.name = this.gameObject.name + "_old";
                slot.Clear();//清空数据
                CommonTool.SetActive(slot.gameObject, true);
                return slot;
            }

            public delegate void OnClickFunc1(Goods goods, int num);
            public delegate void OnClickFunc2(Goods goods, UIItemNewSlot item);

            private bool mUseDoubleClick = false;
            private Action<UIItemNewSlot> mDoubleClickCallback = null;
            private Action<UIItemNewSlot> mSingleClickCallback = null;
            private float mSingleClickDelay = 0.3f;
            private float mSingleClickCounter = 0;
            private int mDoubleClickCount = -1;

            public OnClickCustomFunc mCustomFunc;
            public OnClickFunc mFunc;
            public OnClickFunc1 mFunc1;
            public OnClickFunc2 mFunc2;
            public OnClickFunc2 mCuntFunc;
            private int mOtherNum = 0;
            private uint mGrade = 0;
            public Image mFrameSpr { get; set; }
            public Image mCircleBkg { get; set; }   //圆形背景
            private GameObject mQualityObject = null; // 物品品质框
            private Image mQualityImage = null; // 品质框的Image
            private SpriteArray mQualityArray = null; // 品质框的Sprite列表
            private Image mEquipUpSpr;
            private Image mEquipDownSpr;
            private Image mDisEnableSpr;
            private System.Object mParam;
            private Text mNum;
            public bool IsShowTips = true;
            private Texture mTextureObj = null;
            public Vector3 ForceTipsPosition = Vector3.one;
            public bool NeedForceSetTipsPosition { get; set; }
            public RawImage mCdtex { get; set; }//因为ab序列化原因暂时不用
            private Image mCdtexSpr;
            public bool is_CD = false;
            private float DetalTime = 0;
            private float NowFill = 0;
            private float Times = 0;

            private bool mIsCostItem = false;    //是否是消耗物品(资源消耗，坐骑，守护)
            private bool mIsCostItemNoGrey = false; //不变灰的消耗物品（合成）
            bool mHasGoodsGetWay = false; //是否有获取途径
            //注：mIsCostItem 和 mIsCostItemNoGrey ; 最多只能有一个是 true
            private uint mNeedNum = 0;
            private GameObject NoNum;

            private string CurrentWindow = string.Empty;
            private int CurrentWindowDepth = 50;
            private Button ItemButton;
            private bool isClear = false;

            private uint StartCd = 0;
            private uint EndCd = 0;
            private uint GoodsIcon = 0xffffffff;
            //private uint GoodsColor = 0;
            private GameObject mExpiredObj;
            private SGameEngine.AssetResource mAssetRes = null;

            private bool SupportPressDown = false;//是否支持长按

            private bool isShowCd = false;

            GameObject EffectRoot;
            [Header("面板canvas")]
            public Canvas TargetPanel;
            [Header("裁剪区域：（只有ScrollView 滑动区域需要裁剪）")]
            public RectTransform ClipPanel;

            private bool isListenersInit = false;

            List<GameObject> LegendAttrs = new List<GameObject>();
            Dictionary<uint, GameObject> Effects = new Dictionary<uint, GameObject>();
            private GameObject mExpJadeEffect;  //经验玉特效

            public GameObject RealGameobj { get; set; }
            private ComTouchPress PressCom;

            public SGameEngine.PrefabResource GoodsItemPr = new SGameEngine.PrefabResource();

            private Text mTitleDesc;
            private RenderqueueComponent EffectCom;

            // 品质特效的相关组件
            GameObject mQualityEffect = null; 
            RawImage mQualityTex = null;
            TextureArray mQualityTexArray = null;

            // 第二层品质特效的相关组件
            GameObject mQualityEffect2 = null;
            RawImage mQualityTex2 = null;
            TextureArray mQualityTexArray2 = null;

            private uint mVocation = 0; //所属的玩家职业（0是主角）
            private uint mPlayerLv = 0; //所属的玩家等级（0是主角的等级）

            private bool mCanNotUse = false; //物品不可用的,true 显示不可以图标，false进行其他可用性检测

            private bool mShowNeedNum = true;    //是否显示拥有的个数（默认显示）
            private bool mShowZeroNum = false;  // 当个数为0时，是否显示（默认不显示）
            private GameObject mCheckImage; //勾选图标
            private bool mShowCheckImage = false;   //是否显示勾选图标

            private GameObject mExpireTimeObj = null;  //已过期
            private GameObject mFashionBg = null;  //时装
            private bool mShowExpireTime = false;   //是否显示“已过期”

            private Text mEquipLvStepText = null;   //装备阶数文本

            private SpriteList mSpriteList = null;  //动态加载的sprite
            private GameObject mDiscount = null;    //折扣
            private Image mDiscountImage = null;    //折扣图片

            private GameObject mOverdueNotice = null; //即将过期

            public struct TypeParse
            {
                public int _mType;
                public int _mNum;
                public uint _mGrade;
                public OnClickFunc _mFunc;
                public OnClickFunc1 _mFunc1;
                public OnClickFunc2 _mFunc2;
                public OnClickCustomFunc _mCustomFunc;
                public System.Object _mParam;
            }


            /// <summary>
            /// 设置双击回调，单击的话一段时间不点击回调单击回调
            /// </summary>
            /// <param name="doubleClickCallback"></param>
            /// <param name="singleClickCallback"></param>
            /// <param name="useDoubleClick"></param>
            /// <param name="delay"></param>
            /// <param name="showTips"></param>
            public void SetDoubleClick(Action<UIItemNewSlot> doubleClickCallback, Action<UIItemNewSlot> singleClickCallback, bool useDoubleClick, float delay = 0.3f)
            {
                this.mUseDoubleClick = useDoubleClick;
                this.mSingleClickDelay = delay;
                this.mDoubleClickCallback = doubleClickCallback;
                this.mSingleClickCallback = singleClickCallback;
                this.mSingleClickCounter = 0f;
            }

            public TypeParse _mTypeParse;

            /// <summary>
            /// 对象绑定方法
            /// </summary>
            /// <param name="obj"></param>
            public static UIItemNewSlot Bind(GameObject obj, Canvas canvas = null, RectTransform clipPanel = null)
            {
                var slot = obj.GetComponent<UIItemNewSlot>();
                if(slot == null)
                    slot = obj.AddComponent<UIItemNewSlot>();

                slot.TargetPanel = canvas;
                slot.ClipPanel = clipPanel;

                return slot;

            }
            
            /// <summary>
            /// 替换prefab,返回一个新的对象,并设置在当前位置，设置当前gameobject为false,设置新返回的对象为true
            /// </summary>
            public static UIItemNewSlot ReplaceItemPrefab_static(GameObject re_obj, Canvas canvas = null, RectTransform clipPanel = null, bool newInstace = true)
            {

                RectTransform rect = re_obj.GetComponent<RectTransform>();

                GameObject obj = UIManager.Instance.UICache.GetItemGameObj(re_obj.transform.parent, newInstace);

                var slot = UIItemNewSlot.Bind(obj, canvas, clipPanel);

                //obj.transform.SetParent(re_obj.transform.parent, false);
                obj.transform.SetSiblingIndex(re_obj.transform.GetSiblingIndex());

                RectTransform slotRect = slot.GetComponent<RectTransform>();

                slotRect.pivot = rect.pivot;
                slotRect.localPosition = rect.localPosition;
                slotRect.localRotation = rect.localRotation;
                slotRect.localScale = rect.localScale;
                slotRect.localEulerAngles = rect.localEulerAngles;
                slotRect.anchorMin = rect.anchorMin;
                slotRect.anchorMax = rect.anchorMax;
                slotRect.anchoredPosition = rect.anchoredPosition;
                slotRect.anchoredPosition3D = rect.anchoredPosition3D;
                slotRect.sizeDelta = rect.sizeDelta;

                slot.gameObject.name = re_obj.name;
                GameObject.DestroyImmediate(re_obj);

                slot.Clear();
                CommonTool.SetActive(slot.gameObject, true);
                return slot;
            }

            /// <summary>
            /// 替换prefab,返回一个新的对象,并设置在当前位置，设置当前gameobject为false,设置新返回的对象为true(使用内存池)
            /// </summary>
            public static UIItemNewSlot ReplaceItemUseCache(GameObject re_obj, UIBaseWindow wnd, Canvas canvas = null, RectTransform clipPanel = null)
            {
                if (wnd == null || re_obj == null)
                    return null;

                RectTransform rect = re_obj.GetComponent<RectTransform>();

                GameObject obj = wnd.GetItemGameObj(re_obj.transform.parent);

                var slot = UIItemNewSlot.Bind(obj, canvas, clipPanel);
                obj.transform.SetSiblingIndex(re_obj.transform.GetSiblingIndex());

                RectTransform slotRect = slot.GetComponent<RectTransform>();

                slotRect.pivot = rect.pivot;
                slotRect.localPosition = rect.localPosition;
                slotRect.localRotation = rect.localRotation;
                slotRect.localScale = rect.localScale;
                slotRect.localEulerAngles = rect.localEulerAngles;
                slotRect.anchorMin = rect.anchorMin;
                slotRect.anchorMax = rect.anchorMax;
                slotRect.anchoredPosition = rect.anchoredPosition;
                slotRect.anchoredPosition3D = rect.anchoredPosition3D;
                slotRect.sizeDelta = rect.sizeDelta;

                slot.gameObject.name = re_obj.name;
                GameObject.DestroyImmediate(re_obj);

                slot.Clear();
                CommonTool.SetActive(slot.gameObject, true);
                return slot;
            }

            /// <summary>
            /// 销毁图标贴图资源
            /// </summary>
            private void DestroyAssetRes()
            {
                if (mAssetRes != null)
                {
                    mAssetRes.destroy();
                    mAssetRes = null;
                }
            }

            public void Dispose()
            {

                SetDoubleClick(null, null, false, 0.3f);

                this.Clear();
                this.RemoveListeners();

                DestroyAssetRes();

                /*if (UIManager.Instance.MainCtrl != null)
                {
                    ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("ShowAsync");
                }*/
            }

            //清除icon显示空格子
            public void Clear()
            {
                if (RealGameobj == null)
                {
                    Check();
                }
                if (mUITexture != null)
                {
                    mUITexture.texture = null;
                    CommonTool.SetActive(mUITexture.gameObject, false);
                    isClear = true;
                }

                if (mUITexture_frameAnim != null)
                    mUITexture_frameAnim.enabled = false;
                    
                // 设置品质框
                bool HasNull = false;

                if(mQualityObject != null )
                    mQualityObject.SetActive(false);
                m_IsQualitySprShow = true;

                if (mNum != null)
                {
                    mNum.text = "";
                }

                if (mNum != null)
                {
                    CommonTool.SetActive(mNum.gameObject, true);
                }

                if (mEquipUpSpr != null)
                {
                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                }

                if (mEquipDownSpr != null)
                {
                    CommonTool.SetActive(mEquipDownSpr.gameObject,false);
                }

                if (mDisEnableSpr != null)
                {
                    CommonTool.SetActive(mDisEnableSpr.gameObject, false);
                }

                CommonTool.SetActive(mExpiredObj,false);
                CommonTool.SetActive(mFashionBg,false);

                GoodsIcon = 0xffffffff;
                //GoodsColor = 0;

                CommonTool.SetActive(mBindObj,false);

                if (mEquippedSprite != null)
                    CommonTool.SetActive(mEquippedSprite.gameObject,false);

                CommonTool.SetActive(SelectWid, false);

                if (mCdtexSpr != null)
                {
                    CommonTool.SetActive(mCdtexSpr.gameObject, false);
                }
    
                HasNull = false;
                for (int i = 0; i < LegendAttrs.Count; i++)
                {
                    CommonTool.SetActive(LegendAttrs[i], false);
                    HasNull = true;
                }

                if (HasNull)
                    LegendAttrs.Clear();

                HasNull = false;
                foreach (var kv in Effects)
                {
                    CommonTool.SetActive(kv.Value, false);
                    HasNull = true;
                }

                if (HasNull)
                    Effects.Clear();

                CommonTool.SetActive(mExpJadeEffect, false);

                CommonTool.SetActive(mQualityEffect, false);

                CommonTool.SetActive(mQualityEffect2, false);

                CommonTool.SetActive(EffectRoot, true);

                ItemInfo = null;
                mOtherNum = 0;
                mShowType = 0;
                IsShowTips = true;
                mFunc = null;
                mFunc1 = null;
                mFunc2 = null;
                mCustomFunc = null;
                mGrade = 0;
                mParam = null;
                is_CD = false;
                DetalTime = 0;
                StartCd = 0;
                EndCd = 0;
                Times = 0;
                NowFill = 0;
                mNeedNum = 0;
                SupportPressDown = false;
                mTextureObj = null;

                mIsCostItem = false;
                mIsCostItemNoGrey = false;
                CommonTool.SetActive(NoNum, false);
                
                if (EffectRoot != null)
                {
                    CommonTool.SetActive(EffectRoot.gameObject, true);
                }

                // 设置背景框
                if (mFrameSpr != null)
                {
                    CommonTool.SetActive(mFrameSpr.gameObject,true);
                }

                m_IsCircleBkgShow = false;

                m_CanShowCircleBkg = false;

                if (mCircleBkg != null)
                {
                    CommonTool.SetActive(mCircleBkg.gameObject, false);
                }

                m_IsFrameSprShow = true;

                // 还原Material
                if (mTextureMaterial != null)
                {
                    if(mUITexture != null)
                        mUITexture.material = mTextureMaterial;

                    if(mQualityImage != null)
                        mQualityImage.material = mTextureMaterial;

                    mTextureMaterial = null;
                }

                // 恢复为彩色
                if (mUITexture != null && mUITexture.material != null)
                {
                    mUITexture.material.SetFloat("_Grey", 1);
                }

                if (mQualityImage != null && mQualityImage.material != null)
                {
                    mQualityImage.material.SetFloat("_Grey", 1);
                }

                if (mEquipUpSpr != null)
                {
                    mEquipUpSpr.color = Color.white;
                }

                if (mEquipDownSpr != null)
                {
                    mEquipDownSpr.color = Color.white;
                }

                mVocation = 0; //所属的玩家职业（0是主角）
                mPlayerLv = 0; //所属的玩家等级（0是主角的等级）

                mShowNeedNum = true;
                mShowZeroNum = false;
                mShowCheckImage = false;
                CommonTool.SetActive(mCheckImage, false);
                CommonTool.SetActive(mExpireTimeObj, false);
                mShowExpireTime = false;
                mHasGoodsGetWay = false;

                CommonTool.SetActive(mDiscount, false);
                CommonTool.SetActive(mOverdueNotice, false);

                if(mEquipLvStepText != null)
                    CommonTool.SetActive(mEquipLvStepText.gameObject, false);

                if (mUITexture != null && mUITexture.enabled)
                    mUITexture.enabled = false;
        }

            public void SetNumLabelText(string tx)
            {
                if (mNum != null)
                {
                    mNum.text = tx;
                }
            }

            public void SetNumLabelText(ulong tx)
            {
                if (mNum != null)
                {
                    // 为避免数字超出物品框边界，当数量大于1千万少于1亿的时候使用0位小数点，其他情况使用1位小数点
                    uint decimalPlaces = 1;
                    if (tx > 10000499 && tx < 100000000)
                    {
                        decimalPlaces = 0;
                    }
                    mNum.text = UIWidgetHelp.GetLargeNumberString(tx, decimalPlaces);
                }
            }

            public void CutBtnInit(OnClickFunc2 func)
            {
                mCuntFunc = func;
            }

            public void IsSupportDown(bool isSupport)
            {
                SupportPressDown = isSupport;
                if (PressCom != null)
                    PressCom.SupportPressDown = SupportPressDown;
            }
            

            public void GoodsTexturePixelPerfect()
            {
                if (mUITexture != null)
                    mUITexture.SetNativeSize();
            }

            public void SetShowCdImage(bool isShow)
            {
                isShowCd = isShow;
            }

            public void SetGreyTexture(bool state)
            {
                if (mUITexture != null)
                {
                    if (state)
                    {
                        //mUITexture.shader = Shader.Find("Custom/GrayTexture");

                    }
                    else
                    {
                        // mUITexture.shader = Shader.Find("Unlit/Transparent Colored");
                    }
                }
            }

            public void DisableClick()
            {
                var collider = GetComponent<Collider>();
                collider.enabled = false;
            }

            private IEnumerator ShowAsync(uint icon)
            {
                isClear = false;

                var assetRes = new SGameEngine.AssetResource();

                DBGoodsVocationIcon db_vocation_icon = DBManager.Instance.GetDB<DBGoodsVocationIcon>();
                DBGoodsVocationIcon.DBGoodsVocationIconItem vocation_icon_item = db_vocation_icon.GetOneInfo(icon);
                if(vocation_icon_item != null)
                {
                    icon = vocation_icon_item.GetIconId(LocalPlayerManager.Instance.LocalActorAttribute.Vocation);
                    GoodsIcon = icon;
                }

                DBGoodsEffectIcon db_effect_icon = DBManager.Instance.GetDB<DBGoodsEffectIcon>();
                DBGoodsEffectIcon.DBGoodsEffectIconItem icon_item_tmpl = db_effect_icon.GetOneInfo(icon);
                bool is_effect_icon = false;
                IconInfo info = null;

                if (icon_item_tmpl != null)//属于特效资源，不走普通图标那套
                {
                    is_effect_icon = true;
                    string find_path = icon_item_tmpl.EffectImagePath;
                    if (SGameEngine.ResourceLoader.Instance.is_exist_asset(find_path) == false)
                        find_path = "Assets/" + ResPath.Effect_ui_default_soul;

                    yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(find_path, typeof(Texture), assetRes));

                    // TODO 特效资源的检查
                    if(mIsDestroy)
                    {
                        assetRes.destroy();
                        yield break;
                    }

                    DestroyAssetRes(); // 需要先销毁旧的图片资源
                    mAssetRes = assetRes;
                }
                else
                {
                  
                    info = GoodsHelper.GetIconInfo(icon);
                    if(info == null)
                    {
                        yield break;
                    }

                    yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(info.MainTexturePath, typeof(Texture), assetRes));

                    // 如果加载完的icon id已经不正确了，则舍弃
                    if (GoodsIcon != icon || mIsDestroy)
                    {
                        assetRes.destroy();
                        yield break;
                    }

                    DestroyAssetRes(); // 需要先销毁旧的图片资源
                    mAssetRes = assetRes;
                }
                
                if (mUITexture == null)
                    yield break;

                if (isClear)
                {
                    if (mUITexture != null)
                    {
                        mUITexture.texture = null;
                        CommonTool.SetActive(mUITexture.gameObject, false);
                    }
                }
                else
                {
                    if (ItemInfo == null)
                    {
                        mTextureObj = null;
                        if (mUITexture != null)
                        {
                            mUITexture.texture = null;
                        }

                    }
                    else
                    {
                        if (mAssetRes == null || mAssetRes.asset_ == null)
                            yield break;

                        mTextureObj = mAssetRes.asset_ as Texture;
                        if (mUITexture != null)
                        {
                            mUITexture.texture = mTextureObj;
                            if (is_effect_icon)
                            {
                                InitEffectIconParam();
                                if (mUITexture_frameAnim == null && mUITexture != null)
                                    mUITexture_frameAnim = mUITexture.gameObject.AddComponent<UGUIFrameAnimation>();
                                if (mUITexture_frameAnim != null)
                                {
                                    mUITexture_frameAnim.FrameCount = m_effectIcon_frame_count;
                                    mUITexture_frameAnim.OneFrameWidth = m_effectIcon_frame_width;
                                    mUITexture_frameAnim.OneFrameHeight = m_effectIcon_frame_height;
                                    mUITexture_frameAnim.RectXSpace = m_effectIcon_frame_rect_x;
                                    mUITexture_frameAnim.RectYSpace = m_effectIcon_frame_rect_y;
                                    mUITexture_frameAnim.ColNum = m_effectIcon_frame_col_num;
                                    mUITexture_frameAnim.FrameInterval = m_effectIcon_frame_interval;
                                    mUITexture_frameAnim.IsLoop = m_effectIcon_frame_is_loop;
                                    mUITexture_frameAnim.StartFrame = m_effectIcon_frame_start_frame;
                                    mUITexture_frameAnim.enabled = true;
                                    mUITexture_frameAnim.InitFrame(0);
                                }
                                mUITexture.rectTransform.sizeDelta = new Vector2(55, 55);
                            }
                            else
                            {
                                if (mUITexture_frameAnim != null)
                                    mUITexture_frameAnim.enabled = false;
                                if (info != null)
                                    mUITexture.uvRect = info.IconRect;
                                mUITexture.rectTransform.sizeDelta = new Vector2(80, 80);
                            }

                            CommonTool.SetActive(mUITexture.gameObject, true);
                            if (mUITexture.enabled == false)
                                mUITexture.enabled = true;
                        }
                    }

                }
            }

            void CheckCdTime()
            {
                NowFill = 0;
                Times = 0;

                if (mCdtexSpr != null && ItemInfo != null && isShowCd)
                {
                    uint startTime = 0;
                    if (ItemManager.Instance.GoodsCd.TryGetValue(ItemInfo.cd_id, out startTime))
                    {
                        StartCd = startTime;
                        uint cd = 10;
                        var goods_info = GoodsHelper.GetGoodsInfo(ItemInfo.type_idx);
                        if (goods_info != null)
                            cd = goods_info.use_cd;

                        EndCd = StartCd + cd;
                        if (EndCd != 0)
                        {
                            uint serverTime = Game.GetInstance().ServerTime;
                            if (EndCd > serverTime && serverTime >= StartCd)
                            {
                                uint detal = EndCd - StartCd;
                                uint star_detal = serverTime - StartCd;
                                DetalTime = (float)detal;
                                CommonTool.SetActive(mCdtexSpr.gameObject, true);
                                float _time = (float)star_detal / (float)detal;
                                NowFill = 1 - _time;
                                mCdtexSpr.fillAmount = NowFill;
                                is_CD = true;
                            }
                            else
                            {
                                is_CD = false;
                                CommonTool.SetActive(mCdtexSpr.gameObject, false);
                                mCdtexSpr.fillAmount = 0;
                            }
                        }
                    }
                }
            }

            public void SetUI()
            {
                Check();
                OnBagUpdate(null);
                CommonTool.SetActive(SelectWid, false);
                if (ItemInfo == null)
                    return;

                CheckCdTime();
                if (GoodsIcon != ItemInfo.icon_id)
                {
                    GoodsIcon = ItemInfo.icon_id;
                    RefreshCircleBkgVisiable();
                    ui.ugui.UIManager.Instance.MainCtrl.StartCoroutine(ShowAsync(ItemInfo.icon_id));
                }

                foreach (var kv in Effects)
                {
                    CommonTool.SetActive(kv.Value, false);
                }

                CommonTool.SetActive(mExpJadeEffect, false);

                if (ItemInfo.color_type >= GameConst.QUAL_COLOR_PURPLE)
                {
                    if (mQualityTexArray != null && mQualityTex != null)
                    {
                        var tex = mQualityTexArray.LoadTexture((int)(ItemInfo.color_type - 1));
                        if (mQualityTex.texture != tex)
                            mQualityTex.texture = tex;
                    }

                    CommonTool.SetActive(mQualityEffect, true);
                }
                else
                    CommonTool.SetActive(mQualityEffect, false);

                CommonTool.SetActive(mQualityEffect2, false);

                if (mNum != null)
                {
                    if(mIsCostItem == false)
                    {
                        if (ItemInfo.num > 1)
                        {
                            // 为避免数字超出物品框边界，当数量大于1千万少于1亿的时候使用0位小数点，其他情况使用1位小数点
                            uint decimalPlaces = 1;
                            if (ItemInfo.num > 10000499 && ItemInfo.num < 100000000)
                            {
                                decimalPlaces = 0;
                            }
                            mNum.text = "" + UIWidgetHelp.GetLargeNumberString(ItemInfo.num, decimalPlaces);
                        }
                        else
                        {
                            mNum.text = "";
                        }
                    }
                    else
                    {
                        RefreshCost();
                    }
                }

                if (ItemInfo.bind == 0)
                    CommonTool.SetActive(mBindObj, false);
                else
                    CommonTool.SetActive(mBindObj, true);

                if (mEquippedSprite != null)
                {
                    if (ItemManager.Instance.InstallEquip.ContainsKey(ItemInfo.id))
                    {
                        CommonTool.SetActive(mEquippedSprite.gameObject, true);
                    }
                    else
                    {
                        CommonTool.SetActive(mEquippedSprite.gameObject, false);
                    }
                }

                if (ItemInfo.expire_time != 0 && ItemInfo.expire_time < Game.Instance.ServerTime)
                {
                    CommonTool.SetActive(mExpiredObj, true);
                }
                else
                    CommonTool.SetActive(mExpiredObj, false);

                
                if (mDisEnableSpr != null)
                {
                    CommonTool.SetActive(mDisEnableSpr.gameObject, !CheckCanUse());
                }

                if (mEquipUpSpr != null)
                {
                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                }

                if (mEquipDownSpr != null)
                {
                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                }

                // 设置背景框
                if (mFrameSpr != null)
                {
                    CommonTool.SetActive(mFrameSpr.gameObject, m_IsFrameSprShow);
                }

                if (mCircleBkg != null)
                    CommonTool.SetActive(mCircleBkg.gameObject, m_IsCircleBkgShow);

                // 设置品质框
                if(m_IsQualitySprShow && mQualityImage != null)
                {
                    int index = (int)ItemInfo.color_type;
                    var quality_sp_name = "MainWindow_New@Common@GoodsQuality_" + index;
                    var sp = mQualityImage.sprite;
                    if (sp == null || sp.name != quality_sp_name)
                    {
                        if(mQualityArray != null)
                            mQualityImage.sprite = mQualityArray.LoadSprite(quality_sp_name);
                    }
                }
                CommonTool.SetActive(mQualityObject, m_IsQualitySprShow);

                if (ItemInfo is GoodsEquip || ItemInfo is GoodsMagicEquip || ItemInfo is GoodsDecorate)
                {
                    int count;
                    if (ItemInfo is GoodsEquip)
                    {
                        count = Equip.EquipHelper.GetStarAddEquip(ItemInfo as GoodsEquip);
                    }
                    else if (ItemInfo is GoodsDecorate)
                        count = (int)Decorate.DecorateHelper.GetDecorateStar(ItemInfo as GoodsDecorate);

                    else
                        count = (int)(ItemInfo as GoodsMagicEquip).Star;

                    for (int i = 0; i < LegendAttrs.Count; i++)
                    {
                        CommonTool.SetActive(LegendAttrs[i], false);
                    }

                    if (count > LegendAttrs.Count)
                    {
                        count = LegendAttrs.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        CommonTool.SetActive(LegendAttrs[i], true);
                    }
                }
                else
                {
                    for (int i = 0; i < LegendAttrs.Count; i++)
                    {
                        CommonTool.SetActive(LegendAttrs[i], false);
                    }
                }

                mCheckImage = UIHelper.FindChild(transform, "CheckImage");
                CommonTool.SetActive(mCheckImage, mShowCheckImage);

                bool isFashionItem = ItemInfo.main_type == GameConst.GIVE_TYPE_GOODS && ItemInfo.sub_type == GameConst.GIVE_SUB_TYPE_FASHION;
                CommonTool.SetActive(mFashionBg, isFashionItem);

                if (mEquipLvStepText != null)
                {
                    if (ItemInfo != null && (ItemInfo is GoodsEquip))
                    {
                        CommonTool.SetActive(mEquipLvStepText.gameObject, true);
                        uint lvStep = (ItemInfo as GoodsEquip).LvStep;
                        mEquipLvStepText.text = string.Format(xc.DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), lvStep);
                    }
                    else if (ItemInfo != null && ItemInfo is GoodsMountEquip)
                    {
                        CommonTool.SetActive(mEquipLvStepText.gameObject, true);
                        mEquipLvStepText.text = string.Format(xc.DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), (ItemInfo as GoodsMountEquip).lv_step);
                    }
                    else
                    {
                        if (ItemInfo.show_step != 0)
                        {
                            CommonTool.SetActive(mEquipLvStepText.gameObject, true);
                            mEquipLvStepText.text = string.Format(xc.DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), ItemInfo.show_step);
                        }
                        else
                        {
                            CommonTool.SetActive(mEquipLvStepText.gameObject, false);
                        }
                    }
                }

                if(mDiscount != null)
                {
                    if(ItemInfo.discount > 0 && ItemInfo.discount < 10 && mSpriteList != null && mDiscountImage != null)
                    {
                        var sprite = mSpriteList.LoadSprite(DISCOUNT_IMAGE_NAME_PREFIX + ItemInfo.discount);
                        if (sprite != null)
                        {
                            mDiscountImage.sprite = sprite;
                            CommonTool.SetActive(mDiscount, true);
                        }
                        else
                        {
                            CommonTool.SetActive(mDiscount, false);
                        }
                    }else
                    {
                        CommonTool.SetActive(mDiscount, false);
                    }
                }
                RefreshExpireTime();
                RefreshOverdueNotice();

                //lua拓展的特殊逻辑
                if (ItemInfo is GoodsLuaEx)
                {
                    (ItemInfo as GoodsLuaEx).SetItemSlot(gameObject);
                }
            }

            public void RefreshExpireTime()
            {
                if (mExpireTimeObj == null)
                    return;
                if (ItemInfo == null)
                {
                    mShowExpireTime = false;
                }
                else
                {
                    if (ItemInfo.IsInEnableTime())
                    {
                        mShowExpireTime = false;
                    }
                    else
                    {
                        mShowExpireTime = true;
                    }
                }

                CommonTool.SetActive(mExpireTimeObj, mShowExpireTime);
            }

            public void RefreshOverdueNotice()
            {
                if (mOverdueNotice == null)
                    return;

                bool showOverdueNotice = false;
                if (ItemInfo == null)
                {
                    showOverdueNotice = false;
                }
                else
                {
                    if(ItemInfo.expire_time == 0 || ItemInfo.overdue_notice_time == 0)
                    {
                        showOverdueNotice = false;
                    }
                    else
                    {
                        if(ItemInfo.expire_time > Game.Instance.ServerTime && Game.Instance.ServerTime > ItemInfo.expire_time - ItemInfo.overdue_notice_time)
                        {
                            showOverdueNotice = true;
                        }else
                        {
                            showOverdueNotice = false;
                        }
                    }
                }
                CommonTool.SetActive(mOverdueNotice, showOverdueNotice);
            }

            /// <summary>
            /// 设置品质框的显示
            /// </summary>
            /// <param name="isShow"></param>
            public void SetColor(bool isShow)
            {
                if (ItemInfo == null)
                    return;

                CommonTool.SetActive(mQualityObject, isShow);
                m_IsQualitySprShow = isShow;
            }

            public void setItemInfo(uint goodsId, TypeParse parse)
            {
                Goods goods = GoodsFactory.Create(goodsId, null);
                setItemInfo(goods, parse);
            }

            public void setItemInfoByNum(uint goodsId, ulong num, TypeParse parse)
            {
                Goods goods = GoodsFactory.Create(goodsId, null);
                goods.num = num;
                setItemInfo(goods, parse);
            }

            public void setItemInfo(uint goodsId, uint bind, TypeParse parse)
            {
                Goods goods = GoodsFactory.Create(goodsId, null);
                goods.bind = bind;
                setItemInfo(goods, parse);
            }

            public void setItemInfo(Goods itemInfo, TypeParse parse, uint needNum, string windowName, int maxDepth)
            {
                CurrentWindow = windowName;
                CurrentWindowDepth = maxDepth + 1;
                mNeedNum = needNum;
                setItemInfo(itemInfo, parse);
                
            }

            public void setItemInfo(Goods itemInfo, TypeParse parse)
            {
                //                Clear();
                ItemInfo = itemInfo;
                mOtherNum = parse._mNum;
                mShowType = parse._mType;
                mFunc = parse._mFunc;
                mFunc1 = parse._mFunc1;
                mFunc2 = parse._mFunc2;
                mGrade = parse._mGrade;
                mCustomFunc = parse._mCustomFunc;
                mParam = parse._mParam;
                SetUI();
            }

            public void setItemInfo(Goods itemInfo, TypeParse parse, bool IsScale)
            {
                //                Clear();
                ItemInfo = itemInfo;
                mOtherNum = parse._mNum;
                mShowType = parse._mType;
                mFunc = parse._mFunc;
                mFunc1 = parse._mFunc1;
                mFunc2 = parse._mFunc2;
                mGrade = parse._mGrade;
                
                SetUI();
            }

            public void ShowEquippedIcon(bool show)
            {
                if (mEquippedSprite != null)
                {
                    CommonTool.SetActive(mEquippedSprite.gameObject, show);
                }
            }

            public RawImage MainTexture
            {
                set { mUITexture = value; }
                get { return mUITexture; }
            }
            static public UIItemNewSlot.TypeParse CreateUIItemTypeParse(int type = 0)
            {
                UIItemNewSlot.TypeParse typeParse;
                typeParse._mType = type;
                typeParse._mNum = 0;
                typeParse._mGrade = 0;
                typeParse._mFunc1 = null;
                typeParse._mFunc = null;
                typeParse._mFunc2 = null;
                typeParse._mCustomFunc = null;
                typeParse._mParam = null;
                return typeParse;
            }

            public void IsShowEquipUp(bool show)
            {
                if (mEquipUpSpr != null)
                    CommonTool.SetActive(mEquipUpSpr.gameObject, show);
            }

            bool CheckCanUse()
            {
                if(mCanNotUse)
                {
                    return false;
                }

                uint vocation = mVocation;
                //uint level = mPlayerLv;
                if(vocation == 0 && LocalPlayerManager.Instance.LocalActorAttribute != null)
                {
                    vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                }
//                 if(level == 0 && LocalPlayerManager.Instance.LocalActorAttribute != null)
//                 {
//                     level = LocalPlayerManager.Instance.LocalActorAttribute.Level;
//                 }

                if (ItemInfo == null)
                    return true;

                if (((ItemInfo is GoodsEquip) == false) || 
                    ItemInfo.use_job == 0 || ItemInfo.use_job == vocation)
                {
                    return true;
                }
                return false;

            }
            public void MatchMountEquip(GoodsMountEquip mountEquip)
            {
                if (mDisEnableSpr != null)
                {
                    if (mDisEnableSpr.gameObject.activeSelf)
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                        }
                    }
                    else
                    {
                        if (ItemInfo is GoodsMountEquip)
                        {
                            var itemmountEquip = ItemInfo as GoodsMountEquip;
                            //if ((LocalPlayerManager.Instance.LocalActorAttribute.Vocation != itemmountEquip.use_job && itemmountEquip.use_job != 0)
                            //    || !itemmountEquip.can_use)
                            //{
                            //    if (mEquipUpSpr != null)
                            //    {
                            //        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            //    }

                            //    if (mEquipDownSpr != null)
                            //    {
                            //        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            //    }

                            //    return;
                            //}

                            if (mountEquip == null)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }
                                return;
                            }

                            if (itemmountEquip.Score > mountEquip.Score)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                            else if (itemmountEquip.Score < mountEquip.Score)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, true);
                                }
                            }
                            else
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                        }
                        else
                        {
                            if (mEquipUpSpr != null)
                            {
                                CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            }

                            if (mEquipDownSpr != null)
                            {
                                CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            }
                        }
                    }

                }
                else
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }
            }

            public void MatchDecorate(GoodsDecorate decorate)
            {
                if (mDisEnableSpr != null)
                {
                    if (mDisEnableSpr.gameObject.activeSelf)
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                        }
                    }
                    else
                    {
                        if (ItemInfo is GoodsDecorate)
                        {
                            var itemDecorate = ItemInfo as GoodsDecorate;
                            if ((LocalPlayerManager.Instance.LocalActorAttribute.Vocation != itemDecorate.use_job && itemDecorate.use_job != 0)
                                || !itemDecorate.can_use)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }

                                return;
                            }

                            if (decorate == null)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }
                                return;
                            }

                            if (itemDecorate.BaseScore > decorate.BaseScore)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                            else if (itemDecorate.BaseScore < decorate.BaseScore)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, true);
                                }
                            }
                            else
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                        }
                        else
                        {
                            if (mEquipUpSpr != null)
                            {
                                CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            }

                            if (mEquipDownSpr != null)
                            {
                                CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            }
                        }
                    }

                }
                else
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }
            }

            public void MatchMagicEquip(GoodsMagicEquip magicEquip)
            {
                if (mDisEnableSpr != null)
                {
                    if (mDisEnableSpr.gameObject.activeSelf)
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                        }
                    }
                    else
                    {
                        if (ItemInfo is GoodsMagicEquip)
                        {
                            var itemMagicEquip = ItemInfo as GoodsMagicEquip;
                            if ((LocalPlayerManager.Instance.LocalActorAttribute.Vocation != itemMagicEquip.use_job && itemMagicEquip.use_job != 0)
                                || !itemMagicEquip.can_use)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }

                                return;
                            }

                            if (magicEquip == null)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }
                                return;
                            }

                            if (itemMagicEquip.BaseScore > magicEquip.BaseScore)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                            else if (itemMagicEquip.BaseScore < magicEquip.BaseScore)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, true);
                                }
                            }
                            else
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                        }
                        else
                        {
                            if (mEquipUpSpr != null)
                            {
                                CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            }

                            if (mEquipDownSpr != null)
                            {
                                CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            }
                        }
                    }

                }
                else
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }
            }

            public void MatchGoodsLightWeaponSoul(GoodsLightWeaponSoul LightWeaponSoul)
            {
                if (mDisEnableSpr != null)
                {
                    if (mDisEnableSpr.gameObject.activeSelf)
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                        }
                    }
                    else
                    {
                        if (ItemInfo is GoodsLightWeaponSoul)
                        {
                            var itemElementEquip = ItemInfo as GoodsLightWeaponSoul;

                            if (LightWeaponSoul == null)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }
                                return;
                            }

                            if (itemElementEquip.Score > LightWeaponSoul.Score)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                            else if (itemElementEquip.Score < LightWeaponSoul.Score)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, true);
                                }
                            }
                            else
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                        }
                        else
                        {
                            if (mEquipUpSpr != null)
                            {
                                CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            }

                            if (mEquipDownSpr != null)
                            {
                                CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            }
                        }
                    }

                }
                else
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }
            }
            /// <summary>
            /// 判断equip2是否比equip1更好（考虑职业）
            /// </summary>
            /// <param name="equip1"></param>
            /// <param name="equip2"></param>
            /// <param name="player_vocation">穿戴玩家的职业</param>
            /// <returns>equip2比equip1更好，返回true</returns>
            public static bool IsBetterEquip(GoodsEquip equip1, GoodsEquip equip2, uint player_vocation)
            {
                if (equip2 == null)
                    return false;//无装备
                if (equip2.use_job != 0 && equip2.use_job != player_vocation)
                    return false;//职业不符
                if (equip1 == null)
                {
                    return true;
                }
                if (equip1.EquipRank >= equip2.EquipRank)
                    return false;
                return true;
            }

            public void RefreshMatch(Goods matchGoods = null)
            {
                if (mDisEnableSpr.gameObject.activeSelf)
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }
                else if(ItemInfo != null)
                {
                    if (ItemInfo is GoodsLuaEx)
                    {
                        (ItemInfo as GoodsLuaEx).RefreshMatch(matchGoods, gameObject);
                    }
                    else
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, ItemInfo.is_equipUp);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, ItemInfo.is_equipDown);
                        }
                    }
                }
            }

            public void MatchEquip(GoodsEquip equip)
            {

                if (mDisEnableSpr != null)
                {
                    if (mDisEnableSpr.gameObject.activeSelf)
                    {
                        if (mEquipUpSpr != null)
                        {
                            CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                        }

                        if (mEquipDownSpr != null)
                        {
                            CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                        }
                    }
                    else
                    {
                        if (ItemInfo is GoodsEquip)
                        {
                            GoodsEquip itemEquip = ItemInfo as GoodsEquip;
                            itemEquip.is_equipDown = false;
                            itemEquip.is_equipUp = false;
                            if (LocalPlayerManager.Instance.LocalActorAttribute.Vocation != itemEquip.use_job && itemEquip.use_job != 0)
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                                return;
                            }

                            int itemEquip_rank = itemEquip.EquipRank;
                            int equip_rank = 0;
                            if (equip != null)
                                equip_rank = equip.EquipRank;
                            if (itemEquip.IsInEnableTime() == false)
                                itemEquip_rank = 0;
                            if (equip != null && equip.IsInEnableTime() == false)
                                equip_rank = 0;
                            
                            if (itemEquip_rank > equip_rank)
                            {
                                itemEquip.is_equipUp = true;
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, true);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                            else if (itemEquip_rank < equip_rank)
                            {
                                itemEquip.is_equipDown = true;
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, true);
                                }
                            }
                            else
                            {
                                if (mEquipUpSpr != null)
                                {
                                    CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                                }

                                if (mEquipDownSpr != null)
                                {
                                    CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                                }
                            }
                        }
                        else
                        {
                            ItemInfo.is_equipDown = false;
                            ItemInfo.is_equipUp = false;
                            if (mEquipUpSpr != null)
                            {
                                CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                            }

                            if (mEquipDownSpr != null)
                            {
                                CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                            }
                        }
                    }

                }
                else
                {
                    if (mEquipUpSpr != null)
                    {
                        CommonTool.SetActive(mEquipUpSpr.gameObject, false);
                    }

                    if (mEquipDownSpr != null)
                    {
                        CommonTool.SetActive(mEquipDownSpr.gameObject, false);
                    }
                }


            }

            public void IsSelect(bool show)
            {
                CommonTool.SetActive(SelectWid, show);
            }

            /// <summary>
            /// 获取物品框中的组件
            /// </summary>
            protected void Check()
            {
                RealGameobj = this.gameObject;
                var item_trans = transform.Find("ItemNode");
                if (item_trans == null)
                    return;

                Transform child_trans = null;

                if (NoNum == null)
                {
                    child_trans = item_trans.Find("NoNum");
                    if (child_trans != null)
                    {
                        NoNum = child_trans.gameObject;
                        Button noNumBtn = NoNum.GetComponent<Button>();
                        if (noNumBtn != null)
                        {
                            noNumBtn.onClick.RemoveAllListeners();
                            noNumBtn.onClick.AddListener(OnClickNoNum);
                        }

                        CommonTool.SetActive(NoNum, false);
                    }
                }

                if (SelectWid == null)
                {
                    child_trans = item_trans.Find("Select");
                    if (child_trans != null)
                    {
                        SelectWid = child_trans.gameObject;
                        CommonTool.SetActive(SelectWid, false);
                    }
                }

                // 获取特效
                if (EffectRoot == null)
                {
                    child_trans = item_trans.Find("Effects");
                    if (child_trans != null)
                    {
                        EffectRoot = child_trans.gameObject;
                    }
                }

                if(EffectRoot != null)
                {
                    var effect_root_trans = EffectRoot.transform;

                    // 获取序列帧特效
                    if (mQualityEffect == null)
                    {
                        child_trans = effect_root_trans.Find("frame");
                        if (child_trans != null)
                            mQualityEffect = child_trans.gameObject;

                        child_trans = effect_root_trans.Find("frameExpJade");
                        if (child_trans != null)
                            mExpJadeEffect = child_trans.gameObject;

                        if (mQualityEffect != null)
                            mQualityTexArray = mQualityEffect.GetComponent<TextureArray>();

                        if (mQualityEffect != null)
                            mQualityTex = mQualityEffect.GetComponent<RawImage>();
                    }
                    if (mQualityEffect2 == null)
                    {
                        child_trans = effect_root_trans.Find("frame1");
                        if (child_trans != null)
                            mQualityEffect2 = child_trans.gameObject;

                        if (mQualityEffect2 != null)
                            mQualityTexArray2 = mQualityEffect2.GetComponent<TextureArray>();

                        if (mQualityEffect2 != null)
                            mQualityTex2 = mQualityEffect2.GetComponent<RawImage>();
                    }
                }

                if (mCdtexSpr == null)
                {
                    child_trans = item_trans.Find("CDImage");
                    if (child_trans != null)
                    {
                        mCdtexSpr = child_trans.GetComponent<Image>();
                        CommonTool.SetActive(mCdtexSpr.gameObject, false);
                    }
                }

                if (mUITexture == null)
                {
                    child_trans = item_trans.Find("GoodsRawImage");
                    if (child_trans != null)
                    {
                        mUITexture = child_trans.GetComponent<RawImage>();
                        mUITexture_frameAnim = child_trans.GetComponent<UGUIFrameAnimation>();
                    }
                }

                if (mNum == null)
                {
                    child_trans = item_trans.Find("QuantityText");
                    if (child_trans != null)
                        mNum = child_trans.GetComponent<Text>();
                }

                if (mBindObj == null)
                {
                    child_trans = item_trans.Find("LockImage");
                    if (child_trans != null)
                        mBindObj = child_trans.gameObject;
                }

                if (mFrameSpr == null)
                {
                    child_trans = item_trans.Find("BgImage");
                    if (child_trans != null)
                        mFrameSpr = child_trans.GetComponent<Image>();
                }

                if(mCircleBkg == null)
                {
                    child_trans = item_trans.Find("CircleBkg");
                    if (child_trans != null)
                        mCircleBkg = child_trans.GetComponent<Image>();
                }

                // 品质框
                if (mQualityObject == null)
                {
                    child_trans = item_trans.Find("QualityImage");
                    if (child_trans != null)
                    {
                        mQualityObject = child_trans.gameObject;
                        mQualityImage = child_trans.GetComponent<Image>();
                        mQualityArray = child_trans.GetComponent<SpriteArray>();
                    }
                }

                if (LegendAttrs.Count == 0)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        child_trans = item_trans.Find(string.Format("LegendImage_{0}", i));
                        if (child_trans != null)
                            LegendAttrs.Add(child_trans.gameObject);
                    }
                }

                if (mEquipUpSpr == null)
                {
                    child_trans = item_trans.Find("BetterImage");
                    if (child_trans != null)
                    {
                        mEquipUpSpr = child_trans.GetComponent<Image>();
                    }
                }

                if (mEquipDownSpr == null)
                {
                    child_trans = item_trans.Find("InferiorImage");
                    if (child_trans != null)
                    {
                        mEquipDownSpr = child_trans.GetComponent<Image>();
                    }
                }

                if (mDisEnableSpr == null)
                {
                    child_trans = item_trans.Find("UnavailImage");
                    if (child_trans != null)
                    {
                        mDisEnableSpr = child_trans.GetComponent<Image>();
                    }
                }

                if (mEquippedSprite == null)
                {
                    child_trans = item_trans.Find("AdornImage");
                    if (child_trans != null)
                    {
                        mEquippedSprite = child_trans.GetComponent<Image>();
                        CommonTool.SetActive(mEquippedSprite.gameObject, false);
                    }
                }

                if (ItemButton == null)
                {
                    ItemButton = RealGameobj.GetComponent<Button>();
                    PressCom = RealGameobj.GetComponent<ComTouchPress>();
                    if (PressCom == null)
                    {
                        PressCom = RealGameobj.AddComponent<ComTouchPress>();
                        PressCom.Init(OnPressCallBack, null);
                    }

                    if (ItemButton != null)
                    {
                        ItemButton.onClick.RemoveAllListeners();
                        ItemButton.onClick.AddListener(OnClickGoodsBtn);
                    }
                }

                if (mTitleDesc == null)
                {
                    child_trans = item_trans.Find("TitleDesc");
                    if (child_trans != null)
                    {
                        mTitleDesc = child_trans.GetComponent<Text>();
                    }
                }

                if (mExpireTimeObj == null)
                {
                    child_trans = item_trans.Find("ExpireTime");
                    if (child_trans != null)
                        mExpireTimeObj = child_trans.gameObject;
                }

                if (mEquipLvStepText == null)
                {
                    child_trans = item_trans.Find("EquipLvStepText");
                    if (child_trans != null)
                        mEquipLvStepText = child_trans.GetComponent<Text>();
                }

                if (mFashionBg == null)
                {
                    child_trans = item_trans.Find("FashionBg");
                    if (child_trans != null)
                        mFashionBg = child_trans.gameObject;
                }

                if (mSpriteList == null)
                {
                    child_trans = item_trans.Find("SpriteList");
                    if (child_trans != null)
                        mSpriteList = child_trans.GetComponent<SpriteList>();
                }

                if(mDiscount == null)
                {
                    child_trans = item_trans.Find("Discount");
                    if (child_trans != null)
                    {
                        mDiscount = child_trans.gameObject;
                        child_trans = child_trans.Find("DiscountImage");
                        mDiscountImage = child_trans.GetComponent<Image>();
                    }
                    CommonTool.SetActive(mDiscount, false);
                }

                if (mOverdueNotice == null)
                {
                    child_trans = item_trans.Find("Overdue");
                    if (child_trans != null)
                        mOverdueNotice = child_trans.gameObject;
                    CommonTool.SetActive(mOverdueNotice, false);
                }

                RefreshCost();
            }

            protected void Awake()
            {
                AddListeners();
                Check();
            }

            protected void OnEnable()
            {
                AddListeners();
            }

            private void OnDisable()
            {
                /*if (UIManager.Instance.MainCtrl != null)
                {
                    ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("ShowAsync");
                }*/

                //RemoveEffectsCanvas();
                RemoveListeners();
            }

            private void RemoveListeners()
            {

                if (!isListenersInit)
                {
                    return;
                }

                isListenersInit = false;
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpdate);
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_GOODS_CD_UPDATE, OnGoodsCd);
            }

            private void AddListeners()
            {
                if (isListenersInit)
                {
                    return;
                }

                isListenersInit = true;
                OnBagUpdate(null);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_GOODS_CD_UPDATE, OnGoodsCd);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpdate);

            }

            void Update()
            {
                if (mUseDoubleClick && mSingleClickCallback != null && mDoubleClickCount == 1)
                {
                    mSingleClickCounter += Time.deltaTime;

                    if (mSingleClickCounter > this.mSingleClickDelay)
                    {
                        mSingleClickCallback(this);
                        mDoubleClickCount = -1;
                        mSingleClickCounter = 0;
                    }
                }
                else
                {
                    mSingleClickCounter = 0;
                }


                if (is_CD == true)
                {
                    if (mCdtexSpr != null)
                    {
                        uint serverTime = Game.GetInstance().ServerTime;
                        if (EndCd <= serverTime)
                        {
                            is_CD = false;
                            CommonTool.SetActive(mCdtexSpr.gameObject, false);
                            Times = 0;
                            DetalTime = 0;
                            mCdtexSpr.fillAmount = 0;
                        }
                        else
                        {
                            float _time = Times / DetalTime;
                            mCdtexSpr.fillAmount = NowFill - _time;
                        }
                        Times += Time.deltaTime;

                    }
                }
                else
                {
                    if (ItemInfo != null)
                    {
                        if (Game.Instance.ServerTime == StartCd)
                        {
                            CheckCdTime();
                        }
                    }

                }

            }

            public void ShowTips()
            {
                if (mFrameSpr == null)
                    return;
            }

            void Ontip()
            {
                if (mShowType == 1)
                {
                }
                else if (mShowType == 2 && IsShowTips == true)
                {
                    GoodsHelper.ShowGoodsTips(ItemInfo);
                }

            }

            void OnCutBtnClick()
            {
                if (mCuntFunc != null)
                    mCuntFunc(ItemInfo, this);
            }

            void OnClickNoNum()
            {
                if (ItemInfo == null)
                    return;
                UIManager.Instance.ShowWindow("UIGoodsGetWayWindow", ItemInfo.type_idx);
                //xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_SHOW, new xc.ClientEventParamArgs("UIGetWindow", CurrentWindow, ItemInfo.type_idx, CurrentWindowDepth));
            }

            public void OnPressCallBack(System.Object obj)
            {
                if (SupportPressDown == false || this.ItemInfo == null)
                    return;

                GoodsHelper.ShowGoodsTips(ItemInfo);
            }



            void OnClickGoodsBtn()
            {
                if (mUseDoubleClick)
                {
                    if (mDoubleClickCount == 1)
                    {
                        if (mDoubleClickCallback != null)
                        {
                            mDoubleClickCallback(this);
                        }
                        mDoubleClickCount = -1;
                    }
                    else if (mDoubleClickCount == -1)
                    {
                        mDoubleClickCount = 1;
                    }
                }


                if (mFunc != null)
                {
                    mFunc(ItemInfo);
                    return;
                }
                else if (mFunc1 != null)
                {
                    mFunc1(ItemInfo, mOtherNum);
                    return;
                }
                else if (mFunc2 != null)
                {
                    mFunc2(ItemInfo, this);
                    return;
                }
                else if (mCustomFunc != null)
                    mCustomFunc(mParam, this);
                Ontip();
            }

            void OnGoodsCd(CEventBaseArgs args)
            {
                CheckCdTime();
            }

            void OnServerTimeChange(CEventBaseArgs args)
            {
                RefreshExpireTime();
                RefreshOverdueNotice();
                if (mExpiredObj != null && ItemInfo != null)
                {
                    if (ItemInfo.expire_time != 0 && Game.Instance.ServerTime > ItemInfo.expire_time)
                    {
                        CommonTool.SetActive(mExpiredObj, true);
                    }
                    else
                    {
                        CommonTool.SetActive(mExpiredObj, false);
                    }
                }
            }

            public bool IsCostItem
            {
                get { return mIsCostItem; }
                set
                {
                    mIsCostItem = value;
                    if(mIsCostItemNoGrey)
                    {
                        GameDebug.LogError("[UIItemNewSlot] set mIsCostItem = true, but mIsCostItemNoGrey is true;");
                        mIsCostItemNoGrey = false;
                    }
                    if(mIsCostItem && ItemInfo != null)
                    {
                        uint id = ItemInfo.type_idx;
                        List<string> _icon_id = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_getGoodsWay", "id", id.ToString(), "sys_id");
                        if (_icon_id.Count > 0)
                        {
                            mHasGoodsGetWay = true;
                        }
                        else
                            mHasGoodsGetWay = false;
                    }
                    RefreshCost();
                }
            }
            public bool IsCostItemNoGrey
            {
                get { return mIsCostItemNoGrey; }
                set
                {
                    mIsCostItemNoGrey = value;
                    if (mIsCostItem)
                    {
                        GameDebug.LogError("[UIItemNewSlot] set mIsCostItemNoGrey = true, but mIsCostItem is true;");
                        mIsCostItem = false;
                    }
                    RefreshCost();
                }
            }

            public uint NeedNum
            {
                get { return mNeedNum; }
                set
                {
                    mNeedNum = value;
                    RefreshCost();
                }
            }

            public uint IsBind
            {
                set
                {
                    if (value == 0)
                        CommonTool.SetActive(mBindObj, false);
                    else
                        CommonTool.SetActive(mBindObj, true);
                }
            }

            void OnBagUpdate(CEventBaseArgs args)
            {
                RefreshCost();
                RefreshExpireTime();
            }

            public void RefreshCost()
            {
                if (NoNum != null && ItemInfo != null)
                {
                    if (mIsCostItem == false && mIsCostItemNoGrey == false)
                    {
                        CommonTool.SetActive(NoNum, false);
                        return;
                    }


                    ulong num = 0;
                    if (ItemInfo.main_type == GameConst.GIVE_TYPE_RIDE_EQUIP)
                    {
                        num = ItemManager.Instance.GetGoodsNumForMountEquipBagByTypeId(ItemInfo.type_idx);
                    }
                    else if (ItemInfo.main_type == GameConst.GIVE_TYPE_SOUL)
                    {
                        num = ItemManager.Instance.GetGoodsNumFromSoulBagAndBodyByTypeId(ItemInfo.type_idx);
                    }
                    else if (ItemInfo.main_type == GameConst.GIVE_TYPE_ARCHIVE)
                    {
                        num = ItemManager.Instance.GetGoodsNumFromHandbookBagAndBodyByTypeId(ItemInfo.type_idx);
                    }
                    else
                    {
                        num = ItemManager.Instance.GetGoodsNumForBagByTypeId(ItemInfo.type_idx);
                    }

                    if (num < mNeedNum)
                    {
                        if (mShowNeedNum)
                            mNum.text = string.Format("<color=red>{0}/{1}</color>", num, mNeedNum);
                        else
                        {
                            if (num == 0 && mShowZeroNum == false)
                                mNum.text = "";
                            else
                                mNum.text = string.Format("<color=red>{0}</color>", num);
                        }
                        if (mIsCostItem && mHasGoodsGetWay)
                        {
                            CommonTool.SetActive(NoNum, true);
                            SetGrey(true);
                        }
                        else
                        {
                            CommonTool.SetActive(NoNum, false);
                        }
                    }
                    else//数量足够
                    {
                        if (mShowNeedNum)
                            mNum.text = string.Format("{0}/{1}", num, mNeedNum);
                        else
                            mNum.text = string.Format("{0}", num);

                        CommonTool.SetActive(NoNum, false);
                        if(mIsCostItem && mHasGoodsGetWay)
                            SetGrey(false);
                    }
                }
            }

            public void SetGrey(bool is_grey)
            {
                if(is_grey)//变灰
                {
                    if (EffectRoot != null)
                        CommonTool.SetActive(EffectRoot.gameObject, false);

                    if (mUITexture != null && mUITexture.material != null)
                    {
                        // 先备份当前材质
                        if (mTextureMaterial == null)
                            mTextureMaterial = mUITexture.material;

                        ///TODO Material的实例化需要优化
                        Material m = GameObject.Instantiate(mUITexture.material) as Material;
                        m.SetFloat("_Grey", 0);  //灰白色
                        mUITexture.material = m;

                        if (mQualityImage != null)
                            mQualityImage.material = m;   //灰白色
                    }

                    if (mEquipUpSpr != null)
                        mEquipUpSpr.color = Color.grey;

                    if (mEquipDownSpr != null)
                        mEquipDownSpr.color = Color.grey;
                }
                else//彩色
                {
                    if (EffectRoot != null)
                        CommonTool.SetActive(EffectRoot.gameObject, true);

                    // 还原之前的材质
                    if (mTextureMaterial != null)
                    {
                        if (mUITexture != null)
                            mUITexture.material = mTextureMaterial;

                        if (mQualityImage != null)
                            mQualityImage.material = mTextureMaterial;
                    }

                    if (mEquipUpSpr != null)
                        mEquipUpSpr.color = Color.white;

                    if (mEquipDownSpr != null)
                        mEquipDownSpr.color = Color.white;
                }
            }

            bool mIsDestroy = false;
            

            void OnDestroy()
            {
                mIsDestroy = true;
                DestroyAssetRes();

                /*if (UIManager.Instance.MainCtrl != null)
                {
                    ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("ShowAsync");
                }*/
               
                if (RealGameobj != null)
                {

                    /*UIButton btn = RealGameobj.GetComponent<UIButton>();
                    if (btn != null)
                    {
                        EventDelegate.Remove(btn.onClick, OnClickGoodsBtn);
                    }*/
                }
                Clear();

                this.RemoveListeners();

            }

            public void SetTitleDesc(string title_desc)
            {
                if (mTitleDesc != null)
                    mTitleDesc.text = title_desc;
            }

            /// <summary>
            /// 设置背景框的显示
            /// </summary>
            /// <param name="is_visiable"></param>
            public void SetBgImageVisiable(bool is_visiable)
            {
                if (mFrameSpr != null)
                {
                    CommonTool.SetActive(mFrameSpr.gameObject, is_visiable);
                }

                m_IsFrameSprShow = is_visiable;
            }

            public void SetCircleBkgVisiable(bool is_visiable)
            {
                if (mCircleBkg != null)
                    CommonTool.SetActive(mCircleBkg.gameObject, is_visiable);

                m_IsCircleBkgShow = is_visiable;

                if (is_visiable == true)//若显示圆形背景框，则不显示正方形背景框和品质框
                {
                    SetBgImageVisiable(false);
                    SetColor(false);
                    SetEffectRootVisiable(false);
                }
            }

            public void SetEffectRootVisiable(bool is_visiable)
            {
                CommonTool.SetActive(EffectRoot, is_visiable);
            }

            /// <summary>
            /// 设定所属的玩家职业和等级(通常用于显示其他玩家的装备)
            /// </summary>
            /// <param name="vocation"></param>
            /// <param name="player_lv"></param>
            public void SetPlayerVocationAndLv(uint vocation, uint player_lv)
            {
                mVocation = vocation;
                mPlayerLv = player_lv;
                if (mDisEnableSpr != null)
                {
                    CommonTool.SetActive(mDisEnableSpr.gameObject, !CheckCanUse());
                }
            }

            public void SetCanNotUse(bool canNotUse)
            {
                mCanNotUse = canNotUse;
                if (mDisEnableSpr != null)
                {
                    CommonTool.SetActive(mDisEnableSpr.gameObject, !CheckCanUse());
                }
            }

            public bool ShowNeedNum
            {
                get { return mShowNeedNum; }
                set
                {
                    if (mShowNeedNum == value)
                        return;
                    mShowNeedNum = value;
                    RefreshCost();
                }
            }
            public bool ShowZeroNum
            {
                get { return mShowZeroNum; }
                set
                {
                    if (mShowZeroNum == value)
                        return;
                    mShowZeroNum = value;
                    RefreshCost();
                }
            }

            public bool ShowCheckImage
            {
                get { return mShowCheckImage; }
                set
                {
                    if (mShowCheckImage == value)
                        return;
                    mShowCheckImage = value;
                    if (mCheckImage != null)
                    {
                        CommonTool.SetActive(mCheckImage, mShowCheckImage);
                        SetGrey(mShowCheckImage);
                    }
                }
            }

            public void SetCheckImageActive(bool is_active)
            {
                CommonTool.SetActive(mCheckImage, is_active);
            }

            public void SetShowExpJadeEffect(bool is_active)
            {
                CommonTool.SetActive(mExpJadeEffect, is_active);
            }

            /// <summary>
            /// 是否显示数量
            /// </summary>
            /// <param name="is_active"></param>
            public void SetNumActive(bool is_active)
            {
                if (mNum != null)
                    CommonTool.SetActive(mNum.gameObject, is_active);
            }

            public bool CanShowCircleBkg
            {
                set {
                    m_CanShowCircleBkg = value;
                    RefreshCircleBkgVisiable();
                }
                get { return m_CanShowCircleBkg; }
            }

            void RefreshCircleBkgVisiable()
            {
                if(ItemInfo == null)
                {
                    SetCircleBkgVisiable(false);//默认当成方形处理
                    return;
                }
                DBGoodsEffectIcon db_effect_icon = DBManager.Instance.GetDB<DBGoodsEffectIcon>();
                DBGoodsEffectIcon.DBGoodsEffectIconItem icon_item_tmpl = db_effect_icon.GetOneInfo(ItemInfo.icon_id);
                if (icon_item_tmpl != null)
                {
                    if (m_CanShowCircleBkg)
                        SetCircleBkgVisiable(true);
                    else
                    {
                        SetCircleBkgVisiable(false);
                        SetBgImageVisiable(true);
                        SetColor(false);
                        SetEffectRootVisiable(true);
                    }
                }
                else
                    SetCircleBkgVisiable(false);//默认当成方形处理
            }

            /// <summary>
            /// 设置自定义点击事件
            /// </summary>
            /// <param name="customFunc"></param>
            public void SetCustomFunc(OnClickCustomFunc customFunc)
            {
                mCustomFunc = customFunc;
            }

            /// <summary>
            /// 设置是否显示第二层品质特效
            /// </summary>
            /// <param name="color"></param>
            public void ShowQualityEffect2(bool isShow)
            {
                if (isShow == true)
                {
                    if (ItemInfo != null && ItemInfo.color_type >= GameConst.QUAL_COLOR_GOLDEN)
                    {
                        if (mQualityTexArray2 != null && mQualityTex2 != null)
                        {
                            var tex = mQualityTexArray2.LoadTexture((int)(ItemInfo.color_type - 1));
                            if (mQualityTex2.texture != tex)
                                mQualityTex2.texture = tex;
                        }

                        CommonTool.SetActive(mQualityEffect2, true);
                    }
                    else
                        CommonTool.SetActive(mQualityEffect2, false);
                }
                else
                {
                    CommonTool.SetActive(mQualityEffect2, false);
                }
            }
        }


    }
}
