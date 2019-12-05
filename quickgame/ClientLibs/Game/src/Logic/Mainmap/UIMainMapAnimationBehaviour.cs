/*----------------------------------------------------------------
// 文件名： UIMainMapAnimationBehaviour.cs
// 文件功能描述： 主城UI动画管理组件
//----------------------------------------------------------------*/
using xc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc.ui;

namespace xc.ui.ugui
{
    public class UIMainMapAnimationBehaviour:IUIBehaviour
    {
        /// <summary>
        /// 所有动画的延时管理组件
        /// </summary>
        Dictionary<string, AnimationEventBridge> mDelayBehaviours = new Dictionary<string, AnimationEventBridge>();

        /// <summary>
        /// 保存所有的UI动画
        /// </summary>
        Dictionary<string, Animation> mAnimations = new Dictionary<string, Animation>();

        /// <summary>
        /// 动画控制的UI组件的状态 0: 展开在屏幕内 1: 缩在屏幕外 2: 正在播放动画 
        /// </summary>
        Dictionary<string, byte> mWidgetStates = new Dictionary<string, byte>();

        /// <summary>
        /// 用于管理动画的等待序列,必须按顺序进行
        /// </summary>
        Dictionary<string, LinkedList<byte>> mWidgetWaitList = new Dictionary<string, LinkedList<byte>>();

        /// <summary>
        /// 管理动画的等待索引的index
        /// </summary>
        Dictionary<string, byte> mWidgetWaitIndex = new Dictionary<string, byte>();

        public override void InitBehaviour()
        {
            var all_animation_info = DBMainmapAnimation.Instance.AnimationInfos;

            // 初始化所有UI动画的物体
            foreach (var name in all_animation_info.Keys)
            {
                var ui_animation = Window.FindChild<Animation>(name);
                ui_animation.playAutomatically = false;
                var animation_event = ui_animation.gameObject.AddComponent<AnimationEventBridge>();
                mAnimations.Add(name, ui_animation);
                mDelayBehaviours.Add(name, animation_event);
                mWidgetStates.Add(name, 100);
                mWidgetWaitIndex.Add(name, 0);
            }

            base.InitBehaviour();
        }

        public override void UpdateBehaviour()
        {
            base.UpdateBehaviour();
        }

        public override void DestroyBehaviour()
        {
            foreach(var ui_animation in mAnimations.Values)
            {
                if (ui_animation == null)
                    continue;

                var animation_clip = ui_animation.clip;

                if (animation_clip != null && animation_clip.events != null)
                {
                    for (int j = 0; j < animation_clip.events.Length; ++j)
                    {
                        animation_clip.events[j] = null;
                    }
                    animation_clip.events = null;
                }
            }

            mDelayBehaviours.Clear();
            mAnimations.Clear();
            mWidgetStates.Clear();

            foreach(var list in mWidgetWaitList.Values)
            {
                list.Clear();
            }
            mWidgetWaitList.Clear();
            mWidgetWaitIndex.Clear();
        }


        public override void EnableBehaviour(bool is_enable)
        {
            // 隐藏的时候需要重置状态
            if(is_enable == false)
            {

            }
        }

        /// <summary>
        /// 向指定的节点发送消息
        /// </summary>
        /// <param name="part"></param>
        /// <param name="is_show"></param>
        public void SendAnimationEvent(string part, bool is_show)
        {
            Animation animation = null;
            if(mAnimations.TryGetValue(part, out animation))
            {
                if(animation != null)
                    animation.gameObject.SendMessage("PlaySysBtnAnimation", is_show, SendMessageOptions.DontRequireReceiver);
            }
        }

        /// <summary>
        /// 播放指定节点的动画
        /// </summary>
        /// <param name="part"></param>
        /// <param name="target_state"></param>
        public void PlayAnimation(string part, uint target_state)
        {
            if(!PlayAnimationImpl(part, target_state))// 如果当前不能立即播放，则通过协程来进行等待
            {
                LinkedList<byte> wait_list = null;
                if (!mWidgetWaitList.TryGetValue(part, out wait_list))
                {
                    wait_list = new LinkedList<byte>();
                    mWidgetWaitList[part] = wait_list;
                }

                byte wait_index = 0;
                if (mWidgetWaitIndex.ContainsKey(part))
                {
                    wait_index = mWidgetWaitIndex[part];
                }
                else
                {
                    mWidgetWaitIndex[part] = 0;
                }

                wait_index++;
                wait_index = (byte)(wait_index % 255);
                wait_list.AddLast(wait_index);

                mWidgetWaitIndex[part] = wait_index;
                MainGame.HeartBehavior.StartCoroutine(PlayAnimationEx(part, target_state, wait_index));
            }
                
        }

        /// <summary>
        /// 执行动画播放的协程，需要等待上一次的动画播放完毕
        /// </summary>
        /// <param name="part"></param>
        /// <param name="target_state"></param>
        /// <returns></returns>
        IEnumerator PlayAnimationEx(string part, uint target_state, byte wait_index)
        {
            string animation_name = DBMainmapAnimation.Instance.GetAnimationName(part, target_state);
            if (string.IsNullOrEmpty(animation_name))
            {
                GameDebug.LogError("[PlayAnimationEx]mainmap animation is invalid,part:" + part);
                yield break;
            }

            AnimationEventBridge animation_event = null;
            if (!mDelayBehaviours.TryGetValue(part, out animation_event))
            {
                GameDebug.LogError("[PlayAnimationEx]mainmap animation has not animationi_event,part:" + part);
                yield break;
            }

            // 等待其他动画播放完毕
            byte wait_state = 100;
            while (true)
            {
                mWidgetStates.TryGetValue(part, out wait_state);
                if (wait_state != 100) // 没有其他的动画在播放或者播放完成
                {
                    yield return null;
                }
                else
                    break;
            }

            // 必须按顺序等待
            while(true)
            {
                LinkedList<byte> wait_list = mWidgetWaitList[part];
                if (wait_list.Count != 0 && wait_list.First.Value != wait_index)
                {
                    yield return null;
                    // 等待上一次的动画播放完毕
                    byte wait_next_state = 100;
                    while (true)
                    {
                        mWidgetStates.TryGetValue(part, out wait_next_state);
                        if (wait_next_state != 100) // 没有其他的动画在播放或者播放完成
                        {
                            yield return null;
                        }
                        else
                            break;
                    }
                }
                else
                {
                    if(wait_list.Count != 0)
                        wait_list.RemoveFirst();
                    break;
                }
            }

            animation_event.gameObject.SetActive(true);
            mWidgetStates[part] = (byte)target_state; // 播放过程中,状态设置为200

            // 播放动画并设置延时处理
            var anim = mAnimations[part];
            var animation_state = anim[animation_name];
            if (animation_state == null || animation_state.clip == null)
            {
                Debug.LogError(string.Format("part: {0}, target_state: {1} , animation: {2} is invalid.", part, target_state, animation_name));
                OnPlayAnimationEnd(string.Format("{0}~{1}", part, target_state));
                yield break;
            }

            var animation_clip = animation_state.clip;

            if (animation_clip.events != null)
            {
                for (int j = 0; j < animation_clip.events.Length; ++j)
                {
                    animation_clip.events[j] = null;
                }
                animation_clip.events = null;
            }

            AnimationEvent ent = new AnimationEvent();
            ent.time = animation_state.length;
            ent.functionName = "PlayAnimationEnd";
            ent.stringParameter = string.Format("{0}~{1}", part, target_state);
            animation_clip.AddEvent(ent);

            animation_event.onPlayAnimationEnd = OnPlayAnimationEnd;


            animation_state.speed = 1.0f;
            anim.Play(animation_name);
        }

        /// <summary>
        /// 指定动画播放
        /// </summary>
        /// <param name="part"></param>
        /// <param name="target_state"></param>
        /// <returns></returns>
        bool PlayAnimationImpl(string part, uint target_state)
        {
            string animation_name = DBMainmapAnimation.Instance.GetAnimationName(part, target_state);
            if (string.IsNullOrEmpty(animation_name))
            {
                GameDebug.LogError("[PlayAnimationEx]mainmap animation is invalid,part:" + part);
                return false;
            }

            AnimationEventBridge animationi_event = null;
            if (!mDelayBehaviours.TryGetValue(part, out animationi_event))
            {
                GameDebug.LogError("[PlayAnimationEx]mainmap animation has not animationi_event,part:" + part);
                return false;
            }

            byte wait_state = 100;
            mWidgetStates.TryGetValue(part, out wait_state);
            if (wait_state != 100) // 其他动画正在播放
            {
                // 播放动画并设置延时处理
                var animation = mAnimations[part];
                string wait_animation_name = DBMainmapAnimation.Instance.GetAnimationName(part, wait_state);
                animation[wait_animation_name].speed = 10.0f; // 进行加速处理
                return false;
            }

            animationi_event.gameObject.SetActive(true);
            mWidgetStates[part] = (byte)target_state;

            // 播放动画并设置延时处理
            var anim = mAnimations[part];
            var animation_state = anim[animation_name];
            if(animation_state == null || animation_state.clip == null)
            {
                Debug.LogError(string.Format("part: {0}, target_state: {1} , animation: {2} is invalid.", part, target_state, animation_name));
                OnPlayAnimationEnd(string.Format("{0}~{1}", part, target_state));
                return false;
            }
            var animation_clip = animation_state.clip;

            if(animation_clip.events != null)
            {
                for (int j = 0; j < animation_clip.events.Length; ++j)
                {
                    animation_clip.events[j] = null;
                }
                animation_clip.events = null;
            }

            AnimationEvent ent = new AnimationEvent();
            ent.time = animation_state.length;
            ent.functionName = "PlayAnimationEnd";
            ent.stringParameter = string.Format("{0}~{1}", part, target_state);
            animation_clip.AddEvent(ent);

            animationi_event.onPlayAnimationEnd = OnPlayAnimationEnd;


            animation_state.speed = 1.0f;
            anim.Play(animation_name);

            return true;
        }

        /// <summary>
        /// 响应动画事件播放完毕
        /// </summary>
        /// <param name="param"></param>
        public void OnPlayAnimationEnd(string param)
        {
            string[] animation_params = param.Split('~');
            if(animation_params.Length >= 2)
            {
                string part = animation_params[0];
                int target_state = int.Parse(animation_params[1]);

                mWidgetStates[part] = 100;

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAINMAP_ANIMATION_PLAY_END, new CEventEventParamArgs(part, target_state));
            }
        }
    }
}
