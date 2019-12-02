using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using wxb;
using xc.Decorate;
using xc.Equip;
using xc.ui.ugui;

namespace xc.ui
{
	[DisallowMultipleComponent, Hotfix]
	public class UIItemNewSlot : MonoBehaviour
	{
		public delegate void OnClickCustomFunc(object obj, UIItemNewSlot item);

		public delegate void OnClickFunc(Goods goods);

		public delegate void OnClickFunc1(Goods goods, int num);

		public delegate void OnClickFunc2(Goods goods, UIItemNewSlot item);

		public struct TypeParse
		{
			public int _mType;

			public int _mNum;

			public uint _mGrade;

			public UIItemNewSlot.OnClickFunc _mFunc;

			public UIItemNewSlot.OnClickFunc1 _mFunc1;

			public UIItemNewSlot.OnClickFunc2 _mFunc2;

			public UIItemNewSlot.OnClickCustomFunc _mCustomFunc;

			public object _mParam;
		}

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

		public const uint GOODS_ID_EXP_JADE = 20060u;

		public Goods ItemInfo;

		private RawImage mUITexture;

		private UGUIFrameAnimation mUITexture_frameAnim;

		public Material mTextureMaterial = null;

		public bool m_IsFrameSprShow = true;

		public bool m_IsCircleBkgShow = false;

		private bool m_CanShowCircleBkg = false;

		public bool m_IsQualitySprShow = true;

		private bool mUseDoubleClick = false;

		private Action<UIItemNewSlot> mDoubleClickCallback = null;

		private Action<UIItemNewSlot> mSingleClickCallback = null;

		private float mSingleClickDelay = 0.3f;

		private float mSingleClickCounter = 0f;

		private int mDoubleClickCount = -1;

		public UIItemNewSlot.OnClickCustomFunc mCustomFunc;

		public UIItemNewSlot.OnClickFunc mFunc;

		public UIItemNewSlot.OnClickFunc1 mFunc1;

		public UIItemNewSlot.OnClickFunc2 mFunc2;

		public UIItemNewSlot.OnClickFunc2 mCuntFunc;

		private int mOtherNum = 0;

		private uint mGrade = 0u;

		private GameObject mQualityObject = null;

		private Image mQualityImage = null;

		private SpriteArray mQualityArray = null;

		private Image mEquipUpSpr;

		private Image mEquipDownSpr;

		private Image mDisEnableSpr;

		private object mParam;

		private Text mNum;

		public bool IsShowTips = true;

		private Texture mTextureObj = null;

		public Vector3 ForceTipsPosition = Vector3.get_one();

		private Image mCdtexSpr;

		public bool is_CD = false;

		private float DetalTime = 0f;

		private float NowFill = 0f;

		private float Times = 0f;

		private bool mIsCostItem = false;

		private bool mIsCostItemNoGrey = false;

		private bool mHasGoodsGetWay = false;

		private uint mNeedNum = 0u;

		private GameObject NoNum;

		private string CurrentWindow = string.Empty;

		private int CurrentWindowDepth = 50;

		private Button ItemButton;

		private bool isClear = false;

		private uint StartCd = 0u;

		private uint EndCd = 0u;

		private uint GoodsIcon = 4294967295u;

		private GameObject mExpiredObj;

		private AssetResource mAssetRes = null;

		private bool SupportPressDown = false;

		private bool isShowCd = false;

		private GameObject EffectRoot;

		[Header("面板canvas")]
		public Canvas TargetPanel;

		[Header("裁剪区域：（只有ScrollView 滑动区域需要裁剪）")]
		public RectTransform ClipPanel;

		private bool isListenersInit = false;

		private List<GameObject> LegendAttrs = new List<GameObject>();

		private Dictionary<uint, GameObject> Effects = new Dictionary<uint, GameObject>();

		private GameObject mExpJadeEffect;

		private ComTouchPress PressCom;

		public PrefabResource GoodsItemPr = new PrefabResource();

		private Text mTitleDesc;

		private RenderqueueComponent EffectCom;

		private GameObject mQualityEffect = null;

		private RawImage mQualityTex = null;

		private TextureArray mQualityTexArray = null;

		private GameObject mQualityEffect2 = null;

		private RawImage mQualityTex2 = null;

		private TextureArray mQualityTexArray2 = null;

		private uint mVocation = 0u;

		private uint mPlayerLv = 0u;

		private bool mCanNotUse = false;

		private bool mShowNeedNum = true;

		private bool mShowZeroNum = false;

		private GameObject mCheckImage;

		private bool mShowCheckImage = false;

		private GameObject mExpireTimeObj = null;

		private GameObject mFashionBg = null;

		private bool mShowExpireTime = false;

		private Text mEquipLvStepText = null;

		private SpriteList mSpriteList = null;

		private GameObject mDiscount = null;

		private Image mDiscountImage = null;

		private GameObject mOverdueNotice = null;

		public UIItemNewSlot.TypeParse _mTypeParse;

		private bool mIsDestroy = false;

		public GameObject SelectWid
		{
			get;
			set;
		}

		public int mShowType
		{
			get;
			set;
		}

		public GameObject mBindObj
		{
			get;
			set;
		}

		public Image mEquippedSprite
		{
			get;
			set;
		}

		public Image mFrameSpr
		{
			get;
			set;
		}

		public Image mCircleBkg
		{
			get;
			set;
		}

		public bool NeedForceSetTipsPosition
		{
			get;
			set;
		}

		public RawImage mCdtex
		{
			get;
			set;
		}

		public GameObject RealGameobj
		{
			get;
			set;
		}

		public RawImage MainTexture
		{
			get
			{
				return this.mUITexture;
			}
			set
			{
				this.mUITexture = value;
			}
		}

		public bool IsCostItem
		{
			get
			{
				return this.mIsCostItem;
			}
			set
			{
				this.mIsCostItem = value;
				bool flag = this.mIsCostItemNoGrey;
				if (flag)
				{
					GameDebug.LogError("[UIItemNewSlot] set mIsCostItem = true, but mIsCostItemNoGrey is true;");
					this.mIsCostItemNoGrey = false;
				}
				bool flag2 = this.mIsCostItem && this.ItemInfo != null;
				if (flag2)
				{
					uint type_idx = this.ItemInfo.type_idx;
					List<string> list = Singleton<DBManager>.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_getGoodsWay", "id", type_idx.ToString(), "sys_id");
					bool flag3 = list.Count > 0;
					if (flag3)
					{
						this.mHasGoodsGetWay = true;
					}
					else
					{
						this.mHasGoodsGetWay = false;
					}
				}
				this.RefreshCost();
			}
		}

		public bool IsCostItemNoGrey
		{
			get
			{
				return this.mIsCostItemNoGrey;
			}
			set
			{
				this.mIsCostItemNoGrey = value;
				bool flag = this.mIsCostItem;
				if (flag)
				{
					GameDebug.LogError("[UIItemNewSlot] set mIsCostItemNoGrey = true, but mIsCostItem is true;");
					this.mIsCostItem = false;
				}
				this.RefreshCost();
			}
		}

		public uint NeedNum
		{
			get
			{
				return this.mNeedNum;
			}
			set
			{
				this.mNeedNum = value;
				this.RefreshCost();
			}
		}

		public uint IsBind
		{
			set
			{
				bool flag = value == 0u;
				if (flag)
				{
					CommonTool.SetActive(this.mBindObj, false);
				}
				else
				{
					CommonTool.SetActive(this.mBindObj, true);
				}
			}
		}

		public bool ShowNeedNum
		{
			get
			{
				return this.mShowNeedNum;
			}
			set
			{
				bool flag = this.mShowNeedNum == value;
				if (!flag)
				{
					this.mShowNeedNum = value;
					this.RefreshCost();
				}
			}
		}

		public bool ShowZeroNum
		{
			get
			{
				return this.mShowZeroNum;
			}
			set
			{
				bool flag = this.mShowZeroNum == value;
				if (!flag)
				{
					this.mShowZeroNum = value;
					this.RefreshCost();
				}
			}
		}

		public bool ShowCheckImage
		{
			get
			{
				return this.mShowCheckImage;
			}
			set
			{
				bool flag = this.mShowCheckImage == value;
				if (!flag)
				{
					this.mShowCheckImage = value;
					bool flag2 = this.mCheckImage != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mCheckImage, this.mShowCheckImage);
						this.SetGrey(this.mShowCheckImage);
					}
				}
			}
		}

		public bool CanShowCircleBkg
		{
			get
			{
				return this.m_CanShowCircleBkg;
			}
			set
			{
				this.m_CanShowCircleBkg = value;
				this.RefreshCircleBkgVisiable();
			}
		}

		public static void InitEffectIconParam()
		{
			bool is_load_effectIcon = UIItemNewSlot.m_is_load_effectIcon;
			if (!is_load_effectIcon)
			{
				UIItemNewSlot.m_is_load_effectIcon = true;
				UIItemNewSlot.m_effectIcon_frame_count = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_COUNT");
				UIItemNewSlot.m_effectIcon_frame_width = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_WIDTH");
				UIItemNewSlot.m_effectIcon_frame_height = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_HEIGHT");
				UIItemNewSlot.m_effectIcon_frame_rect_x = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_RECT_X");
				UIItemNewSlot.m_effectIcon_frame_rect_y = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_RECT_Y");
				UIItemNewSlot.m_effectIcon_frame_col_num = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_COL_NUM");
				UIItemNewSlot.m_effectIcon_frame_interval = GameConstHelper.GetFloat("GAME_GOODS_EFFECT_ICON_FRAME_INTERVAL");
				UIItemNewSlot.m_effectIcon_frame_is_loop = (GameConstHelper.GetString("GAME_GOODS_EFFECT_ICON_FRAME_IS_LOOP") == "1");
				UIItemNewSlot.m_effectIcon_frame_start_frame = GameConstHelper.GetUint("GAME_GOODS_EFFECT_ICON_FRAME_START_FRAME");
			}
		}

		public UIItemNewSlot ReplaceItemPrefab(float scale, bool newInstance = true)
		{
			UIItemNewSlot uIItemNewSlot = this.ReplaceItemPrefab(newInstance);
			RectTransform component = uIItemNewSlot.GetComponent<RectTransform>();
			component.set_localScale(new Vector3(scale, scale, scale));
			return uIItemNewSlot;
		}

		public UIItemNewSlot ReplaceItemPrefab(RectTransform rectTrans, bool newInstance = true)
		{
			UIItemNewSlot uIItemNewSlot = this.ReplaceItemPrefab(newInstance);
			RectTransform component = uIItemNewSlot.GetComponent<RectTransform>();
			component.set_localScale(rectTrans.get_localScale());
			return uIItemNewSlot;
		}

		public UIItemNewSlot ReplaceItemPrefab(bool newInstace = true)
		{
			LayoutElement layoutElement = base.get_gameObject().GetComponent<LayoutElement>();
			bool flag = layoutElement == null;
			if (flag)
			{
				layoutElement = base.get_gameObject().AddComponent<LayoutElement>();
			}
			layoutElement.set_ignoreLayout(true);
			RectTransform component = base.GetComponent<RectTransform>();
			Transform transform = base.get_transform();
			GameObject itemGameObj = Singleton<UIManager>.Instance.UICache.GetItemGameObj(transform.get_parent(), newInstace);
			UIItemNewSlot uIItemNewSlot = UIItemNewSlot.Bind(itemGameObj, this.TargetPanel, this.ClipPanel);
			itemGameObj.get_transform().SetSiblingIndex(transform.GetSiblingIndex());
			RectTransform component2 = uIItemNewSlot.GetComponent<RectTransform>();
			component2.set_sizeDelta(component.get_sizeDelta());
			component2.set_pivot(component.get_pivot());
			component2.set_localPosition(component.get_localPosition());
			component2.set_localRotation(component.get_localRotation());
			component2.set_localScale(component.get_localScale());
			component2.set_localEulerAngles(component.get_localEulerAngles());
			component2.set_anchorMin(component.get_anchorMin());
			component2.set_anchorMax(component.get_anchorMax());
			component2.set_anchoredPosition(component.get_anchoredPosition());
			component2.set_anchoredPosition3D(component.get_anchoredPosition3D());
			component2.set_sizeDelta(component.get_sizeDelta());
			CommonTool.SetActive(base.get_gameObject(), false);
			uIItemNewSlot.get_gameObject().set_name(base.get_gameObject().get_name());
			base.get_gameObject().set_name(base.get_gameObject().get_name() + "_old");
			uIItemNewSlot.Clear();
			CommonTool.SetActive(uIItemNewSlot.get_gameObject(), true);
			return uIItemNewSlot;
		}

		public void SetDoubleClick(Action<UIItemNewSlot> doubleClickCallback, Action<UIItemNewSlot> singleClickCallback, bool useDoubleClick, float delay = 0.3f)
		{
			this.mUseDoubleClick = useDoubleClick;
			this.mSingleClickDelay = delay;
			this.mDoubleClickCallback = doubleClickCallback;
			this.mSingleClickCallback = singleClickCallback;
			this.mSingleClickCounter = 0f;
		}

		public static UIItemNewSlot Bind(GameObject obj, Canvas canvas = null, RectTransform clipPanel = null)
		{
			UIItemNewSlot uIItemNewSlot = obj.GetComponent<UIItemNewSlot>();
			bool flag = uIItemNewSlot == null;
			if (flag)
			{
				uIItemNewSlot = obj.AddComponent<UIItemNewSlot>();
			}
			uIItemNewSlot.TargetPanel = canvas;
			uIItemNewSlot.ClipPanel = clipPanel;
			return uIItemNewSlot;
		}

		public static UIItemNewSlot ReplaceItemPrefab_static(GameObject re_obj, Canvas canvas = null, RectTransform clipPanel = null, bool newInstace = true)
		{
			RectTransform component = re_obj.GetComponent<RectTransform>();
			GameObject itemGameObj = Singleton<UIManager>.Instance.UICache.GetItemGameObj(re_obj.get_transform().get_parent(), newInstace);
			UIItemNewSlot uIItemNewSlot = UIItemNewSlot.Bind(itemGameObj, canvas, clipPanel);
			itemGameObj.get_transform().SetSiblingIndex(re_obj.get_transform().GetSiblingIndex());
			RectTransform component2 = uIItemNewSlot.GetComponent<RectTransform>();
			component2.set_pivot(component.get_pivot());
			component2.set_localPosition(component.get_localPosition());
			component2.set_localRotation(component.get_localRotation());
			component2.set_localScale(component.get_localScale());
			component2.set_localEulerAngles(component.get_localEulerAngles());
			component2.set_anchorMin(component.get_anchorMin());
			component2.set_anchorMax(component.get_anchorMax());
			component2.set_anchoredPosition(component.get_anchoredPosition());
			component2.set_anchoredPosition3D(component.get_anchoredPosition3D());
			component2.set_sizeDelta(component.get_sizeDelta());
			uIItemNewSlot.get_gameObject().set_name(re_obj.get_name());
			Object.DestroyImmediate(re_obj);
			uIItemNewSlot.Clear();
			CommonTool.SetActive(uIItemNewSlot.get_gameObject(), true);
			return uIItemNewSlot;
		}

		public static UIItemNewSlot ReplaceItemUseCache(GameObject re_obj, UIBaseWindow wnd, Canvas canvas = null, RectTransform clipPanel = null)
		{
			bool flag = wnd == null || re_obj == null;
			UIItemNewSlot result;
			if (flag)
			{
				result = null;
			}
			else
			{
				RectTransform component = re_obj.GetComponent<RectTransform>();
				GameObject itemGameObj = wnd.GetItemGameObj(re_obj.get_transform().get_parent());
				UIItemNewSlot uIItemNewSlot = UIItemNewSlot.Bind(itemGameObj, canvas, clipPanel);
				itemGameObj.get_transform().SetSiblingIndex(re_obj.get_transform().GetSiblingIndex());
				RectTransform component2 = uIItemNewSlot.GetComponent<RectTransform>();
				component2.set_pivot(component.get_pivot());
				component2.set_localPosition(component.get_localPosition());
				component2.set_localRotation(component.get_localRotation());
				component2.set_localScale(component.get_localScale());
				component2.set_localEulerAngles(component.get_localEulerAngles());
				component2.set_anchorMin(component.get_anchorMin());
				component2.set_anchorMax(component.get_anchorMax());
				component2.set_anchoredPosition(component.get_anchoredPosition());
				component2.set_anchoredPosition3D(component.get_anchoredPosition3D());
				component2.set_sizeDelta(component.get_sizeDelta());
				uIItemNewSlot.get_gameObject().set_name(re_obj.get_name());
				Object.DestroyImmediate(re_obj);
				uIItemNewSlot.Clear();
				CommonTool.SetActive(uIItemNewSlot.get_gameObject(), true);
				result = uIItemNewSlot;
			}
			return result;
		}

		private void DestroyAssetRes()
		{
			bool flag = this.mAssetRes != null;
			if (flag)
			{
				this.mAssetRes.destroy();
				this.mAssetRes = null;
			}
		}

		public void Dispose()
		{
			this.SetDoubleClick(null, null, false, 0.3f);
			this.Clear();
			this.RemoveListeners();
			this.DestroyAssetRes();
		}

		public void Clear()
		{
			bool flag = this.RealGameobj == null;
			if (flag)
			{
				this.Check();
			}
			bool flag2 = this.mUITexture != null;
			if (flag2)
			{
				this.mUITexture.set_texture(null);
				CommonTool.SetActive(this.mUITexture.get_gameObject(), false);
				this.isClear = true;
			}
			bool flag3 = this.mUITexture_frameAnim != null;
			if (flag3)
			{
				this.mUITexture_frameAnim.set_enabled(false);
			}
			bool flag4 = false;
			bool flag5 = this.mQualityObject != null;
			if (flag5)
			{
				this.mQualityObject.SetActive(false);
			}
			this.m_IsQualitySprShow = true;
			bool flag6 = this.mNum != null;
			if (flag6)
			{
				this.mNum.set_text("");
			}
			bool flag7 = this.mNum != null;
			if (flag7)
			{
				CommonTool.SetActive(this.mNum.get_gameObject(), true);
			}
			bool flag8 = this.mEquipUpSpr != null;
			if (flag8)
			{
				CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
			}
			bool flag9 = this.mEquipDownSpr != null;
			if (flag9)
			{
				CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
			}
			bool flag10 = this.mDisEnableSpr != null;
			if (flag10)
			{
				CommonTool.SetActive(this.mDisEnableSpr.get_gameObject(), false);
			}
			CommonTool.SetActive(this.mExpiredObj, false);
			CommonTool.SetActive(this.mFashionBg, false);
			this.GoodsIcon = 4294967295u;
			CommonTool.SetActive(this.mBindObj, false);
			bool flag11 = this.mEquippedSprite != null;
			if (flag11)
			{
				CommonTool.SetActive(this.mEquippedSprite.get_gameObject(), false);
			}
			CommonTool.SetActive(this.SelectWid, false);
			bool flag12 = this.mCdtexSpr != null;
			if (flag12)
			{
				CommonTool.SetActive(this.mCdtexSpr.get_gameObject(), false);
			}
			flag4 = false;
			int num;
			for (int i = 0; i < this.LegendAttrs.Count; i = num + 1)
			{
				CommonTool.SetActive(this.LegendAttrs[i], false);
				flag4 = true;
				num = i;
			}
			bool flag13 = flag4;
			if (flag13)
			{
				this.LegendAttrs.Clear();
			}
			flag4 = false;
			foreach (KeyValuePair<uint, GameObject> current in this.Effects)
			{
				CommonTool.SetActive(current.Value, false);
				flag4 = true;
			}
			bool flag14 = flag4;
			if (flag14)
			{
				this.Effects.Clear();
			}
			CommonTool.SetActive(this.mExpJadeEffect, false);
			CommonTool.SetActive(this.mQualityEffect, false);
			CommonTool.SetActive(this.mQualityEffect2, false);
			CommonTool.SetActive(this.EffectRoot, true);
			this.ItemInfo = null;
			this.mOtherNum = 0;
			this.mShowType = 0;
			this.IsShowTips = true;
			this.mFunc = null;
			this.mFunc1 = null;
			this.mFunc2 = null;
			this.mCustomFunc = null;
			this.mGrade = 0u;
			this.mParam = null;
			this.is_CD = false;
			this.DetalTime = 0f;
			this.StartCd = 0u;
			this.EndCd = 0u;
			this.Times = 0f;
			this.NowFill = 0f;
			this.mNeedNum = 0u;
			this.SupportPressDown = false;
			this.mTextureObj = null;
			this.mIsCostItem = false;
			this.mIsCostItemNoGrey = false;
			CommonTool.SetActive(this.NoNum, false);
			bool flag15 = this.EffectRoot != null;
			if (flag15)
			{
				CommonTool.SetActive(this.EffectRoot.get_gameObject(), true);
			}
			bool flag16 = this.mFrameSpr != null;
			if (flag16)
			{
				CommonTool.SetActive(this.mFrameSpr.get_gameObject(), true);
			}
			this.m_IsCircleBkgShow = false;
			this.m_CanShowCircleBkg = false;
			bool flag17 = this.mCircleBkg != null;
			if (flag17)
			{
				CommonTool.SetActive(this.mCircleBkg.get_gameObject(), false);
			}
			this.m_IsFrameSprShow = true;
			bool flag18 = this.mTextureMaterial != null;
			if (flag18)
			{
				bool flag19 = this.mUITexture != null;
				if (flag19)
				{
					this.mUITexture.set_material(this.mTextureMaterial);
				}
				bool flag20 = this.mQualityImage != null;
				if (flag20)
				{
					this.mQualityImage.set_material(this.mTextureMaterial);
				}
				this.mTextureMaterial = null;
			}
			bool flag21 = this.mUITexture != null && this.mUITexture.get_material() != null;
			if (flag21)
			{
				this.mUITexture.get_material().SetFloat("_Grey", 1f);
			}
			bool flag22 = this.mQualityImage != null && this.mQualityImage.get_material() != null;
			if (flag22)
			{
				this.mQualityImage.get_material().SetFloat("_Grey", 1f);
			}
			bool flag23 = this.mEquipUpSpr != null;
			if (flag23)
			{
				this.mEquipUpSpr.set_color(Color.get_white());
			}
			bool flag24 = this.mEquipDownSpr != null;
			if (flag24)
			{
				this.mEquipDownSpr.set_color(Color.get_white());
			}
			this.mVocation = 0u;
			this.mPlayerLv = 0u;
			this.mShowNeedNum = true;
			this.mShowZeroNum = false;
			this.mShowCheckImage = false;
			CommonTool.SetActive(this.mCheckImage, false);
			CommonTool.SetActive(this.mExpireTimeObj, false);
			this.mShowExpireTime = false;
			this.mHasGoodsGetWay = false;
			CommonTool.SetActive(this.mDiscount, false);
			CommonTool.SetActive(this.mOverdueNotice, false);
			bool flag25 = this.mEquipLvStepText != null;
			if (flag25)
			{
				CommonTool.SetActive(this.mEquipLvStepText.get_gameObject(), false);
			}
			bool flag26 = this.mUITexture != null && this.mUITexture.get_enabled();
			if (flag26)
			{
				this.mUITexture.set_enabled(false);
			}
		}

		public void SetNumLabelText(string tx)
		{
			bool flag = this.mNum != null;
			if (flag)
			{
				this.mNum.set_text(tx);
			}
		}

		public void SetNumLabelText(ulong tx)
		{
			bool flag = this.mNum != null;
			if (flag)
			{
				uint decimalPlaces = 1u;
				bool flag2 = tx > 10000499uL && tx < 100000000uL;
				if (flag2)
				{
					decimalPlaces = 0u;
				}
				this.mNum.set_text(UIWidgetHelp.GetLargeNumberString(tx, decimalPlaces));
			}
		}

		public void CutBtnInit(UIItemNewSlot.OnClickFunc2 func)
		{
			this.mCuntFunc = func;
		}

		public void IsSupportDown(bool isSupport)
		{
			this.SupportPressDown = isSupport;
			bool flag = this.PressCom != null;
			if (flag)
			{
				this.PressCom.SupportPressDown = this.SupportPressDown;
			}
		}

		public void GoodsTexturePixelPerfect()
		{
			bool flag = this.mUITexture != null;
			if (flag)
			{
				this.mUITexture.SetNativeSize();
			}
		}

		public void SetShowCdImage(bool isShow)
		{
			this.isShowCd = isShow;
		}

		public void SetGreyTexture(bool state)
		{
			bool flag = this.mUITexture != null;
			if (flag)
			{
				if (state)
				{
				}
			}
		}

		public void DisableClick()
		{
			Collider component = base.GetComponent<Collider>();
			component.set_enabled(false);
		}

		private IEnumerator ShowAsync(uint icon)
		{
			this.isClear = false;
			AssetResource assetResource = new AssetResource();
			DBGoodsVocationIcon dB = Singleton<DBManager>.Instance.GetDB<DBGoodsVocationIcon>();
			DBGoodsVocationIcon.DBGoodsVocationIconItem oneInfo = dB.GetOneInfo(icon);
			bool flag = oneInfo != null;
			if (flag)
			{
				icon = oneInfo.GetIconId(Singleton<LocalPlayerManager>.Instance.LocalActorAttribute.Vocation);
				this.GoodsIcon = icon;
			}
			DBGoodsEffectIcon dB2 = Singleton<DBManager>.Instance.GetDB<DBGoodsEffectIcon>();
			DBGoodsEffectIcon.DBGoodsEffectIconItem oneInfo2 = dB2.GetOneInfo(icon);
			bool flag2 = false;
			IconInfo iconInfo = null;
			bool flag3 = oneInfo2 != null;
			if (flag3)
			{
				flag2 = true;
				string asset_path = oneInfo2.EffectImagePath;
				bool flag4 = !ResourceLoader.Instance.is_exist_asset(asset_path);
				if (flag4)
				{
					asset_path = "Assets/Res/Effects/Textures/Effect_11298.png";
				}
				yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(asset_path, typeof(Texture), assetResource, true, false, ""));
				bool flag5 = this.mIsDestroy;
				if (flag5)
				{
					assetResource.destroy();
					yield break;
				}
				this.DestroyAssetRes();
				this.mAssetRes = assetResource;
				asset_path = null;
			}
			else
			{
				iconInfo = GoodsHelper.GetIconInfo(icon);
				bool flag6 = iconInfo == null;
				if (flag6)
				{
					yield break;
				}
				yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(iconInfo.MainTexturePath, typeof(Texture), assetResource, true, false, ""));
				bool flag7 = this.GoodsIcon != icon || this.mIsDestroy;
				if (flag7)
				{
					assetResource.destroy();
					yield break;
				}
				this.DestroyAssetRes();
				this.mAssetRes = assetResource;
			}
			bool flag8 = this.mUITexture == null;
			if (flag8)
			{
				yield break;
			}
			bool flag9 = this.isClear;
			if (flag9)
			{
				bool flag10 = this.mUITexture != null;
				if (flag10)
				{
					this.mUITexture.set_texture(null);
					CommonTool.SetActive(this.mUITexture.get_gameObject(), false);
				}
			}
			else
			{
				bool flag11 = this.ItemInfo == null;
				if (flag11)
				{
					this.mTextureObj = null;
					bool flag12 = this.mUITexture != null;
					if (flag12)
					{
						this.mUITexture.set_texture(null);
					}
				}
				else
				{
					bool flag13 = this.mAssetRes == null || this.mAssetRes.asset_ == null;
					if (flag13)
					{
						yield break;
					}
					this.mTextureObj = (this.mAssetRes.asset_ as Texture);
					bool flag14 = this.mUITexture != null;
					if (flag14)
					{
						this.mUITexture.set_texture(this.mTextureObj);
						bool flag15 = flag2;
						if (flag15)
						{
							UIItemNewSlot.InitEffectIconParam();
							bool flag16 = this.mUITexture_frameAnim == null && this.mUITexture != null;
							if (flag16)
							{
								this.mUITexture_frameAnim = this.mUITexture.get_gameObject().AddComponent<UGUIFrameAnimation>();
							}
							bool flag17 = this.mUITexture_frameAnim != null;
							if (flag17)
							{
								this.mUITexture_frameAnim.FrameCount = UIItemNewSlot.m_effectIcon_frame_count;
								this.mUITexture_frameAnim.OneFrameWidth = UIItemNewSlot.m_effectIcon_frame_width;
								this.mUITexture_frameAnim.OneFrameHeight = UIItemNewSlot.m_effectIcon_frame_height;
								this.mUITexture_frameAnim.RectXSpace = UIItemNewSlot.m_effectIcon_frame_rect_x;
								this.mUITexture_frameAnim.RectYSpace = UIItemNewSlot.m_effectIcon_frame_rect_y;
								this.mUITexture_frameAnim.ColNum = UIItemNewSlot.m_effectIcon_frame_col_num;
								this.mUITexture_frameAnim.FrameInterval = UIItemNewSlot.m_effectIcon_frame_interval;
								this.mUITexture_frameAnim.IsLoop = UIItemNewSlot.m_effectIcon_frame_is_loop;
								this.mUITexture_frameAnim.StartFrame = UIItemNewSlot.m_effectIcon_frame_start_frame;
								this.mUITexture_frameAnim.set_enabled(true);
								this.mUITexture_frameAnim.InitFrame(0u);
							}
							this.mUITexture.get_rectTransform().set_sizeDelta(new Vector2(55f, 55f));
						}
						else
						{
							bool flag18 = this.mUITexture_frameAnim != null;
							if (flag18)
							{
								this.mUITexture_frameAnim.set_enabled(false);
							}
							bool flag19 = iconInfo != null;
							if (flag19)
							{
								this.mUITexture.set_uvRect(iconInfo.IconRect);
							}
							this.mUITexture.get_rectTransform().set_sizeDelta(new Vector2(80f, 80f));
						}
						CommonTool.SetActive(this.mUITexture.get_gameObject(), true);
						bool flag20 = !this.mUITexture.get_enabled();
						if (flag20)
						{
							this.mUITexture.set_enabled(true);
						}
					}
				}
			}
			yield break;
		}

		private void CheckCdTime()
		{
			this.NowFill = 0f;
			this.Times = 0f;
			bool flag = this.mCdtexSpr != null && this.ItemInfo != null && this.isShowCd;
			if (flag)
			{
				uint startCd = 0u;
				bool flag2 = ItemManager.Instance.GoodsCd.TryGetValue(this.ItemInfo.cd_id, out startCd);
				if (flag2)
				{
					this.StartCd = startCd;
					uint num = 10u;
					GoodsInfo goodsInfo = GoodsHelper.GetGoodsInfo(this.ItemInfo.type_idx);
					bool flag3 = goodsInfo != null;
					if (flag3)
					{
						num = (uint)goodsInfo.use_cd;
					}
					this.EndCd = this.StartCd + num;
					bool flag4 = this.EndCd > 0u;
					if (flag4)
					{
						uint serverTime = Game.GetInstance().ServerTime;
						bool flag5 = this.EndCd > serverTime && serverTime >= this.StartCd;
						if (flag5)
						{
							uint num2 = this.EndCd - this.StartCd;
							uint num3 = serverTime - this.StartCd;
							this.DetalTime = num2;
							CommonTool.SetActive(this.mCdtexSpr.get_gameObject(), true);
							float num4 = num3 / num2;
							this.NowFill = 1f - num4;
							this.mCdtexSpr.set_fillAmount(this.NowFill);
							this.is_CD = true;
						}
						else
						{
							this.is_CD = false;
							CommonTool.SetActive(this.mCdtexSpr.get_gameObject(), false);
							this.mCdtexSpr.set_fillAmount(0f);
						}
					}
				}
			}
		}

		public void SetUI()
		{
			this.Check();
			this.OnBagUpdate(null);
			CommonTool.SetActive(this.SelectWid, false);
			bool flag = this.ItemInfo == null;
			if (!flag)
			{
				this.CheckCdTime();
				bool flag2 = this.GoodsIcon != this.ItemInfo.icon_id;
				if (flag2)
				{
					this.GoodsIcon = this.ItemInfo.icon_id;
					this.RefreshCircleBkgVisiable();
					Singleton<UIManager>.Instance.MainCtrl.StartCoroutine(this.ShowAsync(this.ItemInfo.icon_id));
				}
				foreach (KeyValuePair<uint, GameObject> current in this.Effects)
				{
					CommonTool.SetActive(current.Value, false);
				}
				CommonTool.SetActive(this.mExpJadeEffect, false);
				bool flag3 = this.ItemInfo.color_type >= 3u;
				if (flag3)
				{
					bool flag4 = this.mQualityTexArray != null && this.mQualityTex != null;
					if (flag4)
					{
						Texture texture = this.mQualityTexArray.LoadTexture((int)(this.ItemInfo.color_type - 1u));
						bool flag5 = this.mQualityTex.get_texture() != texture;
						if (flag5)
						{
							this.mQualityTex.set_texture(texture);
						}
					}
					CommonTool.SetActive(this.mQualityEffect, true);
				}
				else
				{
					CommonTool.SetActive(this.mQualityEffect, false);
				}
				CommonTool.SetActive(this.mQualityEffect2, false);
				bool flag6 = this.mNum != null;
				if (flag6)
				{
					bool flag7 = !this.mIsCostItem;
					if (flag7)
					{
						bool flag8 = this.ItemInfo.num > 1uL;
						if (flag8)
						{
							uint decimalPlaces = 1u;
							bool flag9 = this.ItemInfo.num > 10000499uL && this.ItemInfo.num < 100000000uL;
							if (flag9)
							{
								decimalPlaces = 0u;
							}
							this.mNum.set_text(UIWidgetHelp.GetLargeNumberString(this.ItemInfo.num, decimalPlaces) ?? "");
						}
						else
						{
							this.mNum.set_text("");
						}
					}
					else
					{
						this.RefreshCost();
					}
				}
				bool flag10 = this.ItemInfo.bind == 0u;
				if (flag10)
				{
					CommonTool.SetActive(this.mBindObj, false);
				}
				else
				{
					CommonTool.SetActive(this.mBindObj, true);
				}
				bool flag11 = this.mEquippedSprite != null;
				if (flag11)
				{
					bool flag12 = ItemManager.Instance.InstallEquip.ContainsKey(this.ItemInfo.id);
					if (flag12)
					{
						CommonTool.SetActive(this.mEquippedSprite.get_gameObject(), true);
					}
					else
					{
						CommonTool.SetActive(this.mEquippedSprite.get_gameObject(), false);
					}
				}
				bool flag13 = this.ItemInfo.expire_time != 0u && this.ItemInfo.expire_time < Game.Instance.ServerTime;
				if (flag13)
				{
					CommonTool.SetActive(this.mExpiredObj, true);
				}
				else
				{
					CommonTool.SetActive(this.mExpiredObj, false);
				}
				bool flag14 = this.mDisEnableSpr != null;
				if (flag14)
				{
					CommonTool.SetActive(this.mDisEnableSpr.get_gameObject(), !this.CheckCanUse());
				}
				bool flag15 = this.mEquipUpSpr != null;
				if (flag15)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag16 = this.mEquipDownSpr != null;
				if (flag16)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
				bool flag17 = this.mFrameSpr != null;
				if (flag17)
				{
					CommonTool.SetActive(this.mFrameSpr.get_gameObject(), this.m_IsFrameSprShow);
				}
				bool flag18 = this.mCircleBkg != null;
				if (flag18)
				{
					CommonTool.SetActive(this.mCircleBkg.get_gameObject(), this.m_IsCircleBkgShow);
				}
				bool flag19 = this.m_IsQualitySprShow && this.mQualityImage != null;
				if (flag19)
				{
					int color_type = (int)this.ItemInfo.color_type;
					string text = "MainWindow_New@Common@GoodsQuality_" + color_type;
					Sprite sprite = this.mQualityImage.get_sprite();
					bool flag20 = sprite == null || sprite.get_name() != text;
					if (flag20)
					{
						bool flag21 = this.mQualityArray != null;
						if (flag21)
						{
							this.mQualityImage.set_sprite(this.mQualityArray.LoadSprite(text));
						}
					}
				}
				CommonTool.SetActive(this.mQualityObject, this.m_IsQualitySprShow);
				bool flag22 = this.ItemInfo is GoodsEquip || this.ItemInfo is GoodsMagicEquip || this.ItemInfo is GoodsDecorate;
				if (flag22)
				{
					bool flag23 = this.ItemInfo is GoodsEquip;
					int num;
					if (flag23)
					{
						num = EquipHelper.GetStarAddEquip(this.ItemInfo as GoodsEquip);
					}
					else
					{
						bool flag24 = this.ItemInfo is GoodsDecorate;
						if (flag24)
						{
							num = (int)DecorateHelper.GetDecorateStar(this.ItemInfo as GoodsDecorate);
						}
						else
						{
							num = (int)(this.ItemInfo as GoodsMagicEquip).Star;
						}
					}
					int num2;
					for (int i = 0; i < this.LegendAttrs.Count; i = num2 + 1)
					{
						CommonTool.SetActive(this.LegendAttrs[i], false);
						num2 = i;
					}
					bool flag25 = num > this.LegendAttrs.Count;
					if (flag25)
					{
						num = this.LegendAttrs.Count;
					}
					for (int j = 0; j < num; j = num2 + 1)
					{
						CommonTool.SetActive(this.LegendAttrs[j], true);
						num2 = j;
					}
				}
				else
				{
					int num2;
					for (int k = 0; k < this.LegendAttrs.Count; k = num2 + 1)
					{
						CommonTool.SetActive(this.LegendAttrs[k], false);
						num2 = k;
					}
				}
				this.mCheckImage = UIHelper.FindChild(base.get_transform(), "CheckImage");
				CommonTool.SetActive(this.mCheckImage, this.mShowCheckImage);
				bool active = this.ItemInfo.main_type == 1u && this.ItemInfo.sub_type == 7u;
				CommonTool.SetActive(this.mFashionBg, active);
				bool flag26 = this.mEquipLvStepText != null;
				if (flag26)
				{
					bool flag27 = this.ItemInfo != null && this.ItemInfo is GoodsEquip;
					if (flag27)
					{
						CommonTool.SetActive(this.mEquipLvStepText.get_gameObject(), true);
						uint lvStep = (this.ItemInfo as GoodsEquip).LvStep;
						this.mEquipLvStepText.set_text(string.Format(DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), lvStep));
					}
					else
					{
						bool flag28 = this.ItemInfo != null && this.ItemInfo is GoodsMountEquip;
						if (flag28)
						{
							CommonTool.SetActive(this.mEquipLvStepText.get_gameObject(), true);
							this.mEquipLvStepText.set_text(string.Format(DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), (this.ItemInfo as GoodsMountEquip).lv_step));
						}
						else
						{
							bool flag29 = this.ItemInfo.show_step > 0u;
							if (flag29)
							{
								CommonTool.SetActive(this.mEquipLvStepText.get_gameObject(), true);
								this.mEquipLvStepText.set_text(string.Format(DBConstText.GetText("GAME_GOODS_LV_STEP_FORMAT"), this.ItemInfo.show_step));
							}
							else
							{
								CommonTool.SetActive(this.mEquipLvStepText.get_gameObject(), false);
							}
						}
					}
				}
				bool flag30 = this.mDiscount != null;
				if (flag30)
				{
					bool flag31 = this.ItemInfo.discount > 0u && this.ItemInfo.discount < 10u && this.mSpriteList != null && this.mDiscountImage != null;
					if (flag31)
					{
						Sprite sprite2 = this.mSpriteList.LoadSprite("Mainwindow@Discount_" + this.ItemInfo.discount);
						bool flag32 = sprite2 != null;
						if (flag32)
						{
							this.mDiscountImage.set_sprite(sprite2);
							CommonTool.SetActive(this.mDiscount, true);
						}
						else
						{
							CommonTool.SetActive(this.mDiscount, false);
						}
					}
					else
					{
						CommonTool.SetActive(this.mDiscount, false);
					}
				}
				this.RefreshExpireTime();
				this.RefreshOverdueNotice();
				bool flag33 = this.ItemInfo is GoodsLuaEx;
				if (flag33)
				{
					(this.ItemInfo as GoodsLuaEx).SetItemSlot(base.get_gameObject());
				}
			}
		}

		public void RefreshExpireTime()
		{
			bool flag = this.mExpireTimeObj == null;
			if (!flag)
			{
				bool flag2 = this.ItemInfo == null;
				if (flag2)
				{
					this.mShowExpireTime = false;
				}
				else
				{
					bool flag3 = this.ItemInfo.IsInEnableTime();
					if (flag3)
					{
						this.mShowExpireTime = false;
					}
					else
					{
						this.mShowExpireTime = true;
					}
				}
				CommonTool.SetActive(this.mExpireTimeObj, this.mShowExpireTime);
			}
		}

		public void RefreshOverdueNotice()
		{
			bool flag = this.mOverdueNotice == null;
			if (!flag)
			{
				bool flag2 = this.ItemInfo == null;
				bool active;
				if (flag2)
				{
					active = false;
				}
				else
				{
					bool flag3 = this.ItemInfo.expire_time == 0u || this.ItemInfo.overdue_notice_time == 0u;
					if (flag3)
					{
						active = false;
					}
					else
					{
						bool flag4 = this.ItemInfo.expire_time > Game.Instance.ServerTime && Game.Instance.ServerTime > this.ItemInfo.expire_time - this.ItemInfo.overdue_notice_time;
						active = flag4;
					}
				}
				CommonTool.SetActive(this.mOverdueNotice, active);
			}
		}

		public void SetColor(bool isShow)
		{
			bool flag = this.ItemInfo == null;
			if (!flag)
			{
				CommonTool.SetActive(this.mQualityObject, isShow);
				this.m_IsQualitySprShow = isShow;
			}
		}

		public void setItemInfo(uint goodsId, UIItemNewSlot.TypeParse parse)
		{
			Goods itemInfo = GoodsFactory.Create(goodsId, null);
			this.setItemInfo(itemInfo, parse);
		}

		public void setItemInfoByNum(uint goodsId, ulong num, UIItemNewSlot.TypeParse parse)
		{
			Goods goods = GoodsFactory.Create(goodsId, null);
			goods.num = num;
			this.setItemInfo(goods, parse);
		}

		public void setItemInfo(uint goodsId, uint bind, UIItemNewSlot.TypeParse parse)
		{
			Goods goods = GoodsFactory.Create(goodsId, null);
			goods.bind = bind;
			this.setItemInfo(goods, parse);
		}

		public void setItemInfo(Goods itemInfo, UIItemNewSlot.TypeParse parse, uint needNum, string windowName, int maxDepth)
		{
			this.CurrentWindow = windowName;
			this.CurrentWindowDepth = maxDepth + 1;
			this.mNeedNum = needNum;
			this.setItemInfo(itemInfo, parse);
		}

		public void setItemInfo(Goods itemInfo, UIItemNewSlot.TypeParse parse)
		{
			this.ItemInfo = itemInfo;
			this.mOtherNum = parse._mNum;
			this.mShowType = parse._mType;
			this.mFunc = parse._mFunc;
			this.mFunc1 = parse._mFunc1;
			this.mFunc2 = parse._mFunc2;
			this.mGrade = parse._mGrade;
			this.mCustomFunc = parse._mCustomFunc;
			this.mParam = parse._mParam;
			this.SetUI();
		}

		public void setItemInfo(Goods itemInfo, UIItemNewSlot.TypeParse parse, bool IsScale)
		{
			this.ItemInfo = itemInfo;
			this.mOtherNum = parse._mNum;
			this.mShowType = parse._mType;
			this.mFunc = parse._mFunc;
			this.mFunc1 = parse._mFunc1;
			this.mFunc2 = parse._mFunc2;
			this.mGrade = parse._mGrade;
			this.SetUI();
		}

		public void ShowEquippedIcon(bool show)
		{
			bool flag = this.mEquippedSprite != null;
			if (flag)
			{
				CommonTool.SetActive(this.mEquippedSprite.get_gameObject(), show);
			}
		}

		public static UIItemNewSlot.TypeParse CreateUIItemTypeParse(int type = 0)
		{
			UIItemNewSlot.TypeParse result;
			result._mType = type;
			result._mNum = 0;
			result._mGrade = 0u;
			result._mFunc1 = null;
			result._mFunc = null;
			result._mFunc2 = null;
			result._mCustomFunc = null;
			result._mParam = null;
			return result;
		}

		public void IsShowEquipUp(bool show)
		{
			bool flag = this.mEquipUpSpr != null;
			if (flag)
			{
				CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), show);
			}
		}

		private bool CheckCanUse()
		{
			bool flag = this.mCanNotUse;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint vocation = this.mVocation;
				bool flag2 = vocation == 0u && Singleton<LocalPlayerManager>.Instance.LocalActorAttribute != null;
				if (flag2)
				{
					vocation = Singleton<LocalPlayerManager>.Instance.LocalActorAttribute.Vocation;
				}
				bool flag3 = this.ItemInfo == null;
				if (flag3)
				{
					result = true;
				}
				else
				{
					bool flag4 = !(this.ItemInfo is GoodsEquip) || this.ItemInfo.use_job == 0u || this.ItemInfo.use_job == vocation;
					result = flag4;
				}
			}
			return result;
		}

		public void MatchMountEquip(GoodsMountEquip mountEquip)
		{
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
				if (activeSelf)
				{
					bool flag2 = this.mEquipUpSpr != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
					}
					bool flag3 = this.mEquipDownSpr != null;
					if (flag3)
					{
						CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
					}
				}
				else
				{
					bool flag4 = this.ItemInfo is GoodsMountEquip;
					if (flag4)
					{
						GoodsMountEquip goodsMountEquip = this.ItemInfo as GoodsMountEquip;
						bool flag5 = mountEquip == null;
						if (flag5)
						{
							bool flag6 = this.mEquipUpSpr != null;
							if (flag6)
							{
								CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
							}
						}
						else
						{
							bool flag7 = goodsMountEquip.Score > mountEquip.Score;
							if (flag7)
							{
								bool flag8 = this.mEquipUpSpr != null;
								if (flag8)
								{
									CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
								}
								bool flag9 = this.mEquipDownSpr != null;
								if (flag9)
								{
									CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
								}
							}
							else
							{
								bool flag10 = goodsMountEquip.Score < mountEquip.Score;
								if (flag10)
								{
									bool flag11 = this.mEquipUpSpr != null;
									if (flag11)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag12 = this.mEquipDownSpr != null;
									if (flag12)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), true);
									}
								}
								else
								{
									bool flag13 = this.mEquipUpSpr != null;
									if (flag13)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag14 = this.mEquipDownSpr != null;
									if (flag14)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
									}
								}
							}
						}
					}
					else
					{
						bool flag15 = this.mEquipUpSpr != null;
						if (flag15)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
						}
						bool flag16 = this.mEquipDownSpr != null;
						if (flag16)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
						}
					}
				}
			}
			else
			{
				bool flag17 = this.mEquipUpSpr != null;
				if (flag17)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag18 = this.mEquipDownSpr != null;
				if (flag18)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
		}

		public void MatchDecorate(GoodsDecorate decorate)
		{
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
				if (activeSelf)
				{
					bool flag2 = this.mEquipUpSpr != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
					}
					bool flag3 = this.mEquipDownSpr != null;
					if (flag3)
					{
						CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
					}
				}
				else
				{
					bool flag4 = this.ItemInfo is GoodsDecorate;
					if (flag4)
					{
						GoodsDecorate goodsDecorate = this.ItemInfo as GoodsDecorate;
						bool flag5 = (Singleton<LocalPlayerManager>.Instance.LocalActorAttribute.Vocation != goodsDecorate.use_job && goodsDecorate.use_job != 0u) || !goodsDecorate.can_use;
						if (flag5)
						{
							bool flag6 = this.mEquipUpSpr != null;
							if (flag6)
							{
								CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
							}
							bool flag7 = this.mEquipDownSpr != null;
							if (flag7)
							{
								CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
							}
						}
						else
						{
							bool flag8 = decorate == null;
							if (flag8)
							{
								bool flag9 = this.mEquipUpSpr != null;
								if (flag9)
								{
									CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
								}
							}
							else
							{
								bool flag10 = goodsDecorate.BaseScore > decorate.BaseScore;
								if (flag10)
								{
									bool flag11 = this.mEquipUpSpr != null;
									if (flag11)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
									}
									bool flag12 = this.mEquipDownSpr != null;
									if (flag12)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
									}
								}
								else
								{
									bool flag13 = goodsDecorate.BaseScore < decorate.BaseScore;
									if (flag13)
									{
										bool flag14 = this.mEquipUpSpr != null;
										if (flag14)
										{
											CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
										}
										bool flag15 = this.mEquipDownSpr != null;
										if (flag15)
										{
											CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), true);
										}
									}
									else
									{
										bool flag16 = this.mEquipUpSpr != null;
										if (flag16)
										{
											CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
										}
										bool flag17 = this.mEquipDownSpr != null;
										if (flag17)
										{
											CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
										}
									}
								}
							}
						}
					}
					else
					{
						bool flag18 = this.mEquipUpSpr != null;
						if (flag18)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
						}
						bool flag19 = this.mEquipDownSpr != null;
						if (flag19)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
						}
					}
				}
			}
			else
			{
				bool flag20 = this.mEquipUpSpr != null;
				if (flag20)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag21 = this.mEquipDownSpr != null;
				if (flag21)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
		}

		public void MatchMagicEquip(GoodsMagicEquip magicEquip)
		{
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
				if (activeSelf)
				{
					bool flag2 = this.mEquipUpSpr != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
					}
					bool flag3 = this.mEquipDownSpr != null;
					if (flag3)
					{
						CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
					}
				}
				else
				{
					bool flag4 = this.ItemInfo is GoodsMagicEquip;
					if (flag4)
					{
						GoodsMagicEquip goodsMagicEquip = this.ItemInfo as GoodsMagicEquip;
						bool flag5 = (Singleton<LocalPlayerManager>.Instance.LocalActorAttribute.Vocation != goodsMagicEquip.use_job && goodsMagicEquip.use_job != 0u) || !goodsMagicEquip.can_use;
						if (flag5)
						{
							bool flag6 = this.mEquipUpSpr != null;
							if (flag6)
							{
								CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
							}
							bool flag7 = this.mEquipDownSpr != null;
							if (flag7)
							{
								CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
							}
						}
						else
						{
							bool flag8 = magicEquip == null;
							if (flag8)
							{
								bool flag9 = this.mEquipUpSpr != null;
								if (flag9)
								{
									CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
								}
							}
							else
							{
								bool flag10 = goodsMagicEquip.BaseScore > magicEquip.BaseScore;
								if (flag10)
								{
									bool flag11 = this.mEquipUpSpr != null;
									if (flag11)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
									}
									bool flag12 = this.mEquipDownSpr != null;
									if (flag12)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
									}
								}
								else
								{
									bool flag13 = goodsMagicEquip.BaseScore < magicEquip.BaseScore;
									if (flag13)
									{
										bool flag14 = this.mEquipUpSpr != null;
										if (flag14)
										{
											CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
										}
										bool flag15 = this.mEquipDownSpr != null;
										if (flag15)
										{
											CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), true);
										}
									}
									else
									{
										bool flag16 = this.mEquipUpSpr != null;
										if (flag16)
										{
											CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
										}
										bool flag17 = this.mEquipDownSpr != null;
										if (flag17)
										{
											CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
										}
									}
								}
							}
						}
					}
					else
					{
						bool flag18 = this.mEquipUpSpr != null;
						if (flag18)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
						}
						bool flag19 = this.mEquipDownSpr != null;
						if (flag19)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
						}
					}
				}
			}
			else
			{
				bool flag20 = this.mEquipUpSpr != null;
				if (flag20)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag21 = this.mEquipDownSpr != null;
				if (flag21)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
		}

		public void MatchGoodsLightWeaponSoul(GoodsLightWeaponSoul LightWeaponSoul)
		{
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
				if (activeSelf)
				{
					bool flag2 = this.mEquipUpSpr != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
					}
					bool flag3 = this.mEquipDownSpr != null;
					if (flag3)
					{
						CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
					}
				}
				else
				{
					bool flag4 = this.ItemInfo is GoodsLightWeaponSoul;
					if (flag4)
					{
						GoodsLightWeaponSoul goodsLightWeaponSoul = this.ItemInfo as GoodsLightWeaponSoul;
						bool flag5 = LightWeaponSoul == null;
						if (flag5)
						{
							bool flag6 = this.mEquipUpSpr != null;
							if (flag6)
							{
								CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
							}
						}
						else
						{
							bool flag7 = goodsLightWeaponSoul.Score > LightWeaponSoul.Score;
							if (flag7)
							{
								bool flag8 = this.mEquipUpSpr != null;
								if (flag8)
								{
									CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
								}
								bool flag9 = this.mEquipDownSpr != null;
								if (flag9)
								{
									CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
								}
							}
							else
							{
								bool flag10 = goodsLightWeaponSoul.Score < LightWeaponSoul.Score;
								if (flag10)
								{
									bool flag11 = this.mEquipUpSpr != null;
									if (flag11)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag12 = this.mEquipDownSpr != null;
									if (flag12)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), true);
									}
								}
								else
								{
									bool flag13 = this.mEquipUpSpr != null;
									if (flag13)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag14 = this.mEquipDownSpr != null;
									if (flag14)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
									}
								}
							}
						}
					}
					else
					{
						bool flag15 = this.mEquipUpSpr != null;
						if (flag15)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
						}
						bool flag16 = this.mEquipDownSpr != null;
						if (flag16)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
						}
					}
				}
			}
			else
			{
				bool flag17 = this.mEquipUpSpr != null;
				if (flag17)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag18 = this.mEquipDownSpr != null;
				if (flag18)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
		}

		public static bool IsBetterEquip(GoodsEquip equip1, GoodsEquip equip2, uint player_vocation)
		{
			bool flag = equip2 == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = equip2.use_job != 0u && equip2.use_job != player_vocation;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = equip1 == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = equip1.EquipRank >= equip2.EquipRank;
						result = !flag4;
					}
				}
			}
			return result;
		}

		public void RefreshMatch(Goods matchGoods = null)
		{
			bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
			if (activeSelf)
			{
				bool flag = this.mEquipUpSpr != null;
				if (flag)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag2 = this.mEquipDownSpr != null;
				if (flag2)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
			else
			{
				bool flag3 = this.ItemInfo != null;
				if (flag3)
				{
					bool flag4 = this.ItemInfo is GoodsLuaEx;
					if (flag4)
					{
						(this.ItemInfo as GoodsLuaEx).RefreshMatch(matchGoods, base.get_gameObject());
					}
					else
					{
						bool flag5 = this.mEquipUpSpr != null;
						if (flag5)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), this.ItemInfo.is_equipUp);
						}
						bool flag6 = this.mEquipDownSpr != null;
						if (flag6)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), this.ItemInfo.is_equipDown);
						}
					}
				}
			}
		}

		public void MatchEquip(GoodsEquip equip)
		{
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				bool activeSelf = this.mDisEnableSpr.get_gameObject().get_activeSelf();
				if (activeSelf)
				{
					bool flag2 = this.mEquipUpSpr != null;
					if (flag2)
					{
						CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
					}
					bool flag3 = this.mEquipDownSpr != null;
					if (flag3)
					{
						CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
					}
				}
				else
				{
					bool flag4 = this.ItemInfo is GoodsEquip;
					if (flag4)
					{
						GoodsEquip goodsEquip = this.ItemInfo as GoodsEquip;
						goodsEquip.is_equipDown = false;
						goodsEquip.is_equipUp = false;
						bool flag5 = Singleton<LocalPlayerManager>.Instance.LocalActorAttribute.Vocation != goodsEquip.use_job && goodsEquip.use_job > 0u;
						if (flag5)
						{
							bool flag6 = this.mEquipUpSpr != null;
							if (flag6)
							{
								CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
							}
							bool flag7 = this.mEquipDownSpr != null;
							if (flag7)
							{
								CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
							}
						}
						else
						{
							int num = goodsEquip.EquipRank;
							int num2 = 0;
							bool flag8 = equip != null;
							if (flag8)
							{
								num2 = equip.EquipRank;
							}
							bool flag9 = !goodsEquip.IsInEnableTime();
							if (flag9)
							{
								num = 0;
							}
							bool flag10 = equip != null && !equip.IsInEnableTime();
							if (flag10)
							{
								num2 = 0;
							}
							bool flag11 = num > num2;
							if (flag11)
							{
								goodsEquip.is_equipUp = true;
								bool flag12 = this.mEquipUpSpr != null;
								if (flag12)
								{
									CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), true);
								}
								bool flag13 = this.mEquipDownSpr != null;
								if (flag13)
								{
									CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
								}
							}
							else
							{
								bool flag14 = num < num2;
								if (flag14)
								{
									goodsEquip.is_equipDown = true;
									bool flag15 = this.mEquipUpSpr != null;
									if (flag15)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag16 = this.mEquipDownSpr != null;
									if (flag16)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), true);
									}
								}
								else
								{
									bool flag17 = this.mEquipUpSpr != null;
									if (flag17)
									{
										CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
									}
									bool flag18 = this.mEquipDownSpr != null;
									if (flag18)
									{
										CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
									}
								}
							}
						}
					}
					else
					{
						this.ItemInfo.is_equipDown = false;
						this.ItemInfo.is_equipUp = false;
						bool flag19 = this.mEquipUpSpr != null;
						if (flag19)
						{
							CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
						}
						bool flag20 = this.mEquipDownSpr != null;
						if (flag20)
						{
							CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
						}
					}
				}
			}
			else
			{
				bool flag21 = this.mEquipUpSpr != null;
				if (flag21)
				{
					CommonTool.SetActive(this.mEquipUpSpr.get_gameObject(), false);
				}
				bool flag22 = this.mEquipDownSpr != null;
				if (flag22)
				{
					CommonTool.SetActive(this.mEquipDownSpr.get_gameObject(), false);
				}
			}
		}

		public void IsSelect(bool show)
		{
			CommonTool.SetActive(this.SelectWid, show);
		}

		protected void Check()
		{
			this.RealGameobj = base.get_gameObject();
			Transform transform = base.get_transform().Find("ItemNode");
			bool flag = transform == null;
			if (!flag)
			{
				bool flag2 = this.NoNum == null;
				if (flag2)
				{
					Transform transform2 = transform.Find("NoNum");
					bool flag3 = transform2 != null;
					if (flag3)
					{
						this.NoNum = transform2.get_gameObject();
						Button component = this.NoNum.GetComponent<Button>();
						bool flag4 = component != null;
						if (flag4)
						{
							component.get_onClick().RemoveAllListeners();
							component.get_onClick().AddListener(new UnityAction(this.OnClickNoNum));
						}
						CommonTool.SetActive(this.NoNum, false);
					}
				}
				bool flag5 = this.SelectWid == null;
				if (flag5)
				{
					Transform transform2 = transform.Find("Select");
					bool flag6 = transform2 != null;
					if (flag6)
					{
						this.SelectWid = transform2.get_gameObject();
						CommonTool.SetActive(this.SelectWid, false);
					}
				}
				bool flag7 = this.EffectRoot == null;
				if (flag7)
				{
					Transform transform2 = transform.Find("Effects");
					bool flag8 = transform2 != null;
					if (flag8)
					{
						this.EffectRoot = transform2.get_gameObject();
					}
				}
				bool flag9 = this.EffectRoot != null;
				if (flag9)
				{
					Transform transform3 = this.EffectRoot.get_transform();
					bool flag10 = this.mQualityEffect == null;
					if (flag10)
					{
						Transform transform2 = transform3.Find("frame");
						bool flag11 = transform2 != null;
						if (flag11)
						{
							this.mQualityEffect = transform2.get_gameObject();
						}
						transform2 = transform3.Find("frameExpJade");
						bool flag12 = transform2 != null;
						if (flag12)
						{
							this.mExpJadeEffect = transform2.get_gameObject();
						}
						bool flag13 = this.mQualityEffect != null;
						if (flag13)
						{
							this.mQualityTexArray = this.mQualityEffect.GetComponent<TextureArray>();
						}
						bool flag14 = this.mQualityEffect != null;
						if (flag14)
						{
							this.mQualityTex = this.mQualityEffect.GetComponent<RawImage>();
						}
					}
					bool flag15 = this.mQualityEffect2 == null;
					if (flag15)
					{
						Transform transform2 = transform3.Find("frame1");
						bool flag16 = transform2 != null;
						if (flag16)
						{
							this.mQualityEffect2 = transform2.get_gameObject();
						}
						bool flag17 = this.mQualityEffect2 != null;
						if (flag17)
						{
							this.mQualityTexArray2 = this.mQualityEffect2.GetComponent<TextureArray>();
						}
						bool flag18 = this.mQualityEffect2 != null;
						if (flag18)
						{
							this.mQualityTex2 = this.mQualityEffect2.GetComponent<RawImage>();
						}
					}
				}
				bool flag19 = this.mCdtexSpr == null;
				if (flag19)
				{
					Transform transform2 = transform.Find("CDImage");
					bool flag20 = transform2 != null;
					if (flag20)
					{
						this.mCdtexSpr = transform2.GetComponent<Image>();
						CommonTool.SetActive(this.mCdtexSpr.get_gameObject(), false);
					}
				}
				bool flag21 = this.mUITexture == null;
				if (flag21)
				{
					Transform transform2 = transform.Find("GoodsRawImage");
					bool flag22 = transform2 != null;
					if (flag22)
					{
						this.mUITexture = transform2.GetComponent<RawImage>();
						this.mUITexture_frameAnim = transform2.GetComponent<UGUIFrameAnimation>();
					}
				}
				bool flag23 = this.mNum == null;
				if (flag23)
				{
					Transform transform2 = transform.Find("QuantityText");
					bool flag24 = transform2 != null;
					if (flag24)
					{
						this.mNum = transform2.GetComponent<Text>();
					}
				}
				bool flag25 = this.mBindObj == null;
				if (flag25)
				{
					Transform transform2 = transform.Find("LockImage");
					bool flag26 = transform2 != null;
					if (flag26)
					{
						this.mBindObj = transform2.get_gameObject();
					}
				}
				bool flag27 = this.mFrameSpr == null;
				if (flag27)
				{
					Transform transform2 = transform.Find("BgImage");
					bool flag28 = transform2 != null;
					if (flag28)
					{
						this.mFrameSpr = transform2.GetComponent<Image>();
					}
				}
				bool flag29 = this.mCircleBkg == null;
				if (flag29)
				{
					Transform transform2 = transform.Find("CircleBkg");
					bool flag30 = transform2 != null;
					if (flag30)
					{
						this.mCircleBkg = transform2.GetComponent<Image>();
					}
				}
				bool flag31 = this.mQualityObject == null;
				if (flag31)
				{
					Transform transform2 = transform.Find("QualityImage");
					bool flag32 = transform2 != null;
					if (flag32)
					{
						this.mQualityObject = transform2.get_gameObject();
						this.mQualityImage = transform2.GetComponent<Image>();
						this.mQualityArray = transform2.GetComponent<SpriteArray>();
					}
				}
				bool flag33 = this.LegendAttrs.Count == 0;
				if (flag33)
				{
					int num;
					for (int i = 1; i <= 4; i = num + 1)
					{
						Transform transform2 = transform.Find(string.Format("LegendImage_{0}", i));
						bool flag34 = transform2 != null;
						if (flag34)
						{
							this.LegendAttrs.Add(transform2.get_gameObject());
						}
						num = i;
					}
				}
				bool flag35 = this.mEquipUpSpr == null;
				if (flag35)
				{
					Transform transform2 = transform.Find("BetterImage");
					bool flag36 = transform2 != null;
					if (flag36)
					{
						this.mEquipUpSpr = transform2.GetComponent<Image>();
					}
				}
				bool flag37 = this.mEquipDownSpr == null;
				if (flag37)
				{
					Transform transform2 = transform.Find("InferiorImage");
					bool flag38 = transform2 != null;
					if (flag38)
					{
						this.mEquipDownSpr = transform2.GetComponent<Image>();
					}
				}
				bool flag39 = this.mDisEnableSpr == null;
				if (flag39)
				{
					Transform transform2 = transform.Find("UnavailImage");
					bool flag40 = transform2 != null;
					if (flag40)
					{
						this.mDisEnableSpr = transform2.GetComponent<Image>();
					}
				}
				bool flag41 = this.mEquippedSprite == null;
				if (flag41)
				{
					Transform transform2 = transform.Find("AdornImage");
					bool flag42 = transform2 != null;
					if (flag42)
					{
						this.mEquippedSprite = transform2.GetComponent<Image>();
						CommonTool.SetActive(this.mEquippedSprite.get_gameObject(), false);
					}
				}
				bool flag43 = this.ItemButton == null;
				if (flag43)
				{
					this.ItemButton = this.RealGameobj.GetComponent<Button>();
					this.PressCom = this.RealGameobj.GetComponent<ComTouchPress>();
					bool flag44 = this.PressCom == null;
					if (flag44)
					{
						this.PressCom = this.RealGameobj.AddComponent<ComTouchPress>();
						this.PressCom.Init(new ComTouchPress.OnPress(this.OnPressCallBack), null);
					}
					bool flag45 = this.ItemButton != null;
					if (flag45)
					{
						this.ItemButton.get_onClick().RemoveAllListeners();
						this.ItemButton.get_onClick().AddListener(new UnityAction(this.OnClickGoodsBtn));
					}
				}
				bool flag46 = this.mTitleDesc == null;
				if (flag46)
				{
					Transform transform2 = transform.Find("TitleDesc");
					bool flag47 = transform2 != null;
					if (flag47)
					{
						this.mTitleDesc = transform2.GetComponent<Text>();
					}
				}
				bool flag48 = this.mExpireTimeObj == null;
				if (flag48)
				{
					Transform transform2 = transform.Find("ExpireTime");
					bool flag49 = transform2 != null;
					if (flag49)
					{
						this.mExpireTimeObj = transform2.get_gameObject();
					}
				}
				bool flag50 = this.mEquipLvStepText == null;
				if (flag50)
				{
					Transform transform2 = transform.Find("EquipLvStepText");
					bool flag51 = transform2 != null;
					if (flag51)
					{
						this.mEquipLvStepText = transform2.GetComponent<Text>();
					}
				}
				bool flag52 = this.mFashionBg == null;
				if (flag52)
				{
					Transform transform2 = transform.Find("FashionBg");
					bool flag53 = transform2 != null;
					if (flag53)
					{
						this.mFashionBg = transform2.get_gameObject();
					}
				}
				bool flag54 = this.mSpriteList == null;
				if (flag54)
				{
					Transform transform2 = transform.Find("SpriteList");
					bool flag55 = transform2 != null;
					if (flag55)
					{
						this.mSpriteList = transform2.GetComponent<SpriteList>();
					}
				}
				bool flag56 = this.mDiscount == null;
				if (flag56)
				{
					Transform transform2 = transform.Find("Discount");
					bool flag57 = transform2 != null;
					if (flag57)
					{
						this.mDiscount = transform2.get_gameObject();
						transform2 = transform2.Find("DiscountImage");
						this.mDiscountImage = transform2.GetComponent<Image>();
					}
					CommonTool.SetActive(this.mDiscount, false);
				}
				bool flag58 = this.mOverdueNotice == null;
				if (flag58)
				{
					Transform transform2 = transform.Find("Overdue");
					bool flag59 = transform2 != null;
					if (flag59)
					{
						this.mOverdueNotice = transform2.get_gameObject();
					}
					CommonTool.SetActive(this.mOverdueNotice, false);
				}
				this.RefreshCost();
			}
		}

		protected void Awake()
		{
			this.AddListeners();
			this.Check();
		}

		protected void OnEnable()
		{
			this.AddListeners();
		}

		private void OnDisable()
		{
			this.RemoveListeners();
		}

		private void RemoveListeners()
		{
			bool flag = !this.isListenersInit;
			if (!flag)
			{
				this.isListenersInit = false;
				Singleton<ClientEventMgr>.GetInstance().UnsubscribeClientEvent(21, new ClientEventMgr.ClientEventFunc(this.OnServerTimeChange));
				Singleton<ClientEventMgr>.GetInstance().UnsubscribeClientEvent(191, new ClientEventMgr.ClientEventFunc(this.OnBagUpdate));
				Singleton<ClientEventMgr>.GetInstance().UnsubscribeClientEvent(211, new ClientEventMgr.ClientEventFunc(this.OnGoodsCd));
			}
		}

		private void AddListeners()
		{
			bool flag = this.isListenersInit;
			if (!flag)
			{
				this.isListenersInit = true;
				this.OnBagUpdate(null);
				Singleton<ClientEventMgr>.GetInstance().SubscribeClientEvent(21, new ClientEventMgr.ClientEventFunc(this.OnServerTimeChange));
				Singleton<ClientEventMgr>.GetInstance().SubscribeClientEvent(211, new ClientEventMgr.ClientEventFunc(this.OnGoodsCd));
				Singleton<ClientEventMgr>.GetInstance().SubscribeClientEvent(191, new ClientEventMgr.ClientEventFunc(this.OnBagUpdate));
			}
		}

		private void Update()
		{
			bool flag = this.mUseDoubleClick && this.mSingleClickCallback != null && this.mDoubleClickCount == 1;
			if (flag)
			{
				this.mSingleClickCounter += Time.get_deltaTime();
				bool flag2 = this.mSingleClickCounter > this.mSingleClickDelay;
				if (flag2)
				{
					this.mSingleClickCallback(this);
					this.mDoubleClickCount = -1;
					this.mSingleClickCounter = 0f;
				}
			}
			else
			{
				this.mSingleClickCounter = 0f;
			}
			bool flag3 = this.is_CD;
			if (flag3)
			{
				bool flag4 = this.mCdtexSpr != null;
				if (flag4)
				{
					uint serverTime = Game.GetInstance().ServerTime;
					bool flag5 = this.EndCd <= serverTime;
					if (flag5)
					{
						this.is_CD = false;
						CommonTool.SetActive(this.mCdtexSpr.get_gameObject(), false);
						this.Times = 0f;
						this.DetalTime = 0f;
						this.mCdtexSpr.set_fillAmount(0f);
					}
					else
					{
						float num = this.Times / this.DetalTime;
						this.mCdtexSpr.set_fillAmount(this.NowFill - num);
					}
					this.Times += Time.get_deltaTime();
				}
			}
			else
			{
				bool flag6 = this.ItemInfo != null;
				if (flag6)
				{
					bool flag7 = Game.Instance.ServerTime == this.StartCd;
					if (flag7)
					{
						this.CheckCdTime();
					}
				}
			}
		}

		public void ShowTips()
		{
			bool flag = this.mFrameSpr == null;
			if (flag)
			{
			}
		}

		private void Ontip()
		{
			bool flag = this.mShowType == 1;
			if (!flag)
			{
				bool flag2 = this.mShowType == 2 && this.IsShowTips;
				if (flag2)
				{
					GoodsHelper.ShowGoodsTips(this.ItemInfo, null, null, "Normal");
				}
			}
		}

		private void OnCutBtnClick()
		{
			bool flag = this.mCuntFunc != null;
			if (flag)
			{
				this.mCuntFunc(this.ItemInfo, this);
			}
		}

		private void OnClickNoNum()
		{
			bool flag = this.ItemInfo == null;
			if (!flag)
			{
				Singleton<UIManager>.Instance.ShowWindow("UIGoodsGetWayWindow", new object[]
				{
					this.ItemInfo.type_idx
				});
			}
		}

		public void OnPressCallBack(object obj)
		{
			bool flag = !this.SupportPressDown || this.ItemInfo == null;
			if (!flag)
			{
				GoodsHelper.ShowGoodsTips(this.ItemInfo, null, null, "Normal");
			}
		}

		private void OnClickGoodsBtn()
		{
			bool flag = this.mUseDoubleClick;
			if (flag)
			{
				bool flag2 = this.mDoubleClickCount == 1;
				if (flag2)
				{
					bool flag3 = this.mDoubleClickCallback != null;
					if (flag3)
					{
						this.mDoubleClickCallback(this);
					}
					this.mDoubleClickCount = -1;
				}
				else
				{
					bool flag4 = this.mDoubleClickCount == -1;
					if (flag4)
					{
						this.mDoubleClickCount = 1;
					}
				}
			}
			bool flag5 = this.mFunc != null;
			if (flag5)
			{
				this.mFunc(this.ItemInfo);
			}
			else
			{
				bool flag6 = this.mFunc1 != null;
				if (flag6)
				{
					this.mFunc1(this.ItemInfo, this.mOtherNum);
				}
				else
				{
					bool flag7 = this.mFunc2 != null;
					if (flag7)
					{
						this.mFunc2(this.ItemInfo, this);
					}
					else
					{
						bool flag8 = this.mCustomFunc != null;
						if (flag8)
						{
							this.mCustomFunc(this.mParam, this);
						}
						this.Ontip();
					}
				}
			}
		}

		private void OnGoodsCd(CEventBaseArgs args)
		{
			this.CheckCdTime();
		}

		private void OnServerTimeChange(CEventBaseArgs args)
		{
			this.RefreshExpireTime();
			this.RefreshOverdueNotice();
			bool flag = this.mExpiredObj != null && this.ItemInfo != null;
			if (flag)
			{
				bool flag2 = this.ItemInfo.expire_time != 0u && Game.Instance.ServerTime > this.ItemInfo.expire_time;
				if (flag2)
				{
					CommonTool.SetActive(this.mExpiredObj, true);
				}
				else
				{
					CommonTool.SetActive(this.mExpiredObj, false);
				}
			}
		}

		private void OnBagUpdate(CEventBaseArgs args)
		{
			this.RefreshCost();
			this.RefreshExpireTime();
		}

		public void RefreshCost()
		{
			bool flag = this.NoNum != null && this.ItemInfo != null;
			if (flag)
			{
				bool flag2 = !this.mIsCostItem && !this.mIsCostItemNoGrey;
				if (flag2)
				{
					CommonTool.SetActive(this.NoNum, false);
				}
				else
				{
					bool flag3 = this.ItemInfo.main_type == 23u;
					ulong num;
					if (flag3)
					{
						num = ItemManager.Instance.GetGoodsNumForMountEquipBagByTypeId(this.ItemInfo.type_idx);
					}
					else
					{
						bool flag4 = this.ItemInfo.main_type == 20u;
						if (flag4)
						{
							num = ItemManager.Instance.GetGoodsNumFromSoulBagAndBodyByTypeId(this.ItemInfo.type_idx);
						}
						else
						{
							bool flag5 = this.ItemInfo.main_type == 28u;
							if (flag5)
							{
								num = ItemManager.Instance.GetGoodsNumFromHandbookBagAndBodyByTypeId(this.ItemInfo.type_idx);
							}
							else
							{
								num = ItemManager.Instance.GetGoodsNumForBagByTypeId(this.ItemInfo.type_idx);
							}
						}
					}
					bool flag6 = num < (ulong)this.mNeedNum;
					if (flag6)
					{
						bool flag7 = this.mShowNeedNum;
						if (flag7)
						{
							this.mNum.set_text(string.Format("<color=red>{0}/{1}</color>", num, this.mNeedNum));
						}
						else
						{
							bool flag8 = num == 0uL && !this.mShowZeroNum;
							if (flag8)
							{
								this.mNum.set_text("");
							}
							else
							{
								this.mNum.set_text(string.Format("<color=red>{0}</color>", num));
							}
						}
						bool flag9 = this.mIsCostItem && this.mHasGoodsGetWay;
						if (flag9)
						{
							CommonTool.SetActive(this.NoNum, true);
							this.SetGrey(true);
						}
						else
						{
							CommonTool.SetActive(this.NoNum, false);
						}
					}
					else
					{
						bool flag10 = this.mShowNeedNum;
						if (flag10)
						{
							this.mNum.set_text(string.Format("{0}/{1}", num, this.mNeedNum));
						}
						else
						{
							this.mNum.set_text(string.Format("{0}", num));
						}
						CommonTool.SetActive(this.NoNum, false);
						bool flag11 = this.mIsCostItem && this.mHasGoodsGetWay;
						if (flag11)
						{
							this.SetGrey(false);
						}
					}
				}
			}
		}

		public void SetGrey(bool is_grey)
		{
			if (is_grey)
			{
				bool flag = this.EffectRoot != null;
				if (flag)
				{
					CommonTool.SetActive(this.EffectRoot.get_gameObject(), false);
				}
				bool flag2 = this.mUITexture != null && this.mUITexture.get_material() != null;
				if (flag2)
				{
					bool flag3 = this.mTextureMaterial == null;
					if (flag3)
					{
						this.mTextureMaterial = this.mUITexture.get_material();
					}
					Material material = Object.Instantiate<Material>(this.mUITexture.get_material());
					material.SetFloat("_Grey", 0f);
					this.mUITexture.set_material(material);
					bool flag4 = this.mQualityImage != null;
					if (flag4)
					{
						this.mQualityImage.set_material(material);
					}
				}
				bool flag5 = this.mEquipUpSpr != null;
				if (flag5)
				{
					this.mEquipUpSpr.set_color(Color.get_grey());
				}
				bool flag6 = this.mEquipDownSpr != null;
				if (flag6)
				{
					this.mEquipDownSpr.set_color(Color.get_grey());
				}
			}
			else
			{
				bool flag7 = this.EffectRoot != null;
				if (flag7)
				{
					CommonTool.SetActive(this.EffectRoot.get_gameObject(), true);
				}
				bool flag8 = this.mTextureMaterial != null;
				if (flag8)
				{
					bool flag9 = this.mUITexture != null;
					if (flag9)
					{
						this.mUITexture.set_material(this.mTextureMaterial);
					}
					bool flag10 = this.mQualityImage != null;
					if (flag10)
					{
						this.mQualityImage.set_material(this.mTextureMaterial);
					}
				}
				bool flag11 = this.mEquipUpSpr != null;
				if (flag11)
				{
					this.mEquipUpSpr.set_color(Color.get_white());
				}
				bool flag12 = this.mEquipDownSpr != null;
				if (flag12)
				{
					this.mEquipDownSpr.set_color(Color.get_white());
				}
			}
		}

		private void OnDestroy()
		{
			this.mIsDestroy = true;
			this.DestroyAssetRes();
			bool flag = this.RealGameobj != null;
			if (flag)
			{
			}
			this.Clear();
			this.RemoveListeners();
		}

		public void SetTitleDesc(string title_desc)
		{
			bool flag = this.mTitleDesc != null;
			if (flag)
			{
				this.mTitleDesc.set_text(title_desc);
			}
		}

		public void SetBgImageVisiable(bool is_visiable)
		{
			bool flag = this.mFrameSpr != null;
			if (flag)
			{
				CommonTool.SetActive(this.mFrameSpr.get_gameObject(), is_visiable);
			}
			this.m_IsFrameSprShow = is_visiable;
		}

		public void SetCircleBkgVisiable(bool is_visiable)
		{
			bool flag = this.mCircleBkg != null;
			if (flag)
			{
				CommonTool.SetActive(this.mCircleBkg.get_gameObject(), is_visiable);
			}
			this.m_IsCircleBkgShow = is_visiable;
			if (is_visiable)
			{
				this.SetBgImageVisiable(false);
				this.SetColor(false);
				this.SetEffectRootVisiable(false);
			}
		}

		public void SetEffectRootVisiable(bool is_visiable)
		{
			CommonTool.SetActive(this.EffectRoot, is_visiable);
		}

		public void SetPlayerVocationAndLv(uint vocation, uint player_lv)
		{
			this.mVocation = vocation;
			this.mPlayerLv = player_lv;
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				CommonTool.SetActive(this.mDisEnableSpr.get_gameObject(), !this.CheckCanUse());
			}
		}

		public void SetCanNotUse(bool canNotUse)
		{
			this.mCanNotUse = canNotUse;
			bool flag = this.mDisEnableSpr != null;
			if (flag)
			{
				CommonTool.SetActive(this.mDisEnableSpr.get_gameObject(), !this.CheckCanUse());
			}
		}

		public void SetCheckImageActive(bool is_active)
		{
			CommonTool.SetActive(this.mCheckImage, is_active);
		}

		public void SetShowExpJadeEffect(bool is_active)
		{
			CommonTool.SetActive(this.mExpJadeEffect, is_active);
		}

		public void SetNumActive(bool is_active)
		{
			bool flag = this.mNum != null;
			if (flag)
			{
				CommonTool.SetActive(this.mNum.get_gameObject(), is_active);
			}
		}

		private void RefreshCircleBkgVisiable()
		{
			bool flag = this.ItemInfo == null;
			if (flag)
			{
				this.SetCircleBkgVisiable(false);
			}
			else
			{
				DBGoodsEffectIcon dB = Singleton<DBManager>.Instance.GetDB<DBGoodsEffectIcon>();
				DBGoodsEffectIcon.DBGoodsEffectIconItem oneInfo = dB.GetOneInfo(this.ItemInfo.icon_id);
				bool flag2 = oneInfo != null;
				if (flag2)
				{
					bool canShowCircleBkg = this.m_CanShowCircleBkg;
					if (canShowCircleBkg)
					{
						this.SetCircleBkgVisiable(true);
					}
					else
					{
						this.SetCircleBkgVisiable(false);
						this.SetBgImageVisiable(true);
						this.SetColor(false);
						this.SetEffectRootVisiable(true);
					}
				}
				else
				{
					this.SetCircleBkgVisiable(false);
				}
			}
		}

		public void SetCustomFunc(UIItemNewSlot.OnClickCustomFunc customFunc)
		{
			this.mCustomFunc = customFunc;
		}

		public void ShowQualityEffect2(bool isShow)
		{
			if (isShow)
			{
				bool flag = this.ItemInfo != null && this.ItemInfo.color_type >= 4u;
				if (flag)
				{
					bool flag2 = this.mQualityTexArray2 != null && this.mQualityTex2 != null;
					if (flag2)
					{
						Texture texture = this.mQualityTexArray2.LoadTexture((int)(this.ItemInfo.color_type - 1u));
						bool flag3 = this.mQualityTex2.get_texture() != texture;
						if (flag3)
						{
							this.mQualityTex2.set_texture(texture);
						}
					}
					CommonTool.SetActive(this.mQualityEffect2, true);
				}
				else
				{
					CommonTool.SetActive(this.mQualityEffect2, false);
				}
			}
			else
			{
				CommonTool.SetActive(this.mQualityEffect2, false);
			}
		}
	}
}
