//--------------------------------------------------
// File : FuryButton.cs
// Desc: 怒气技能按钮的逻辑
// Author: Raorui
// Date: 2017.12.11
//--------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using xc;
using xc.ui;
using xc.ui.ugui;

[wxb.Hotfix]
class FuryButton : MonoBehaviour
{
    /// <summary>
    /// 怒气技能槽的孔位
    /// </summary>
    const uint mFuryHole = 7;

    /// <summary>
    /// 怒气槽是否已开启
    /// </summary>
    bool mHoleOpen = false;

    /// <summary>
    /// 怒气技能可释放时候的特效
    /// </summary>
    GameObject mNoticeEffect;

    /// <summary>
    /// 怒气技能点击时候的特效
    /// </summary>
    GameObject mNoticeEffectClick;

    /// <summary>
    /// 怒气技能更换成功的特效
    /// </summary>
    GameObject mChangeEffect;

    /// <summary>
    /// 显示怒气进度的Image
    /// </summary>
    Image mSliderImage;

    /// <summary>
    /// 怒气按钮的物体
    /// </summary>
    GameObject mPowerButtonObject;

    Transform mCacheTrans;

    /// <summary>
    /// Sprite的列表，用于更换技能图标
    /// </summary>
    SpriteList mSpriteList;

    Image mSkillImage;

    /// <summary>
    /// 长按按键的协程
    /// </summary>
    IEnumerator mCoroutine;

    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        mInstance = this;
        mCacheTrans = transform;
        mSpriteList = mCacheTrans.parent.GetComponent<SpriteList>();

        Transform mPowerTrans = transform.Find("PowerButton");
        mSkillImage = mPowerTrans.Find("SkillImg").GetComponent<Image>();
        mPowerButtonObject = mPowerTrans.gameObject;
        mNoticeEffect = mPowerTrans.Find("NoticeEffect").gameObject;
        mNoticeEffect.SetActive(false);
        mNoticeEffectClick = mPowerTrans.Find("NoticeEffect_back").gameObject;
        mNoticeEffectClick.SetActive(false);

        var childTrans = mPowerTrans.Find("ChangeEffect");
        if(childTrans != null)
        {
            mChangeEffect = childTrans.gameObject;
            if (mChangeEffect != null)
                mChangeEffect.SetActive(false);
        }

        mSliderImage = mPowerTrans.Find("Slider").GetComponent<Image>();
        EventTriggerListener.GetListener(mPowerButtonObject).onPointerClick += OnClick;
        EventTriggerListener.GetListener(mPowerButtonObject).onPointerDown += OnDown;
        EventTriggerListener.GetListener(mPowerButtonObject).onPointerUp += OnUp;
        ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);

        SkillButtonManager.Instance.AddButton(mFuryHole, gameObject);
    }

    void OnEnable()
    {
        if (GlobalConfig.GetInstance().IsDebugMode)
        {
            return;
        }

        OnSkillUpdate(null);
    }

    /// <summary>
    /// 销毁
    /// </summary>
    void OnDestroy()
    {
        mInstance = null;

        StopPressWait();

        EventTriggerListener.GetListener(mPowerButtonObject).onPointerClick -= OnClick;
        EventTriggerListener.GetListener(mPowerButtonObject).onPointerDown += OnDown;
        EventTriggerListener.GetListener(mPowerButtonObject).onPointerUp += OnUp;

        ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
    }

    void Update()
    {
        // 技能即将开放时，先显示技能槽
        if (SkillHoleManager.Instance.IsHoleWillOpen(mFuryHole))
        {
            // 技能槽未开启
            if (!SkillHoleManager.Instance.IsHoleOpen(mFuryHole))
            {
                OnSkillNotFit();
            }
            else// 技能槽已经开启，说明即将开启的技能与已装备的技能共用技能槽，可以保留原有技能图片
            {
                if(mSkillInfo != null)
                    OnHoldOpen();
            }
                
            return;
        }

        // 怒气技能槽还没开启
        if (SkillHoleManager.Instance.IsHoleOpen(mFuryHole) == false)
        {
            OnHoldClose();
            return;
        }

        // 技能为空
        if (mSkillIdx == 0 || mSkillInfo == null)
        {
            OnSkillNotFit();
            return;
        }

        OnHoldOpen();
    }


    /// <summary>
    /// 点击按钮
    /// </summary>
    void OnClick(GameObject target)
    {
        if (GameInput.Instance.GetEnableInput() == false || mHoleOpen == false)
        {
            return;
        }

        // 玩家在安全区域内不响应
        Actor local_player = Game.Instance.GetLocalPlayer();
        if (local_player == null)
            return;

        if (local_player.IsInSafeArea)
        {
            UINotice.GetInstance().ShowMessage(xc.DBConstText.GetText("SKILL_CANNOT_SAFEAREA")); //在安全区无法使用技能
            return;
        }

        if (mSkillInfo == null)
            return;

        if (LocalPlayerManager.Instance.Fury < mSkillInfo.CostFury)
        {
            UINotice.Instance.ShowMessage(xc.DBConstText.GetText("FURY_CANNOT_USE")); // 怒气不足时候的提示
            return;
        }

        if (!local_player.CDCtrl.IsInCD(mSkillIdx))// 技能不在cd中
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(mSkillIdx));
        }
            
    }

    void OnDown(GameObject target)
    {
        if (mHoleOpen)
        {
            mCoroutine = OnPressLongTime();
            StartCoroutine(mCoroutine);
        }
    }

    /// <summary>
    /// 当一直按下时
    /// </summary>
    IEnumerator OnPressLongTime()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.ShowWindow("UISkillDescTipsWindow", mBasicSkillInfo, Vector3.zero, new Vector2(0, 0));
    }

    void OnUp(GameObject target)
    {
        StopPressWait();
        UIManager.Instance.CloseWindow("UISkillDescTipsWindow");
    }

    /// <summary>
    /// 停止协程
    /// </summary>
    void StopPressWait()
    {
        if (mCoroutine != null)
        {
            StopCoroutine(mCoroutine);
            mCoroutine = null;
        }
    }

    uint mSkillIdx;
    DBDataAllSkill.AllSkillInfo mBasicSkillInfo;
    DBSkillSev.SkillInfoSev mSkillInfo;
    public DBSkillSev.SkillInfoSev SkillInfo
    {
        get
        {
            return mSkillInfo;
        }
    }

    /// <summary>
    /// 网络断线重连
    /// </summary>
    /// <param name="data"></param>
    void OnNetReconnect(CEventBaseArgs data)
    {
        OnSkillUpdate(null);
    }

    /// <summary>
    /// 技能装配信息发生改变
    /// </summary>
    void OnSkillUpdate(xc.ClientEventBaseArgs data)
    {
        if (mCacheTrans == null)
            return;

        uint skillId = SkillManager.GetInstance().GetFitSkillId(mFuryHole);
        if (mSkillIdx != skillId)
        {
            // 装配的技能ID更换的时候，触发特效
            if(mSkillIdx != 0)
            {
                if(mChangeEffect != null)
                {
                    mChangeEffect.SetActive(false);
                    mChangeEffect.SetActive(true);
                }
            }

            mSkillIdx = skillId;
        }

        mBasicSkillInfo = DBManager.Instance.GetDB<DBDataAllSkill>().GetOneAllSkillInfo_byActiveSkillId(skillId);
        mSkillInfo = DBSkillSev.Instance.GetSkillInfo(skillId);

        // 设置技能图标
        if (mBasicSkillInfo != null && mSpriteList != null)
        {
            var sprite = mSpriteList.LoadSprite(mBasicSkillInfo.Icon);
            if (sprite != null)
            {
                mSkillImage.color = Color.white;
                mSkillImage.sprite = sprite;
                return;
            }
        }

        // 技能未装配，不显示技能对应图片
        mSkillImage.color = Color.clear;
    }

    void OnHoldClose()
    {
        CommonTool.SetActive(mPowerButtonObject, false);
        mHoleOpen = false;
        mFuryState = false;
    }

    void OnSkillNotFit()
    {
        CommonTool.SetActive(mPowerButtonObject, true);
        mSkillImage.color = Color.clear;

        // 设置怒气的进度条
        if (mSliderImage != null)
            mSliderImage.fillAmount = 0;

        if (mNoticeEffect != null)
            mNoticeEffect.SetActive(false);
        if (mNoticeEffectClick != null)
            mNoticeEffectClick.SetActive(false);

        mHoleOpen = false;
        mFuryState = false;
    }

    bool mFuryState = false;

    void OnHoldOpen()
    {
        CommonTool.SetActive(mPowerButtonObject, true);

        mSkillImage.color = Color.white;

        // 设置怒气的进度条
        if (mSliderImage != null)
        {
                if (mSkillInfo.CostFury == 0)
                    mSliderImage.fillAmount = 0;
                else
                    mSliderImage.fillAmount = LocalPlayerManager.Instance.Fury / (float)mSkillInfo.CostFury;
            }

        // 设置怒气可释放的提示
        if (LocalPlayerManager.Instance.Fury < mSkillInfo.CostFury)
        {
            mFuryState = false;
            if (mNoticeEffect != null)
            {
                if (mNoticeEffect.activeSelf == true)
                {
                    mNoticeEffectClick.SetActive(false);
                    mNoticeEffectClick.SetActive(true);
                    mNoticeEffect.SetActive(false);
                }
            }
                
        }
        else
        {
            if (mNoticeEffect != null)
            {
                if (mNoticeEffect.activeSelf == false)
                    mNoticeEffect.SetActive(true);
            }

            if(mFuryState == false)
            {
                mFuryState = true;
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_FURYSKILL_CANUSE, null);
            }
        }

        mHoleOpen = true;
    }

    static FuryButton mInstance = null;

    /// <summary>
    /// 当前的怒气技能是否可用
    /// </summary>
    /// <returns></returns>
    public static bool IsFurySkillReady()
    {
        if (mInstance == null)
            return false;

        var skill_info = mInstance.SkillInfo;
        if (skill_info == null)
            return false;

        return LocalPlayerManager.Instance.Fury >= skill_info.CostFury;
    }
}

