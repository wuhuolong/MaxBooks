using UnityEngine;
using System.Collections;

namespace xc
{
    /// <summary>
    /// 保存已经实例化的特效GameObject和绑定的Target
    /// </summary>
	public class AnimationEffect
	{
        public static uint EffectID = 0;
        public uint UID;

        const int MaxCount = 5;

        // 特效的配置数据
		public class ResInitData
		{
			public string Effect = string.Empty;// 特效的资源路径
			public string Audio = string.Empty;// 声音的资源路径
			public string BindNode = string.Empty;// 绑定的骨骼
            public float StartTime = 0.0f;// 开始的时间
			public float EndTime = 0.0f;// 结束的时间
			public bool IsLoop = false;// 声音播放是否是循环
			public bool	FollowTarget = true;// 特效是否跟随绑定的目标移动
            public bool AutoScale = false; // 是否根据绑定目标的半径进行自动缩放

            public ResInitData Clone()
			{
                return MemberwiseClone() as ResInitData;
			}
		}
		
        ResInitData mResData = null;// 资源数据
		GameObject m_BindTarget = null;// 特效绑定的目标物体
		public GameObject m_EffectObject = null;
        private DelayDestroyComponent.EndCallBack mDestroyCallBack;
        float m_TargetRadius;
	
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="data">特效配置的数据</param>
        /// <param name="target">特效绑定的物体</param>
        /// <param name="kEnd">特效销毁后的回调</param>
        public AnimationEffect(ResInitData data, GameObject target, float bind_target_radius, DelayDestroyComponent.EndCallBack kEnd)
		{
            mResData = data;
            m_BindTarget = target;
            m_TargetRadius = bind_target_radius;
            AddDestoryCallback(kEnd);
            LoadEffectRes();
            UID = EffectID;
            EffectID++;
		}		
		
        /// <summary>
        /// 重设特效销毁后的回调函数
        /// </summary>
        public void AddDestoryCallback(DelayDestroyComponent.EndCallBack kEnd)
		{
            mDestroyCallBack += kEnd;
		}
		
        /// <summary>
        /// 特效文件是否已经初始化
        /// </summary>
		bool mIsInited = false;
		
        /// <summary>
        /// 初始化特效资源
        /// </summary>
		public void LoadEffectRes()
		{		
            if (mIsInited)
				return;
			
            mIsInited = true;
            // 如果没有Prefab
			if (mResData.Effect == string.Empty)
			{
                m_EffectObject = new GameObject("AnimationEffect");
                // 绑定声音文件
                BindAudio(m_EffectObject);
			}
            // 有Prefab则初始化特效资源
			else
			{
                EffectManager.GetInstance().GetEffectEmitter(mResData.Effect, MaxCount).CreateInstance(InitEffectObject);
            }
		}
		
        /// <summary>
        /// 加载声音资源
        /// </summary>
		void BindAudio(GameObject audio_object)
		{
            //策划用公式合并表的时候，会将""转成"0",这里需要特殊处理一下
            if (mResData.Audio != string.Empty && mResData.Audio != "0")
			{
                AudioManager.Instance.BindAudio(audio_object, mResData.Audio, mResData.IsLoop);
			}
		}

        /// <summary>
        /// 特效资源加载完毕后的回调
        /// </summary>
        /// <param name="effect_object">加载的特效物体</param>
        void InitEffectObject(GameObject effect_object)
		{
            if (effect_object == null)
                return;

            m_EffectObject = effect_object;
            // 重新激活特效
            m_EffectObject.SetActive(false);
            m_EffectObject.SetActive(true);

            Transform effect_trans = m_EffectObject.transform;
			BindAudio(m_EffectObject);

            if (m_BindTarget == null)
            {
                GameObject.Destroy(effect_trans.gameObject);
                OnObjectDestroy(null);
                GameDebug.LogError("[InitEffectObject]m_BindTarget is null");
                return;
            }

            if (mResData.FollowTarget == false)// 不跟随骨骼移动
			{
                if (string.IsNullOrEmpty(mResData.BindNode))// 没有骨骼信息
				{
                    effect_trans.position = m_BindTarget.transform.position;
                    effect_trans.rotation = m_BindTarget.transform.rotation;
				}
                else// 有骨骼信息
				{
                    Transform bone_trans = ModelHelper.FindChildInHierarchy(m_BindTarget.transform, mResData.BindNode);
					if (bone_trans != null)
					{
                        effect_trans.position = bone_trans.position;
                        effect_trans.rotation = bone_trans.rotation;
                        effect_trans.localScale = Vector3.one;
					}
                    else
                    {
                        GameObject.Destroy(effect_trans.gameObject);
                        OnObjectDestroy(null);
                        GameDebug.LogError(string.Format("[InitEffectObject]m_BindTarget's bind node {0} is null", mResData.BindNode));
                    }
				}
			}
			else// 跟随骨骼移动
			{
				Transform bone_trans = null;
                if (!string.IsNullOrEmpty(mResData.BindNode))
                {
                    bone_trans = ModelHelper.FindChildInHierarchy(m_BindTarget.transform, mResData.BindNode);
                    // 角色模型资源可能没有加载完毕，获取不到骨骼信息
                    if(bone_trans == null && m_BindTarget.transform != null)
                        bone_trans = m_BindTarget.transform;
                }
                else if (m_BindTarget != null)
                    bone_trans = m_BindTarget.transform;
				
				if (bone_trans != null)
				{
                    effect_trans.position = bone_trans.position;
                    effect_trans.parent = bone_trans;
                    effect_trans.rotation = bone_trans.rotation;
                    effect_trans.localScale = Vector3.one;
				}
                else
                {
                    GameObject.Destroy(effect_trans.gameObject);
                    OnObjectDestroy(null);
                    GameDebug.Log(string.Format("[InitEffectObject]bindtarget's bind node {0} is null", mResData.BindNode));
                }
			}

            // 此处需要销毁，不然通过InstaGameObject获取不到新的物体（需要重构）
            // 将特效的删除修改为取消激活，以免GameObject的频繁实例化
            /*DelayEnableComponent kDelayEnableComponent = m_EffectObject.GetComponent<DelayEnableComponent>();
            if(kDelayEnableComponent == null)
                kDelayEnableComponent = m_EffectObject.AddComponent<DelayEnableComponent>();
            kDelayEnableComponent.DelayTime = mResData.EndTime;
            kDelayEnableComponent.SetEnable = false;
            kDelayEnableComponent.Start();*/

            //特效生命周期的2倍时间后销毁
            DelayDestroyComponent kDestroyComponent = m_EffectObject.GetComponent<DelayDestroyComponent>();
            if(kDestroyComponent == null)
                kDestroyComponent = m_EffectObject.AddComponent<DelayDestroyComponent>();
            kDestroyComponent.DelayTime = mResData.EndTime;// * 2.0f; 
            kDestroyComponent.AddEndCallBack(new DelayDestroyComponent.EndCallBackInfo(OnObjectDestroy, m_EffectObject));
            kDestroyComponent.Start();

            ParticleControl particle_control = effect_object.GetComponent<ParticleControl>();
            if (particle_control == null)
                particle_control = effect_object.AddComponent<ParticleControl>();
            particle_control.Scale = mResData.AutoScale ? m_TargetRadius / GlobalConst.StandardRadius : 1.0f;

        }
		
        /// <summary>
        /// 特效GameObject被销毁后的回调
        /// </summary>
		public void OnObjectDestroy(System.Object obj)
		{
            mIsInited = false;
            if(mDestroyCallBack != null)
                mDestroyCallBack(UID);
		}
	}
}