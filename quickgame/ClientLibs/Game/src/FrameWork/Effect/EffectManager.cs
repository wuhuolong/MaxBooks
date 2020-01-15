//-------------------------------------------------------------------
// Desc : 特效的管理类
// Author : raorui
// Date : 2016.9.2 重构
//-------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;
namespace xc
{
    /// <summary>
    /// 特效的管理类
    /// </summary>
    public class EffectManager : xc.Singleton<EffectManager>
    {
        public int MaxPlayerEffectCount = 2;
        public int m_CurEffectNum = 0;

        public void IncreaseEffectNum()
        {
            m_CurEffectNum++;
        }

        public void DecreaseEffectNum()
        {
            m_CurEffectNum--;
        }

        public bool ExceedEffectNum()
        {
            //return true; // 始终无显示其他玩家的特效
            return m_CurEffectNum >= MaxPlayerEffectCount;
        }

        /// <summary>
        /// 所有的SkillAttackInstance
        /// </summary>
        Dictionary<ulong, SkillAttackInstance> mSkillAttackMaps;

        /// <summary>
        /// 所有的EffectEmitter,保存特效对应的Object
        /// </summary>
        Dictionary<string, EffectEmitter> mEmitterTemplateMap;

        /// <summary>
        /// 所有的AnimationEffect，保存已经实例化的特效GameObject和绑定的Target
        /// </summary>
        Dictionary<uint, AnimationEffect> mAnimationEffectMap;
        
        public EffectManager()
        {
            m_CurEffectNum = 0;
            mSkillAttackMaps = new Dictionary<ulong, SkillAttackInstance>();
            mEmitterTemplateMap = new Dictionary<string, EffectEmitter>();
            mAnimationEffectMap = new Dictionary<uint, AnimationEffect>();
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
        }

        public void Update()
        {
            var keys = SGameEngine.Pool<ulong>.List.New();

            using (var iter = mSkillAttackMaps.Keys.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    keys.Add(iter.Current);
                }
            }

                //foreach (var info in mSkillAttackMaps.Keys)
                //{
                //    keys.Add(info);
                //}

            //var keys = new List<ulong>(mSkillAttackMaps.Keys);
            for (int i = 0; i < keys.Count; ++i)
            {
                mSkillAttackMaps[keys[i]].Update();
            }

            Pool<ulong>.List.Free(keys);
        }

        /// <summary>
        /// 响应切换场景时候的消息
        /// </summary>
        void OnSwitchScene(CEventBaseArgs kArgs)
        {
            ClearAllEffect();
            m_CurEffectNum = 0;
        }

        /// <summary>
        /// 增加SkillAttackInstance
        /// </summary>
        public void AddSkillInstance(ulong uiID, SkillAttackInstance kSkillEffect)
        {
            mSkillAttackMaps[uiID] = kSkillEffect;
        }

        /// <summary>
        /// 移除SkillAttackInstance
        /// </summary>
        public bool RemoveSkillInstance(ulong uiID)
        {
            if (mSkillAttackMaps.ContainsKey(uiID))
            {
                mSkillAttackMaps.Remove(uiID);
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// 获取SkillAttackInstance
        /// </summary>
        public SkillAttackInstance GetAttackInstance(ulong uiID)
        {
            SkillAttackInstance kResult;
            if (mSkillAttackMaps.TryGetValue(uiID, out kResult))
                return kResult;
            
            return null;
        }

        /// <summary>
        /// 获取EffectEmitter
        /// </summary>
        public EffectEmitter GetEffectEmitter(string effectPrefab, int maxCount = 5)
        {
            EffectEmitter kResult;
            if (!mEmitterTemplateMap.TryGetValue(effectPrefab, out kResult))
            {           
                kResult = new EffectEmitter(effectPrefab, maxCount);
                mEmitterTemplateMap.Add(effectPrefab, kResult);
            }               
            
            return kResult; 
        }

        /// <summary>
        /// 增加AnimationEffect
        /// </summary>
        public void AddAnimationEffect(AnimationEffect kEffect)
        {
            kEffect.AddDestoryCallback(RemoveAnimationEffect);
            mAnimationEffectMap[kEffect.UID] = kEffect;
        }

        /// <summary>
        /// AnimationEffect销毁后的回调,将其从Map中移除
        /// </summary>
        private void RemoveAnimationEffect(System.Object param)
        {
            uint effect_id = (uint)param;
            mAnimationEffectMap.Remove(effect_id);
        }

        /// <summary>
        /// 清除掉所有特效
        /// </summary>
        private void ClearAllEffect()
        {
            // EffectEmitter涉及到AssetBundle，需要手动Destory
            foreach(EffectEmitter emt in mEmitterTemplateMap.Values)
            {
                emt.Destroy();
            }
            mEmitterTemplateMap.Clear();
            // AnimationEffect和SkillBaseComponent对应的GameObject在切换场景后会自动销毁
            mAnimationEffectMap.Clear();
            mSkillAttackMaps.Clear();
            // 重设EffectID
            AnimationEffect.EffectID = 0;
        }
    }
}
