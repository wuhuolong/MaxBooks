//-------------------------------------------
// File: RockButton.cs
// Desc: 技能按键的组件
// Author: raorui
// Date: 2017/9/13
//-------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using xc;
using xc.ui;
using xc.ui.ugui;

[wxb.Hotfix]
public class RockButton : MonoBehaviour
{
    #region VAR_NORMAL
    /// <summary>
    /// 是否需要按住持续触发
    /// </summary>
    bool mContinuePress = false;

    /// <summary>
    /// 按键的装配位置
    /// </summary>
    uint mFitPos = 1;

    /// <summary>
    /// 当前按键对应的技能id
    /// </summary>
    uint mSkillIdx;

    /// <summary>
    /// 按键对应的基本技能信息
    /// </summary>
    DBDataAllSkill.AllSkillInfo mBasicSkillInfo;

    /// <summary>
    /// 按键对应的战斗技能信息
    /// </summary>
    DBSkillSev.SkillInfoSev mSkillInfo;

    /// <summary>
    /// 技能是否在CD中
    /// </summary>
    bool mInCD = false;

    /// <summary>
    /// 技能槽是否开启
    /// </summary>
    bool mHoleOpen = false;

    /// <summary>
    /// 是否有吟唱阶段
    /// </summary>
    bool mHasCastingReadyStage = false;

    /// <summary>
    /// 按钮是否按下
    /// </summary>
    bool mIsPressed;

    /// <summary>
    /// 持续触发的间隔时间
    /// </summary>
    const float DetalTime = 0.2f;

    /// <summary>
    /// 持续触发的下次更新时间
    /// </summary>
    float mNextTime;

    /// <summary>
    /// 长按按键的协程
    /// </summary>
    IEnumerator mCoroutine;
    #endregion

    #region VAR_UIWIDGETS
    /// <summary>
    /// 技能CD遮罩的GameObject
    /// </summary>
    GameObject mCDMask;

    /// <summary>
    /// 技能CD遮罩的Image
    /// </summary>
    Image mCDMaskImage;

    /// <summary>
    /// CD的倒计时
    /// </summary>
    Text mCDLevel;

    /// <summary>
    /// 按钮未开启时候的提示文本
    /// </summary>
    Text mNoticeLabel;

    /// <summary>
    /// 技能升级的提示
    /// </summary>
    Text mLevelText;

    GameObject mLevelObject;

    /// <summary>
    /// 技能Button
    /// </summary>
    Button mButton;

    /// <summary>
    /// 按钮背景图
    /// </summary>
    Image mBackImage;

    /// <summary>
    /// 缓存的Transform
    /// </summary>
    Transform mCacheTrans;

    /// <summary>
    /// 技能锁对应的GameObject
    /// </summary>
    GameObject mSkillLockObj;

    /// <summary>
    /// 技能图片的Image
    /// </summary>
    Image mSkillImage;

    /// <summary>
    /// 按钮的EventListener
    /// </summary>
    EventTriggerListener mEventListener;

    /// <summary>
    /// Sprite的列表，用于更换技能图标
    /// </summary>
    SpriteList mSpriteList;

    /// <summary>
    /// CD结束时候播放的特效
    /// </summary>
    GameObject mCDBlink;

    /// <summary>
    /// CD特效定时取消激活的组件
    /// </summary>
    DelayEnableComponent mCDBlinkDelayer;

    /// <summary>
    /// 点击按钮时候播放的特效
    /// </summary>
    GameObject mClickEffect;

    /// <summary>
    /// 点击特效定时取消激活的组件
    /// </summary>
    DelayEnableComponent mClickEffectDelayer;
    #endregion

    #region FUNCTION_ENGINE
    void Awake()
    {
        if (uint.TryParse(gameObject.name, out mFitPos) == false)
        {
            mFitPos = 1;
            GameDebug.Log("mFitPos is invalid");
        }

        if (mFitPos == 1)
            mContinuePress = true;
        else
            mContinuePress = false;

        SkillButtonManager.Instance.AddButton(mFitPos, gameObject);

        mButton = GetComponent<Button>();
        mBackImage = GetComponent<Image>();

        mEventListener = EventTriggerListener.GetListener(mButton.gameObject);
        mEventListener.onPointerDown += OnDown;
        mEventListener.onPointerUp += OnUp;

        mCacheTrans = transform;
        mSpriteList = mCacheTrans.parent.GetComponent<SpriteList>();

        Transform maskTrans = mCacheTrans.Find("Mask");
        if(maskTrans != null)
        {
            mCDMask = maskTrans.gameObject;
            mCDMaskImage = mCDMask.GetComponent<Image>();
        }

        mSkillLockObj = mCacheTrans.Find("SkillLock").gameObject;
        mNoticeLabel = mCacheTrans.Find("NoticeLabel").GetComponent<Text>();
        var childTrans = mCacheTrans.Find("LevelText");
        if (childTrans != null)
        {
            mLevelText = childTrans.GetComponent<Text>();
            mLevelObject = childTrans.gameObject;
        }

        mSkillImage = mCacheTrans.Find("SkillImg").GetComponent<Image>();
        Transform trans = mCacheTrans.Find("CDBlink");
        if(trans != null)
            mCDBlink = trans.gameObject;

        trans = mCacheTrans.Find("ClickEffect");
        if(trans != null)
            mClickEffect = trans.gameObject;

        if (GlobalConfig.GetInstance().IsDebugMode)
        {
            return;
        }

        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelup);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ATTACK_SUCC, OnAttackSucc);
        Transform cd_level_transform = mCacheTrans.Find("cd_level");
        if (cd_level_transform != null)
        {
            mCDLevel = cd_level_transform.GetComponent<Text>();
            SetTextContent(mCDLevel, string.Empty);
        }
    }

    /// <summary>
    /// 激活组件的时候需要更新技能信息
    /// </summary>
    void OnEnable() 
    {
        if(GlobalConfig.GetInstance().IsDebugMode)
        {
            return;
        }

        OnSkillUpdate(null);
    }

    /// <summary>
    /// 取消激活
    /// </summary>
    void OnDisable()
    {
        if (mCDBlinkDelayer != null)
            mCDBlinkDelayer.OnStop();

        if (mClickEffectDelayer != null)
            mClickEffectDelayer.OnStop();

        StopPressWait();
    }

    /// <summary>
    /// 销毁
    /// </summary>
    void OnDestroy()
    {
        SkillButtonManager.Instance.RemoveButton(mFitPos);

        StopPressWait();
        mEventListener.onPointerDown -= OnDown;
        mEventListener.onPointerUp -= OnUp;
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelup);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ATTACK_SUCC, OnAttackSucc);
    }

    /// <summary>
    /// 更新时检测技能的cd
    /// </summary>
    void Update()
    {
        if (NetReconnect.Instance.IsReconnect)
            return;

        // 普通攻击按键，定时自动触发点击消息
        if (mIsPressed)
        {
            if (GameInput.Instance.GetEnableInput() == false || mHoleOpen == false)
            {
                mIsPressed = false;
                return;
            }

            if (UIInputEvent.TouchedUI() == false)// 应用被切出，失去焦点
            {
                mIsPressed = false;
                StopPressWait();
                return;
            }

            float t = Time.time;
            if (t > mNextTime)
            {
                OnClick(null);

                mNextTime = t + DetalTime;
            }
        }

        var localPlayer = Game.Instance.GetLocalPlayer();
        if (localPlayer == null)// 角色为空
            return;

        // 技能槽未开启
        if (SkillHoleManager.Instance.IsHoleOpen(mFitPos) == false || SkillHoleManager.Instance.IsHoleWillOpen(mFitPos))
        {
            OnHoldHide();
            return;
        }

        // 技能未装配
        if (mSkillIdx == 0)
        {
            OnSkillNotFit();
            return;
        }

        // 技能为空
        Skill skill = localPlayer.GetSelfSkill(mSkillIdx);
        if (skill == null)
        {
            OnHoldClose();
            return;
        }

        // 技能正常
        OnHoldOpen();

        // 设置CD相关的显示
        if (!skill.IsInCD())// 技能不在cd中
        {
            SetObjectActive(mCDMask,false);

            if (mInCD)// 显示cd结束时候的特效
            {
                mInCD = false;
                if (mCDLevel != null)
                {
                    SetTextContent(mCDLevel, string.Empty);
                }

                if (mCDBlink != null)
                {
                    SetObjectActive(mCDBlink,false);
                    SetObjectActive(mCDBlink,true);

                    if (mCDBlinkDelayer == null)
                        mCDBlinkDelayer = mCDBlink.AddComponent<DelayEnableComponent>();

                    if (mCDBlinkDelayer != null)
                    {
                        mCDBlinkDelayer.DelayTime = 0.5f;
                        mCDBlinkDelayer.SetEnable = false;
                        mCDBlinkDelayer.Start();
                    }
                }
            }
        }
        else// 在cd中
        {
            mInCD = true;

            SetObjectActive(mCDMask,true);

            if (mCDMaskImage != null)
            {
                CooldownCtrl.CDInstance cd_inst = skill.GetCurrentCD();
                if (cd_inst != null)
                {
                    if (mCDLevel != null)
                    {
                        float level_seconds = cd_inst.GetRemainSeconds();
                        SetTextContent(mCDLevel, string.Format("{0:N1}", level_seconds));
                    }
                    mCDMaskImage.fillAmount = cd_inst.GetCDPercent();
                }
            }
        }
    }
    #endregion

    #region FUNCTION_MSG
    /// <summary>
    /// 技能装配信息发生改变
    /// </summary>
    void OnSkillUpdate(xc.ClientEventBaseArgs data)
    {
        if(mCacheTrans == null)
            return;

        uint skillId = SkillManager.GetInstance().GetFitSkillId(mFitPos);
        mSkillIdx = skillId;
        mBasicSkillInfo = DBManager.Instance.GetDB<DBDataAllSkill>().GetOneAllSkillInfo_byActiveSkillId(skillId);
        mSkillInfo = DBSkillSev.Instance.GetSkillInfo(skillId);
        DBSkillSev skill_db = DBManager.GetInstance().GetDB<DBSkillSev>();
        mHasCastingReadyStage = skill_db.HasCastingReadyStage(skillId);

        // 设置技能图标
        if (SkillHoleManager.Instance.IsHoleOpen(mFitPos) == false || SkillHoleManager.Instance.IsHoleWillOpen(mFitPos))
        {
            mSkillImage.color = Color.clear;
        }
        else
        {
            if (skillId != 0)// 设置技能图标
            {
                if(mBasicSkillInfo != null)
                {
                    if (mSpriteList != null)
                    {
                        string icon_str = mBasicSkillInfo.Icon;
                        if (mFitPos == (uint)DBCommandList.OPFlag.OP_A) //普攻
                        {
                            var localPlayer = Game.Instance.GetLocalPlayer();
                            if(localPlayer != null && localPlayer.IsShapeShift)// 变身状态下的图标需要特殊处理
                            {
                                icon_str = mBasicSkillInfo.Icon;

                                if(string.IsNullOrEmpty(icon_str))
                                {
                                    VocationInfo info = DBVocationInfo.Instance.GetVocationInfo(Game.Instance.LocalPlayerVocation);
                                    if (info != null && string.IsNullOrEmpty(info.common_skill_icon_main) == false)
                                        icon_str = info.common_skill_icon_main;
                                }
                            }
                            else
                            {
                                VocationInfo info = DBVocationInfo.Instance.GetVocationInfo(Game.Instance.LocalPlayerVocation);
                                if (info != null && string.IsNullOrEmpty(info.common_skill_icon_main) == false)
                                    icon_str = info.common_skill_icon_main;
                            }
                        }

                        Sprite sprite = mSpriteList.LoadSprite(icon_str);
                        if (sprite != null)
                        {
                            mSkillImage.color = Color.white;
                            mSkillImage.sprite = sprite;
                        }
                        else
                            mSkillImage.color = Color.clear;
                    }
                    else
                        mSkillImage.color = Color.clear;
                }
                else
                    mSkillImage.color = Color.clear;
            }
            else// 技能未装配，不显示技能对应图片
            {
                mSkillImage.color = Color.clear;
            }
        }
    }

    /// <summary>
    /// 角色升级
    /// </summary>
    void OnLevelup(CEventBaseArgs data)
    {
        OnSkillUpdate(null);
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
    /// 技能触发成功
    /// </summary>
    /// <param name="data"></param>
    void OnAttackSucc(CEventBaseArgs data)
    {
        uint skill_id = (uint)data.arg;
        if (skill_id != mSkillIdx)
            return;

        if (mClickEffect != null)
        {
            SetObjectActive(mClickEffect,false);
            SetObjectActive(mClickEffect,true);

            if(mClickEffectDelayer == null)
                mClickEffectDelayer = mClickEffect.AddComponent<DelayEnableComponent>();

            if(mClickEffectDelayer != null)
            {
                mClickEffectDelayer.DelayTime = 2.0f;
                mClickEffectDelayer.SetEnable = false;
                mClickEffectDelayer.Start();
            }
            
        }
    }
    #endregion

    #region FUNCTION_INNER
    /// <summary>
    /// 点击按钮
    /// </summary>
    void OnClick(GameObject go)
    {
        if (GameInput.Instance.GetEnableInput() == false || mHoleOpen == false)
        {
            return;
        }

        // 玩家在安全区域内不响应
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if(localPlayer != null && localPlayer.IsInSafeArea)
        {
            UINotice.GetInstance().ShowMessage(xc.DBConstText.GetText("SKILL_CANNOT_SAFEAREA")); //在安全区无法使用技能
            return;
        }

        if(mFitPos == 1) // 第一装配位置的技能按键需要特殊处理
        {
            if (localPlayer.IsShapeShift)// 角色进行了变身，只能触发普通技能
            {
                if(mSkillIdx != 0)
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(mSkillIdx));
            }
            else
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(0xF0000000));
        }
        else
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(mSkillIdx));
    }

    /// <summary>
    /// 技能槽未开启时
    /// </summary>
    void OnHoldHide()
    {
        SetHoleState(false, true);
    }

    /// <summary>
    /// 技能槽开启
    /// </summary>
    void OnHoldOpen()
    {
        SetHoleState(true, false);
    }

    /// <summary>
    /// 技能未装配(异常状态)
    /// </summary>
    void OnSkillNotFit()
    {
        SetHoleState(false, false);
    }

    /// <summary>
    /// 技能为空(异常状态)
    /// </summary>
    void OnHoldClose()
    {
        SetHoleState(false, true);
    }

    /// <summary>
    /// 设置技能槽的状态
    /// </summary>
    void SetHoleState(bool holeOpen, bool lockIconOpen)
    {
        // 技能槽
        mHoleOpen = holeOpen;

        // 按钮
        EnableButton(holeOpen);

        // CD控件
        if (holeOpen)
        {
            //SetObjectActive(mCDMask,true);

            if(mLevelObject != null)
            {
                SetObjectActive(mLevelObject,true);

                if (mLevelText != null && mBasicSkillInfo != null)
                {
                    SetTextContent(mLevelText, mBasicSkillInfo.LevelNotice);
                }
            }
        }
        else
        {
            SetObjectActive(mCDMask,false);

            if (mCDLevel != null)
            {
                SetTextContent(mCDLevel, string.Empty);
            }

            if (mLevelObject != null)
            {
                SetObjectActive(mLevelObject,false);
            }
        }

        // 技能图标
        if(holeOpen)
            mSkillImage.color = Color.white;
        else
            mSkillImage.color = Color.clear;

        // 锁图标
        SetObjectActive(mSkillLockObj,lockIconOpen);
        SetObjectActive(mNoticeLabel.gameObject,lockIconOpen);

        var dbSkillSlot = DBManager.Instance.GetDB<DBSkillSlot>();
        if (dbSkillSlot != null)
        {
            var vocationId = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
            SetTextContent(mNoticeLabel, dbSkillSlot.GetSkillSlotNotice(vocationId, mFitPos));
        }
    }

    /// <summary>
    /// 按下技能按钮
    /// </summary>
    /// <param name="go"></param>
    void OnDown(GameObject go)
    {
        if (GameInput.GetInstance().GetEnableInput() == false)
            return;

        if (mHoleOpen == false)
        {
            /*string notice = DBConstText.GetText("SKILL_HOLE_NOTOPEN");
            UINotice.Instance.ShowMessage(notice);
            StopPressWait();
            mCoroutine = OnPressLongTime();
            StartCoroutine(mCoroutine);*/
            return;
        }

        if (mFitPos != 1 && !mHasCastingReadyStage)
        {
            mCoroutine = OnPressLongTime();
            StartCoroutine(mCoroutine);
        }
        if (mHasCastingReadyStage)
        {
            OnClick(null);
        }
        OnPress(true);
            
        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_PRESS_BUTTON, new CEventBaseArgs(mSkillIdx));
    }

    /// <summary>
    /// 释放技能按钮
    /// </summary>
    /// <param name="go"></param>
    void OnUp(GameObject go)
    {
        StopPressWait();

        if (!mHasCastingReadyStage && UIManager.Instance.GetWindow("UISkillDescTipsWindow") == null)
        {
            OnClick(null);
        }
        OnPress(false);
        UIManager.Instance.CloseWindow("UISkillDescTipsWindow");

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_RELEASE_BUTTON, new CEventBaseArgs(mSkillIdx));
    }

    /// <summary>
    /// 点击、释放技能按钮的触发逻辑
    /// </summary>
    /// <param name="isDown"></param>
    void OnPress(bool isDown)
    {
        if (mContinuePress)// 普通攻击下，定时自动触发点击消息
        {
            mIsPressed = isDown;
            if (GameInput.Instance.GetEnableInput() == false || mHoleOpen == false)
                mIsPressed = false;

            if (mIsPressed)
            {
                mNextTime = Time.time + DetalTime;
            }
        }
        else
            mIsPressed = false;
    }

    /// <summary>
    /// 当一直按下时
    /// </summary>
    IEnumerator OnPressLongTime()
    {
        yield return new WaitForSeconds(0.5f);

        if(mBasicSkillInfo != null)
            UIManager.Instance.ShowWindow("UISkillDescTipsWindow", mBasicSkillInfo, Vector3.zero, new Vector2(0, 0));
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

    /// <summary>
    /// 开启、关闭Button的点击
    /// </summary>
    /// <param name="enable"></param>
    void EnableButton(bool enable)
    {
        if(mButton.enabled != enable)
            mButton.enabled = enable;

        if(mEventListener.enabled != enable)
            mEventListener.enabled = enable;
    }

    void SetObjectActive(GameObject obj, bool active)
    {
        if (obj.activeSelf != active)
            obj.SetActive(active);
    }

    void SetTextContent(Text text, string content)
    {
        if(text.text != content)
        {
            text.text = content;
        }
    }
    #endregion
}
