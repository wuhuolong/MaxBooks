//-------------------------------------------------
// File: MarryFireworkManager.cs 
// Desc: 情缘副本中烟花释放效果的管理类
// Authro: raorui
// Date: 2018.11.21
//-------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class MarryFireworkManager
    {
        public class EmitInfo
        {
            uint mEmitId; // id
            float mMaxLifeTime = 0.0f; // 最大生命周期
            string mEffectPath = "";// 特效的资源路径

            float mLifeTime = 0.0f;// 当前的生命时间
            bool mIsFinish = false; // 播放是否完成
            GameObject mEffectObject = null;// 加载的特效物体
            AssetResource mAudioRes = null; // 音效资源

            public uint EmitID
            {
                get
                {
                    return mEmitId;
                }
            }

            public bool IsFinish
            {
                get
                {
                    return mIsFinish;
                }
            }

            public void Update()
            {
                if (mIsFinish)
                    return;

                mLifeTime += Time.deltaTime;
                if (mLifeTime > mMaxLifeTime)
                {
                    mIsFinish = true;
                    Stop();
                }
            }

            public EmitInfo(uint emitId, float maxLifeTime, string effectPath)
            {
                mEmitId = emitId;
                mLifeTime = 0;
                mMaxLifeTime = maxLifeTime;
                mIsFinish = false;
                mEffectPath = effectPath;
            }

            /// <summary>
            /// 停止特效播放
            /// </summary>
            public void Stop()
            {
                mLifeTime = 0;
                mIsFinish = true;
                if (mEffectObject != null)
                {
                    ObjCachePoolMgr.Instance.RecyclePrefab(mEffectObject, ObjCachePoolType.SFX, mEffectPath);
                    mEffectObject = null;
                }

                if(mAudioRes != null)
                {
                    mAudioRes.destroy();
                    mAudioRes = null;
                }
            }

            /// <summary>
            /// 重置特效播放信息
            /// </summary>
            /// <param name="emitId"></param>
            /// <param name="maxLifeTime"></param>
            /// <param name="effectPath"></param>
            public void Reset(uint emitId, float maxLifeTime, string effectPath)
            {
                mEmitId = emitId;
                mMaxLifeTime = maxLifeTime;
                mEffectPath = effectPath;

                mLifeTime = 0;
                mIsFinish = false;
            }

            /// <summary>
            /// 设置特效物体
            /// </summary>
            /// <param name="obj"></param>
            public void SetObject(GameObject obj)
            {
                mEffectObject = obj;
            }

            /// <summary>
            /// 设置音效资源
            /// </summary>
            /// <param name="ar"></param>
            public void SetAuido(AssetResource ar)
            {
                mAudioRes = ar;
            }
        }

        static MarryFireworkManager mInstance;
        public static MarryFireworkManager Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new MarryFireworkManager();
                return mInstance;
            }
        }

        public MarryFireworkManager()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }

        /// <summary>
        /// 当前正在播放特效的信息
        /// </summary>
        EmitInfo mEmitInfo = null;

        static uint mEmitId = 0;
        uint mCurEmitId = 0;

        /// <summary>
        /// 在uuid的玩家身上播放物品gid对应的烟火特效资源
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="gid"></param>
        public void Ignite(uint uuid, uint gid)
        {
            var info = DBMarryFirework.Instance.GetInfo(gid);
            if (info == null)
            {
                GameDebug.LogError("[Ignite]get firework info failed, id:" + gid);
                return;
            }

            /*var actor = ActorManager.Instance.GetActor(uuid);
            if (actor == null || actor.IsDestroy)
            {
                GameDebug.LogError("[Ignite]get actor info failed, id:" + uuid);
                return;
            }*/

            var isLocalPlayer = uuid == LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx;
            if (isLocalPlayer)
            {
                // 停止之前正在播放的特效
                if (mEmitInfo != null && !mEmitInfo.IsFinish)
                {
                    mEmitInfo.Stop();
                }
            }
            else
            {
                // 如果当前有正在播放的特效，则直接返回
                if (mEmitInfo != null && !mEmitInfo.IsFinish)
                    return;
            }

            if (mEmitId == 0)
                mEmitId++;
            mCurEmitId = mEmitId;

            if (mEmitInfo == null)
                mEmitInfo = new EmitInfo(mCurEmitId, info.Time, info.AssetPath);
            else
                mEmitInfo.Reset(mCurEmitId, info.Time, info.AssetPath);

            MainGame.HeartBehavior.StartCoroutine(PlayEffect(info.AssetPath, mEmitInfo, mCurEmitId));
            MainGame.HeartBehavior.StartCoroutine(PlayAudio("Assets/Res/" + info.AudioPath, mEmitInfo, mCurEmitId));
            mEmitId++;
        }

        public void Update()
        {
            // 更新当前特效的生命周期
            if (mEmitInfo != null && !mEmitInfo.IsFinish)
            {
                mEmitInfo.Update();
            }
        }

        /// <summary>
        /// 切换场景的时候需要重置烟花特效
        /// </summary>
        /// <param name="data"></param>
        void OnStartSwitchScene(CEventBaseArgs data)
        {
            if(mEmitInfo != null && !mEmitInfo.IsFinish)
            {
                mEmitInfo.Stop();
            }
        }

        /// <summary>
        /// 在指定位置播放特效
        /// </summary>
        /// <param name="effectPath"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public IEnumerator PlayEffect(string effectPath, EmitInfo emitInfo, uint emitId)
        {
            var objectWrapper = new ObjectWrapper();
            yield return MainGame.HeartBehavior.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(effectPath, ObjCachePoolType.SFX, effectPath, objectWrapper));
            if (objectWrapper.obj == null)
                yield break;

            var effectObject = objectWrapper.obj as GameObject;
            if (effectObject == null)
                yield break;

            GameDebug.Log("emit:" + emitInfo.EmitID + "," + emitId);

            // 如果当前ID发生变化，说明之前的特效播放已经被终止
            if (emitId != mCurEmitId)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(effectObject, ObjCachePoolType.SFX, effectPath);
                yield break;
            }

            emitInfo.SetObject(effectObject);

            // 如果找不到当前主相机，则停止特效的播放
            Camera mainCam = Camera.main;
            if (mainCam == null)
            {
                if(!emitInfo.IsFinish)
                    emitInfo.Stop();
                yield break;
            }
               
            var effectTrans = effectObject.transform;
            effectTrans.parent = mainCam.transform;
            effectTrans.localPosition = Vector3.zero;
            effectTrans.localScale = Vector3.one;
            effectTrans.localRotation = Quaternion.identity;
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="effectPath"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public IEnumerator PlayAudio(string resPath, EmitInfo emitInfo, uint emitId)
        {
            var ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(resPath, typeof(Object), ar));
            if (ar.asset_ == null)
            {
                GameDebug.LogError(string.Format("the res {0} does not exist", resPath));
                yield break;
            }

            // 如果当前ID发生变化，说明之前的特效播放已经被终止
            if (emitId != mCurEmitId)
            {
                ar.destroy();
                yield break;
            }

            emitInfo.SetAuido(ar);
            var audio_clip = ar.asset_ as AudioClip;
            if (audio_clip != null)
            {
                AudioManager.Instance.PlayAudio(audio_clip, false);
            }
        }
    }
}
