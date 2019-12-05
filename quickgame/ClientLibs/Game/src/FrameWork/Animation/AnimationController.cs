using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
public class AnimationController : MonoBehaviour
{
    private AnimatorCullingMode mCullMode = AnimatorCullingMode.CullCompletely;
    public AnimatorCullingMode CullMode
    {
        get
        {
            return mCullMode;
        }

        set
        {
            mCullMode = value;
            if(mAnimator != null)
            {
                mAnimator.cullingMode = mCullMode;
            }
        }
    }

    AnimationClip[] m_AnimationClips;// 动画组件中包含的所有动画Clip

    /// <summary>
    /// 当前播放动画的数据
    /// </summary>
    struct CurAnimationInfo
    {
        public string Name;
        public bool IsPlaying;
        public bool IsLoop;
    }
    CurAnimationInfo mCurAnimationInfo;

    public AnimationController()
    {
        if(mLoopAnimations == null)
        {
            mLoopAnimations = new List<string>();
            mLoopAnimations.Add("idle");
            mLoopAnimations.Add("run");
            mLoopAnimations.Add("fightidle");
            mLoopAnimations.Add("fightrun");
            mLoopAnimations.Add("stun");
            mLoopAnimations.Add("rideidle");
            mLoopAnimations.Add("riderun");
            mLoopAnimations.Add("loadidle");
            mLoopAnimations.Add("rideidle01");
            mLoopAnimations.Add("rideidle02");
            mLoopAnimations.Add("rideidle03");
            mLoopAnimations.Add("rideidle04");
            mLoopAnimations.Add("riderun01");
            mLoopAnimations.Add("riderun02");
            mLoopAnimations.Add("riderun03");
            mLoopAnimations.Add("riderun04");
        }
    }

    Animator _animator;
    Animator mAnimator // Animator组件
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();

                if (_animator != null)
                    _animator.cullingMode = CullMode;
            }
               
            return _animator;
        }
    }

    /// <summary>
    /// 循环播放的动画
    /// </summary>
    public static List<string> LoopAnimations
    {
        get
        {
            return mLoopAnimations;
        }
    }
    static List<string> mLoopAnimations;
    static Dictionary<string, int> mAnimationHash = new Dictionary<string, int>();

    SkillEffectPlayer mSkillEffectPlayer;// 特效组件
	
    /// <summary>
    /// 动画是否被暂停
    /// </summary>
	bool mbPause = false;
	
	public delegate void AnimationCtrlCallBack(System.Object param);
	public class CallBackInfo
	{
		public System.Object mParam;// 回调函数的参数
		public AnimationCtrlCallBack mCallBack;// 触发时的回调函数
		public float mTime;// 触发的时间
	}
	
	Dictionary<int, CallBackInfo> mEventMap = new Dictionary<int, CallBackInfo>();

    static Dictionary<string, int> mPoolGameKeyToInt = new Dictionary<string, int>();
    static int mNextKey = 1;
    /// <summary>
    /// 注册动画对应的触发事件
    /// </summary>
    void RegisterAnimation(int key, SkillEffectPlayer effect_player)
    {
        TriggerSetting[] trigger_settings = effect_player.TriggerSettings;
        if (trigger_settings == null)
            return;

        // 根据TriggerSettings来进行动画事件的注册
        for (int i = 0; i < trigger_settings.GetLength(0); ++i)
        {
            int tigger_int = key * 100 + i;
            // 获取AnimationClip
            TriggerSetting trigger_setting = trigger_settings[i];
            AnimationClip animation_clip = trigger_setting.Animation;
            if (animation_clip == null)
            {
                GameDebug.LogError(effect_player.gameObject.name + "'s animationclip is null");
                continue;
            }

            // 初始化回调相关参数
            CallBackInfo info = new CallBackInfo();
            info.mTime = trigger_setting.StartFrame * 0.0333f;
            info.mCallBack = effect_player.OnFrameHit;
            info.mParam = trigger_setting;
            // 注册回调事件
            RegisterEvent(tigger_int, animation_clip.name, info);
        }
    }

    /// <summary>
    /// 注册动画触发事件
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ani"></param>
    /// <param name="kInfo"></param>
    void RegisterEvent(int id, string ani, CallBackInfo call_Info)
	{
		CallBackInfo info = GetCallBackInfos(id);

        if (info == null)
        {
            mEventMap.Add(id, call_Info);
        }
        else
            GameDebug.LogError("[RegisterEvent]Has same id");


        if (m_AnimationClips == null)
        {
            GameDebug.LogError("[RegisterEvent]m_AnimationClips is null");
            return;
        }

        // 注册AnimationEvent
        AnimationClip[] clips = m_AnimationClips;
        //int count = 0;

        bool is_find = false;
        for (int i = 0; i < clips.Length; ++i)
        {
            AnimationClip clip = clips[i];
            if (clip.name == ani)
            {
                is_find = false;

                // 当前clip中是否已经注册过该事件
                var clip_events = clip.events;
                if(clip_events != null)
                {
                    for (int find_index = 0; find_index < clip_events.Length; ++find_index)
                    {
                        var clip_event = clip_events[find_index];
                        if (clip_event.functionName == "OnHit" && clip_event.intParameter == id)
                        {
                            is_find = true;
                            break;
                        }
                    }
                }

                if (is_find)
                    break;

                float hitTime = call_Info.mTime;

                AnimationEvent ent = new AnimationEvent();
                ent.messageOptions = SendMessageOptions.DontRequireReceiver;
                ent.time = hitTime != 0 ? hitTime : 0.001f + hitTime; // 不能与OnPlayBegin同一时间，不然有可能OnHit不会被调用
                ent.functionName = "OnHit";
                ent.intParameter = id;
                
                clip.AddEvent(ent);

//              count++;
//              if(count > 1)
//              {
//                  GameDebug.LogError("count = " + count + " clip.name = " + clip.name);
//              }
            }
        }
    }

    bool mInited = false;

    bool mInitOnHit = false;
    /// <summary>
    /// 注册所有动画的开始和结束事件
    /// </summary>
    void RegisterStageEvent()
    {
        if (mAnimator == null)
        {
            GameDebug.LogWarning("[RegisterStageEvent]Animator is null");
            return;
        }

        if (mInited)
            return;

        mInited = true;

        RuntimeAnimatorController animator_control = mAnimator.runtimeAnimatorController;
        if (animator_control == null)
        {
            GameDebug.LogWarning("[RegisterStageEvent]RuntimeAnimatorController is null");
            return;
        }

        // 注册AnimationEvent
        m_AnimationClips = animator_control.animationClips;
        bool is_find = false;
        for (int i = 0; i < m_AnimationClips.Length; ++i)
        {
            var clip = m_AnimationClips[i];

            // 此时会产生gc
            /*for (int j = 0; j < clip.events.Length; ++j)
            {
                clip.events[j] = null;
            }*/

            bool is_exist_start_event = CheckExistEvent(clip, "OnPlayBegin");
            if (is_exist_start_event == false)
            {
                AnimationEvent beginEnt = new AnimationEvent();
                beginEnt.messageOptions = SendMessageOptions.DontRequireReceiver;
                beginEnt.time = 0;
                beginEnt.functionName = "OnPlayBegin";
                beginEnt.stringParameter = clip.name;
                clip.AddEvent(beginEnt);
            }

            bool is_exist_end_event = CheckExistEvent(clip, "OnPlayEnd");
            if(is_exist_end_event == false)
            {
                AnimationEvent endEnt = new AnimationEvent();
                endEnt.messageOptions = SendMessageOptions.DontRequireReceiver;
                endEnt.time = clip.length;
                endEnt.functionName = "OnPlayEnd";
                endEnt.stringParameter = clip.name;
                clip.AddEvent(endEnt);
            }
        }
    }

    /// <summary>
    /// AnimationClip中是否存在指定的Event
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="event_name"></param>
    /// <returns></returns>
    bool CheckExistEvent(AnimationClip clip, string event_name)
    {
        if (clip == null)
            return false;

        var clip_events = clip.events;
        if (clip_events == null)
            return false;

        for (int find_index = 0; find_index < clip_events.Length; ++find_index)
        {
            var clip_event = clip_events[find_index];
            if (clip_event.functionName == event_name)//已经添加这个方法，不再增加
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 清除掉所有的动画事件
    /// </summary>
    void ClearEvents()
	{
        mEventMap.Clear();

        // 取消注册AnimationEvent（实例化的prefab用的是一份animation event，因此不能取消注册事件）
        /*if(m_AnimationClips == null)
        {
            GameDebug.Log("[ClearEvents]m_AnimationClips is null");
            return;
        }

        AnimationClip[] clips = m_AnimationClips;
        for (int i = 0; i < clips.Length; ++i)
        {
            AnimationClip clip = clips[i];
            for(int j = 0; j < clip.events.Length; ++j)
            {
                clip.events[j] = null;
            }
            clip.events = null;
        }*/

        m_AnimationClips = null;
    }
	
    /// <summary>
    /// 获取动画对应的触发事件
    /// </summary>
    /// <param name="ani"></param>
    /// <returns></returns>
	CallBackInfo GetCallBackInfos(int id)
	{
		CallBackInfo result;
		if (mEventMap.TryGetValue(id, out result))
		{
			return result;
		}
		
		return null;
	}
	
    /// <summary>
    /// 是否在播放当前的动画
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
	public bool IsPlaying(string strName)
	{
        return enabled && mCurAnimationInfo.Name == strName && mCurAnimationInfo.IsPlaying;
	}


    /// <summary>
    /// 是否在播放任意的动画
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        return enabled && mCurAnimationInfo.IsPlaying;
    }

    /// <summary>
    /// 是否在指定的动画状态下
    /// </summary>
    /// <param name="ani"></param>
    /// <returns></returns>
    public bool IsInAnimationState(string ani)
    {
        return mAnimator.GetCurrentAnimatorStateInfo(0).IsName(ani);
    }

    /// <summary>
    /// 设置动画的播放速度
    /// </summary>
    /// <param name="speed"></param>
    public void SetAnimationSpeed(float speed)
    {
        if (mAnimator != null)
            mAnimator.speed = speed;
    }

    public void SetMoveSpeed(float speed)
    {
        if (mAnimator != null)
            mAnimator.SetFloat("MoveSpeed",speed);
    }

    public float GetAnimationLength(string ani)
    {
        if(m_AnimationClips == null)
        {
            GameDebug.LogError("[GetAnimationLength]m_AnimationClips is null");
            return 0;
        }

        if (string.IsNullOrEmpty(ani) == true)
        {
            return 0;
        }

        AnimationClip[] clips = m_AnimationClips;
        for (int i = 0; i < clips.Length; ++i)
        {
            AnimationClip clip = clips[i];
            if (clip.name == ani)
                return clip.length;
        }

        return 0;
    }

    /// <summary>
    /// 暂停、开启动画的播放
    /// </summary>
    /// <param name="bPause"></param>
	public void Pause(bool bPause)
	{
		mbPause = bPause;		

		if (mAnimator != null)
        {
            if (mAnimator.enabled != !mbPause)
            {
                mAnimator.enabled = !mbPause;
            }
        }
            
	}

    /// <summary>
    /// 重置动画组件
    /// </summary>
    public void Reset()
    {
        Pause(false);
        mCurAnimationInfo.Name = "";
        mCurAnimationInfo.IsPlaying = false;
        mCurAnimationInfo.IsLoop = false;
    }

	void Awake ()
	{
        var animator = GetComponent<Animator>();

        if(animator != null)
        {
            animator.cullingMode = CullMode;
            _animator = animator;
        }

        if (mSkillEffectPlayer == null)
            mSkillEffectPlayer = GetComponent<SkillEffectPlayer>();

        RegisterStageEvent();
    }

    /// <summary>
    /// 是否在技能编辑器中
    /// </summary>
    /// <returns></returns>
    bool InSkillEffectEditor()
    {
#if UNITY_EDITOR
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SkillEffectEditor")
        {
            return true;
        }
        else
            return false;
#else
        return false;
#endif
    }

    private void Update()
    {
        if (mInitOnHit == false)
            TryInit();
    }

    void TryInit()
    {
        string pool_key = "";
        if (InSkillEffectEditor())
        {
            pool_key = gameObject.GetInstanceID().ToString();
        }
        else
        {
            PoolGameObject pool = transform.GetComponent<PoolGameObject>();
            if (pool == null)
                return;

            pool_key = pool.key;
        }

        int key = 0;
        if (mPoolGameKeyToInt.TryGetValue(pool_key, out key) == false)
        {
            key = mNextKey;
            mPoolGameKeyToInt[pool_key] = key;
            ++mNextKey;
            if (mNextKey >= 1000000)
                mNextKey = 1;
        }

        // 注册开始、结束事件
        RegisterStageEvent();

        // 注册技能触发事件
        if (mSkillEffectPlayer != null)
            RegisterAnimation(key, mSkillEffectPlayer);
        else
            GameDebug.LogError("[AnimationController]SkillEffectPlayer is null");

        mInitOnHit = true;
    }
    
    void OnDestroy()
    {
        ClearEvents();

        mCurAnimationInfo.Name = "";
        mCurAnimationInfo.IsPlaying = false;
        mCurAnimationInfo.IsLoop = false;
    }

    /// <summary>
    /// 是否具备动画的资源
    /// </summary>
    /// <param name="name"></param>
    public bool HasAnimation(string ani)
    {
        if (string.IsNullOrEmpty(ani))
            return false;

        if (mAnimator == null)
            return false;

        int ani_hash = 0;
        if(!mAnimationHash.TryGetValue(ani, out ani_hash))
        {
            ani_hash = Animator.StringToHash(ani);
            mAnimationHash[ani] = ani_hash;
        }

        if (!mAnimator.HasState(0, ani_hash))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 是否是循环动画
    /// </summary>
    /// <param name="ani"></param>
    /// <returns></returns>
    bool IsLoop(string ani)
    {
        if (mAnimator == null)
            return false;

        if (mLoopAnimations.Contains(ani))
            return true;
        else
            return false;
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="time">归一化的时间</param>
    public bool PlayAnimation(string name, float time = 0)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        if (mAnimator == null)
            return false;

        bool play_succ = false;

        if (mSkillEffectPlayer != null)
            mSkillEffectPlayer.ClearEffects(true);

        if (HasAnimation(name))
        {
            play_succ = true;
            mAnimator.Play(name, -1, time);
        }

        mCurAnimationInfo.Name = name;
        mCurAnimationInfo.IsPlaying = true;
        mCurAnimationInfo.IsLoop = IsLoop(name);

        return play_succ;
    }

    /// <summary>
    /// 渐入渐出播放一个动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fadeTime"></param>
    public bool CrossfadeAnimation (string name, float fadeTime)
	{
        if (string.IsNullOrEmpty(name))
            return false;

        if (mAnimator == null)
            return false;

        if (mCurAnimationInfo.Name == name)
			return true;

        bool play_succ = false;

        if (mSkillEffectPlayer != null)
            mSkillEffectPlayer.ClearEffects(true);

        if (HasAnimation(name))
        {
            play_succ = true;
            mAnimator.CrossFadeInFixedTime(name, fadeTime, -1, 0);
        }

        mCurAnimationInfo.Name = name;
        mCurAnimationInfo.IsPlaying = true;
        mCurAnimationInfo.IsLoop = IsLoop(name);

        return play_succ;
    }

    /// <summary>
    /// 动画播放开始
    /// </summary>
    /// <param name="param"></param>
    public void OnPlayBegin(string param)
    {
        if (string.IsNullOrEmpty(mCurAnimationInfo.Name))
        {
            mCurAnimationInfo.Name = param;
            mCurAnimationInfo.IsLoop = IsLoop(param);
            mCurAnimationInfo.IsPlaying = true;
        }
    }

    /// <summary>
    /// 动画播放结束
    /// </summary>
    /// <param name="param"></param>
    public void OnPlayEnd(string param)
    {
        if (mCurAnimationInfo.Name == param && !mCurAnimationInfo.IsLoop)
        {
            mCurAnimationInfo.Name = "";
            mCurAnimationInfo.IsPlaying = false;
        }
    }

    public void OnHit(int param)
    {
        CallBackInfo info = GetCallBackInfos(param);
        if (info != null)
        {
            info.mCallBack(info.mParam);
        }
    }
}
