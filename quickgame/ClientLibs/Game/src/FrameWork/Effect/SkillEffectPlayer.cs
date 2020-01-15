//--------------------------------------
// File: SkillEffectControl.cs
// Desc: 技能特效的播放组件
// Author: raorui
// Date: 2017.8.29
//--------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using xc;

public class SkillEffectPlayer: MonoBehaviour
{
    /// <summary>
    /// 是否使用高配的特效文件，在编辑器中切换
    /// </summary>
    public static bool UseHighEffect = true;

    public TriggerSetting[] TriggerSettings
    {
        get
        {
            return mTriggerSettings;
        }
        set
        {
            mTriggerSettings = value;
        }
    }
    TriggerSetting[] mTriggerSettings;

    System.WeakReference mOwner;
    protected bool mIsLocalPlayer = false;
    protected bool mIsPlayer = false;



    /// <summary>
    /// 缓存的Transform
    /// </summary>
    Transform mTrans;

    /// 特效的信息
    public class EffectInfo
    {
        // 特效的触发点相关信息
        public TriggerSetting mTriggerSetting;
        // 特效的GameObject
        public GameObject mEffectObject;
        // 技能音效实例 id 用于打断声音
        public uint mSkillSoundId = 0;

        public EffectInfo(TriggerSetting trigger_settting, GameObject effect_object, uint skill_sound_id)
        {
            mTriggerSetting = trigger_settting;
            mEffectObject = effect_object;
            mSkillSoundId = skill_sound_id;
        }
    }

    /// <summary>
    /// 保存技能的特效物体和特效信息
    /// </summary>
    Dictionary<int, EffectInfo> mEffectObjects = new Dictionary<int, EffectInfo>();

    /// <summary>
    /// 是否可以播放特效
    /// </summary>
    bool mIsEnable = true;
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

    void Awake()
    {
        mTrans = transform;

        var trigger_option = GetComponent<AnimationTriggerSetting>();
        if (trigger_option != null)
            TriggerSettings = trigger_option.TriggerSettings;

        //设置默认的Bone
        if (TriggerSettings != null)
        {
            TriggerSetting kEffectTrigger;
            for (int i = 0; i < TriggerSettings.Length; ++i)
            {
                kEffectTrigger = TriggerSettings[i];
                if (kEffectTrigger != null)
                {
                    if (kEffectTrigger.BindBone == null)
                        kEffectTrigger.BindBone = mTrans.Find("root_node");
                }
            }
        }
    }

    /// <summary>
    /// 设置特效播放者是否是本地玩家
    /// </summary>
    public void SetOwner(Actor actor)
    {
        Owner = actor;
        mIsPlayer = actor.IsPlayer();
        mIsLocalPlayer = actor.IsLocalPlayer;
    }

    /// <summary>
    /// 动画播放到指定帧的回调
    /// </summary>
    public void OnFrameHit(System.Object trigger_setting)
    {
        PlayEffect(trigger_setting as TriggerSetting);
    }

    /// <summary>
    /// 播放指定动作名字对应的特效
    /// </summary>
    public void PlayEffect(string aniName)
    {
        if (TriggerSettings == null)
            return;

        TriggerSetting trigger;
        for (int i = 0; i < TriggerSettings.GetLength(0); ++i)
        {
            trigger = TriggerSettings[i];

            if (trigger != null && trigger.Animation != null && aniName == trigger.Animation.name)
            {
                PlayEffect(trigger);
                break;
            }
        }
    }

    /// <summary>
    /// 播放指定触发信息对应的特效
    /// </summary>
    public void PlayEffect(TriggerSetting effect_trigger)
    {
        if (!mIsEnable)
            return;

        if (effect_trigger.OnlyLocalPlayer && !mIsLocalPlayer)
            return;

#if UNITY_EDITOR
        if(InSkillEffectEditor())
        {
            GameObject effect_object = EditorResourceLoader.LoadAssetAtPath("Assets/Res/"+effect_trigger.SuitEffectPath(UseHighEffect? 0:1) + ".prefab",typeof(GameObject)) as GameObject;
            if (effect_object == null)
                return;

            effect_object = GameObject.Instantiate(effect_object) as GameObject;

            // 如果组件已经被销毁了，需要将gameobject放入内存池
            if (mIsDestory)
            {
                GameObject.Destroy(effect_object);
                return;
            }

            Transform effect_trans = effect_object.transform;
            Transform bind_trans = effect_trigger.BindBone.transform;
            if (bind_trans == null)
                bind_trans = mTrans;

            if (bind_trans != null)
            {
                effect_trans.parent = bind_trans;
                effect_trans.localPosition = Vector3.zero;
                effect_trans.localRotation = Quaternion.identity;
                effect_trans.localScale = Vector3.one;

                if (effect_trigger.InWorld)// 特效不跟随角色
                    effect_trans.parent = null;
            }
            else
            {
                GameDebug.LogError("[LoadSkillEffect]bind_trans is null");
                GameObject.Destroy(effect_object);
                return;
            }

            var delay_timer = effect_object.GetComponent<DelayTimeComponent>();
            if (delay_timer == null)
                delay_timer = effect_object.AddComponent<DelayTimeComponent>();
            delay_timer.DelayTime = effect_trigger.LifeTime;
            delay_timer.Start();

            uint skillSoundId = 0;
            // 播放特效中的声音
            if (effect_trigger.Audio != null)
            {
                skillSoundId = AudioManager.Instance.PlayBattleSFX(effect_trigger.Audio, AudioManager.GetSFXSoundType(Owner));
                //AudioManager.Instance.PlayAudio(effect_trigger.Audio, false);
            }

            EffectInfo effect_info = new EffectInfo(effect_trigger, effect_object, skillSoundId);
            mEffectObjects[effect_object.GetHashCode()] = effect_info;
            delay_timer.SetEndCallBack(new DelayTimeComponent.EndCallBackInfo(OnEffectPlayFinish, effect_object));

            var shakes = effect_object.GetComponentsInChildren<CameraCurveShake>(true);
            foreach (var item in shakes)
            {
                item.enabled = true;
                item.StartShake();
            }
        }
        else
#endif
        StartCoroutine(LoadSkillEffect(effect_trigger));
    }

    /// <summary>
    /// 加载特效资源，加载完毕后根据配置设置不同的跟节点
    /// </summary>
    /// <param name="setting"></param>
    /// <returns></returns>
    IEnumerator LoadSkillEffect(TriggerSetting effect_trigger)
    {
        var owner = Owner;
        if (mIsDestory || owner == null || owner.IsDestroy)
            yield break;

        bool is_visible = owner.mVisibleCtrl.IsVisible;
        if(!is_visible)
            yield break;

        bool need_effect_hide = false;
        if (mIsPlayer)//检查角色的特效数量是否超出限制
        {
            if (!mIsLocalPlayer)
                need_effect_hide = true;
        }
        else// 如果召唤怪或者宠物的主人是玩家，释放的技能特效也需要隐藏
        {
            var parent_actor = owner.ParentActor;
            if (parent_actor != null && parent_actor.IsPlayer() && !parent_actor.IsLocalPlayer)
                need_effect_hide = true;
        }

        if (need_effect_hide && EffectManager.Instance.ExceedEffectNum())
            yield break;

        int effect_level = 1;
        // 低配下使用低配的特效
        if (QualitySetting.GraphicLevel == 2)
        {
            effect_level = 1;
        }
        // 其他配置下本地玩家才使用高配特效
        else
        {
            effect_level = mIsLocalPlayer ? 0 : 1;
        }
        string effect_path = effect_trigger.SuitEffectPath(effect_level);
        if (string.IsNullOrEmpty(effect_path))
            yield break;

        xc.ObjectWrapper game_object_wrapper = new xc.ObjectWrapper();
        yield return StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(effect_path, ObjCachePoolType.SFX, effect_path, game_object_wrapper));
        GameObject effect_object = game_object_wrapper.obj as GameObject;
        if (effect_object == null)// 特效加载不成功或者在切场景时被销毁，则直接返回
            yield break;

        if(mIsPlayer && !mIsLocalPlayer)
            EffectManager.Instance.IncreaseEffectNum();

        // 如果组件已经被销毁了，需要将gameobject放入内存池
        var ownerActor = Owner;
        if (mIsDestory || ownerActor == null || ownerActor.IsDestroy)
        {
            BeforeRecycleEffect(effect_object);
            ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, effect_path);
            yield break;
        }

        Transform effect_trans = effect_object.transform;

        Transform bind_trans = effect_trigger.BindBone != null ? effect_trigger.BindBone.transform : null;
        if (bind_trans == null)
            bind_trans = mTrans;

        if (bind_trans != null)
        {
            effect_trans.parent = bind_trans;
            effect_trans.localPosition = Vector3.zero;
            effect_trans.localRotation = Quaternion.identity;
            effect_trans.localScale = Vector3.one;

            if (effect_trigger.InWorld)// 特效不跟随角色
                effect_trans.parent = null;
        }
        else
        {
            GameDebug.LogError("[LoadSkillEffect]bind_trans is null");
            BeforeRecycleEffect(effect_object);
            ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, effect_path);
            yield break;
        }

        ParticleControl particle_control = effect_object.GetComponent<ParticleControl>();
        if (particle_control == null)
            particle_control = effect_object.AddComponent<ParticleControl>();
        if (ownerActor != null)
            particle_control.Speed = ownerActor.AttackSpeed;
        else
            particle_control.Speed = 1.0f;

        var delay_timer = effect_object.GetComponent<DelayTimeComponent>();
        if (delay_timer == null)
            delay_timer = effect_object.AddComponent<DelayTimeComponent>();
        delay_timer.DelayTime = effect_trigger.LifeTime;
        delay_timer.Start();

        uint skillSoundId = 0;
        // 播放特效中的声音
        if (effect_trigger.Audio != null)
        {
            // 某些音效只有本地玩家才播放
            if (effect_trigger.OnlyLocalPlayer == false || (effect_trigger.OnlyLocalPlayer && mIsLocalPlayer))
            {
                skillSoundId = AudioManager.Instance.PlayBattleSFX(effect_trigger.Audio, AudioManager.GetSFXSoundType(Owner));
                //AudioManager.Instance.PlayAudio(effect_trigger.Audio, false);
            }
        }

        EffectInfo effect_info = new EffectInfo(effect_trigger, effect_object, skillSoundId);
        mEffectObjects[effect_object.GetHashCode()] = effect_info;
        delay_timer.SetEndCallBack(new DelayTimeComponent.EndCallBackInfo(OnEffectPlayFinish, effect_object));

        //本地玩家才有振动
        var cameraShakeCache = effect_object.GetComponent<CameraCurveCache>();
        CameraCurveShake[] shakes = null;
        if (cameraShakeCache == null)
        {
            cameraShakeCache = effect_object.AddComponent<CameraCurveCache>();
            shakes = effect_object.GetComponentsInChildren<CameraCurveShake>(true);
            cameraShakeCache.ShakeCache = shakes;
        }
        else
        {
            shakes = cameraShakeCache.ShakeCache;
        }
            
        foreach (var item in shakes)
        {
            if (mIsLocalPlayer && GlobalSettings.Instance.CameraShake)
            {
                item.enabled = true;
                item.StartShake();
            }
            else
            {
                item.enabled = false;
            }
        }
    }

    bool mIsDestory = false;

    void OnDestroy()
    {
        mIsDestory = true;
        ClearEffects();
    }

    /// <summary>
    /// 特效播放完毕的回调
    /// </summary>
    void OnEffectPlayFinish(System.Object effect_object)
    {
        GameObject effet_game_object = effect_object as GameObject;
        if (effet_game_object != null)
        {
            EffectInfo effect_info = null;
            int key = effet_game_object.GetHashCode();
            if (mEffectObjects.TryGetValue(key, out effect_info))
            {
                mEffectObjects.Remove(key);
#if UNITY_EDITOR
                if (InSkillEffectEditor())
                {
                    GameObject.Destroy(effet_game_object);
                }
                else
#endif
                {
                    BeforeRecycleEffect(effet_game_object);
                    ObjCachePoolMgr.Instance.RecyclePrefab(effet_game_object, ObjCachePoolType.SFX, effect_info.mTriggerSetting.SuitEffectPath(mIsLocalPlayer ? 0 : 1));
                }
               
            }
        }
    }

    /// <summary>
    /// 特效被回收前的处理
    /// </summary>
    /// <param name="effect_object"></param>
    void BeforeRecycleEffect(GameObject effect_object)
    {
        if(effect_object != null)
        {
            if(mIsPlayer && !mIsLocalPlayer)
                EffectManager.Instance.DecreaseEffectNum();
            var delay_time = effect_object.GetComponent<DelayTimeComponent>();
            if (delay_time != null)
                delay_time.Reset();
        }
    }

    /// <summary>
    /// 清除掉所有可以被打断的特效
    /// only_interrput 表示是否只清除可以中断的技能
    /// </summary>
    public void ClearEffects(bool only_interrput = false)
    {
        List<int> destroy_list = new List<int>();
        foreach (KeyValuePair<int, EffectInfo> item in mEffectObjects)
        {
            if (only_interrput)
            {
                if (item.Value.mTriggerSetting.InterrputEnable)
                {
                    destroy_list.Add(item.Key);
#if UNITY_EDITOR
                    if (InSkillEffectEditor())
                    {
                        GameObject.Destroy(item.Value.mEffectObject);
                    }
                    else
#endif
                    {
                        BeforeRecycleEffect(item.Value.mEffectObject);
                        ObjCachePoolMgr.Instance.RecyclePrefab(item.Value.mEffectObject, ObjCachePoolType.SFX, item.Value.mTriggerSetting.SuitEffectPath(mIsLocalPlayer ? 0 : 1));
                    }
                    //AudioManager.Instance.StopBattleSFX(item.Value.mSkillSoundId);
                }
            }
            else
            {

                destroy_list.Add(item.Key);

#if UNITY_EDITOR
                if (InSkillEffectEditor())
                {
                    GameObject.Destroy(item.Value.mEffectObject);
                }
                else
#endif
                {
                    BeforeRecycleEffect(item.Value.mEffectObject);
                    ObjCachePoolMgr.Instance.RecyclePrefab(item.Value.mEffectObject, ObjCachePoolType.SFX, item.Value.mTriggerSetting.SuitEffectPath(mIsLocalPlayer ? 0 : 1));
                }
                //AudioManager.Instance.StopBattleSFX(item.Value.mSkillSoundId);
            }
        }

        foreach (int k in destroy_list)
        {
            mEffectObjects.Remove(k);
        }

        destroy_list.Clear();
    }

    bool InSkillEffectEditor()
    {
        if (SceneManager.GetActiveScene().name == "SkillEffectEditor")
        {
            return true;
        }
        else
            return false;
    }
}

