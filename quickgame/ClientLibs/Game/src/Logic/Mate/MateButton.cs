//-----------------------------------
// File: MateButton.cs
// Desc: 情侣技能按钮
// Author: luozhuocheng
// Date: 2018/11/13 20:16:40
//-----------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using xc;
using xc.ui;
using xc.ui.ugui;

[wxb.Hotfix]
public class MateButton : MonoBehaviour
{
    /// <summary>
    /// 是否需要按住持续触发
    /// </summary>
    [SerializeField]
    bool m_ContinuePress = false;

    /// <summary>
    /// 按键的装配位置
    /// </summary>
    [SerializeField]
    uint m_FitPos;

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
    /// 技能CD遮罩的GameObject
    /// </summary>
    GameObject mCDMask;

    /// <summary>
    /// 技能CD遮罩的Image
    /// </summary>
    Image mCDMaskImage;

    /// <summary>
    /// 技能Button
    /// </summary>
    Button mButton;

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
    DelayEnableComponent mCDBlink_DelayEnableComponent;

    /// <summary>
    /// 点击按钮时候播放的特效
    /// </summary>
    GameObject mClickEffect;

    /// <summary>
    ///  点击特效定时取消激活的组件
    /// </summary>
    DelayEnableComponent mClickEffect_DelayEnableComponent;

    /// <summary>
    /// 技能是否在CD中
    /// </summary>
    bool mInCD = false;

    /// <summary>
    /// CD的倒计时
    /// </summary>
    Text mCDLevel;

    /// <summary>
    /// 技能槽是否开启
    /// </summary>
    bool mHoleOpen = false;

    /// <summary>
    /// 是否有吟唱阶段
    /// </summary>
    bool mHasCastingReadyStage = false;

    /// <summary>
    /// 长按按键的协程
    /// </summary>
    IEnumerator mCoroutine;

    /// <summary>
    /// 不能显示情缘技能的副本类型
    /// </summary>
    List<uint> mCanNotShowWarList = null;

    void Awake()
    {
        if (uint.TryParse(gameObject.name, out m_FitPos) == false)
        {
            m_FitPos = 1;
            GameDebug.Log("m_FitPos is invalid");
        }

        if (m_FitPos == 1)
            m_ContinuePress = true;
        else
            m_ContinuePress = false;

        SkillButtonManager.Instance.AddButton(m_FitPos, gameObject);

        mButton = GetComponent<Button>();

        mEventListener = EventTriggerListener.GetListener(mButton.gameObject);
        mEventListener.onPointerDown += OnDown;
        mEventListener.onPointerUp += OnUp;

        mCacheTrans = transform;
        mSpriteList = mCacheTrans.parent.GetComponent<SpriteList>();

        Transform maskTrans = mCacheTrans.Find("Mask");
        if (maskTrans != null)
        {
            mCDMask = maskTrans.gameObject;
            mCDMaskImage = mCDMask.GetComponent<Image>();
        }

        mSkillLockObj = mCacheTrans.Find("SkillLock").gameObject;
        mSkillImage = mCacheTrans.Find("SkillImg").GetComponent<Image>();
        Transform trans = mCacheTrans.Find("CDBlink");
        if (trans != null)
            mCDBlink = trans.gameObject;

        trans = mCacheTrans.Find("ClickEffect");
        if (trans != null)
            mClickEffect = trans.gameObject;

        if (GlobalConfig.GetInstance().IsDebugMode)
        {
            return;
        }
        
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelup);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.SKILL_MATE_UPDATE, OnSkillUpdate);
        //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ATTACK_SUCC, OnAttackSucc);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.SKILL_MATE_USE_SUCCESS, OnAttackSucc);
        
        Transform cd_level_transform = mCacheTrans.Find("cd_level");
        if (cd_level_transform != null)
        {
            mCDLevel = cd_level_transform.GetComponent<Text>();
            mCDLevel.text = string.Empty;
        }
    }

    void OnEnable()
    {
        if (GlobalConfig.GetInstance().IsDebugMode)
        {
            return;
        }

        OnSkillUpdate(null);
    }

    void OnDisable()
    {
        if (mCDBlink_DelayEnableComponent != null)
            mCDBlink_DelayEnableComponent.OnStop();
        if (mClickEffect_DelayEnableComponent != null)
            mClickEffect_DelayEnableComponent.OnStop();

        StopPressWait();
    }

    void OnDestroy()
    {
        SkillButtonManager.Instance.RemoveButton(m_FitPos);

        StopPressWait();
        mEventListener.onPointerDown -= OnDown;
        mEventListener.onPointerUp -= OnUp;
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelup);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_POS_SET, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, OnSkillUpdate);
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.SKILL_MATE_UPDATE, OnSkillUpdate);
        //ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ATTACK_SUCC, OnAttackSucc);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.SKILL_MATE_USE_SUCCESS, OnAttackSucc);

        if (mCanNotShowWarList != null)
        {
            mCanNotShowWarList.Clear();
            mCanNotShowWarList = null;
        }
    }

    /// <summary>
    /// 技能装配信息发生改变
    /// </summary>
    void OnSkillUpdate(xc.ClientEventBaseArgs data)
    {
        if (mCacheTrans == null)
            return;

        uint skillId = SkillManager.GetInstance().GetFitSkillId(m_FitPos);
        mSkillIdx = skillId;
        mBasicSkillInfo = DBManager.Instance.GetDB<DBDataAllSkill>().GetOneAllSkillInfo_byActiveSkillId(skillId);
        mSkillInfo = DBSkillSev.Instance.GetSkillInfo(skillId);
        DBSkillSev skill_db = DBManager.GetInstance().GetDB<DBSkillSev>();
        mHasCastingReadyStage = skill_db.HasCastingReadyStage(skillId);

        // 设置技能图标
        if (SkillHoleManager.Instance.IsHoleOpen(m_FitPos) == false || SkillHoleManager.Instance.IsHoleWillOpen(m_FitPos))
        {
            mSkillImage.color = Color.clear;
        }
        else
        {
            if (skillId != 0)// 设置技能图标
            {
                if (mBasicSkillInfo != null)
                {
                    if (mSpriteList != null)
                    {
                        string icon_str = mBasicSkillInfo.Icon;
                        if (m_FitPos == (uint)DBCommandList.OPFlag.OP_A)
                        {//普攻
                            VocationInfo info = DBVocationInfo.Instance.GetVocationInfo(Game.Instance.LocalPlayerVocation);
                            if (info != null && string.IsNullOrEmpty(info.common_skill_icon_main) == false)
                                icon_str = info.common_skill_icon_main;
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
        //uint skill_id = System.Convert.ToUInt32(data.arg);
        //if (skill_id != mSkillIdx)
        //    return;

        if (mClickEffect != null)
        {
            mClickEffect.SetActive(false);
            mClickEffect.SetActive(true);

            if (mClickEffect_DelayEnableComponent == null)
                mClickEffect_DelayEnableComponent = mClickEffect.AddComponent<DelayEnableComponent>();
            if (mClickEffect_DelayEnableComponent != null)
            {
                mClickEffect_DelayEnableComponent.DelayTime = 2.0f;
                mClickEffect_DelayEnableComponent.SetEnable = false;
                mClickEffect_DelayEnableComponent.Start();
            }

        }

        Game.GetInstance().GetLocalPlayer().CDCtrl.StartCD(mSkillIdx);

    }

    /// <summary>
    /// 点击按钮
    /// </summary>
    public void OnClick(GameObject go)
    {
        if (GameInput.Instance.GetEnableInput() == false || mHoleOpen == false)
        {
            return;
        }

        // 玩家在安全区域内不响应
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer != null && localPlayer.IsInSafeArea)
        {
            UINotice.GetInstance().ShowMessage(xc.DBConstText.GetText("SKILL_CANNOT_SAFEAREA")); //在安全区无法使用技能
            return;
        }


        //if (xc.SceneHelp.Instance.IsInNormalWild == false)
        //{
        //    //先提示
        //    ClientEventMgr.GetInstance().FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_CLICK_MATE_SKILL), new CEventBaseArgs(mSkillIdx));
        //}
        //else
        //{
        //    RealClick();
        //}

        ClientEventMgr.GetInstance().FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_CLICK_MATE_SKILL), new CEventBaseArgs(mSkillIdx));

    }
    void RealClick()
    {
        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(mSkillIdx));
    }



    /// <summary>
    /// 技能槽未开启
    /// </summary>
    void OnHoldClose()
    {
        mHoleOpen = false;

        mCDMask.SetActive(false);// cd 图片
        if (mCDLevel != null) // cd 的倒计时
            mCDLevel.text = string.Empty;
        mSkillImage.color = Color.clear;// 技能图标
        mSkillLockObj.SetActive(true);// 锁图标
        EnableButton(true);
        GetComponent<Image>().enabled = true;
    }

    /// <summary>
    /// 技能槽未开启时隐藏按钮
    /// </summary>
    void OnHoldHide()
    {
        mHoleOpen = false;

        mCDMask.SetActive(false);// cd 图片
        if (mCDLevel != null) // cd 的倒计时
            mCDLevel.text = string.Empty;
        mSkillImage.color = Color.clear;// 技能图标
        mSkillLockObj.SetActive(false);// 锁图标
        EnableButton(false);
        GetComponent<Image>().enabled = false;
    }

    /// <summary>
    /// 技能槽开启
    /// </summary>
    void OnHoldOpen()
    {
        mHoleOpen = true;

        mSkillLockObj.SetActive(false);// 锁图标
        EnableButton(true);
        GetComponent<Image>().enabled = true;
    }

    /// <summary>
    /// 技能未装配
    /// </summary>
    void OnSkillNotFit()
    {
        mHoleOpen = true;

        mCDMask.SetActive(false);// cd 图片
        if (mCDLevel != null) // cd 的倒计时
            mCDLevel.text = string.Empty;
        mSkillImage.color = Color.clear;// 技能图标
        mSkillLockObj.SetActive(false);// 锁图标
        EnableButton(false);
    }

    /// <summary>
    /// 更新时检测技能的cd
    /// </summary>
    public void Update()
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

        Actor local_player = Game.GetInstance().GetLocalPlayer();
        if (local_player == null)// 角色为空
            return;

        //DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
        //if (instanceInfo != null && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_ARENA)
        //{
        //    OnHoldHide();
        //    return;
        //}
        if(CanShowMateButton() == false)
        {
            OnHoldHide();
            return;
        }


        if (SkillHoleManager.Instance.IsHoleOpen(m_FitPos) == false || SkillHoleManager.Instance.IsHoleWillOpen(m_FitPos))// 技能槽还没开启
        {
            OnHoldHide();
            return;
        }

        if (mSkillIdx == 0)
        {
            OnSkillNotFit();
            return;
        }

        Skill skill = local_player.GetSelfSkill(mSkillIdx);
        if (skill == null)// 技能为空
        {
            OnHoldClose();
            return;
        }

        OnHoldOpen();

        // 设置CD相关的显示
        if (!skill.IsInCD())// 技能不在cd中
        {
            if (mCDMask.activeSelf)
                mCDMask.SetActive(false);

            if (mInCD)// 显示cd结束时候的特效
            {
                mInCD = false;
                if (mCDLevel != null)
                    mCDLevel.text = string.Empty;

                if (mCDBlink != null)
                {
                    mCDBlink.SetActive(false);
                    mCDBlink.SetActive(true);

                    if (mCDBlink_DelayEnableComponent == null)
                    {
                        mCDBlink_DelayEnableComponent = mCDBlink.AddComponent<DelayEnableComponent>();
                    }
                    if (mCDBlink_DelayEnableComponent != null)
                    {
                        mCDBlink_DelayEnableComponent.DelayTime = 0.5f;
                        mCDBlink_DelayEnableComponent.SetEnable = false;
                        mCDBlink_DelayEnableComponent.Start();
                    }
                }
            }
        }
        else// 在cd中
        {
            mInCD = true;

            if (!mCDMask.activeSelf)
            {
                mCDMask.SetActive(true);
            }

            if (mCDMaskImage != null)
            {
                CooldownCtrl.CDInstance cd_inst = skill.GetCurrentCD();
                if (cd_inst != null)
                {
                    if (mCDLevel != null)
                    {
                        float level_seconds = cd_inst.GetRemainSeconds();
                        mCDLevel.text = string.Format("{0:N1}", level_seconds);
                    }
                    mCDMaskImage.fillAmount = cd_inst.GetCDPercent();
                }
            }
        }
    }

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

    public void OnDown(GameObject go)
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

        if (m_FitPos != 1 && !mHasCastingReadyStage)
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

    public void OnUp(GameObject go)
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

    void OnPress(bool isDown)
    {
        if (m_ContinuePress)// 普通攻击下，定时自动触发点击消息
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
    /// 开启\关闭Button的点击
    /// </summary>
    /// <param name="enable"></param>
    void EnableButton(bool enable)
    {
        mButton.enabled = enable;
        mEventListener.enabled = enable;
    }


    public bool CanShowMateButton()
    {
        if (mCanNotShowWarList == null)
        {
            mCanNotShowWarList = xc.GameConstHelper.GetUintList("GAME_SHOW_MATE_BUTTON_WAR_TYPE");
        }
        DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
        if (instanceInfo != null && mCanNotShowWarList != null)
        {
            for (int i = 0; i < mCanNotShowWarList.Count; i++)
            {
                if (mCanNotShowWarList[i] == instanceInfo.mWarSubType)
                {
                    return false;
                }
            }
        }
        return true;
    }

}
