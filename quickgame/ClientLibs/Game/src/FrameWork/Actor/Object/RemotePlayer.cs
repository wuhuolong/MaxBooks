using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;



// 远程玩家，响应服务器发来的同步协议
[wxb.Hotfix]
public class RemotePlayer : Player
{
    public RemotePlayer()
    {
        
    }

    protected override void InitCtrl()
    {
        base.InitCtrl();

        AttackCtrl.mIsSendMsg = false;
        AttackCtrl.mIsRecvMsg = true;
        AttackCtrl.mIsProcessInput = false;
        AttackCtrl.IsUseMP = false;
        AttackCtrl.IsUseCD = false;
    
        BeattackedCtrl.mIsSendMsg = true;
        BeattackedCtrl.mIsRecvMsg = true;

        MoveCtrl.mIsProcessInput = false;
        MoveCtrl.mIsRecvMsg = true;
        MoveCtrl.mIsSendMsg = false;
    }

    protected override void InitAOIData(xc.UnitCacheInfo info)
    {
        base.InitAOIData(info);

        ActorManager.Instance.PlayerSet [info.UnitID] = this;
    }

    public override void InitBehaviors()
    {
        if (SceneHelp.Instance.IsInDeadSpaceInstance == true)
        {
            AddBehavior(new TargetGuideBehavior(this));

            TargetGuideBehavior targetGuideBehavior = GetBehavior<TargetGuideBehavior>();
            UI3DTargetGuide.StyleInfo styleInfo = new UI3DTargetGuide.StyleInfo();
            styleInfo.EllipseRadius1 = 110f;
            styleInfo.EllipseRadius2 = 90f;
            targetGuideBehavior.SetStyle(styleInfo);
        }

        base.InitBehaviors();
    }

    override public void Update()
    {
        base.Update();

        TargetGuideBehavior targetGuideBehavior = GetBehavior<TargetGuideBehavior>();
        if (targetGuideBehavior != null)
        {
            Camera mainCamera = xc.Game.Instance.MainCamera;
            if (mainCamera != null)
            {
                Vector3 pos = mainCamera.WorldToScreenPoint(this.GetModelParent().transform.position);
                pos.z = 0f;
                Rect camRect = mainCamera.pixelRect;
                // 在屏幕外
                if (!camRect.Contains(pos))
                {
                    targetGuideBehavior.EnableBehaviors(true);
                }
                else
                {
                    targetGuideBehavior.EnableBehaviors(false);
                }
            }
        }
    }

    public override void OnResLoaded()
    {
        base.OnResLoaded();

        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_REMOTEPLAYER_CREATED, new CEventBaseArgs(this));
    }

    public override void AfterCreate()
    {
        base.AfterCreate();

        gameObject.name = "RemotePlayer_" + UID.obj_idx + "_" + ActorId;
    }

    public override void Beattacked(Damage dam)
    {
        base.Beattacked(dam);
    }

    public override void ActiveAI(bool active)
    {
        if (!IsResLoaded)
        {
            Debug.LogError("modle is null");
            return;
        }
        if (active)
        {
            if (mAI == null)
            {
                //mAI = new PlayerAI(this);
                //mAI = new RobotAI2(this);
            }
        }
        else
        {
            if (mAI != null)
            {
                mAI.OnDestroy();
                mAI = null;
            }
        }
    }

    protected override void SetNameStyle()
    {
        UI3DText.StyleInfo styleInfo = new UI3DText.StyleInfo();
        styleInfo.Offset = new Vector3(0, 2.8f, 0);
        styleInfo.HeadOffset = new Vector3(0, this.Height, 0);
        styleInfo.ScreenOffset = UI3DText.NameTextScreenOffset;
        styleInfo.Scale = Vector3.one;

        bool show_tips = false;
        styleInfo.IsShowBg = PKModeManagerEx.Instance.IsLocalPlayerCanAttackActor(this, ref show_tips);
        styleInfo.SpritName = "Main@PKCan";
        int labelWidth = 100;//UserName.Length * 20;
        styleInfo.SpriteWidth = labelWidth + 30;
        show_tips = false;
        styleInfo.IsShowBgPreHead = PKModeManagerEx.Instance.IsActorCanAttackLocalPlayer(this, ref show_tips);
        if (styleInfo.IsShowBg)
            styleInfo.BgPreHeadOffset = new Vector3(styleInfo.SpriteWidth / 2 - 145, 2, 0);
        else
            styleInfo.BgPreHeadOffset = new Vector3(labelWidth / 2 - 110, 2, 0);

        Actor local_player = Game.Instance.GetLocalPlayer();
        show_tips = false;
        styleInfo.IsEnemyRelation = !(PKModeManagerEx.Instance.IsFriendRelation(local_player, this));

        //更新归属
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        CommonLuaInstanceState wildInstanceState = curState as CommonLuaInstanceState;
        if (wildInstanceState != null && wildInstanceState.DataBossBehaviour != null)
            styleInfo.IsShowAffiliationPanel = wildInstanceState.DataBossBehaviour.IsAffiliation(this);

        if (SceneHelp.Instance.IsInWorldBossExperienceInstance && this.IsLocalPlayer == false && this.IsPlayer() && this.IsDead())
        {
            styleInfo.LayoutIsVisiable = false;
        }
        else
            styleInfo.LayoutIsVisiable = true;

        // 和平模式，不显示血条，破碎死域副本内要总是显示血条
        if (PKModeManagerEx.Instance.CanShowPVPBlood(this) == false && SceneHelp.Instance.ForceShowHpBar == false)
        {
            SetShowBar(styleInfo, false);
        }
        else
        {
            SetShowBar(styleInfo, true);
        }

        TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
        nameBehavoir.SetStyle(styleInfo);
    }

    public override bool Kill()
    {
        bool isDead = base.Kill();
        if (SceneHelp.Instance.IsInWorldBossExperienceInstance)
        {
            SetNameLayoutVisiable(false);
            xc.ActorManager.Instance.DestroyActor(UID, xc.GlobalConst.MonsterDestroyDelay);
        }
        return isDead;
    }
}

