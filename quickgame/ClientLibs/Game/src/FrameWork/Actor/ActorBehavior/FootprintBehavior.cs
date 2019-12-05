using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class FootprintBehavior : IActorBehavior
    {
        //特效信息
        public class SceneEffectInfo
        {
            // 特效路径 用于回收
            public string mFileName;
            // 持续时间
            public float mDelayTime;
            // 特效的GameObject
            public GameObject mEffectObject;

            public SceneEffectInfo(string file_name, float delay_time, GameObject effect_object)
            {
                mFileName = file_name;
                mDelayTime = delay_time;
                mEffectObject = effect_object;
            }

        }

        private float mMinDistance = 2;
        private uint mFootprintId = 0;
        private string mSceneEffectFile = "";
        private float mSceneEffectDelayTime = 0f;
        private float mCDTime = 0f;
        private string mStandEffectFile = "";

        private Vector3 mLastEffectPos = Vector3.zero;
        private float mCreateTime;
        private SceneEffectInfo mStandEffectInfo;
        private GameObject mStandEffectContainer;

        /// <summary>
        /// 保存场景特效物体和特效信息
        /// </summary>
        Dictionary<int, SceneEffectInfo> mEffectObjects = new Dictionary<int, SceneEffectInfo>();

        public FootprintBehavior(Actor owner)
        {
            mOwner = owner;
            //SetFootprintId(400001);
        }
        public override void EnableBehaviors(bool enable)
        {

        }

        public override void InitBehaviors()
        {
        }

        public override void LateUpdate()
        {
        }

        public override void Update()
        {
            if (mFootprintId <= 0 || mOwner == null)
            {
                return;
            }

            //没有坐骑的LocalPlayer
            if (mOwner.IsLocalPlayer && (mOwner.mRideCtrl == null || mOwner.mRideCtrl.Rider == null))
            {
                //Debug.Log("no ride IsLocalPlayer");
                CheckCreateEffect();
                return;
            }

            //坐骑上的ClientModel
            if (mOwner.IsClientModel())
            {
                //Debug.Log("IsClientModel");

                ClientModel m = mOwner as ClientModel;
                if (m.IsRidePlayer)
                {
                    //Debug.Log("rider ClientModel");
                    CheckCreateEffect();
                    return;
                }
            }
        }

        void CheckCreateEffect()
        {
            mCreateTime += Time.deltaTime;
            if (mCreateTime > mCDTime)
            {
                Vector3 pos = mOwner.transform.position;
                pos.y = PhysicsHelp.GetHeight(pos.x, pos.z);

                if (Vector3.Distance(pos, mLastEffectPos) >= mMinDistance)
                {
                    mCreateTime = 0;
                    CreateSceneEffect(pos);
                    mLastEffectPos = pos;
                }
            }
        }

        public override void UnInitBehaviors()
        {
            Clear();
            base.UnInitBehaviors();
        }

        public IEnumerator SetFootprintId(uint footprintId)
        {
            if (footprintId <= 0)
            {
                Clear();
                yield break;
            }

            if (mFootprintId == footprintId)
            {
                yield break;
            }

            DBFootprint.DBFootprintItem item = DBFootprint.GetFootprintItem(footprintId);
            if(item == null)
            {
                yield break;
            }
            mSceneEffectFile = item.SuitablePath(true);
            mSceneEffectDelayTime = item.DelayTime;
            mCDTime = item.CDTime;
            mMinDistance = item.MinDistance;
            mCreateTime = 0;

            //var avatarPart = DBManager.Instance.GetDB<DBAvatarPart>().mData[footprintId];
            var avatarPart = DBAvatarPart.GetAvatarPartData(footprintId);
            if(avatarPart == null)
            {
                yield break;
            }
            mStandEffectFile = avatarPart.SuitablePath(true);

            if(mOwner == null || mOwner.transform == null)
            {
                yield break;
            }
            Vector3 pos = mOwner.transform.position;
            pos.y = PhysicsHelp.GetHeight(pos.x, pos.z);
            mLastEffectPos = pos;
            mFootprintId = footprintId;

            if (mOwner.IsUIModel())
            {
                yield return ResourceLoader.Instance.StartCoroutine(LoadStandEffect(mStandEffectFile));
            }
        }

        private void CreateSceneEffect(Vector3 position)
        {
            //if (!mOwner.IsLocalPlayer)
            //    return;

            if (!CheckHadFootprint())
                return;

            if (String.IsNullOrEmpty(mSceneEffectFile))
                return;

            ResourceLoader.Instance.StartCoroutine(LoadSceneEffect(position, mSceneEffectFile, mSceneEffectDelayTime));
        }

        bool CheckHadFootprint()
        {
            return mFootprintId != 0;
        }

        IEnumerator LoadStandEffect(string fileName)
        {
            GameObject model = mOwner.mAvatarCtrl.GetModel();
            if (model == null)
            {
                yield break;
            }

            RemoveStandEffect();
            Transform pos = CommonTool.FindChildInHierarchy(model.transform, AvatarCtrl.ROOT_NODE);
            if (pos == null)
            {
                Debug.LogError(string.Format("not found footprint point on {0}", model.name));
                yield break;
            }
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(fileName, ObjCachePoolType.SFX, fileName, ow));
            GameObject effect_object = ow.obj as GameObject;
            if (effect_object == null)
            {
                yield break;
            }

            GameObject.DontDestroyOnLoad(effect_object);

            if (mIsDestroy || fileName != mStandEffectFile)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, fileName);
                yield break;
            }
            RemoveStandEffect();

            if(mStandEffectContainer == null)
            {
                mStandEffectContainer = new GameObject("FootprintContainer");
            }
            mStandEffectContainer.transform.parent = pos;
            mStandEffectContainer.transform.localPosition = Vector3.zero;
            mStandEffectContainer.transform.localEulerAngles = new Vector3(0, 0, 0);
            mStandEffectContainer.transform.localScale = Vector3.one;

            effect_object.transform.parent = mStandEffectContainer.transform;
            effect_object.transform.localPosition = Vector3.zero;
            effect_object.transform.localEulerAngles = new Vector3(0, 0, 0);
            effect_object.transform.localScale = Vector3.one;

            int layer = 0;
            if (mOwner.mAvatarCtrl.GetModelParent() != null)
                layer = mOwner.mAvatarCtrl.GetModelParent().layer;
            mOwner.mAvatarCtrl.SetRenderLayer(effect_object, layer, false, false);

            mStandEffectInfo = new SceneEffectInfo(fileName, 0, effect_object);

        }



        public IEnumerator LoadSceneEffect(Vector3 position, string fileName, float delayTime)
        {
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(fileName, ObjCachePoolType.SFX, fileName, ow));
            GameObject effect_object = ow.obj as GameObject;
            if (effect_object == null)
            {
                yield break;
            }

            GameObject.DontDestroyOnLoad(effect_object);

            if (mIsDestroy)
            {
                BeforeRecycleEffect(effect_object);
                ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, fileName);
                yield break;
            }
            effect_object.transform.position = position;
            CommonTool.SetActive(effect_object, false);
            CommonTool.SetActive(effect_object, true);

            var delay_timer = effect_object.GetComponent<DelayTimeComponent>();
            if (delay_timer == null)
                delay_timer = effect_object.AddComponent<DelayTimeComponent>();
            delay_timer.DelayTime = delayTime;
            delay_timer.Start();

            SceneEffectInfo info = new SceneEffectInfo(fileName, delayTime, effect_object);
            mEffectObjects[effect_object.GetHashCode()] = info;

            delay_timer.SetEndCallBack(new DelayTimeComponent.EndCallBackInfo(OnEffectPlayFinish, effect_object));


        }

        void Clear()
        {
            mFootprintId = 0;
            RemoveStandEffect();
            ClearSceneEffect();
        }


        void OnEffectPlayFinish(System.Object effect_object)
        {
            GameObject effet_game_object = effect_object as GameObject;
            if (effet_game_object != null)
            {
                SceneEffectInfo effect_info = null;
                int key = effet_game_object.GetHashCode();
                if (mEffectObjects.TryGetValue(key, out effect_info))
                {
                    mEffectObjects.Remove(key);
                    BeforeRecycleEffect(effet_game_object);
                    ObjCachePoolMgr.Instance.RecyclePrefab(effet_game_object, ObjCachePoolType.SFX, effect_info.mFileName);
                }
            }
        }

        /// <summary>
        /// 特效被回收前的处理
        /// </summary>
        /// <param name="effect_object"></param>
        public void BeforeRecycleEffect(GameObject effect_object)
        {
            if (effect_object != null)
            {
                //if (mIsPlayer && !mIsLocalPlayer)
                //EffectManager.Instance.DecreaseEffectNum();
                var delay_time = effect_object.GetComponent<DelayTimeComponent>();
                if (delay_time != null)
                    delay_time.Reset();

                CommonTool.SetActive(effect_object, false);
            }
        }

        public void RemoveStandEffect()
        {
            if (mStandEffectInfo == null)
            {
                return;
            }
            ObjCachePoolMgr.Instance.RecyclePrefab(mStandEffectInfo.mEffectObject, ObjCachePoolType.SFX, mStandEffectInfo.mFileName);
            mStandEffectInfo = null;
            if (mStandEffectContainer != null)
            {
                GameObject.DestroyImmediate(mStandEffectContainer);
                mStandEffectContainer = null;
            }
        }

        public void ClearSceneEffect()
        {
            foreach (KeyValuePair<int, SceneEffectInfo> item in mEffectObjects)
            {
                BeforeRecycleEffect(item.Value.mEffectObject);
                ObjCachePoolMgr.Instance.RecyclePrefab(item.Value.mEffectObject, ObjCachePoolType.SFX, item.Value.mFileName);
            }
            mEffectObjects.Clear();
        }

        public void SetStandEulerAngles(Vector3 angle)
        {
            if(mStandEffectContainer != null)
            {
                mStandEffectContainer.transform.localEulerAngles = angle;
            }
        }
    }
}
