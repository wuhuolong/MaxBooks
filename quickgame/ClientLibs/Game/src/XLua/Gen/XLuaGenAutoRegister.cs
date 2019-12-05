#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter((luaenv, translator) => {
			    
				translator.DelayWrapLoader(typeof(Couple), CoupleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaMonoBehaviour), LuaMonoBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Game), xcGameWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Game.EGameMode), xcGameEGameModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.DateTime), SystemDateTimeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.ValueType), SystemValueTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.RectTransform), UnityEngineRectTransformWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.RectTransform.Axis), UnityEngineRectTransformAxisWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.RectTransform.Edge), UnityEngineRectTransformEdgeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.WWW), UnityEngineWWWWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Application), UnityEngineApplicationWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.RuntimePlatform), UnityEngineRuntimePlatformWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Enum), SystemEnumWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Type), SystemTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Animation), UnityEngineAnimationWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngineAsyncOperationWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AssetBundle), UnityEngineAssetBundleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Texture), UnityEngineTextureWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Animator), UnityEngineAnimatorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AnimatorCullingMode), UnityEngineAnimatorCullingModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Texture2D), UnityEngineTexture2DWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Texture2D.EXRFlags), UnityEngineTexture2DEXRFlagsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Events.UnityEvent), UnityEngineEventsUnityEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.SystemInfo), UnityEngineSystemInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<uint>), SystemCollectionsGenericList_1_SystemUInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<uint>.Enumerator), SystemCollectionsGenericList_1Enumerator_SystemUInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>), SystemCollectionsGenericList_1_SystemCollectionsGenericList_1_SystemUInt32__Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<string>), SystemCollectionsGenericList_1_SystemString_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<string>.Enumerator), SystemCollectionsGenericList_1Enumerator_SystemString_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<System.Collections.Generic.List<string>>), SystemCollectionsGenericList_1_SystemCollectionsGenericList_1_SystemString__Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, uint>), SystemCollectionsGenericDictionary_2_SystemUInt32SystemUInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, uint>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32SystemUInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Machine), xcMachineWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Machine.State), xcMachineStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GameDebug), GameDebugWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DBOSManager), DBOSManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Net.NetClient), NetNetClientWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Net.NetClient.MutiPacketHelp), NetNetClientMutiPacketHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Net.NetClient.NetCoreHeader), NetNetClientNetCoreHeaderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Net.NetClient.ENetState), NetNetClientENetStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Net.NetClient.IListener), NetNetClientIListenerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NetworkManager), xcNetworkManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ClientEventMgr), ClientEventMgrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientEventParamArgs), xcClientEventParamArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(CEventBaseArgs), CEventBaseArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(CEventEventParamArgs), CEventEventParamArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DebugProfile), xcDebugProfileWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ObjCachePoolMgr), xcObjCachePoolMgrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ObjCachePoolType), xcObjCachePoolTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PoolGameObject), xcPoolGameObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(SGameEngine.AssetResource), SGameEngineAssetResourceWrap.__Register);
				
				translator.DelayWrapLoader(typeof(SGameEngine.ResourceLoader), SGameEngineResourceLoaderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CommonTool), xcCommonToolWrap.__Register);
				
				translator.DelayWrapLoader(typeof(IBridge), IBridgeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaTestMgr), LuaTestMgrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GlobalConst), xcGlobalConstWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ControlServerLogHelper), xcControlServerLogHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PlayerFollowRecordSceneId), xcPlayerFollowRecordSceneIdWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ChannelHelper), xcChannelHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AuditManager), xcAuditManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.LocalizeManager), xcLocalizeManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.UserPlayerPrefs), xcUserPlayerPrefsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(HttpRequest), HttpRequestWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Utils.Timer), UtilsTimerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GameInput), xcGameInputWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GameInput.HandScaleDistinguish), xcGameInputHandScaleDistinguishWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UtilHtml), UtilHtmlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PingTime), xcPingTimeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientEventStringArgs), xcClientEventStringArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(AnimatorSpeed), AnimatorSpeedWrap.__Register);
				
				translator.DelayWrapLoader(typeof(TrackAnimationComponent), TrackAnimationComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GlobalSettings), xcGlobalSettingsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(BatteryUpdate), BatteryUpdateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DateHelper), DateHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClassConstructHelper), xcClassConstructHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EnumUtil), xcEnumUtilWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientEventBaseArgs), xcClientEventBaseArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientEventUintArgs), xcClientEventUintArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientEvent), xcClientEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GlobalConfig), xcGlobalConfigWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GlobalConfig.LoginInfoStruct), xcGlobalConfigLoginInfoStructWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DebugCommand), xcDebugCommandWrap.__Register);
				
				translator.DelayWrapLoader(typeof(TextHelper), TextHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TextHelper), xcTextHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PhysicsHelp), xcPhysicsHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DelayDestroyComponent), DelayDestroyComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(CameraControl), CameraControlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(CameraControl.EMode), CameraControlEModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(XLua.LuaTable), XLuaLuaTableWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Utils.AES), UtilsAESWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.LuaUtility), xcLuaUtilityWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.LuaSqliteUtility), xcLuaSqliteUtilityWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBManager), xcDBManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBManager.ColumnInfo), xcDBManagerColumnInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBManager.SqliteCache), xcDBManagerSqliteCacheWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBManager.DBBase), xcDBManagerDBBaseWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBManager.CommandTag), xcDBManagerCommandTagWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTextResource), xcDBTextResourceWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTextResource.DBAttrItem), xcDBTextResourceDBAttrItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTextResource.DBGoodsItem), xcDBTextResourceDBGoodsItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstance), xcDBInstanceWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstance.InstanceInfo), xcDBInstanceInstanceInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBReward), xcDBRewardWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBReward.RewardInfo), xcDBRewardRewardInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBErrorCode), xcDBErrorCodeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBErrorCode.ErrorInfo), xcDBErrorCodeErrorInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBNotice), xcDBNoticeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBNotice.Notice), xcDBNoticeNoticeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBNotice.EFillType), xcDBNoticeEFillTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBConstText), xcDBConstTextWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GameConstHelper), xcGameConstHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDataAllSkill), xcDBDataAllSkillWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos), xcDBDataAllSkillOneVocationActiveSkillInfosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDataAllSkill.AllSkillInfo), xcDBDataAllSkillAllSkillInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), xcDBDataAllSkillSET_SLOT_TYPEWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDataAllSkill.SKILL_TYPE), xcDBDataAllSkillSKILL_TYPEWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DBBuffSev), DBBuffSevWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DBBuffSev.DBBuffInfo), DBBuffSevDBBuffInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DBBuffSev.BindPos), DBBuffSevBindPosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBWorldBoss), xcDBWorldBossWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBWorldBoss.DBWorldBossItem), xcDBWorldBossDBWorldBossItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBWorldBoss.DBWorldBossRewardItem), xcDBWorldBossDBWorldBossRewardItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstancePhase), xcDBInstancePhaseWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstancePhase.InstancePhaseInfo), xcDBInstancePhaseInstancePhaseInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildLv), xcDBGuildLvWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildLv.DBGuildLvItem), xcDBGuildLvDBGuildLvItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildDuty), xcDBGuildDutyWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildDuty.DBGuildDutyItem), xcDBGuildDutyDBGuildDutyItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildBoss), xcDBGuildBossWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildBoss.DBGuildBossStatisticItem), xcDBGuildBossDBGuildBossStatisticItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildBoss.DBGuildBossItem), xcDBGuildBossDBGuildBossItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildBoss.DBGuildBossRewardItem), xcDBGuildBossDBGuildBossRewardItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildTotem), xcDBGuildTotemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildTotem.DBGuildTotemItem), xcDBGuildTotemDBGuildTotemItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDeadSpaceLv), xcDBDeadSpaceLvWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDeadSpaceLv.DeadSpaceLvInfo), xcDBDeadSpaceLvDeadSpaceLvInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGrowSkin), xcDBGrowSkinWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGrowSkin.DBGrowSkinItem), xcDBGrowSkinDBGrowSkinItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGrowSkin.SkinUnLockType), xcDBGrowSkinSkinUnLockTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBHang), xcDBHangWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBVocationInfo), xcDBVocationInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBHonor), xcDBHonorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBHonor.DBHonorItem), xcDBHonorDBHonorItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuit), xcDBSuitWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuit.DBSuitInfo), xcDBSuitDBSuitInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuitAttr), xcDBSuitAttrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuitAttr.DBSuitAttrInfo), xcDBSuitAttrDBSuitAttrInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuitRefine), xcDBSuitRefineWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSuitRefine.DBSuitRefineItem), xcDBSuitRefineDBSuitRefineItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTitle), xcDBTitleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTitle.DBTitleItem), xcDBTitleDBTitleItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBAvatarPart), xcDBAvatarPartWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBAvatarPart.Data), xcDBAvatarPartDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBAvatarPart.BODY_PART), xcDBAvatarPartBODY_PARTWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSpecialMon), xcDBSpecialMonWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSpecialMon.DBSpecialMonItem), xcDBSpecialMonDBSpecialMonItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstanceTypeControl), xcDBInstanceTypeControlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBInstanceTypeControl.InstanceTypeInfo), xcDBInstanceTypeControlInstanceTypeInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSystemToggle), xcDBSystemToggleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSystemToggle.SystemToggle), xcDBSystemToggleSystemToggleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBActor), xcDBActorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBActor.ActorData), xcDBActorActorDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMallType), xcDBMallTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMallType.DBMallTypeItem), xcDBMallTypeDBMallTypeItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGemHole), xcDBGemHoleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGemHole.GemHoleInfo), xcDBGemHoleGemHoleInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGem), xcDBGemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGem.GemInfo), xcDBGemGemInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet), xcDBPetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet.PetInfo), xcDBPetPetInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet.UnLockPrePetCondition), xcDBPetUnLockPrePetConditionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet.UnLockGoodsCondition), xcDBPetUnLockGoodsConditionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet.PetSkillItem), xcDBPetPetSkillItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPet.PetUnLockType), xcDBPetPetUnLockTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildSkill), xcDBGuildSkillWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildSkill.DBGuildSkillItem), xcDBGuildSkillDBGuildSkillItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBGuildSkill.DBCommonAttrItem), xcDBGuildSkillDBCommonAttrItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBRedPoint), xcDBRedPointWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBRedPoint.DBRedPointItem), xcDBRedPointDBRedPointItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTaskGuide), xcDBTaskGuideWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTaskGuide.TaskGuideInfo), xcDBTaskGuideTaskGuideInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysConfig), xcDBSysConfigWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysConfig.SysConfig), xcDBSysConfigSysConfigWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysConfig.ESysBtnFixType), xcDBSysConfigESysBtnFixTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysConfig.ESysBtnPos), xcDBSysConfigESysBtnPosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysConfig.ESysTaskType), xcDBSysConfigESysTaskTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysPreview), xcDBSysPreviewWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBSysPreview.DBSysPreviewInfo), xcDBSysPreviewDBSysPreviewInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDecorate), xcDBDecorateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDecorate.LegendAttrDescItem), xcDBDecorateLegendAttrDescItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDecorate.DBDecorateItem), xcDBDecorateDBDecorateItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDecoratePos), xcDBDecoratePosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBDecoratePos.DBDecoratePosItem), xcDBDecoratePosDBDecoratePosItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBStigma), xcDBStigmaWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBStigma.DBStigmaInfo), xcDBStigmaDBStigmaInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBStigma.DBStigmaSkillItemSkillItem), xcDBStigmaDBStigmaSkillItemSkillItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMap), xcDBMapWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMap.MapInfo), xcDBMapMapInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBEquipPos), xcDBEquipPosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBEquipPos.DBEquipPosItem), xcDBEquipPosDBEquipPosItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBEquipPos.EquipPosType), xcDBEquipPosEquipPosTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeGroove), xcDBBaptizeGrooveWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo), xcDBBaptizeGrooveDBBaptizeGrooveInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeColorPool), xcDBBaptizeColorPoolWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo), xcDBBaptizeColorPoolDBBaptizeColorPoolInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeAttrStandard), xcDBBaptizeAttrStandardWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo), xcDBBaptizeAttrStandardDBBaptizeAttrStandardInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeCost), xcDBBaptizeCostWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBBaptizeCost.DBBaptizeCostInfo), xcDBBaptizeCostDBBaptizeCostInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMagic), xcDBMagicWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMagic.DBMagicItem), xcDBMagicDBMagicItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMagicEquip), xcDBMagicEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBMagicEquip.DBMagicEquipItem), xcDBMagicEquipDBMagicEquipItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBShemale), xcDBShemaleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBShemale.ShemaleInfo), xcDBShemaleShemaleInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPetFetter), xcDBPetFetterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPetFetter.DBPetFetterItem), xcDBPetFetterDBPetFetterItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBPetFetter.FetterSkillItem), xcDBPetFetterFetterSkillItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Buff), xcBuffWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Buff.BuffInfo), xcBuffBuffInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Buff.BuffFlags), xcBuffBuffFlagsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CooldownManager), xcCooldownManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RockCommandSystem), xcRockCommandSystemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RockCommandSystem.Command), xcRockCommandSystemCommandWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RockCommandSystem.ClickRockButtonTipsType), xcRockCommandSystemClickRockButtonTipsTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BuffCtrl), xcBuffCtrlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(SkillBaseComponent), SkillBaseComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(AnimationController), AnimationControllerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(AnimationController.CallBackInfo), AnimationControllerCallBackInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EffectManager), xcEffectManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EffectEmitter), xcEffectEmitterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BuffImageLoader), xcBuffImageLoaderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SkillManager), xcSkillManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.UnitID), xcUnitIDWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor), ActorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.DamageEffect), ActorDamageEffectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.SkillCastInfo), ActorSkillCastInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.EHeadIcon), ActorEHeadIconWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.EVocationType), ActorEVocationTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.ActorEvent), ActorActorEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.EAnimation), ActorEAnimationWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.SlotBoneNameType), ActorSlotBoneNameTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.EWildState), ActorEWildStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.DamageValueItem), ActorDamageValueItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Actor.SlotBoneItemData), ActorSlotBoneItemDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Player), PlayerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster), MonsterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster.MonsterSpawnType), MonsterMonsterSpawnTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster.MonsterType), MonsterMonsterTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster.BeSummonType), MonsterBeSummonTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster.CreateParam), MonsterCreateParamWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Monster.QualityColor), MonsterQualityColorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(NpcPlayer), NpcPlayerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ClientModel), xcClientModelWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.WorshipModel), xcWorshipModelWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.VocationInfo), xcVocationInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MoveCtrl), xcMoveCtrlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MoveCtrl.MoveStep), xcMoveCtrlMoveStepWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MoveCtrl.EActorStepType), xcMoveCtrlEActorStepTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorMachine), xcActorMachineWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorMachine.DeathInfo), xcActorMachineDeathInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorMachine.EWalkMode), xcActorMachineEWalkModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorMachine.EFSMEvent), xcActorMachineEFSMEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorMachine.EFSMState), xcActorMachineEFSMStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorHelper), xcActorHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NpcManager), xcNpcManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NpcHelper), xcNpcHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NpcDefine), xcNpcDefineWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NpcDefine.EFunction), xcNpcDefineEFunctionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.NpcDefine.ELightMode), xcNpcDefineELightModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(NpcScenePosition), NpcScenePositionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorManager), xcActorManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorManager.CreateInfo), xcActorManagerCreateInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorAttribute), xcActorAttributeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ActorAttributeData), xcActorAttributeDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DefaultActorAttribute), xcDefaultActorAttributeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.IActorAttribute), xcIActorAttributeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RoleHelp), xcRoleHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AvatarCtrl), xcAvatarCtrlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AvatarCtrl.FlyActorItem), xcAvatarCtrlFlyActorItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AvatarProperty), xcAvatarPropertyWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ModelHelper), xcModelHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.LocalPlayerManager), xcLocalPlayerManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(SafeInteger), SafeIntegerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Canvas), UnityEngineCanvasWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.CanvasGroup), UnityEngineCanvasGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Button), UnityEngineUIButtonWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Button.ButtonClickedEvent), UnityEngineUIButtonButtonClickedEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle), UnityEngineUIToggleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle.ToggleEvent), UnityEngineUIToggleToggleEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle.ToggleTransition), UnityEngineUIToggleToggleTransitionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ToggleGroup), UnityEngineUIToggleGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider), UnityEngineUISliderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider.SliderEvent), UnityEngineUISliderSliderEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider.Direction), UnityEngineUISliderDirectionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image), UnityEngineUIImageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.Origin360), UnityEngineUIImageOrigin360Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.Origin180), UnityEngineUIImageOrigin180Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.Origin90), UnityEngineUIImageOrigin90Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.OriginVertical), UnityEngineUIImageOriginVerticalWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.OriginHorizontal), UnityEngineUIImageOriginHorizontalWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.FillMethod), UnityEngineUIImageFillMethodWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Image.Type), UnityEngineUIImageTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.RawImage), UnityEngineUIRawImageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Sprite), UnityEngineSpriteWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Text), UnityEngineUITextWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.TextAnchor), UnityEngineTextAnchorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField), UnityEngineUIInputFieldWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.OnChangeEvent), UnityEngineUIInputFieldOnChangeEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.SubmitEvent), UnityEngineUIInputFieldSubmitEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.LineType), UnityEngineUIInputFieldLineTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.CharacterValidation), UnityEngineUIInputFieldCharacterValidationWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.InputType), UnityEngineUIInputFieldInputTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.ContentType), UnityEngineUIInputFieldContentTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect), UnityEngineUIScrollRectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent), UnityEngineUIScrollRectScrollRectEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), UnityEngineUIScrollRectScrollbarVisibilityWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect.MovementType), UnityEngineUIScrollRectMovementTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutRebuilder), UnityEngineUILayoutRebuilderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.VerticalLayoutGroup), UnityEngineUIVerticalLayoutGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalLayoutGroup), UnityEngineUIHorizontalLayoutGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup), UnityEngineUIGridLayoutGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), UnityEngineUIGridLayoutGroupConstraintWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup.Axis), UnityEngineUIGridLayoutGroupAxisWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup.Corner), UnityEngineUIGridLayoutGroupCornerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), UnityEngineUIHorizontalOrVerticalLayoutGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ContentSizeFitter), UnityEngineUIContentSizeFitterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), UnityEngineUIContentSizeFitterFitModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown), UnityEngineUIDropdownWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.DropdownEvent), UnityEngineUIDropdownDropdownEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.OptionDataList), UnityEngineUIDropdownOptionDataListWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.OptionData), UnityEngineUIDropdownOptionDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.EventSystems.EventTriggerType), UnityEngineEventSystemsEventTriggerTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.UI.Extensions.UIFlippable), UnityEngineUIExtensionsUIFlippableWrap.__Register);
				
				translator.DelayWrapLoader(typeof(AutoScale), AutoScaleWrap.__Register);
				
				translator.DelayWrapLoader(typeof(AutoScale.ScaleMode), AutoScaleScaleModeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.TweenAlpha), xcuiuguiTweenAlphaWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.TweenPosition), xcuiuguiTweenPositionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.TweenAnchoredPosition), xcuiuguiTweenAnchoredPositionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.TweenCircleAnchoredPosition), xcuiuguiTweenCircleAnchoredPositionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.TweenScrollNormalizedPosition), xcuiuguiTweenScrollNormalizedPositionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaDragComponent), LuaDragComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(SliderLimit), SliderLimitWrap.__Register);
				
				translator.DelayWrapLoader(typeof(EmojiText), EmojiTextWrap.__Register);
				
				translator.DelayWrapLoader(typeof(EmojiText.EmojiMaterialType), EmojiTextEmojiMaterialTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIJoystick), xcuiUIJoystickWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIMainmapJoystick), xcuiUIMainmapJoystickWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIRollNumWidget), UIRollNumWidgetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DynamicScorll), DynamicScorllWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DynamicScorll.ItemInfo), DynamicScorllItemInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.EventTriggerListener), xcuiuguiEventTriggerListenerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ScrollViewEx), ScrollViewExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ScrollPagePoint), ScrollPagePointWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ScrollPage), ScrollPageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EcanConvertToCh), xcEcanConvertToChWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ComTouchPress), ComTouchPressWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UINewLockCDSlot), xcuiUINewLockCDSlotWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIItemRef), xcuiUIItemRefWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIItemNewSlot), xcuiUIItemNewSlotWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIItemNewSlot.TypeParse), xcuiUIItemNewSlotTypeParseWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ClickLimit), xcuiClickLimitWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ContentImmediate), ContentImmediateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIBuffUpdate), UIBuffUpdateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UI3DText), UI3DTextWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UI3DText.StyleInfo), UI3DTextStyleInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.RedPoint), xcuiRedPointWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.LockIcon), xcuiLockIconWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.LockIcon.State), xcuiLockIconStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(WWWLoadImage), WWWLoadImageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIMainMapAnimationBehaviour), xcuiuguiUIMainMapAnimationBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIPreviewTexture), UIPreviewTextureWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIPreviewModel), UIPreviewModelWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.UINotice), xcUINoticeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.UIPhotoFrameWidget), xcUIPhotoFrameWidgetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.UIChatBubbleWidget), xcUIChatBubbleWidgetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UILockCDSlot), xcuiUILockCDSlotWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GreyMaterialComponent), GreyMaterialComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(TargetModelInfo), TargetModelInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.SliderEx), xcuiuguiSliderExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.ToggleEx), xcuiuguiToggleExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(RandomObjectEmitter), RandomObjectEmitterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIHandBookItemSlot), xcuiUIHandBookItemSlotWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LongTimePress), LongTimePressWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIVisibleControlComponent), UIVisibleControlComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIManager), xcuiuguiUIManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIManager.RefreshOrder), xcuiuguiUIManagerRefreshOrderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIBaseWindow), xcuiuguiUIBaseWindowWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIBaseWindow.BackupWin), xcuiuguiUIBaseWindowBackupWinWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), xcuiuguiUIBaseWindowCloseWinsTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UILuaBaseWindow), xcuiuguiUILuaBaseWindowWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.IUIBehaviour), xcuiuguiIUIBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIType), xcuiuguiUITypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UIHelper), xcuiuguiUIHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIWidgetHelp), xcuiUIWidgetHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.UIWidgetHelp.DragDropGroup), xcuiUIWidgetHelpDragDropGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UILuaBehaviour), xcuiuguiUILuaBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UILoadingWindow), xcuiuguiUILoadingWindowWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RouterManager), xcRouterManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UINoticeWindow), xcuiuguiUINoticeWindowWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.UINoticeWindow.EWindowType), xcuiuguiUINoticeWindowEWindowTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<ClientEventMgr>), xcSingleton_1_ClientEventMgr_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.DBManager>), xcSingleton_1_xcDBManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.LocalPlayerManager>), xcSingleton_1_xcLocalPlayerManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.SysConfigManager>), xcSingleton_1_xcSysConfigManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.RouterManager>), xcSingleton_1_xcRouterManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.TimelineManager>), xcSingleton_1_xcTimelineManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.ui.ugui.UIManager>), xcSingleton_1_xcuiuguiUIManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.InstanceManager>), xcSingleton_1_xcInstanceManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.PKModeManagerEx>), xcSingleton_1_xcPKModeManagerEx_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.GlobalConfig>), xcSingleton_1_xcGlobalConfig_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.GlobalSettings>), xcSingleton_1_xcGlobalSettings_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.SceneHelp>), xcSingleton_1_xcSceneHelp_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.HookSettingManager>), xcSingleton_1_xcHookSettingManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.TaskManager>), xcSingleton_1_xcTaskManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.WaterWaveEffect>), xcSingleton_1_xcWaterWaveEffect_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.GameInput>), xcSingleton_1_xcGameInput_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.ControlServerLogHelper>), xcSingleton_1_xcControlServerLogHelper_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.Dungeon.CollectionObjectManager>), xcSingleton_1_xcDungeonCollectionObjectManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.Dungeon.OrdinaryObjectManager>), xcSingleton_1_xcDungeonOrdinaryObjectManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.Dungeon.ColliderObjectManager>), xcSingleton_1_xcDungeonColliderObjectManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.Dungeon.DoorObjectManager>), xcSingleton_1_xcDungeonDoorObjectManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.NpcManager>), xcSingleton_1_xcNpcManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.GuideManager>), xcSingleton_1_xcGuideManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.PingTime>), xcSingleton_1_xcPingTime_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.TeamManager>), xcSingleton_1_xcTeamManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.UINotice>), xcSingleton_1_xcUINotice_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.SkillHoleManager>), xcSingleton_1_xcSkillHoleManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(Uranus.Runtime.Singleton<Uranus.Runtime.UranusManager>), UranusRuntimeSingleton_1_UranusRuntimeUranusManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.Dungeon.LevelManager>), xcSingleton_1_xcDungeonLevelManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.MarryManager>), xcSingleton_1_xcMarryManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Singleton<xc.SkillManager>), xcSingleton_1_xcSkillManager_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<xc.UnitID, Actor>), SystemCollectionsGenericDictionary_2_xcUnitIDActor_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<xc.UnitID, Actor>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_xcUnitIDActor_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsSoul>), SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsSoul>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcGoodsSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsGodEquip>), SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsGodEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsGodEquip>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcGoodsGodEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsElementEquip>), SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsElementEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsElementEquip>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcGoodsElementEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsMountEquip>), SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsMountEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsMountEquip>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcGoodsMountEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>), SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsLightWeaponSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcGoodsLightWeaponSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.EquipPosInfo>), SystemCollectionsGenericList_1_xcEquipPosInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.EquipPosInfo>.Enumerator), SystemCollectionsGenericList_1Enumerator_xcEquipPosInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>), SystemCollectionsGenericDictionary_2_SystemUInt64xcGoodsEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt64xcGoodsEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>), SystemCollectionsGenericKeyValuePair_2_SystemUInt64xcGoodsEquip_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.Goods>), SystemCollectionsGenericList_1_xcGoods_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>), SystemCollectionsGenericDictionary_2_SystemUInt64xcGoods_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt64xcGoods_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.GoodsSoul>), SystemCollectionsGenericList_1_xcGoodsSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.GoodsSoul>.Enumerator), SystemCollectionsGenericList_1Enumerator_xcGoodsSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.GoodsLightWeaponSoul>), SystemCollectionsGenericList_1_xcGoodsLightWeaponSoul_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBTextResource.DBGoodsItem>), SystemCollectionsGenericList_1_xcDBTextResourceDBGoodsItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.Equip.EquipHelper.AttributeDescItem>), SystemCollectionsGenericList_1_xcEquipEquipHelperAttributeDescItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBDataAllSkill.AllSkillInfo>), SystemCollectionsGenericList_1_xcDBDataAllSkillAllSkillInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBPet.PetInfo>), SystemCollectionsGenericList_1_xcDBPetPetInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>), SystemCollectionsGenericList_1_xcDBGrowSkinDBGrowSkinItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBStigma.DBStigmaInfo>), SystemCollectionsGenericList_1_xcDBStigmaDBStigmaInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>), SystemCollectionsGenericDictionary_2_SystemUInt32xcDBTitleDBTitleItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcDBTitleDBTitleItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>), SystemCollectionsGenericList_1_xcDBTextResourceDBAttrItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>.Enumerator), SystemCollectionsGenericList_1Enumerator_xcDBTextResourceDBAttrItem_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.Task>), SystemCollectionsGenericList_1_xcTask_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.ActorAttribute>), SystemCollectionsGenericDictionary_2_SystemUInt32xcActorAttribute_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.Dictionary<uint, xc.ActorAttribute>.Enumerator), SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcActorAttribute_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsItem), xcGoodsItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsSoul), xcGoodsSoulWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Goods), xcGoodsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsLuaEx), xcGoodsLuaExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ItemManager), xcItemManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ItemManager.TmpGetGoods), xcItemManagerTmpGetGoodsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsHelper), xcGoodsHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsHelper.ColorQualityItem), xcGoodsHelperColorQualityItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsHelper.ItemMainType), xcGoodsHelperItemMainTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsCompositeData), xcGoodsCompositeDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsCompositeStuffData), xcGoodsCompositeStuffDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BagConditionHelper), xcBagConditionHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskManager), xcTaskManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BountyTaskInfo), xcBountyTaskInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GuildTaskInfo), xcGuildTaskInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskHelper), xcTaskHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskNet), xcTaskNetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Task), xcTaskWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Task.StepProgress), xcTaskStepProgressWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskDefine), xcTaskDefineWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskDefine.TaskStep), xcTaskDefineTaskStepWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TaskDefine.EAutoRunType), xcTaskDefineEAutoRunTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TargetPathManager), xcTargetPathManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBTask), xcDBTaskWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SensitiveWordsFilter), xcSensitiveWordsFilterWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ChatItem), xcChatItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ChatHelper), xcChatHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ChatNoticeInfo), xcChatNoticeInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ChatVoicePressCtrl), ChatVoicePressCtrlWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.VoiceManager), xcVoiceManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.VoiceControlComponent), xcVoiceControlComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.VoiceControlComponent.State), xcVoiceControlComponentStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TeamManager), xcTeamManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TeamHelper), xcTeamHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(MiniMapHelp), MiniMapHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EquipSuitInfo), xcEquipSuitInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsEquip), xcGoodsEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.EquipHelper), xcEquipEquipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.EquipHelper.AttributeDescItem), xcEquipEquipHelperAttributeDescItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.EquipHelper.EquipEffectWashSelectData), xcEquipEquipHelperEquipEffectWashSelectDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.EquipAttributes), xcEquipEquipAttributesWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.DefaultAttribute), xcEquipDefaultAttributeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Equip.IEquipAttribute), xcEquipIEquipAttributeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EquipModData), xcEquipModDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EquipPosInfo), xcEquipPosInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EquipBaptizeInfo), xcEquipBaptizeInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EquipBaptizeInfo.EquipBaptizeState), xcEquipBaptizeInfoEquipBaptizeStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.Equip.IEquipAttribute>), SystemCollectionsGenericList_1_xcEquipIEquipAttribute_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendsInfo), xcFriendsInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.InteractiveType), xcInteractiveTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendType), xcFriendTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendsManager), xcFriendsManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendsNet), xcFriendsNetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendShipInfo), xcFriendShipInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.FriendsHelper), xcFriendsHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MailHelper), xcMailHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MailNet), xcMailNetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MailManager2), xcMailManager2Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MailInfo), xcMailInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MailInfo.JumpType), xcMailInfoJumpTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Money), xcMoneyWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SysConfigManager), xcSysConfigManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GuideManager), xcGuideManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GuideHelper), xcGuideHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SysPreviewManager), xcSysPreviewManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GameInitState), xcGameInitStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PlayingTestState), xcPlayingTestStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CommonLuaInstanceState), xcCommonLuaInstanceStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.LuaBehaviour), xcinstance_behaviourLuaBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SceneHelp), xcSceneHelpWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SceneHelp.LoadQuadTreeSceneState), xcSceneHelpLoadQuadTreeSceneStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.InstanceManager), xcInstanceManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.InstanceManager.InstancePollInfo), xcInstanceManagerInstancePollInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.InstanceManager.InstaneOpenState), xcInstanceManagerInstaneOpenStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.InstanceManager.ERewardState), xcInstanceManagerERewardStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DungeonDeadSpaceScore), xcDungeonDeadSpaceScoreWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DungeonFairyValleyInfo), xcDungeonFairyValleyInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(InstanceHelper), InstanceHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CommonInstanceState), xcCommonInstanceStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.LevelManager), xcDungeonLevelManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.LevelObjectHelper), xcDungeonLevelObjectHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.ColliderObjectManager), xcDungeonColliderObjectManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.DoorObjectManager), xcDungeonDoorObjectManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.CollectionObjectManager), xcDungeonCollectionObjectManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.CollectionObjectManager.ShowCollectionBarData), xcDungeonCollectionObjectManagerShowCollectionBarDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.OrdinaryObjectManager), xcDungeonOrdinaryObjectManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Dungeon.CollectionObjectBehaviour), xcDungeonCollectionObjectBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Neptune.DataManager), NeptuneDataManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Neptune.Data), NeptuneDataWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Neptune.Data.Container), NeptuneDataContainerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(Uranus.Runtime.UranusManager), UranusRuntimeUranusManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour), xcinstance_behaviourBossBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem), xcinstance_behaviourBossBehaviourUpdateBossAffiItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem), xcinstance_behaviourBossBehaviourBossInfoItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo), xcinstance_behaviourBossBehaviourRedefineBossInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller), xcinstance_behaviourBossBehaviourRedefineBossKillerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.instance_behaviour.BossBehaviour.RedefinePos), xcinstance_behaviourBossBehaviourRedefinePosWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>), SystemCollectionsGenericList_1_xcinstance_behaviourBossBehaviourRedefineBossInfo_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(TrigramItem), TrigramItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SkillHoleManager), xcSkillHoleManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.QualitySetting), xcQualitySettingWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.EHookRangeType), xcEHookRangeTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.HookSettingManager), xcHookSettingManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AudioManager), xcAudioManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AudioManager.DynamicAudioParam), xcAudioManagerDynamicAudioParamWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.AudioManager.DynamicAudioItem), xcAudioManagerDynamicAudioItemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ShieldManager), xcShieldManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xpatch.XPatchManager), xpatchXPatchManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xpatch.XPatchManager.DownloadSpeedCalclator), xpatchXPatchManagerDownloadSpeedCalclatorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xpatch.PatchProgress), xpatchPatchProgressWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xpatch.ExtendPatchProgress), xpatchExtendPatchProgressWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CustomDataType), xcCustomDataTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CustomDataMgr), xcCustomDataMgrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TreasureHunt.TreasureHuntHelper), xcTreasureHuntTreasureHuntHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Handbook.HandbookHelper), xcHandbookHandbookHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Decorate.DecorateHelper), xcDecorateDecorateHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsDecorate), xcGoodsDecorateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GodEquip.GodEquipHelper), xcGodEquipGodEquipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsGodEquip), xcGoodsGodEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ElementEquip.ElementEquipHelper), xcElementEquipElementEquipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsElementEquip), xcGoodsElementEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsMountEquip), xcGoodsMountEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MountEquipHelper), xcMountEquipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsLightWeaponSoul), xcGoodsLightWeaponSoulWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsLightWeaponHelper), xcGoodsLightWeaponHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsWeddingRing), xcGoodsWeddingRingWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.WeddingRingHelper), xcWeddingRingHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MarryFireworkManager), xcMarryFireworkManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MarryFireworkManager.EmitInfo), xcMarryFireworkManagerEmitInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GuildLeagueManager), xcGuildLeagueManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(ParticleAutoHide), ParticleAutoHideWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SDKHelper), xcSDKHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SDKConfig), xcSDKConfigWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MarryHelper), xcMarryHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MarryManager), xcMarryManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.Magic.MagicEquipHelper), xcMagicMagicEquipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.GoodsMagicEquip), xcGoodsMagicEquipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BuriedPointHelper), xcBuriedPointHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.CEventActorArgs), xcCEventActorArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.BagItemInfo), xcBagItemInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DialogManager), xcDialogManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.TimelineManager), xcTimelineManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SpanServerManager), xcSpanServerManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GrayServerManager), GrayServerManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.PKModeManagerEx), xcPKModeManagerExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SocietyManagerEx), xcSocietyManagerExWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.SocietyManagerEx.MemberInfo), xcSocietyManagerExMemberInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.VipHelper), xcVipHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.WaterWaveEffect), xcWaterWaveEffectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.MainmapManager), xcMainmapManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ui.ugui.LoginNoticeUtil), xcuiuguiLoginNoticeUtilWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.RedPointDataMgr), xcRedPointDataMgrWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBEngrave), xcDBEngraveWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.DBEngrave.EngraveInfo), xcDBEngraveEngraveInfoWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LoadMaJiaImage), LoadMaJiaImageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(xc.ResNameMapping), xcResNameMappingWrap.__Register);
				
				
				translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
				
			});
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	public static partial class XUtils
    {
	    
	    static XUtils()
		{
		    extension_method_map = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
		}
	}
}
