using System;
using UnityEngine;
namespace xc.ui
{
    public class UIWIldSwitchLine : MonoBehaviour
    {
        public GameObject goFold { get; set; }
        public GameObject goUnfold { get; set; }
        public UISprite spriteAmount { get; set; }
        public GameObject goSwitchBoard { get; set; }
        public GameObject goBar { get; set; }
        public UILabel labelWaitingNumTip { get; set; }
        public UIWildSwtichLineItem[] items { get; set; }

        public static UIWIldSwitchLine instance;
        public static readonly string mPrefabName = "UIWildSwitchLine";
        public static readonly string SPRITE_BAR_RED = "fiald_hong";
        public static readonly string SPRITE_BAR_GREEN = "fiald_lv";
        public static readonly string SPRITE_BAR_YELLOW = "fiald_renshutiao";

        private static float[] mPercent = new float[3];
        private UIWildSwtichLineItem mPrimary;


        private void Awake()
        {
            // TODO C# UIMainmapWindow 接口不可用，需要改成新的控制方式
            //UIMainmapWindow uiMainMap = UIManager.Instance.GetWindowImm<UIMainmapWindow>();
            //Transform anchorTarget = uiMainMap.FindChild("MinimapBgSprite").transform;
            //             UIWidget widget = goUnfold.GetComponent<UIWidget>();
            //             widget.leftAnchor.target = anchorTarget;
            //             widget.rightAnchor.target = anchorTarget;
            //             widget.bottomAnchor.target = anchorTarget;
            //             widget.topAnchor.target = anchorTarget;
            //             widget.ResetAndUpdateAnchors();

            instance = this;
            OnUnFold();
            OnAmountChanged(null);
            goSwitchBoard.SetActive(false);

            string[] splits = GameConstHelper.GetString("GAME_MWAR_WILD_HUMAN_COLOUR").Split(',', '[', ']');
            int index = 0;
            foreach (var item in splits)
            {
                float f = 0;
                if(index < mPercent.Length && float.TryParse(item, out f))
                {
                    mPercent[index] = f;
                    ++index;
                }
            }
        }

        private void Update()
        {
            if (mPrimary == null)
            {
                return;
            }
            mPrimary.EnableGO(LocalPlayerManager.Instance.LocalActorAttribute.BattlePower <= GameConstHelper.GetUint("GAME_WILD_PRIMARY_BATTLE_POWER"));
        }

        private void OnEnable()
        {
            WildManager.Instance.StartQueryAllLineAmount(true);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_WILD_HUMAN_COUNT_CHANGED, OnAmountChanged);
        }

        private void OnDisable()
        {
            if (WildManager.Instance != null)
            {
                WildManager.Instance.StartQueryAllLineAmount(false);
            }
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_WILD_HUMAN_COUNT_CHANGED, OnAmountChanged);
        }

        #region BAR
        public void OnFold()
        {
            goFold.SetActive(true);
            goUnfold.SetActive(false);
        }

        public void OnUnFold()
        {
            goFold.SetActive(false);
            goUnfold.SetActive(true);
        }

        public void OnAmountChanged(CEventBaseArgs evt)
        {
            var dic = WildManager.Instance.mLineAmout;
            if (dic.ContainsKey(WildManager.Instance.mCurrentLineId))
            {
                SetAmount(spriteAmount, dic[WildManager.Instance.mCurrentLineId]);
            }
            RefreshSwtichBoard();


        }

        public void OnShowSwitchBoard()
        {
            if (!Game.GetInstance().GetLocalPlayer().IsInSafeArea)
            {
                UINotice.Instance.ShowMessage(DBManager.Instance.GetDB<DBConstText>().Text("CHANGE_MAP"));
                return;
            }
            goSwitchBoard.SetActive(true);
            goBar.SetActive(false);
        }

        public static void SetAmount(UISprite sprite, uint num)
        {
            float percent = Mathf.Max((float) num / GameConstHelper.GetFloat("GAME_MWAR_WILD_MAX_HUMAN"), 0.2f);

            if (percent < 0.7f)
            {
                percent += 0.1f;
            }

            if (percent <= mPercent[0])
            {
                sprite.spriteName = SPRITE_BAR_GREEN;
            }
            else if (num <= mPercent[1] )
            {
                sprite.spriteName = SPRITE_BAR_YELLOW;
            }
            else
            {
                sprite.spriteName = SPRITE_BAR_RED;
            }
            sprite.fillAmount = percent;
        }
        #endregion

        #region SWITCH_BOARD
        public void OnExiotSwtichBoard()
        {
            goSwitchBoard.SetActive(false);
            goBar.SetActive(true);
        }

        public void RefreshSwtichBoard()
        {
            //set items
            mPrimary = null;
            int i = 0;
            foreach (var item in WildManager.Instance.mLineAmout)
            {
                if(i >= items.Length)
                {
                    break;
                }
                items[i].Set(item.Key, item.Value);
                items[i].gameObject.SetActive(true);
                if(item.Key == GameConstHelper.GetUint("GAME_WILD_DUNGEON_PRIMARY_ID"))
                {
                    mPrimary = items[i];
                }
                ++i;
            }
            for (int j =i; j< items.Length; j++)
            {
                items[j].gameObject.SetActive(false);
            }

            UIWildSwtichLineItem waitingItem = getItem(WildManager.Instance.mCurrentWaitingLineId);
            if (waitingItem != null)
            {
                labelWaitingNumTip.text = string.Format(xc.DBConstText.GetText("SWITCH_LINE_WAITING_TIP"), waitingItem.labelName.text, WildManager.Instance.mWaitingNum);
            }
            labelWaitingNumTip.gameObject.SetActive(waitingItem != null);
        }

        public void OnCancelQueue()
        {

        }

        private UIWildSwtichLineItem getItem(uint id)
        {
            if (id == 0)
            {
                return null;
            }
            foreach (var item in items)
            {
                if(item.mId == id)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion

    }
}

