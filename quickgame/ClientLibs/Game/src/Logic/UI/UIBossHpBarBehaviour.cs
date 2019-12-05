using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;
using System;

namespace xc.ui.ugui
{
    // Boss血条实现：通过当前正在变化的标签mScrollHpImageIndex与实际当前血量标签mCurrentHpImageIndex来控制血条的滑动
    // 回血/扣血都是标签mScrollHpImageIndex向mCurrentHpImageIndex标签靠拢来处理
    [wxb.Hotfix]
    public class UIBossHpBarBehaviour : IUIBehaviour
    {
        float mDefaultHpChangeOffsetPerFrame = 0.01f;

        GameObject mUIObject;

        Text mBossNameText;
        Image mBossIconImage;
        Text mBossLevelText;
        Text mBossHpBarCountText;

        GameObject mBossEvilPanel;
        Text mBossEvilValue;     // Boss的浊气值(南天圣地)

        Image mHpBarBgImage;
        Slider mAlphaSlider;
        Slider mForegroundSlider;
        Image mForegroundImage;
        List<Image> mHpBarImageList;

        ActorMono mTargetMono;
        long mHpValuePerHpBar;
        List<Image> mTargetHpImageList;
        int mTargetHpImageIndex;
        int mCurrentHpImageIndex;
        float mTargetHpBarPercent;
        UIMainMapAnimationBehaviour mUIMainMapAnimationBehaviour;
        public bool m_is_active = false;
        public static bool m_show_boss_hp = false;
        public static bool m_show_player_hp = false;
        public static bool m_final_show_hp = false;
        public static void SetShowBossHp(bool is_show)
        {
            m_show_boss_hp = is_show;
            UpdateHpBar();
        }

        public static void SetShowPlayerHp(bool is_show)
        {
//             m_show_player_hp = is_show;
//             UpdateHpBar();
        }
        public static void UpdateHpBar()
        {
            bool new_show_hp = false;
            if (m_show_boss_hp || m_show_player_hp)
                new_show_hp = true;
            string state = new_show_hp == true ? "Battle" : "Normal";
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_STATE_CHANGED, new CEventBaseArgs(state));
        }
        public override void InitBehaviour()
        {
            InitUI();
            InitEvent();
            base.InitBehaviour();
        }

        public override void UpdateBehaviour()
        {
            Update();
            base.UpdateBehaviour();
        }

        public override void DestroyBehaviour()
        {
            UninitEvent();
            mUIObject = null;
            mTargetMono = null;
            base.DestroyBehaviour();
        }

        public override void EnableBehaviour(bool isEnable) 
        {
            base.EnableBehaviour(isEnable);
            //GameDebug.LogError("start EnableBehaviour = " + isEnable.ToString());
            SetActive(m_is_active);
            //GameDebug.LogError("end EnableBehaviour = " + isEnable.ToString());
        }

        void InitUI()
        {
            mUIMainMapAnimationBehaviour = Window.GetBehaviour("UIMainMapAnimationBehaviour") as UIMainMapAnimationBehaviour;
            mUIObject = UIHelper.FindChild(Window.mUIObject, "BossHpBar");
            mUIObject.SetActive(false);
            m_is_active = false;
            //GameDebug.LogError("start InitUI = " + m_is_active.ToString());
            SetActive(false);
            //GameDebug.LogError("end InitUI = " + m_is_active.ToString());
            mBossNameText = UIHelper.FindChild(mUIObject, "BossNameText").GetComponent<Text>();
            mBossIconImage = UIHelper.FindChild(mUIObject, "BossIconImage").GetComponent<Image>();
            mBossLevelText = UIHelper.FindChild(mUIObject, "LvText").GetComponent<Text>();
            mBossHpBarCountText = UIHelper.FindChild(mUIObject, "HpBarCountText").GetComponent<Text>();
            mHpBarBgImage = UIHelper.FindChild(mUIObject, "HpBarBgImage").GetComponent<Image>();
            mAlphaSlider = UIHelper.FindChild(mUIObject, "AlphaSlider").GetComponent<Slider>();
            mForegroundSlider = UIHelper.FindChild(mUIObject, "ForegroundSlider").GetComponent<Slider>();
            mForegroundImage = UIHelper.FindChild(mForegroundSlider.gameObject, "Fill").GetComponent<Image>();

            mBossEvilPanel = UIHelper.FindChild(mUIObject, "BossEvilPanel");
            mBossEvilValue = UIHelper.FindChild(mBossEvilPanel, "EvilValue").GetComponent<Text>();

            mHpBarImageList = new List<Image>();
            for (int i = 0; i < 5; i++)
            {
                var img = UIHelper.FindChild(mUIObject, ("HpImage" + (i + 1))).GetComponent<Image>();
                img.gameObject.SetActive(false);
                mHpBarImageList.Add(img);
            }
        }

        void InitEvent()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_BATTLESTATUS_CHANGE, OnBattleStatusChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, OnSelectActorChange);
            xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
        }

        void UninitEvent()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_BATTLESTATUS_CHANGE, OnBattleStatusChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, OnSelectActorChange);
            xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
        }

        void OnBattleStatusChange(CEventBaseArgs msg)
        {
            bool isInBattleStatus = (bool)msg.arg;
            if (!isInBattleStatus)
            {
                // 脱战
                //脱战不取消选中状态(2018/7/19)
//                 mTargetMono = null;
//                 SetHpBarPanelVisible(false);
            }
            else
            {
                var local_player = Game.Instance.GetLocalPlayer();
                if (local_player != null && local_player.AttackCtrl != null 
                    && local_player.AttackCtrl.CurSelectActor != null)
                {
                    OnSelectActorChange(new CEventBaseArgs(local_player.AttackCtrl.CurSelectActor));
                }
            }
        }

        void OnSelectActorChange(CEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (msg == null || msg.arg == null)
            {
                mTargetMono = null;
                SetHpBarPanelVisible(false);
                return;
            }

            var monoActor = msg.arg as ActorMono;
            if (monoActor == null || monoActor.BindActor == null || !monoActor.BindActor.IsBoss())
            {
                mTargetMono = null;
                SetHpBarPanelVisible(false);
                return;
            }

            if (mTargetMono != null && monoActor.BindActor.UID == mTargetMono.BindActor.UID)
            {
                return;
            }

            SetHpBarPanelVisible(true);
            mTargetMono = monoActor;
            InitData();

            SetBossInfoPanel();
        }

        void SetBossInfoPanel()
        {
            var actor = mTargetMono.BindActor;
            var actorData = GetActorData(actor.ActorId);
            if (actorData == null)
            {
                GameDebug.LogError("actorData == null, ActorID:" + actor.ActorId);
                return;
            }

            int barCount = actorData.hp_bar_count;
            string iconName = RoleHelp.GetRoleIcon(actor.ActorId);

            if(GlobalConst.IsBanshuVersion)
                mBossLevelText.text = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_113"), actor.Level.ToString());
            else
                mBossLevelText.text = string.Format("LV{0}", actor.Level.ToString());
            mBossNameText.text = actor.Name;

            mBossIconImage.sprite = Window.LoadSprite(iconName);

            UpdateRemainHpBarCount();
        }

        void UpdateRemainHpBarCount()
        {
            if (GlobalConst.IsBanshuVersion)
                mBossHpBarCountText.text = string.Format("*{0}", (mCurrentHpImageIndex + 1).ToString());
            else
                mBossHpBarCountText.text = string.Format("x{0}", (mCurrentHpImageIndex + 1).ToString());
        }

        void SwitchToNextHpBar(bool isReduceHp)
        {
            if (mTargetHpImageList == null)
                return;

            //【[优化]血条问题】
            //https://www.tapd.cn/20249401/prong/stories/view/1120249401001009955
            //mCurrentHpImageIndex += isReduceHp ? -1 : 1;
            mCurrentHpImageIndex = mTargetHpImageIndex;

            // 设置背景血条
            int bgImageIndex = mCurrentHpImageIndex - 1;
            mHpBarBgImage.gameObject.SetActive(bgImageIndex >= 0);
            if (bgImageIndex >= 0)
            {
                if(mTargetHpImageList != null && bgImageIndex < mTargetHpImageList.Count)
                {
                    var image = mTargetHpImageList[bgImageIndex];
                    mHpBarBgImage.sprite = image.sprite;
                }
            }
            if (mTargetHpImageList == null || mCurrentHpImageIndex < 0 || mCurrentHpImageIndex >= mTargetHpImageList.Count)
                return;
            // 设置当前血条
            mForegroundImage.sprite = mTargetHpImageList[mCurrentHpImageIndex].sprite;
            mForegroundImage.gameObject.SetActive(mCurrentHpImageIndex == mTargetHpImageIndex);

            if (isReduceHp)
            {
                mForegroundSlider.value = mTargetHpBarPercent;
                mAlphaSlider.value = 1;
            }
            else
            {
                mForegroundSlider.value = 0;

                if (mCurrentHpImageIndex == mTargetHpImageIndex)
                {
                    mAlphaSlider.value = mTargetHpBarPercent;
                }
                else
                {
                    mAlphaSlider.value = 1;
                }
            }
        }

        void InitData()
        {
            // 浊气值
            SetEvilValue();

            var actorData = GetActorData(mTargetMono.BindActor.ActorId);
            if(mTargetMono.BindActor.FullLife <= 0)
            {
                GameDebug.LogError(string.Format("mTargetMono.BindActor.FullLife is {0} (less than 0) ActorId = {1}", 
                    mTargetMono.BindActor.FullLife, mTargetMono.BindActor.ActorId));
                return;
            }
           
            int hp_bar_count = actorData.hp_bar_count;
            if (hp_bar_count <= 0)
            {
                GameDebug.LogError(string.Format("actor.ActorId = {0} actorData.hp_bar_count is {1}",
                    mTargetMono.BindActor.ActorId, actorData.hp_bar_count));
                hp_bar_count = 1;
            }
            mHpValuePerHpBar = Mathf.CeilToInt(1.0f * mTargetMono.BindActor.FullLife / hp_bar_count);
            if (mHpValuePerHpBar * hp_bar_count < mTargetMono.BindActor.FullLife)
                mHpValuePerHpBar = mHpValuePerHpBar + 1;
            CaculateTargetHpImageList();

            mTargetHpImageIndex = (int)((mTargetMono.BindActor.CurLife - 1) / mHpValuePerHpBar);
            mTargetHpImageIndex = Math.Max(0, mTargetHpImageIndex);
            mCurrentHpImageIndex = mTargetHpImageIndex;

            if (mTargetHpImageList == null || mTargetHpImageList.Count <= 0)
            {
                GameDebug.LogError(string.Format("mTargetHpImageList.Count is zero; ActorId = {0}",
                    mTargetMono.BindActor.ActorId));
                return;
            }
            if (mTargetHpImageIndex < 0 || mTargetHpImageIndex >= mTargetHpImageList.Count)
            {
                GameDebug.LogError(string.Format("mTargetHpImageList.Count is zero; ActorId = {0}",
                    mTargetMono.BindActor.ActorId));
                return;
            }
            mForegroundImage.sprite = mTargetHpImageList[mTargetHpImageIndex].sprite;
            mForegroundImage.gameObject.SetActive(true);

            if (mTargetMono.BindActor.CurLife == mTargetMono.BindActor.FullLife)
            {
                mForegroundSlider.value = 1;
            }
            else
            {
                mForegroundSlider.value = (float)((double)(mTargetMono.BindActor.CurLife % mHpValuePerHpBar) / (double)mHpValuePerHpBar);
            }
            mAlphaSlider.value = mForegroundSlider.value;
            mTargetHpBarPercent = mForegroundSlider.value;

            var bgImageIndex = mCurrentHpImageIndex - 1;
            mHpBarBgImage.gameObject.SetActive(bgImageIndex>=0);
            if (bgImageIndex >=0)
            {
                mHpBarBgImage.sprite = mTargetHpImageList[bgImageIndex].sprite;
            }
        }

        void SetEvilValue()
        {
            bool bDisplayEvil = false;
            uint value = 0;

            if (xc.SceneHelp.Instance.IsInSouthLandInstance) // 南天圣地
            {
                var evilValueItem = DBManager.Instance.GetDB<DBEvilValue>().GetData(mTargetMono.BindActor.ActorId);
                if (null != evilValueItem)
                {
                    bDisplayEvil = true;
                    value = evilValueItem.Value;
                }
            }
            else if (xc.SceneHelp.Instance.IsInElementAreaInstance) // 元素禁地
            {
                var evilValueItem = DBManager.Instance.GetDB<DBElementAreaEvilValue>().GetData(mTargetMono.BindActor.ActorId);
                if (null != evilValueItem)
                {
                    bDisplayEvil = true;
                    value = evilValueItem.Value;
                }
            }

            mBossEvilValue.text = value.ToString();
            mBossEvilPanel.SetActive(bDisplayEvil);
        }

        void CaculateTargetHpImageList()
        {
            if (mTargetHpImageList == null)
            {
                mTargetHpImageList = new List<Image>();
            }
            mTargetHpImageList.Clear();

            var actor = mTargetMono.BindActor;
            var actorData = GetActorData(actor.ActorId);

            int imageIndex = 0;
            int hp_bar_count = actorData.hp_bar_count;
            if (hp_bar_count <= 0)
            {
                GameDebug.LogError(string.Format("actor.ActorId = {0} actorData.hp_bar_count is {1}",
                    actor.ActorId, actorData.hp_bar_count));
                hp_bar_count = 1;
            }
            for (int i = 0; i < actorData.hp_bar_count; i++)
            {
                if (imageIndex < mHpBarImageList.Count)
                {
                    mTargetHpImageList.Add(mHpBarImageList[imageIndex]);
                    imageIndex++;
                }
                else
                {
                    imageIndex = 0;
                    mTargetHpImageList.Add(mHpBarImageList[imageIndex]);
                    imageIndex++;
                }
            }
        }

        DBActor.ActorData GetActorData(uint npcID)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (db.ContainsKey(npcID) == false)
            {
                GameDebug.LogError("Record does't exist. npcID:" + npcID);
                return null;
            } 

            return db.GetData(npcID);
        }

        void OnActorHpChange(xc.ClientEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (mTargetMono == null || mTargetMono.BindActor == null)
            {
                return;
            }

            var actor = (Actor)msg.GetArg();
            if (actor == null)
            {
                GameDebug.LogError("actor == null");
                return;
            }

            var targetActor = (Actor)mTargetMono.BindActor;
            if (targetActor.UID == actor.UID)
            {
                SetHpBarPanel();
            }
        }

        void SetHpBarPanel()
        {
            //GameDebug.LogError(string.Format("CurLife = {0} FullLife = {1}", mTargetMono.BindActor.CurLife, mTargetMono.BindActor.FullLife));
            if(mTargetMono.BindActor.CurLife > 0)
            {
                if (mHpValuePerHpBar <= 0)
                {
                    mHpValuePerHpBar = 1;
                }
                mTargetHpImageIndex = (int)((mTargetMono.BindActor.CurLife - 1) / mHpValuePerHpBar);
                mTargetHpImageIndex = Math.Max(0, mTargetHpImageIndex);
                mTargetHpBarPercent = (float)((double)((mTargetMono.BindActor.CurLife - 1) % mHpValuePerHpBar) / (double)mHpValuePerHpBar);
            }
            else
            {
                mTargetHpImageIndex = 0;
                mTargetHpBarPercent = 0;
            }

            if (mCurrentHpImageIndex > mTargetHpImageIndex)
            {
                mForegroundSlider.value = 0;
            }
        }

        void Update()
        {
            if (mTargetMono == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }

            if (mTargetMono.BindActor == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }

            if (HasReachTarget())
            {
                return;
            }

            ScrollHpBar();
        }

        bool HasReachTarget()
        {
            bool hasReachTarget = false;
            if (mCurrentHpImageIndex == mTargetHpImageIndex)
            {
                // 有误差，这里需要取一个范围值做判断
                bool hasAlphaReach = false;
                if (Mathf.Abs(mAlphaSlider.value - mTargetHpBarPercent) < mDefaultHpChangeOffsetPerFrame)
                {
                    mAlphaSlider.value = mTargetHpBarPercent;
                    hasAlphaReach = true;
                }

                bool hasForegroundReach = false;
                if (Mathf.Abs(mForegroundSlider.value - mTargetHpBarPercent) < mDefaultHpChangeOffsetPerFrame)
                {
                    mForegroundSlider.value = mTargetHpBarPercent;
                    hasForegroundReach = true;
                }

                hasReachTarget = hasAlphaReach && hasForegroundReach;
            }
            return hasReachTarget;
        }

        void ScrollHpBar()
        {
            var actor = mTargetMono.BindActor;

            if (mCurrentHpImageIndex > mTargetHpImageIndex && mAlphaSlider.value <= 0)
            {
                SwitchToNextHpBar(true);
                UpdateRemainHpBarCount();
                return;
            }

            if (mCurrentHpImageIndex < mTargetHpImageIndex && mForegroundSlider.value >= 1)
            {
                SwitchToNextHpBar(false);
                UpdateRemainHpBarCount();
                return;
            }

            // 取得变化率
            float offsetValue = mDefaultHpChangeOffsetPerFrame;
            if (mCurrentHpImageIndex != mTargetHpImageIndex)
            {
                offsetValue = mDefaultHpChangeOffsetPerFrame * 6;
            }

            // 扣血
            if (mCurrentHpImageIndex > mTargetHpImageIndex)
            {
                mAlphaSlider.value -= offsetValue;
            }

            // 回血
            if (mCurrentHpImageIndex < mTargetHpImageIndex)
            {
                mForegroundSlider.value += offsetValue;
                mAlphaSlider.value = mForegroundSlider.value;
            }

            // 当处于同一段血条时，向目标点mTargetHpBarPercent靠拢
            if (mCurrentHpImageIndex == mTargetHpImageIndex)
            {
                if (mForegroundSlider.value < mTargetHpBarPercent)
                {
                    // 回血
                    mForegroundSlider.value += offsetValue;
                    mForegroundSlider.value = Mathf.Min(mTargetHpBarPercent, mForegroundSlider.value);
                }
                else
                {
                    // 扣血
                    mForegroundSlider.value = mTargetHpBarPercent;
                }

                if (mAlphaSlider.value > mTargetHpBarPercent)
                {
                    mAlphaSlider.value -= offsetValue;
                    mAlphaSlider.value = Mathf.Max(mTargetHpBarPercent, mAlphaSlider.value);
                }
                else
                {
                    mAlphaSlider.value = mTargetHpBarPercent;
                }
            }
        }

        void SetHpBarPanelVisible(bool isVisible)
        {
            
            if (mUIObject != null&& m_is_active != isVisible)
            {
                SetActive(isVisible);
            }
            if (mUIObject)
            {
                if(mUIObject.activeSelf != isVisible)
                    mUIObject.SetActive(isVisible);
            }
        }

        void SetActive(bool var_is_active)
        {
            //GameDebug.LogError("var_is_active = " + var_is_active.ToString());
            m_is_active = var_is_active;
            if (var_is_active)
            {
                mUIObject.SetActive(true);
            }

            SetShowBossHp(var_is_active);
//             string state = var_is_active == true ? "Battle" : "Normal";
//             ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_STATE_CHANGED, new CEventBaseArgs(state));
        }
    }
}
