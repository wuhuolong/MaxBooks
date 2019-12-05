using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        [DisallowMultipleComponent]
        public class UIHandBookItemSlot : MonoBehaviour
        {
            /// <summary>
            /// 图鉴名称
            /// </summary>
            [SerializeField]
            private Text handbookName;
            /// <summary>
            /// 图鉴图片
            /// </summary>
            [SerializeField]
            private RawImage handbookPicture;
            /// <summary>
            /// 图鉴框
            /// </summary>
            [SerializeField]
            private Image handbookBorder;
            /// <summary>
            /// 图鉴未激活标记
            /// </summary>
            [SerializeField]
            private GameObject handbookInactiveMark;
            /// <summary>
            /// 前五颗星星
            /// </summary>
            [SerializeField]
            private List<GameObject> firstFiveStars;
            /// <summary>
            /// 超过五颗星星
            /// </summary>
            [SerializeField]
            private GameObject moreThanFiveStars;
            /// <summary>
            /// 超过五颗星星的数量
            /// </summary>
            [SerializeField]
            private Text moreThanFiveStarsCount;
            /// <summary>
            /// 满星标记
            /// </summary>
            [SerializeField]
            private GameObject handbookFullMark;
            /// <summary>
            /// 图鉴的Toggle
            /// </summary>
            [SerializeField]
            private Toggle handbookToggle;
            /// <summary>
            /// 图鉴小红点
            /// </summary>
            [SerializeField]
            private RedPoint redPoint;
            /// <summary>
            /// 激活特效
            /// </summary>
            [SerializeField]
            private GameObject activateEff;
            /// <summary>
            /// 升星特效
            /// </summary>
            [SerializeField]
            private GameObject upgradeEff;

            public Func<int, bool> OnHandBookItemClick;

            private int handbookID = 0;
            private Material pictureMat;
            private Texture mTextureObj = null;
            private SGameEngine.AssetResource mAssetRes = null;

            private int RED_POINT_DELTA_X = 168;
            private int RED_POINT_DELTA_Y = -12;

            //图鉴最低星级
            private int HANDBOOK_MIN_STAR = 1;

            void Awake()
            {
                RED_POINT_DELTA_X = GameConstHelper.GetInt("HANDBOOK_RED_POINT_DELTA_X");
                RED_POINT_DELTA_Y = GameConstHelper.GetInt("HANDBOOK_RED_POINT_DELTA_Y");
                HANDBOOK_MIN_STAR = GameConstHelper.GetInt("HANDBOOK_MIN_STAR");
                if (handbookName == null)
                    handbookName = this.transform.Find("Name").GetComponent<Text>();
                if (handbookPicture == null)
                    handbookPicture = this.transform.Find("Picture").GetComponent<RawImage>();
                if (handbookBorder == null)
                    handbookBorder = this.transform.Find("bg").GetComponent<Image>();
                if (handbookInactiveMark == null)
                    handbookInactiveMark = this.transform.Find("NotText").gameObject;
                if (firstFiveStars == null || firstFiveStars.Count <= 0)
                {
                    firstFiveStars = new List<GameObject>();
                    var starParent1 = this.transform.Find("StarPanel");
                    for (int i = 0; i < starParent1.childCount; i++)
                    {
                        firstFiveStars.Add(starParent1.GetChild(i).gameObject);
                    }
                }
                if (moreThanFiveStars == null)
                {
                    moreThanFiveStars = this.transform.Find("StarPanel2/StarBg_1").gameObject;
                }
                if (moreThanFiveStarsCount == null)
                {
                    moreThanFiveStarsCount = this.transform.Find("StarPanel2/Text").GetComponent<Text>();
                }
                if (handbookFullMark == null)
                {
                    handbookFullMark = this.transform.Find("Max").gameObject;
                }
                if (handbookToggle == null)
                {
                    handbookToggle = this.transform.GetComponent<Toggle>();
                }
                if(handbookToggle != null)
                    handbookToggle.onValueChanged.AddListener((isOn) =>
                    {
                        if (isOn)
                        {
                            OnHandBookItemClick?.Invoke(handbookID);
                        }
                    });
                if (redPoint == null)
                {
                    redPoint = this.gameObject.AddComponent<RedPoint>();
                    redPoint.DeltaX = RED_POINT_DELTA_X;
                    redPoint.DeltaY = RED_POINT_DELTA_Y;
                }

                //两个特效策划让对换一下
                if (activateEff == null)
                {
                    var trans = this.transform.Find("EF_UI_tujian_shengxing");
                    if(trans != null)
                        activateEff = trans.gameObject;
                }

                if (upgradeEff == null)
                {
                    var trans = this.transform.Find("EF_UI_tujian_jihuo"); 
                    if (trans != null)
                        upgradeEff = trans.gameObject;
                }

                Reset();
            }

            void OnDestroy()
            {
                Reset();
            }

            public void Reset()
            {
                handbookInactiveMark.SetActive(false);
                foreach (GameObject star in firstFiveStars)
                {
                    star.SetActive(false);
                }
                firstFiveStars[0].transform.parent.gameObject.SetActive(false);
                moreThanFiveStars.SetActive(false);
                moreThanFiveStarsCount.gameObject.SetActive(false);
                handbookFullMark.SetActive(false);
                if(activateEff != null)
                    activateEff.SetActive(false);
                if(upgradeEff != null)
                    upgradeEff.SetActive(false);

                if (handbookPicture != null)
                {
                    handbookPicture.texture = null;
                    CommonTool.SetActive(handbookPicture.gameObject, false);
                }

                DestroyAssetRes();
            }

            private void DestroyAssetRes()
            {
                if (mAssetRes != null)
                {
                    mAssetRes.destroy();
                    mAssetRes = null;
                }
            }

            private IEnumerator LoadHandbookAssetAsync(string path)
            {
                var assetRes = new SGameEngine.AssetResource();
                yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(Texture), assetRes));
                DestroyAssetRes(); // 需要先销毁旧的图片资源
                mAssetRes = assetRes;
                if (handbookPicture == null)
                    yield break;
                if (mAssetRes == null || mAssetRes.asset_ == null)
                    yield break;
                mTextureObj = mAssetRes.asset_ as Texture;
                if (handbookPicture != null)
                {
                    handbookPicture.texture = mTextureObj;
                    CommonTool.SetActive(handbookPicture.gameObject, true);
                }
            }

            public void SetHandBookPicture(string picturePath)
            {
                StartCoroutine(LoadHandbookAssetAsync(picturePath));
            }

            public void SetHandBookInfo(int id, string name, int stars = -1, bool full = false, bool selected = false)
            {
                Reset();
                SetHandBookName(name);
                SetHandBookStars(stars);
                SetHandBookFull(full);

                handbookID = id;
            }

            public void SetHandBookName(string name)
            {
                handbookName.text = name;
            }

            public void SetHandBookPicture(Texture picture)
            {
                handbookPicture.texture = picture;
            }

            public void SetHandBookBorder(Sprite border)
            {
                handbookBorder.sprite = border;
            }

            public RawImage GetHandBookPicture()
            {
                return handbookPicture;
            }

            public void SetHandBookActive(bool isActive)
            {
                if (isActive == true)
                {
                    handbookInactiveMark.SetActive(false);
                    SetGrey(false);
                }
                else
                {
                    handbookInactiveMark.SetActive(true);
                    SetGrey(true);
                }
            }

            public void SetHandBookStars(int stars)
            {
                var active = stars >= HANDBOOK_MIN_STAR;
                SetHandBookActive(active);
                if (stars < HANDBOOK_MIN_STAR)
                {
                    firstFiveStars[0].transform.parent.gameObject.SetActive(false);
                }
                else if (stars <= firstFiveStars.Count)
                {
                    for (int i = 0; i < firstFiveStars.Count; i++)
                    {
                        var starObj = firstFiveStars[i];
                        starObj.SetActive(true);
                        var starActiveObj = starObj.transform.Find("Star").gameObject;
                        starActiveObj.SetActive(i < stars);
                    }
                    firstFiveStars[0].transform.parent.gameObject.SetActive(true);
                    moreThanFiveStars.SetActive(false);
                    moreThanFiveStarsCount.gameObject.SetActive(false);
                }
                else
                {
                    for (int i = 0; i < firstFiveStars.Count; i++)
                    {
                        var starObj = firstFiveStars[i];
                        starObj.SetActive(false);
                    }
                    firstFiveStars[0].transform.parent.gameObject.SetActive(false);
                    moreThanFiveStars.SetActive(true);
                    moreThanFiveStarsCount.gameObject.SetActive(true);
                    moreThanFiveStarsCount.text = stars.ToString();
                }
            }

            public void SetHandBookFull(bool full)
            {
                handbookFullMark.SetActive(full);
            }

            public void SetGrey(bool is_grey)
            {
                if (is_grey)//变灰
                {
                    if (handbookPicture != null && handbookPicture.material != null)
                    {
                        // 先备份当前材质
                        if (pictureMat == null)
                            pictureMat = handbookPicture.material;

                        Material m = GameObject.Instantiate(handbookPicture.material) as Material;
                        m.SetFloat("_Grey", 0);  //灰白色
                        handbookPicture.material = m;
                    }
                }
                else//彩色
                {
                    // 还原之前的材质
                    if (pictureMat != null)
                    {
                        if (handbookPicture != null)
                            handbookPicture.material = pictureMat;
                    }
                }
            }

            public void SetToggleEnabled(bool bRet)
            {
                if (handbookToggle != null)
                {
                    handbookToggle.enabled = bRet;
                }
            }

            public void SetToggleOn(bool isOn)
            {
                if (handbookToggle != null)
                {
                    if (handbookToggle.isOn == isOn)
                    {
                        handbookToggle.isOn = !isOn;
                    }
                    handbookToggle.isOn = isOn;
                }
            }

            public void SetRedPointID(uint redPointID)
            {
                if (redPoint != null)
                {
                    redPoint.PointKey = redPointID;
                }
            }

            public void SetActivateEff(bool show)
            {
                if (activateEff != null)
                {
                    activateEff.SetActive(false);
                    activateEff.SetActive(show);
                }

                if (upgradeEff != null)
                    upgradeEff.SetActive(false);
            }

            public void SetUpgradeEff(bool show)
            {
                if (activateEff != null)
                {
                    activateEff.SetActive(false);
                }

                if (upgradeEff != null)
                {
                    upgradeEff.SetActive(false);
                    upgradeEff.SetActive(show);
                }
            }
        }
    }
}