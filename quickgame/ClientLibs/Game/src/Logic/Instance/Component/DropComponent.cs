/*----------------------------------------------------------------
// 文件名： DropComponent.cs
// 文件功能描述： 掉落物品组件
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using Net;

[wxb.Hotfix]
public class DropComponent : MonoBehaviour
{
    public enum EDropType
    {
        None = 0,
        Noncompetitive = 1, // 非竞争性掉落
        Competitive = 2,    // 竞争性掉落
    }

    /// <summary>
    /// 掉落数据
    /// </summary>
    private PkgDropGive mDropInfo;

    /// <summary>
    /// 掉落类型
    /// </summary>
    private EDropType mDropType = EDropType.None;

    /// <summary>
    /// 玩家的layer mask
    /// </summary>
    private int mPlayerMask;

    /// <summary>
    /// 掉落保护期计时器
    /// </summary>
    private Utils.Timer mTimer;

    /// <summary>
    /// 掉落消失计时器
    /// </summary>
    private Utils.Timer mDisappearTimer;

    /// <summary>
    /// 是否可以拾取
    /// </summary>
    private bool mCanPick;

    /// <summary>
    /// 不能拾取的理由
    /// </summary>
    public uint CanNotPickReason = 0;

    /// <summary>
    /// 拾取半径
    /// </summary>
    private float mPickSqrRadius;

    /// <summary>
    /// 是否在拾取范围内
    /// </summary>
    private bool mIsTouching;

    /// <summary>
    /// 掉落位置
    /// </summary>
    private Vector3 mPosition;

    public static uint mLoadEffectID = 1;
    public uint mCurLoadEffectID = 0;

    public static uint mLoadIconID = 1;
    public uint mCurLoadIconID = 0;

    SGameEngine.AssetResource mDropIconRes = null;

    /// <summary>
    /// 自动拾取延迟的协程
    /// </summary>
    private SafeCoroutine.Coroutine mAutoPickCoroutine = null;

    /// <summary>
    /// 拾取CD计时器
    /// </summary>
    private Utils.Timer mCDTimer;

    /// <summary>
    /// 拾取CD长度(秒)
    /// </summary>
    private float mCD;

    public bool IsLocalPlayerCloseEnough
    {
        get
        {
            var player = Game.GetInstance().GetLocalPlayer();
            if (player == null)
                return false;

            Vector3 localPlayerPos = player.transform.position;
            localPlayerPos.y = 0f;
            return (localPlayerPos - mPosition).sqrMagnitude < mPickSqrRadius;
        }
    }

    uint mDropGoodsSubType = 0; //掉落物品的sub_type
    private bool mIsBossChip = false; //是否是BOSS碎片
    public bool IsBossChip { get { return mIsBossChip; } }
    GameObject mBossChipEffectGameObject = null;

    int mGroundLayer = 0;
    Transform mParentTrans = null;

    void Awake()
    {
        mGroundLayer = LayerMask.NameToLayer("Ground");
        mParentTrans = gameObject.transform.parent;
        xc.ui.ugui.UIHelper.SetLayer(mParentTrans, mGroundLayer);
        mPlayerMask = LayerMask.NameToLayer("Player");

        mPickSqrRadius = 0f;
        mIsTouching = false;
    }


    bool m_IsDestory = false;
    void OnDestroy()
    {
        Destroy();
    }

    public void Destroy()
    {
        if (mIsBossChip && CanPick)
        {
            OnTouchExit();
        }

        mDropInfo = null;
        mDropType = EDropType.None;
        mCanPick = false;
        CanNotPickReason = 0;
        mPickSqrRadius = 0f;
        mIsTouching = false;

        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }

        if (mDisappearTimer != null)
        {
            mDisappearTimer.Destroy();
            mDisappearTimer = null;
        }

        ClearCD();

        InstanceDropManager.GetInstance().RemoveDrop(this);

        if (mDropIconRes != null)
        {
            mDropIconRes.destroy();
            mDropIconRes = null;
        }

        if (mAutoPickCoroutine != null)
        {
            mAutoPickCoroutine.Stop();
            mAutoPickCoroutine = null;
        }

        mDropGoodsSubType = 0;
        mIsBossChip = false;
        if (mBossChipEffectGameObject != null)
        {
            GameObject.DestroyImmediate(mBossChipEffectGameObject);
            mBossChipEffectGameObject = null;
        }

        mCurLoadEffectID = 0;
        mCurLoadIconID = 0;

        m_IsDestory = true;
    }

    public void Init()
    {
        m_IsDestory = false;

        mPosition = this.transform.parent.position;
        mPosition.y = 0f;

        if (mDropInfo != null)
        {
            if (DBInstanceTypeControl.Instance.AutoPickDrop(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == true)
            {
                if ((mDropInfo.type == GameConst.GIVE_TYPE_GOODS || mDropInfo.type == GameConst.GIVE_TYPE_EQUIP) && ItemManager.Instance.BagIsFull(1) == true)
                {

                }
                else
                {
                    mAutoPickCoroutine = SafeCoroutine.CoroutineManager.StartCoroutine(AutoPickCoroutine());
                }
            }
        }

        InstanceDropManager.GetInstance().AddDrop(this);
    }

    void Start()
    {
        mCD = GameConstHelper.GetFloat("GAME_MWAR_PICK_CD");
    }

    private void Update()
    {
        if (this == null)
        {
            return;
        }

        //if (mIsTouching == true)
        {
            if (IsLocalPlayerCloseEnough == false)
            {
                OnTouchExit();
            }
        }
        //else
        {
            if (IsLocalPlayerCloseEnough == true)
            {
                OnTouchEnter();
            }
        }
    }

    void OnTouchEnter()
    {
        mIsTouching = true;

        // 主角死了不能捡
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer != null && localPlayer.IsDead() == true)
        {
            return;
        }

        Pick();

        //GameDebug.LogError("OnTouchEnter: " + mDropInfo.oid);
    }

    void OnTouchExit()
    {
        mIsTouching = false;
        if (mIsBossChip && CanPick)
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP, new CEventBaseArgs(this.mDropInfo));
        }
        //GameDebug.LogError("OnTouchExit: " + mDropInfo.oid);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == null || other.gameObject.layer != mPlayerMask)
            return;

        // 不是本地玩家，不要捡
        ActorMono actor_mono = ActorHelper.GetActorMono(other.gameObject);
        if (actor_mono == null)
            return;

        var actor = actor_mono.BindActor;
        if (actor == null || actor.UID.obj_idx != Game.GetInstance().LocalPlayerID.obj_idx)
            return;

        // 死了也不要捡
        if (actor.IsDead())
            return;

        //Pick();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == null || other.gameObject.layer != mPlayerMask)
            return;

        ActorMono actor_mono = ActorHelper.GetActorMono(other.gameObject);
        if (actor_mono == null)
            return;

        var actor = actor_mono.BindActor;
        if (actor == null || actor.UID.obj_idx != Game.GetInstance().LocalPlayerID.obj_idx)
            return;
    }

    IEnumerator LoadDropEffect(string path, uint loadId)
    {
        if (gameObject == null || this == null)
        {
            yield return null;
        }

        SGameEngine.PrefabResource prefab = new SGameEngine.PrefabResource();

        yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(path, prefab));

        if (m_IsDestory == true || loadId != mCurLoadEffectID)
        {
            if (prefab != null && prefab.obj_ != null)
            {
                GameObject.DestroyImmediate(prefab.obj_);
            }
            yield break;
        }

        if (prefab != null && prefab.obj_ != null)
        {
            try
            {
                var dropTrans = prefab.obj_.transform;
                dropTrans.parent = mParentTrans.Find("EffectGameObject");
                dropTrans.localScale = Vector3.one;
                dropTrans.localPosition = Vector3.zero;
                dropTrans.localRotation = Quaternion.identity;

                xc.ui.ugui.UIHelper.SetLayer(dropTrans, mGroundLayer);
            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }

    IEnumerator LoadDropIcon(uint iconId, Sprite3DEx sprite3D, uint loadId)
    {
        sprite3D.RenderEnable = false;

        SGameEngine.AssetResource ar = new SGameEngine.AssetResource();
        IconInfo info = GoodsHelper.GetIconInfo(iconId);
        var iconPath = info.MainTexturePath;
        yield return xc.MainGame.GetGlobalMono().StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(iconPath, typeof(Texture), ar));

        // 检查资源
        var tex = ar.asset_ as Texture;
        if (tex == null)
        {
            GameDebug.LogError("LoadDropIcon is failed");
            yield break;
        }

        // 检查loadId是否变化/sprite3D组件
        if (loadId != mCurLoadIconID || sprite3D == null)
        {
            ar.destroy();
            yield break;
        }

        mDropIconRes = ar;

        sprite3D.SetTexture(tex, iconPath);
        sprite3D.UVOffset = info.IconRect;
        sprite3D.RenderEnable = true;
    }

    public ulong Id
    {
        get
        {
            if (mDropInfo != null)
            {
                return mDropInfo.oid;
            }

            return 0;
        }
    }

    public PkgDropGive DropInfo
    {
        get { return mDropInfo; }
        set
        {
            m_IsDestory = false;

            mDropInfo = value;

            mDropGoodsSubType = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(mDropInfo.gid);
            if (goods_info != null)
            {
                mDropGoodsSubType = goods_info.sub_type;
            }
            else
            {
                GameDebug.LogError("Error in set drop info, can not find goods by gid: " + mDropInfo.gid);
            }

            if (mDropInfo.type == GameConst.GIVE_TYPE_GOODS && mDropGoodsSubType == GameConst.GIVE_SUB_TYPE_BOSS_CHIP)
            {
                // 抓BOSS副本 和 世界BOSS引导副本 强制把本地玩家名字赋值给掉落归属名字
                if (SceneHelp.Instance.IsInCatchBossInstance == true || SceneHelp.Instance.IsInWorldBossExperienceInstance || SceneHelp.Instance.IsInPersonalBossInstance)
                {
                    mDropInfo.name = DBTextResource.Str2Byte(LocalPlayerManager.Instance.LocalActorAttribute.Name);
                }
                if (mDropInfo.name != null && DBTextResource.Byte2Str(mDropInfo.name) != "")
                    mIsBossChip = true;
                else
                    mIsBossChip = false;
            }
            else
                mIsBossChip = false;

            if(mIsBossChip)
            {
                var nameSprite3D = gameObject.GetComponent<Sprite3DEx>();
                if (nameSprite3D != null)
                    nameSprite3D.SetTexture(null, "");

                //归属名字
                UIDropAffiBar bar = gameObject.AddComponent<UIDropAffiBar>();
                string affi_player_name = "";
                if (mDropInfo.name != null && DBTextResource.Byte2Str(mDropInfo.name) != "")
                    affi_player_name = DBTextResource.Byte2Str(mDropInfo.name);
                bar.AffiPlayerName = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_43"), affi_player_name);
                bar.Offset = new Vector3(0, 0.8f, 0);
                bar.Visible = true;
                EffectManager.GetInstance().GetEffectEmitter("Effects/Prefabs/Skill/BOSS_skill/EF_boss_hunpo_0.prefab").CreateInstance(OnBossChipEffectResLoad);
            }
            else
            {
                string name = GoodsHelper.GetGoodsNameByTypeId_blackBkg(mDropInfo.gid);
                if (mDropInfo.type == GameConst.GIVE_TYPE_MONEY)
                {
                    name = "<color=#FFFFFF>" + mDropInfo.num + "</color>" + name;
                }
                string dropEffectPathPrefix = "Assets/";

                // 特效模型
                string dropEffectPath = dropEffectPathPrefix + ResPath.path20;
                if (mDropInfo.type == GameConst.GIVE_TYPE_EXP)
                {
                    dropEffectPath = dropEffectPathPrefix + ResPath.EF_ui_jingyansaluo_dimian;
                }
                else
                {
                    uint color = GoodsHelper.GetGoodsColorTypeByTypeId(mDropInfo.gid);
                    if (color == GameConst.QUAL_COLOR_GREEN)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path13;
                    }
                    else if (color == GameConst.QUAL_COLOR_BLUE)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path14;
                    }
                    else if (color == GameConst.QUAL_COLOR_PURPLE)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path15;
                    }
                    else if (color == GameConst.QUAL_COLOR_GOLDEN)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path16;
                    }
                    else if (color == GameConst.QUAL_COLOR_PINK)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path17;
                    }
                    else if (color == GameConst.QUAL_COLOR_RED)
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path18;
                    }
                    else
                    {
                        dropEffectPath = dropEffectPathPrefix + ResPath.path20;
                    }
                }

                if (string.IsNullOrEmpty(dropEffectPath) == false)
                {
                    if (mLoadEffectID == 0)
                        mLoadEffectID++;
                    mCurLoadEffectID = mLoadEffectID;

                    SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadDropEffect(dropEffectPath, mCurLoadEffectID));
                    ++mLoadEffectID;
                }

                // 图片
                uint iconId = GoodsHelper.GetGoodsIconIdByTypeId(mDropInfo.gid);
                var nameSprite3D = gameObject.GetComponent<Sprite3DEx>();
                if (nameSprite3D != null)
                {
                    nameSprite3D.gameObject.SetActive(true);
                    if (mDropIconRes != null)
                    {
                        mDropIconRes.destroy();
                        mDropIconRes = null;
                    }

                    if (mLoadIconID == 0)
                        mLoadIconID++;
                    mCurLoadIconID = mLoadIconID;

                    SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadDropIcon(iconId, nameSprite3D, mCurLoadIconID));
                    ++mLoadIconID;
                }

                // 名字
                UI3DText nameText = gameObject.AddComponent<UI3DText>();
                nameText.ShowFrame(false);
                //nameText.SetBGSprite("Main@LeftLower_19");
                //nameText.SetBGMaterial("Main");
                nameText.SetButtonStyle("", "", 18, Color.white, Vector3.zero);
                nameText.ShowPreBGSprite = false;
                nameText.Text = name;
                if (name == "")
                {
                    nameText.ShowFrame(false);
                }
                nameText.TextColor = GoodsHelper.GetGoodsColorByTypeId(mDropInfo.gid);
                nameText.Offset = new Vector3(0, 0.6f, 0);
                nameText.SetClickCallback(() =>
                {
                    Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                    if (localPlayer != null)
                    {
                        localPlayer.MoveCtrl.TryWalkToAlong(this.transform.position);
                    }
                });
            }
            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
            if (mDisappearTimer != null)
            {
                mDisappearTimer.Destroy();
                mDisappearTimer = null;
            }
            int pass_time = 0;
            uint server_time = xc.Game.Instance.ServerTime;
            if (server_time >= mDropInfo.time)
                pass_time = (int)(server_time - mDropInfo.time);
            int pickDisappearTime = GameConstHelper.GetInt("GAME_MWAR_PICK_DISAPPEAR");
            int pickExclusiveTime = GameConstHelper.GetInt("GAME_MWAR_PICK_EXCLUSIVE");

            pickDisappearTime = pickDisappearTime - pass_time;
            mDisappearTimer = new Utils.Timer(pickDisappearTime * 1000, false, (float)pickDisappearTime * 1000f,
                (dt) =>
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DESTROY_DROP, new CEventBaseArgs(this.mDropInfo.oid));
                });
            if (mDropInfo.name != null)
            {//属于专属某个玩家，其他玩家不可以拾取
                string name_str = DBTextResource.Byte2Str(mDropInfo.name);
                if (Game.Instance.LocalPlayerName == name_str)
                {
                    mCanPick = true;
                }
                else
                    mCanPick = false;
            }
            else
            {
                if (mDropInfo.owner_uuids != null && mDropInfo.owner_uuids.Contains(Game.GetInstance().LocalPlayerID.obj_idx) == true)
                {// 存在owner_uuids中，任何时候都可以拾取
                    mCanPick = true;
                }
                else if(mDropInfo.owner_uuids != null && mDropInfo.owner_uuids.Count == 0)
                {
                    mCanPick = true;
                }
                else
                {//不属于主角，安全期间过后才可以拾取
                    pickExclusiveTime = pickExclusiveTime - pass_time;
                    if (pickExclusiveTime > 0)
                    {
                        mCanPick = false;
                        mTimer = new Utils.Timer(pickExclusiveTime * 1000, false, (float)pickExclusiveTime * 1000f,
                        (dt) =>
                        {
                            mCanPick = true;

                            ClearCD();
                        });
                    }
                    else
                        mCanPick = true;
                }
            }

            // 调整拾取范围
            float radius = 0f;
            if (mDropType == EDropType.Noncompetitive)
            {
                radius = GameConstHelper.GetFloat("GAME_DROP_PICK_DISTANCE_UNCOMPETE") * GlobalConst.UnitScale;
            }
            else if (mDropType == EDropType.Competitive)
            {
                radius = GameConstHelper.GetFloat("GAME_DROP_PICK_DISTANCE_COMPETE") * GlobalConst.UnitScale;
            }
            if (mIsBossChip)
                radius = 10;    //
            mPickSqrRadius = radius * radius;
        }
    }

    /// <summary>
    /// BOSS碎片特效加载完毕后的回调
    /// </summary>
    /// <param name="effect_object"></param>
    /// <param name="parent_trans"></param>
    /// <param name="bind_node"></param>
    void OnBossChipEffectResLoad(GameObject effect_object)
    {
        if (effect_object != null)
        {
            if (m_IsDestory == true || gameObject == null)
            {
                GameObject.DestroyObject(effect_object);
                return;
            }

            Transform selectTrans = effect_object.transform;

            selectTrans.parent = mParentTrans;
            selectTrans.localPosition = new Vector3(0, 0.71f, 0);
            selectTrans.localScale = Vector3.one;
            effect_object.SetActive(true);

            xc.ui.ugui.UIHelper.SetLayer(selectTrans, mGroundLayer);

            mBossChipEffectGameObject = effect_object;
        }
    }

    public EDropType DropType
    {
        get
        {
            return mDropType;
        }
        set
        {
            mDropType = value;
        }
    }

    public bool CanPick
    {
        get
        {
            return mCanPick;
        }
        set
        {
            mCanPick = value;
        }
    }

    public bool IsInCD
    {
        get
        {
            return !(mCDTimer == null);
        }
    }

    /// <summary>
    /// 拾取
    /// </summary>
    public void Pick()
    {
        if (m_IsDestory == true)
        {
            return;
        }

        if (mAutoPickCoroutine != null)
        {
            mAutoPickCoroutine.Stop();
            mAutoPickCoroutine = null;
        }

        if (mCDTimer != null)
        {
            return;
        }

        if (mIsBossChip == false)
        {
            if ((mDropInfo.type == GameConst.GIVE_TYPE_GOODS || mDropInfo.type == GameConst.GIVE_TYPE_EQUIP) && ItemManager.Instance.BagIsFull(1) == true)
            {
                //UINotice.Instance.ShowMessage(DBConstText.GetText("BAG_IS_FULL"));
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS, new CEventBaseArgs(DBConstText.GetText("BAG_IS_FULL")));

                StartCD();
                return;
            }
        }

        if (mCanPick == false)
        {
            if (mIsBossChip == false)
            {
                if (CanNotPickReason == 2)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS, new CEventBaseArgs(DBConstText.GetText("DROP_REACH_LIMIT")));
                }
                else
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS, new CEventBaseArgs(DBConstText.GetText("DROP_NOT_BELONG_TO_YOU")));
                }

                StartCD();
            }
            return;
        }

        if (gameObject == null)
        {
            return;
        }
        if (enabled == false)
        {
            return;
        }
        Transform trans = transform;
        if(trans == null)
            return;

        Transform parentTrans = trans.parent;
        if(parentTrans == null)
            return;

        if (mDropType == 0)
        {
            return;
        }

        if (mIsBossChip)
        {//BOSS碎片不能主动拾取
            //显示主界面
            Actor local_player = Game.Instance.GetLocalPlayer();
            if (local_player != null && (local_player.IsShapeShift || 
                local_player.HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_DIZZY) )) //变身和眩晕状态，不显示拾取BOSS按钮
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP, new CEventBaseArgs(this.mDropInfo));
                return;
            }
            
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PICK_DROP_SHOW_BOSS_CHIP, new CEventObjectArgs(mDropInfo, (uint)mDropType, parentTrans.gameObject));
            return;
        }

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PICK_DROP, new CEventObjectArgs(mDropInfo, (uint)mDropType, parentTrans.gameObject));

        StartCD();
    }

    /// <summary>
    /// 开始计算CD
    /// </summary>
    void StartCD()
    {
        ClearCD();
        float cd = 1000f * mCD;
        mCDTimer = new Utils.Timer(cd, false, cd,
            (dt) =>
            {
                ClearCD();
            });
    }

    /// <summary>
    /// 清除CD
    /// </summary>
    void ClearCD()
    {
        if (mCDTimer != null)
        {
            mCDTimer.Destroy();
            mCDTimer = null;
        }
    }

    IEnumerator AutoPickCoroutine()
    {
        yield return new SafeCoroutine.SafeWaitForSeconds(GameConstHelper.GetFloat("GAME_AUTO_PICK_DROP_DELAY"));

        Pick();
    }
}
