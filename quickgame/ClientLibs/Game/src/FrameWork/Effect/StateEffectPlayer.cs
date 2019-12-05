//----------------------------------------
// File : StateEffectPlayer
// Desc : 根据不同角色状态播放特效的组件
// Author : raorui
// Date: 2018.3.15
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class StateEffectPlayer : MonoBehaviour
{
    bool mTriggerAuto = true;

    public struct EffectInfo
    {
        public EffectInfo(string effect_path, GameObject effect_obejct)
        {
            EffectPath = effect_path;
            EffectObject = effect_obejct;
        }

        public string EffectPath;//当前已加载特效的资源路径
        public GameObject EffectObject;//当前已加载特效的物体
    }

    #region 变量 
    Transform mTrans;
    System.WeakReference mOwner;

    /// <summary>
    /// 已经加载的特效信息
    /// </summary>
    List<EffectInfo> mEffectInfos = new List<EffectInfo>();

    /// <summary>
    /// 状态与特效的配置组件
    /// </summary>
    StateTriggerSetting mStateTriggerSetting;

    /// <summary>
    /// 是否已经注册了状态改变的事件
    /// </summary>
    bool mIsRegisted;

    /// <summary>
    /// 是否可以播放特效
    /// </summary>
    bool mIsEnable = true;

    /// <summary>
    /// 组件是否已被销毁
    /// </summary>
    bool mIsDestory = false;

    /// <summary>
    /// 状态与触发特效的对应
    /// </summary>
    Dictionary<StateTriggerSetting.StateType, List<StateTriggerSetting.TriggerSetting>> mStateTriggerMap = new Dictionary<StateTriggerSetting.StateType, List<StateTriggerSetting.TriggerSetting>>();

    /// <summary>
    /// 当前正处在的角色状态
    /// </summary>
    StateTriggerSetting.StateType mState = StateTriggerSetting.StateType.STATE_NONE;
    #endregion

    #region 属性访问器
    Actor Owner
    {
        get
        {
            if (mOwner != null && mOwner.IsAlive)
            {
                Actor actor = (Actor)(mOwner.Target);
                return actor;
            }

            return null;
        }

        set
        {
            if (mOwner == null || !mOwner.IsAlive)
            {
                mOwner = new System.WeakReference(value);
            }
            else
            {
                mOwner.Target = value;
            }
        }
    }

    public bool IsEnable
    {
        get
        {
            return mIsEnable;
        }

        set
        {
            mIsEnable = value;
        }
    }

    #endregion

    #region 引擎接口
    void Awake()
    {
        mTrans = transform;
        mStateTriggerSetting = GetComponent<StateTriggerSetting>();
        mTriggerAuto = mStateTriggerSetting.TriggerAuto;

        // 将状态的设置添加到字典中
        if (mStateTriggerSetting != null && mStateTriggerSetting.TriggerSettings != null)
        {
            foreach (var setting in mStateTriggerSetting.TriggerSettings)
            {
                List<StateTriggerSetting.TriggerSetting> state_trigget_list = null;
                if (!mStateTriggerMap.TryGetValue(setting.State, out state_trigget_list))
                {
                    state_trigget_list = new List<StateTriggerSetting.TriggerSetting>();
                    mStateTriggerMap[setting.State] = state_trigget_list;
                }
                state_trigget_list.Add(setting);
            }
        }
    }

    void Start()
    {
        RegisterStateEvent();
    }

    void OnDestroy()
    {
        mIsDestory = true;
        UnRegisterStateEvent();
    }
    #endregion

    #region 外部接口
    /// <summary>
    /// 设置特效播放者是否是本地玩家
    /// </summary>
    public void SetOwner(Actor actor)
    {
        Owner = actor;

        if (Owner.IsIdle())
            OnEnterIdleState(null);
    }

    /// <summary>
    /// 进入状态的时候不自动触发，需要调用此函数才触发
    /// </summary>
    /// <param name="actor"></param>
    public void TriggerManual()
    {
        if (Owner == null)
            return;

        if (Owner.IsIdle())
        {
            mState = StateTriggerSetting.StateType.STATE_IDLE;
            List<StateTriggerSetting.TriggerSetting> trigger_setting_list = null;
            if (mStateTriggerMap.TryGetValue(mState, out trigger_setting_list))
            {
                PlayEffect(trigger_setting_list, mState);
            }
        }
    }

    /// <summary>
    /// 播放指定触发信息对应的特效
    /// </summary>
    private void PlayEffect(List<StateTriggerSetting.TriggerSetting> trigger_setting_list, StateTriggerSetting.StateType state_type)
    {
        // 先删除特效
        RecycleEffect();

        if (!mIsEnable)
            return;

        // 判断是否需要隐藏特效
        bool need_effect_hide = false;
        bool is_visible = Owner != null ? Owner.mVisibleCtrl.IsVisible : false;
        if (!is_visible)
        {
            need_effect_hide = true;
        }
        else
        {
            if (Owner.IsPlayer())//检查角色的特效数量是否超出限制
            {
                if (!Owner.IsLocalPlayer)
                    need_effect_hide = true;
            }
            else// 如果召唤怪或者宠物的主人是玩家，释放的技能特效也需要隐藏
            {
                var parent_actor = Owner.ParentActor;
                if (parent_actor != null && parent_actor.IsPlayer() && !parent_actor.IsLocalPlayer)
                    need_effect_hide = true;
            }
        }

        if (need_effect_hide)
            return;

        foreach (var trigger_setting in trigger_setting_list)
        {
            StartCoroutine(LoadEffect(trigger_setting, state_type));
        }
    }

    /// <summary>
    /// 清除掉所有可以被打断的特效
    /// only_interrput 表示是否只清除可以中断的技能
    /// </summary>
    public void ClearEffects()
    {
        RecycleEffect();
    }

    #endregion

    #region 内部函数
    /// <summary>
    /// 注册角色状态改变的事件
    /// </summary>
    void RegisterStateEvent()
    {
        if (Owner != null)
        {
            if (mIsRegisted)
                return;

            mIsRegisted = true;
            Owner.SubscribeActorEvent(Actor.ActorEvent.ENTERIDLE, OnEnterIdleState);
            Owner.SubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnExitIdleState);
        }
    }

    /// <summary>
    /// 注册角色状态改变的事件
    /// </summary>
    void UnRegisterStateEvent()
    {
        if (Owner != null)
        {
            if (!mIsRegisted)
                return;

            mIsRegisted = false;
            Owner.UnsubscribeActorEvent(Actor.ActorEvent.ENTERIDLE, OnEnterIdleState);
            Owner.UnsubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnExitIdleState);
        }
    }

    /// <summary>
    /// 进入待机状态
    /// </summary>
    /// <param name="data"></param>
    void OnEnterIdleState(CEventBaseArgs data)
    {
        if (!mTriggerAuto)
            return;

        mState = StateTriggerSetting.StateType.STATE_IDLE;
        List<StateTriggerSetting.TriggerSetting> trigger_setting_list = null;
        if (mStateTriggerMap.TryGetValue(mState, out trigger_setting_list))
        {
            PlayEffect(trigger_setting_list, mState);
        }
    }

    /// <summary>
    /// 退出待机状态
    /// </summary>
    /// <param name="data"></param>
    void OnExitIdleState(CEventBaseArgs data)
    {
        if (!mTriggerAuto)
            return;

        mState = StateTriggerSetting.StateType.STATE_NONE;
        RecycleEffect();
    }

    /// <summary>
    /// 加载特效资源，加载完毕后根据配置设置不同的跟节点
    /// </summary>
    /// <param name="setting"></param>
    /// <returns></returns>
    IEnumerator LoadEffect(StateTriggerSetting.TriggerSetting trigger_setting, StateTriggerSetting.StateType state_type)
    {
        var effect_path = trigger_setting.EffectPath;
        xc.ObjectWrapper game_object_wrapper = new xc.ObjectWrapper();
        yield return StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(effect_path, ObjCachePoolType.SFX, effect_path, game_object_wrapper));
        GameObject effect_object = game_object_wrapper.obj as GameObject;
        if (effect_object == null)// 特效加载不成功或者在切场景时被销毁，则直接返回
            yield break;

        // 是否组件已经被销毁或取消激活
        if (mIsDestory || !mIsEnable)
        {
            ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, effect_path);
            yield break;
        }

        // 资源加载完毕后需要再次判断可见性
        bool is_visible = Owner != null ? Owner.mVisibleCtrl.IsVisible : false;
        if (!is_visible || mState != state_type)
        {
            ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, effect_path);
            yield break;
        }

        Transform effect_trans = effect_object.transform;
        Transform bind_trans = trigger_setting.BindBone;
        if (bind_trans == null)
            bind_trans = mTrans;

        if (bind_trans != null)
        {
            effect_trans.parent = bind_trans;
            effect_trans.localPosition = Vector3.zero;
            effect_trans.localRotation = Quaternion.identity;
            effect_trans.localScale = Vector3.one;

            mEffectInfos.Add(new EffectInfo(effect_path, effect_object));
            yield return null;
        }
        else
        {
            GameDebug.LogError("StateEffectPlayer::LoadEffect: bind_trans is null");
            ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, effect_path);
            yield break;
        }
    }

    /// <summary>
    /// 将特效放入内存池
    /// </summary>
    void RecycleEffect()
    {
        foreach(var effect_info in mEffectInfos)
        {
            if (effect_info.EffectObject != null && !string.IsNullOrEmpty(effect_info.EffectPath))
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(effect_info.EffectObject, ObjCachePoolType.SFX, effect_info.EffectPath);
            }
        }
        mEffectInfos.Clear();
    }
    #endregion
}
