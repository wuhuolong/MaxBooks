using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Net;
using xc;
using xc.protocol;
using xc.ui;
using xc.ui.ugui;
using Random = System.Random;

/// <summary>
/// 流光旋转创建角色功场景功能
/// </summary>
[wxb.Hotfix]
public class CreateActorScene : MonoBehaviour
{
    /// <summary>
    /// 创建好的Actor挂载的总节点
    /// </summary>
    public Transform ActorPos { get; set; }

    /// <summary>
    /// 角色信息(职业id等)
    /// </summary>
    private List<PkgPlayerBrief> mRoleData = new List<PkgPlayerBrief>();

    /// <summary>
    /// 当前可用角色的最大数量
    /// </summary>
    private int mActorNum = 4;

    /// <summary>
    /// 创建好的角色
    /// </summary>
    private List<ClientModel> mActors = new List<ClientModel>();

    /// <summary>
    /// 登场动作
    /// </summary>
    private const string DEBUT_ANIMATION = "load";

    /// <summary>
    /// 登场后动作
    /// </summary>
    private const string DEBUT_NEXT_ANIMATION = "loadidle";

    /// <summary>
    /// 当前选择的角色索引
    /// </summary>
    private int mSelectIndex = -1;

    /// <summary>
    /// 已经加载的角色数量
    /// </summary>
    int mLoadedNum = 0;

    /// <summary>
    /// 所有的角色是否都加载完毕
    /// </summary>
    public bool LoadFinish = false;

    /// <summary>
    /// 当前是否正在播放登场动作
    /// </summary>
    bool mIsPlayingDebut = false;

    /// <summary>
    /// 当前是否正在播放登场待机动作
    /// </summary>
    bool mIsPlayDebutIdle = false;

    /// <summary>
    /// 实例
    /// </summary>
    public static CreateActorScene Instance;

    /// <summary>
    /// 用于随机选择角色音效
    /// </summary>
    private Random audioRandom = new Random();

    /// <summary>
    /// 上一次音效ID
    /// </summary>
    private uint lastAudioID;

    /// <summary>
    ///  初始化角色职业id等信息
    /// </summary>
    private void SetData()
    {
        var role_ids = GameConstHelper.GetUintList("GAME_AVAILABLE_ROLE_ID");
        mActorNum = role_ids.Count;

        mRoleData = new List<PkgPlayerBrief>();
        for (int i = 0; i < mActorNum; ++i)
        {
            PkgPlayerBrief roleBrief = new PkgPlayerBrief();
            roleBrief.rid = role_ids[i];
            roleBrief.uuid = 0;
            roleBrief.name = new byte[0];
            roleBrief.level = 0;

            mRoleData.Add(roleBrief);
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        SetData();

        ActorPos = transform;

        // 查找主光源
        Vector3 light_dir = new Vector3(0, -1, -1);
        var shadow_light_info = GetComponent<ShadowLightInfo>();
        if (shadow_light_info != null)
            light_dir = shadow_light_info.LightDir;
        ShadowManager.Instance.SetRealShadow(ActorPos, light_dir, 1 << LayerMask.NameToLayer("UIPreview"));

        ModelHelper.ClearChildren(ActorPos);

        mLoadedNum = 0;
        LoadFinish = false;

        if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
        {
            LoadFinish = true;
            return;
        }

        for (int i = 0; i < mActorNum; i++)
        {
            CreateActor(i);
        }

        PreloadTimelines();
    }

    private void Awake()
    {
        Instance = this;
        Init();
    }

    bool mIsDestroy = false;

    private void OnDestroy()
    {
        mIsDestroy = true;
        Instance = null;

        mRoleData.Clear();
        mActors.Clear();

    }

    /// <summary>
    /// 场景中的主相机
    /// </summary>
    private Camera mCamera;

    /// <summary>
    /// 当前显示的角色
    /// </summary>
    private GameObject mPreviewObj;

    private bool mStartDrag = false;
    private Vector3 mStartPos = new Vector3(0, 0, 0);

    /// <summary>
    /// 处理角色的旋转
    /// </summary>
    void UpdateRotation()
    {
        if (mCamera == null)
            mCamera = Camera.main;

        if (mCamera == null)
            return;

        // 出场动画播放完毕后才可拖动
        if (mIsPlayingDebut == false)
        {
            for (int i = 0; i < mActors.Count; i++)
            {
                if (i == mSelectIndex)
                {
                    mPreviewObj = mActors[i].gameObject;
                }
            }

            if (mPreviewObj == null)
                return;

            if (Input.GetMouseButton(0))
            {
                if (!mStartDrag)
                {
                    int layerMask = 1 << LayerMask.NameToLayer("UIPreview");
                    Vector3 screenPos = Input.mousePosition;
                    Ray ray = mCamera.ScreenPointToRay(screenPos);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
                    {
                        mStartDrag = true;
                        mStartPos = Input.mousePosition;
                    }
                }
            }
            else if (mStartDrag)
            {
                mStartDrag = false;
            }

            if (mStartDrag)
            {
                float angle = mStartPos.x - Input.mousePosition.x;
                angle *= 0.6f;

                mPreviewObj.transform.Rotate(Vector3.up, angle);

                mStartPos = Input.mousePosition;
            }
        }
    }

    /// <summary>
    /// 更新动画的播放
    /// </summary>
    void UpdateAnimation()
    {
        for (int i = 0; i < mActors.Count; i++)
        {
            if (i == mSelectIndex)
            {
                if (mIsPlayingDebut && mActors[i].IsPlaying(DEBUT_ANIMATION) == false)
                {
                    mIsPlayingDebut = false;
                    mIsPlayDebutIdle = true;
                }

                var select_actor = mActors[i];
                // 登场动画播放完毕后再播放待机动画
                if (mIsPlayDebutIdle && select_actor.IsPlaying(DEBUT_NEXT_ANIMATION) == false)
                {
                    if(select_actor.StateEffectPlayer != null)
                        select_actor.StateEffectPlayer.TriggerManual();
                    select_actor.CrossFade(DEBUT_NEXT_ANIMATION);
                    mIsPlayDebutIdle = false;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (ActorPos == null)
        {
            return;
        }

        if (mIsDestroy)
            return;

        UpdateAnimation();
        UpdateRotation();
    }

    private bool SelectActor(int index)
    {
        if (index >= mRoleData.Count)
        {
            return false;
        }

        mSelectIndex = index;

        if (mActors.Count > index)
            mActors[index].transform.localRotation = Quaternion.identity;

        PlayRandomActorAudio(index);
        PlayDebutAnimation();
        ChangeActorVisble();
        PreviewLight.SelectLight(1,(uint)(index + 1));
        return true;
    }

    /// <summary>
    /// 随机播放一个音效
    /// </summary>
    /// <param name="index"></param>
    private void PlayRandomActorAudio(int index)
    {
        // 东南亚版非简体中文不播放语音
        if (Const.Region == RegionType.SEASIA && Const.Language != LanguageType.SIMPLE_CHINESE)
        {
            return;
        }

        //AudioManager.Instance.StopAuidoClip();
        AudioManager.Instance.StopBattleSFX(lastAudioID);
        VocationInfo vocationInfo = DBVocationInfo.Instance.GetVocationInfo((uint)index + 1);
        if (vocationInfo!= null && vocationInfo.audios.Count > 0)
        {
            var audios = vocationInfo.audios;
            var audioIndex = audioRandom.Next(0, audios.Count);
            lastAudioID = AudioManager.Instance.PlayBattleSFX(GlobalConst.ResPath + $"Sound/Skill/{audios[audioIndex]}.ogg", SoundType.NPC);
        }
    }

    /// <summary>
    /// 设置角色的可见（只有当前选中的角色才显示）
    /// </summary>
    private void ChangeActorVisble()
    {
        for (int i = 0; i < mActors.Count; ++i)
        {
            Actor actor = mActors[i];
            if (actor != null)
            {
                actor.mVisibleCtrl.SetActorVisible(i == mSelectIndex, VisiblePriority.EXCEPT);
            }
        }
    }

    /// <summary>
    /// 选中指定职业的角色
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public bool SelectActorByVocation(uint rid, Action finishCallback)
    {
        int index = -1;

        for (int i = 0; i < mRoleData.Count; i++)
        {
            if (mRoleData[i] != null)
            {
                if (mRoleData[i].rid == rid)
                {
                    index = i;
                    break;
                }
            }
        }

        if (index >= 0)
        {
            var bSkipLogAni = false; // 跳过登场动作

            var isAuditAndIos = AuditManager.Instance.AuditAndIOS();
            if (isAuditAndIos)
            {
                if (SDKHelper.GetSwitchModel())
                {
                    bSkipLogAni = true;
                }
                else
                {
                    // SDKHelper.GetFashion() 有配置时，会改变创角初始模型，但该初始模型没有 "登场动作"
                    if (SDKHelper.GetFashion() != 0)
                        bSkipLogAni = true;
                }
            }

            if ( bSkipLogAni )
            {
                if (finishCallback != null)
                {
                    finishCallback();
                }
                return SelectActor(index);
            }

            // 播放剧情动画
            // 停止正在播放的
            TimelineManager.Instance.Stop();
            // 保存摄像机的位置和朝向
            Vector3 cameraPositionBeforePlay = mCamera.transform.position;
            Quaternion cameraRotationBeforePlay = mCamera.transform.rotation;
            List<uint> timelineIds = xc.GameConstHelper.GetUintList("GAME_CREATE_ROLE_TIMELINE_IDS");
            if (timelineIds.Count >= rid)
            {
                TimelineManager.Instance.Play(timelineIds[(int)rid - 1], () =>
                {
                    // 恢复摄像机的位置和朝向
                    mCamera.transform.position = cameraPositionBeforePlay;
                    mCamera.transform.rotation = cameraRotationBeforePlay;

                    if (finishCallback != null)
                    {
                        finishCallback();
                    }
                });
            }

            return SelectActor(index);
        }
        else
        {
            GameDebug.LogError("CreateActorScene.MoveToActorByVocation 找不到Rid 对应的 Index，Rid:" + rid.ToString());
        }

        return false;
    }

    /// <summary>
    /// 播放登场动画
    /// </summary>
    private void PlayDebutAnimation()
    {
        if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
            return;



        for (int i = 0; i < mActors.Count; i++)
        {
            if (i == mSelectIndex)
            {
 				// 没有出场动画，先直接播放待机
                //mActors[i].CrossFade(DEBUT_NEXT_ANIMATION);

                // 播放登场动画
                var animation_ctrl = mActors[i].AnimationCtrl;
                if (animation_ctrl != null)
                    animation_ctrl.CullMode = AnimatorCullingMode.AlwaysAnimate;

                mIsPlayingDebut = true;
                mIsPlayDebutIdle = false;
                mActors[i].Play(DEBUT_ANIMATION);
            }
        }
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="index"></param>
    private void CreateActor(int index)
    {
        string bodyweaponstring = string.Empty;
        if (index >= 0 && index < mRoleData.Count)
        {
            // 获取配置的初始武器和装备信息
            //bodyweaponstring = GameConstHelper.GetString(string.Format("GAME_BORN_ROLE{0}", mRoleData[index].rid));

            string[] splits = bodyweaponstring.Split('[', ',', ']');
            List<uint> modelList = new List<uint>();
            if (splits.Length > 3)
            {
                uint bodyId = uint.Parse(splits[1]);
                modelList.Add(bodyId);
                uint weaponId = uint.Parse(splits[2]);
                modelList.Add(weaponId);
            }
            modelList = ActorManager.ReplaceModelList(modelList, (Actor.EVocationType)mRoleData[index].rid, false);

            UnitID actor_uid = null;
            if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetFashion() != 0)
            {
                //List<uint> npc_id = SDKHelper.GetRoleList();
                //actor_uid = ClientModel.CreateClientModelByActorIdForLua(ActorHelper.RoleIdToCreateTypeId(npc_id[index]), OnActorLoaded);


                uint type_idx = ActorHelper.RoleIdToTypeId(mRoleData[index].rid);
                List<uint> model_list = new List<uint>();
                List<uint> fashion_list = new List<uint>();
                ActorHelper.GetModelFashionList(mRoleData[index].shows, model_list, fashion_list);
                fashion_list.Add(SDKHelper.GetFashion());
                var model_id_list = ActorManager.ReplaceModelList(model_list, (Actor.EVocationType)mRoleData[index].rid, true);
                ClientModel actor = ClientModel.CreateClientModel(type_idx, mRoleData[index].uuid, model_id_list, fashion_list, mRoleData[index].effects, OnActorLoaded);
                mActors.Add(actor);

            }
            else
            {
                actor_uid = ClientModel.CreateClientModelByActorIdForLua(ActorHelper.RoleIdToCreateTypeId(mRoleData[index].rid), OnActorLoaded);
            }
            

            

            var client_model = ActorManager.Instance.GetActor(actor_uid) as ClientModel;
            if(client_model != null)
            {
                client_model.AttackSpeed = 1.0f;// 攻速必须为1，不然出场特效与动作匹配不上
                mActors.Add(client_model);
            }
        }
    }

    /// <summary>
    /// 角色模型加载后的回调
    /// </summary>
    /// <param name="actor"></param>
    private void OnActorLoaded(Actor actor)
    {
        actor.Freeze(DBActor.UF_ANIMATION);
        actor.transform.localRotation = Quaternion.identity;

        actor.transform.parent = ActorPos;
        actor.transform.localPosition = Vector3.zero;
        actor.transform.localRotation = Quaternion.identity;
        actor.transform.localScale = Vector3.one;
        int layer = LayerMask.NameToLayer("UIPreview");
        actor.mAvatarCtrl.SetLayer(layer);

        mLoadedNum++;
        if (mLoadedNum == mRoleData.Count)
        {
            LoadFinish = true;
        }
    }

    /// <summary>
    /// 预加载剧情动画
    /// </summary>
    public void PreloadTimelines()
    {
        List<uint> timelineIds = xc.GameConstHelper.GetUintList("GAME_CREATE_ROLE_TIMELINE_IDS");
        foreach (uint timeline in timelineIds)
        {
            TimelineManager.Instance.Preload(timeline);
        }
    }

    /// <summary>
    /// 是否正在预加载剧情动画
    /// </summary>
    public bool TimelinesIsLoadFinished
    {
        get
        {
            return !TimelineManager.Instance.IsPreloading();
        }
    }
}
