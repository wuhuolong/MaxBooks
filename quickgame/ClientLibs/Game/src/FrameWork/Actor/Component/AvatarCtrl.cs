//------------------------------------------------
// File: AvatarCtrl.cs
// Desc:处理角色换装的组件
// Author: raorui
// Date: 2017.10.28
//------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;
using System.Linq;

namespace xc
{
    public enum VisibleDirty
    {
        NONE = 0,//not dirty
        VISIBLE = 1, //visible
        INVISIBLE = 2,//notvisible
    }

    [wxb.Hotfix]
    public class AvatarCtrl : BaseCtrl
    {
        public static readonly string ROOT_NODE = "root_node";
        public static readonly string BODY_NAME = "suits";
        public static readonly string WEAPON_NAME = "weapon_mount";
        public static readonly string MOUNT_POINT_WING = "wing_link"; //"BoneProp1";//"wing_link"
        public static readonly string MOUNT_POINT_NAME = "mount_link";
        public static readonly string BOSS_CHIP_HAND_NAME = "Bip001 R Hand";    //抓BOSS的手上特效位置
        public static readonly string SPIRIT_LINK_NAME = "spirit_link";     //小精灵挂点
        public static readonly string MAGICAL_PET_LINK_NAME = "spirit_link01";     //神宠挂点
        public static readonly string AVATAR_PATH_PREFIX = "Assets/Res";
        public static readonly string BACK_ATTACHMENT_LINK = "back_link";

        /// <summary>
        /// 是否首次加载模型
        /// </summary>
        private bool mIsFirstLoadModel = true;

        //case changeable modles
        private AvatarProperty mCurrentProperty = null;// 第一次换装成功后才赋值
        private AvatarProperty m_LastProperty = null;// 变身前的保存的换装属性
        private AvatarProperty mDirtyProperty = null;// 需要换装时，先设置该属性，在Update中检查有改动时再进行LoadAvatarAsync操作

        //case unchangable modle
        private string mDirtyPrefabName = null;//需要加载的prefab资源的名字，先设置路径，在Update中检查有改动时再进行LoadAvatarAsync操作
        private string m_LoadedPrefabName = null;//记录已经加载过得prefab资源的名字，以便于在Destory时销毁资源
        private string m_LastPrefabName = null; //变身前保存的prefab资源的名字
        private string m_PrefabNameBeforeUnload = null; //unload前保存的prefab资源的名字

        private bool m_IsShapeShift = false; //是否处在变身状态
        private byte mShiftState = 0; // 变身状态标记

        /// <summary>
        /// 是否处在变身加载模型的过程中
        /// </summary>
        private bool m_IsShapeProcessing = false;

        public bool IsShapeProcessing
        {
            get { return m_IsShapeProcessing; }
        }

        private bool mIsProcessingModel = false;//进行LoadAvatarAsync操作后此变量设置为true，当完成模型的加载后才设置为false
        private GameObject mModel;//已经实例化后的角色模型
        private bool mCurrentVisible = false;// 当前角色被设置成的可见状态
        private VisibleDirty mDirtyVisible = VisibleDirty.NONE;// 可见性发生改变时
        private GameObject mElfinLinkObj = null; //小精灵挂点
        private GameObject mMagicalPetLinkObj = null;   //神宠挂点
        /// <summary>
        /// 加载的套装特效物体
        /// </summary>
        private Dictionary<string, List<GameObject>> m_EffectObjs = new Dictionary<string, List<GameObject>>();

        private Dictionary<string, GameObject> m_WingObjs = new Dictionary<string, GameObject>();
        Dictionary<string, GameObject> m_BackAttachments = new Dictionary<string, GameObject> ();
        public List<xc.DBAvatarPart.BODY_PART> mNoShowParts = null;

        private bool m_is_wait_one_frame = false;
        private uint m_has_waited_frame = 0;

        public bool NeedShowBackAttachment = false; // 是否在直接显示背饰(需求上大部分UI界面不显示背饰)
        /// <summary>
        /// 模型是否加载中
        /// </summary>
        public bool ModelIsLoading { get; set; }

        /// <summary>
        /// 模型是否加载好
        /// </summary>
        public bool ModelIsLoaded { get; set; }

        uint obj_idx;
        public AvatarCtrl(Actor owner) : base(owner)
        {
            ModelIsLoading = false;
            ModelIsLoaded = false;
            obj_idx = mOwner.UID.obj_idx;
        }

        /// <summary>
        /// 返回当前角色对应的GameObject
        /// </summary>
        /// <returns></returns>
        public GameObject GetModel()
        {
            return mModel;
        }

        /// <summary>
        /// 返回当前角色对应的GameObject
        /// </summary>
        /// <returns></returns>
        public GameObject GetModelParent()
        {
            if (!mIsDestroy)
                return mModelParent;
            else
                return null;
        }

        /// <summary>
        /// 设置角色是否可见
        /// 给VisibleCtrl提供的接口，其他地方不需要调用
        /// </summary>
        public void SetVisible(bool visible)
        {
            mDirtyVisible = visible ? VisibleDirty.VISIBLE : VisibleDirty.INVISIBLE;

            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null && !mOwner.mRideCtrl.Rider.IsDestroy && mOwner.mRideCtrl.Rider.mAvatarCtrl != null)
            {
                mOwner.mRideCtrl.Rider.mAvatarCtrl.SetVisible(visible);
            }
        }

        public AvatarProperty GetAvatartProperty()
        {
            if (mOwner == null || mOwner.IsDestroy)
                return null;

            // 销毁后mOwner会被release掉
            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null && !mOwner.mRideCtrl.Rider.IsDestroy && mOwner.mRideCtrl.Rider.mAvatarCtrl != null)
            {
                return mOwner.mRideCtrl.Rider.mAvatarCtrl.GetAvatartProperty();
            }
            else
            {
                if (mCurrentProperty != null)
                    return mCurrentProperty;
                else
                    return m_LastProperty;
            }
        }

        public AvatarProperty GetAvatartProperty_onlySelf()
        {
            if (mCurrentProperty != null)
                return mCurrentProperty;
            else
                return m_LastProperty;

        }

        /// <summary>
        /// 获取可用的换装属性（一般给角色使用）
        /// </summary>
        /// <returns></returns>
        public AvatarProperty GetLatestAvatartProperty()
        {
            // 销毁后mOwner会被release掉
            if (mOwner != null && mOwner.IsDestroy == false && mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null
                && mOwner.mRideCtrl.Rider.mAvatarCtrl != null)
            {
                return mOwner.mRideCtrl.Rider.mAvatarCtrl.GetAvatartProperty();
            }
            else
            {
                if (mDirtyProperty != null)
                    return mDirtyProperty;
                else if (mCurrentProperty != null)
                    return mCurrentProperty;
                else
                    return m_LastProperty;
            }
        }

        /// <summary>
        /// 获取即将加载或者已经加载的prefab资源路径（一般给怪物使用）
        /// </summary>
        /// <returns></returns>
        string GetLatestAvatarPrefab()
        {
            if (mDirtyPrefabName != null)
                return mDirtyPrefabName;
            else if (m_LoadedPrefabName != null)
                return m_LoadedPrefabName;
            else
                return m_PrefabNameBeforeUnload;
        }

        /// <summary>
        /// 是否处在变身状态
        /// </summary>
        public bool IsShapeShift
        {
            get
            {
                return m_IsShapeShift;
            }
        }

        /// <summary>
        /// 变身状态的特殊标记
        /// </summary>
        public byte ShiftState
        {
            get
            {
                return mShiftState;
            }
        }

        /// <summary>
        /// 模型是否正在加载过程中（包括角色和和坐骑）
        /// considerNotInited设置为true时，表示需要等待角色完全初始化完毕
        /// </summary>
        public bool IsLoading(bool considerNotInited)
        {
            if (mOwner == null || mOwner.IsDestroy)
                return false;

            bool isloading = mIsProcessingModel || mDirtyProperty != null || mDirtyPrefabName != null;// 是否正在进行换装或者需要进行换装操作
            if (considerNotInited)
            {
                isloading = isloading || !mOwner.IsResLoaded;
            }

            // 坐骑是否在加载过程中
            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null && mOwner.mRideCtrl.Rider.IsDestroy == false
                && mOwner.mRideCtrl.Rider.mAvatarCtrl != null)
            {
                isloading = isloading || mOwner.mRideCtrl.Rider.mAvatarCtrl.IsLoading(considerNotInited);
            }

            return isloading;
        }

        public bool IsProcessingModel
        {
            get
            {
                return mIsProcessingModel;
            }
        }

        /// <summary>
        /// 当前模型是否处于可见状态
        /// </summary>
        public bool IsModelVisible()
        {
            return mCurrentVisible;
        }

        public void SetRenderLayer(GameObject layer_obj, int layer, bool isIgnoreMatReplace, bool castShadow = true)
        {
            if (layer_obj == null)
                return;

            Renderer[] renders = layer_obj.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer r in renders)
            {
                GameObject obj = r.gameObject;
                obj.layer = layer;

                if (isIgnoreMatReplace && obj.tag != "MatReplace")
                    continue;

                if (!castShadow)
                    continue;

                ShadowCull cull = obj.GetComponent<ShadowCull>();
                if (cull == null)
                {
                    cull = obj.AddComponent<ShadowCull>();
                    cull.Init(mOwner);
                }

                cull.SetLayer(layer);
            }
        }
        /// <summary>
        /// 设置模型下所有Render的层级
        /// </summary>
        /// <param name="layer"></param>
        public void SetLayer(int layer)
        {
            if (mModel == null)
            {
                return;
            }

            int model_layer = 0;
            if (layer == -1)
            {
                layer = mOwner.GetLayer();
                model_layer = mOwner.GetModelLayer();
            }
            else
                model_layer = layer;

            mModelParent.layer = layer;
            mModel.layer = model_layer;

            Renderer[] renders = mModel.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer r in renders)
            {
                GameObject obj = r.gameObject;
                obj.layer = model_layer;

                if (obj.tag != "MatReplace")
                    continue;
                ShadowCull cull = obj.GetComponent<ShadowCull>();
                if (cull == null)
                {
                    cull = obj.AddComponent<ShadowCull>();
                    cull.Init(mOwner);
                }

                cull.SetLayer(model_layer);
            }

            if (mElfinObject != null)
            {
                renders = mElfinObject.GetComponentsInChildren<Renderer>(true);
                foreach (Renderer r in renders)
                {
                    GameObject obj = r.gameObject;
                    obj.layer = model_layer;
                }
            }
            if (mMagicalPetObject != null)
            {
                renders = mMagicalPetObject.GetComponentsInChildren<Renderer>(true);
                foreach (Renderer r in renders)
                {
                    GameObject obj = r.gameObject;
                    obj.layer = model_layer;
                }
            }
        }

        /// <summary>
        /// 通过模型列表和时装列表的数据来创建角色模型
        /// </summary>
        /// <param name="modleList"></param>
        /// <param name="fashions"></param>
        /// <param name="vocation"></param>
        /// <param name="rot"></param>
        /// <param name="change_rider_first"></param>
        /// <param name="cbResLoaded"></param>
        /// <returns></returns>
        public IEnumerator CreateModelFromModleList(Vector3 pos, Quaternion rot, Vector3 scale, List<uint> modleList, List<uint> fashions, List<uint> suit_effects, Actor.EVocationType vocation, Action<Actor> cbResLoaded)
        {
            ModelIsLoading = true;

            //先创建一个空GameObject
            InitEmptyModel(pos, rot, scale);

            SetAvatarProperty(modleList, fashions, suit_effects, vocation, false);
            while (IsLoading(false))
            {
                yield return new WaitForEndOfFrame();
            }
            yield return null;

            // 异步加载时，可能角色已经被销毁了
            if (mOwner == null || mOwner.IsDestroy)
            {
                //FIXME
                DestroyModel();
                mIsProcessingModel = false;
                yield break;
            }

            if (mModel != null)
            {
                if (mIsFirstLoadModel == true)
                {
                    mOwner.OnResLoaded();
                }
                if (cbResLoaded != null)
                {
                    cbResLoaded.Invoke(mOwner);
                }

                if (mIsFirstLoadModel == true)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_RES_LOADED, new CEventActorArgs(mOwner));
                }
            }

            mIsFirstLoadModel = false;
            ModelIsLoading = false;
            ModelIsLoaded = true;

            if (mCurrentVisible == true)
            {
                VisibleModel();
            }
            else
            {
                InVisibleModel();
            }
        }

        /// <summary>
        /// 从prefab创建角色（怪物等），不涉及换装逻辑
        /// </summary>
        /// <returns>The model from prefab.</returns>
        public IEnumerator CreateModelFromPrefab(string prefab, Vector3 pos, Quaternion rot, Vector3 scale, Action<Actor> cbResLoaded)
        {
            ModelIsLoading = true;

            //先创建一个空GameObject
            InitEmptyModel(pos, rot, scale);

            GameObject go = null;
            bool isDummyObject = false;
            if (string.IsNullOrEmpty(prefab))
            {
                go = new GameObject();
                isDummyObject = true;
            }
            else
            {
                ModelPrefab = prefab;
            }

            while (IsLoading(false))
            {
                yield return new WaitForEndOfFrame();
            }
            yield return null;

            // 异步加载时，可能角色已经被销毁了
            if (mOwner == null || mOwner.IsDestroy)
            {
                //FIXME
                DestroyModel();
                mIsProcessingModel = false;
                yield break;
            }

            if (mModel != null)
            {
                if (mIsFirstLoadModel == true)
                {
                    if (isDummyObject)// 如果prefab为空，需要先调用一次AfterCreate来进行初始化，以防止异常
                        mOwner.AfterCreate();

                    mOwner.OnResLoaded();
                }
                if (cbResLoaded != null)
                {
                    cbResLoaded.Invoke(mOwner);
                }

                if (mIsFirstLoadModel == true)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_RES_LOADED, new CEventActorArgs(mOwner));
                }
            }

            mIsFirstLoadModel = false;
            ModelIsLoading = false;
            ModelIsLoaded = true;

            if (mCurrentVisible == true)
            {
                VisibleModel();
            }
            else
            {
                InVisibleModel();
            }
        }


        //设置模型prefab的名字
        public string ModelPrefab
        {
            set
            {
                mDirtyProperty = null;
                mDirtyPrefabName = value;
            }
        }

        public Vector3 ModelScale
        {
            set
            {
                if (mModelParent != null)
                {
                    mModelParent.transform.localScale = value;
                }
            }
            get
            {
                if (mModelParent != null)
                {
                    return mModelParent.transform.localScale;
                }
                return Vector3.one;
            }
        }

        //设置换装属性
        AvatarProperty AvatarDirtyProperty
        {
            set
            {
                mDirtyProperty = value;
                mDirtyPrefabName = null;
            }
        }

        //you should never call this function!
        public IEnumerator LoadAsync_public()
        {
            return LoadAvatarAsync();
        }

        /// <summary>
        /// 根据模型列表和时装列表来设置换装属性
        /// </summary>
        /// <param name="equip_modle_ids">装备id列表</param>
        /// <param name="fashions">时装id列表</param>
        /// <param name="suit_effect_ids">套装特效id列表</param>
        public void SetAvatarProperty(List<uint> equip_modle_ids, List<uint> fashions, List<uint> suit_effect_ids, Actor.EVocationType vocation, bool change_rider_first = true)
        {
            if (mOwner == null)
            {
                GameDebug.LogError("[SetAvatarProperty]Owner is null");
                return;
            }

            if (change_rider_first && mOwner.mRideCtrl != null && mOwner.mRideCtrl.Rider != null)
            {
                mOwner.mRideCtrl.Rider.mAvatarCtrl.SetAvatarProperty(equip_modle_ids, fashions, suit_effect_ids, vocation, false);
                return;
            }

            if (mNoShowParts != null)
            {
                List<uint> copy_equip_modle_ids = new List<uint>();
                List<uint> copy_fashions = new List<uint>();
                if (equip_modle_ids != null)
                    copy_equip_modle_ids.AddRange(equip_modle_ids);
                if (fashions != null)
                    copy_fashions.AddRange(fashions);
                for (int index = 0; index < mNoShowParts.Count; ++index)
                {
                    Equip.EquipHelper.DelEquipPart(copy_equip_modle_ids, mNoShowParts[index]);
                    Equip.EquipHelper.DelEquipPart(copy_fashions, mNoShowParts[index]);
                }
                equip_modle_ids = copy_equip_modle_ids;
                fashions = copy_fashions;
            }

            // 检查职业信息
            if (!DBManager.GetInstance().GetDB<DBAvatarDefault>().mData.ContainsKey(vocation))
            {
                Debug.LogError(string.Format("[AvatarCtrl][SetAvatarProperty]not found vocation {0}, use default instead", vocation));
                vocation = Actor.EVocationType.ROLE1;
            }

            AvatarDirtyProperty = new AvatarProperty();

            // ----获取时装id
            uint fashion_body_id = 0;
            uint fashion_weapon_id = 0;
            uint fashion_wing_id = 0;
            uint fashion_magical_pet = 0;
            uint fashion_footprint = 0;
            uint fashion_bubble = 0;
            uint fashion_photoframe = 0;
            uint light_weapon_id = 0;
            uint back_attachment_id = 0;
            if (fashions != null)
            {
                foreach (uint fashion in fashions)
                {
                    if (fashion == 0)
                        continue;

                    if (!DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(fashion))
                    {
                        GameDebug.LogError("[SetAvatarProperty] cannot find fashion info: id:" + fashion);
                        continue;
                    }

                    var item = DBManager.Instance.GetDB<DBAvatarPart>().mData[fashion];

                    if(item.vocation != 0 && item.vocation != vocation)
                        continue;

                    if (item.part == DBAvatarPart.BODY_PART.WING)
                    {
                        fashion_wing_id = QualitySetting.CheckAvatarCapacity(mOwner, item.part, fashion);
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.WEAPON)
                    {
                        fashion_weapon_id = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.BODY)
                    {
                        fashion_body_id = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.MAGICAL_PET)
                    {
                        fashion_magical_pet = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.FOOTPRINT)
                    {
                        fashion_footprint = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.BUBBLE)
                    {
                        fashion_bubble = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.PHOTO_FRAME)
                    {
                        fashion_photoframe = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.LIGHT_WEAPON)
                    {
                        light_weapon_id = fashion;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.BACK_ATTACHMENT)
                        back_attachment_id = fashion;
                }
            }

            mDirtyProperty.FashionBodyId = fashion_body_id;
            mDirtyProperty.FashionWeaponId = fashion_weapon_id;
            mDirtyProperty.FashionWingId = fashion_wing_id;
            mDirtyProperty.FashionMagicalPetId = fashion_magical_pet;
            mDirtyProperty.FashionFootprintId = fashion_footprint;
            mDirtyProperty.FashionBubbleId = fashion_bubble;
            mDirtyProperty.FashionPhotoFrameId = fashion_photoframe;
            mDirtyProperty.LightWeaponId = light_weapon_id;
            mDirtyProperty.BackAttachmentID = back_attachment_id;

            // ----获取装备id
            uint body_id = 0;
            uint weapon_id = 0;
            GetBodyWeaponId(equip_modle_ids, vocation, out body_id, out weapon_id);// 获取可用的换装装备
            mDirtyProperty.EquipBodyId = body_id;
            mDirtyProperty.EquipWeaponId = weapon_id;

            uint fashion_elfin_id = 0;
            GetAvatarPartId(equip_modle_ids, DBAvatarPart.BODY_PART.ELFIN, out fashion_elfin_id);
            mDirtyProperty.ElfinId = fashion_elfin_id;
            // 有时装时，BodyId与FashionBodyId相同，如果没有时装，则与EquipBodyId相同
            if (fashion_body_id != 0 && ActorUtils.Instance.HasExistResourceAvatarPartId(fashion_body_id))
            {
                body_id = fashion_body_id;
            }

            // weapon_id 取值优先级： LightWeaponId > FashionWingId > EquipWeaponId 
            if (light_weapon_id != 0 && ActorUtils.Instance.HasExistResourceAvatarPartId(light_weapon_id))
            {
                weapon_id = light_weapon_id;
            }
            else if (fashion_weapon_id != 0 && ActorUtils.Instance.HasExistResourceAvatarPartId(fashion_weapon_id))
            {
                weapon_id = fashion_weapon_id;
            }
            mDirtyProperty.BodyId = body_id;
            mDirtyProperty.WeaponId = weapon_id;

            //-- 获取套装特效id
            if (suit_effect_ids != null)
            {
                mDirtyProperty.SuitEffectIds = new List<uint>(suit_effect_ids);
            }

            mDirtyProperty.Vocation = vocation;

            // 在变身状态下，设置mLastProperty
            if(IsShapeShift)
            {
                m_LastProperty = mDirtyProperty;
                mDirtyProperty = null;
            }
        }

        /// <summary>
        /// 根据模型列表和时装列表来设置换装属性
        /// SetAvatarProperty()的精简接口
        /// </summary>
        public void SetAvatarProperty(AvatarProperty ap, Actor.EVocationType vocation, bool change_rider_first = true)
        {
            if (ap == null)
            {
                SetAvatarProperty(null, null, null, vocation, change_rider_first);
                return;
            }

            List<uint> suit_effect_ids = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
            SetAvatarProperty(ap.GetEquipModleIds(), ap.GetFashionModleIds(), suit_effect_ids, vocation, change_rider_first);
        }

        //------------------- 换装接口 start ------------------------------------------------------------------------------------------------------------------------------------------------

        public void CloneAvatar(Actor clonedActor, bool changeRiderFirst = true)
        {
            AvatarProperty ap = clonedActor.mAvatarCtrl.GetAvatartProperty();
            if (ap != null)
            {
                //List<uint> suit_effect_ids = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
                //SetAvatarProperty(new List<uint> { ap.EquipBodyId, ap.EquipWeaponId, ap.ElfinId }, new List<uint> { ap.FashionBodyId, ap.FashionWeaponId, ap.FashionWingId }, suit_effect_ids, clonedActor.VocationID, changeRiderFirst);

                ap = ap.Clone();
                SetAvatarProperty(ap, clonedActor.VocationID, changeRiderFirst);
            }
            else
            {
                SetAvatarProperty(null, null, null, clonedActor.VocationID, changeRiderFirst);
            }
        }

        /// <summary>
        /// 更换某一部位的装备
        /// </summary>
        /// <param name="part"></param>
        /// <param name="quip_model_id"></param>
        /// <param name="vocation"></param>
        public void ChangeEquipPart(DBAvatarPart.BODY_PART part, uint quip_model_id, Actor.EVocationType vocation)
        {
            AvatarProperty ap = GetAvatartProperty();
            if (ap == null)
            {
                Debug.LogError("ChangeEquipPart: 获取换装属性失败!!!");
                return;
            }

            //List<uint> model_list = new List<uint>();
            //if (part != DBAvatarPart.BODY_PART.BODY)
            //    model_list.Add(ap.BodyId);

            //if (part != DBAvatarPart.BODY_PART.WEAPON)
            //    model_list.Add(ap.WeaponId);

            //if(part != DBAvatarPart.BODY_PART.ELFIN)
            //    model_list.Add(ap.ElfinId);

            //model_list.Add(quip_model_id);
            //List<uint> suit_effect_ids = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
            //SetAvatarProperty(model_list, new List<uint> { ap.FashionBodyId, ap.FashionWeaponId, ap.FashionWingId },suit_effect_ids, vocation);

            ap = ap.Clone();
            ap.SetEquipPart(part, quip_model_id);
            SetAvatarProperty(ap, vocation);
        }

        /// <summary>
        /// 根据模型列表和时装列表来进行换装
        /// </summary>
        /// <param name="equipModleIds"></param>
        /// <param name="fashionIds"></param>
        /// <param name="vocation"></param>
        public void ChangeFacade(List<uint> equipModleIds, List<uint> fashionIds, List<uint> suit_effests, Actor.EVocationType vocation)
        {
            if (equipModleIds == null || fashionIds == null)
            {
                AvatarProperty ap = GetAvatartProperty();
                if (ap == null)
                {
                    Debug.LogError("ChangeEquipPart: 获取换装属性失败!!!");
                    return;
                }

                if (equipModleIds == null)
                {
                    equipModleIds = ap.GetEquipModleIds();
                }

                if (fashionIds == null)
                {
                    fashionIds = ap.GetFashionModleIds();
                }
            }

            SetAvatarProperty(equipModleIds, fashionIds, suit_effests, vocation);
        }

        //public void ChangeFashion(uint fashionBodyId, uint fashionweaponId, uint wingId, Actor.EVocationType vocation)
        //{
        //    AvatarProperty ap = GetAvatartProperty();
        //    if(ap == null)
        //    {
        //        Debug.LogError("ChangeFashion: 获取换装属性失败!!!");
        //        return;
        //    }
        //    List<uint> suit_effect_ids = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
        //    SetAvatarProperty(new List<uint>{ap.EquipBodyId, ap.EquipWeaponId }, new List<uint> { fashionBodyId, fashionweaponId, wingId }, suit_effect_ids, vocation);
        //}

        /// <summary>
        /// 更换时装武器(用在特殊武器的更换机制上)
        /// </summary>
        /// <param name="weaponId"></param>
        //public void ChangeFahionWeapon(uint weaponId)
        //{
        //    AvatarProperty ap = GetAvatartProperty();
        //    if (ap == null)
        //    {
        //        Debug.LogError("ChangeFahionWeapon: 获取换装属性失败!!!");
        //        return;
        //    }
        //    List<uint> suit_effect_ids = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
        //    SetAvatarProperty(new List<uint>{ap.EquipBodyId, ap.EquipWeaponId, ap.ElfinId }, new List<uint> { ap.FashionBodyId, weaponId, ap.FashionWingId } , suit_effect_ids, mOwner.VocationID);
        //}

        public void ChangeFashionPart(DBAvatarPart.BODY_PART part, uint dressId, Actor.EVocationType vocation)
        {
            AvatarProperty ap = GetAvatartProperty();
            if (ap == null)
            {
                Debug.LogError("ChangeFahionWeapon: 获取换装属性失败!!!");
                return;
            }
            ap = ap.Clone();
            ap.SetFashionPart(part, dressId);
            SetAvatarProperty(ap, vocation);
        }

        //---------------------- 换装接口 end ---------------------------------------------------------------------------------------------------------------------------------------------

        //recycle avatar
        private void RecycleDynamicAvatar()
        {
            if (mModel == null)
            {
                return;
            }
           
            if (mCurrentProperty.BodyId == 0 && mCurrentProperty.WeaponId == 0)
            {
                Debug.LogError(string.Format("recylce an gameobject{0}  error", mOwner.UID.obj_idx));
                GameObject.Destroy(mModel);
                return;
            }
            string newKey = string.Format("avatar_{0}_{1}", mCurrentProperty.BodyId, mCurrentProperty.WeaponId);
            PoolGameObject pg = mModel.GetComponent<PoolGameObject>();
            if (pg == null)
            {
                GameDebug.LogError("Can not find PoolGameObject in " + mModel.name);
                return;
            }
            if (pg.key != newKey)
            {
                ObjCachePoolMgr.Instance.RemoveFromCachePool(ObjCachePoolType.ACTOR, pg.key, mModel);
            }
            pg.key = newKey;
            ObjCachePoolMgr.Instance.RecyclePrefab(mModel, ObjCachePoolType.ACTOR, pg.key);
        }

        private IEnumerator SetWing(uint id)
        {
            if (id == 0)
            {
                RemoveWing();
                yield break;
            }

            RemoveWing();
            if (!DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(id))
            {
                Debug.LogError(string.Format("ride id {0} not found", id));
                yield break;
            }
            if (mModel == null)
            {
                yield break;
            }
            bool is_local_player = IsLocalPlayerModel();
            string respath = DBManager.Instance.GetDB<DBAvatarPart>().mData[id].SuitablePath(is_local_player);
            Transform wingMout = CommonTool.FindChildInHierarchy(mModel.transform, MOUNT_POINT_WING);
            if (wingMout == null)
            {
                Debug.LogError(string.Format("not found wing mount point on {0}", mModel.name));
                yield break;
            }
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(respath, ObjCachePoolType.ACTOR, respath, ow));
            GameObject winggo = ow.obj as GameObject;
            if (winggo == null)
            {
                yield break;
            }

            GameObject.DontDestroyOnLoad(winggo);
            if (mIsDestroy)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(winggo, ObjCachePoolType.ACTOR, respath);
                yield break;
            }

            var winTrans = winggo.transform;
            winTrans.parent = wingMout;
            winTrans.localPosition = Vector3.zero;
            winTrans.localEulerAngles = Vector3.zero;
            var scaleInfo = winggo.GetComponent<ScaleInfo>();
            if (scaleInfo != null)
                winTrans.localScale = scaleInfo.Scale;
            else
                winTrans.localScale = Vector3.one;

            int layer = 0;
            if (mModelParent != null)
                layer = mModelParent.layer;
            SetRenderLayer(winggo, layer, true);
            SetGameObjectVisible(winggo, mCurrentVisible);
            m_WingObjs[respath] = winggo;

            // 确保MaterialEffectCtrl那边获取的材质包括翅膀的材质，这里要fire这个事件
            if (mOwner != null)
                mOwner.FireActorEvent(Actor.ActorEvent.AVATAR_CHANGE, null);
        }

        private IEnumerator SetBackAttachment(uint id)
        {
            RemoveBackAttachment();
            if (id == 0)
            {
                yield break;
            }

            if (!DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(id))
            {
                Debug.LogError(string.Format("BackAttachment id {0} not found", id));
                yield break;
            }
            if (mModel == null)
                yield break;
            
            bool is_local_player = IsLocalPlayerModel();
            string respath = DBManager.Instance.GetDB<DBAvatarPart>().mData[id].SuitablePath(is_local_player);
            Transform backAttachmentMount = CommonTool.FindChildInHierarchy(mModel.transform, BACK_ATTACHMENT_LINK);
            if (backAttachmentMount == null)
            {
                Debug.LogError(string.Format("not found back attachment mount point on {0}", mModel.name));
                yield break;
            }
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(respath, ObjCachePoolType.ACTOR, respath, ow));
            GameObject backGO = ow.obj as GameObject;
            if (backGO == null)
                yield break;

            GameObject.DontDestroyOnLoad(backGO);
            if (mIsDestroy)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(backGO, ObjCachePoolType.ACTOR, respath);
                yield break;
            }

            var t = backGO.transform;
            t.parent = backAttachmentMount;
            t.localPosition = Vector3.zero;
            t.localEulerAngles = Vector3.zero;
            var scaleInfo = backGO.GetComponent<ScaleInfo>();
            if (scaleInfo != null)
                t.localScale = scaleInfo.Scale;
            else
                t.localScale = Vector3.one;

            int layer = 0;
            if (mModelParent != null)
                layer = mModelParent.layer;
            SetRenderLayer(backGO, layer, true);
            SetGameObjectVisible(backGO, mCurrentVisible);
            m_BackAttachments[respath] = backGO;

            // 确保MaterialEffectCtrl那边获取的材质包括翅膀的材质，这里要fire这个事件
            if (mOwner != null)
                mOwner.FireActorEvent(Actor.ActorEvent.AVATAR_CHANGE, null);
        }

        public bool IsLocalPlayerModel()
        {
            bool is_local_player = false;
            if (mOwner != null && mOwner.IsClientModel())
            {
                if (!Game.Instance.IsEnterGame) // 在进入游戏之前
                    is_local_player = true;
                else
                {
                    ClientModel client_model = mOwner as ClientModel;
                    if (client_model != null)
                    {
                        is_local_player = client_model.RawUID.Equals(Game.Instance.LocalPlayerID.obj_idx);
                    }
                    if (mOwner.IsUIModel())
                        is_local_player = true;
                }
            }
            else
                is_local_player = mOwner != null ? mOwner.IsLocalPlayer : false;
            return is_local_player;
        }
        private void RemoveWing()
        {
            foreach (var obj in m_WingObjs)
            {
                if (obj.Value != null)
                {
                    //SetGameObjectVisible(obj.Value, true);
                    ObjCachePoolMgr.Instance.RecyclePrefab(obj.Value, ObjCachePoolType.ACTOR, obj.Key);
                }
            }

            m_WingObjs.Clear();
        }

        void RemoveBackAttachment ()
        {
            foreach (var obj in m_BackAttachments)
            {
                if (obj.Value != null)
                    ObjCachePoolMgr.Instance.RecyclePrefab(obj.Value, ObjCachePoolType.ACTOR, obj.Key);
            }
            m_BackAttachments.Clear();
        }

        GameObject mElfinObject = null;
        string mElfinResPath = "";
        GameObject mMagicalPetObject = null;
        string mMagicalPetResPath = "";
        bool IsUIModel()
        {
            if (mOwner == null || mOwner.IsDestroy)
                return false;
            if (mOwner.IsClientModel() == false)
                return false;
            else
            {
                if ((mOwner as ClientModel).IsRidePlayer)
                    return false;
            }
            return true;
        }
        void ResetElfinPos()
        {
            if (mElfinObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            GameObject spirit_obj = ui.ugui.UIHelper.FindChild(mModelParent, SPIRIT_LINK_NAME);
            if (spirit_obj != null)
                mElfinObject.transform.position = spirit_obj.transform.position;
            else
            {
                mElfinObject.transform.localPosition = mModelParent.transform.localPosition - mModelParent.transform.right * 0.8f + mModelParent.transform.up * 0.2f;
            }
        }

        void ResetMagicalPetPos()
        {
            if (mMagicalPetObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            GameObject spirit_obj = ui.ugui.UIHelper.FindChild(mModelParent, MAGICAL_PET_LINK_NAME);
            if (spirit_obj != null)
                mMagicalPetObject.transform.position = spirit_obj.transform.position;
            else
            {
                mMagicalPetObject.transform.localPosition = mModelParent.transform.localPosition - mModelParent.transform.right * 0.8f + mModelParent.transform.up * 0.2f;
            }
        }
        private IEnumerator SetElfin(uint id)
        {

            RemoveElfin();
            if (id == 0)
            {
                yield break;
            }

            DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
            if (instanceInfo != null && DBInstanceTypeControl.Instance.ForbidElfin(instanceInfo.mWarType, instanceInfo.mWarSubType))
            {
                yield break;
            }

            //             if (mOwner != null && mOwner.IsPlayer() == false && mOwner.IsLocalPlayer == false)
            //             {//场景上普通玩家(不上坐骑)不显示小精灵
            //                 yield break;
            //             }
            if (mOwner != null && IsUIModel() == false && IsLocalPlayerModel() == false)
            {//场景上普通玩家(上坐骑)不显示小精灵
                yield break;
            }

            //             if (mOwner != null && mOwner.IsPlayer() == false && mOwner.IsClientModel() == false)
            //             {//只有主角和UI才可以显示小精灵
            //                 yield break;
            //             }
            if (!DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(id))
            {
                Debug.LogError(string.Format("ride id {0} not found", id));
                yield break;
            }
            if (mModelParent == null)
                yield break;
            bool is_local_player_model = IsLocalPlayerModel();
            string respath = DBManager.Instance.GetDB<DBAvatarPart>().mData[id].SuitablePath(is_local_player_model); //path;
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(respath, ObjCachePoolType.ACTOR, respath, ow));
            GameObject winggo = ow.obj as GameObject;
            if (winggo == null)
            {
                yield break;
            }

            GameObject.DontDestroyOnLoad(winggo);
            mElfinObject = winggo;
            mElfinResPath = respath;
            if (mIsDestroy)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(winggo, ObjCachePoolType.ACTOR, respath);
                yield break;
            }

            ResetElfinObject();
            int layer = 0;
            if (mModelParent != null)
                layer = mModelParent.layer;
            SetRenderLayer(winggo, layer, false, false);
            SetGameObjectVisible(winggo, mCurrentVisible);
            AvatarProperty ap = GetAvatartProperty_onlySelf();
            if (ap != null)
            {
                /*                ap.ElfinId = id;*/
                ap.ElfinResPath = respath;
            }
        }

        private void RemoveElfin()
        {
            if (mElfinObject == null)
            {
                return;
            }
            //SetGameObjectVisible(mElfinObject, true);
            ObjCachePoolMgr.Instance.RecyclePrefab(mElfinObject, ObjCachePoolType.ACTOR, mElfinResPath);
            mElfinObject = null;
            //             AvatarProperty ap = GetAvatartProperty_onlySelf();
            //             if (ap != null)
            //             {
            //                 ap.ElfinId = 0;
            //                 ap.ElfinResPath = "";
            //             }
        }

        private IEnumerator SetMagicalPet(uint id)
        {
            RemoveMagicalPet();
            if (id == 0)
            {
                yield break;
            }
            DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
            if (instanceInfo != null && DBInstanceTypeControl.Instance.ForbidMagicPet(instanceInfo.mWarType, instanceInfo.mWarSubType))
            {
                yield break;
            }

            if (mOwner != null && mOwner.IsPlayer() == false && mOwner.IsClientModel() == false)
            {//只有玩家和UI才可以显示
                yield break;
            }
            if (!DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(id))
            {
                Debug.LogError(string.Format("magical pet id {0} not found", id));
                yield break;
            }
            if (mModelParent == null)
                yield break;
            bool is_local_player_model = IsLocalPlayerModel();
            string respath = DBManager.Instance.GetDB<DBAvatarPart>().mData[id].SuitablePath(is_local_player_model); //path;
            ObjectWrapper ow = new ObjectWrapper();
            yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(respath, ObjCachePoolType.ACTOR, respath, ow));
            GameObject winggo = ow.obj as GameObject;
            if (winggo == null)
            {
                yield break;
            }

            GameObject.DontDestroyOnLoad(winggo);
            if (mIsDestroy)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(winggo, ObjCachePoolType.ACTOR, respath);
                yield break;
            }

            mMagicalPetObject = winggo;
            mMagicalPetResPath = respath;
            ResetMagicalPetObject();
            int layer = 0;
            if (mModelParent != null)
                layer = mModelParent.layer;
            SetRenderLayer(winggo, layer, false, false);
            SetGameObjectVisible(winggo, mCurrentVisible);
            AvatarProperty ap = GetAvatartProperty_onlySelf();
            if (ap != null)
            {
                ap.MagicalPetResPath = respath;
            }
        }

        private void RemoveMagicalPet()
        {
            if (mMagicalPetObject == null)
            {
                return;
            }
            //SetGameObjectVisible(mMagicalPetObject, true);
            ObjCachePoolMgr.Instance.RecyclePrefab(mMagicalPetObject, ObjCachePoolType.ACTOR, mMagicalPetResPath);
            mMagicalPetObject = null;
        }

        private void GetAvatarPartId(List<uint> modleIds, DBAvatarPart.BODY_PART body_part, out uint part_id)
        {
            part_id = 0;

            if (modleIds == null)
            {
                return;
            }

            DBAvatarPart dbAvatarPart = DBManager.GetInstance().GetDB<DBAvatarPart>();

            DBAvatarPart.Data item;
            foreach (uint fashion in modleIds)
            {
                if (fashion == 0)
                    continue;

                if (dbAvatarPart.mData.TryGetValue(fashion, out item) == false)
                    continue;

                if (item != null && item.part == body_part)
                {
                    part_id = fashion;
                }
            }
        }
        /// <summary>
        /// 从模型列表中获取可用的装备id和武器id
        /// </summary>
        /// <param name="modleIds">模型id列表</param>
        /// <param name="vocation">玩家的职业</param>
        /// <param name="bodyId">获取的装备id</param>
        /// <param name="weaponId">获取的武器id</param>
        private void GetBodyWeaponId(List<uint> modleIds, Actor.EVocationType vocation, out uint bodyId, out uint weaponId)
        {
            // 获取默认的装备id
            DBAvatarDefault.Data vocationDefault = DBManager.GetInstance().GetDB<DBAvatarDefault>().mData[vocation];
            bodyId = vocationDefault.bodyId;
            weaponId = vocationDefault.weaponId;

            if (modleIds == null)
            {
                return;
            }

            foreach (uint id in modleIds)
            {
                var data = DBManager.GetInstance().GetDB<DBAvatarPart>().mData;
                if (data.ContainsKey(id))
                {
                    var item = data[id];
                    if (item.vocation != 0 && item.vocation != vocation)// 如果职业类型不匹配，则直接返回
                    {
                        Debug.LogError(string.Format("modle id {0} does not match the vocation {1}, use default instead", id, vocation));
                        continue;
                    }
                    if (item.part == DBAvatarPart.BODY_PART.BODY)
                    {
                        bodyId = id;
                    }
                    else if (item.part == DBAvatarPart.BODY_PART.WEAPON)
                    {
                        weaponId = id;
                    }
                }
            }
        }

        /// <summary>
        /// 更换身体部件
        /// partId 对应换装表中的ID，可以是身体和武器部件
        /// </summary>
        private IEnumerator ChangePart(uint partId)
        {
            if(mModel == null)
            {
                yield break;
            }

            // 从表格中获取换装部件的类型
            DBAvatarPart.Data data = DBManager.Instance.GetDB<DBAvatarPart>().mData[partId];
            string part_name = data.part == DBAvatarPart.BODY_PART.BODY ? BODY_NAME : WEAPON_NAME;

            // 查找旧资源中的换装节点
            Transform old_part = CommonTool.FindChildInHierarchy(mModel.transform, part_name);
            if (old_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", mModel.name, part_name));
                yield break;
            }
            bool is_local_player = IsLocalPlayerModel();
            string path = data.SuitablePath(is_local_player);
            // 加载换装部件的模型
            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(string.Format("{0}/{1}.prefab", AVATAR_PATH_PREFIX, path), typeof(GameObject), ar));
            GameObject gameObjectAsset = ar.asset_ as GameObject;
            if (gameObjectAsset == null)
            {
                Debug.LogError(string.Format("the res {0} does not exist", path));
                yield break;
            }

            if (mIsDestroy || mModel == null)
            {
                ar.destroy();
                yield break;
            }

            old_part = CommonTool.FindChildInHierarchy(mModel.transform, part_name);
            if (old_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", mModel.name, part_name));
                ar.destroy();
                yield break;
            }

            // 将asset资源的生命周期与角色GameObject关联起来
            ResourceUtilEx.Instance.host_res_to_gameobj(mModel, ar);

            // 查找新资源的换装节点
            Transform new_part = CommonTool.FindChildInHierarchy(gameObjectAsset.transform, part_name);
            if (new_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", gameObjectAsset.name, part_name));
                yield break;
            }

            SkinnedMeshRenderer new_mesh_renderer = new_part.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer old_mesh_renderer = old_part.GetComponent<SkinnedMeshRenderer>();
            mOwner.FireActorEvent(Actor.ActorEvent.AVATAR_CHANGE_BEGIN, null);
            Transform[] old_bones = (Transform[])old_part.GetComponent<SkinnedMeshRenderer>().bones.Clone();
            ReplaceSkinnedMesh(old_bones, mModel, old_mesh_renderer, new_mesh_renderer);

            //更新Model的内存池参数
            var pg = mModel.GetComponent<PoolGameObject>();
            if (pg != null)
            {
                var key = pg.key;
                if (string.IsNullOrEmpty(key))
                {
                    GameDebug.LogError("PoolGameObject key is null");
                }
                else
                {
                    var is_body_id = data.part == DBAvatarPart.BODY_PART.BODY;
                    uint body_id = 0;
                    uint weapon_id = 0;
                    bool start_num_parse = false;
                    uint cur_num = 0;
                    uint num_index = 0;
                    for (int i = 0; i < key.Length; ++i)
                    {
                        var ch = key[i];
                        // 开始数字解析
                        if (ch >= '0' && ch <= '9')
                        {
                            start_num_parse = true;
                            uint n = (uint)(ch - '0');
                            cur_num = cur_num * 10 + n;
                        }
                        else
                        {
                            // 完成数字解析
                            if (start_num_parse)
                            {
                                start_num_parse = false;
                                if (num_index == 0)
                                {
                                    num_index++;
                                    body_id = cur_num;
                                    cur_num = 0;
                                }
                                else
                                {
                                    weapon_id = cur_num;
                                    cur_num = 0;
                                    break;
                                }
                            }
                        }
                    }
                    if (is_body_id)
                    {
                        if (partId != body_id)
                        {
                            key = string.Format("avatar_{0}_{1}", partId, weapon_id);
                            pg.key = key;
                        }
                    }
                    else
                    {
                        if (partId != weapon_id)
                        {
                            key = string.Format("avatar_{0}_{1}", body_id, partId);
                            pg.key = key;
                        }
                    }
                }
            }
            else
                GameDebug.LogError("PoolGameObject is null");

            mOwner.FireActorEvent(Actor.ActorEvent.AVATAR_CHANGE, null);
        }

        /// <summary>
        /// 设置套装特效
        /// </summary>
        /// <param name="effect_id_list"></param>
        /// <returns></returns>
        IEnumerator SetSuitEffect(List<uint> effect_id_list)
        {
            if (effect_id_list == null || effect_id_list.Count == 0)
                yield break;


            effect_id_list = effect_id_list.Distinct().ToList();

            // 屏蔽特效显示
            /*if (!EnableEffect)
            {
                if (mOwner == null || !mOwner.UID.Equals(Game.GetInstance().LocalPlayerID))
                    yield return null;
            }*/

            //var avartaPartData = DBManager.GetInstance().GetDB<DBAvatarPart>().mData;

            foreach (var id in effect_id_list)
            {
                if(mCurrentProperty == null)
                    yield break;

                var effect_id = id;
                if (id == 1 || id == 2)
                {
                    effect_id = id == 1 ? mCurrentProperty.BodyId : mCurrentProperty.WeaponId;
                }

                var effect_info = DBManager.Instance.GetDB<DBSuitEffect>().GetEffectInfo(effect_id);
                if (effect_info == null)
                {
                    GameDebug.Log("Cannot find suit effect info, id: " + effect_id);
                    continue;
                }

                // 检查特效id是否与当前的装备或武器匹配
                if (effect_info.effect_type == 1)
                {
                    if (effect_id != mCurrentProperty.BodyId)
                        continue;
                }
                else if (effect_info.effect_type == 2)
                {
                    if (effect_id != mCurrentProperty.WeaponId)
                        continue;
                }

                bool is_local_player_model = this.IsLocalPlayerModel();
                foreach (var bind_info in effect_info.bind_infos)
                {
                    // 本地玩家才使用高配的特效
                    string res_path = "";

                    if (is_local_player_model)// 本地玩家
                    {
                        if (QualitySetting.GraphicLevel == 2) // 低配也使用低配特效
                        {
                            res_path = ModelHelper.GetModelPrefab(bind_info.low_model_id);
                        }
                        else
                        {
                            if(Owner.IsUIModel())
                            {
                                res_path = ModelHelper.GetModelPrefab(bind_info.ui_model_id);
                            }
                            else
                            {
                                res_path = ModelHelper.GetModelPrefab(bind_info.model_id);
                            }
                        }
                    }
                    else// 其他玩家
                        res_path = ModelHelper.GetModelPrefab(bind_info.low_model_id);

                    if (string.IsNullOrEmpty(res_path))
                    {
                        GameDebug.LogError("Cannot find suit res info, model_id: " + bind_info.model_id);
                        continue;
                    }

                    var mount_point = CommonTool.FindChildInHierarchy(mOwner.transform, bind_info.bind_node);
                    if (mount_point == null)
                    {
                        GameDebug.LogError("Cannot find suit mount point, bind_node: " + bind_info.bind_node);
                        continue;
                    }

                    ObjectWrapper ow = new ObjectWrapper();
                    yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(res_path, ObjCachePoolType.SFX, res_path, ow));
                    GameObject effect_object = ow.obj as GameObject;

                    if (effect_object == null)
                    {
                        GameDebug.LogError("Cannot load suit effect point, res_path: " + res_path);
                        continue;
                    }

                    effect_object.SetActive(true);
                    GameObject.DontDestroyOnLoad(effect_object);
                    if (mIsDestroy)
                    {
                        ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, res_path);
                        break;
                    }

                    int layer = 0;
                    if (mModelParent != null)
                        layer = mModelParent.layer;
                    SetRenderLayer(effect_object, layer, false, false);

                    List<GameObject> list;
                    if(!m_EffectObjs.TryGetValue(res_path, out list))
                    {
                        list = new List<GameObject>();
                        m_EffectObjs.Add(res_path, list);
                    }
                    list.Add(effect_object);

                    var trans = effect_object.transform;
                    trans.parent = mount_point;
                    trans.localPosition = Vector3.zero;
                    trans.localRotation = Quaternion.identity;
                    trans.localScale = Vector3.one;

                    ListTrailRenderer trail_render_list = effect_object.GetComponent<ListTrailRenderer>();
                    if (trail_render_list == null)
                        trail_render_list = effect_object.AddComponent<ListTrailRenderer>();
                    if (trail_render_list != null)
                        trail_render_list.ResetPos();

                    // 设置层级
                    xc.ui.ugui.UIHelper.SetLayer(effect_object.transform, mOwner.GetModelLayer());
                }
            }
        }

        public void ResetSuitPos(bool is_wait_one_frame = true, uint delay_frame_count = 4)
        {
            if (mOwner == null || mOwner.IsDestroy)
                return;
            List<GameObject> list;
            foreach (var item in m_EffectObjs)
            {
                if (item.Value != null)
                {
                    list = item.Value;
                    foreach(var effect in list)
                    {
                        ListTrailRenderer trail_render_list = effect.GetComponent<ListTrailRenderer>();
                        if (trail_render_list != null)
                            trail_render_list.ResetPos();
                    }
                }
            }
            m_is_wait_one_frame = is_wait_one_frame;
            if (is_wait_one_frame)
                m_has_waited_frame = delay_frame_count;
            else
                m_has_waited_frame = 0;
        }

        //设置站立特效角度 用于调整ui视觉效果
        public void SetFootprintEulerAngles(Vector3 angle)
        {
            FootprintBehavior footprintBehavior = Owner.GetBehavior<FootprintBehavior>();
            footprintBehavior.SetStandEulerAngles(angle);
        }

        /// <summary>
        /// 移除套装特效
        /// </summary>
        public void RemoveSuitEffect()
        {
            List<GameObject> list;
            foreach (var obj in m_EffectObjs)
            {
                if (obj.Value != null)
                {
                    list = obj.Value;
                    foreach(var item in list)
                    {
                        ObjCachePoolMgr.Instance.RecyclePrefab(item, ObjCachePoolType.SFX, obj.Key);
                    }
                    list.Clear();
                }
            }

            m_EffectObjs.Clear();
        }

        /// <summary>
        /// 替换换装部件的蒙皮信息
        /// old_bones : 换装骨骼信息
        /// model : 角色模型对应的GameObject
        /// old_mesh_renderer ： 旧的换装蒙皮网格
        /// new_mesh_renderer ： 新的换装蒙皮网格
        /// </summary>
        private static void ReplaceSkinnedMesh(Transform[] old_bones, GameObject model, SkinnedMeshRenderer old_mesh_renderer, SkinnedMeshRenderer new_mesh_renderer)
        {
            if (old_bones == null || old_mesh_renderer == null || new_mesh_renderer == null)
            {
                return;
            }

            //创建与new_mesh_renderer匹配的骨骼
            Transform[] new_mesh_bones = new_mesh_renderer.bones;
            Transform[] new_bones = new Transform[new_mesh_bones.Length];

            bool found = false;
            for (int i = 0; i < new_mesh_bones.Length; i++)
            {
                var new_bone = new_mesh_bones[i];
                if (new_bone == null)
                {
                    Debug.LogError("new_mesh_bones is invalid");
                    continue;
                }

                found = false;

                //在旧骨骼中查找与new_mesh_renderer中骨骼名字一致的transform
                foreach (Transform old_bone in old_bones)
                {
                    if (old_bone == null)
                    {
                        Debug.LogError("old_bones is invalid");
                        continue;
                    }

                    if (old_bone.name == new_bone.name)
                    {
                        new_bones[i] = old_bone;
                        found = true;
                        break;
                    }
                }

                //如果没找到，则在角色模型的子节点中寻找
                if (!found)
                {
                    Transform[] all = model.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in all)
                    {
                        if (t.name == new_mesh_bones[i].name)
                        {
                            new_bones[i] = t;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Debug.LogError(string.Format("old_bones do not have a bone named {0} when change skinned mesh,make sure they use the same bones, change from {1} to {2}", new_mesh_bones[i].name, old_mesh_renderer.transform.parent.name, new_mesh_renderer.transform.parent.name));
                        return;
                    }
                }
            }

            old_mesh_renderer.sharedMesh = new_mesh_renderer.sharedMesh;
            //TODO: 所有装备的骨骼信息一致时，可以直接使用旧的骨骼
            old_mesh_renderer.bones = new_bones;
            old_mesh_renderer.sharedMaterials = new_mesh_renderer.sharedMaterials;
        }

        /// <summary>
        /// 设置新的Actor模型和层级信息，并将旧的模型销毁
        /// </summary>
        private void SetModel(GameObject mewModel)
        {
            if (mewModel == null || mewModel == mModel)
            {
                return;
            }

            Transform newTrans = mewModel.transform;
            newTrans.parent = mModelParent.transform;
            newTrans.localPosition = Vector3.zero;
            newTrans.localRotation = Quaternion.identity;
            newTrans.localScale = Vector3.one;

            // FIXME 特效应该确定固定的挂点，然后将挂点下的所有子节点移动到新的Transform下
            // 在旧的GameObject生命周期内，有可能会添加buff特效到其transform下，因此需要把其子节点也移动到新模型下
            if (mModel != null && mModel.name == m_TmpActorName)
            {
                Transform oldTrans = mModel.transform;
                for (int i = 0; i < oldTrans.childCount; ++i)
                {
                    Transform childTrans = oldTrans.GetChild(i);
                    Vector3 localPos = childTrans.localPosition;
                    Quaternion localRot = childTrans.localRotation;
                    childTrans.parent = newTrans;
                    childTrans.localPosition = localPos;
                    childTrans.localRotation = localRot;
                }
            }

            // destroy old model
            DestroyModel();

            mModel = mewModel;
            mElfinLinkObj = ui.ugui.UIHelper.FindChild(mModel, SPIRIT_LINK_NAME);
            mMagicalPetLinkObj = ui.ugui.UIHelper.FindChild(mModel, MAGICAL_PET_LINK_NAME);
            //set layer
            //if (mModel != null)// && mModel.layer > 0) && mewModel.layer != mModel.layer)
            {
                SetLayer(-1);
            }

            mOwner.OnModelChanged();

            mOwner.FireActorEvent(Actor.ActorEvent.AVATAR_CHANGE, null);
        }

        /// <summary>
        /// 销毁模型
        /// </summary>
        private void DestroyModel()
        {
            RemoveWing();
            RemoveSuitEffect();
            RemoveElfin();
            RemoveMagicalPet();
            RemoveBackAttachment();

            if (mModel == null)
            {
                return;
            }

            // 销毁ShadowCull
            ShadowCull[] shadow_cull = mModel.GetComponentsInChildren<ShadowCull>(true);
            for (int i = 0; i < shadow_cull.Length; ++i)
            {
                GameObject.DestroyImmediate(shadow_cull[i]);
            }
            shadow_cull = null;

            if (mCurrentProperty != null)
            {
                RecycleDynamicAvatar();
                mCurrentProperty = null;
            }
            else if (m_LoadedPrefabName != null)
            {
                ObjCachePoolMgr.Instance.RecyclePrefab(mModel, ObjCachePoolType.ACTOR, m_LoadedPrefabName);
                m_LoadedPrefabName = null;
            }
            else
            {
                GameObject.DestroyObject(mModel);
            }
            mModel = null;
            mElfinLinkObj = null;
            mMagicalPetLinkObj = null;
            ModelIsLoaded = false;
        }

        string m_ParentName = "ActorParent";
        string m_TmpActorName = "Actor";
        GameObject mModelParent;

        /// <summary>
        /// 初始化时创建一个空的GameObject
        /// </summary>
        private void InitEmptyModel(Vector3 pos, Quaternion rot, Vector3 scale)
        {
            if (mModelParent != null)
                return;

            GameObject go_parent = new GameObject();
            mModelParent = go_parent;
            go_parent.name = m_ParentName;
            GameObject.DontDestroyOnLoad(go_parent);
            Transform tans = go_parent.transform;
            tans.position = pos;
            tans.rotation = rot;
            tans.localScale = scale;
            go_parent.layer = 0;

            // 没加载模型的时候也要可以点击
            var collider = go_parent.AddComponent<CapsuleCollider>();
            collider.radius = 0.66f;
            collider.height = 2.6f;
            collider.center = new Vector3(0, 1.3f, 0);
            collider.isTrigger = true;

            xc.ActorMono actMono = go_parent.AddComponent<xc.ActorMono>();
            actMono.BindActor = mOwner;

            InitEmptyModelImpl();
        }

        private void InitEmptyModelImpl()
        {
            GameObject go = new GameObject();
            go.name = m_TmpActorName;
            Transform child_tans = go.transform;
            child_tans.parent = GetModelParent().transform;
            child_tans.localPosition = Vector3.zero;
            child_tans.localRotation = Quaternion.identity;
            child_tans.localScale = new Vector3(-1, -1, -1);
            go.layer = 0;

            SetModel(go);
        }

        void PlayLastAnimation()
        {
            if (mOwner != null)
                mOwner.PlayLastAnimation();
        }

        /// <summary>
        /// 当需要进行换装时，进行相应的资源加载操作
        /// 在进行换装操作时，如果已经存在角色模型，则只加载部件进行更换
        //  在换装时会先从内存池中获取模型，因此在销毁模型的时候，需要使用RecycleDynamicAvatart方法将模型放回内存池中
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadAvatarAsync()
        {
            mIsProcessingModel = true;
            if (mDirtyPrefabName != null)//如果不涉及换装，直接从prefab加载
            {
                //load from objcache ,not changeable
                string path = mDirtyPrefabName;
                mDirtyPrefabName = null;

                ObjectWrapper ow = new ObjectWrapper();
                yield return ObjCachePoolMgr.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(path, ObjCachePoolType.ACTOR, path, ow));
                GameObject game_object = ow.obj as GameObject;
                if (game_object == null)
                {
                    mIsProcessingModel = false;
                    yield break;
                }

                GameObject.DontDestroyOnLoad(game_object);
                if (mIsDestroy)
                {
                    mIsProcessingModel = false;
                    ObjCachePoolMgr.Instance.RecyclePrefab(game_object, ObjCachePoolType.ACTOR, path);
                    yield break;
                }

                SetModel(ow.obj as GameObject);
                PlayLastAnimation();
                m_LoadedPrefabName = path;
                mCurrentProperty = null;
            }
            else
            {
                GameObject oldGameObject = mModel;
                if (mCurrentProperty == null)//如果mCurrentProperty为空，则表示之前没有进行过换装，mModel是就创建的临时GameObject
                {
                    oldGameObject = null;
                }

                //从mDirtyProperty中拷贝属性
                AvatarProperty ap = new AvatarProperty(mDirtyProperty);
                mDirtyProperty = null;
                var mData = DBManager.GetInstance().GetDB<DBAvatarDefault>().mData;
                DBAvatarDefault.Data defaultAvatar = null;
                mData.TryGetValue(ap.Vocation, out defaultAvatar);
                if (defaultAvatar == null)
                {
                    GameDebug.LogError("[DBAvatarDefault] can't find the vocation " + ap.Vocation);
                    mIsProcessingModel = false;
                    yield break;
                }
                // 旧的装备id
                uint oldBodyId = 0;
                uint oldWeaponId = 0;
                if (oldGameObject != null)
                {
                    oldBodyId = mCurrentProperty.BodyId;
                    oldWeaponId = mCurrentProperty.WeaponId;
                }
                bool is_change_body = false;
                if (ap.BodyId == oldBodyId && ap.WeaponId == oldWeaponId)//装备id相同时不需要处理
                {
                    //
                }
                else
                {
                    is_change_body = true;
                    var avartaPartData = DBManager.GetInstance().GetDB<DBAvatarPart>().mData;
                    if (oldGameObject == null)//如果之前没有进行过换装
                    {
                        string avatar_cache_path = string.Format("avatar_{0}_{1}", ap.BodyId, ap.WeaponId);
                        GameObject go = ObjCachePoolMgr.Instance.LoadFromCache(ObjCachePoolType.ACTOR, avatar_cache_path) as GameObject;
                        if (go != null)
                        {
                            Transform goPart = CommonTool.FindChildInHierarchy(go.transform, BODY_NAME);
                            if (goPart == null)
                            {
                                Debug.LogError(string.Format("model {0} do not have a part named suits, please check your resource!", go.name));
                                mIsProcessingModel = false;
                                yield break;
                            }
                            goPart.gameObject.SetActive(true);

                            goPart = CommonTool.FindChildInHierarchy(go.transform, WEAPON_NAME);
                            if (goPart != null)
                            {
                                goPart.gameObject.SetActive(true);
                            }

                            go.SetActive(true);

                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                ObjCachePoolMgr.Instance.RecyclePrefab(go, ObjCachePoolType.ACTOR, avatar_cache_path);
                                yield break;
                            }
                            SetModel(go);
                            PlayLastAnimation();
                        }
                        else// 如果缓存中不存在，则需要从文件中加载prefab
                        {
                            if (!avartaPartData.ContainsKey(defaultAvatar.bodyId))//检查换装id在表中是否存在
                            {
                                Debug.LogError(string.Format("body id is invalid {0} ap.vocation = {1}", ap.BodyId, ap.Vocation));
                                mIsProcessingModel = false;
                                yield break;
                            }

                            //先加载空装备的模型
                            PrefabResource pr = new PrefabResource();

                            string asset_path = string.Format("{0}/{1}.prefab", AVATAR_PATH_PREFIX, defaultAvatar.default_res);
                            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_prefab(asset_path, pr));
                            go = pr.obj_;

                            if (go == null)
                            {
                                mIsProcessingModel = false;
                                yield break;
                            }

                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                GameObject.Destroy(go);
                                yield break;
                            }

                            //将加载的gameobject放入内存池中
                            PoolGameObject pg = go.AddComponent<PoolGameObject>();
                            pg.poolType = ObjCachePoolType.ACTOR;
                            pg.key = string.Format("avatar_{0}_0", ap.Vocation);
                            GameObject.DontDestroyOnLoad(go);
                            SetModel(go);
                            PlayLastAnimation();

                            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.BodyId));
                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                yield break;
                            }

                            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.WeaponId));
                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                yield break;
                            }
                        }
                    }
                    else //如果之前进行过换装, 则直接替换部件就行
                    {
                        RemoveWing();
                        RemoveBackAttachment();
                        if (oldBodyId != 0 && oldWeaponId != 0)
                        {
                            DBAvatarPart.Data oldBodyData = null;
                            avartaPartData.TryGetValue(oldBodyId, out oldBodyData);
                            if (oldBodyData != null && oldBodyData.vocation != ap.Vocation)//检查职业信息
                            {
                                Debug.LogError(string.Format("change cloth faild, old body vocation {0}, new vocation {1}", oldBodyData.vocation, ap.Vocation));
                            }
                            else
                            {
                                if (ap.BodyId != oldBodyId)// 身体部件有改变时
                                {
                                    yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.BodyId));
                                    if (mIsDestroy)
                                    {
                                        mIsProcessingModel = false;
                                        yield break;
                                    }
                                }
                                if (ap.WeaponId != oldWeaponId)// 武器部件有改变时
                                {
                                    yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.WeaponId));
                                    if (mIsDestroy)
                                    {
                                        mIsProcessingModel = false;
                                        yield break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.BodyId));
                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                yield break;
                            }

                            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(ap.WeaponId));
                            if (mIsDestroy)
                            {
                                mIsProcessingModel = false;
                                yield break;
                            }
                        }
                    }
                }

                bool need_update_wing = true;
                if (is_change_body == false && mCurrentProperty != null && ap != null && mCurrentProperty.FashionWingId == ap.FashionWingId)
                    need_update_wing = false;
                bool need_update_magical_pet = true;
                if (is_change_body == false && mCurrentProperty != null && ap != null && mCurrentProperty.FashionMagicalPetId == ap.FashionMagicalPetId)
                    need_update_magical_pet = false;
                bool need_update_footprint = true;
                if (is_change_body == false && mCurrentProperty != null && ap != null && mCurrentProperty.FashionFootprintId == ap.FashionFootprintId)
                    need_update_footprint = false;
                bool need_update_back_attachment = true;
                if (is_change_body == false && mCurrentProperty != null && ap != null && mCurrentProperty.BackAttachmentID == ap.BackAttachmentID)
                    need_update_back_attachment = false;
                bool need_update_suit = true;
                if (is_change_body == false && mCurrentProperty != null && ap != null)
                {
                    if (mCurrentProperty.SuitEffectIds == null && ap.SuitEffectIds == null)
                    {
                        need_update_suit = false;
                    }
                    if (mCurrentProperty.SuitEffectIds != null && ap.SuitEffectIds != null && mCurrentProperty.SuitEffectIds.Count == ap.SuitEffectIds.Count)
                    {
                        need_update_suit = false;
                        for (int index = 0; index < mCurrentProperty.SuitEffectIds.Count; ++index)
                        {
                            uint suit_id = mCurrentProperty.SuitEffectIds[index];
                            if (suit_id == 0)
                                continue;
                            int find_index = ap.SuitEffectIds.FindIndex((a) => { return a == suit_id; });
                            if (find_index < 0 || find_index >= ap.SuitEffectIds.Count)
                            {
                                need_update_suit = true;
                                break;
                            }
                        }
                    }


                }
                if (mCurrentProperty == null)
                {
                    mCurrentProperty = new AvatarProperty();
                }

                mCurrentProperty.BodyId = ap.BodyId;
                mCurrentProperty.WeaponId = ap.WeaponId;
                mCurrentProperty.FashionBodyId = ap.FashionBodyId;
                mCurrentProperty.FashionWeaponId = ap.FashionWeaponId;
                mCurrentProperty.FashionWingId = ap.FashionWingId;// 可能需要加载后再设置属性
                mCurrentProperty.EquipBodyId = ap.EquipBodyId;
                mCurrentProperty.EquipWeaponId = ap.EquipWeaponId;
                mCurrentProperty.SuitEffectIds = ap.SuitEffectIds;// 可能需要加载后再设置属性
                mCurrentProperty.Vocation = ap.Vocation;
                mCurrentProperty.ElfinId = ap.ElfinId;
                mCurrentProperty.FashionMagicalPetId = ap.FashionMagicalPetId;
                mCurrentProperty.FashionFootprintId = ap.FashionFootprintId;
                mCurrentProperty.FashionBubbleId = ap.FashionBubbleId;
                mCurrentProperty.FashionPhotoFrameId = ap.FashionPhotoFrameId;
                mCurrentProperty.LightWeaponId = ap.LightWeaponId;
                mCurrentProperty.BackAttachmentID = ap.BackAttachmentID;

                if (mOwner is LocalPlayer)
                {
                    ActorManager.Instance.UpdateLocalPlayerClientModels();
                }

                if (need_update_wing)
                {
                    yield return ResourceLoader.Instance.StartCoroutine(SetWing(ap.FashionWingId));
                    if (mIsDestroy)
                    {
                        mIsProcessingModel = false;
                        yield break;
                    }
                }

                if (need_update_magical_pet)
                {
                    yield return ResourceLoader.Instance.StartCoroutine(SetMagicalPet(ap.FashionMagicalPetId));
                    if (mIsDestroy)
                    {
                        mIsProcessingModel = false;
                        yield break;
                    }
                }

                RemoveElfin();
                yield return ResourceLoader.Instance.StartCoroutine(SetElfin(ap.ElfinId));
                if (mIsDestroy)
                {
                    mIsProcessingModel = false;
                    yield break;
                }

                if (need_update_suit)
                {
                    RemoveSuitEffect();
                    yield return ResourceLoader.Instance.StartCoroutine(SetSuitEffect(ap.SuitEffectIds));
                    if (mIsDestroy)
                    {
                        mIsProcessingModel = false;
                        yield break;
                    }
                }

                if (need_update_footprint)
                {
                    //Debug.Log("need_update_footprint " + ap.FashionFootprintId + "  " + mOwner.IsLocalPlayer +  "   "  + mOwner.IsClientModel());

                    if (mOwner != null && (mOwner.IsLocalPlayer || mOwner.IsClientModel()))
                    {
                        //if (mOwner.IsLocalPlayer)
                        //{
                        FootprintBehavior footprintBehavior = Owner.GetBehavior<FootprintBehavior>();
                        //if (IsLocalPlayerModel())
                        //{
                        yield return ResourceLoader.Instance.StartCoroutine(footprintBehavior.SetFootprintId(ap.FashionFootprintId));
                        //}
                        //}
                    }
                }

                if (need_update_back_attachment)
                {
                    if (NeedShowBackAttachment || !IsUIModel())
                    {
                        if (mIsDestroy)
                        {
                            mIsProcessingModel = false;
                            yield break;
                        }
                        yield return ResourceLoader.Instance.StartCoroutine(SetBackAttachment(ap.BackAttachmentID));
                        if (mIsDestroy)
                        {
                            mIsProcessingModel = false;
                            yield break;
                        }

                    }
                }

                m_LoadedPrefabName = null;
            }
            mIsProcessingModel = false;
        }

        CommandInvoker m_CommandInvoker = new CommandInvoker();
        Coroutine m_WaitUnRide;
        Coroutine mWaitProcessModel;

    /// <summary>
    /// 进行变身操作
    /// </summary>
    /// <param name="shift">是否进入变身状态</param>
    /// <param name="type_id">变身后的角色id</param>
    public void ShapeShift(bool shift, uint type_id, byte shift_state)
        {
            if (shift)// 角色变身为怪物
            {
                if (mOwner == null || mOwner.transform == null)
                    return;

                if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.IsRiding())
                {
                    mOwner.mRideCtrl.UnRide(true);

                    if (m_WaitUnRide != null)
                    {
                        MainGame.HeartBehavior.StopCoroutine(m_WaitUnRide);
                    }
                    m_WaitUnRide = MainGame.HeartBehavior.StartCoroutine(WaitForUnRide(type_id, shift_state));
                }
                else
                {
                    // 必须等待上一次的模型加载结束
                    if (IsProcessingModel)
                    {
                        if (mWaitProcessModel != null)
                        {
                            MainGame.HeartBehavior.StopCoroutine(mWaitProcessModel);
                        }
                        mWaitProcessModel = MainGame.HeartBehavior.StartCoroutine(WaitForProcessModel(type_id, shift_state));
                    }
                    else
                        m_CommandInvoker.PushCommand(new ShapeShiftCommand(this, type_id, shift_state));
                }
            }
            else
            {
                if (m_WaitUnRide != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(m_WaitUnRide);
                    m_WaitUnRide = null;
                }

                if (mWaitProcessModel != null)
                {
                    MainGame.HeartBehavior.StopCoroutine(mWaitProcessModel);
                    mWaitProcessModel = null;
                }

                if (mOwner == null || mOwner.transform == null)
                    return;

                m_CommandInvoker.PushCommand(new UnShapeShiftCommand(this, type_id, shift_state));
            }
        }

        /// <summary>
        /// 等待下坐骑后再进行变身
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitForUnRide(uint type_id,byte shift_state)
        {
            while (mOwner.mRideCtrl.IsInUnRideAndResLoaded() == false)
            {
                yield return null;
            }

            m_CommandInvoker.PushCommand(new ShapeShiftCommand(this, type_id, shift_state));
        }

        /// <summary>
        /// 等待模型加载后再进行变身
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitForProcessModel(uint type_id, byte shift_state)
        {
            while (IsProcessingModel)
            {
                yield return null;
                //Debug.LogError("WaitForProcessModel");
            }

            m_CommandInvoker.PushCommand(new ShapeShiftCommand(this, type_id, shift_state));
        }

        /// <summary>
        /// 执行变身操作
        /// </summary>
        /// <param name="type_id"></param>
        public IEnumerator ShapeShiftImpl(uint type_id, byte shift_state)
        {
            if (mOwner == null || mOwner.IsDestroy)
                yield break;

            m_IsShapeShift = true;
            mShiftState = shift_state;
            m_IsShapeProcessing = true;

            AvatarProperty property = GetLatestAvatartProperty();
            if (property != null)
                m_LastProperty = property;
            else
            {
                string path = GetLatestAvatarPrefab();
                if (path != null)
                    m_LastPrefabName = path;
            }

            Vector3 pos = mOwner.transform.position;
            Quaternion rot = mOwner.transform.rotation;
            if (mOwner.SkillEffectPlayer != null)
                mOwner.SkillEffectPlayer.ClearEffects();

            if (mOwner.IsAttacking())// 在攻击状态时需要先Stop
                mOwner.Stop();
            // 变身的消息要在销毁模型前发送，因此有些组件的函数要在模型回收到内存池之前调用
            mOwner.FireActorEvent(Actor.ActorEvent.SHAPE_SHIFT, new CEventBaseArgs(true));
            //DestroyModel();
            //mIsProcessingModel = false;

            if (mOwner.IsLocalPlayer)
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHAPE_SHIFT_BEGIN, new CEventBaseArgs(type_id));
            string prefab = RoleHelp.GetPrefabName(type_id);
            Vector3 scale = RoleHelp.GetPrefabScale(type_id);
            yield return MainGame.HeartBehavior.StartCoroutine(CreateModelFromPrefab(prefab, Vector3.zero, Quaternion.identity, scale, null));

            m_IsShapeProcessing = false;
        }

        /// <summary>
        /// 变身恢复操作
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public IEnumerator UnShapeShifeImpl(uint type_id, byte shift_state)
        {
            if (mOwner == null || mOwner.IsDestroy)
                yield break;

            m_IsShapeShift = false;
            mShiftState = 0;
            m_IsShapeProcessing = true;

            if (mOwner.SkillEffectPlayer != null)
                mOwner.SkillEffectPlayer.ClearEffects();

            if (mOwner.IsAttacking())// 在攻击状态时需要先Stop
                mOwner.Stop();
            mOwner.FireActorEvent(Actor.ActorEvent.SHAPE_SHIFT, new CEventBaseArgs(false));// 变身的消息要在销毁模型前发送，因此有些组件的函数要在模型回收到内存池之前调用
            //DestroyModel();
            //mIsProcessingModel = false;

            Vector3 scale = RoleHelp.GetPrefabScale(mOwner.TypeIdx);

            if (m_LastProperty != null)// 玩家的变身恢复
            {
                List<uint> model_list = m_LastProperty.GetEquipModleIds();
                List<uint> fashion_list = m_LastProperty.GetFashionModleIds();
                List<uint> suit_effect_ids = m_LastProperty.SuitEffectIds != null ? new List<uint>(m_LastProperty.SuitEffectIds) : null;

                if (mOwner.IsLocalPlayer)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHAPE_SHIFT_END, null);

                yield return MainGame.HeartBehavior.StartCoroutine(CreateModelFromModleList(Vector3.zero, Quaternion.identity, scale, model_list, fashion_list, suit_effect_ids, m_LastProperty.Vocation, null));
                m_IsShapeProcessing = false;
                m_LastProperty = null;

                //变羊不打断，恢复采集动画
                if (mOwner != null &&
                    mOwner.ActorMachine != null &&
                    mOwner.ActorMachine.IsInInteraction &&
                    mOwner.ActorMachine.InteractionAniName != string.Empty)
                {
                    mOwner.Play(mOwner.ActorMachine.InteractionAniName);
                }

            }
            else if (m_LastPrefabName != null)// 怪物的变身恢复
            {
                if (mOwner.IsLocalPlayer)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHAPE_SHIFT_END, null);

                yield return MainGame.HeartBehavior.StartCoroutine(CreateModelFromPrefab(m_LastPrefabName, Vector3.zero, Quaternion.identity, scale, null));
                m_IsShapeProcessing = false;
                m_LastPrefabName = null;
            }
        }

        private void VisibleModel()
        {
            mCurrentVisible = true;
            if (mModelParent == null)
            {
                return;
            }

            // 显示模型下所有的Renderer
            Renderer[] rds = mModelParent.GetComponentsInChildren<Renderer>();
            foreach (Renderer rd in rds)
            {
                rd.enabled = true;
            }

            if (mElfinObject != null)
            {
                SetGameObjectVisible(mElfinObject, true);
            }

            if (mMagicalPetObject != null)
            {
                SetGameObjectVisible(mMagicalPetObject, true);
            }

        }

        private static void SetGameObjectVisible(GameObject obj, bool is_visible)
        {
            if (obj == null)
                return;
            Renderer[] rds = obj.GetComponentsInChildren<Renderer>();
            foreach (Renderer rd in rds)
            {
                rd.enabled = is_visible;
            }
        }

        private void InVisibleModel()
        {
            mCurrentVisible = false;
            if (mModelParent == null)
            {
                return;
            }

            // 隐藏模型下所有的Renderer
            Renderer[] rds = mModelParent.GetComponentsInChildren<Renderer>();
            foreach (Renderer rd in rds)
            {
                rd.enabled = false;
            }

            if (mElfinObject != null)
            {
                SetGameObjectVisible(mElfinObject, false);
            }

            if (mMagicalPetObject != null)
            {
                SetGameObjectVisible(mMagicalPetObject, false);
            }
        }

        public override void Destroy()
        {
            var model = GetModelParent();

            if (model != null)
            {
                // 销毁ActorMono
                xc.ActorMono actMono = model.GetComponent<ActorMono>();
                if (actMono != null)
                {
                    actMono.BindActor = null;
                    GameObject.DestroyImmediate(actMono);
                    actMono = null;
                }
            }
            DestroyModel();
            CommonTool.DestroyObjectImmediate(model);
            mIsProcessingModel = false;

            if (m_WaitUnRide != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_WaitUnRide);
                m_WaitUnRide = null;
            }

            if (mWaitProcessModel != null)
            {
                MainGame.HeartBehavior.StopCoroutine(mWaitProcessModel);
                mWaitProcessModel = null;
            }

            if (m_InvokerCoroutine != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_InvokerCoroutine);
                m_InvokerCoroutine = null;
            }

            if (m_CommandInvoker != null)
            {
                m_CommandInvoker.Stop();
                m_CommandInvoker = null;
            }

            base.Destroy();// Destroy中会设置mOnwer为null
        }

        /// <summary>
        /// 当前是否需要进行换装操作
        /// </summary>
        private bool NeedLoadAvatar()
        {
            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.IsLoadingRide())
                return false;
            return mCurrentVisible /*&& !mOwner.mRideCtrl.IsLoadingRide()*/ && (mDirtyPrefabName != null || mDirtyProperty != null);
        }

        Coroutine m_InvokerCoroutine;
        public override void Update()
        {
            base.Update();

            if (m_InvokerCoroutine == null)
            {
                m_InvokerCoroutine = MainGame.HeartBehavior.StartCoroutine(m_CommandInvoker.Execute());
            }

            if (IsProcessingModel)
            {
                return;
            }

            //可见状态发生改变时
            if (mDirtyVisible == VisibleDirty.INVISIBLE)
            {
                //invisible
                InVisibleModel();
                mDirtyVisible = VisibleDirty.NONE;

            }
            else if (mDirtyVisible == VisibleDirty.VISIBLE)
            {
                //visible
                VisibleModel();
                mDirtyVisible = VisibleDirty.NONE;
            }

            if (NeedLoadAvatar())
            {
                ResourceLoader.Instance.StartCoroutine(LoadAvatarAsync());
            }

            if (mElfinObject != null && mIsDestroy == false && this.mModelParent != null)
            {
                if (mElfinFlyItem == null)
                    mElfinFlyItem = new FlyActorItem(ResetElfinPos);
                Vector3 elfin_dest_pos = GetElfinFollowDestPos();
                FlyActorFollow(elfin_dest_pos, mElfinObject, mElfinFlyItem);
            }
            if (mMagicalPetObject != null && mIsDestroy == false && this.mModelParent != null)
            {
                if (mMagicalPetFlyItem == null)
                    mMagicalPetFlyItem = new FlyActorItem(ResetMagicalPetPos);
                Vector3 elfin_dest_pos = GetMagicalPetFollowDestPos();
                FlyActorFollow(elfin_dest_pos, mMagicalPetObject, mMagicalPetFlyItem);
            }

            if (m_is_wait_one_frame)
            {
                m_has_waited_frame = m_has_waited_frame - 1;
                if (m_has_waited_frame > 0)
                    ResetSuitPos(true, m_has_waited_frame);
                else
                    ResetSuitPos(false);
            }
        }

        public delegate void OnResetPosFunc();
        public class FlyActorItem
        {
            public float m_circleFlyingTotalInterval = 3;  //环绕的总时间

            public bool m_is_circleFlying = false; //环绕飞行
            public bool m_is_followMoving = false; //跟随移动
            public float m_circleFlyingInterval = 0;  //已经环绕的时间
            public float m_next_circleFlyingInterval = -1;  //下一次环绕的时间
            public Vector3 m_circleFly_startPos = Vector3.zero;    //环绕飞行的初始点
            public System.Action resetPos_callback;
            public FlyActorItem(System.Action var_resetPos_callback)
            {
                resetPos_callback = var_resetPos_callback;
            }
        }

        FlyActorItem mElfinFlyItem;
        FlyActorItem mMagicalPetFlyItem;

        Vector3 GetElfinFollowDestPos()
        {
            if (mElfinLinkObj)
                return mElfinLinkObj.transform.position;
            else if (this.mModelParent != null)
                return this.mModelParent.transform.position;
            return Vector3.zero;
        }

        Vector3 GetMagicalPetFollowDestPos()
        {
            if (mMagicalPetLinkObj)
                return mMagicalPetLinkObj.transform.position;
            else if (this.mModelParent != null)
                return this.mModelParent.transform.position;
            return Vector3.zero;
        }

        /// <summary>
        /// 小精灵跟随
        /// </summary>
        void FlyActorFollow(Vector3 dest_pos, GameObject fly_object, FlyActorItem item_data)
        {
            if (fly_object == null || mIsDestroy || this.mModelParent == null)
            {
                return;
            }
            //Vector3 dest_pos = GetElfinFollowDestPos();
            Vector3 move_forward = dest_pos - fly_object.transform.position;
            if (item_data.m_is_circleFlying)
            {
                item_data.m_circleFlyingInterval = item_data.m_circleFlyingInterval + Time.deltaTime;
                //环绕动画
                float percent = item_data.m_circleFlyingInterval / item_data.m_circleFlyingTotalInterval;
                if (percent >= 1)
                {//环绕结束，回到初始位置
                    item_data.m_is_circleFlying = false;
                    percent = 1;
                    item_data.m_next_circleFlyingInterval = new System.Random().Next(50, 100) / 100.0f * 5f;
                }

                Vector3 model_parent_pos = dest_pos;
                Vector3 forward_v = item_data.m_circleFly_startPos - model_parent_pos;
                Vector3 top_v = Vector3.Cross(this.mModel.transform.right, forward_v);
                float angle = (float)(percent * 2 * Math.PI);
                Vector3 x_v = Mathf.Cos(angle) * forward_v.normalized;
                Vector3 y_v = Mathf.Sin(angle) * top_v.normalized;
                fly_object.transform.position = x_v + y_v + model_parent_pos;
                return;
            }
            else if (item_data.m_is_followMoving)
            {//正在移动
                //移动到了合适的范围内（2米），就不再移动
                if (move_forward.magnitude < 1)
                {
                    item_data.m_is_followMoving = false;
                    item_data.m_next_circleFlyingInterval = new System.Random().Next(50, 100) / 100.0f * 3f;
                    return;
                }

                fly_object.transform.position = fly_object.transform.position + move_forward.normalized * 5.5f * Time.deltaTime;
                fly_object.transform.forward = move_forward.normalized;
            }
            else
            {//站立
                if (move_forward.magnitude > 2.5f)
                {
                    if (move_forward.magnitude > 10)
                    {//超过10米，直接瞬移到目标点
                        if (item_data.resetPos_callback != null)
                            item_data.resetPos_callback();
                        return;
                    }
                    //首次移动需要满足:超过5米
                    item_data.m_is_followMoving = true;
                    return;
                }
                //                 //超过某个时间执行绕行
                //                 m_next_circleFlyingInterval = m_next_circleFlyingInterval - Time.deltaTime;
                //                 if(m_next_circleFlyingInterval <= 0)
                //                 {//首次绕行
                //                     m_is_circleFlying = true;
                //                     m_circleFlyingInterval = 0;
                //                     m_circleFly_startPos = fly_object.transform.position;
                //                     return;
                //                 }

            }
        }

        public void UpdateVisibleState()
        {
            //可见状态发生改变时
            if (mDirtyVisible == VisibleDirty.INVISIBLE)
            {
                //invisible
                InVisibleModel();
                mDirtyVisible = VisibleDirty.NONE;

            }
            else if (mDirtyVisible == VisibleDirty.VISIBLE)
            {
                //visible
                VisibleModel();
                mDirtyVisible = VisibleDirty.NONE;
            }
        }

        /// <summary>
        /// 卸载模型(仅用于NPC的动态加载)
        /// </summary>
        public void UnloadModel()
        {
            // 模型未加载/正在加载模型时不能卸载
            if (ModelIsLoaded == false || mIsProcessingModel || mDirtyPrefabName != null || ModelIsLoading || mIsDestroy)
            {
                return;
            }

            m_PrefabNameBeforeUnload = GetLatestAvatarPrefab();

            DestroyModel();
            InitEmptyModelImpl();
        }

        /// <summary>
        /// 重新加载模型(仅用于NPC的动态加载)
        /// </summary>
        /// <returns></returns>
        IEnumerator ReloadModelCoroutine()
        {
            Vector3 scale = RoleHelp.GetPrefabScale(mOwner.ActorId);
            if (string.IsNullOrEmpty(m_PrefabNameBeforeUnload) == false)
            {
                yield return MainGame.HeartBehavior.StartCoroutine(CreateModelFromPrefab(m_PrefabNameBeforeUnload, Vector3.zero, Quaternion.identity, scale, null));
                m_PrefabNameBeforeUnload = null;
            }
        }

        /// <summary>
        /// 重新加载模型(仅用于NPC的动态加载)
        /// </summary>
        public void ReloadModel()
        {
            // 模型已加载/正在加载模型时不能卸载
            if (ModelIsLoaded != false || mIsProcessingModel || mDirtyPrefabName != null || ModelIsLoading || mIsDestroy)
            {
                return;
            }

            MainGame.HeartBehavior.StartCoroutine(ReloadModelCoroutine());
        }

        public void SetParent(Transform parent, Vector3 local_scale, Vector3 local_pos, Vector3 local_eulerAngles)
        {
            if (mIsDestroy)
                return;
            if (mModelParent != null)
            {
                mModelParent.transform.parent = parent;
                mModelParent.transform.localPosition = local_pos;
                mModelParent.transform.localScale = local_scale;
                mModelParent.transform.localEulerAngles = local_eulerAngles;
            }

            ResetElfinObject();

        }

        public void ResetElfinObject()
        {

            if (mElfinObject != null && mOwner != null)
            {
                bool is_scene_player = false;
                if (mOwner.IsClientModel() == false)
                    is_scene_player = true;
                else
                {
                    if ((mOwner as ClientModel).IsRidePlayer)
                        is_scene_player = true;
                }

                if (is_scene_player)
                {//场景上的Player
                    mElfinObject.transform.parent = null;
                    mElfinObject.transform.localScale = Vector3.one;
                    if (mModelParent != null)
                        mElfinObject.transform.eulerAngles = mModelParent.transform.eulerAngles;
                }
                else if (mModelParent != null)
                {
                    mElfinObject.transform.parent = mModelParent.transform.parent;
                    mElfinObject.transform.localPosition = mModelParent.transform.localPosition;
                    mElfinObject.transform.localScale = mModelParent.transform.localScale;
                    mElfinObject.transform.localEulerAngles = mModelParent.transform.localEulerAngles;
                }

            }
            ResetElfinPos();
        }

        public void SetElfinPos(Vector3 pos)
        {
            if (mElfinObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            mElfinObject.transform.localPosition = pos;
        }

        public void SetElfinEulerAngles(Vector3 eulerAngles)
        {
            if (mElfinObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            mElfinObject.transform.localEulerAngles = eulerAngles;
        }

        public void ResetMagicalPetObject()
        {
            if (mMagicalPetObject != null && mOwner != null)
            {
                bool is_scene_player = false;
                if (mOwner.IsClientModel() == false)
                    is_scene_player = true;
                else
                {
                    if ((mOwner as ClientModel).IsRidePlayer)
                        is_scene_player = true;
                }

                if (is_scene_player)
                {//场景上的Player
                    mMagicalPetObject.transform.parent = null;
                    mMagicalPetObject.transform.localScale = Vector3.one;
                    if (mModelParent != null)
                        mMagicalPetObject.transform.eulerAngles = mModelParent.transform.eulerAngles;
                }
                else if (mModelParent != null)
                {
                    mMagicalPetObject.transform.parent = mModelParent.transform.parent;
                    mMagicalPetObject.transform.localPosition = mModelParent.transform.localPosition;
                    mMagicalPetObject.transform.localScale = mModelParent.transform.localScale;
                    mMagicalPetObject.transform.localEulerAngles = mModelParent.transform.localEulerAngles;
                }

            }
            ResetMagicalPetPos();
        }

        public void SetMagicalPetPos(Vector3 pos)
        {
            if (mMagicalPetObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            mMagicalPetObject.transform.localPosition = pos;
        }

        public void SetMagicalPetEulerAngles(Vector3 eulerAngles)
        {
            if (mMagicalPetObject == null || mModelParent == null || mOwner == null || mOwner.IsDestroy)
                return;
            mMagicalPetObject.transform.localEulerAngles = eulerAngles;
        }
    }
}

