#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class ActorWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Actor), L, translator, 0, 134, 89, 37);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBehaviors", _m_InitBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnInitBehaviors", _m_UnInitBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBehavior", _m_AddBehavior);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnableBehaviors", _m_EnableBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBehavior", _m_GetBehavior);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnModelChanged", _m_OnModelChanged);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetActorMono", _m_GetActorMono);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsGuardedNpc", _m_IsGuardedNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LateUpdate", _m_LateUpdate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetActorAttribute", _m_SetActorAttribute);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnCreate", _m_OnCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAOIAttrElement", _m_UpdateAOIAttrElement);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetModelLayer", _m_GetModelLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLayer", _m_GetLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetLayer", _m_ResetLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSlotTransform", _m_GetSlotTransform);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetModel", _m_GetModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetModelParent", _m_GetModelParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayLastAnimation", _m_PlayLastAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayLastAnimation_real", _m_PlayLastAnimation_real);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAnimationOptions", _m_GetAnimationOptions);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWalkAniOptions", _m_GetWalkAniOptions);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetIdleAniOptions", _m_GetIdleAniOptions);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Play", _m_Play);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlaySkillSound", _m_PlaySkillSound);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CrossFade", _m_CrossFade);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAnimationSpeed", _m_SetAnimationSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMoveSpeed", _m_GetMoveSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWalkSpeed", _m_GetWalkSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMoveSpeedScale", _m_SetMoveSpeedScale);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMoveAnimationSpeed", _m_SetMoveAnimationSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAnimationLength", _m_GetAnimationLength);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPlaying", _m_IsPlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInAnimationState", _m_IsInAnimationState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasAnimation", _m_HasAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeginInteraction", _m_BeginInteraction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeginJumpScene", _m_BeginJumpScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBeAttacking", _m_IsBeAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsDead", _m_IsDead);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsIdle", _m_IsIdle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWalking", _m_IsWalking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAttacking", _m_IsAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsGrounded", _m_IsGrounded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Freeze", _m_Freeze);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnFreeze", _m_UnFreeze);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stop", _m_Stop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stand", _m_Stand);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetPosition", _m_SetPosition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TurnDir", _m_TurnDir);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetRotation", _m_SetRotation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WalkTo", _m_WalkTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanMove", _m_CanMove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WalkAlong", _m_WalkAlong);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReachDst", _m_ReachDst);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MoveDirInAttacking", _m_MoveDirInAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WalkAlongStop", _m_WalkAlongStop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Kill", _m_Kill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Relive", _m_Relive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Beattacked", _m_Beattacked);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMPEnough", _m_IsMPEnough);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Attack", _m_Attack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetSkillCastInfo", _m_SetSkillCastInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSkillCastInfo", _m_AddSkillCastInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillCount", _m_GetSkillCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillCastInfo", _m_GetSkillCastInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillIDByIndex", _m_GetSkillIDByIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCurSkill", _m_SetCurSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCurSkill", _m_GetCurSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSelfSkill", _m_GetSelfSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillList", _m_GetSkillList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInSkillActionEndingStage", _m_IsInSkillActionEndingStage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishCastingReadyStage", _m_FinishCastingReadyStage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateBattleState", _m_UpdateBattleState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasBattleState", _m_HasBattleState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanBeHited", _m_CanBeHited);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanBeChoosed", _m_CanBeChoosed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterFreezeState", _m_EnterFreezeState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitFreezeState", _m_ExitFreezeState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterDizzyState", _m_EnterDizzyState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitDizzyState", _m_ExitDizzyState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterSuperState", _m_EnterSuperState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitSuperState", _m_ExitSuperState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterChaosState", _m_EnterChaosState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitChaosState", _m_ExitChaosState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDamageEffectModel", _m_ShowDamageEffectModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLocalPlayerCamp", _m_IsLocalPlayerCamp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DoDamage", _m_DoDamage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDamageEffect", _m_ShowDamageEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetEffect", _m_ResetEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowBuffTip", _m_ShowBuffTip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowTextBehaviors", _m_ShowTextBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowTextName", _m_ShowTextName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHeadIcons", _m_SetHeadIcons);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowTeamIcon", _m_ShowTeamIcon);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNameText", _m_GetNameText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNameText", _m_SetNameText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDialogBubble", _m_ShowDialogBubble);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBindEffectInfo", _m_InitBindEffectInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyTriggerEnter", _m_NotifyTriggerEnter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyTriggerExit", _m_NotifyTriggerExit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBattleTrigger", _m_OnBattleTrigger);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActiveAI", _m_ActiveAI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBoss", _m_IsBoss);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMonster", _m_IsMonster);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPet", _m_IsPet);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPlayer", _m_IsPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsNpc", _m_IsNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsClientModel", _m_IsClientModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBecomeVisible", _m_OnBecomeVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBecomeNameVisible", _m_OnBecomeNameVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePKIconImpl", _m_UpdatePKIconImpl);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateNameStyle", _m_UpdateNameStyle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNameLayoutVisiable", _m_SetNameLayoutVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsShemale", _m_IsShemale);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateByBitState", _m_UpdateByBitState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateNameColor", _m_UpdateNameColor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckCanAttackOtherPlayer", _m_CheckCanAttackOtherPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSonActor", _m_AddSonActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAIEnable", _m_SetAIEnable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAIEnable", _m_GetAIEnable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAI", _m_GetAI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NeedUpdate", _m_NeedUpdate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUpdateFlag", _m_SetUpdateFlag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAI", _m_SetAI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubscribeActorEvent", _m_SubscribeActorEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnsubscribeActorEvent", _m_UnsubscribeActorEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnsubscribeAllActorEvent", _m_UnsubscribeAllActorEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FireActorEvent", _m_FireActorEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAvatarParent", _m_SetAvatarParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsUIModel", _m_IsUIModel);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsDestroy", _g_get_IsDestroy);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gameObject", _g_get_gameObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "transform", _g_get_transform);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "collider", _g_get_collider);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPlayingAnimation", _g_get_IsPlayingAnimation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveDir", _g_get_MoveDir);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveSpeed", _g_get_MoveSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorMachine", _g_get_ActorMachine);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForwardDir", _g_get_ForwardDir);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DisableMoveState", _g_get_DisableMoveState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShapeShift", _g_get_IsShapeShift);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShiftState", _g_get_ShiftState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShapeProcessing", _g_get_IsShapeProcessing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WarTag", _g_get_WarTag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttackSpeed", _g_get_AttackSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Camp", _g_get_Camp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsActorInvisiable", _g_get_IsActorInvisiable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNoStrike", _g_get_IsNoStrike);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsActorBeattackDisable", _g_get_IsActorBeattackDisable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFreezeState", _g_get_IsFreezeState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HPProgressBarIsActive", _g_get_HPProgressBarIsActive);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CreateParamInfo", _g_get_CreateParamInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VocationID", _g_get_VocationID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorAttribute", _g_get_ActorAttribute);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NormalAttackID", _g_get_NormalAttackID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorTrans", _g_get_ActorTrans);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WalkMode", _g_get_WalkMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DestList", _g_get_DestList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsHaveSonActors", _g_get_IsHaveSonActors);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SvrId", _g_get_SvrId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ParentActor", _g_get_ParentActor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InBattleStatus", _g_get_InBattleStatus);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OverridingName", _g_get_OverridingName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Height", _g_get_Height);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CharacterHeight", _g_get_CharacterHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Radius", _g_get_Radius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HpPercent", _g_get_HpPercent);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurLife", _g_get_CurLife);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FullLife", _g_get_FullLife);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurMp", _g_get_CurMp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FullMp", _g_get_FullMp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UserName", _g_get_UserName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MonsterSpecName", _g_get_MonsterSpecName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TitleId", _g_get_TitleId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeIdx", _g_get_TypeIdx);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorId", _g_get_ActorId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TeamId", _g_get_TeamId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EscortId", _g_get_EscortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Honor", _g_get_Honor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Title", _g_get_Title);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TransferLv", _g_get_TransferLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildId", _g_get_GuildId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildName", _g_get_GuildName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OverridingTargetName", _g_get_OverridingTargetName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NameColor", _g_get_NameColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BitStates", _g_get_BitStates);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SonActors", _g_get_SonActors);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsResLoaded", _g_get_IsResLoaded);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BuffCtrl", _g_get_BuffCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NoUpdate", _g_get_NoUpdate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkillEffectPlayer", _g_get_SkillEffectPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StateEffectPlayer", _g_get_StateEffectPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveImplement", _g_get_MoveImplement);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnitType", _g_get_UnitType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FSM", _g_get_FSM);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UID", _g_get_UID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Trans", _g_get_Trans);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AnimationCtrl", _g_get_AnimationCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurSelectActor", _g_get_CurSelectActor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanBeInterruptedWhenInInteractionAndBeAttacked", _g_get_CanBeInterruptedWhenInInteractionAndBeAttacked);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLocalPlayer", _g_get_IsLocalPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInSafeArea", _g_get_IsInSafeArea);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WildState", _g_get_WildState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MountId", _g_get_MountId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateInfo", _g_get_MateInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateUuid", _g_get_MateUuid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateName", _g_get_MateName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mEventCtrl", _g_get_mEventCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveCtrl", _g_get_MoveCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttackCtrl", _g_get_AttackCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BeattackedCtrl", _g_get_BeattackedCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CDCtrl", _g_get_CDCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_MatEffectCtrl", _g_get_m_MatEffectCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mRideCtrl", _g_get_mRideCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mAvatarCtrl", _g_get_mAvatarCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mVisibleCtrl", _g_get_mVisibleCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PKLvProtect", _g_get_PKLvProtect);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveSpeed", _s_set_MoveSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttackSpeed", _s_set_AttackSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Camp", _s_set_Camp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Alpha", _s_set_Alpha);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HPProgressBarIsActive", _s_set_HPProgressBarIsActive);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VocationID", _s_set_VocationID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActorAttribute", _s_set_ActorAttribute);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ParentActor", _s_set_ParentActor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InBattleStatus", _s_set_InBattleStatus);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OverridingName", _s_set_OverridingName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurLife", _s_set_CurLife);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FullLife", _s_set_FullLife);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurMp", _s_set_CurMp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FullMp", _s_set_FullMp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UserName", _s_set_UserName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MonsterSpecName", _s_set_MonsterSpecName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TitleId", _s_set_TitleId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TransferLv", _s_set_TransferLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OverridingTargetName", _s_set_OverridingTargetName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NameColor", _s_set_NameColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NoUpdate", _s_set_NoUpdate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UID", _s_set_UID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanBeInterruptedWhenInInteractionAndBeAttacked", _s_set_CanBeInterruptedWhenInInteractionAndBeAttacked);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsInSafeArea", _s_set_IsInSafeArea);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WildState", _s_set_WildState);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MountId", _s_set_MountId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MateInfo", _s_set_MateInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mEventCtrl", _s_set_mEventCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveCtrl", _s_set_MoveCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttackCtrl", _s_set_AttackCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BeattackedCtrl", _s_set_BeattackedCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CDCtrl", _s_set_CDCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_MatEffectCtrl", _s_set_m_MatEffectCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mRideCtrl", _s_set_mRideCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mAvatarCtrl", _s_set_mAvatarCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mVisibleCtrl", _s_set_mVisibleCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PKLvProtect", _s_set_PKLvProtect);
            
			XUtils.EndObjectRegister(typeof(Actor), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Actor), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsShowDamageWord", _m_IsShowDamageWord_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SlotSpineName", Actor.SlotSpineName);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SlotHeadName", Actor.SlotHeadName);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SlotRootName", Actor.SlotRootName);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor));
			
			
			XUtils.EndClassRegister(typeof(Actor), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Actor __cl_gen_ret = new Actor();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Actor constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitBehaviors(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnInitBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UnInitBehaviors(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBehavior(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.IActorBehavior behavior = (xc.IActorBehavior)translator.GetObject(L, 2, typeof(xc.IActorBehavior));
                    
                    __cl_gen_to_be_invoked.AddBehavior( behavior );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnableBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool enable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.EnableBehaviors( enable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBehavior(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.IActorBehavior __cl_gen_ret = __cl_gen_to_be_invoked.GetBehavior( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnModelChanged(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnModelChanged(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorMono(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.ActorMono __cl_gen_ret = __cl_gen_to_be_invoked.GetActorMono(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AfterCreate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnResLoaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnResLoaded(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGuardedNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsGuardedNpc(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LateUpdate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LateUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActorAttribute(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ActorAttributeData info = (xc.ActorAttributeData)translator.GetObject(L, 2, typeof(xc.ActorAttributeData));
                    
                    __cl_gen_to_be_invoked.SetActorAttribute( info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.UnitCacheInfo info = (xc.UnitCacheInfo)translator.GetObject(L, 2, typeof(xc.UnitCacheInfo));
                    Monster.CreateParam param = (Monster.CreateParam)translator.GetObject(L, 3, typeof(Monster.CreateParam));
                    
                    __cl_gen_to_be_invoked.OnCreate( info, param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAOIAttrElement(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgAttrElm> attr_element = (System.Collections.Generic.List<Net.PkgAttrElm>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgAttrElm>));
                    
                    __cl_gen_to_be_invoked.UpdateAOIAttrElement( attr_element );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModelLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetModelLayer(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetLayer(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetLayer(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSlotTransform(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string bone = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Transform __cl_gen_ret = __cl_gen_to_be_invoked.GetSlotTransform( bone );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetModel(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModelParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetModelParent(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayLastAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PlayLastAnimation(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayLastAnimation_real(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PlayLastAnimation_real(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAnimationOptions(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.EAnimation id;translator.Get(L, 2, out id);
                    
                        AnimationOptions __cl_gen_ret = __cl_gen_to_be_invoked.GetAnimationOptions( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWalkAniOptions(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        AnimationOptions __cl_gen_ret = __cl_gen_to_be_invoked.GetWalkAniOptions(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIdleAniOptions(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        AnimationOptions __cl_gen_ret = __cl_gen_to_be_invoked.GetIdleAniOptions(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<AnimationOptions>(L, 2)) 
                {
                    AnimationOptions op = (AnimationOptions)translator.GetObject(L, 2, typeof(AnimationOptions));
                    
                    __cl_gen_to_be_invoked.Play( op );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Actor.EAnimation>(L, 2)) 
                {
                    Actor.EAnimation state;translator.Get(L, 2, out state);
                    
                    __cl_gen_to_be_invoked.Play( state );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    float time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.Play( name, time );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.Play( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.Play!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlaySkillSound(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.PlaySkillSound( res_path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CrossFade(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<AnimationOptions>(L, 2)) 
                {
                    AnimationOptions op = (AnimationOptions)translator.GetObject(L, 2, typeof(AnimationOptions));
                    
                    __cl_gen_to_be_invoked.CrossFade( op );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.CrossFade( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.CrossFade!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimationSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float speed = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAnimationSpeed( speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoveSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.EAnimation type;translator.Get(L, 2, out type);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetMoveSpeed( type );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWalkSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetWalkSpeed(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMoveSpeedScale(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float speed_scale = (float)LuaAPI.lua_tonumber(L, 2);
                    float speed_add = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SetMoveSpeedScale( speed_scale, speed_add );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMoveAnimationSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float speed = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetMoveAnimationSpeed( speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAnimationLength(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetAnimationLength( name );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string ani_name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlaying( ani_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.IsPlaying!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInAnimationState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInAnimationState( ani );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani_name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasAnimation( ani_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginInteraction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string aniName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BeginInteraction( aniName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginJumpScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string aniName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BeginJumpScene( aniName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBeAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBeAttacking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDead(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsDead(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIdle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsIdle(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWalking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWalking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAttacking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGrounded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsGrounded(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Freeze(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint flag = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Freeze( flag );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float time = (float)LuaAPI.lua_tonumber(L, 2);
                    uint flag = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.Freeze( time, flag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.Freeze!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnFreeze(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UnFreeze(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Stop(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stand(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Stand(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                    __cl_gen_to_be_invoked.SetPosition( pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TurnDir(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                    __cl_gen_to_be_invoked.TurnDir( dir );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRotation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Quaternion rotation;translator.Get(L, 2, out rotation);
                    
                    __cl_gen_to_be_invoked.SetRotation( rotation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dst;translator.Get(L, 2, out dst);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.WalkTo( dst );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanMove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanMove(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkAlong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.WalkAlong( dir );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReachDst(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ReachDst(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveDirInAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.MoveDirInAttacking( dir );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkAlongStop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.WalkAlongStop(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Kill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Kill(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Relive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Relive(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Beattacked(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Damage dam = (xc.Damage)translator.GetObject(L, 2, typeof(xc.Damage));
                    
                    __cl_gen_to_be_invoked.Beattacked( dam );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMPEnough(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int mp = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMPEnough( mp );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Attack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Attack( skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSkillCastInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> skillList = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.SetSkillCastInfo( skillList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSkillCastInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uiSkillID = LuaAPI.xlua_touint(L, 2);
                    ushort rate = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.AddSkillCastInfo( uiSkillID, rate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillCount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillCastInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skillId = LuaAPI.xlua_touint(L, 2);
                    
                        Actor.SkillCastInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillCastInfo( skillId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillIDByIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        Actor.SkillCastInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillIDByIndex( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Skill skill = (xc.Skill)translator.GetObject(L, 2, typeof(xc.Skill));
                    
                    __cl_gen_to_be_invoked.SetCurSkill( skill );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Skill __cl_gen_ret = __cl_gen_to_be_invoked.GetCurSkill(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelfSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skillID = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Skill __cl_gen_ret = __cl_gen_to_be_invoked.GetSelfSkill( skillID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.Skill> __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInSkillActionEndingStage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInSkillActionEndingStage(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishCastingReadyStage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishCastingReadyStage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateBattleState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateBattleState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasBattleState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.BattleStatusType type;translator.Get(L, 2, out type);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasBattleState( type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanBeHited(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanBeHited(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanBeChoosed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanBeChoosed(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterFreezeState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterFreezeState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitFreezeState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitFreezeState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterDizzyState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterDizzyState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitDizzyState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitDizzyState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterSuperState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterSuperState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitSuperState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitSuperState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterChaosState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterChaosState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitChaosState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitChaosState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDamageEffectModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.AnimationEffect.ResInitData effectData = (xc.AnimationEffect.ResInitData)translator.GetObject(L, 2, typeof(xc.AnimationEffect.ResInitData));
                    
                    __cl_gen_to_be_invoked.ShowDamageEffectModel( effectData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShowDamageWord_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 1);
                    Actor defender = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = Actor.IsShowDamageWord( attacker_obj_idx, defender );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLocalPlayerCamp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLocalPlayerCamp(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoDamage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 2);
                    int iDamageValue = LuaAPI.xlua_tointeger(L, 3);
                    float fShowDelayTime = (float)LuaAPI.lua_tonumber(L, 4);
                    bool bCritic = LuaAPI.lua_toboolean(L, 5);
                    uint proto_damageEffectType = LuaAPI.xlua_touint(L, 6);
                    
                    __cl_gen_to_be_invoked.DoDamage( attacker_obj_idx, iDamageValue, fShowDelayTime, bCritic, proto_damageEffectType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDamageEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& translator.Assignable<xc.FightEffectHelp.FightEffectType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& (LuaAPI.lua_isnil(L, 6) || LuaAPI.lua_type(L, 6) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.FightEffectHelp.FightEffectType damageType;translator.Get(L, 2, out damageType);
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 3);
                    long value = LuaAPI.lua_toint64(L, 4);
                    bool show_percent = LuaAPI.lua_toboolean(L, 5);
                    string push_str = LuaAPI.lua_tostring(L, 6);
                    
                    __cl_gen_to_be_invoked.ShowDamageEffect( damageType, attacker_obj_idx, value, show_percent, push_str );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<xc.FightEffectHelp.FightEffectType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    xc.FightEffectHelp.FightEffectType damageType;translator.Get(L, 2, out damageType);
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 3);
                    long value = LuaAPI.lua_toint64(L, 4);
                    bool show_percent = LuaAPI.lua_toboolean(L, 5);
                    
                    __cl_gen_to_be_invoked.ShowDamageEffect( damageType, attacker_obj_idx, value, show_percent );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.FightEffectHelp.FightEffectType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isint64(L, 4))) 
                {
                    xc.FightEffectHelp.FightEffectType damageType;translator.Get(L, 2, out damageType);
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 3);
                    long value = LuaAPI.lua_toint64(L, 4);
                    
                    __cl_gen_to_be_invoked.ShowDamageEffect( damageType, attacker_obj_idx, value );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.FightEffectHelp.FightEffectType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.FightEffectHelp.FightEffectType damageType;translator.Get(L, 2, out damageType);
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowDamageEffect( damageType, attacker_obj_idx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.ShowDamageEffect!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetEffect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowBuffTip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buffID = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowBuffTip( buffID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTextBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowTextBehaviors( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTextName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowTextName( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHeadIcons(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.EHeadIcon icon_type;translator.Get(L, 2, out icon_type);
                    
                    __cl_gen_to_be_invoked.SetHeadIcons( icon_type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTeamIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowTeamIcon( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNameText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetNameText(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNameText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetNameText(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDialogBubble(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    int time = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowDialogBubble( text, time );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBindEffectInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string effect = LuaAPI.lua_tostring(L, 2);
                    DBBuffSev.BindPos bind_pos;translator.Get(L, 3, out bind_pos);
                    bool follow_target = LuaAPI.lua_toboolean(L, 4);
                    float scale = (float)LuaAPI.lua_tonumber(L, 5);
                    bool auto_scale = LuaAPI.lua_toboolean(L, 6);
                    int maxCount = LuaAPI.xlua_tointeger(L, 7);
                    
                        xc.BindEffectInfo __cl_gen_ret = __cl_gen_to_be_invoked.InitBindEffectInfo( effect, bind_pos, follow_target, scale, auto_scale, maxCount );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyTriggerEnter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Collider other = (UnityEngine.Collider)translator.GetObject(L, 2, typeof(UnityEngine.Collider));
                    
                    __cl_gen_to_be_invoked.NotifyTriggerEnter( other );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyTriggerExit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Collider other = (UnityEngine.Collider)translator.GetObject(L, 2, typeof(UnityEngine.Collider));
                    
                    __cl_gen_to_be_invoked.NotifyTriggerExit( other );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBattleTrigger(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnBattleTrigger(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActiveAI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ActiveAI( active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBoss(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBoss(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMonster(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMonster(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPet(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPet(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlayer(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsNpc(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsClientModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsClientModel(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBecomeVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool bVisible = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.OnBecomeVisible( bVisible );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBecomeNameVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnBecomeNameVisible(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePKIconImpl(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePKIconImpl(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNameStyle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateNameStyle(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNameLayoutVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetNameLayoutVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShemale(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsShemale( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateByBitState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong bitStates = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateByBitState( bitStates );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNameColor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint nameColor = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateNameColor( nameColor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanAttackOtherPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor target = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckCanAttackOtherPlayer( target );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSonActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor son = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                    __cl_gen_to_be_invoked.AddSonActor( son );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAIEnable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool enable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAIEnable( enable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAIEnable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GetAIEnable(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.AI __cl_gen_ret = __cl_gen_to_be_invoked.GetAI(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NeedUpdate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint flag = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.NeedUpdate( flag );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpdateFlag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint flag = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUpdateFlag( flag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.AI ai = (xc.AI)translator.GetObject(L, 2, typeof(xc.AI));
                    
                    __cl_gen_to_be_invoked.SetAI( ai );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeActorEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.ActorEvent eEvent;translator.Get(L, 2, out eEvent);
                    EventCtrl.EventProcessFunc kFunc = translator.GetDelegate<EventCtrl.EventProcessFunc>(L, 3);
                    
                    __cl_gen_to_be_invoked.SubscribeActorEvent( eEvent, kFunc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnsubscribeActorEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.ActorEvent eEvent;translator.Get(L, 2, out eEvent);
                    EventCtrl.EventProcessFunc kFunc = translator.GetDelegate<EventCtrl.EventProcessFunc>(L, 3);
                    
                    __cl_gen_to_be_invoked.UnsubscribeActorEvent( eEvent, kFunc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnsubscribeAllActorEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.ActorEvent eEvent;translator.Get(L, 2, out eEvent);
                    
                    __cl_gen_to_be_invoked.UnsubscribeAllActorEvent( eEvent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FireActorEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.ActorEvent eEvent;translator.Get(L, 2, out eEvent);
                    CEventBaseArgs data = (CEventBaseArgs)translator.GetObject(L, 3, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.FireActorEvent( eEvent, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAvatarParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector3 local_scale;translator.Get(L, 3, out local_scale);
                    UnityEngine.Vector3 local_pos;translator.Get(L, 4, out local_pos);
                    UnityEngine.Vector3 local_eulerAngles;translator.Get(L, 5, out local_eulerAngles);
                    
                    __cl_gen_to_be_invoked.SetAvatarParent( parent, local_scale, local_pos, local_eulerAngles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsUIModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsUIModel(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsDestroy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsDestroy);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gameObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.gameObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.transform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_collider(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.collider);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPlayingAnimation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPlayingAnimation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveDir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.MoveDir);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.MoveSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorMachine(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ActorMachine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForwardDir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ForwardDir);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DisableMoveState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.DisableMoveState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShapeShift(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShapeShift);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShiftState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ShiftState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShapeProcessing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShapeProcessing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WarTag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.WarTag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.AttackSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Camp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Camp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsActorInvisiable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsActorInvisiable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNoStrike(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNoStrike);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsActorBeattackDisable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsActorBeattackDisable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFreezeState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsFreezeState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HPProgressBarIsActive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HPProgressBarIsActive);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreateParamInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CreateParamInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VocationID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.PushActorEVocationType(L, __cl_gen_to_be_invoked.VocationID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorAttribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ActorAttribute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NormalAttackID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NormalAttackID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorTrans(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ActorTrans);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WalkMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.PushxcActorMachineEWalkMode(L, __cl_gen_to_be_invoked.WalkMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DestList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DestList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsHaveSonActors(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsHaveSonActors);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SvrId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SvrId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ParentActor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ParentActor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InBattleStatus(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.InBattleStatus);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OverridingName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.OverridingName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Height);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CharacterHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.CharacterHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HpPercent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.HpPercent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurLife(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.CurLife);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FullLife(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.FullLife);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.CurMp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FullMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.FullMp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UserName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MonsterSpecName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.MonsterSpecName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TitleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TitleId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeIdx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TypeIdx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActorId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TeamId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EscortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EscortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Honor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Title);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TransferLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GuildId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GuildName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OverridingTargetName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.OverridingTargetName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NameColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NameColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BitStates(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.BitStates);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SonActors(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SonActors);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsResLoaded(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsResLoaded);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BuffCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BuffCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoUpdate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NoUpdate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkillEffectPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SkillEffectPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StateEffectPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StateEffectPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveImplement(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MoveImplement);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnitType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnitType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FSM(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FSM);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Trans(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Trans);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AnimationCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AnimationCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurSelectActor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurSelectActor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanBeInterruptedWhenInInteractionAndBeAttacked(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanBeInterruptedWhenInInteractionAndBeAttacked);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLocalPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsLocalPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInSafeArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInSafeArea);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WildState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.PushActorEWildState(L, __cl_gen_to_be_invoked.WildState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MountId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MateInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateUuid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MateUuid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.MateName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mEventCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mEventCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MoveCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AttackCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BeattackedCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BeattackedCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CDCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CDCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_MatEffectCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_MatEffectCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mRideCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mRideCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mAvatarCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mAvatarCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mVisibleCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mVisibleCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PKLvProtect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PKLvProtect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoveSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttackSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttackSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Camp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Camp = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Alpha(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Alpha = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HPProgressBarIsActive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HPProgressBarIsActive = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VocationID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                Actor.EVocationType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.VocationID = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActorAttribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActorAttribute = (xc.ActorAttributeData)translator.GetObject(L, 2, typeof(xc.ActorAttributeData));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ParentActor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ParentActor = (Actor)translator.GetObject(L, 2, typeof(Actor));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InBattleStatus(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InBattleStatus = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OverridingName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OverridingName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurLife(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurLife = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FullLife(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FullLife = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurMp = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FullMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FullMp = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UserName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UserName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MonsterSpecName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MonsterSpecName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TitleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TitleId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TransferLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OverridingTargetName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OverridingTargetName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NameColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NameColor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoUpdate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NoUpdate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UID = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanBeInterruptedWhenInInteractionAndBeAttacked(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanBeInterruptedWhenInInteractionAndBeAttacked = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsInSafeArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsInSafeArea = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WildState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                Actor.EWildState __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.WildState = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MountId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MateInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MateInfo = (Net.PkgMateInfo)translator.GetObject(L, 2, typeof(Net.PkgMateInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mEventCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mEventCtrl = (EventCtrl)translator.GetObject(L, 2, typeof(EventCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoveCtrl = (xc.MoveCtrl)translator.GetObject(L, 2, typeof(xc.MoveCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttackCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttackCtrl = (xc.AttackCtrl)translator.GetObject(L, 2, typeof(xc.AttackCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BeattackedCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BeattackedCtrl = (xc.BeattackedCtrl)translator.GetObject(L, 2, typeof(xc.BeattackedCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CDCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CDCtrl = (xc.CooldownCtrl)translator.GetObject(L, 2, typeof(xc.CooldownCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_MatEffectCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_MatEffectCtrl = (xc.MaterialEffectCtrl)translator.GetObject(L, 2, typeof(xc.MaterialEffectCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mRideCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mRideCtrl = (xc.RideCtrl)translator.GetObject(L, 2, typeof(xc.RideCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mAvatarCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mAvatarCtrl = (xc.AvatarCtrl)translator.GetObject(L, 2, typeof(xc.AvatarCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mVisibleCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mVisibleCtrl = (xc.VisibleCtrl)translator.GetObject(L, 2, typeof(xc.VisibleCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PKLvProtect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor __cl_gen_to_be_invoked = (Actor)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PKLvProtect = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
