//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using Net;
//using xc.protocol;
//using xc.ui;
//using SGameEngine;
//using Utils;
//using xc.ui.ugui;
//namespace xc
//{
//    namespace ui
//    {

//        /// <summary>
//        /// 见UIItemNewSlot
//        /// </summary>
//        public class UIItemSlot : MonoBehaviour
//        {

//            public Goods ItemInfo;
//            public GameObject SelectWid { get; set; }
//            public int mShowType { get; set; } //0不显示 1显示背包内属性 2tips属性
//            RawImage mUITexture;
//            public GameObject mBindObj { get; set; }
//            public Image mEquippedSprite { get; set; }
//            public delegate void OnClickCustomFunc(System.Object obj, UIItemSlot item);
//            public delegate void OnClickFunc(Goods goods);
//            public delegate void OnClickFunc1(Goods goods, int num);
//            public delegate void OnClickFunc2(Goods goods, UIItemSlot item);
//            public OnClickCustomFunc mCustomFunc;
//            public OnClickFunc mFunc;
//            public OnClickFunc1 mFunc1;
//            public OnClickFunc2 mFunc2;
//            public OnClickFunc2 mCuntFunc;
//            private int mOtherNum = 0;
//            private uint mGrade = 0;
//            public Image mFrameSpr { get; set; }
//            private List<GameObject> mQualitySprs = new List<GameObject>();
//            private Image mEquipUpSpr;
//            private Image mEquipDownSpr;
//            private Image mDisEnableSpr;
//            private System.Object mParam;
//            private Text mNum;
//            public bool IsShowTips = true;
//            private Texture mTextureObj = null;
//            public Vector3 ForceTipsPosition = Vector3.one;
//            public bool NeedForceSetTipsPosition { get; set; }
//            public Image mItemSpr { get; set; }
//            public RawImage mCdtex { get; set; }//因为ab序列化原因暂时不用
//            private Image mCdtexSpr;
//            public bool is_CD = false;
//            private bool isShowCd = true;
//            private float DetalTime = 0;
//            private float NowFill = 0;
//            private float Times = 0;
//            private uint mNeedNum = 0;
//            private GameObject NoNum;
//            private string CurrentWindow = string.Empty;
//            private int CurrentWindowDepth = 50;
//            private Button ItemButton;
//            private bool isClear = false;
//            private GameObject AddHintImageObj;
//            private uint StartCd = 0;
//            private uint EndCd = 0;
//            private uint GoodsIcon = 0;
//            private uint GoodsColor = 0;
//            private GameObject mExpiredObj;
//            private SGameEngine.AssetResource Ar;
//            private bool SupportPressDown = false;//是否支持长按
//            private Dictionary<uint, GameObject> AddEquipIcon = new Dictionary<uint, GameObject>();
//            GameObject EffectRoot;
//            [Header("面板canvas")]
//            public Canvas TargetPanel;
//            [Header("裁剪区域：（只有ScrollView 滑动区域需要裁剪）")]
//            public RectTransform ClipPanel;

//            List<GameObject> LegendAttrs = new List<GameObject>();
//            Dictionary<uint, GameObject> Effects = new Dictionary<uint, GameObject>();

//            public GameObject RealGameobj { get; set; }
//            private ComTouchPress1 PressCom;

//            public SGameEngine.PrefabResource GoodsItemPr = new SGameEngine.PrefabResource();

//            private Text mTitleDesc;
//            private RenderqueueComponent EffectCom;
//            public UILockCDSlot LockPanel { get; set; }
//            //            bool mIsInit = true;
//            public struct TypeParse
//            {
//                public int _mType;
//                public int _mNum;
//                public uint _mGrade;
//                public OnClickFunc _mFunc;
//                public OnClickFunc1 _mFunc1;
//                public OnClickFunc2 _mFunc2;
//                public OnClickCustomFunc _mCustomFunc;
//                public System.Object _mParam;
//            }

//            public TypeParse _mTypeParse;


//            /// <summary>
//            /// 对象绑定方法
//            /// </summary>
//            /// <param name="obj"></param>
//            public static void Bind(GameObject obj)
//            {
//                if (obj.GetComponent<UIItemSlot>() == null)
//                {
//                    var item = obj.AddComponent<UIItemSlot>();

//                    item.Init(false);
//                }
//            }

//            //清除icon显示空格子
//            public void Clear()
//            {
//                Check();
//                if (mUITexture != null)
//                {
//                    /*if (mUITexture.material != null)
//                    {
//                        mUITexture.material.SetTexture("_MainTex", null);
//                    }*/
//                    mUITexture.texture = null;
//                    mUITexture.gameObject.SetActive(false);
//                    isClear = true;
//                }
//                bool HasNull = false;
//                for (int i = 0; i < mQualitySprs.Count; i++)
//                {
//                    if (mQualitySprs[i] != null)
//                        mQualitySprs[i].SetActive(false);
//                    else
//                    {
//                        HasNull = true;
//                    }
//                }
//                if (HasNull)
//                    mQualitySprs.Clear();
//                //                 if (mFrameSpr != null)
//                //                 {
//                //                     mFrameSpr.color = Color.white;
//                //                 }
//                if (mNum != null)
//                {
//                    mNum.text = "";
//                }
//                if (mEquipUpSpr != null)
//                {
//                    mEquipUpSpr.gameObject.SetActive(false);
//                }
//                if (mEquipDownSpr != null)
//                {
//                    mEquipDownSpr.gameObject.SetActive(false);
//                }
//                if (mDisEnableSpr != null)
//                {
//                    mDisEnableSpr.gameObject.SetActive(false);
//                }
//                if (LockPanel != null)
//                    LockPanel.Clear();
//                if (mExpiredObj != null)
//                {
//                    mExpiredObj.SetActive(false);
//                }
//                GoodsIcon = 0;
//                GoodsColor = 0;
//                if (mBindObj != null)
//                {
//                    mBindObj.SetActive(false);
//                }
//                if (mEquippedSprite != null)
//                    mEquippedSprite.gameObject.SetActive(false);
//                if (SelectWid != null)
//                    SelectWid.SetActive(false);
//                if (mCdtexSpr != null)
//                    mCdtexSpr.gameObject.SetActive(false);
//                HasNull = false;
//                for (int i = 0; i < LegendAttrs.Count; i++)
//                {
//                    if (LegendAttrs[i] != null)
//                        LegendAttrs[i].SetActive(false);
//                    {
//                        HasNull = true;
//                    }
//                }
//                if (HasNull)
//                    LegendAttrs.Clear();

//                HasNull = false;
//                foreach (var kv in Effects)
//                {
//                    if (kv.Value != null)
//                        kv.Value.SetActive(false);
//                    {
//                        HasNull = true;
//                    }
//                }
//                if (HasNull)
//                    Effects.Clear();
//                if (AddHintImageObj != null)
//                    AddHintImageObj.SetActive(false);
//                ItemInfo = null;
//                mOtherNum = 0;
//                mShowType = 0;
//                mFunc = null;
//                mFunc1 = null;
//                mFunc2 = null;
//                mCustomFunc = null;
//                mGrade = 0;
//                mParam = null;
//                is_CD = false;
//                DetalTime = 0;
//                StartCd = 0;
//                EndCd = 0;
//                Times = 0;
//                NowFill = 0;
//                mNeedNum = 0;
//                SupportPressDown = false;
//                //                if(mTextureObj != null)
//                //                    Resources.UnloadAsset(mTextureObj);
//                mTextureObj = null;
//            }

//            public void SetNumLabelText(string tx)
//            {
//                if (mNum != null)
//                {
//                    mNum.text = tx;
//                }
//            }

//            public void CutBtnInit(OnClickFunc2 func)
//            {
//                mCuntFunc = func;
//            }

//            public void IsSupportDown(bool isSupport)
//            {
//                SupportPressDown = isSupport;
//                if (PressCom != null)
//                    PressCom.SupportPressDown = SupportPressDown;
//            }

//            public void IsShowAddHintImageObj(bool isShow)
//            {
//                if (AddHintImageObj != null)
//                    AddHintImageObj.SetActive(isShow);
//            }

//            public void GoodsTexturePixelPerfect()
//            {
//                if (mUITexture != null)
//                    mUITexture.SetNativeSize();
//            }

//            public void SetShowCdImage(bool isShow)
//            {
//                isShowCd = isShow;
//            }


//            public void SetGreyTexture(bool state)
//            {
//                if (mUITexture != null)
//                {
//                    if (state)
//                    {
//                        //mUITexture.shader = Shader.Find("Custom/GrayTexture");

//                    }
//                    else
//                    {
//                        // mUITexture.shader = Shader.Find("Unlit/Transparent Colored");
//                    }
//                }
//            }

//            public void DisableClick()
//            {
//                var collider = GetComponent<Collider>();
//                collider.enabled = false;
//            }

//            private IEnumerator ShowAsync(uint icon)
//            {
//                isClear = false;
//                Ar = new SGameEngine.AssetResource();
//                if (mTextureObj != null)
//                {
//                    if (mTextureObj.name.CompareTo(icon.ToString()) == 0)
//                    {
//                        yield break;
//                    }
//                }

//                IconInfo info = GoodsHelper.GetIconInfo(icon);
//                yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(info.MainTexturePath, typeof(Texture), Ar));
//                if (mUITexture == null)
//                    yield break;
//                if (isClear)
//                {
//                    if (mUITexture != null)
//                    {
//                        mUITexture.texture = null;
//                        mUITexture.gameObject.SetActive(false);

//                        /*if (mUITexture.material != null)
//                        {
//                            mUITexture.material.SetTexture("_MainTex", null);
//                        }*/
//                    }

//                }
//                else
//                {
//                    if (ItemInfo == null)
//                    {
//                        mTextureObj = null;
//                        if (mUITexture != null)
//                        {
//                            mUITexture.texture = null;
//                            /*if (mUITexture.material != null)
//                            {
//                                mUITexture.material.SetTexture("_MainTex", null);
//                            }*/
//                        }

//                    }
//                    else
//                    {
//                        if (Ar == null || Ar.asset_ == null)
//                            yield break;
//                        mTextureObj = Ar.asset_ as Texture;
//                        if (mUITexture != null)
//                        {
//                            /*if (mUITexture.material != null)
//                            {
//                                mUITexture.material.SetTexture("_MainTex", mTextureObj);
//                            }*/
//                            mUITexture.texture = mTextureObj;
//                            mUITexture.uvRect = info.IconRect;
//                            mUITexture.rectTransform.sizeDelta = new Vector2(68, 68);
//                            mUITexture.gameObject.SetActive(true);
//                        }
//                    }

//                }
//            }

//            IEnumerator LoadEffect(uint color)
//            {
//                SGameEngine.PrefabResource prefab = new SGameEngine.PrefabResource();
//                if (color == 0)
//                    yield break;
//                string path = GoodsHelper.GetGoodsEffectPath(color);
//                if (path.CompareTo(string.Empty) == 0)
//                    yield break;
//                yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(path, prefab));
//                if (prefab.obj_ != null)
//                {
//                    if (EffectRoot == null)
//                    {
//                        CommonTool.DestroyObjectImmediate(prefab.obj_);
//                        yield break;
//                    }
//                    else
//                    {
//                        if (Effects.ContainsKey(color) || EffectRoot == null && EffectRoot.transform == null)
//                        {
//                            CommonTool.DestroyObjectImmediate(prefab.obj_);
//                            yield break;
//                        }
//                        GameObject effect = prefab.obj_;
//                        effect.transform.SetParent(EffectRoot.transform);
//                        effect.transform.localScale = Vector3.one;
//                        effect.transform.localPosition = Vector3.zero;
//                        effect.transform.localRotation = Quaternion.identity;
//                        effect.SetActive(true);
//                        Effects.Add(color, effect);
//                    }
//                }
//            }

//            void CheckCdTime()
//            {
//                NowFill = 0;
//                Times = 0;
//                if (mCdtexSpr != null && ItemInfo != null && isShowCd)
//                {
//                    uint startTime = 0;
//                    if (ItemManager.Instance.GoodsCd.TryGetValue(ItemInfo.type_idx, out startTime))
//                    {
//                        StartCd = startTime;
//                        List<string> data_goods = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_goods", "gid", ItemInfo.type_idx.ToString(), "use_cd");
//                        uint cd = 10;
//                        if (data_goods.Count > 0)
//                            cd = DBTextResource.ParseUI(data_goods[0]);
//                        EndCd = StartCd + cd;
//                        if (EndCd != 0)
//                        {
//                            uint serverTime = Game.GetInstance().ServerTime;
//                            if (EndCd > serverTime && serverTime >= StartCd)
//                            {
//                                uint detal = EndCd - StartCd;
//                                uint star_detal = serverTime - StartCd;
//                                DetalTime = (float)detal;
//                                mCdtexSpr.gameObject.SetActive(true);
//                                float _time = (float)star_detal / (float)detal;
//                                NowFill = 1 - _time;
//                                mCdtexSpr.fillAmount = NowFill;
//                                is_CD = true;
//                            }
//                            else
//                            {
//                                is_CD = false;
//                                mCdtexSpr.gameObject.SetActive(false);
//                                mCdtexSpr.fillAmount = 0;
//                            }
//                        }
//                    }
//                }
//            }

//            public void SetUI()
//            {
//                Check();
//                if (RealGameobj == null)
//                {
//                    return;
//                }
//                OnBagUpdate(null);
//                if (SelectWid != null)
//                    SelectWid.SetActive(false);
//                if (ItemInfo == null)
//                    return;
//                CheckCdTime();
//                if (GoodsIcon != ItemInfo.icon_id)
//                {
//                    GoodsIcon = ItemInfo.icon_id;
//                    ui.ugui.UIManager.Instance.MainCtrl.StartCoroutine(ShowAsync(ItemInfo.icon_id));
//                }
//                if (AddHintImageObj != null)
//                    AddHintImageObj.SetActive(false);
//                if (LockPanel != null)
//                    LockPanel.Clear();
//                foreach (var kv in Effects)
//                {
//                    kv.Value.SetActive(false);
//                }
//                if (GoodsColor != ItemInfo.color_type)
//                {
//                    GoodsColor = ItemInfo.color_type;
//                    if (ItemInfo.color_type >= GameConst.QUAL_COLOR_PURPLE)
//                    {
//                        Effects[ItemInfo.color_type].SetActive(true);
//                    }

//                    //                         if (Effects.ContainsKey(ItemInfo.color_type) == false)
//                    //                     {
//                    //                         if (ItemInfo.color_type >= GameConst.QUAL_COLOR_PURPLE)
//                    //                             ui.ugui.UIManager.Instance.MainCtrl.StartCoroutine(LoadEffect(ItemInfo.color_type));
//                    //                     }
//                    //                     else
//                    //                         Effects[ItemInfo.color_type].SetActive(true);
//                }



//                if (mNum != null)
//                {
//                    if (ItemInfo.num > 1)
//                    {
//                        mNum.text = "" + ItemInfo.num;
//                    }
//                    else
//                    {
//                        mNum.text = "";
//                    }
//                }
//                if (mBindObj != null)
//                {
//                    if (ItemInfo.bind == 0)
//                        mBindObj.SetActive(false);
//                    else
//                        mBindObj.SetActive(true);
//                }
//                if (mEquippedSprite != null)
//                {
//                    if (ItemManager.Instance.InstallEquip.ContainsKey(ItemInfo.id))
//                    {
//                        mEquippedSprite.gameObject.SetActive(true);
//                    }
//                    else
//                        mEquippedSprite.gameObject.SetActive(false);
//                }
//                if (mExpiredObj != null)
//                {
//                    if (ItemInfo.expire_time != 0 && ItemInfo.expire_time < Game.Instance.ServerTime)
//                    {
//                        mExpiredObj.SetActive(true);
//                    }
//                    else
//                        mExpiredObj.SetActive(false);
//                }
//                if (mDisEnableSpr != null)
//                {
//                    mDisEnableSpr.gameObject.SetActive(!CheckCanUse());
//                }
//                if (mEquipUpSpr != null)
//                {
//                    mEquipUpSpr.gameObject.SetActive(false);
//                }
//                if (mEquipDownSpr != null)
//                {
//                    mEquipDownSpr.gameObject.SetActive(false);
//                }

//                if (mFrameSpr != null)
//                {
//                    mFrameSpr.gameObject.SetActive(true);
//                }
//                if (mQualitySprs.Count != 0)
//                {
//                    for (int i = 0; i < mQualitySprs.Count; i++)
//                    {
//                        mQualitySprs[i].gameObject.SetActive(false);
//                    }
//                    int index = (int)ItemInfo.color_type;
//                    if (index < mQualitySprs.Count)
//                    {
//                        mQualitySprs[index].gameObject.SetActive(true);
//                    }
//                }

//                if (ItemInfo is GoodsEquip)
//                {
//                    if (AddHintImageObj != null)
//                    {
//                        AddHintImageObj.SetActive(false);
//                    }
//                    GoodsEquip equip = ItemInfo as GoodsEquip;
//                    int count = Equip.EquipHelper.GetStarAddEquip(equip);
//                    //int count = equip.LegendAttrs.Count > LegendAttrs.Count ? LegendAttrs.Count : equip.LegendAttrs.Count;
//                    for (int i = 0; i < LegendAttrs.Count; i++)
//                    {
//                        LegendAttrs[i].SetActive(false);
//                    }
//                    if (count > LegendAttrs.Count)
//                    {
//                        count = LegendAttrs.Count;
//                    }
//                    for (int i = 0; i < count; i++)
//                    {
//                        LegendAttrs[i].SetActive(true);
//                    }
//                }
//                else
//                {
//                    for (int i = 0; i < LegendAttrs.Count; i++)
//                    {
//                        LegendAttrs[i].SetActive(false);
//                    }
//                }

//            }
//            public void SetColor(bool isShow)
//            {
//                int index = (int)ItemInfo.color_type;
//                if (index < mQualitySprs.Count)
//                {
//                    mQualitySprs[index].SetActive(isShow);
//                }
//            }

//            public void setItemInfo(uint goodsId, TypeParse parse)
//            {
//                Goods goods = GoodsFactory.Create(goodsId, null);
//                setItemInfo(goods, parse);
//            }

//            public void setItemInfo(Goods itemInfo, TypeParse parse, uint needNum, string windowName, int maxDepth)
//            {
//                CurrentWindow = windowName;
//                CurrentWindowDepth = maxDepth + 1;
//                mNeedNum = needNum;
//                setItemInfo(itemInfo, parse);
//            }

//            public void setItemInfo(Goods itemInfo, TypeParse parse)
//            {
//                //                Clear();
//                ItemInfo = itemInfo;
//                mOtherNum = parse._mNum;
//                mShowType = parse._mType;
//                mFunc = parse._mFunc;
//                mFunc1 = parse._mFunc1;
//                mFunc2 = parse._mFunc2;
//                mGrade = parse._mGrade;
//                mCustomFunc = parse._mCustomFunc;
//                mParam = parse._mParam;
//                SetUI();
//            }

//            public void setItemInfo(Goods itemInfo, TypeParse parse, bool IsScale)
//            {
//                //                Clear();
//                ItemInfo = itemInfo;
//                mOtherNum = parse._mNum;
//                mShowType = parse._mType;
//                mFunc = parse._mFunc;
//                mFunc1 = parse._mFunc1;
//                mFunc2 = parse._mFunc2;
//                mGrade = parse._mGrade;

//                //                 if (IsScale == false)
//                //                 {
//                //                     UIButtonScale BtnScale = RealGameobj.GetComponent<UIButtonScale>();
//                //                     if (BtnScale != null)
//                //                         BtnScale.enabled = false;
//                //                 }
//                SetUI();
//            }

//            public void ShowEquippedIcon(bool show)
//            {
//                if (mEquippedSprite != null)
//                {
//                    mEquippedSprite.gameObject.SetActive(show);
//                }
//            }

//            public RawImage MainTexture
//            {
//                set { mUITexture = value; }
//                get { return mUITexture; }
//            }
//            static public UIItemSlot.TypeParse CreateUIItemTypeParse()
//            {
//                UIItemSlot.TypeParse typeParse;
//                typeParse._mType = 0;
//                typeParse._mNum = 0;
//                typeParse._mGrade = 0;
//                typeParse._mFunc1 = null;
//                typeParse._mFunc = null;
//                typeParse._mFunc2 = null;
//                typeParse._mCustomFunc = null;
//                typeParse._mParam = null;
//                return typeParse;
//            }

//            public void IsShowEquipUp(bool show)
//            {
//                if (mEquipUpSpr != null)
//                    mEquipUpSpr.gameObject.SetActive(show);
//            }

//            bool CheckCanUse()
//            {
//                if (LocalPlayerManager.Instance.LocalActorAttribute != null)
//                {
//                    if ((ItemInfo.use_job == 0 || ItemInfo.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
//                        && (ItemInfo.use_lv <= LocalPlayerManager.Instance.LocalActorAttribute.Level)
//                        /*&&判断消费*/ )
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                else
//                    return false;

//            }

//            private void OnDisable()
//            {
//                //ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("LoadEffect");
//                ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("ShowAsync");
//                //                 if (Ar != null)
//                //                 {
//                //                     Ar.destroy();
//                //                     Ar = null;
//                //                 }
//            }

//            public void MatchEquip(GoodsEquip equip)
//            {

//                if (mDisEnableSpr != null)
//                {
//                    if (mDisEnableSpr.gameObject.activeSelf)
//                    {
//                        if (mEquipUpSpr != null)
//                        {
//                            mEquipUpSpr.gameObject.SetActive(false);
//                        }
//                        if (mEquipDownSpr != null)
//                        {
//                            mEquipDownSpr.gameObject.SetActive(false);
//                        }
//                    }
//                    else
//                    {
//                        if (ItemInfo is GoodsEquip)
//                        {
//                            GoodsEquip itemEquip = ItemInfo as GoodsEquip;
//                            if (LocalPlayerManager.Instance.LocalActorAttribute.Vocation != itemEquip.use_job && itemEquip.use_job != 0)
//                            {
//                                if (mEquipUpSpr != null)
//                                {
//                                    mEquipUpSpr.gameObject.SetActive(false);
//                                }
//                                if (mEquipDownSpr != null)
//                                {
//                                    mEquipDownSpr.gameObject.SetActive(false);
//                                }
//                                return;
//                            }
//                            if (equip == null)
//                            {
//                                if (mEquipUpSpr != null)
//                                {
//                                    mEquipUpSpr.gameObject.SetActive(true);
//                                }
//                                return;
//                            }
//                            if (itemEquip.EquipRank > equip.EquipRank)
//                            {
//                                if (mEquipUpSpr != null)
//                                {
//                                    mEquipUpSpr.gameObject.SetActive(true);
//                                }
//                                if (mEquipDownSpr != null)
//                                {
//                                    mEquipDownSpr.gameObject.SetActive(false);
//                                }
//                            }
//                            else if (itemEquip.EquipRank < equip.EquipRank)
//                            {
//                                if (mEquipUpSpr != null)
//                                {
//                                    mEquipUpSpr.gameObject.SetActive(false);
//                                }
//                                if (mEquipDownSpr != null)
//                                {
//                                    mEquipDownSpr.gameObject.SetActive(true);
//                                }
//                            }
//                            else
//                            {
//                                if (mEquipUpSpr != null)
//                                {
//                                    mEquipUpSpr.gameObject.SetActive(false);
//                                }
//                                if (mEquipDownSpr != null)
//                                {
//                                    mEquipDownSpr.gameObject.SetActive(false);
//                                }
//                            }
//                        }
//                        else
//                        {
//                            if (mEquipUpSpr != null)
//                            {
//                                mEquipUpSpr.gameObject.SetActive(false);
//                            }
//                            if (mEquipDownSpr != null)
//                            {
//                                mEquipDownSpr.gameObject.SetActive(false);
//                            }
//                        }
//                    }

//                }
//                else
//                {
//                    if (mEquipUpSpr != null)
//                    {
//                        mEquipUpSpr.gameObject.SetActive(false);
//                    }
//                    if (mEquipDownSpr != null)
//                    {
//                        mEquipDownSpr.gameObject.SetActive(false);
//                    }
//                }


//            }

//            public void SetEquipAddSpr(uint pos)
//            {
//                foreach (var kv in AddEquipIcon)
//                {
//                    kv.Value.SetActive(false);
//                }

//                if (AddEquipIcon.ContainsKey(pos))
//                    AddEquipIcon[pos].SetActive(true);
//            }

//            public void IsSelect(bool show)
//            {
//                if (SelectWid != null)
//                    SelectWid.SetActive(show);
//            }

//            protected void Check()
//            {
//                if (RealGameobj == null)
//                    LoadPrefab();

//                if (mItemSpr == null)
//                    mItemSpr = RealGameobj.GetComponent<Image>();

//                if (NoNum == null)
//                {
//                    if (RealGameobj.transform.Find("NoNum") != null)
//                    {
//                        NoNum = RealGameobj.transform.Find("NoNum").gameObject;
//                        /*UIButton noNumBtn = NoNum.GetComponent<UIButton>();
//                        if (noNumBtn != null)
//                        {
//                            EventDelegate.Remove(noNumBtn.onClick, OnClickNoNum);
//                            EventDelegate.Add(noNumBtn.onClick, OnClickNoNum);
//                        }*/
//                        NoNum.SetActive(false);
//                    }
//                }
//                if (SelectWid == null)
//                {
//                    if (RealGameobj.transform.Find("Select") != null)
//                    {
//                        SelectWid = RealGameobj.transform.Find("Select").gameObject;
//                        SelectWid.SetActive(false);
//                    }
//                }

//                if (EffectRoot == null)
//                {
//                    if (RealGameobj.transform.Find("Effects") != null)
//                    {
//                        EffectCom = RealGameobj.transform.Find("Effects").GetComponent<RenderqueueComponent>();
//                        if (EffectCom == null)
//                            EffectCom = RealGameobj.transform.Find("Effects").gameObject.AddComponent<RenderqueueComponent>();
//                        EffectCom.targetPanel = TargetPanel;
//                        EffectCom.rect = ClipPanel;
//                        EffectRoot = RealGameobj.transform.Find("Effects").gameObject;
//                    }

//                }

//                if (Effects.Count == 0)
//                {
//                    for (int i = 1; i <= 7; i++)
//                    {
//                        if (EffectRoot.transform.Find("EF_ui_pz_" + i) != null)
//                        {
//                            var effect = EffectRoot.transform.Find("EF_ui_pz_" + i).gameObject;
//                            Effects.Add((uint)(i - 1), effect);
//                        }
//                    }
//                }

//                if (mExpiredObj == null)
//                {
//                    if (RealGameobj.transform.Find("ExpiredObj") != null)
//                    {
//                        mExpiredObj = RealGameobj.transform.Find("ExpiredObj").gameObject;
//                    }
//                }
//                if (AddHintImageObj == null)
//                {
//                    if (RealGameobj.transform.Find("AddHintImage") != null)
//                    {
//                        AddHintImageObj = RealGameobj.transform.Find("AddHintImage").gameObject;
//                        AddHintImageObj.SetActive(false);
//                    }
//                }


//                if (AddEquipIcon.Count == 0)
//                {
//                    if (AddHintImageObj != null)
//                    {
//                        int count = AddHintImageObj.transform.childCount;
//                        for (int i = 0; i < count; i++)
//                        {
//                            Transform trans = AddHintImageObj.transform.GetChild(i);
//                            string name = trans.name;
//                            name = name.Replace("Equip_", "");
//                            uint pos = 0;
//                            uint.TryParse(name, out pos);
//                            trans.gameObject.SetActive(false);
//                            if (AddEquipIcon.ContainsKey(pos) == false)
//                                AddEquipIcon.Add(pos, trans.gameObject);

//                        }
//                    }
//                }

//                if (mCdtexSpr == null)
//                {
//                    if (RealGameobj.transform.Find("CDImage") != null)
//                    {
//                        mCdtexSpr = RealGameobj.transform.Find("CDImage").GetComponent<Image>();
//                        mCdtexSpr.gameObject.SetActive(false);
//                    }
//                }
//                if (mUITexture == null)
//                {
//                    if (RealGameobj.transform.Find("GoodsRawImage") != null)
//                        mUITexture = RealGameobj.transform.Find("GoodsRawImage").GetComponent<RawImage>();
//                }
//                if (mNum == null)
//                {
//                    if (RealGameobj.transform.Find("QuantityText") != null)
//                        mNum = RealGameobj.transform.Find("QuantityText").GetComponent<Text>();
//                }

//                if (mBindObj == null)
//                {
//                    if (RealGameobj.transform.Find("LockImage") != null)
//                        mBindObj = RealGameobj.transform.Find("LockImage").gameObject;
//                }

//                if (mFrameSpr == null)
//                {
//                    if (RealGameobj.transform.Find("BgImage") != null)
//                        mFrameSpr = RealGameobj.transform.Find("BgImage").GetComponent<Image>();
//                }

//                if (mQualitySprs.Count == 0)
//                {
//                    int startIdx = GameConst.QUAL_COLOR_WHITE;
//                    int EndIdx = GameConst.QUAL_COLOR_RED;
//                    for (int i = startIdx; i <= EndIdx; i++)
//                    {
//                        if (RealGameobj.transform.Find("QualityImage_" + i) != null)
//                        {
//                            mQualitySprs.Add(RealGameobj.transform.Find("QualityImage_" + i).gameObject);
//                        }
//                    }
//                }

//                if (LockPanel == null)
//                {
//                    if (RealGameobj.transform.Find("LockPanel") != null)
//                    {
//                        LockPanel = RealGameobj.transform.Find("LockPanel").GetComponent<UILockCDSlot>();
//                        if (LockPanel == null)
//                            LockPanel = RealGameobj.transform.Find("LockPanel").gameObject.AddComponent<UILockCDSlot>();
//                        LockPanel.Clear();
//                    }
//                }

//                if (LegendAttrs.Count == 0)
//                {
//                    for (int i = 1; i <= 4; i++)
//                    {
//                        var trans = RealGameobj.transform.Find(string.Format("LegendImage_{0}", i));
//                        if (trans != null)
//                            LegendAttrs.Add(trans.gameObject);
//                    }
//                }

//                if (mEquipUpSpr == null)
//                {
//                    if (RealGameobj.transform.Find("BetterImage") != null)
//                    {
//                        mEquipUpSpr = RealGameobj.transform.Find("BetterImage").GetComponent<Image>();
//                    }
//                }

//                if (mEquipDownSpr == null)
//                {
//                    if (RealGameobj.transform.Find("InferiorImage") != null)
//                    {
//                        mEquipDownSpr = RealGameobj.transform.Find("InferiorImage").GetComponent<Image>();
//                    }
//                }

//                if (mDisEnableSpr == null)
//                {
//                    if (RealGameobj.transform.Find("UnavailImage") != null)
//                    {
//                        mDisEnableSpr = RealGameobj.transform.Find("UnavailImage").GetComponent<Image>();
//                    }
//                }


//                if (mEquippedSprite == null)
//                {
//                    if (RealGameobj.transform.Find("AdornImage") != null)
//                    {
//                        mEquippedSprite = RealGameobj.transform.Find("AdornImage").GetComponent<Image>();
//                        mEquippedSprite.gameObject.SetActive(false);
//                    }
//                }

//                if (ItemButton == null)
//                {
//                    ItemButton = RealGameobj.GetComponent<Button>();
//                    PressCom = RealGameobj.GetComponent<ComTouchPress1>();
//                    if (PressCom == null)
//                    {
//                        PressCom = RealGameobj.AddComponent<ComTouchPress1>();
//                        PressCom.Init(OnPressCallBack, null);
//                    }


//                    if (ItemButton != null)
//                    {
//                        ItemButton.onClick.RemoveAllListeners();
//                        ItemButton.onClick.AddListener(OnClickGoodsBtn);
//                    }
//                }



//                if (mTitleDesc == null)
//                {
//                    if (RealGameobj.transform.Find("TitleDesc") != null)
//                    {
//                        mTitleDesc = RealGameobj.transform.Find("TitleDesc").GetComponent<Text>();
//                    }
//                }
//            }

//            public void Init(bool isLoad)
//            {
//                if (isLoad)
//                {
//                    RealGameobj = gameObject;
//                }
//                else
//                {
//                    if (RealGameobj == null)
//                        LoadPrefab();
//                }
//                Check();
//            }

//            protected void Awake()
//            {
//                //                 if (RealGameobj == null)
//                //                     LoadPrefab();
//                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
//                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_GOODS_CD_UPDATE, OnGoodsCd);
//                ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpdate);
//                //                 Check();
//            }

//            /// <summary>
//            /// 美术想省事要程序提供替换功能
//            /// </summary>
//            void LoadPrefab()
//            {
//                if (GoodsHelper.GoodsPrefab == null)
//                    return;
//                RealGameobj = GameObject.Instantiate(GoodsHelper.GoodsPrefab);
//                RealGameobj.transform.SetParent(gameObject.transform);
//                RealGameobj.transform.localPosition = Vector3.zero;
//                RealGameobj.transform.localScale = Vector3.one;
//                Button rootBtn = gameObject.GetComponent<Button>();
//                if (rootBtn != null)
//                    Destroy(gameObject.GetComponent<Button>());
//                if (gameObject.transform.Find("Effects") != null)
//                {
//                    var tmpEffect = gameObject.transform.Find("Effects").GetComponent<RenderqueueComponent>();
//                    if (tmpEffect != null)
//                    {
//                        TargetPanel = tmpEffect.targetPanel;
//                        ClipPanel = tmpEffect.rect;
//                    }
//                }
//                List<GameObject> gos = new List<GameObject>();
//                for (int i = 0; i < gameObject.transform.childCount; i++)
//                {
//                    var trans = gameObject.transform.GetChild(i);
//                    if (trans != RealGameobj.transform)
//                    {
//                        gos.Add(trans.gameObject);
//                    }
//                }
//                for (int i = 0; i < gos.Count; i++)
//                {
//                    GameObject.DestroyImmediate(gos[i]);
//                }
//            }

//            void Update()
//            {
//                if (is_CD == true)
//                {
//                    if (mCdtexSpr != null)
//                    {
//                        uint serverTime = Game.GetInstance().ServerTime;
//                        if (EndCd <= serverTime)
//                        {
//                            is_CD = false;
//                            mCdtexSpr.gameObject.SetActive(false);
//                            Times = 0;
//                            DetalTime = 0;
//                            mCdtexSpr.fillAmount = 0;
//                        }
//                        else
//                        {
//                            float _time = Times / DetalTime;
//                            mCdtexSpr.fillAmount = NowFill - _time;
//                        }
//                        Times += Time.deltaTime;

//                    }
//                }
//                else
//                {
//                    if (ItemInfo != null)
//                    {
//                        if (Game.Instance.ServerTime == StartCd)
//                        {
//                            CheckCdTime();
//                        }
//                    }

//                }

//            }

//            void Start()
//            {
//            }

//            public void ShowTips()
//            {
//                if (mFrameSpr == null)
//                    return;

//                //                 if (ItemInfo.main_type != (uint)GoodsHelper.ItemMainType.EQUIP)
//                //                 {
//                //                     string str = ItemInfo.description;
//                //                     GoodsItem goodsItem = ItemInfo as GoodsItem;
//                //                     if (str == string.Empty && ItemInfo is GoodsEquipModItem)
//                //                     {
//                //                         GoodsEquipModItem fakeGoods = ItemInfo as GoodsEquipModItem;
//                //                         str = "  " + Equip.EquipHelper.GetEquipQualityStr((EGoodsQuality)fakeGoods.color_type) + " " + TextHelper.GetConstText("LEVEL") + ":" + fakeGoods.use_lv;
//                //                     }
//                //                     else if (ItemInfo is GoodsGem)
//                //                     {
//                //                         if (ItemInfo.description.CompareTo("") != 0)
//                //                         {
//                //                             if (ItemInfo.description[0] == '"')
//                //                                 str = ItemInfo.description.Substring(1, ItemInfo.description.Length - 2);
//                //                             else
//                //                                 str = ItemInfo.description;
//                //                         }
//                //                     }
//                //                     else
//                //                         str = ItemInfo.description;
//                //                     UIWidgetHelp.GetInstance().ShowTips(str, this);
//                //                 }
//            }

//            void Ontip()
//            {
//                if (mShowType == 1)
//                {
//                }
//                else if (mShowType == 2 && IsShowTips == true)
//                {
//                    //ShowTips();
//                    if (this.ItemInfo.GetType() == typeof(GoodsEquip))
//                    {
//                        xc.ui.ugui.UIManager.Instance.ShowWindow("UIEquipmentTipsWindow", this.ItemInfo, "Normal");
//                    }
//                    else
//                    {
//                        xc.ui.ugui.UIManager.Instance.ShowWindow("UIGoodsTipsWindow", this.ItemInfo, "Normal");
//                    }
//                }

//            }

//            void OnCutBtnClick()
//            {
//                if (mCuntFunc != null)
//                    mCuntFunc(ItemInfo, this);
//            }

//            void OnClickNoNum()
//            {
//                Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_SHOW, new Utils.ClientEventParamArgs("UIGetWindow", CurrentWindow, ItemInfo.type_idx, CurrentWindowDepth));
//            }

//            public void OnPressCallBack(System.Object obj)
//            {
//                if (SupportPressDown == false || this.ItemInfo == null)
//                    return;
//                if (this.ItemInfo.GetType() == typeof(GoodsEquip))
//                {
//                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIEquipmentTipsWindow", this.ItemInfo, "Normal");
//                }
//                else
//                {
//                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIGoodsTipsWindow", this.ItemInfo, "Normal");
//                }
//            }

//            void OnClickGoodsBtn()
//            {
//                if (mFunc != null)
//                {
//                    mFunc(ItemInfo);
//                    return;
//                }
//                else if (mFunc1 != null)
//                {
//                    mFunc1(ItemInfo, mOtherNum);
//                    return;
//                }
//                else if (mFunc2 != null)
//                {
//                    mFunc2(ItemInfo, this);
//                    return;
//                }
//                else if (mCustomFunc != null)
//                    mCustomFunc(mParam, this);
//                Ontip();
//            }

//            void OnGoodsCd(CEventBaseArgs args)
//            {
//                CheckCdTime();
//            }

//            void OnServerTimeChange(CEventBaseArgs args)
//            {
//                if (mExpiredObj != null && ItemInfo != null)
//                {
//                    if (ItemInfo.expire_time != 0 && Game.Instance.ServerTime > ItemInfo.expire_time)
//                    {
//                        if (mExpiredObj.activeSelf == false)
//                            mExpiredObj.SetActive(true);
//                    }
//                    else
//                    {
//                        if (mExpiredObj.activeSelf == true)
//                            mExpiredObj.SetActive(false);
//                    }
//                }
//            }

//            void OnBagUpdate(CEventBaseArgs args)
//            {
//                if (NoNum != null && ItemInfo != null)
//                {
//                    uint num = ItemManager.Instance.GetGoodsNumForBagByTypeId(ItemInfo.type_idx);
//                    if (num < mNeedNum)
//                    {
//                        List<Dictionary<string, string>> data_cost = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_cost", "id", ItemInfo.type_idx.ToString());
//                        if (data_cost.Count > 0)
//                            NoNum.SetActive(true);
//                        else
//                            NoNum.SetActive(false);
//                    }
//                    else
//                        NoNum.SetActive(false);
//                }
//            }

//            void OnDestroy()
//            {
//                if (Ar != null)
//                {
//                    Ar.destroy();
//                    Ar = null;
//                }
//                //ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("LoadEffect");

//                if (UIManager.Instance.MainCtrl != null)
//                {
//                    ui.ugui.UIManager.Instance.MainCtrl.StopCoroutine("ShowAsync");
//                }

//                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
//                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpdate);
//                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_GOODS_CD_UPDATE, OnGoodsCd);
//                if (RealGameobj != null)
//                {

//                    /*UIButton btn = RealGameobj.GetComponent<UIButton>();
//                    if (btn != null)
//                    {
//                        EventDelegate.Remove(btn.onClick, OnClickGoodsBtn);
//                    }*/
//                }
//                Clear();
//            }

//            public void SetTitleDesc(string title_desc)
//            {
//                if (mTitleDesc != null)
//                    mTitleDesc.text = title_desc;
//            }
//        }

//    }
//}
