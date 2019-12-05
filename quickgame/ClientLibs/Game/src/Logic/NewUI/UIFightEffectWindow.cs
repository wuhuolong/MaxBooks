using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIFightEffectWindow : UIBaseWindow
    {
        GameObject mFightingTipRoot;
        GameObject mFightingTipContainer;
        GameObject mFightingTipItem;
        List<GameObject> mLayoutLevelList;

        float m_showAddBuffTipsInterval = 2f;

        public class FightEffectItemStruct
        {
            public string m_name;
            public GameObject m_obj;

            public FightEffectItemStruct(string var_name, int maxNum)
            {
                m_name = var_name;
                mCriticDamageObjMaxNum = maxNum;
            }

            GameObject[] mCriticDamageValueObjs;
            int mCriticDamageObjIdx;
            int mCriticDamageObjMaxNum = 5;

            public GameObject CurObj
            {
                get
                {
                    if (m_obj == null)
                        return null;

                    if (mCriticDamageValueObjs == null)
                    {
                        mCriticDamageValueObjs = new GameObject[mCriticDamageObjMaxNum];
                        mCriticDamageObjIdx = 0;
                    }

                    GameObject mCurObj = mCriticDamageValueObjs[mCriticDamageObjIdx];

                    if (mCurObj == null)
                    {
                        GameObject obj = (GameObject)GameObject.Instantiate(m_obj);
                        Transform objTrans = obj.transform;
                        objTrans.SetParent(m_obj.transform.parent);
                        objTrans.localPosition = m_obj.transform.localPosition;
                        objTrans.localScale = m_obj.transform.localScale;
                        objTrans.localRotation = m_obj.transform.localRotation;

                        mCurObj = obj;
                        mCriticDamageValueObjs[mCriticDamageObjIdx] = mCurObj;
                    }

                    mCriticDamageObjIdx++;
                    mCriticDamageObjIdx %= mCriticDamageObjMaxNum;

                    var delay_enable = mCurObj.GetComponent<DelayEnableComponent>();
                    if (delay_enable == null)
                        delay_enable = mCurObj.AddComponent<DelayEnableComponent>();
                    delay_enable.Reset();

                    mCurObj.SetActive(false);
                    return mCurObj;
                }
            }
        }

        public static Dictionary<FightEffectHelp.FightEffectType, FightEffectItemStruct> m_fightEffectItemArray = new Dictionary<FightEffectHelp.FightEffectType, FightEffectItemStruct>()
        {
            { FightEffectHelp.FightEffectType.EnemyDamage, new FightEffectItemStruct("EnemyDamage", 20)},
            { FightEffectHelp.FightEffectType.Attendant_damage, new FightEffectItemStruct("AttendantDamage", 20)},
            { FightEffectHelp.FightEffectType.CriticEnemyDamage, new FightEffectItemStruct("CritEnemyDamage", 20)},
            { FightEffectHelp.FightEffectType.CriticAttendantDamage, new FightEffectItemStruct("CriticAttendantDamage", 20)},
            { FightEffectHelp.FightEffectType.OurDamage, new FightEffectItemStruct("OurDamage", 5)},

            { FightEffectHelp.FightEffectType.BounceDamage, new FightEffectItemStruct("BounceDamage", 5)},
            { FightEffectHelp.FightEffectType.Dodge, new FightEffectItemStruct("Dodge", 5)},
            { FightEffectHelp.FightEffectType.AbsoluteDoge, new FightEffectItemStruct("AbsoluteDoge", 5)},
            { FightEffectHelp.FightEffectType.Parry, new FightEffectItemStruct("Parry", 5)},
            { FightEffectHelp.FightEffectType.Invincible, new FightEffectItemStruct("Invincible", 5)},
            { FightEffectHelp.FightEffectType.Accelerate, new FightEffectItemStruct("Accelerate", 5)},

            { FightEffectHelp.FightEffectType.AddHp, new FightEffectItemStruct("AddHP", 5)},
            { FightEffectHelp.FightEffectType.AddMp, new FightEffectItemStruct("AddMP", 5)},
            { FightEffectHelp.FightEffectType.AddExp, new FightEffectItemStruct("AddEXP", 5)},
            { FightEffectHelp.FightEffectType.AddSp, new FightEffectItemStruct("AddSP", 5)},
            { FightEffectHelp.FightEffectType.AttackSp, new FightEffectItemStruct("AttackSp", 5)},
            { FightEffectHelp.FightEffectType.Immune, new FightEffectItemStruct("Immune", 5)},
            { FightEffectHelp.FightEffectType.OneHitKill, new FightEffectItemStruct("OneHitKill", 5)},
            { FightEffectHelp.FightEffectType.DamageDrain, new FightEffectItemStruct("DamageDrain", 5)},
            { FightEffectHelp.FightEffectType.FollowAttack, new FightEffectItemStruct("FollowAttack", 5)},
        };

        protected override void InitUI()
        {
            foreach(var item in m_fightEffectItemArray)
            {
                item.Value.m_obj = FindChild(item.Value.m_name);
                if (item.Value.m_obj != null)
                    item.Value.m_obj.SetActive(false);
            }

            m_showAddBuffTipsInterval = GameConstHelper.GetFloat("GAME_BF_SHOW_ADD_BUFF_TIPS_INTERVAL");

            mFightingTipRoot = FindChild("FightingTipRoot");
            mFightingTipRoot.SetActive(true);
            mFightingTipContainer = FindChild(mFightingTipRoot, "Container");
            mFightingTipItem = FindChild(mFightingTipRoot, "ItemTemplate");
            mFightingTipItem.SetActive(false);

            mLayoutLevelList = new List<GameObject>();
            for (int i = 0; i < 5; i++)
            {
                var layoutLevel = FindChild(string.Format("LayoutLevel_{0}", i));
                mLayoutLevelList.Add(layoutLevel);
            }

            InitFightTipPanel();

            base.InitUI();
        }

        protected override void ResetUI()
        {
            base.ResetUI();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        /// <summary>
        /// 根据 FightEffectHelp.FightEffectType 返回一个合适的飘字 GameObject
        /// </summary>
        /// <param name="var_type"></param>
        /// <returns></returns>
        public GameObject GetObjectByFightEffectType(FightEffectHelp.FightEffectType var_type)
        {
            FightEffectItemStruct find_struct;
            m_fightEffectItemArray.TryGetValue(var_type, out find_struct);
            if (find_struct == null)
                return null;
            return find_struct.CurObj;
        }

        public class BuffTipEffect
        {
            public GameObject m_root_obj;
            public Text m_label;
            public Image m_leftImage;
            public Image m_rightImage;
            public Image m_bkg;
        }

        List<BuffTipEffect> mFightingTipCacheList = new List<BuffTipEffect>();
        int m_nextShowTipsIndex = 0;    //下一个显示的tips位置

        void InitFightTipPanel()
        {
            for (int i = 0; i < 4; i++)
            {
                var itemGo = GameObject.Instantiate(mFightingTipItem);
                itemGo.SetActive(false);
                BuffTipEffect tmp = new BuffTipEffect();
                tmp.m_root_obj = itemGo;
                tmp.m_bkg = itemGo.GetComponent<Image>();
                Transform cell_transform = itemGo.transform.Find("cell");
                tmp.m_label = cell_transform.Find("label").GetComponent<Text>();
                tmp.m_leftImage = cell_transform.Find("leftImage").GetComponent<Image>();
                tmp.m_rightImage = cell_transform.Find("rightImage").GetComponent<Image>();
                tmp.m_root_obj.transform.SetParent(mFightingTipContainer.transform);
                tmp.m_root_obj.transform.localScale = Vector3.one;
                tmp.m_root_obj.transform.localPosition = Vector3.zero;
                tmp.m_root_obj.transform.localRotation = Quaternion.identity;
                tmp.m_root_obj.name = i.ToString();
                mFightingTipCacheList.Add(tmp);
            }
        }

        public void ShowFightingTip(string tipStr)
        {
            var buffTipsItem = mFightingTipCacheList[m_nextShowTipsIndex];

            var tipText = buffTipsItem.m_label;

            buffTipsItem.m_root_obj.SetActive(true);
            tipText.text = tipStr;

            Vector2 perfect_size = new Vector2(tipText.preferredWidth + 40, tipText.preferredHeight + 15);
            buffTipsItem.m_bkg.rectTransform.sizeDelta = perfect_size;
            buffTipsItem.m_leftImage.rectTransform.sizeDelta = new Vector2(perfect_size.x / 2, perfect_size.y);
            buffTipsItem.m_leftImage.rectTransform.localPosition = new Vector3(-perfect_size.x / 4, 0, 0);
            buffTipsItem.m_rightImage.rectTransform.sizeDelta = new Vector2(perfect_size.x / 2, perfect_size.y);
            buffTipsItem.m_rightImage.rectTransform.localPosition = new Vector3(perfect_size.x / 4, 0, 0);

            var delayTime = buffTipsItem.m_root_obj.GetComponent<DelayTimeComponent>();
            if (delayTime != null)
            {
                GameObject.Destroy(delayTime);
            }

            delayTime = buffTipsItem.m_root_obj.AddComponent<DelayTimeComponent>();
            delayTime.Start();
            delayTime.DelayTime = m_showAddBuffTipsInterval;
            delayTime.SetEndCallBack(new DelayDestroyComponent.EndCallBackInfo(OnFightingTipShowTimeEnd, buffTipsItem));

            m_nextShowTipsIndex = (m_nextShowTipsIndex + 1) % mFightingTipCacheList.Count;
            ResetTipsArrayPosition();
        }

        void ResetTipsArrayPosition()
        {
            int real_index = 0;
            int show_tips_count = 0;
            int total_count = mFightingTipCacheList.Count;
            for (int index = 0; index < total_count; ++index)
            {
                real_index = (total_count + m_nextShowTipsIndex - index - 1) % total_count;
                if (mFightingTipCacheList[real_index].m_root_obj.activeSelf)
                {
                    mFightingTipCacheList[real_index].m_root_obj.transform.localPosition = new Vector3(0, 28 + show_tips_count * (-50), 0);
                    show_tips_count++;
                }
            }
        }

        void OnFightingTipShowTimeEnd(object ob)
        {
            var tipText = (BuffTipEffect)ob;
            RecycleFightingTipItem(tipText);
        }

        void RecycleFightingTipItem(BuffTipEffect tipText)
        {
            tipText.m_root_obj.SetActive(false);
        }

        public void SetGameObjectLayoutLevel(GameObject go, int level)
        {
            if (go == null || mLayoutLevelList == null)
                return;
            if(level < 0 || level >= mLayoutLevelList.Count)
            {
                return;
            }
            if (mLayoutLevelList[level] == null || mLayoutLevelList[level].transform == null)
                return;
            go.transform.SetParent(mLayoutLevelList[level].transform);
            go.transform.localPosition = mLayoutLevelList[level].transform.localPosition;
            go.transform.localScale = mLayoutLevelList[level].transform.localScale;
            go.transform.localRotation = mLayoutLevelList[level].transform.localRotation;
        }

        /// <summary>
        /// 返回某个飘字类型的起始世界坐标位置(相对于UICamera)（PS：若没有挂点，则返回脚底坐标）
        /// </summary>
        /// <param name="target"></param>
        /// <param name="effect_type"></param>
        /// <param name="screen_abs_offset">屏幕绝对偏移值</param>
        /// <returns></returns>
        public static Vector3 GetEffectWorldPosInUIByType(Actor target, FightEffectHelp.FightEffectType effect_type, out Vector3 worldPosInScene, out Vector2 screen_abs_offset)
        {
            screen_abs_offset = Vector2.zero;
            worldPosInScene = Vector3.zero;
            if (target == null || target.transform == null)
                return Vector3.zero;

            Vector3 worldPos;
            DBFightFlyWord.DBFightFlyWordISev flyWordSev = DBFightFlyWord.Instance.GetFightFlyWordInfo((int)effect_type);
            if (flyWordSev != null && flyWordSev.IsScreenCenterBone)//屏幕中心点坐标
            {
                Camera mainCam = xc.ui.ugui.UIMainCtrl.MainCam;
                screen_abs_offset = new Vector2(mainCam.pixelWidth * (0.5f + flyWordSev.XOffset / 1280), mainCam.pixelHeight * (0.5f + flyWordSev.YOffset / 720));
                worldPos = mainCam.ScreenToWorldPoint(new Vector3(screen_abs_offset.x, screen_abs_offset.y));
                worldPos.z = 0;
                return worldPos;
            }
            if (flyWordSev == null)//错误飘字类型
            {
                worldPosInScene = target.transform.position;
            }
            else
            {
                Transform slot_transform = target.GetSlotTransform(flyWordSev.Bone);
                if (slot_transform == null)
                    worldPosInScene = target.transform.position;
                else
                    worldPosInScene = slot_transform.position;
            }
            Camera mainCamera = Game.Instance.MainCamera;
            Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPosInScene);
            if (flyWordSev != null)
            {
                screen_abs_offset = new Vector2(mainCamera.pixelWidth * flyWordSev.XOffset / 1280, mainCamera.pixelHeight * flyWordSev.YOffset / 720);
                screenPos.x += screen_abs_offset.x;
                screenPos.y += screen_abs_offset.y;
            }

            worldPos = xc.ui.ugui.UIMainCtrl.MainCam.ScreenToWorldPoint(screenPos);
            worldPos.z = 0;
            return worldPos;
        }
    }
}
