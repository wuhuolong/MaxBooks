#if USE_HOT && USE_HOT
namespace AutoIL
{
    using ILRuntime.Runtime.Enviorment;

    static class ILRegType
    {
        static public void RegisterFunctionDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, UnityEngine.Component, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKvMin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKvMin, Net.PkgKvMin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAttrElm, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAttrElm, Net.PkgAttrElm, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.UInt32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.UInt32, System.UInt32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.LeaveBuff, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.LeaveBuff, xc.LeaveBuff, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.String, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Path.PathNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Path.PathNode, Neptune.Path.PathNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.BindPathNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.BindPathNode, Neptune.BindPathNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Machine.State, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Machine.State, xc.Machine.State, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Single, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSkill.SkillActionData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSkill.SkillActionData, xc.DBSkill.SkillActionData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Skill, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Skill, xc.Skill, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Actor, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Actor, Actor, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Buff, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Buff, xc.Buff, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo, UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.UnLockGoodsCondition, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.UnLockGoodsCondition, xc.DBPet.UnLockGoodsCondition, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTextResource.DBAttrItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTextResource.DBAttrItem, xc.DBTextResource.DBAttrItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBAvatarPart.BODY_PART, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBAvatarPart.BODY_PART, xc.DBAvatarPart.BODY_PART, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, UnityEngine.Rect, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, UnityEngine.Color, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, UnityEngine.Color32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Goods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Goods, xc.Goods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Guide.ICondition, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Guide.ICondition, Guide.ICondition, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerBrief, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerBrief, Net.PkgPlayerBrief, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKv, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKv, Net.PkgKv, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.PackRecorder.PackData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.PackRecorder.PackData, xc.PackRecorder.PackData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Newtonsoft.Json.Serialization.IReferenceResolver>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.List<System.UInt32>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.List<System.UInt32>, System.Collections.Generic.List<System.UInt32>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMagic.DBMagicItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMagic.DBMagicItem, xc.DBMagic.DBMagicItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Equip.IEquipAttribute, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Equip.IEquipAttribute, xc.Equip.IEquipAttribute, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExotic, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExotic, Net.PkgExotic, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGem, Net.PkgGem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStrStr, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStrStr, Net.PkgStrStr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsLightWeaponSoul, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsLightWeaponSoul, xc.GoodsLightWeaponSoul, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameEngine.BundleObject, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameEngine.BundleObject, SGameEngine.BundleObject, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.UInt64, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.UInt64, System.UInt64, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsMountEquip, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsMountEquip, xc.GoodsMountEquip, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSpecialMon.DBSpecialMonItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSpecialMon.DBSpecialMonItem, xc.DBSpecialMon.DBSpecialMonItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ServerRoleInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ServerRoleInfo, xc.ServerRoleInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ServerInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ServerInfo, xc.ServerInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.RegionInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.RegionInfo, xc.RegionInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsEquip, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsEquip, xc.GoodsEquip, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuit.DBSuitInfo.NeedInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuit.DBSuitInfo.NeedInfo, xc.DBSuit.DBSuitInfo.NeedInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.TaskDefine.TaskStep, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.TaskDefine.TaskStep, xc.TaskDefine.TaskStep, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBReward.RewardInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBReward.RewardInfo, xc.DBReward.RewardInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<NpcScenePosition, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<NpcScenePosition, NpcScenePosition, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.List<System.String>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.String>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Task.StepProgress, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Task.StepProgress, xc.Task.StepProgress, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Task, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Task, xc.Task, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamMember, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamMember, Net.PkgTeamMember, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamUserIntro, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamUserIntro, Net.PkgTeamUserIntro, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.S2CTeamBeInvite, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.S2CTeamBeInvite, Net.S2CTeamBeInvite, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.SocietyManagerEx.MemberInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.SocietyManagerEx.MemberInfo, xc.SocietyManagerEx.MemberInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.EquipPosInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.EquipPosInfo, xc.EquipPosInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DecoratePosInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DecoratePosInfo, xc.DecoratePosInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DecorateAppendAttr, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DecorateAppendAttr, xc.DecorateAppendAttr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSysConfig.SysConfig, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSysConfig.SysConfig, xc.DBSysConfig.SysConfig, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsPos, Net.PkgSkillsPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsOne, Net.PkgSkillsOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.MailInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.MailInfo, xc.MailInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAttachment, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAttachment, Net.PkgAttachment, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Money, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Money, xc.Money, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsItem, xc.GoodsItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsSoul, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsSoul, xc.GoodsSoul, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Equip.EquipHelper.AttributeDescItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Equip.EquipHelper.AttributeDescItem, xc.Equip.EquipHelper.AttributeDescItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DropComponent, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DropComponent, DropComponent, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.FriendsInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.FriendsInfo, xc.FriendsInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.FriendShipInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.FriendShipInfo, xc.FriendShipInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DebugUI.Command, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ValueRange, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ValueRange, xc.ValueRange, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsLuaEx, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsLuaEx, xc.GoodsLuaEx, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsMagicEquip, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsMagicEquip, xc.GoodsMagicEquip, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsGodEquip, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsGodEquip, xc.GoodsGodEquip, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsDecorate, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsDecorate, xc.GoodsDecorate, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDecorate.LegendAttrDescItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDecorate.LegendAttrDescItem, xc.DBDecorate.LegendAttrDescItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossKiller, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossKiller, Net.PkgBossKiller, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte[], System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte[], System.Byte[], System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossKiller, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossKiller, xc.instance_behaviour.BossBehaviour.RedefineBossKiller, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossInfo, xc.instance_behaviour.BossBehaviour.RedefineBossInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.UIBaseWindow.BackupWin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.UIBaseWindow.BackupWin, xc.ui.ugui.UIBaseWindow.BackupWin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.UIBaseWindow, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.UIBaseWindow, xc.ui.ugui.UIBaseWindow, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.debug.CommandPanel.CommandInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.debug.CommandPanel.CommandInfo, xc.debug.CommandPanel.CommandInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<MiniMapPointInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<MiniMapPointInfo, MiniMapPointInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<QuadTreeSceneManager.CubeTime, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<QuadTreeSceneManager.CubeTime, QuadTreeSceneManager.CubeTime, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.FirstClassNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.FirstClassNode, UIExpandScrollView.FirstClassNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.SecondClassNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.SecondClassNode, UIExpandScrollView.SecondClassNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.ThirdClassNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIExpandScrollView.ThirdClassNode, UIExpandScrollView.ThirdClassNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDropGive, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDropGive, Net.PkgDropGive, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Object, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Object, UnityEngine.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Type, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameFirstPass.AssetBundleInfoItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameFirstPass.AssetBundleInfoItem, SGameFirstPass.AssetBundleInfoItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Type>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Uranus.Runtime.ICondition, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Uranus.Runtime.ICondition, Uranus.Runtime.ICondition, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<BinItemInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<BinItemInfo, BinItemInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameFirstPass.AssetPatchInfoItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<SGameFirstPass.AssetPatchInfoItem, SGameFirstPass.AssetPatchInfoItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xpatch.DL_BundleContext, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xpatch.DL_BundleContext, xpatch.DL_BundleContext, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xpatch.DL_PatchContext, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xpatch.DL_PatchContext, xpatch.DL_PatchContext, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<MikuLuaProfiler.Sample, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<MikuLuaProfiler.Sample, MikuLuaProfiler.Sample, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte, System.Byte, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccPhoneInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccPhoneInfo, Net.PkgAccPhoneInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccSysSetting, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccSysSetting, Net.PkgAccSysSetting, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKvStr, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKvStr, Net.PkgKvStr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerPersonality, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerPersonality, Net.PkgPlayerPersonality, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsGidnum, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsGidnum, Net.PkgGoodsGidnum, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsInfo, Net.PkgGoodsInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStrengthInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStrengthInfo, Net.PkgStrengthInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBaptizeInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBaptizeInfo, Net.PkgBaptizeInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBaptizeGroove, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBaptizeGroove, Net.PkgBaptizeGroove, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerClientData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerClientData, Net.PkgPlayerClientData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorldMemberInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorldMemberInfo, Net.PkgWorldMemberInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNotice, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNotice, Net.PkgNotice, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMapLineState, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMapLineState, Net.PkgMapLineState, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNwarBarPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNwarBarPos, Net.PkgNwarBarPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNwarNpcPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgNwarNpcPos, Net.PkgNwarNpcPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTrialBossPass, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTrialBossPass, Net.PkgTrialBossPass, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorshipHuman, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorshipHuman, Net.PkgWorshipHuman, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorshipAnswer, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWorshipAnswer, Net.PkgWorshipAnswer, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTombInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTombInfo, Net.PkgTombInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueResource, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueResource, Net.PkgGleagueResource, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueWarGuild, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueWarGuild, Net.PkgGleagueWarGuild, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueAchieve, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGleagueAchieve, Net.PkgGleagueAchieve, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBattleFieldOpponent, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBattleFieldOpponent, Net.PkgBattleFieldOpponent, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBattleFieldHistory, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBattleFieldHistory, Net.PkgBattleFieldHistory, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeBossInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeBossInfo, Net.PkgLordComeBossInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeBossLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeBossLog, Net.PkgLordComeBossLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLordComeRank, Net.PkgLordComeRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakArenaRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakArenaRank, Net.PkgPeakArenaRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakRank, Net.PkgPeakRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakClanMini, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakClanMini, Net.PkgPeakClanMini, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakClan, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakClan, Net.PkgPeakClan, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeak3PMatchOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeak3PMatchOne, Net.PkgPeak3PMatchOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeak3PResultOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeak3PResultOne, Net.PkgPeak3PResultOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMeleeScore, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMeleeScore, Net.PkgMeleeScore, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodDemonDuelRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodDemonDuelRank, Net.PkgGodDemonDuelRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsCd, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSkillsCd, Net.PkgSkillsCd, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsCd, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsCd, Net.PkgGoodsCd, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsDailyLimit, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsDailyLimit, Net.PkgGoodsDailyLimit, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsUsageCounter, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGoodsUsageCounter, Net.PkgGoodsUsageCounter, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMoneyInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMoneyInfo, Net.PkgMoneyInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEpShapeRefine, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEpShapeRefine, Net.PkgEpShapeRefine, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEpQuenchSpirits, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEpQuenchSpirits, Net.PkgEpQuenchSpirits, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgElementEpStrength, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgElementEpStrength, Net.PkgElementEpStrength, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightSoulOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightSoulOne, Net.PkgLightSoulOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightEquipOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightEquipOne, Net.PkgLightEquipOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemStrength, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemStrength, Net.PkgFiveElemStrength, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemTrain, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemTrain, Net.PkgFiveElemTrain, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemSuit, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveElemSuit, Net.PkgFiveElemSuit, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQuotaList, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQuotaList, Net.PkgQuotaList, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopInfo, Net.PkgShopInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMshopItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMshopItem, Net.PkgMshopItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMshopOrder, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMshopOrder, Net.PkgMshopOrder, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSpirit, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSpirit, Net.PkgArtifactSpirit, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSpiritDecompose, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSpiritDecompose, Net.PkgArtifactSpiritDecompose, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDecorateAttr, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDecorateAttr, Net.PkgDecorateAttr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDecoratePosInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDecoratePosInfo, Net.PkgDecoratePosInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipAttr, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipAttr, Net.PkgGodEquipAttr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipPosInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipPosInfo, Net.PkgGodEquipPosInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipSkill, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodEquipSkill, Net.PkgGodEquipSkill, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodBaptizeGroove, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodBaptizeGroove, Net.PkgGodBaptizeGroove, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodBaptizeInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodBaptizeInfo, Net.PkgGodBaptizeInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEngrave, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEngrave, Net.PkgEngrave, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEngravePosInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEngravePosInfo, Net.PkgEngravePosInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRideEquipPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRideEquipPos, Net.PkgRideEquipPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEquipZhuhun, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEquipZhuhun, Net.PkgEquipZhuhun, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEquipCarve, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEquipCarve, Net.PkgEquipCarve, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPetEquipPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPetEquipPos, Net.PkgPetEquipPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHolySuit, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHolySuit, Net.PkgHolySuit, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLeg, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLeg, Net.PkgLeg, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLegInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLegInfo, Net.PkgLegInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTaskInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTaskInfo, Net.PkgTaskInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTaskTitleInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTaskTitleInfo, Net.PkgTaskTitleInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMail, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMail, Net.PkgMail, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarqueeInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarqueeInfo, Net.PkgMarqueeInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRankLine, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRankLine, Net.PkgRankLine, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int64, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int64, System.Int64, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFinalRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFinalRank, Net.PkgFinalRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActDaily, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActDaily, Net.PkgActDaily, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActState, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActState, Net.PkgActState, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActYunying, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActYunying, Net.PkgActYunying, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccPayTarget, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccPayTarget, Net.PkgAccPayTarget, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHolidayAccPayTarget, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHolidayAccPayTarget, Net.PkgHolidayAccPayTarget, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccTreasureTower, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgAccTreasureTower, Net.PkgAccTreasureTower, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerCostConf, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerCostConf, Net.PkgTreasureTowerCostConf, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerItemConf, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerItemConf, Net.PkgTreasureTowerItemConf, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerResetConf, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerResetConf, Net.PkgTreasureTowerResetConf, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerGradeConf, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerGradeConf, Net.PkgTreasureTowerGradeConf, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerConf, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureTowerConf, Net.PkgTreasureTowerConf, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBargainInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBargainInfo, Net.PkgBargainInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPainKill, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPainKill, Net.PkgPainKill, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildCompeteInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildCompeteInfo, Net.PkgGuildCompeteInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSb, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSb, Net.PkgConsumeRankSb, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSbReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSbReward, Net.PkgConsumeRankSbReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSpring, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSpring, Net.PkgConsumeRankSpring, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSpringReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConsumeRankSpringReward, Net.PkgConsumeRankSpringReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossActBuyLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossActBuyLog, Net.PkgBossActBuyLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedpackActLucky, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedpackActLucky, Net.PkgRedpackActLucky, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedpackAct, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedpackAct, Net.PkgRedpackAct, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgCollectCompose, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgCollectCompose, Net.PkgCollectCompose, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKnockEgg, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgKnockEgg, Net.PkgKnockEgg, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEggLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEggLog, Net.PkgEggLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEggGoods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgEggGoods, Net.PkgEggGoods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActReturnGoal, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActReturnGoal, Net.PkgActReturnGoal, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtaskIndexInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtaskIndexInfo, Net.PkgDtaskIndexInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtaskDayInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtaskDayInfo, Net.PkgDtaskDayInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLuckyTurntableLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLuckyTurntableLog, Net.PkgLuckyTurntableLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActPrayLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActPrayLog, Net.PkgActPrayLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActPrayDo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActPrayDo, Net.PkgActPrayDo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanCostRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanCostRank, Net.PkgSpanCostRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStarWishLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStarWishLog, Net.PkgStarWishLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHonorableGiftGoods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgHonorableGiftGoods, Net.PkgHonorableGiftGoods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTimeLimitItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTimeLimitItem, Net.PkgTimeLimitItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTimeLimitBuy, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTimeLimitBuy, Net.PkgTimeLimitBuy, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTransferSaleItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTransferSaleItem, Net.PkgTransferSaleItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExaltedGiftGoods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExaltedGiftGoods, Net.PkgExaltedGiftGoods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActFestivalInvest, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgActFestivalInvest, Net.PkgActFestivalInvest, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureReplaceInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureReplaceInfo, Net.PkgTreasureReplaceInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureBigAward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureBigAward, Net.PkgTreasureBigAward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamIntro, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTeamIntro, Net.PkgTeamIntro, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMemberPos, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMemberPos, Net.PkgMemberPos, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgInviteMember, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgInviteMember, Net.PkgInviteMember, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossInfo, Net.PkgBossInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossFight, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossFight, Net.PkgBossFight, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossAffRank, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossAffRank, Net.PkgBossAffRank, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossDropInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBossDropInfo, Net.PkgBossDropInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBossMon, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBossMon, Net.PkgSpanBossMon, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBossGroupOne, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBossGroupOne, Net.PkgSpanBossGroupOne, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveEmperorsBoss, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveEmperorsBoss, Net.PkgFiveEmperorsBoss, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveEmperorsTotem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFiveEmperorsTotem, Net.PkgFiveEmperorsTotem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBeastDng, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBeastDng, Net.PkgSaintBeastDng, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBox, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBox, Net.PkgSaintBox, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBossLv, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSaintBossLv, Net.PkgSaintBossLv, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTrigram, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTrigram, Net.PkgTrigram, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRune, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRune, Net.PkgRune, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildIntro, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildIntro, Net.PkgGuildIntro, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildMember, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildMember, Net.PkgGuildMember, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildWareLogGoods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildWareLogGoods, Net.PkgGuildWareLogGoods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildWareLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildWareLog, Net.PkgGuildWareLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlRoundInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlRoundInfo, Net.PkgGlRoundInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlLevelInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlLevelInfo, Net.PkgGlLevelInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlBattleInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGlBattleInfo, Net.PkgGlBattleInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildTask, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildTask, Net.PkgGuildTask, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildRedpackLucky, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildRedpackLucky, Net.PkgGuildRedpackLucky, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildRedpackInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGuildRedpackInfo, Net.PkgGuildRedpackInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbBattleGuild, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbBattleGuild, Net.PkgSgbBattleGuild, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbRankGuild, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbRankGuild, Net.PkgSgbRankGuild, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbBattleInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSgbBattleInfo, Net.PkgSgbBattleInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarketGoods, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarketGoods, Net.PkgMarketGoods, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtIndexInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtIndexInfo, Net.PkgDtIndexInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtDayInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgDtDayInfo, Net.PkgDtDayInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgResourceRetrieve, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgResourceRetrieve, Net.PkgResourceRetrieve, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPrayInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPrayInfo, Net.PkgPrayInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubTargetInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubTargetInfo, Net.PkgSubTargetInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTargetInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTargetInfo, Net.PkgTargetInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubPhaseInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubPhaseInfo, Net.PkgSubPhaseInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPhaseInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPhaseInfo, Net.PkgPhaseInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSevenGiftInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSevenGiftInfo, Net.PkgSevenGiftInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgImpactRankInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgImpactRankInfo, Net.PkgImpactRankInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLvReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLvReward, Net.PkgLvReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipLvReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipLvReward, Net.PkgVipLvReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSepcReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSepcReward, Net.PkgSepcReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBuyLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgBuyLog, Net.PkgBuyLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgChosenResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgChosenResult, Net.PkgChosenResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipInvestUnit, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipInvestUnit, Net.PkgVipInvestUnit, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureHuntInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureHuntInfo, Net.PkgTreasureHuntInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTreasureInfo, Net.PkgTreasureInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSuperHuntInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSuperHuntInfo, Net.PkgSuperHuntInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubGodExpInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSubGodExpInfo, Net.PkgSubGodExpInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodExpInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGodExpInfo, Net.PkgGodExpInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgZeroGift, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgZeroGift, Net.PkgZeroGift, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleItem, Net.PkgLimitSaleItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleShop, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleShop, Net.PkgLimitSaleShop, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSoulInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSoulInfo, Net.PkgSoulInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitCollect, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitCollect, Net.PkgLimitCollect, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitTask, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitTask, Net.PkgLimitTask, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRed, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRed, Net.PkgPayRed, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRedBorn, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRedBorn, Net.PkgPayRedBorn, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRedTaker, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPayRedTaker, Net.PkgPayRedTaker, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFireworkCelebrationLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFireworkCelebrationLog, Net.PkgFireworkCelebrationLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightEquip, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLightEquip, Net.PkgLightEquip, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakHuntInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPeakHuntInfo, Net.PkgPeakHuntInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedPacket, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRedPacket, Net.PkgRedPacket, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConPay, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgConPay, Net.PkgConPay, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGiftSale, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGiftSale, Net.PkgShopGiftSale, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGiftBuy, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGiftBuy, Net.PkgShopGiftBuy, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopDay, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopDay, Net.PkgShopDay, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGift, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShopGift, Net.PkgShopGift, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanSepcReward, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanSepcReward, Net.PkgSpanSepcReward, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanChosenInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanChosenInfo, Net.PkgSpanChosenInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerBuy, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPlayerBuy, Net.PkgPlayerBuy, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBuyLog, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanBuyLog, Net.PkgSpanBuyLog, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanChosenResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgSpanChosenResult, Net.PkgSpanChosenResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleSpanItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleSpanItem, Net.PkgLimitSaleSpanItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleSpanShop, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgLimitSaleSpanShop, Net.PkgLimitSaleSpanShop, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQiankunHuntInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQiankunHuntInfo, Net.PkgQiankunHuntInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarryReserveCouple, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarryReserveCouple, Net.PkgMarryReserveCouple, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWeddingGift, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgWeddingGift, Net.PkgWeddingGift, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarryPerfitRecords, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgMarryPerfitRecords, Net.PkgMarryPerfitRecords, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStigma, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgStigma, Net.PkgStigma, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPetSkin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgPetSkin, Net.PkgPetSkin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGrowInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgGrowInfo, Net.PkgGrowInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRideSkin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgRideSkin, Net.PkgRideSkin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFruitInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFruitInfo, Net.PkgFruitInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFashion, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgFashion, Net.PkgFashion, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExpJade, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgExpJade, Net.PkgExpJade, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipBonus, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgVipBonus, Net.PkgVipBonus, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTitleInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTitleInfo, Net.PkgTitleInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTalentSystem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgTalentSystem, Net.PkgTalentSystem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShowInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgShowInfo, Net.PkgShowInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactInfo, Net.PkgArtifactInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSkillInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgArtifactSkillInfo, Net.PkgArtifactSkillInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQualityAdvance, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Net.PkgQualityAdvance, Net.PkgQualityAdvance, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBAttrs.DBAttrsItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBAttrs.DBAttrsItem, xc.DBAttrs.DBAttrsItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDecoratePos.DBDecoratePosItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDecoratePos.DBDecoratePosItem, xc.DBDecoratePos.DBDecoratePosItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBEngrave.EngraveInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBEngrave.EngraveInfo, xc.DBEngrave.EngraveInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGem.GemInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGem.GemInfo, xc.DBGem.GemInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTextResource.DBGoodsItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTextResource.DBGoodsItem, xc.DBTextResource.DBGoodsItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketFilter.OneDBMarketFilter, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketFilter.OneDBMarketFilter, xc.DBMarketFilter.OneDBMarketFilter, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketFilter.DBMarketFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketFilter.DBMarketFilterItem, xc.DBMarketFilter.DBMarketFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketQualityFilter.DBMarketQualityFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketQualityFilter.DBMarketQualityFilterItem, xc.DBMarketQualityFilter.DBMarketQualityFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketStepFilter.DBMarketStepFilterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBMarketStepFilter.DBMarketStepFilterItem, xc.DBMarketStepFilter.DBMarketStepFilterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.PreloadInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.PreloadInfo, xc.PreloadInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitAttr.DBSuitAttrInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitAttr.DBSuitAttrInfo, xc.DBSuitAttr.DBSuitAttrInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitRefine.DBSuitRefineItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitRefine.DBSuitRefineItem, xc.DBSuitRefine.DBSuitRefineItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDataAllSkill.AllSkillInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBDataAllSkill.AllSkillInfo, xc.DBDataAllSkill.AllSkillInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGrowSkin.DBGrowSkinItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGrowSkin.DBGrowSkinItem, xc.DBGrowSkin.DBGrowSkinItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildBoss.DBGuildBossItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildBoss.DBGuildBossItem, xc.DBGuildBoss.DBGuildBossItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildBoss.DBGuildBossStatisticItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildBoss.DBGuildBossStatisticItem, xc.DBGuildBoss.DBGuildBossStatisticItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildSkill.DBCommonAttrItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBGuildSkill.DBCommonAttrItem, xc.DBGuildSkill.DBCommonAttrItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.HangInfo.TagInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.HangInfo.TagInfo, xc.HangInfo.TagInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.PetSkillItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.PetSkillItem, xc.DBPet.PetSkillItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.PetInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.PetInfo, xc.DBPet.PetInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPetFetter.DBPetFetterItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPetFetter.DBPetFetterItem, xc.DBPetFetter.DBPetFetterItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPetFetter.FetterSkillItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPetFetter.FetterSkillItem, xc.DBPetFetter.FetterSkillItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.UnLockPrePetCondition, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPet.UnLockPrePetCondition, xc.DBPet.UnLockPrePetCondition, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSkillSelection.SkillSelectionInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSkillSelection.SkillSelectionInfo, xc.DBSkillSelection.SkillSelectionInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBStigma.DBStigmaSkillItemSkillItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBStigma.DBStigmaSkillItemSkillItem, xc.DBStigma.DBStigmaSkillItemSkillItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBStigma.DBStigmaInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBStigma.DBStigmaInfo, xc.DBStigma.DBStigmaInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTrialBoss.TrialBossItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBTrialBoss.TrialBossItem, xc.DBTrialBoss.TrialBossItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWidgetShield.WidgetInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWidgetShield.WidgetInfo, xc.DBWidgetShield.WidgetInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWorldBoss.DBWorldBossRewardItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWorldBoss.DBWorldBossRewardItem, xc.DBWorldBoss.DBWorldBossRewardItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWorldBoss.DBWorldBossItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBWorldBoss.DBWorldBossItem, xc.DBWorldBoss.DBWorldBossItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.EquipAttrData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.EquipAttrData, xc.EquipAttrData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSysGroupConfig.SysGroup, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSysGroupConfig.SysGroup, xc.DBSysGroupConfig.SysGroup, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GuideData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GuideData, xc.GuideData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Guide.Step, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Guide.Step, Guide.Step, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBManager.ColumnInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBManager.ColumnInfo, xc.DBManager.ColumnInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.String, System.String>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.String, System.String>, System.Collections.Generic.Dictionary<System.String, System.String>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object[], System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsDropFrom.DropType, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.GoodsDropFrom.DropType, xc.GoodsDropFrom.DropType, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.UnitCacheInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPay.PayItemInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBPay.PayItemInfo, xc.DBPay.PayItemInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitEffect.BindInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.DBSuitEffect.BindInfo, xc.DBSuitEffect.BindInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Dungeon.ColliderObject, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.Dungeon.ColliderObject, xc.Dungeon.ColliderObject, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Data.Container, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Data.Container, Neptune.Data.Container, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UGUIAtlas, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UGUIAtlas, UGUIAtlas, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.LoginNoticeContent, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.LoginNoticeContent, xc.ui.ugui.LoginNoticeContent, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.LoginNoticeItemInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<xc.ui.ugui.LoginNoticeItemInfo, xc.ui.ugui.LoginNoticeItemInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Int32, System.Char, System.Char>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.ILayoutElement, System.Single>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Camera, Cinemachine.ICinemachineCamera, Cinemachine.CameraState, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Cinemachine.CinemachineVirtualCamera, System.String, Cinemachine.ICinemachineComponent[], UnityEngine.Transform>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Cinemachine.CinemachineFreeLook, System.String, Cinemachine.CinemachineVirtualCamera, Cinemachine.CinemachineVirtualCamera>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Single>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Tag, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.Tag, Neptune.Tag, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.BaseGenericNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<Neptune.BaseGenericNode, Neptune.BaseGenericNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RawImage, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RawImage, UnityEngine.UI.RawImage, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Texture, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Texture, UnityEngine.Texture, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Text, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Text, UnityEngine.UI.Text, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Text.RegularExpressions.Match, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.Dictionary<System.String, System.String>>();
            appdomain.DelegateManager.RegisterFunctionDelegate<AssetBundleOffsetInfoItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<AssetBundleOffsetInfoItem, AssetBundleOffsetInfoItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.AdvancedText.CharOffest, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.AdvancedText.CharOffest, UnityEngine.UI.AdvancedText.CharOffest, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DynamicBoneCollider, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DynamicBoneCollider, DynamicBoneCollider, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Transform, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Transform, UnityEngine.Transform, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Single, System.Single, System.Single, System.Single>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TimelineRef.TimelineRefInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TimelineRef.TimelineRefInfo, TimelineRef.TimelineRefInfo, System.Int32>();

        }

        static public void RegisterDelegateConvertor(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Component>>((act) =>
            {
                return new System.Predicate<UnityEngine.Component>((obj) =>
                {
                    return ((System.Func<UnityEngine.Component, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Component>>((act) =>
            {
                return new System.Comparison<UnityEngine.Component>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Component, UnityEngine.Component, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ActorMachine.UpdateFunc>((act) =>
            {
                return new xc.ActorMachine.UpdateFunc(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.Skill.FuncUpdateSkill>((act) =>
            {
                return new xc.Skill.FuncUpdateSkill(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Action>((act) =>
            {
                return new System.Action(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.MoveCtrl.MoveDirCallback>((act) =>
            {
                return new xc.MoveCtrl.MoveDirCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Canvas.WillRenderCanvases>((act) =>
            {
                return new UnityEngine.Canvas.WillRenderCanvases(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Font.FontTextureRebuildCallback>((act) =>
            {
                return new UnityEngine.Font.FontTextureRebuildCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UIExpandScrollView.ThirdClassNode.Callback>((act) =>
            {
                return new UIExpandScrollView.ThirdClassNode.Callback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UIExpandScrollView.SecondClassNode.Callback>((act) =>
            {
                return new UIExpandScrollView.SecondClassNode.Callback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UIExpandScrollView.FirstClassNode.Callback>((act) =>
            {
                return new UIExpandScrollView.FirstClassNode.Callback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SGameEngine.ResourceLoader.on_load_scene>((act) =>
            {
                return new SGameEngine.ResourceLoader.on_load_scene(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SGameFirstPass.download_error>((act) =>
            {
                return new SGameFirstPass.download_error(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.VoiceControlComponent.OnClickDelegate>((act) =>
            {
                return new xc.VoiceControlComponent.OnClickDelegate(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.GuideManager.OnTouchedDelegate>((act) =>
            {
                return new xc.GuideManager.OnTouchedDelegate(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.Buff.UpdateFunc>((act) =>
            {
                return new xc.Buff.UpdateFunc(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.AvatarCtrl.OnResetPosFunc>((act) =>
            {
                return new xc.AvatarCtrl.OnResetPosFunc(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UIWidgetHelp.BarCloseBtnFunc>((act) =>
            {
                return new xc.ui.UIWidgetHelp.BarCloseBtnFunc(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<AutoScale.AutoSizeDelegate>((act) =>
            {
                return new AutoScale.AutoSizeDelegate(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DynamicScorll.OnSlider2Top>((act) =>
            {
                return new DynamicScorll.OnSlider2Top(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DynamicScorll.OnSlider2Bottom>((act) =>
            {
                return new DynamicScorll.OnSlider2Bottom(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.SliderEx.OnFinished>((act) =>
            {
                return new xc.ui.ugui.SliderEx.OnFinished(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.SpringPanel.OnFinished>((act) =>
            {
                return new xc.ui.ugui.SpringPanel.OnFinished(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.ToggleEx.UIDelegate>((act) =>
            {
                return new xc.ui.ugui.ToggleEx.UIDelegate(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.SpringPosition.OnFinished>((act) =>
            {
                return new xc.ui.ugui.SpringPosition.OnFinished(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ParticleAutoHide.OnStopped>((act) =>
            {
                return new ParticleAutoHide.OnStopped(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<EventCtrl.EventProcessFunc>((act) =>
            {
                return new EventCtrl.EventProcessFunc((kArgs) =>
                {
                    ((System.Action<CEventBaseArgs>)act)(kArgs);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ClientEventMgr.ClientEventFunc>((act) =>
            {
                return new ClientEventMgr.ClientEventFunc((arg) =>
                {
                    ((System.Action<CEventBaseArgs>)act)(arg);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgKvMin>>((act) =>
            {
                return new System.Predicate<Net.PkgKvMin>((obj) =>
                {
                    return ((System.Func<Net.PkgKvMin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgKvMin>>((act) =>
            {
                return new System.Comparison<Net.PkgKvMin>((x, y) =>
                {
                    return ((System.Func<Net.PkgKvMin, Net.PkgKvMin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAttrElm>>((act) =>
            {
                return new System.Predicate<Net.PkgAttrElm>((obj) =>
                {
                    return ((System.Func<Net.PkgAttrElm, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAttrElm>>((act) =>
            {
                return new System.Comparison<Net.PkgAttrElm>((x, y) =>
                {
                    return ((System.Func<Net.PkgAttrElm, Net.PkgAttrElm, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.UInt32>>((act) =>
            {
                return new System.Predicate<System.UInt32>((obj) =>
                {
                    return ((System.Func<System.UInt32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.GuideManager.WaitGuideFinishDelegate>((act) =>
            {
                return new xc.GuideManager.WaitGuideFinishDelegate((guide_id) =>
                {
                    ((System.Action<System.UInt32>)act)(guide_id);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<TrigramItem.ToggleChanged>((act) =>
            {
                return new TrigramItem.ToggleChanged((trigram_id) =>
                {
                    ((System.Action<System.UInt32>)act)(trigram_id);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.SliderEx.OnOneFinished>((act) =>
            {
                return new xc.ui.ugui.SliderEx.OnOneFinished((times) =>
                {
                    ((System.Action<System.UInt32>)act)(times);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.UInt32>>((act) =>
            {
                return new System.Comparison<System.UInt32>((x, y) =>
                {
                    return ((System.Func<System.UInt32, System.UInt32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.LeaveBuff>>((act) =>
            {
                return new System.Predicate<xc.LeaveBuff>((obj) =>
                {
                    return ((System.Func<xc.LeaveBuff, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.LeaveBuff>>((act) =>
            {
                return new System.Comparison<xc.LeaveBuff>((x, y) =>
                {
                    return ((System.Func<xc.LeaveBuff, xc.LeaveBuff, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.String>>((act) =>
            {
                return new System.Predicate<System.String>((obj) =>
                {
                    return ((System.Func<System.String, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SGameFirstPass.NewInitSceneLoader.StreamAssetsCopyed>((act) =>
            {
                return new SGameFirstPass.NewInitSceneLoader.StreamAssetsCopyed((error) =>
                {
                    ((System.Action<System.String>)act)(error);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.String>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.String>((arg0) =>
                {
                    ((System.Action<System.String>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<EmojiText.OnClickHref>((act) =>
            {
                return new EmojiText.OnClickHref((str) =>
                {
                    ((System.Action<System.String>)act)(str);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<AnimationEventBridge.OnPlayAnimationEnd>((act) =>
            {
                return new AnimationEventBridge.OnPlayAnimationEnd((param) =>
                {
                    ((System.Action<System.String>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.String>>((act) =>
            {
                return new System.Comparison<System.String>((x, y) =>
                {
                    return ((System.Func<System.String, System.String, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Neptune.Path.PathNode>>((act) =>
            {
                return new System.Predicate<Neptune.Path.PathNode>((obj) =>
                {
                    return ((System.Func<Neptune.Path.PathNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Neptune.Path.PathNode>>((act) =>
            {
                return new System.Comparison<Neptune.Path.PathNode>((x, y) =>
                {
                    return ((System.Func<Neptune.Path.PathNode, Neptune.Path.PathNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Neptune.BindPathNode>>((act) =>
            {
                return new System.Predicate<Neptune.BindPathNode>((obj) =>
                {
                    return ((System.Func<Neptune.BindPathNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Neptune.BindPathNode>>((act) =>
            {
                return new System.Comparison<Neptune.BindPathNode>((x, y) =>
                {
                    return ((System.Func<Neptune.BindPathNode, Neptune.BindPathNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Machine.State>>((act) =>
            {
                return new System.Predicate<xc.Machine.State>((obj) =>
                {
                    return ((System.Func<xc.Machine.State, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.Machine.State.StateFunction>((act) =>
            {
                return new xc.Machine.State.StateFunction((s) =>
                {
                    ((System.Action<xc.Machine.State>)act)(s);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Machine.State>>((act) =>
            {
                return new System.Comparison<xc.Machine.State>((x, y) =>
                {
                    return ((System.Func<xc.Machine.State, xc.Machine.State, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<BetterList<UnityEngine.Vector3>.CompareFunc>((act) =>
            {
                return new BetterList<UnityEngine.Vector3>.CompareFunc((left, right) =>
                {
                    return ((System.Func<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>)act)(left, right);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector3>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector3>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ActorMachine.WalkToPointChange>((act) =>
            {
                return new xc.ActorMachine.WalkToPointChange((nextPoint) =>
                {
                    ((System.Action<UnityEngine.Vector3>)act)(nextPoint);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ActorMachine.ReachTarget>((act) =>
            {
                return new xc.ActorMachine.ReachTarget((next) =>
                {
                    ((System.Action<UnityEngine.Vector3>)act)(next);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector3>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector3>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector3, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Single>>((act) =>
            {
                return new System.Predicate<System.Single>((obj) =>
                {
                    return ((System.Func<System.Single, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Single>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Single>((arg0) =>
                {
                    ((System.Action<System.Single>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Single>>((act) =>
            {
                return new System.Comparison<System.Single>((x, y) =>
                {
                    return ((System.Func<System.Single, System.Single, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSkill.SkillActionData>>((act) =>
            {
                return new System.Predicate<xc.DBSkill.SkillActionData>((obj) =>
                {
                    return ((System.Func<xc.DBSkill.SkillActionData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSkill.SkillActionData>>((act) =>
            {
                return new System.Comparison<xc.DBSkill.SkillActionData>((x, y) =>
                {
                    return ((System.Func<xc.DBSkill.SkillActionData, xc.DBSkill.SkillActionData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Skill>>((act) =>
            {
                return new System.Predicate<xc.Skill>((obj) =>
                {
                    return ((System.Func<xc.Skill, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Skill>>((act) =>
            {
                return new System.Comparison<xc.Skill>((x, y) =>
                {
                    return ((System.Func<xc.Skill, xc.Skill, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.EffectEmitter.InitFunc>((act) =>
            {
                return new xc.EffectEmitter.InitFunc((effectObject) =>
                {
                    ((System.Action<UnityEngine.GameObject>)act)(effectObject);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineVirtualCamera.DestroyPipelineDelegate>((act) =>
            {
                return new Cinemachine.CinemachineVirtualCamera.DestroyPipelineDelegate((pipeline) =>
                {
                    ((System.Action<UnityEngine.GameObject>)act)(pipeline);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineFreeLook.DestroyRigDelegate>((act) =>
            {
                return new Cinemachine.CinemachineFreeLook.DestroyRigDelegate((rig) =>
                {
                    ((System.Action<UnityEngine.GameObject>)act)(rig);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.EventTriggerListener.UIDelegate>((act) =>
            {
                return new xc.ui.ugui.EventTriggerListener.UIDelegate((go) =>
                {
                    ((System.Action<UnityEngine.GameObject>)act)(go);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UICenterOnChild.OnCenterCallback>((act) =>
            {
                return new xc.ui.ugui.UICenterOnChild.OnCenterCallback((centeredObject) =>
                {
                    ((System.Action<UnityEngine.GameObject>)act)(centeredObject);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Actor>>((act) =>
            {
                return new System.Predicate<Actor>((obj) =>
                {
                    return ((System.Func<Actor, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Actor>>((act) =>
            {
                return new System.Comparison<Actor>((x, y) =>
                {
                    return ((System.Func<Actor, Actor, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.Buff.BuffInfo.FunctionHandle>((act) =>
            {
                return new xc.Buff.BuffInfo.FunctionHandle((buff, buff_info) =>
                {
                    ((System.Action<xc.Buff, xc.Buff.BuffInfo>)act)(buff, buff_info);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Buff>>((act) =>
            {
                return new System.Predicate<xc.Buff>((obj) =>
                {
                    return ((System.Func<xc.Buff, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Buff>>((act) =>
            {
                return new System.Comparison<xc.Buff>((x, y) =>
                {
                    return ((System.Func<xc.Buff, xc.Buff, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Rendering.ReflectionProbeBlendInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.Rendering.ReflectionProbeBlendInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Rendering.ReflectionProbeBlendInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.Rendering.ReflectionProbeBlendInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Rendering.ReflectionProbeBlendInfo, UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPet.UnLockGoodsCondition>>((act) =>
            {
                return new System.Predicate<xc.DBPet.UnLockGoodsCondition>((obj) =>
                {
                    return ((System.Func<xc.DBPet.UnLockGoodsCondition, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPet.UnLockGoodsCondition>>((act) =>
            {
                return new System.Comparison<xc.DBPet.UnLockGoodsCondition>((x, y) =>
                {
                    return ((System.Func<xc.DBPet.UnLockGoodsCondition, xc.DBPet.UnLockGoodsCondition, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBTextResource.DBAttrItem>>((act) =>
            {
                return new System.Predicate<xc.DBTextResource.DBAttrItem>((obj) =>
                {
                    return ((System.Func<xc.DBTextResource.DBAttrItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBTextResource.DBAttrItem>>((act) =>
            {
                return new System.Comparison<xc.DBTextResource.DBAttrItem>((x, y) =>
                {
                    return ((System.Func<xc.DBTextResource.DBAttrItem, xc.DBTextResource.DBAttrItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBAvatarPart.BODY_PART>>((act) =>
            {
                return new System.Predicate<xc.DBAvatarPart.BODY_PART>((obj) =>
                {
                    return ((System.Func<xc.DBAvatarPart.BODY_PART, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBAvatarPart.BODY_PART>>((act) =>
            {
                return new System.Comparison<xc.DBAvatarPart.BODY_PART>((x, y) =>
                {
                    return ((System.Func<xc.DBAvatarPart.BODY_PART, xc.DBAvatarPart.BODY_PART, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Rect>>((act) =>
            {
                return new System.Predicate<UnityEngine.Rect>((obj) =>
                {
                    return ((System.Func<UnityEngine.Rect, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Rect>>((act) =>
            {
                return new System.Comparison<UnityEngine.Rect>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Rect, UnityEngine.Rect, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector2>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector2>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector2, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.Vector2>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.Vector2>((arg0) =>
                {
                    ((System.Action<UnityEngine.Vector2>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector2>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector2>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Matrix4x4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Matrix4x4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Camera.CameraCallback>((act) =>
            {
                return new UnityEngine.Camera.CameraCallback((cam) =>
                {
                    ((System.Action<UnityEngine.Camera>)act)(cam);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Boolean>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Boolean>((arg0) =>
                {
                    ((System.Action<System.Boolean>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate>((act) =>
            {
                return new xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate((isOn) =>
                {
                    ((System.Action<System.Boolean>)act)(isOn);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.RectTransform.ReapplyDrivenProperties>((act) =>
            {
                return new UnityEngine.RectTransform.ReapplyDrivenProperties((driven) =>
                {
                    ((System.Action<UnityEngine.RectTransform>)act)(driven);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ContentSizeFitByTarget.ItemCellChange>((act) =>
            {
                return new ContentSizeFitByTarget.ItemCellChange((vec) =>
                {
                    ((System.Action<UnityEngine.RectTransform>)act)(vec);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Predicate<UnityEngine.UIVertex>((obj) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Comparison<UnityEngine.UIVertex>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color, UnityEngine.Color, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color32>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color32>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color32>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color32>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color32, UnityEngine.Color32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Int32>>((act) =>
            {
                return new System.Predicate<System.Int32>((obj) =>
                {
                    return ((System.Func<System.Int32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xpatch.XPatchManager.delPatchEventHandler>((act) =>
            {
                return new xpatch.XPatchManager.delPatchEventHandler((patch_id) =>
                {
                    ((System.Action<System.Int32>)act)(patch_id);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.QualitySetting.OnGraphicLevelChange>((act) =>
            {
                return new xc.QualitySetting.OnGraphicLevelChange((level) =>
                {
                    ((System.Action<System.Int32>)act)(level);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SDKControler.OnInitCallback>((act) =>
            {
                return new SDKControler.OnInitCallback((code) =>
                {
                    ((System.Action<System.Int32>)act)(code);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Int32>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Int32>((arg0) =>
                {
                    ((System.Action<System.Int32>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Int32>>((act) =>
            {
                return new System.Comparison<System.Int32>((x, y) =>
                {
                    return ((System.Func<System.Int32, System.Int32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Predicate<UnityEngine.BoneWeight>((obj) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Comparison<UnityEngine.BoneWeight>((x, y) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UICharInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UICharInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UILineInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UILineInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Goods>>((act) =>
            {
                return new System.Predicate<xc.Goods>((obj) =>
                {
                    return ((System.Func<xc.Goods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UIItemNewSlot.OnClickFunc>((act) =>
            {
                return new xc.ui.UIItemNewSlot.OnClickFunc((goods) =>
                {
                    ((System.Action<xc.Goods>)act)(goods);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.GoodsHelper.CommonClickFunc>((act) =>
            {
                return new xc.GoodsHelper.CommonClickFunc((goods) =>
                {
                    ((System.Action<xc.Goods>)act)(goods);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Goods>>((act) =>
            {
                return new System.Comparison<xc.Goods>((x, y) =>
                {
                    return ((System.Func<xc.Goods, xc.Goods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SDKControler.OnLoginCallback>((act) =>
            {
                return new SDKControler.OnLoginCallback((code, msg) =>
                {
                    ((System.Action<System.Int32, System.String>)act)(code, msg);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Guide.ICondition>>((act) =>
            {
                return new System.Predicate<Guide.ICondition>((obj) =>
                {
                    return ((System.Func<Guide.ICondition, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Guide.ICondition>>((act) =>
            {
                return new System.Comparison<Guide.ICondition>((x, y) =>
                {
                    return ((System.Func<Guide.ICondition, Guide.ICondition, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPlayerBrief>>((act) =>
            {
                return new System.Predicate<Net.PkgPlayerBrief>((obj) =>
                {
                    return ((System.Func<Net.PkgPlayerBrief, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPlayerBrief>>((act) =>
            {
                return new System.Comparison<Net.PkgPlayerBrief>((x, y) =>
                {
                    return ((System.Func<Net.PkgPlayerBrief, Net.PkgPlayerBrief, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgKv>>((act) =>
            {
                return new System.Predicate<Net.PkgKv>((obj) =>
                {
                    return ((System.Func<Net.PkgKv, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgKv>>((act) =>
            {
                return new System.Comparison<Net.PkgKv>((x, y) =>
                {
                    return ((System.Func<Net.PkgKv, Net.PkgKv, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.Game.DataReplyDelegate>((act) =>
            {
                return new xc.Game.DataReplyDelegate((protocol, data) =>
                {
                    ((System.Action<System.UInt16, System.Byte[]>)act)(protocol, data);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.PackRecorder.PackData>>((act) =>
            {
                return new System.Predicate<xc.PackRecorder.PackData>((obj) =>
                {
                    return ((System.Func<xc.PackRecorder.PackData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.PackRecorder.PackData>>((act) =>
            {
                return new System.Comparison<xc.PackRecorder.PackData>((x, y) =>
                {
                    return ((System.Func<xc.PackRecorder.PackData, xc.PackRecorder.PackData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>>((act) =>
            {
                return new System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>((sender, e) =>
                {
                    ((System.Action<System.Object, Newtonsoft.Json.Serialization.ErrorEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.JoinRoomCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.JoinRoomCompleteHandler((code, roomName, memberID) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32>)act)(code, roomName, memberID);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.QuitRoomCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.QuitRoomCompleteHandler((code, roomName, memberID) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32>)act)(code, roomName, memberID);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.StatusUpdateHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.StatusUpdateHandler((code, roomName, memberID) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32>)act)(code, roomName, memberID);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.MemberVoiceHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.MemberVoiceHandler((members, count) =>
                {
                    ((System.Action<System.Int32[], System.Int32>)act)(members, count);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.ApplyMessageKeyCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.ApplyMessageKeyCompleteHandler((code) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode>)act)(code);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.UploadReccordFileCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.UploadReccordFileCompleteHandler((code, filepath, fileid) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.String>)act)(code, filepath, fileid);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.DownloadRecordFileCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.DownloadRecordFileCompleteHandler((code, filepath, fileid) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.String>)act)(code, filepath, fileid);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.SpeechToTextHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.SpeechToTextHandler((code, fileID, result) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.String>)act)(code, fileID, result);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.PlayRecordFilCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.PlayRecordFilCompleteHandler((code, filepath) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String>)act)(code, filepath);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.StreamSpeechToTextHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.StreamSpeechToTextHandler((code, error, result) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.Int32, System.String>)act)(code, error, result);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<gcloud_voice.IGCloudVoice.ChangeRoleCompleteHandler>((act) =>
            {
                return new gcloud_voice.IGCloudVoice.ChangeRoleCompleteHandler((code, roomName, memberID, role) =>
                {
                    ((System.Action<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32, System.Int32>)act)(code, roomName, memberID, role);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.List<System.UInt32>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.List<System.UInt32>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.List<System.UInt32>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.List<System.UInt32>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.List<System.UInt32>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.List<System.UInt32>, System.Collections.Generic.List<System.UInt32>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMagic.DBMagicItem>>((act) =>
            {
                return new System.Predicate<xc.DBMagic.DBMagicItem>((obj) =>
                {
                    return ((System.Func<xc.DBMagic.DBMagicItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMagic.DBMagicItem>>((act) =>
            {
                return new System.Comparison<xc.DBMagic.DBMagicItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMagic.DBMagicItem, xc.DBMagic.DBMagicItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Equip.IEquipAttribute>>((act) =>
            {
                return new System.Predicate<xc.Equip.IEquipAttribute>((obj) =>
                {
                    return ((System.Func<xc.Equip.IEquipAttribute, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Equip.IEquipAttribute>>((act) =>
            {
                return new System.Comparison<xc.Equip.IEquipAttribute>((x, y) =>
                {
                    return ((System.Func<xc.Equip.IEquipAttribute, xc.Equip.IEquipAttribute, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgExotic>>((act) =>
            {
                return new System.Predicate<Net.PkgExotic>((obj) =>
                {
                    return ((System.Func<Net.PkgExotic, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgExotic>>((act) =>
            {
                return new System.Comparison<Net.PkgExotic>((x, y) =>
                {
                    return ((System.Func<Net.PkgExotic, Net.PkgExotic, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGem>>((act) =>
            {
                return new System.Predicate<Net.PkgGem>((obj) =>
                {
                    return ((System.Func<Net.PkgGem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGem>>((act) =>
            {
                return new System.Comparison<Net.PkgGem>((x, y) =>
                {
                    return ((System.Func<Net.PkgGem, Net.PkgGem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgStrStr>>((act) =>
            {
                return new System.Predicate<Net.PkgStrStr>((obj) =>
                {
                    return ((System.Func<Net.PkgStrStr, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgStrStr>>((act) =>
            {
                return new System.Comparison<Net.PkgStrStr>((x, y) =>
                {
                    return ((System.Func<Net.PkgStrStr, Net.PkgStrStr, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsLightWeaponSoul>>((act) =>
            {
                return new System.Predicate<xc.GoodsLightWeaponSoul>((obj) =>
                {
                    return ((System.Func<xc.GoodsLightWeaponSoul, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsLightWeaponSoul>>((act) =>
            {
                return new System.Comparison<xc.GoodsLightWeaponSoul>((x, y) =>
                {
                    return ((System.Func<xc.GoodsLightWeaponSoul, xc.GoodsLightWeaponSoul, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<SGameEngine.BundleObject>>((act) =>
            {
                return new System.Predicate<SGameEngine.BundleObject>((obj) =>
                {
                    return ((System.Func<SGameEngine.BundleObject, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<SGameEngine.BundleObject>>((act) =>
            {
                return new System.Comparison<SGameEngine.BundleObject>((x, y) =>
                {
                    return ((System.Func<SGameEngine.BundleObject, SGameEngine.BundleObject, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.UInt64>>((act) =>
            {
                return new System.Predicate<System.UInt64>((obj) =>
                {
                    return ((System.Func<System.UInt64, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.UInt64>>((act) =>
            {
                return new System.Comparison<System.UInt64>((x, y) =>
                {
                    return ((System.Func<System.UInt64, System.UInt64, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsMountEquip>>((act) =>
            {
                return new System.Predicate<xc.GoodsMountEquip>((obj) =>
                {
                    return ((System.Func<xc.GoodsMountEquip, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsMountEquip>>((act) =>
            {
                return new System.Comparison<xc.GoodsMountEquip>((x, y) =>
                {
                    return ((System.Func<xc.GoodsMountEquip, xc.GoodsMountEquip, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSpecialMon.DBSpecialMonItem>>((act) =>
            {
                return new System.Predicate<xc.DBSpecialMon.DBSpecialMonItem>((obj) =>
                {
                    return ((System.Func<xc.DBSpecialMon.DBSpecialMonItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSpecialMon.DBSpecialMonItem>>((act) =>
            {
                return new System.Comparison<xc.DBSpecialMon.DBSpecialMonItem>((x, y) =>
                {
                    return ((System.Func<xc.DBSpecialMon.DBSpecialMonItem, xc.DBSpecialMon.DBSpecialMonItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ServerRoleInfo>>((act) =>
            {
                return new System.Predicate<xc.ServerRoleInfo>((obj) =>
                {
                    return ((System.Func<xc.ServerRoleInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ServerRoleInfo>>((act) =>
            {
                return new System.Comparison<xc.ServerRoleInfo>((x, y) =>
                {
                    return ((System.Func<xc.ServerRoleInfo, xc.ServerRoleInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ServerInfo>>((act) =>
            {
                return new System.Predicate<xc.ServerInfo>((obj) =>
                {
                    return ((System.Func<xc.ServerInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetLastLoginServerInfoFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetLastLoginServerInfoFinishedDelegate((serverInfo) =>
                {
                    ((System.Action<xc.ServerInfo>)act)(serverInfo);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ServerInfo>>((act) =>
            {
                return new System.Comparison<xc.ServerInfo>((x, y) =>
                {
                    return ((System.Func<xc.ServerInfo, xc.ServerInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.RegionInfo>>((act) =>
            {
                return new System.Predicate<xc.RegionInfo>((obj) =>
                {
                    return ((System.Func<xc.RegionInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.RegionInfo>>((act) =>
            {
                return new System.Comparison<xc.RegionInfo>((x, y) =>
                {
                    return ((System.Func<xc.RegionInfo, xc.RegionInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsEquip>>((act) =>
            {
                return new System.Predicate<xc.GoodsEquip>((obj) =>
                {
                    return ((System.Func<xc.GoodsEquip, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsEquip>>((act) =>
            {
                return new System.Comparison<xc.GoodsEquip>((x, y) =>
                {
                    return ((System.Func<xc.GoodsEquip, xc.GoodsEquip, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSuit.DBSuitInfo.NeedInfo>>((act) =>
            {
                return new System.Predicate<xc.DBSuit.DBSuitInfo.NeedInfo>((obj) =>
                {
                    return ((System.Func<xc.DBSuit.DBSuitInfo.NeedInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSuit.DBSuitInfo.NeedInfo>>((act) =>
            {
                return new System.Comparison<xc.DBSuit.DBSuitInfo.NeedInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBSuit.DBSuitInfo.NeedInfo, xc.DBSuit.DBSuitInfo.NeedInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.TaskDefine.TaskStep>>((act) =>
            {
                return new System.Predicate<xc.TaskDefine.TaskStep>((obj) =>
                {
                    return ((System.Func<xc.TaskDefine.TaskStep, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.TaskDefine.TaskStep>>((act) =>
            {
                return new System.Comparison<xc.TaskDefine.TaskStep>((x, y) =>
                {
                    return ((System.Func<xc.TaskDefine.TaskStep, xc.TaskDefine.TaskStep, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBReward.RewardInfo>>((act) =>
            {
                return new System.Predicate<xc.DBReward.RewardInfo>((obj) =>
                {
                    return ((System.Func<xc.DBReward.RewardInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBReward.RewardInfo>>((act) =>
            {
                return new System.Comparison<xc.DBReward.RewardInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBReward.RewardInfo, xc.DBReward.RewardInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<NpcScenePosition>>((act) =>
            {
                return new System.Predicate<NpcScenePosition>((obj) =>
                {
                    return ((System.Func<NpcScenePosition, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<NpcScenePosition>>((act) =>
            {
                return new System.Comparison<NpcScenePosition>((x, y) =>
                {
                    return ((System.Func<NpcScenePosition, NpcScenePosition, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.List<System.String>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.List<System.String>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.List<System.String>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.List<System.String>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.List<System.String>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.String>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Task.StepProgress>>((act) =>
            {
                return new System.Predicate<xc.Task.StepProgress>((obj) =>
                {
                    return ((System.Func<xc.Task.StepProgress, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Task.StepProgress>>((act) =>
            {
                return new System.Comparison<xc.Task.StepProgress>((x, y) =>
                {
                    return ((System.Func<xc.Task.StepProgress, xc.Task.StepProgress, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Task>>((act) =>
            {
                return new System.Predicate<xc.Task>((obj) =>
                {
                    return ((System.Func<xc.Task, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Task>>((act) =>
            {
                return new System.Comparison<xc.Task>((x, y) =>
                {
                    return ((System.Func<xc.Task, xc.Task, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTeamMember>>((act) =>
            {
                return new System.Predicate<Net.PkgTeamMember>((obj) =>
                {
                    return ((System.Func<Net.PkgTeamMember, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTeamMember>>((act) =>
            {
                return new System.Comparison<Net.PkgTeamMember>((x, y) =>
                {
                    return ((System.Func<Net.PkgTeamMember, Net.PkgTeamMember, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTeamUserIntro>>((act) =>
            {
                return new System.Predicate<Net.PkgTeamUserIntro>((obj) =>
                {
                    return ((System.Func<Net.PkgTeamUserIntro, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTeamUserIntro>>((act) =>
            {
                return new System.Comparison<Net.PkgTeamUserIntro>((x, y) =>
                {
                    return ((System.Func<Net.PkgTeamUserIntro, Net.PkgTeamUserIntro, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.S2CTeamBeInvite>>((act) =>
            {
                return new System.Predicate<Net.S2CTeamBeInvite>((obj) =>
                {
                    return ((System.Func<Net.S2CTeamBeInvite, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.S2CTeamBeInvite>>((act) =>
            {
                return new System.Comparison<Net.S2CTeamBeInvite>((x, y) =>
                {
                    return ((System.Func<Net.S2CTeamBeInvite, Net.S2CTeamBeInvite, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.SocietyManagerEx.MemberInfo>>((act) =>
            {
                return new System.Predicate<xc.SocietyManagerEx.MemberInfo>((obj) =>
                {
                    return ((System.Func<xc.SocietyManagerEx.MemberInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.SocietyManagerEx.MemberInfo>>((act) =>
            {
                return new System.Comparison<xc.SocietyManagerEx.MemberInfo>((x, y) =>
                {
                    return ((System.Func<xc.SocietyManagerEx.MemberInfo, xc.SocietyManagerEx.MemberInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.EquipPosInfo>>((act) =>
            {
                return new System.Predicate<xc.EquipPosInfo>((obj) =>
                {
                    return ((System.Func<xc.EquipPosInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.EquipPosInfo>>((act) =>
            {
                return new System.Comparison<xc.EquipPosInfo>((x, y) =>
                {
                    return ((System.Func<xc.EquipPosInfo, xc.EquipPosInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DecoratePosInfo>>((act) =>
            {
                return new System.Predicate<xc.DecoratePosInfo>((obj) =>
                {
                    return ((System.Func<xc.DecoratePosInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DecoratePosInfo>>((act) =>
            {
                return new System.Comparison<xc.DecoratePosInfo>((x, y) =>
                {
                    return ((System.Func<xc.DecoratePosInfo, xc.DecoratePosInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DecorateAppendAttr>>((act) =>
            {
                return new System.Predicate<xc.DecorateAppendAttr>((obj) =>
                {
                    return ((System.Func<xc.DecorateAppendAttr, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DecorateAppendAttr>>((act) =>
            {
                return new System.Comparison<xc.DecorateAppendAttr>((x, y) =>
                {
                    return ((System.Func<xc.DecorateAppendAttr, xc.DecorateAppendAttr, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSysConfig.SysConfig>>((act) =>
            {
                return new System.Predicate<xc.DBSysConfig.SysConfig>((obj) =>
                {
                    return ((System.Func<xc.DBSysConfig.SysConfig, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSysConfig.SysConfig>>((act) =>
            {
                return new System.Comparison<xc.DBSysConfig.SysConfig>((x, y) =>
                {
                    return ((System.Func<xc.DBSysConfig.SysConfig, xc.DBSysConfig.SysConfig, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSkillsPos>>((act) =>
            {
                return new System.Predicate<Net.PkgSkillsPos>((obj) =>
                {
                    return ((System.Func<Net.PkgSkillsPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSkillsPos>>((act) =>
            {
                return new System.Comparison<Net.PkgSkillsPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgSkillsPos, Net.PkgSkillsPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSkillsOne>>((act) =>
            {
                return new System.Predicate<Net.PkgSkillsOne>((obj) =>
                {
                    return ((System.Func<Net.PkgSkillsOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSkillsOne>>((act) =>
            {
                return new System.Comparison<Net.PkgSkillsOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgSkillsOne, Net.PkgSkillsOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.GameObject>>((act) =>
            {
                return new System.Predicate<UnityEngine.GameObject>((obj) =>
                {
                    return ((System.Func<UnityEngine.GameObject, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.GameObject>>((act) =>
            {
                return new System.Comparison<UnityEngine.GameObject>((x, y) =>
                {
                    return ((System.Func<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.MailInfo>>((act) =>
            {
                return new System.Predicate<xc.MailInfo>((obj) =>
                {
                    return ((System.Func<xc.MailInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.MailInfo>>((act) =>
            {
                return new System.Comparison<xc.MailInfo>((x, y) =>
                {
                    return ((System.Func<xc.MailInfo, xc.MailInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAttachment>>((act) =>
            {
                return new System.Predicate<Net.PkgAttachment>((obj) =>
                {
                    return ((System.Func<Net.PkgAttachment, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAttachment>>((act) =>
            {
                return new System.Comparison<Net.PkgAttachment>((x, y) =>
                {
                    return ((System.Func<Net.PkgAttachment, Net.PkgAttachment, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Money>>((act) =>
            {
                return new System.Predicate<xc.Money>((obj) =>
                {
                    return ((System.Func<xc.Money, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Money>>((act) =>
            {
                return new System.Comparison<xc.Money>((x, y) =>
                {
                    return ((System.Func<xc.Money, xc.Money, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.Dictionary<System.UInt32, System.Single>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.Dictionary<System.UInt32, System.Single>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.Dictionary<System.UInt32, System.Single>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.Dictionary<System.UInt32, System.Single>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Collections.Generic.Dictionary<System.UInt32, System.Single>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsItem>>((act) =>
            {
                return new System.Predicate<xc.GoodsItem>((obj) =>
                {
                    return ((System.Func<xc.GoodsItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsItem>>((act) =>
            {
                return new System.Comparison<xc.GoodsItem>((x, y) =>
                {
                    return ((System.Func<xc.GoodsItem, xc.GoodsItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsSoul>>((act) =>
            {
                return new System.Predicate<xc.GoodsSoul>((obj) =>
                {
                    return ((System.Func<xc.GoodsSoul, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsSoul>>((act) =>
            {
                return new System.Comparison<xc.GoodsSoul>((x, y) =>
                {
                    return ((System.Func<xc.GoodsSoul, xc.GoodsSoul, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Equip.EquipHelper.AttributeDescItem>>((act) =>
            {
                return new System.Predicate<xc.Equip.EquipHelper.AttributeDescItem>((obj) =>
                {
                    return ((System.Func<xc.Equip.EquipHelper.AttributeDescItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Equip.EquipHelper.AttributeDescItem>>((act) =>
            {
                return new System.Comparison<xc.Equip.EquipHelper.AttributeDescItem>((x, y) =>
                {
                    return ((System.Func<xc.Equip.EquipHelper.AttributeDescItem, xc.Equip.EquipHelper.AttributeDescItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<DropComponent>>((act) =>
            {
                return new System.Predicate<DropComponent>((obj) =>
                {
                    return ((System.Func<DropComponent, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<DropComponent>>((act) =>
            {
                return new System.Comparison<DropComponent>((x, y) =>
                {
                    return ((System.Func<DropComponent, DropComponent, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.RaycastResult>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.RaycastResult>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.AnimatorClipInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.AnimatorClipInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Selectable>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Selectable>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.FriendsInfo>>((act) =>
            {
                return new System.Predicate<xc.FriendsInfo>((obj) =>
                {
                    return ((System.Func<xc.FriendsInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.FriendsInfo>>((act) =>
            {
                return new System.Comparison<xc.FriendsInfo>((x, y) =>
                {
                    return ((System.Func<xc.FriendsInfo, xc.FriendsInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.CacheReleaser.ReleaseCacheHandle>((act) =>
            {
                return new xc.CacheReleaser.ReleaseCacheHandle((_obj) =>
                {
                    ((System.Action<System.Object>)act)(_obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DelayTimeComponent.EndCallBack>((act) =>
            {
                return new DelayTimeComponent.EndCallBack((args) =>
                {
                    ((System.Action<System.Object>)act)(args);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>((act) =>
            {
                return new xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate((param) =>
                {
                    ((System.Action<System.Object>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>((act) =>
            {
                return new xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate((param) =>
                {
                    ((System.Action<System.Object>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<AnimationController.AnimationCtrlCallBack>((act) =>
            {
                return new AnimationController.AnimationCtrlCallBack((param) =>
                {
                    ((System.Action<System.Object>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UIAutoConnectWindow.OkBtnClickedDelegate>((act) =>
            {
                return new xc.ui.ugui.UIAutoConnectWindow.OkBtnClickedDelegate((param) =>
                {
                    ((System.Action<System.Object>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UIAutoConnectWindow.CancelBtnClickedDelegate>((act) =>
            {
                return new xc.ui.ugui.UIAutoConnectWindow.CancelBtnClickedDelegate((param) =>
                {
                    ((System.Action<System.Object>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ComTouchPress.OnPress>((act) =>
            {
                return new ComTouchPress.OnPress((obj) =>
                {
                    ((System.Action<System.Object>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.FriendShipInfo>>((act) =>
            {
                return new System.Predicate<xc.FriendShipInfo>((obj) =>
                {
                    return ((System.Func<xc.FriendShipInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.FriendShipInfo>>((act) =>
            {
                return new System.Comparison<xc.FriendShipInfo>((x, y) =>
                {
                    return ((System.Func<xc.FriendShipInfo, xc.FriendShipInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<HttpRequest.GETCB>((act) =>
            {
                return new HttpRequest.GETCB((url, error, reply, userData) =>
                {
                    ((System.Action<System.String, System.String, System.String, System.Object>)act)(url, error, reply, userData);
                });
            });


            appdomain.DelegateManager.RegisterDelegateConvertor<DebugUI.ProcessCmdDelegate>((act) =>
            {
                return new DebugUI.ProcessCmdDelegate((cmd) =>
                {
                    return ((System.Func<DebugUI.Command, System.Boolean>)act)(cmd);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ValueRange>>((act) =>
            {
                return new System.Predicate<xc.ValueRange>((obj) =>
                {
                    return ((System.Func<xc.ValueRange, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ValueRange>>((act) =>
            {
                return new System.Comparison<xc.ValueRange>((x, y) =>
                {
                    return ((System.Func<xc.ValueRange, xc.ValueRange, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsLuaEx>>((act) =>
            {
                return new System.Predicate<xc.GoodsLuaEx>((obj) =>
                {
                    return ((System.Func<xc.GoodsLuaEx, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsLuaEx>>((act) =>
            {
                return new System.Comparison<xc.GoodsLuaEx>((x, y) =>
                {
                    return ((System.Func<xc.GoodsLuaEx, xc.GoodsLuaEx, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsMagicEquip>>((act) =>
            {
                return new System.Predicate<xc.GoodsMagicEquip>((obj) =>
                {
                    return ((System.Func<xc.GoodsMagicEquip, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsMagicEquip>>((act) =>
            {
                return new System.Comparison<xc.GoodsMagicEquip>((x, y) =>
                {
                    return ((System.Func<xc.GoodsMagicEquip, xc.GoodsMagicEquip, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsGodEquip>>((act) =>
            {
                return new System.Predicate<xc.GoodsGodEquip>((obj) =>
                {
                    return ((System.Func<xc.GoodsGodEquip, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsGodEquip>>((act) =>
            {
                return new System.Comparison<xc.GoodsGodEquip>((x, y) =>
                {
                    return ((System.Func<xc.GoodsGodEquip, xc.GoodsGodEquip, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsDecorate>>((act) =>
            {
                return new System.Predicate<xc.GoodsDecorate>((obj) =>
                {
                    return ((System.Func<xc.GoodsDecorate, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsDecorate>>((act) =>
            {
                return new System.Comparison<xc.GoodsDecorate>((x, y) =>
                {
                    return ((System.Func<xc.GoodsDecorate, xc.GoodsDecorate, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBDecorate.LegendAttrDescItem>>((act) =>
            {
                return new System.Predicate<xc.DBDecorate.LegendAttrDescItem>((obj) =>
                {
                    return ((System.Func<xc.DBDecorate.LegendAttrDescItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBDecorate.LegendAttrDescItem>>((act) =>
            {
                return new System.Comparison<xc.DBDecorate.LegendAttrDescItem>((x, y) =>
                {
                    return ((System.Func<xc.DBDecorate.LegendAttrDescItem, xc.DBDecorate.LegendAttrDescItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>>((act) =>
            {
                return new System.Predicate<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>((obj) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>>((act) =>
            {
                return new System.Comparison<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>((x, y) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossKiller>>((act) =>
            {
                return new System.Predicate<Net.PkgBossKiller>((obj) =>
                {
                    return ((System.Func<Net.PkgBossKiller, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossKiller>>((act) =>
            {
                return new System.Comparison<Net.PkgBossKiller>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossKiller, Net.PkgBossKiller, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Byte[]>>((act) =>
            {
                return new System.Predicate<System.Byte[]>((obj) =>
                {
                    return ((System.Func<System.Byte[], System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Byte[]>>((act) =>
            {
                return new System.Comparison<System.Byte[]>((x, y) =>
                {
                    return ((System.Func<System.Byte[], System.Byte[], System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>>((act) =>
            {
                return new System.Predicate<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>((obj) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.RedefineBossKiller, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>>((act) =>
            {
                return new System.Comparison<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>((x, y) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.RedefineBossKiller, xc.instance_behaviour.BossBehaviour.RedefineBossKiller, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>>((act) =>
            {
                return new System.Predicate<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>((obj) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.RedefineBossInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>>((act) =>
            {
                return new System.Comparison<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>((x, y) =>
                {
                    return ((System.Func<xc.instance_behaviour.BossBehaviour.RedefineBossInfo, xc.instance_behaviour.BossBehaviour.RedefineBossInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UIItemNewSlot.OnClickFunc2>((act) =>
            {
                return new xc.ui.UIItemNewSlot.OnClickFunc2((goods, item) =>
                {
                    ((System.Action<xc.Goods, xc.ui.UIItemNewSlot>)act)(goods, item);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UIItemNewSlot.OnClickCustomFunc>((act) =>
            {
                return new xc.ui.UIItemNewSlot.OnClickCustomFunc((obj, item) =>
                {
                    ((System.Action<System.Object, xc.ui.UIItemNewSlot>)act)(obj, item);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ui.ugui.UIBaseWindow.BackupWin>>((act) =>
            {
                return new System.Predicate<xc.ui.ugui.UIBaseWindow.BackupWin>((obj) =>
                {
                    return ((System.Func<xc.ui.ugui.UIBaseWindow.BackupWin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ui.ugui.UIBaseWindow.BackupWin>>((act) =>
            {
                return new System.Comparison<xc.ui.ugui.UIBaseWindow.BackupWin>((x, y) =>
                {
                    return ((System.Func<xc.ui.ugui.UIBaseWindow.BackupWin, xc.ui.ugui.UIBaseWindow.BackupWin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UIItemNewSlot.OnClickFunc1>((act) =>
            {
                return new xc.ui.UIItemNewSlot.OnClickFunc1((goods, num) =>
                {
                    ((System.Action<xc.Goods, System.Int32>)act)(goods, num);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ui.ugui.UIBaseWindow>>((act) =>
            {
                return new System.Predicate<xc.ui.ugui.UIBaseWindow>((obj) =>
                {
                    return ((System.Func<xc.ui.ugui.UIBaseWindow, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ui.ugui.UIBaseWindow>>((act) =>
            {
                return new System.Comparison<xc.ui.ugui.UIBaseWindow>((x, y) =>
                {
                    return ((System.Func<xc.ui.ugui.UIBaseWindow, xc.ui.ugui.UIBaseWindow, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UISysConfigBtn.ClickSysBtnCallBack>((act) =>
            {
                return new UISysConfigBtn.ClickSysBtnCallBack((param) =>
                {
                    ((System.Action<System.Object[]>)act)(param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.debug.CommandPanel.CommandInfo>>((act) =>
            {
                return new System.Predicate<xc.debug.CommandPanel.CommandInfo>((obj) =>
                {
                    return ((System.Func<xc.debug.CommandPanel.CommandInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.debug.CommandPanel.CommandInfo>>((act) =>
            {
                return new System.Comparison<xc.debug.CommandPanel.CommandInfo>((x, y) =>
                {
                    return ((System.Func<xc.debug.CommandPanel.CommandInfo, xc.debug.CommandPanel.CommandInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<MiniMapPointInfo>>((act) =>
            {
                return new System.Predicate<MiniMapPointInfo>((obj) =>
                {
                    return ((System.Func<MiniMapPointInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<MiniMapPointInfo>>((act) =>
            {
                return new System.Comparison<MiniMapPointInfo>((x, y) =>
                {
                    return ((System.Func<MiniMapPointInfo, MiniMapPointInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<QuadTreeSceneManager.CubeTime>>((act) =>
            {
                return new System.Predicate<QuadTreeSceneManager.CubeTime>((obj) =>
                {
                    return ((System.Func<QuadTreeSceneManager.CubeTime, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<QuadTreeSceneManager.CubeTime>>((act) =>
            {
                return new System.Comparison<QuadTreeSceneManager.CubeTime>((x, y) =>
                {
                    return ((System.Func<QuadTreeSceneManager.CubeTime, QuadTreeSceneManager.CubeTime, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UIRollNumWidget.Finish>((act) =>
            {
                return new UIRollNumWidget.Finish((go, wid) =>
                {
                    ((System.Action<UnityEngine.GameObject, UIRollNumWidget>)act)(go, wid);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIExpandScrollView.FirstClassNode>>((act) =>
            {
                return new System.Predicate<UIExpandScrollView.FirstClassNode>((obj) =>
                {
                    return ((System.Func<UIExpandScrollView.FirstClassNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIExpandScrollView.FirstClassNode>>((act) =>
            {
                return new System.Comparison<UIExpandScrollView.FirstClassNode>((x, y) =>
                {
                    return ((System.Func<UIExpandScrollView.FirstClassNode, UIExpandScrollView.FirstClassNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIExpandScrollView.SecondClassNode>>((act) =>
            {
                return new System.Predicate<UIExpandScrollView.SecondClassNode>((obj) =>
                {
                    return ((System.Func<UIExpandScrollView.SecondClassNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIExpandScrollView.SecondClassNode>>((act) =>
            {
                return new System.Comparison<UIExpandScrollView.SecondClassNode>((x, y) =>
                {
                    return ((System.Func<UIExpandScrollView.SecondClassNode, UIExpandScrollView.SecondClassNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIExpandScrollView.ThirdClassNode>>((act) =>
            {
                return new System.Predicate<UIExpandScrollView.ThirdClassNode>((obj) =>
                {
                    return ((System.Func<UIExpandScrollView.ThirdClassNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIExpandScrollView.ThirdClassNode>>((act) =>
            {
                return new System.Comparison<UIExpandScrollView.ThirdClassNode>((x, y) =>
                {
                    return ((System.Func<UIExpandScrollView.ThirdClassNode, UIExpandScrollView.ThirdClassNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDropGive>>((act) =>
            {
                return new System.Predicate<Net.PkgDropGive>((obj) =>
                {
                    return ((System.Func<Net.PkgDropGive, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDropGive>>((act) =>
            {
                return new System.Comparison<Net.PkgDropGive>((x, y) =>
                {
                    return ((System.Func<Net.PkgDropGive, Net.PkgDropGive, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ILRuntime.CLR.TypeSystem.IType>>((act) =>
            {
                return new System.Predicate<ILRuntime.CLR.TypeSystem.IType>((obj) =>
                {
                    return ((System.Func<ILRuntime.CLR.TypeSystem.IType, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ILRuntime.CLR.TypeSystem.IType>>((act) =>
            {
                return new System.Comparison<ILRuntime.CLR.TypeSystem.IType>((x, y) =>
                {
                    return ((System.Func<ILRuntime.CLR.TypeSystem.IType, ILRuntime.CLR.TypeSystem.IType, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ILRuntime.CLR.Method.IMethod>>((act) =>
            {
                return new System.Predicate<ILRuntime.CLR.Method.IMethod>((obj) =>
                {
                    return ((System.Func<ILRuntime.CLR.Method.IMethod, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ILRuntime.CLR.Method.IMethod>>((act) =>
            {
                return new System.Comparison<ILRuntime.CLR.Method.IMethod>((x, y) =>
                {
                    return ((System.Func<ILRuntime.CLR.Method.IMethod, ILRuntime.CLR.Method.IMethod, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Object>>((act) =>
            {
                return new System.Predicate<UnityEngine.Object>((obj) =>
                {
                    return ((System.Func<UnityEngine.Object, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Object>>((act) =>
            {
                return new System.Comparison<UnityEngine.Object>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Object, UnityEngine.Object, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Type>>((act) =>
            {
                return new System.Predicate<System.Type>((obj) =>
                {
                    return ((System.Func<System.Type, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Type>>((act) =>
            {
                return new System.Comparison<System.Type>((x, y) =>
                {
                    return ((System.Func<System.Type, System.Type, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SGameEngine.ResourceLoader.OnRemoteFileDownload>((act) =>
            {
                return new SGameEngine.ResourceLoader.OnRemoteFileDownload((url, error, fileData) =>
                {
                    ((System.Action<System.String, System.String, System.Byte[]>)act)(url, error, fileData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<SGameFirstPass.AssetBundleInfoItem>>((act) =>
            {
                return new System.Predicate<SGameFirstPass.AssetBundleInfoItem>((obj) =>
                {
                    return ((System.Func<SGameFirstPass.AssetBundleInfoItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<SGameFirstPass.AssetBundleInfoItem>>((act) =>
            {
                return new System.Comparison<SGameFirstPass.AssetBundleInfoItem>((x, y) =>
                {
                    return ((System.Func<SGameFirstPass.AssetBundleInfoItem, SGameFirstPass.AssetBundleInfoItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>>>((act) =>
            {
                return new System.Predicate<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>>((obj) =>
                {
                    return ((System.Func<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>>>((act) =>
            {
                return new System.Comparison<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>>((x, y) =>
                {
                    return ((System.Func<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ProtoBuf.Serializer.TypeResolver>((act) =>
            {
                return new ProtoBuf.Serializer.TypeResolver((fieldNumber) =>
                {
                    return ((System.Func<System.Int32, System.Type>)act)(fieldNumber);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ProtoBuf.Meta.TypeFormatEventHandler>((act) =>
            {
                return new ProtoBuf.Meta.TypeFormatEventHandler((sender, args) =>
                {
                    ((System.Action<System.Object, ProtoBuf.Meta.TypeFormatEventArgs>)act)(sender, args);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ProtoBuf.Meta.LockContentedEventHandler>((act) =>
            {
                return new ProtoBuf.Meta.LockContentedEventHandler((sender, args) =>
                {
                    ((System.Action<System.Object, ProtoBuf.Meta.LockContentedEventArgs>)act)(sender, args);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Uranus.Runtime.ICondition>>((act) =>
            {
                return new System.Predicate<Uranus.Runtime.ICondition>((obj) =>
                {
                    return ((System.Func<Uranus.Runtime.ICondition, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Uranus.Runtime.ICondition>>((act) =>
            {
                return new System.Comparison<Uranus.Runtime.ICondition>((x, y) =>
                {
                    return ((System.Func<Uranus.Runtime.ICondition, Uranus.Runtime.ICondition, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<BinItemInfo>>((act) =>
            {
                return new System.Predicate<BinItemInfo>((obj) =>
                {
                    return ((System.Func<BinItemInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<BinItemInfo>>((act) =>
            {
                return new System.Comparison<BinItemInfo>((x, y) =>
                {
                    return ((System.Func<BinItemInfo, BinItemInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<SGameFirstPass.AssetPatchInfoItem>>((act) =>
            {
                return new System.Predicate<SGameFirstPass.AssetPatchInfoItem>((obj) =>
                {
                    return ((System.Func<SGameFirstPass.AssetPatchInfoItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<SGameFirstPass.AssetPatchInfoItem>>((act) =>
            {
                return new System.Comparison<SGameFirstPass.AssetPatchInfoItem>((x, y) =>
                {
                    return ((System.Func<SGameFirstPass.AssetPatchInfoItem, SGameFirstPass.AssetPatchInfoItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xpatch.DL_PatchContext.delStateChangeHanlder>((act) =>
            {
                return new xpatch.DL_PatchContext.delStateChangeHanlder((dl_ctx) =>
                {
                    ((System.Action<xpatch.DL_PatchContext>)act)(dl_ctx);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xpatch.DL_BundleContext>>((act) =>
            {
                return new System.Predicate<xpatch.DL_BundleContext>((obj) =>
                {
                    return ((System.Func<xpatch.DL_BundleContext, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xpatch.DL_BundleContext.delStateChangeHanlder>((act) =>
            {
                return new xpatch.DL_BundleContext.delStateChangeHanlder((dl_ctx, state) =>
                {
                    ((System.Action<xpatch.DL_BundleContext, xpatch.EDownloadState>)act)(dl_ctx, state);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xpatch.DL_BundleContext>>((act) =>
            {
                return new System.Comparison<xpatch.DL_BundleContext>((x, y) =>
                {
                    return ((System.Func<xpatch.DL_BundleContext, xpatch.DL_BundleContext, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xpatch.DL_PatchContext>>((act) =>
            {
                return new System.Predicate<xpatch.DL_PatchContext>((obj) =>
                {
                    return ((System.Func<xpatch.DL_PatchContext, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xpatch.DL_PatchContext>>((act) =>
            {
                return new System.Comparison<xpatch.DL_PatchContext>((x, y) =>
                {
                    return ((System.Func<xpatch.DL_PatchContext, xpatch.DL_PatchContext, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<SGameFirstPass.download_process>((act) =>
            {
                return new SGameFirstPass.download_process((_downloaded_size_in_kb, _speed) =>
                {
                    ((System.Action<System.Single, System.Single>)act)(_downloaded_size_in_kb, _speed);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<MikuLuaProfiler.Sample>>((act) =>
            {
                return new System.Predicate<MikuLuaProfiler.Sample>((obj) =>
                {
                    return ((System.Func<MikuLuaProfiler.Sample, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<MikuLuaProfiler.Sample>>((act) =>
            {
                return new System.Comparison<MikuLuaProfiler.Sample>((x, y) =>
                {
                    return ((System.Func<MikuLuaProfiler.Sample, MikuLuaProfiler.Sample, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Byte>>((act) =>
            {
                return new System.Predicate<System.Byte>((obj) =>
                {
                    return ((System.Func<System.Byte, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Byte>>((act) =>
            {
                return new System.Comparison<System.Byte>((x, y) =>
                {
                    return ((System.Func<System.Byte, System.Byte, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAccPhoneInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgAccPhoneInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgAccPhoneInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAccPhoneInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgAccPhoneInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgAccPhoneInfo, Net.PkgAccPhoneInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAccSysSetting>>((act) =>
            {
                return new System.Predicate<Net.PkgAccSysSetting>((obj) =>
                {
                    return ((System.Func<Net.PkgAccSysSetting, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAccSysSetting>>((act) =>
            {
                return new System.Comparison<Net.PkgAccSysSetting>((x, y) =>
                {
                    return ((System.Func<Net.PkgAccSysSetting, Net.PkgAccSysSetting, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgKvStr>>((act) =>
            {
                return new System.Predicate<Net.PkgKvStr>((obj) =>
                {
                    return ((System.Func<Net.PkgKvStr, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgKvStr>>((act) =>
            {
                return new System.Comparison<Net.PkgKvStr>((x, y) =>
                {
                    return ((System.Func<Net.PkgKvStr, Net.PkgKvStr, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPlayerPersonality>>((act) =>
            {
                return new System.Predicate<Net.PkgPlayerPersonality>((obj) =>
                {
                    return ((System.Func<Net.PkgPlayerPersonality, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPlayerPersonality>>((act) =>
            {
                return new System.Comparison<Net.PkgPlayerPersonality>((x, y) =>
                {
                    return ((System.Func<Net.PkgPlayerPersonality, Net.PkgPlayerPersonality, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGoodsGidnum>>((act) =>
            {
                return new System.Predicate<Net.PkgGoodsGidnum>((obj) =>
                {
                    return ((System.Func<Net.PkgGoodsGidnum, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGoodsGidnum>>((act) =>
            {
                return new System.Comparison<Net.PkgGoodsGidnum>((x, y) =>
                {
                    return ((System.Func<Net.PkgGoodsGidnum, Net.PkgGoodsGidnum, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGoodsInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGoodsInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGoodsInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGoodsInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGoodsInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGoodsInfo, Net.PkgGoodsInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgStrengthInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgStrengthInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgStrengthInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgStrengthInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgStrengthInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgStrengthInfo, Net.PkgStrengthInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBaptizeInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgBaptizeInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgBaptizeInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBaptizeInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgBaptizeInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgBaptizeInfo, Net.PkgBaptizeInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBaptizeGroove>>((act) =>
            {
                return new System.Predicate<Net.PkgBaptizeGroove>((obj) =>
                {
                    return ((System.Func<Net.PkgBaptizeGroove, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBaptizeGroove>>((act) =>
            {
                return new System.Comparison<Net.PkgBaptizeGroove>((x, y) =>
                {
                    return ((System.Func<Net.PkgBaptizeGroove, Net.PkgBaptizeGroove, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPlayerClientData>>((act) =>
            {
                return new System.Predicate<Net.PkgPlayerClientData>((obj) =>
                {
                    return ((System.Func<Net.PkgPlayerClientData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPlayerClientData>>((act) =>
            {
                return new System.Comparison<Net.PkgPlayerClientData>((x, y) =>
                {
                    return ((System.Func<Net.PkgPlayerClientData, Net.PkgPlayerClientData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgWorldMemberInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgWorldMemberInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgWorldMemberInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgWorldMemberInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgWorldMemberInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgWorldMemberInfo, Net.PkgWorldMemberInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgNotice>>((act) =>
            {
                return new System.Predicate<Net.PkgNotice>((obj) =>
                {
                    return ((System.Func<Net.PkgNotice, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgNotice>>((act) =>
            {
                return new System.Comparison<Net.PkgNotice>((x, y) =>
                {
                    return ((System.Func<Net.PkgNotice, Net.PkgNotice, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMapLineState>>((act) =>
            {
                return new System.Predicate<Net.PkgMapLineState>((obj) =>
                {
                    return ((System.Func<Net.PkgMapLineState, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMapLineState>>((act) =>
            {
                return new System.Comparison<Net.PkgMapLineState>((x, y) =>
                {
                    return ((System.Func<Net.PkgMapLineState, Net.PkgMapLineState, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgNwarBarPos>>((act) =>
            {
                return new System.Predicate<Net.PkgNwarBarPos>((obj) =>
                {
                    return ((System.Func<Net.PkgNwarBarPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgNwarBarPos>>((act) =>
            {
                return new System.Comparison<Net.PkgNwarBarPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgNwarBarPos, Net.PkgNwarBarPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgNwarNpcPos>>((act) =>
            {
                return new System.Predicate<Net.PkgNwarNpcPos>((obj) =>
                {
                    return ((System.Func<Net.PkgNwarNpcPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgNwarNpcPos>>((act) =>
            {
                return new System.Comparison<Net.PkgNwarNpcPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgNwarNpcPos, Net.PkgNwarNpcPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTrialBossPass>>((act) =>
            {
                return new System.Predicate<Net.PkgTrialBossPass>((obj) =>
                {
                    return ((System.Func<Net.PkgTrialBossPass, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTrialBossPass>>((act) =>
            {
                return new System.Comparison<Net.PkgTrialBossPass>((x, y) =>
                {
                    return ((System.Func<Net.PkgTrialBossPass, Net.PkgTrialBossPass, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgWorshipHuman>>((act) =>
            {
                return new System.Predicate<Net.PkgWorshipHuman>((obj) =>
                {
                    return ((System.Func<Net.PkgWorshipHuman, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgWorshipHuman>>((act) =>
            {
                return new System.Comparison<Net.PkgWorshipHuman>((x, y) =>
                {
                    return ((System.Func<Net.PkgWorshipHuman, Net.PkgWorshipHuman, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgWorshipAnswer>>((act) =>
            {
                return new System.Predicate<Net.PkgWorshipAnswer>((obj) =>
                {
                    return ((System.Func<Net.PkgWorshipAnswer, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgWorshipAnswer>>((act) =>
            {
                return new System.Comparison<Net.PkgWorshipAnswer>((x, y) =>
                {
                    return ((System.Func<Net.PkgWorshipAnswer, Net.PkgWorshipAnswer, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTombInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTombInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTombInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTombInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTombInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTombInfo, Net.PkgTombInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGleagueResource>>((act) =>
            {
                return new System.Predicate<Net.PkgGleagueResource>((obj) =>
                {
                    return ((System.Func<Net.PkgGleagueResource, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGleagueResource>>((act) =>
            {
                return new System.Comparison<Net.PkgGleagueResource>((x, y) =>
                {
                    return ((System.Func<Net.PkgGleagueResource, Net.PkgGleagueResource, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGleagueWarGuild>>((act) =>
            {
                return new System.Predicate<Net.PkgGleagueWarGuild>((obj) =>
                {
                    return ((System.Func<Net.PkgGleagueWarGuild, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGleagueWarGuild>>((act) =>
            {
                return new System.Comparison<Net.PkgGleagueWarGuild>((x, y) =>
                {
                    return ((System.Func<Net.PkgGleagueWarGuild, Net.PkgGleagueWarGuild, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGleagueAchieve>>((act) =>
            {
                return new System.Predicate<Net.PkgGleagueAchieve>((obj) =>
                {
                    return ((System.Func<Net.PkgGleagueAchieve, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGleagueAchieve>>((act) =>
            {
                return new System.Comparison<Net.PkgGleagueAchieve>((x, y) =>
                {
                    return ((System.Func<Net.PkgGleagueAchieve, Net.PkgGleagueAchieve, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBattleFieldOpponent>>((act) =>
            {
                return new System.Predicate<Net.PkgBattleFieldOpponent>((obj) =>
                {
                    return ((System.Func<Net.PkgBattleFieldOpponent, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBattleFieldOpponent>>((act) =>
            {
                return new System.Comparison<Net.PkgBattleFieldOpponent>((x, y) =>
                {
                    return ((System.Func<Net.PkgBattleFieldOpponent, Net.PkgBattleFieldOpponent, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBattleFieldHistory>>((act) =>
            {
                return new System.Predicate<Net.PkgBattleFieldHistory>((obj) =>
                {
                    return ((System.Func<Net.PkgBattleFieldHistory, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBattleFieldHistory>>((act) =>
            {
                return new System.Comparison<Net.PkgBattleFieldHistory>((x, y) =>
                {
                    return ((System.Func<Net.PkgBattleFieldHistory, Net.PkgBattleFieldHistory, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLordComeBossInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgLordComeBossInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgLordComeBossInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLordComeBossInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgLordComeBossInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgLordComeBossInfo, Net.PkgLordComeBossInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLordComeBossLog>>((act) =>
            {
                return new System.Predicate<Net.PkgLordComeBossLog>((obj) =>
                {
                    return ((System.Func<Net.PkgLordComeBossLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLordComeBossLog>>((act) =>
            {
                return new System.Comparison<Net.PkgLordComeBossLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgLordComeBossLog, Net.PkgLordComeBossLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLordComeRank>>((act) =>
            {
                return new System.Predicate<Net.PkgLordComeRank>((obj) =>
                {
                    return ((System.Func<Net.PkgLordComeRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLordComeRank>>((act) =>
            {
                return new System.Comparison<Net.PkgLordComeRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgLordComeRank, Net.PkgLordComeRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeakArenaRank>>((act) =>
            {
                return new System.Predicate<Net.PkgPeakArenaRank>((obj) =>
                {
                    return ((System.Func<Net.PkgPeakArenaRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeakArenaRank>>((act) =>
            {
                return new System.Comparison<Net.PkgPeakArenaRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeakArenaRank, Net.PkgPeakArenaRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeakRank>>((act) =>
            {
                return new System.Predicate<Net.PkgPeakRank>((obj) =>
                {
                    return ((System.Func<Net.PkgPeakRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeakRank>>((act) =>
            {
                return new System.Comparison<Net.PkgPeakRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeakRank, Net.PkgPeakRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeakClanMini>>((act) =>
            {
                return new System.Predicate<Net.PkgPeakClanMini>((obj) =>
                {
                    return ((System.Func<Net.PkgPeakClanMini, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeakClanMini>>((act) =>
            {
                return new System.Comparison<Net.PkgPeakClanMini>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeakClanMini, Net.PkgPeakClanMini, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeakClan>>((act) =>
            {
                return new System.Predicate<Net.PkgPeakClan>((obj) =>
                {
                    return ((System.Func<Net.PkgPeakClan, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeakClan>>((act) =>
            {
                return new System.Comparison<Net.PkgPeakClan>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeakClan, Net.PkgPeakClan, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeak3PMatchOne>>((act) =>
            {
                return new System.Predicate<Net.PkgPeak3PMatchOne>((obj) =>
                {
                    return ((System.Func<Net.PkgPeak3PMatchOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeak3PMatchOne>>((act) =>
            {
                return new System.Comparison<Net.PkgPeak3PMatchOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeak3PMatchOne, Net.PkgPeak3PMatchOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeak3PResultOne>>((act) =>
            {
                return new System.Predicate<Net.PkgPeak3PResultOne>((obj) =>
                {
                    return ((System.Func<Net.PkgPeak3PResultOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeak3PResultOne>>((act) =>
            {
                return new System.Comparison<Net.PkgPeak3PResultOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeak3PResultOne, Net.PkgPeak3PResultOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMeleeScore>>((act) =>
            {
                return new System.Predicate<Net.PkgMeleeScore>((obj) =>
                {
                    return ((System.Func<Net.PkgMeleeScore, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMeleeScore>>((act) =>
            {
                return new System.Comparison<Net.PkgMeleeScore>((x, y) =>
                {
                    return ((System.Func<Net.PkgMeleeScore, Net.PkgMeleeScore, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodDemonDuelRank>>((act) =>
            {
                return new System.Predicate<Net.PkgGodDemonDuelRank>((obj) =>
                {
                    return ((System.Func<Net.PkgGodDemonDuelRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodDemonDuelRank>>((act) =>
            {
                return new System.Comparison<Net.PkgGodDemonDuelRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodDemonDuelRank, Net.PkgGodDemonDuelRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSkillsCd>>((act) =>
            {
                return new System.Predicate<Net.PkgSkillsCd>((obj) =>
                {
                    return ((System.Func<Net.PkgSkillsCd, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSkillsCd>>((act) =>
            {
                return new System.Comparison<Net.PkgSkillsCd>((x, y) =>
                {
                    return ((System.Func<Net.PkgSkillsCd, Net.PkgSkillsCd, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGoodsCd>>((act) =>
            {
                return new System.Predicate<Net.PkgGoodsCd>((obj) =>
                {
                    return ((System.Func<Net.PkgGoodsCd, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGoodsCd>>((act) =>
            {
                return new System.Comparison<Net.PkgGoodsCd>((x, y) =>
                {
                    return ((System.Func<Net.PkgGoodsCd, Net.PkgGoodsCd, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGoodsDailyLimit>>((act) =>
            {
                return new System.Predicate<Net.PkgGoodsDailyLimit>((obj) =>
                {
                    return ((System.Func<Net.PkgGoodsDailyLimit, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGoodsDailyLimit>>((act) =>
            {
                return new System.Comparison<Net.PkgGoodsDailyLimit>((x, y) =>
                {
                    return ((System.Func<Net.PkgGoodsDailyLimit, Net.PkgGoodsDailyLimit, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGoodsUsageCounter>>((act) =>
            {
                return new System.Predicate<Net.PkgGoodsUsageCounter>((obj) =>
                {
                    return ((System.Func<Net.PkgGoodsUsageCounter, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGoodsUsageCounter>>((act) =>
            {
                return new System.Comparison<Net.PkgGoodsUsageCounter>((x, y) =>
                {
                    return ((System.Func<Net.PkgGoodsUsageCounter, Net.PkgGoodsUsageCounter, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMoneyInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgMoneyInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgMoneyInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMoneyInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgMoneyInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgMoneyInfo, Net.PkgMoneyInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEpShapeRefine>>((act) =>
            {
                return new System.Predicate<Net.PkgEpShapeRefine>((obj) =>
                {
                    return ((System.Func<Net.PkgEpShapeRefine, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEpShapeRefine>>((act) =>
            {
                return new System.Comparison<Net.PkgEpShapeRefine>((x, y) =>
                {
                    return ((System.Func<Net.PkgEpShapeRefine, Net.PkgEpShapeRefine, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEpQuenchSpirits>>((act) =>
            {
                return new System.Predicate<Net.PkgEpQuenchSpirits>((obj) =>
                {
                    return ((System.Func<Net.PkgEpQuenchSpirits, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEpQuenchSpirits>>((act) =>
            {
                return new System.Comparison<Net.PkgEpQuenchSpirits>((x, y) =>
                {
                    return ((System.Func<Net.PkgEpQuenchSpirits, Net.PkgEpQuenchSpirits, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgElementEpStrength>>((act) =>
            {
                return new System.Predicate<Net.PkgElementEpStrength>((obj) =>
                {
                    return ((System.Func<Net.PkgElementEpStrength, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgElementEpStrength>>((act) =>
            {
                return new System.Comparison<Net.PkgElementEpStrength>((x, y) =>
                {
                    return ((System.Func<Net.PkgElementEpStrength, Net.PkgElementEpStrength, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLightSoulOne>>((act) =>
            {
                return new System.Predicate<Net.PkgLightSoulOne>((obj) =>
                {
                    return ((System.Func<Net.PkgLightSoulOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLightSoulOne>>((act) =>
            {
                return new System.Comparison<Net.PkgLightSoulOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgLightSoulOne, Net.PkgLightSoulOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLightEquipOne>>((act) =>
            {
                return new System.Predicate<Net.PkgLightEquipOne>((obj) =>
                {
                    return ((System.Func<Net.PkgLightEquipOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLightEquipOne>>((act) =>
            {
                return new System.Comparison<Net.PkgLightEquipOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgLightEquipOne, Net.PkgLightEquipOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFiveElemStrength>>((act) =>
            {
                return new System.Predicate<Net.PkgFiveElemStrength>((obj) =>
                {
                    return ((System.Func<Net.PkgFiveElemStrength, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFiveElemStrength>>((act) =>
            {
                return new System.Comparison<Net.PkgFiveElemStrength>((x, y) =>
                {
                    return ((System.Func<Net.PkgFiveElemStrength, Net.PkgFiveElemStrength, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFiveElemTrain>>((act) =>
            {
                return new System.Predicate<Net.PkgFiveElemTrain>((obj) =>
                {
                    return ((System.Func<Net.PkgFiveElemTrain, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFiveElemTrain>>((act) =>
            {
                return new System.Comparison<Net.PkgFiveElemTrain>((x, y) =>
                {
                    return ((System.Func<Net.PkgFiveElemTrain, Net.PkgFiveElemTrain, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFiveElemSuit>>((act) =>
            {
                return new System.Predicate<Net.PkgFiveElemSuit>((obj) =>
                {
                    return ((System.Func<Net.PkgFiveElemSuit, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFiveElemSuit>>((act) =>
            {
                return new System.Comparison<Net.PkgFiveElemSuit>((x, y) =>
                {
                    return ((System.Func<Net.PkgFiveElemSuit, Net.PkgFiveElemSuit, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgQuotaList>>((act) =>
            {
                return new System.Predicate<Net.PkgQuotaList>((obj) =>
                {
                    return ((System.Func<Net.PkgQuotaList, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgQuotaList>>((act) =>
            {
                return new System.Comparison<Net.PkgQuotaList>((x, y) =>
                {
                    return ((System.Func<Net.PkgQuotaList, Net.PkgQuotaList, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShopInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgShopInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgShopInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShopInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgShopInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgShopInfo, Net.PkgShopInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMshopItem>>((act) =>
            {
                return new System.Predicate<Net.PkgMshopItem>((obj) =>
                {
                    return ((System.Func<Net.PkgMshopItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMshopItem>>((act) =>
            {
                return new System.Comparison<Net.PkgMshopItem>((x, y) =>
                {
                    return ((System.Func<Net.PkgMshopItem, Net.PkgMshopItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMshopOrder>>((act) =>
            {
                return new System.Predicate<Net.PkgMshopOrder>((obj) =>
                {
                    return ((System.Func<Net.PkgMshopOrder, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMshopOrder>>((act) =>
            {
                return new System.Comparison<Net.PkgMshopOrder>((x, y) =>
                {
                    return ((System.Func<Net.PkgMshopOrder, Net.PkgMshopOrder, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgArtifactSpirit>>((act) =>
            {
                return new System.Predicate<Net.PkgArtifactSpirit>((obj) =>
                {
                    return ((System.Func<Net.PkgArtifactSpirit, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgArtifactSpirit>>((act) =>
            {
                return new System.Comparison<Net.PkgArtifactSpirit>((x, y) =>
                {
                    return ((System.Func<Net.PkgArtifactSpirit, Net.PkgArtifactSpirit, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgArtifactSpiritDecompose>>((act) =>
            {
                return new System.Predicate<Net.PkgArtifactSpiritDecompose>((obj) =>
                {
                    return ((System.Func<Net.PkgArtifactSpiritDecompose, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgArtifactSpiritDecompose>>((act) =>
            {
                return new System.Comparison<Net.PkgArtifactSpiritDecompose>((x, y) =>
                {
                    return ((System.Func<Net.PkgArtifactSpiritDecompose, Net.PkgArtifactSpiritDecompose, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDecorateAttr>>((act) =>
            {
                return new System.Predicate<Net.PkgDecorateAttr>((obj) =>
                {
                    return ((System.Func<Net.PkgDecorateAttr, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDecorateAttr>>((act) =>
            {
                return new System.Comparison<Net.PkgDecorateAttr>((x, y) =>
                {
                    return ((System.Func<Net.PkgDecorateAttr, Net.PkgDecorateAttr, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDecoratePosInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgDecoratePosInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgDecoratePosInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDecoratePosInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgDecoratePosInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgDecoratePosInfo, Net.PkgDecoratePosInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodEquipAttr>>((act) =>
            {
                return new System.Predicate<Net.PkgGodEquipAttr>((obj) =>
                {
                    return ((System.Func<Net.PkgGodEquipAttr, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodEquipAttr>>((act) =>
            {
                return new System.Comparison<Net.PkgGodEquipAttr>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodEquipAttr, Net.PkgGodEquipAttr, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodEquipPosInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGodEquipPosInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGodEquipPosInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodEquipPosInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGodEquipPosInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodEquipPosInfo, Net.PkgGodEquipPosInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodEquipSkill>>((act) =>
            {
                return new System.Predicate<Net.PkgGodEquipSkill>((obj) =>
                {
                    return ((System.Func<Net.PkgGodEquipSkill, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodEquipSkill>>((act) =>
            {
                return new System.Comparison<Net.PkgGodEquipSkill>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodEquipSkill, Net.PkgGodEquipSkill, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodBaptizeGroove>>((act) =>
            {
                return new System.Predicate<Net.PkgGodBaptizeGroove>((obj) =>
                {
                    return ((System.Func<Net.PkgGodBaptizeGroove, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodBaptizeGroove>>((act) =>
            {
                return new System.Comparison<Net.PkgGodBaptizeGroove>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodBaptizeGroove, Net.PkgGodBaptizeGroove, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodBaptizeInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGodBaptizeInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGodBaptizeInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodBaptizeInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGodBaptizeInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodBaptizeInfo, Net.PkgGodBaptizeInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEngrave>>((act) =>
            {
                return new System.Predicate<Net.PkgEngrave>((obj) =>
                {
                    return ((System.Func<Net.PkgEngrave, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEngrave>>((act) =>
            {
                return new System.Comparison<Net.PkgEngrave>((x, y) =>
                {
                    return ((System.Func<Net.PkgEngrave, Net.PkgEngrave, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEngravePosInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgEngravePosInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgEngravePosInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEngravePosInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgEngravePosInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgEngravePosInfo, Net.PkgEngravePosInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRideEquipPos>>((act) =>
            {
                return new System.Predicate<Net.PkgRideEquipPos>((obj) =>
                {
                    return ((System.Func<Net.PkgRideEquipPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRideEquipPos>>((act) =>
            {
                return new System.Comparison<Net.PkgRideEquipPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgRideEquipPos, Net.PkgRideEquipPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEquipZhuhun>>((act) =>
            {
                return new System.Predicate<Net.PkgEquipZhuhun>((obj) =>
                {
                    return ((System.Func<Net.PkgEquipZhuhun, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEquipZhuhun>>((act) =>
            {
                return new System.Comparison<Net.PkgEquipZhuhun>((x, y) =>
                {
                    return ((System.Func<Net.PkgEquipZhuhun, Net.PkgEquipZhuhun, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEquipCarve>>((act) =>
            {
                return new System.Predicate<Net.PkgEquipCarve>((obj) =>
                {
                    return ((System.Func<Net.PkgEquipCarve, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEquipCarve>>((act) =>
            {
                return new System.Comparison<Net.PkgEquipCarve>((x, y) =>
                {
                    return ((System.Func<Net.PkgEquipCarve, Net.PkgEquipCarve, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPetEquipPos>>((act) =>
            {
                return new System.Predicate<Net.PkgPetEquipPos>((obj) =>
                {
                    return ((System.Func<Net.PkgPetEquipPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPetEquipPos>>((act) =>
            {
                return new System.Comparison<Net.PkgPetEquipPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgPetEquipPos, Net.PkgPetEquipPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgHolySuit>>((act) =>
            {
                return new System.Predicate<Net.PkgHolySuit>((obj) =>
                {
                    return ((System.Func<Net.PkgHolySuit, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgHolySuit>>((act) =>
            {
                return new System.Comparison<Net.PkgHolySuit>((x, y) =>
                {
                    return ((System.Func<Net.PkgHolySuit, Net.PkgHolySuit, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLeg>>((act) =>
            {
                return new System.Predicate<Net.PkgLeg>((obj) =>
                {
                    return ((System.Func<Net.PkgLeg, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLeg>>((act) =>
            {
                return new System.Comparison<Net.PkgLeg>((x, y) =>
                {
                    return ((System.Func<Net.PkgLeg, Net.PkgLeg, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLegInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgLegInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgLegInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLegInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgLegInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgLegInfo, Net.PkgLegInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTaskInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTaskInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTaskInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTaskInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTaskInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTaskInfo, Net.PkgTaskInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTaskTitleInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTaskTitleInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTaskTitleInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTaskTitleInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTaskTitleInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTaskTitleInfo, Net.PkgTaskTitleInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMail>>((act) =>
            {
                return new System.Predicate<Net.PkgMail>((obj) =>
                {
                    return ((System.Func<Net.PkgMail, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMail>>((act) =>
            {
                return new System.Comparison<Net.PkgMail>((x, y) =>
                {
                    return ((System.Func<Net.PkgMail, Net.PkgMail, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMarqueeInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgMarqueeInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgMarqueeInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMarqueeInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgMarqueeInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgMarqueeInfo, Net.PkgMarqueeInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRankLine>>((act) =>
            {
                return new System.Predicate<Net.PkgRankLine>((obj) =>
                {
                    return ((System.Func<Net.PkgRankLine, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRankLine>>((act) =>
            {
                return new System.Comparison<Net.PkgRankLine>((x, y) =>
                {
                    return ((System.Func<Net.PkgRankLine, Net.PkgRankLine, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Int64>>((act) =>
            {
                return new System.Predicate<System.Int64>((obj) =>
                {
                    return ((System.Func<System.Int64, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Int64>>((act) =>
            {
                return new System.Comparison<System.Int64>((x, y) =>
                {
                    return ((System.Func<System.Int64, System.Int64, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFinalRank>>((act) =>
            {
                return new System.Predicate<Net.PkgFinalRank>((obj) =>
                {
                    return ((System.Func<Net.PkgFinalRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFinalRank>>((act) =>
            {
                return new System.Comparison<Net.PkgFinalRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgFinalRank, Net.PkgFinalRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActDaily>>((act) =>
            {
                return new System.Predicate<Net.PkgActDaily>((obj) =>
                {
                    return ((System.Func<Net.PkgActDaily, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActDaily>>((act) =>
            {
                return new System.Comparison<Net.PkgActDaily>((x, y) =>
                {
                    return ((System.Func<Net.PkgActDaily, Net.PkgActDaily, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActState>>((act) =>
            {
                return new System.Predicate<Net.PkgActState>((obj) =>
                {
                    return ((System.Func<Net.PkgActState, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActState>>((act) =>
            {
                return new System.Comparison<Net.PkgActState>((x, y) =>
                {
                    return ((System.Func<Net.PkgActState, Net.PkgActState, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActYunying>>((act) =>
            {
                return new System.Predicate<Net.PkgActYunying>((obj) =>
                {
                    return ((System.Func<Net.PkgActYunying, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActYunying>>((act) =>
            {
                return new System.Comparison<Net.PkgActYunying>((x, y) =>
                {
                    return ((System.Func<Net.PkgActYunying, Net.PkgActYunying, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAccPayTarget>>((act) =>
            {
                return new System.Predicate<Net.PkgAccPayTarget>((obj) =>
                {
                    return ((System.Func<Net.PkgAccPayTarget, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAccPayTarget>>((act) =>
            {
                return new System.Comparison<Net.PkgAccPayTarget>((x, y) =>
                {
                    return ((System.Func<Net.PkgAccPayTarget, Net.PkgAccPayTarget, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgHolidayAccPayTarget>>((act) =>
            {
                return new System.Predicate<Net.PkgHolidayAccPayTarget>((obj) =>
                {
                    return ((System.Func<Net.PkgHolidayAccPayTarget, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgHolidayAccPayTarget>>((act) =>
            {
                return new System.Comparison<Net.PkgHolidayAccPayTarget>((x, y) =>
                {
                    return ((System.Func<Net.PkgHolidayAccPayTarget, Net.PkgHolidayAccPayTarget, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgAccTreasureTower>>((act) =>
            {
                return new System.Predicate<Net.PkgAccTreasureTower>((obj) =>
                {
                    return ((System.Func<Net.PkgAccTreasureTower, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgAccTreasureTower>>((act) =>
            {
                return new System.Comparison<Net.PkgAccTreasureTower>((x, y) =>
                {
                    return ((System.Func<Net.PkgAccTreasureTower, Net.PkgAccTreasureTower, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureTowerCostConf>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureTowerCostConf>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerCostConf, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureTowerCostConf>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureTowerCostConf>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerCostConf, Net.PkgTreasureTowerCostConf, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureTowerItemConf>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureTowerItemConf>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerItemConf, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureTowerItemConf>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureTowerItemConf>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerItemConf, Net.PkgTreasureTowerItemConf, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureTowerResetConf>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureTowerResetConf>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerResetConf, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureTowerResetConf>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureTowerResetConf>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerResetConf, Net.PkgTreasureTowerResetConf, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureTowerGradeConf>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureTowerGradeConf>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerGradeConf, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureTowerGradeConf>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureTowerGradeConf>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerGradeConf, Net.PkgTreasureTowerGradeConf, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureTowerConf>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureTowerConf>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerConf, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureTowerConf>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureTowerConf>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureTowerConf, Net.PkgTreasureTowerConf, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBargainInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgBargainInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgBargainInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBargainInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgBargainInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgBargainInfo, Net.PkgBargainInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPainKill>>((act) =>
            {
                return new System.Predicate<Net.PkgPainKill>((obj) =>
                {
                    return ((System.Func<Net.PkgPainKill, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPainKill>>((act) =>
            {
                return new System.Comparison<Net.PkgPainKill>((x, y) =>
                {
                    return ((System.Func<Net.PkgPainKill, Net.PkgPainKill, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildCompeteInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildCompeteInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildCompeteInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildCompeteInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildCompeteInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildCompeteInfo, Net.PkgGuildCompeteInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgConsumeRankSb>>((act) =>
            {
                return new System.Predicate<Net.PkgConsumeRankSb>((obj) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSb, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgConsumeRankSb>>((act) =>
            {
                return new System.Comparison<Net.PkgConsumeRankSb>((x, y) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSb, Net.PkgConsumeRankSb, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgConsumeRankSbReward>>((act) =>
            {
                return new System.Predicate<Net.PkgConsumeRankSbReward>((obj) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSbReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgConsumeRankSbReward>>((act) =>
            {
                return new System.Comparison<Net.PkgConsumeRankSbReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSbReward, Net.PkgConsumeRankSbReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgConsumeRankSpring>>((act) =>
            {
                return new System.Predicate<Net.PkgConsumeRankSpring>((obj) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSpring, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgConsumeRankSpring>>((act) =>
            {
                return new System.Comparison<Net.PkgConsumeRankSpring>((x, y) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSpring, Net.PkgConsumeRankSpring, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgConsumeRankSpringReward>>((act) =>
            {
                return new System.Predicate<Net.PkgConsumeRankSpringReward>((obj) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSpringReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgConsumeRankSpringReward>>((act) =>
            {
                return new System.Comparison<Net.PkgConsumeRankSpringReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgConsumeRankSpringReward, Net.PkgConsumeRankSpringReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossActBuyLog>>((act) =>
            {
                return new System.Predicate<Net.PkgBossActBuyLog>((obj) =>
                {
                    return ((System.Func<Net.PkgBossActBuyLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossActBuyLog>>((act) =>
            {
                return new System.Comparison<Net.PkgBossActBuyLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossActBuyLog, Net.PkgBossActBuyLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRedpackActLucky>>((act) =>
            {
                return new System.Predicate<Net.PkgRedpackActLucky>((obj) =>
                {
                    return ((System.Func<Net.PkgRedpackActLucky, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRedpackActLucky>>((act) =>
            {
                return new System.Comparison<Net.PkgRedpackActLucky>((x, y) =>
                {
                    return ((System.Func<Net.PkgRedpackActLucky, Net.PkgRedpackActLucky, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRedpackAct>>((act) =>
            {
                return new System.Predicate<Net.PkgRedpackAct>((obj) =>
                {
                    return ((System.Func<Net.PkgRedpackAct, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRedpackAct>>((act) =>
            {
                return new System.Comparison<Net.PkgRedpackAct>((x, y) =>
                {
                    return ((System.Func<Net.PkgRedpackAct, Net.PkgRedpackAct, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgCollectCompose>>((act) =>
            {
                return new System.Predicate<Net.PkgCollectCompose>((obj) =>
                {
                    return ((System.Func<Net.PkgCollectCompose, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgCollectCompose>>((act) =>
            {
                return new System.Comparison<Net.PkgCollectCompose>((x, y) =>
                {
                    return ((System.Func<Net.PkgCollectCompose, Net.PkgCollectCompose, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgKnockEgg>>((act) =>
            {
                return new System.Predicate<Net.PkgKnockEgg>((obj) =>
                {
                    return ((System.Func<Net.PkgKnockEgg, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgKnockEgg>>((act) =>
            {
                return new System.Comparison<Net.PkgKnockEgg>((x, y) =>
                {
                    return ((System.Func<Net.PkgKnockEgg, Net.PkgKnockEgg, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEggLog>>((act) =>
            {
                return new System.Predicate<Net.PkgEggLog>((obj) =>
                {
                    return ((System.Func<Net.PkgEggLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEggLog>>((act) =>
            {
                return new System.Comparison<Net.PkgEggLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgEggLog, Net.PkgEggLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgEggGoods>>((act) =>
            {
                return new System.Predicate<Net.PkgEggGoods>((obj) =>
                {
                    return ((System.Func<Net.PkgEggGoods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgEggGoods>>((act) =>
            {
                return new System.Comparison<Net.PkgEggGoods>((x, y) =>
                {
                    return ((System.Func<Net.PkgEggGoods, Net.PkgEggGoods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActReturnGoal>>((act) =>
            {
                return new System.Predicate<Net.PkgActReturnGoal>((obj) =>
                {
                    return ((System.Func<Net.PkgActReturnGoal, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActReturnGoal>>((act) =>
            {
                return new System.Comparison<Net.PkgActReturnGoal>((x, y) =>
                {
                    return ((System.Func<Net.PkgActReturnGoal, Net.PkgActReturnGoal, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDtaskIndexInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgDtaskIndexInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgDtaskIndexInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDtaskIndexInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgDtaskIndexInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgDtaskIndexInfo, Net.PkgDtaskIndexInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDtaskDayInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgDtaskDayInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgDtaskDayInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDtaskDayInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgDtaskDayInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgDtaskDayInfo, Net.PkgDtaskDayInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLuckyTurntableLog>>((act) =>
            {
                return new System.Predicate<Net.PkgLuckyTurntableLog>((obj) =>
                {
                    return ((System.Func<Net.PkgLuckyTurntableLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLuckyTurntableLog>>((act) =>
            {
                return new System.Comparison<Net.PkgLuckyTurntableLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgLuckyTurntableLog, Net.PkgLuckyTurntableLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActPrayLog>>((act) =>
            {
                return new System.Predicate<Net.PkgActPrayLog>((obj) =>
                {
                    return ((System.Func<Net.PkgActPrayLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActPrayLog>>((act) =>
            {
                return new System.Comparison<Net.PkgActPrayLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgActPrayLog, Net.PkgActPrayLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActPrayDo>>((act) =>
            {
                return new System.Predicate<Net.PkgActPrayDo>((obj) =>
                {
                    return ((System.Func<Net.PkgActPrayDo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActPrayDo>>((act) =>
            {
                return new System.Comparison<Net.PkgActPrayDo>((x, y) =>
                {
                    return ((System.Func<Net.PkgActPrayDo, Net.PkgActPrayDo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanCostRank>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanCostRank>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanCostRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanCostRank>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanCostRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanCostRank, Net.PkgSpanCostRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgStarWishLog>>((act) =>
            {
                return new System.Predicate<Net.PkgStarWishLog>((obj) =>
                {
                    return ((System.Func<Net.PkgStarWishLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgStarWishLog>>((act) =>
            {
                return new System.Comparison<Net.PkgStarWishLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgStarWishLog, Net.PkgStarWishLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgHonorableGiftGoods>>((act) =>
            {
                return new System.Predicate<Net.PkgHonorableGiftGoods>((obj) =>
                {
                    return ((System.Func<Net.PkgHonorableGiftGoods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgHonorableGiftGoods>>((act) =>
            {
                return new System.Comparison<Net.PkgHonorableGiftGoods>((x, y) =>
                {
                    return ((System.Func<Net.PkgHonorableGiftGoods, Net.PkgHonorableGiftGoods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTimeLimitItem>>((act) =>
            {
                return new System.Predicate<Net.PkgTimeLimitItem>((obj) =>
                {
                    return ((System.Func<Net.PkgTimeLimitItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTimeLimitItem>>((act) =>
            {
                return new System.Comparison<Net.PkgTimeLimitItem>((x, y) =>
                {
                    return ((System.Func<Net.PkgTimeLimitItem, Net.PkgTimeLimitItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTimeLimitBuy>>((act) =>
            {
                return new System.Predicate<Net.PkgTimeLimitBuy>((obj) =>
                {
                    return ((System.Func<Net.PkgTimeLimitBuy, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTimeLimitBuy>>((act) =>
            {
                return new System.Comparison<Net.PkgTimeLimitBuy>((x, y) =>
                {
                    return ((System.Func<Net.PkgTimeLimitBuy, Net.PkgTimeLimitBuy, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTransferSaleItem>>((act) =>
            {
                return new System.Predicate<Net.PkgTransferSaleItem>((obj) =>
                {
                    return ((System.Func<Net.PkgTransferSaleItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTransferSaleItem>>((act) =>
            {
                return new System.Comparison<Net.PkgTransferSaleItem>((x, y) =>
                {
                    return ((System.Func<Net.PkgTransferSaleItem, Net.PkgTransferSaleItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgExaltedGiftGoods>>((act) =>
            {
                return new System.Predicate<Net.PkgExaltedGiftGoods>((obj) =>
                {
                    return ((System.Func<Net.PkgExaltedGiftGoods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgExaltedGiftGoods>>((act) =>
            {
                return new System.Comparison<Net.PkgExaltedGiftGoods>((x, y) =>
                {
                    return ((System.Func<Net.PkgExaltedGiftGoods, Net.PkgExaltedGiftGoods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgActFestivalInvest>>((act) =>
            {
                return new System.Predicate<Net.PkgActFestivalInvest>((obj) =>
                {
                    return ((System.Func<Net.PkgActFestivalInvest, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgActFestivalInvest>>((act) =>
            {
                return new System.Comparison<Net.PkgActFestivalInvest>((x, y) =>
                {
                    return ((System.Func<Net.PkgActFestivalInvest, Net.PkgActFestivalInvest, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureReplaceInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureReplaceInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureReplaceInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureReplaceInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureReplaceInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureReplaceInfo, Net.PkgTreasureReplaceInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureBigAward>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureBigAward>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureBigAward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureBigAward>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureBigAward>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureBigAward, Net.PkgTreasureBigAward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTeamIntro>>((act) =>
            {
                return new System.Predicate<Net.PkgTeamIntro>((obj) =>
                {
                    return ((System.Func<Net.PkgTeamIntro, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTeamIntro>>((act) =>
            {
                return new System.Comparison<Net.PkgTeamIntro>((x, y) =>
                {
                    return ((System.Func<Net.PkgTeamIntro, Net.PkgTeamIntro, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMemberPos>>((act) =>
            {
                return new System.Predicate<Net.PkgMemberPos>((obj) =>
                {
                    return ((System.Func<Net.PkgMemberPos, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMemberPos>>((act) =>
            {
                return new System.Comparison<Net.PkgMemberPos>((x, y) =>
                {
                    return ((System.Func<Net.PkgMemberPos, Net.PkgMemberPos, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgInviteMember>>((act) =>
            {
                return new System.Predicate<Net.PkgInviteMember>((obj) =>
                {
                    return ((System.Func<Net.PkgInviteMember, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgInviteMember>>((act) =>
            {
                return new System.Comparison<Net.PkgInviteMember>((x, y) =>
                {
                    return ((System.Func<Net.PkgInviteMember, Net.PkgInviteMember, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgBossInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgBossInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgBossInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossInfo, Net.PkgBossInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossFight>>((act) =>
            {
                return new System.Predicate<Net.PkgBossFight>((obj) =>
                {
                    return ((System.Func<Net.PkgBossFight, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossFight>>((act) =>
            {
                return new System.Comparison<Net.PkgBossFight>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossFight, Net.PkgBossFight, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossAffRank>>((act) =>
            {
                return new System.Predicate<Net.PkgBossAffRank>((obj) =>
                {
                    return ((System.Func<Net.PkgBossAffRank, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossAffRank>>((act) =>
            {
                return new System.Comparison<Net.PkgBossAffRank>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossAffRank, Net.PkgBossAffRank, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBossDropInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgBossDropInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgBossDropInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBossDropInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgBossDropInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgBossDropInfo, Net.PkgBossDropInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanBossMon>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanBossMon>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanBossMon, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanBossMon>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanBossMon>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanBossMon, Net.PkgSpanBossMon, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanBossGroupOne>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanBossGroupOne>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanBossGroupOne, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanBossGroupOne>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanBossGroupOne>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanBossGroupOne, Net.PkgSpanBossGroupOne, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFiveEmperorsBoss>>((act) =>
            {
                return new System.Predicate<Net.PkgFiveEmperorsBoss>((obj) =>
                {
                    return ((System.Func<Net.PkgFiveEmperorsBoss, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFiveEmperorsBoss>>((act) =>
            {
                return new System.Comparison<Net.PkgFiveEmperorsBoss>((x, y) =>
                {
                    return ((System.Func<Net.PkgFiveEmperorsBoss, Net.PkgFiveEmperorsBoss, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFiveEmperorsTotem>>((act) =>
            {
                return new System.Predicate<Net.PkgFiveEmperorsTotem>((obj) =>
                {
                    return ((System.Func<Net.PkgFiveEmperorsTotem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFiveEmperorsTotem>>((act) =>
            {
                return new System.Comparison<Net.PkgFiveEmperorsTotem>((x, y) =>
                {
                    return ((System.Func<Net.PkgFiveEmperorsTotem, Net.PkgFiveEmperorsTotem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSaintBeastDng>>((act) =>
            {
                return new System.Predicate<Net.PkgSaintBeastDng>((obj) =>
                {
                    return ((System.Func<Net.PkgSaintBeastDng, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSaintBeastDng>>((act) =>
            {
                return new System.Comparison<Net.PkgSaintBeastDng>((x, y) =>
                {
                    return ((System.Func<Net.PkgSaintBeastDng, Net.PkgSaintBeastDng, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSaintBox>>((act) =>
            {
                return new System.Predicate<Net.PkgSaintBox>((obj) =>
                {
                    return ((System.Func<Net.PkgSaintBox, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSaintBox>>((act) =>
            {
                return new System.Comparison<Net.PkgSaintBox>((x, y) =>
                {
                    return ((System.Func<Net.PkgSaintBox, Net.PkgSaintBox, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSaintBossLv>>((act) =>
            {
                return new System.Predicate<Net.PkgSaintBossLv>((obj) =>
                {
                    return ((System.Func<Net.PkgSaintBossLv, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSaintBossLv>>((act) =>
            {
                return new System.Comparison<Net.PkgSaintBossLv>((x, y) =>
                {
                    return ((System.Func<Net.PkgSaintBossLv, Net.PkgSaintBossLv, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTrigram>>((act) =>
            {
                return new System.Predicate<Net.PkgTrigram>((obj) =>
                {
                    return ((System.Func<Net.PkgTrigram, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTrigram>>((act) =>
            {
                return new System.Comparison<Net.PkgTrigram>((x, y) =>
                {
                    return ((System.Func<Net.PkgTrigram, Net.PkgTrigram, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRune>>((act) =>
            {
                return new System.Predicate<Net.PkgRune>((obj) =>
                {
                    return ((System.Func<Net.PkgRune, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRune>>((act) =>
            {
                return new System.Comparison<Net.PkgRune>((x, y) =>
                {
                    return ((System.Func<Net.PkgRune, Net.PkgRune, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildIntro>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildIntro>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildIntro, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildIntro>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildIntro>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildIntro, Net.PkgGuildIntro, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildMember>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildMember>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildMember, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildMember>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildMember>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildMember, Net.PkgGuildMember, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildWareLogGoods>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildWareLogGoods>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildWareLogGoods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildWareLogGoods>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildWareLogGoods>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildWareLogGoods, Net.PkgGuildWareLogGoods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildWareLog>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildWareLog>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildWareLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildWareLog>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildWareLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildWareLog, Net.PkgGuildWareLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGlRoundInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGlRoundInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGlRoundInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGlRoundInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGlRoundInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGlRoundInfo, Net.PkgGlRoundInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGlLevelInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGlLevelInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGlLevelInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGlLevelInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGlLevelInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGlLevelInfo, Net.PkgGlLevelInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGlBattleInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGlBattleInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGlBattleInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGlBattleInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGlBattleInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGlBattleInfo, Net.PkgGlBattleInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildTask>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildTask>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildTask, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildTask>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildTask>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildTask, Net.PkgGuildTask, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildRedpackLucky>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildRedpackLucky>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildRedpackLucky, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildRedpackLucky>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildRedpackLucky>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildRedpackLucky, Net.PkgGuildRedpackLucky, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGuildRedpackInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGuildRedpackInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGuildRedpackInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGuildRedpackInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGuildRedpackInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGuildRedpackInfo, Net.PkgGuildRedpackInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSgbBattleGuild>>((act) =>
            {
                return new System.Predicate<Net.PkgSgbBattleGuild>((obj) =>
                {
                    return ((System.Func<Net.PkgSgbBattleGuild, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSgbBattleGuild>>((act) =>
            {
                return new System.Comparison<Net.PkgSgbBattleGuild>((x, y) =>
                {
                    return ((System.Func<Net.PkgSgbBattleGuild, Net.PkgSgbBattleGuild, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSgbRankGuild>>((act) =>
            {
                return new System.Predicate<Net.PkgSgbRankGuild>((obj) =>
                {
                    return ((System.Func<Net.PkgSgbRankGuild, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSgbRankGuild>>((act) =>
            {
                return new System.Comparison<Net.PkgSgbRankGuild>((x, y) =>
                {
                    return ((System.Func<Net.PkgSgbRankGuild, Net.PkgSgbRankGuild, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSgbBattleInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSgbBattleInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSgbBattleInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSgbBattleInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSgbBattleInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSgbBattleInfo, Net.PkgSgbBattleInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMarketGoods>>((act) =>
            {
                return new System.Predicate<Net.PkgMarketGoods>((obj) =>
                {
                    return ((System.Func<Net.PkgMarketGoods, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMarketGoods>>((act) =>
            {
                return new System.Comparison<Net.PkgMarketGoods>((x, y) =>
                {
                    return ((System.Func<Net.PkgMarketGoods, Net.PkgMarketGoods, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDtIndexInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgDtIndexInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgDtIndexInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDtIndexInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgDtIndexInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgDtIndexInfo, Net.PkgDtIndexInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgDtDayInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgDtDayInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgDtDayInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgDtDayInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgDtDayInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgDtDayInfo, Net.PkgDtDayInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgResourceRetrieve>>((act) =>
            {
                return new System.Predicate<Net.PkgResourceRetrieve>((obj) =>
                {
                    return ((System.Func<Net.PkgResourceRetrieve, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgResourceRetrieve>>((act) =>
            {
                return new System.Comparison<Net.PkgResourceRetrieve>((x, y) =>
                {
                    return ((System.Func<Net.PkgResourceRetrieve, Net.PkgResourceRetrieve, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPrayInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgPrayInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgPrayInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPrayInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgPrayInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgPrayInfo, Net.PkgPrayInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSubTargetInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSubTargetInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSubTargetInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSubTargetInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSubTargetInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSubTargetInfo, Net.PkgSubTargetInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTargetInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTargetInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTargetInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTargetInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTargetInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTargetInfo, Net.PkgTargetInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSubPhaseInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSubPhaseInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSubPhaseInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSubPhaseInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSubPhaseInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSubPhaseInfo, Net.PkgSubPhaseInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPhaseInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgPhaseInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgPhaseInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPhaseInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgPhaseInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgPhaseInfo, Net.PkgPhaseInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSevenGiftInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSevenGiftInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSevenGiftInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSevenGiftInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSevenGiftInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSevenGiftInfo, Net.PkgSevenGiftInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgImpactRankInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgImpactRankInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgImpactRankInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgImpactRankInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgImpactRankInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgImpactRankInfo, Net.PkgImpactRankInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLvReward>>((act) =>
            {
                return new System.Predicate<Net.PkgLvReward>((obj) =>
                {
                    return ((System.Func<Net.PkgLvReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLvReward>>((act) =>
            {
                return new System.Comparison<Net.PkgLvReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgLvReward, Net.PkgLvReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgVipLvReward>>((act) =>
            {
                return new System.Predicate<Net.PkgVipLvReward>((obj) =>
                {
                    return ((System.Func<Net.PkgVipLvReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgVipLvReward>>((act) =>
            {
                return new System.Comparison<Net.PkgVipLvReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgVipLvReward, Net.PkgVipLvReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSepcReward>>((act) =>
            {
                return new System.Predicate<Net.PkgSepcReward>((obj) =>
                {
                    return ((System.Func<Net.PkgSepcReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSepcReward>>((act) =>
            {
                return new System.Comparison<Net.PkgSepcReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgSepcReward, Net.PkgSepcReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgBuyLog>>((act) =>
            {
                return new System.Predicate<Net.PkgBuyLog>((obj) =>
                {
                    return ((System.Func<Net.PkgBuyLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgBuyLog>>((act) =>
            {
                return new System.Comparison<Net.PkgBuyLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgBuyLog, Net.PkgBuyLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgChosenResult>>((act) =>
            {
                return new System.Predicate<Net.PkgChosenResult>((obj) =>
                {
                    return ((System.Func<Net.PkgChosenResult, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgChosenResult>>((act) =>
            {
                return new System.Comparison<Net.PkgChosenResult>((x, y) =>
                {
                    return ((System.Func<Net.PkgChosenResult, Net.PkgChosenResult, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgVipInvestUnit>>((act) =>
            {
                return new System.Predicate<Net.PkgVipInvestUnit>((obj) =>
                {
                    return ((System.Func<Net.PkgVipInvestUnit, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgVipInvestUnit>>((act) =>
            {
                return new System.Comparison<Net.PkgVipInvestUnit>((x, y) =>
                {
                    return ((System.Func<Net.PkgVipInvestUnit, Net.PkgVipInvestUnit, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureHuntInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureHuntInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureHuntInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureHuntInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureHuntInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureHuntInfo, Net.PkgTreasureHuntInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTreasureInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTreasureInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTreasureInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTreasureInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTreasureInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTreasureInfo, Net.PkgTreasureInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSuperHuntInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSuperHuntInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSuperHuntInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSuperHuntInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSuperHuntInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSuperHuntInfo, Net.PkgSuperHuntInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSubGodExpInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSubGodExpInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSubGodExpInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSubGodExpInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSubGodExpInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSubGodExpInfo, Net.PkgSubGodExpInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGodExpInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGodExpInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGodExpInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGodExpInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGodExpInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGodExpInfo, Net.PkgGodExpInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgZeroGift>>((act) =>
            {
                return new System.Predicate<Net.PkgZeroGift>((obj) =>
                {
                    return ((System.Func<Net.PkgZeroGift, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgZeroGift>>((act) =>
            {
                return new System.Comparison<Net.PkgZeroGift>((x, y) =>
                {
                    return ((System.Func<Net.PkgZeroGift, Net.PkgZeroGift, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitSaleItem>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitSaleItem>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitSaleItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitSaleItem>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitSaleItem>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitSaleItem, Net.PkgLimitSaleItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitSaleShop>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitSaleShop>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitSaleShop, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitSaleShop>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitSaleShop>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitSaleShop, Net.PkgLimitSaleShop, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSoulInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSoulInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSoulInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSoulInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSoulInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSoulInfo, Net.PkgSoulInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitCollect>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitCollect>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitCollect, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitCollect>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitCollect>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitCollect, Net.PkgLimitCollect, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitTask>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitTask>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitTask, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitTask>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitTask>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitTask, Net.PkgLimitTask, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPayRed>>((act) =>
            {
                return new System.Predicate<Net.PkgPayRed>((obj) =>
                {
                    return ((System.Func<Net.PkgPayRed, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPayRed>>((act) =>
            {
                return new System.Comparison<Net.PkgPayRed>((x, y) =>
                {
                    return ((System.Func<Net.PkgPayRed, Net.PkgPayRed, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPayRedBorn>>((act) =>
            {
                return new System.Predicate<Net.PkgPayRedBorn>((obj) =>
                {
                    return ((System.Func<Net.PkgPayRedBorn, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPayRedBorn>>((act) =>
            {
                return new System.Comparison<Net.PkgPayRedBorn>((x, y) =>
                {
                    return ((System.Func<Net.PkgPayRedBorn, Net.PkgPayRedBorn, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPayRedTaker>>((act) =>
            {
                return new System.Predicate<Net.PkgPayRedTaker>((obj) =>
                {
                    return ((System.Func<Net.PkgPayRedTaker, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPayRedTaker>>((act) =>
            {
                return new System.Comparison<Net.PkgPayRedTaker>((x, y) =>
                {
                    return ((System.Func<Net.PkgPayRedTaker, Net.PkgPayRedTaker, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFireworkCelebrationLog>>((act) =>
            {
                return new System.Predicate<Net.PkgFireworkCelebrationLog>((obj) =>
                {
                    return ((System.Func<Net.PkgFireworkCelebrationLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFireworkCelebrationLog>>((act) =>
            {
                return new System.Comparison<Net.PkgFireworkCelebrationLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgFireworkCelebrationLog, Net.PkgFireworkCelebrationLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLightEquip>>((act) =>
            {
                return new System.Predicate<Net.PkgLightEquip>((obj) =>
                {
                    return ((System.Func<Net.PkgLightEquip, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLightEquip>>((act) =>
            {
                return new System.Comparison<Net.PkgLightEquip>((x, y) =>
                {
                    return ((System.Func<Net.PkgLightEquip, Net.PkgLightEquip, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPeakHuntInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgPeakHuntInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgPeakHuntInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPeakHuntInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgPeakHuntInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgPeakHuntInfo, Net.PkgPeakHuntInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRedPacket>>((act) =>
            {
                return new System.Predicate<Net.PkgRedPacket>((obj) =>
                {
                    return ((System.Func<Net.PkgRedPacket, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRedPacket>>((act) =>
            {
                return new System.Comparison<Net.PkgRedPacket>((x, y) =>
                {
                    return ((System.Func<Net.PkgRedPacket, Net.PkgRedPacket, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgConPay>>((act) =>
            {
                return new System.Predicate<Net.PkgConPay>((obj) =>
                {
                    return ((System.Func<Net.PkgConPay, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgConPay>>((act) =>
            {
                return new System.Comparison<Net.PkgConPay>((x, y) =>
                {
                    return ((System.Func<Net.PkgConPay, Net.PkgConPay, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShopGiftSale>>((act) =>
            {
                return new System.Predicate<Net.PkgShopGiftSale>((obj) =>
                {
                    return ((System.Func<Net.PkgShopGiftSale, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShopGiftSale>>((act) =>
            {
                return new System.Comparison<Net.PkgShopGiftSale>((x, y) =>
                {
                    return ((System.Func<Net.PkgShopGiftSale, Net.PkgShopGiftSale, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShopGiftBuy>>((act) =>
            {
                return new System.Predicate<Net.PkgShopGiftBuy>((obj) =>
                {
                    return ((System.Func<Net.PkgShopGiftBuy, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShopGiftBuy>>((act) =>
            {
                return new System.Comparison<Net.PkgShopGiftBuy>((x, y) =>
                {
                    return ((System.Func<Net.PkgShopGiftBuy, Net.PkgShopGiftBuy, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShopDay>>((act) =>
            {
                return new System.Predicate<Net.PkgShopDay>((obj) =>
                {
                    return ((System.Func<Net.PkgShopDay, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShopDay>>((act) =>
            {
                return new System.Comparison<Net.PkgShopDay>((x, y) =>
                {
                    return ((System.Func<Net.PkgShopDay, Net.PkgShopDay, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShopGift>>((act) =>
            {
                return new System.Predicate<Net.PkgShopGift>((obj) =>
                {
                    return ((System.Func<Net.PkgShopGift, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShopGift>>((act) =>
            {
                return new System.Comparison<Net.PkgShopGift>((x, y) =>
                {
                    return ((System.Func<Net.PkgShopGift, Net.PkgShopGift, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanSepcReward>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanSepcReward>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanSepcReward, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanSepcReward>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanSepcReward>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanSepcReward, Net.PkgSpanSepcReward, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanChosenInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanChosenInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanChosenInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanChosenInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanChosenInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanChosenInfo, Net.PkgSpanChosenInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPlayerBuy>>((act) =>
            {
                return new System.Predicate<Net.PkgPlayerBuy>((obj) =>
                {
                    return ((System.Func<Net.PkgPlayerBuy, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPlayerBuy>>((act) =>
            {
                return new System.Comparison<Net.PkgPlayerBuy>((x, y) =>
                {
                    return ((System.Func<Net.PkgPlayerBuy, Net.PkgPlayerBuy, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanBuyLog>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanBuyLog>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanBuyLog, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanBuyLog>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanBuyLog>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanBuyLog, Net.PkgSpanBuyLog, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgSpanChosenResult>>((act) =>
            {
                return new System.Predicate<Net.PkgSpanChosenResult>((obj) =>
                {
                    return ((System.Func<Net.PkgSpanChosenResult, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgSpanChosenResult>>((act) =>
            {
                return new System.Comparison<Net.PkgSpanChosenResult>((x, y) =>
                {
                    return ((System.Func<Net.PkgSpanChosenResult, Net.PkgSpanChosenResult, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitSaleSpanItem>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitSaleSpanItem>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitSaleSpanItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitSaleSpanItem>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitSaleSpanItem>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitSaleSpanItem, Net.PkgLimitSaleSpanItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgLimitSaleSpanShop>>((act) =>
            {
                return new System.Predicate<Net.PkgLimitSaleSpanShop>((obj) =>
                {
                    return ((System.Func<Net.PkgLimitSaleSpanShop, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgLimitSaleSpanShop>>((act) =>
            {
                return new System.Comparison<Net.PkgLimitSaleSpanShop>((x, y) =>
                {
                    return ((System.Func<Net.PkgLimitSaleSpanShop, Net.PkgLimitSaleSpanShop, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgQiankunHuntInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgQiankunHuntInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgQiankunHuntInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgQiankunHuntInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgQiankunHuntInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgQiankunHuntInfo, Net.PkgQiankunHuntInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMarryReserveCouple>>((act) =>
            {
                return new System.Predicate<Net.PkgMarryReserveCouple>((obj) =>
                {
                    return ((System.Func<Net.PkgMarryReserveCouple, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMarryReserveCouple>>((act) =>
            {
                return new System.Comparison<Net.PkgMarryReserveCouple>((x, y) =>
                {
                    return ((System.Func<Net.PkgMarryReserveCouple, Net.PkgMarryReserveCouple, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgWeddingGift>>((act) =>
            {
                return new System.Predicate<Net.PkgWeddingGift>((obj) =>
                {
                    return ((System.Func<Net.PkgWeddingGift, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgWeddingGift>>((act) =>
            {
                return new System.Comparison<Net.PkgWeddingGift>((x, y) =>
                {
                    return ((System.Func<Net.PkgWeddingGift, Net.PkgWeddingGift, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgMarryPerfitRecords>>((act) =>
            {
                return new System.Predicate<Net.PkgMarryPerfitRecords>((obj) =>
                {
                    return ((System.Func<Net.PkgMarryPerfitRecords, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgMarryPerfitRecords>>((act) =>
            {
                return new System.Comparison<Net.PkgMarryPerfitRecords>((x, y) =>
                {
                    return ((System.Func<Net.PkgMarryPerfitRecords, Net.PkgMarryPerfitRecords, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgStigma>>((act) =>
            {
                return new System.Predicate<Net.PkgStigma>((obj) =>
                {
                    return ((System.Func<Net.PkgStigma, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgStigma>>((act) =>
            {
                return new System.Comparison<Net.PkgStigma>((x, y) =>
                {
                    return ((System.Func<Net.PkgStigma, Net.PkgStigma, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgPetSkin>>((act) =>
            {
                return new System.Predicate<Net.PkgPetSkin>((obj) =>
                {
                    return ((System.Func<Net.PkgPetSkin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgPetSkin>>((act) =>
            {
                return new System.Comparison<Net.PkgPetSkin>((x, y) =>
                {
                    return ((System.Func<Net.PkgPetSkin, Net.PkgPetSkin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgGrowInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgGrowInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgGrowInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgGrowInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgGrowInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgGrowInfo, Net.PkgGrowInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgRideSkin>>((act) =>
            {
                return new System.Predicate<Net.PkgRideSkin>((obj) =>
                {
                    return ((System.Func<Net.PkgRideSkin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgRideSkin>>((act) =>
            {
                return new System.Comparison<Net.PkgRideSkin>((x, y) =>
                {
                    return ((System.Func<Net.PkgRideSkin, Net.PkgRideSkin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFruitInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgFruitInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgFruitInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFruitInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgFruitInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgFruitInfo, Net.PkgFruitInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgFashion>>((act) =>
            {
                return new System.Predicate<Net.PkgFashion>((obj) =>
                {
                    return ((System.Func<Net.PkgFashion, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgFashion>>((act) =>
            {
                return new System.Comparison<Net.PkgFashion>((x, y) =>
                {
                    return ((System.Func<Net.PkgFashion, Net.PkgFashion, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgExpJade>>((act) =>
            {
                return new System.Predicate<Net.PkgExpJade>((obj) =>
                {
                    return ((System.Func<Net.PkgExpJade, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgExpJade>>((act) =>
            {
                return new System.Comparison<Net.PkgExpJade>((x, y) =>
                {
                    return ((System.Func<Net.PkgExpJade, Net.PkgExpJade, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgVipBonus>>((act) =>
            {
                return new System.Predicate<Net.PkgVipBonus>((obj) =>
                {
                    return ((System.Func<Net.PkgVipBonus, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgVipBonus>>((act) =>
            {
                return new System.Comparison<Net.PkgVipBonus>((x, y) =>
                {
                    return ((System.Func<Net.PkgVipBonus, Net.PkgVipBonus, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTitleInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgTitleInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgTitleInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTitleInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgTitleInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgTitleInfo, Net.PkgTitleInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgTalentSystem>>((act) =>
            {
                return new System.Predicate<Net.PkgTalentSystem>((obj) =>
                {
                    return ((System.Func<Net.PkgTalentSystem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgTalentSystem>>((act) =>
            {
                return new System.Comparison<Net.PkgTalentSystem>((x, y) =>
                {
                    return ((System.Func<Net.PkgTalentSystem, Net.PkgTalentSystem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgShowInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgShowInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgShowInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgShowInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgShowInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgShowInfo, Net.PkgShowInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgArtifactInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgArtifactInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgArtifactInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgArtifactInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgArtifactInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgArtifactInfo, Net.PkgArtifactInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgArtifactSkillInfo>>((act) =>
            {
                return new System.Predicate<Net.PkgArtifactSkillInfo>((obj) =>
                {
                    return ((System.Func<Net.PkgArtifactSkillInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgArtifactSkillInfo>>((act) =>
            {
                return new System.Comparison<Net.PkgArtifactSkillInfo>((x, y) =>
                {
                    return ((System.Func<Net.PkgArtifactSkillInfo, Net.PkgArtifactSkillInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Net.PkgQualityAdvance>>((act) =>
            {
                return new System.Predicate<Net.PkgQualityAdvance>((obj) =>
                {
                    return ((System.Func<Net.PkgQualityAdvance, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Net.PkgQualityAdvance>>((act) =>
            {
                return new System.Comparison<Net.PkgQualityAdvance>((x, y) =>
                {
                    return ((System.Func<Net.PkgQualityAdvance, Net.PkgQualityAdvance, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Object>>((act) =>
            {
                return new System.Predicate<System.Object>((obj) =>
                {
                    return ((System.Func<System.Object, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Object>>((act) =>
            {
                return new System.Comparison<System.Object>((x, y) =>
                {
                    return ((System.Func<System.Object, System.Object, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBAttrs.DBAttrsItem>>((act) =>
            {
                return new System.Predicate<xc.DBAttrs.DBAttrsItem>((obj) =>
                {
                    return ((System.Func<xc.DBAttrs.DBAttrsItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBAttrs.DBAttrsItem>>((act) =>
            {
                return new System.Comparison<xc.DBAttrs.DBAttrsItem>((x, y) =>
                {
                    return ((System.Func<xc.DBAttrs.DBAttrsItem, xc.DBAttrs.DBAttrsItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBDecoratePos.DBDecoratePosItem>>((act) =>
            {
                return new System.Predicate<xc.DBDecoratePos.DBDecoratePosItem>((obj) =>
                {
                    return ((System.Func<xc.DBDecoratePos.DBDecoratePosItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBDecoratePos.DBDecoratePosItem>>((act) =>
            {
                return new System.Comparison<xc.DBDecoratePos.DBDecoratePosItem>((x, y) =>
                {
                    return ((System.Func<xc.DBDecoratePos.DBDecoratePosItem, xc.DBDecoratePos.DBDecoratePosItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBEngrave.EngraveInfo>>((act) =>
            {
                return new System.Predicate<xc.DBEngrave.EngraveInfo>((obj) =>
                {
                    return ((System.Func<xc.DBEngrave.EngraveInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBEngrave.EngraveInfo>>((act) =>
            {
                return new System.Comparison<xc.DBEngrave.EngraveInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBEngrave.EngraveInfo, xc.DBEngrave.EngraveInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGem.GemInfo>>((act) =>
            {
                return new System.Predicate<xc.DBGem.GemInfo>((obj) =>
                {
                    return ((System.Func<xc.DBGem.GemInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGem.GemInfo>>((act) =>
            {
                return new System.Comparison<xc.DBGem.GemInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBGem.GemInfo, xc.DBGem.GemInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBTextResource.DBGoodsItem>>((act) =>
            {
                return new System.Predicate<xc.DBTextResource.DBGoodsItem>((obj) =>
                {
                    return ((System.Func<xc.DBTextResource.DBGoodsItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBTextResource.DBGoodsItem>>((act) =>
            {
                return new System.Comparison<xc.DBTextResource.DBGoodsItem>((x, y) =>
                {
                    return ((System.Func<xc.DBTextResource.DBGoodsItem, xc.DBTextResource.DBGoodsItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketFilter.OneDBMarketFilter>>((act) =>
            {
                return new System.Predicate<xc.DBMarketFilter.OneDBMarketFilter>((obj) =>
                {
                    return ((System.Func<xc.DBMarketFilter.OneDBMarketFilter, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketFilter.OneDBMarketFilter>>((act) =>
            {
                return new System.Comparison<xc.DBMarketFilter.OneDBMarketFilter>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketFilter.OneDBMarketFilter, xc.DBMarketFilter.OneDBMarketFilter, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketFilter.DBMarketFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBMarketFilter.DBMarketFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBMarketFilter.DBMarketFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketFilter.DBMarketFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBMarketFilter.DBMarketFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketFilter.DBMarketFilterItem, xc.DBMarketFilter.DBMarketFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketQualityFilter.DBMarketQualityFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBMarketQualityFilter.DBMarketQualityFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBMarketQualityFilter.DBMarketQualityFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketQualityFilter.DBMarketQualityFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBMarketQualityFilter.DBMarketQualityFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketQualityFilter.DBMarketQualityFilterItem, xc.DBMarketQualityFilter.DBMarketQualityFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBMarketStepFilter.DBMarketStepFilterItem>>((act) =>
            {
                return new System.Predicate<xc.DBMarketStepFilter.DBMarketStepFilterItem>((obj) =>
                {
                    return ((System.Func<xc.DBMarketStepFilter.DBMarketStepFilterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBMarketStepFilter.DBMarketStepFilterItem>>((act) =>
            {
                return new System.Comparison<xc.DBMarketStepFilter.DBMarketStepFilterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBMarketStepFilter.DBMarketStepFilterItem, xc.DBMarketStepFilter.DBMarketStepFilterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.PreloadInfo>>((act) =>
            {
                return new System.Predicate<xc.PreloadInfo>((obj) =>
                {
                    return ((System.Func<xc.PreloadInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.PreloadInfo>>((act) =>
            {
                return new System.Comparison<xc.PreloadInfo>((x, y) =>
                {
                    return ((System.Func<xc.PreloadInfo, xc.PreloadInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSuitAttr.DBSuitAttrInfo>>((act) =>
            {
                return new System.Predicate<xc.DBSuitAttr.DBSuitAttrInfo>((obj) =>
                {
                    return ((System.Func<xc.DBSuitAttr.DBSuitAttrInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSuitAttr.DBSuitAttrInfo>>((act) =>
            {
                return new System.Comparison<xc.DBSuitAttr.DBSuitAttrInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBSuitAttr.DBSuitAttrInfo, xc.DBSuitAttr.DBSuitAttrInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSuitRefine.DBSuitRefineItem>>((act) =>
            {
                return new System.Predicate<xc.DBSuitRefine.DBSuitRefineItem>((obj) =>
                {
                    return ((System.Func<xc.DBSuitRefine.DBSuitRefineItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSuitRefine.DBSuitRefineItem>>((act) =>
            {
                return new System.Comparison<xc.DBSuitRefine.DBSuitRefineItem>((x, y) =>
                {
                    return ((System.Func<xc.DBSuitRefine.DBSuitRefineItem, xc.DBSuitRefine.DBSuitRefineItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBDataAllSkill.AllSkillInfo>>((act) =>
            {
                return new System.Predicate<xc.DBDataAllSkill.AllSkillInfo>((obj) =>
                {
                    return ((System.Func<xc.DBDataAllSkill.AllSkillInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBDataAllSkill.AllSkillInfo>>((act) =>
            {
                return new System.Comparison<xc.DBDataAllSkill.AllSkillInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBDataAllSkill.AllSkillInfo, xc.DBDataAllSkill.AllSkillInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>((act) =>
            {
                return new System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>((obj) =>
                {
                    return ((System.Func<xc.DBGrowSkin.DBGrowSkinItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGrowSkin.DBGrowSkinItem>>((act) =>
            {
                return new System.Comparison<xc.DBGrowSkin.DBGrowSkinItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGrowSkin.DBGrowSkinItem, xc.DBGrowSkin.DBGrowSkinItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGuildBoss.DBGuildBossItem>>((act) =>
            {
                return new System.Predicate<xc.DBGuildBoss.DBGuildBossItem>((obj) =>
                {
                    return ((System.Func<xc.DBGuildBoss.DBGuildBossItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGuildBoss.DBGuildBossItem>>((act) =>
            {
                return new System.Comparison<xc.DBGuildBoss.DBGuildBossItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGuildBoss.DBGuildBossItem, xc.DBGuildBoss.DBGuildBossItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGuildBoss.DBGuildBossStatisticItem>>((act) =>
            {
                return new System.Predicate<xc.DBGuildBoss.DBGuildBossStatisticItem>((obj) =>
                {
                    return ((System.Func<xc.DBGuildBoss.DBGuildBossStatisticItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGuildBoss.DBGuildBossStatisticItem>>((act) =>
            {
                return new System.Comparison<xc.DBGuildBoss.DBGuildBossStatisticItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGuildBoss.DBGuildBossStatisticItem, xc.DBGuildBoss.DBGuildBossStatisticItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBGuildSkill.DBCommonAttrItem>>((act) =>
            {
                return new System.Predicate<xc.DBGuildSkill.DBCommonAttrItem>((obj) =>
                {
                    return ((System.Func<xc.DBGuildSkill.DBCommonAttrItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBGuildSkill.DBCommonAttrItem>>((act) =>
            {
                return new System.Comparison<xc.DBGuildSkill.DBCommonAttrItem>((x, y) =>
                {
                    return ((System.Func<xc.DBGuildSkill.DBCommonAttrItem, xc.DBGuildSkill.DBCommonAttrItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.HangInfo.TagInfo>>((act) =>
            {
                return new System.Predicate<xc.HangInfo.TagInfo>((obj) =>
                {
                    return ((System.Func<xc.HangInfo.TagInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.HangInfo.TagInfo>>((act) =>
            {
                return new System.Comparison<xc.HangInfo.TagInfo>((x, y) =>
                {
                    return ((System.Func<xc.HangInfo.TagInfo, xc.HangInfo.TagInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPet.PetSkillItem>>((act) =>
            {
                return new System.Predicate<xc.DBPet.PetSkillItem>((obj) =>
                {
                    return ((System.Func<xc.DBPet.PetSkillItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPet.PetSkillItem>>((act) =>
            {
                return new System.Comparison<xc.DBPet.PetSkillItem>((x, y) =>
                {
                    return ((System.Func<xc.DBPet.PetSkillItem, xc.DBPet.PetSkillItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPet.PetInfo>>((act) =>
            {
                return new System.Predicate<xc.DBPet.PetInfo>((obj) =>
                {
                    return ((System.Func<xc.DBPet.PetInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPet.PetInfo>>((act) =>
            {
                return new System.Comparison<xc.DBPet.PetInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBPet.PetInfo, xc.DBPet.PetInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPetFetter.DBPetFetterItem>>((act) =>
            {
                return new System.Predicate<xc.DBPetFetter.DBPetFetterItem>((obj) =>
                {
                    return ((System.Func<xc.DBPetFetter.DBPetFetterItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPetFetter.DBPetFetterItem>>((act) =>
            {
                return new System.Comparison<xc.DBPetFetter.DBPetFetterItem>((x, y) =>
                {
                    return ((System.Func<xc.DBPetFetter.DBPetFetterItem, xc.DBPetFetter.DBPetFetterItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPetFetter.FetterSkillItem>>((act) =>
            {
                return new System.Predicate<xc.DBPetFetter.FetterSkillItem>((obj) =>
                {
                    return ((System.Func<xc.DBPetFetter.FetterSkillItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPetFetter.FetterSkillItem>>((act) =>
            {
                return new System.Comparison<xc.DBPetFetter.FetterSkillItem>((x, y) =>
                {
                    return ((System.Func<xc.DBPetFetter.FetterSkillItem, xc.DBPetFetter.FetterSkillItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPet.UnLockPrePetCondition>>((act) =>
            {
                return new System.Predicate<xc.DBPet.UnLockPrePetCondition>((obj) =>
                {
                    return ((System.Func<xc.DBPet.UnLockPrePetCondition, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPet.UnLockPrePetCondition>>((act) =>
            {
                return new System.Comparison<xc.DBPet.UnLockPrePetCondition>((x, y) =>
                {
                    return ((System.Func<xc.DBPet.UnLockPrePetCondition, xc.DBPet.UnLockPrePetCondition, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSkillSelection.SkillSelectionInfo>>((act) =>
            {
                return new System.Predicate<xc.DBSkillSelection.SkillSelectionInfo>((obj) =>
                {
                    return ((System.Func<xc.DBSkillSelection.SkillSelectionInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSkillSelection.SkillSelectionInfo>>((act) =>
            {
                return new System.Comparison<xc.DBSkillSelection.SkillSelectionInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBSkillSelection.SkillSelectionInfo, xc.DBSkillSelection.SkillSelectionInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBStigma.DBStigmaSkillItemSkillItem>>((act) =>
            {
                return new System.Predicate<xc.DBStigma.DBStigmaSkillItemSkillItem>((obj) =>
                {
                    return ((System.Func<xc.DBStigma.DBStigmaSkillItemSkillItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBStigma.DBStigmaSkillItemSkillItem>>((act) =>
            {
                return new System.Comparison<xc.DBStigma.DBStigmaSkillItemSkillItem>((x, y) =>
                {
                    return ((System.Func<xc.DBStigma.DBStigmaSkillItemSkillItem, xc.DBStigma.DBStigmaSkillItemSkillItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBStigma.DBStigmaInfo>>((act) =>
            {
                return new System.Predicate<xc.DBStigma.DBStigmaInfo>((obj) =>
                {
                    return ((System.Func<xc.DBStigma.DBStigmaInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBStigma.DBStigmaInfo>>((act) =>
            {
                return new System.Comparison<xc.DBStigma.DBStigmaInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBStigma.DBStigmaInfo, xc.DBStigma.DBStigmaInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBTrialBoss.TrialBossItem>>((act) =>
            {
                return new System.Predicate<xc.DBTrialBoss.TrialBossItem>((obj) =>
                {
                    return ((System.Func<xc.DBTrialBoss.TrialBossItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBTrialBoss.TrialBossItem>>((act) =>
            {
                return new System.Comparison<xc.DBTrialBoss.TrialBossItem>((x, y) =>
                {
                    return ((System.Func<xc.DBTrialBoss.TrialBossItem, xc.DBTrialBoss.TrialBossItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBWidgetShield.WidgetInfo>>((act) =>
            {
                return new System.Predicate<xc.DBWidgetShield.WidgetInfo>((obj) =>
                {
                    return ((System.Func<xc.DBWidgetShield.WidgetInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBWidgetShield.WidgetInfo>>((act) =>
            {
                return new System.Comparison<xc.DBWidgetShield.WidgetInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBWidgetShield.WidgetInfo, xc.DBWidgetShield.WidgetInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBWorldBoss.DBWorldBossRewardItem>>((act) =>
            {
                return new System.Predicate<xc.DBWorldBoss.DBWorldBossRewardItem>((obj) =>
                {
                    return ((System.Func<xc.DBWorldBoss.DBWorldBossRewardItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBWorldBoss.DBWorldBossRewardItem>>((act) =>
            {
                return new System.Comparison<xc.DBWorldBoss.DBWorldBossRewardItem>((x, y) =>
                {
                    return ((System.Func<xc.DBWorldBoss.DBWorldBossRewardItem, xc.DBWorldBoss.DBWorldBossRewardItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBWorldBoss.DBWorldBossItem>>((act) =>
            {
                return new System.Predicate<xc.DBWorldBoss.DBWorldBossItem>((obj) =>
                {
                    return ((System.Func<xc.DBWorldBoss.DBWorldBossItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBWorldBoss.DBWorldBossItem>>((act) =>
            {
                return new System.Comparison<xc.DBWorldBoss.DBWorldBossItem>((x, y) =>
                {
                    return ((System.Func<xc.DBWorldBoss.DBWorldBossItem, xc.DBWorldBoss.DBWorldBossItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetServerDataFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetServerDataFinishedDelegate((regionList, serverList, lastLoginServerId) =>
                {
                    ((System.Action<System.Collections.Generic.List<xc.RegionInfo>, System.Collections.Generic.List<xc.ServerInfo>, System.Int32>)act)(regionList, serverList, lastLoginServerId);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetAllRegionFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetAllRegionFinishedDelegate((regionList) =>
                {
                    ((System.Action<System.Collections.Generic.List<xc.RegionInfo>>)act)(regionList);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetLatelyLoginServerListFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetLatelyLoginServerListFinishedDelegate((serverList) =>
                {
                    ((System.Action<System.Collections.Generic.List<xc.ServerInfo>>)act)(serverList);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetServerListFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetServerListFinishedDelegate((serverList) =>
                {
                    ((System.Action<System.Collections.Generic.List<xc.ServerInfo>>)act)(serverList);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetAllRecommServerFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetAllRecommServerFinishedDelegate((recomServerList, willOpenServerList, loginServerList) =>
                {
                    ((System.Action<System.Collections.Generic.List<xc.ServerInfo>, System.Collections.Generic.List<xc.ServerInfo>, System.Collections.Generic.List<xc.ServerInfo>>)act)(recomServerList, willOpenServerList, loginServerList);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ServerListHelper.GetServerStateFinishedDelegate>((act) =>
            {
                return new xc.ServerListHelper.GetServerStateFinishedDelegate((serverInfo, canEnter) =>
                {
                    ((System.Action<xc.ServerInfo, System.Boolean>)act)(serverInfo, canEnter);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.EquipAttrData>>((act) =>
            {
                return new System.Predicate<xc.EquipAttrData>((obj) =>
                {
                    return ((System.Func<xc.EquipAttrData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.EquipAttrData>>((act) =>
            {
                return new System.Comparison<xc.EquipAttrData>((x, y) =>
                {
                    return ((System.Func<xc.EquipAttrData, xc.EquipAttrData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSysGroupConfig.SysGroup>>((act) =>
            {
                return new System.Predicate<xc.DBSysGroupConfig.SysGroup>((obj) =>
                {
                    return ((System.Func<xc.DBSysGroupConfig.SysGroup, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSysGroupConfig.SysGroup>>((act) =>
            {
                return new System.Comparison<xc.DBSysGroupConfig.SysGroup>((x, y) =>
                {
                    return ((System.Func<xc.DBSysGroupConfig.SysGroup, xc.DBSysGroupConfig.SysGroup, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GuideData>>((act) =>
            {
                return new System.Predicate<xc.GuideData>((obj) =>
                {
                    return ((System.Func<xc.GuideData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GuideData>>((act) =>
            {
                return new System.Comparison<xc.GuideData>((x, y) =>
                {
                    return ((System.Func<xc.GuideData, xc.GuideData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Guide.Step>>((act) =>
            {
                return new System.Predicate<Guide.Step>((obj) =>
                {
                    return ((System.Func<Guide.Step, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Guide.Step>>((act) =>
            {
                return new System.Comparison<Guide.Step>((x, y) =>
                {
                    return ((System.Func<Guide.Step, Guide.Step, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBManager.ColumnInfo>>((act) =>
            {
                return new System.Predicate<xc.DBManager.ColumnInfo>((obj) =>
                {
                    return ((System.Func<xc.DBManager.ColumnInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBManager.ColumnInfo>>((act) =>
            {
                return new System.Comparison<xc.DBManager.ColumnInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBManager.ColumnInfo, xc.DBManager.ColumnInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Collections.Generic.Dictionary<System.String, System.String>>>((act) =>
            {
                return new System.Predicate<System.Collections.Generic.Dictionary<System.String, System.String>>((obj) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.String, System.String>, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.Dictionary<System.String, System.String>>>((act) =>
            {
                return new System.Comparison<System.Collections.Generic.Dictionary<System.String, System.String>>((x, y) =>
                {
                    return ((System.Func<System.Collections.Generic.Dictionary<System.String, System.String>, System.Collections.Generic.Dictionary<System.String, System.String>, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.RouterManager.OpenSysWindowDelegate>((act) =>
            {
                return new xc.RouterManager.OpenSysWindowDelegate((args) =>
                {
                    return ((System.Func<System.Object[], System.Boolean>)act)(args);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.GoodsDropFrom.DropType>>((act) =>
            {
                return new System.Predicate<xc.GoodsDropFrom.DropType>((obj) =>
                {
                    return ((System.Func<xc.GoodsDropFrom.DropType, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.GoodsDropFrom.DropType>>((act) =>
            {
                return new System.Comparison<xc.GoodsDropFrom.DropType>((x, y) =>
                {
                    return ((System.Func<xc.GoodsDropFrom.DropType, xc.GoodsDropFrom.DropType, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ActorManager.UnitCacheDataFilter>((act) =>
            {
                return new xc.ActorManager.UnitCacheDataFilter((info) =>
                {
                    return ((System.Func<xc.UnitCacheInfo, System.Boolean>)act)(info);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBPay.PayItemInfo>>((act) =>
            {
                return new System.Predicate<xc.DBPay.PayItemInfo>((obj) =>
                {
                    return ((System.Func<xc.DBPay.PayItemInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBPay.PayItemInfo>>((act) =>
            {
                return new System.Comparison<xc.DBPay.PayItemInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBPay.PayItemInfo, xc.DBPay.PayItemInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.DBSuitEffect.BindInfo>>((act) =>
            {
                return new System.Predicate<xc.DBSuitEffect.BindInfo>((obj) =>
                {
                    return ((System.Func<xc.DBSuitEffect.BindInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.DBSuitEffect.BindInfo>>((act) =>
            {
                return new System.Comparison<xc.DBSuitEffect.BindInfo>((x, y) =>
                {
                    return ((System.Func<xc.DBSuitEffect.BindInfo, xc.DBSuitEffect.BindInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.Dungeon.ColliderObject>>((act) =>
            {
                return new System.Predicate<xc.Dungeon.ColliderObject>((obj) =>
                {
                    return ((System.Func<xc.Dungeon.ColliderObject, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.Dungeon.ColliderObject>>((act) =>
            {
                return new System.Comparison<xc.Dungeon.ColliderObject>((x, y) =>
                {
                    return ((System.Func<xc.Dungeon.ColliderObject, xc.Dungeon.ColliderObject, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Neptune.Data.Container>>((act) =>
            {
                return new System.Predicate<Neptune.Data.Container>((obj) =>
                {
                    return ((System.Func<Neptune.Data.Container, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Neptune.Data.Container>>((act) =>
            {
                return new System.Comparison<Neptune.Data.Container>((x, y) =>
                {
                    return ((System.Func<Neptune.Data.Container, Neptune.Data.Container, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UILockCDSlot.OnClickFunc>((act) =>
            {
                return new xc.ui.UILockCDSlot.OnClickFunc((item) =>
                {
                    ((System.Action<xc.ui.UILockCDSlot>)act)(item);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.UINewLockCDSlot.OnClickFunc>((act) =>
            {
                return new xc.ui.UINewLockCDSlot.OnClickFunc((item) =>
                {
                    ((System.Action<xc.ui.UINewLockCDSlot>)act)(item);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>((act) =>
            {
                return new xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate((toggleIsOn, param) =>
                {
                    ((System.Action<System.Boolean, System.Object>)act)(toggleIsOn, param);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UGUIAtlas>>((act) =>
            {
                return new System.Predicate<UGUIAtlas>((obj) =>
                {
                    return ((System.Func<UGUIAtlas, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UGUIAtlas>>((act) =>
            {
                return new System.Comparison<UGUIAtlas>((x, y) =>
                {
                    return ((System.Func<UGUIAtlas, UGUIAtlas, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Sprite>>((act) =>
            {
                return new System.Predicate<UnityEngine.Sprite>((obj) =>
                {
                    return ((System.Func<UnityEngine.Sprite, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Sprite>>((act) =>
            {
                return new System.Comparison<UnityEngine.Sprite>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ui.ugui.LoginNoticeContent>>((act) =>
            {
                return new System.Predicate<xc.ui.ugui.LoginNoticeContent>((obj) =>
                {
                    return ((System.Func<xc.ui.ugui.LoginNoticeContent, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ui.ugui.LoginNoticeContent>>((act) =>
            {
                return new System.Comparison<xc.ui.ugui.LoginNoticeContent>((x, y) =>
                {
                    return ((System.Func<xc.ui.ugui.LoginNoticeContent, xc.ui.ugui.LoginNoticeContent, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<xc.ui.ugui.LoginNoticeItemInfo>>((act) =>
            {
                return new System.Predicate<xc.ui.ugui.LoginNoticeItemInfo>((obj) =>
                {
                    return ((System.Func<xc.ui.ugui.LoginNoticeItemInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<xc.ui.ugui.LoginNoticeItemInfo>>((act) =>
            {
                return new System.Comparison<xc.ui.ugui.LoginNoticeItemInfo>((x, y) =>
                {
                    return ((System.Func<xc.ui.ugui.LoginNoticeItemInfo, xc.ui.ugui.LoginNoticeItemInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>((arg0) =>
                {
                    ((System.Action<UnityEngine.EventSystems.BaseEventData>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Dropdown.OptionData>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Dropdown.OptionData>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.UI.InputField.OnValidateInput>((act) =>
            {
                return new UnityEngine.UI.InputField.OnValidateInput((text, charIndex, addedChar) =>
                {
                    return ((System.Func<System.String, System.Int32, System.Char, System.Char>)act)(text, charIndex, addedChar);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.RectMask2D>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.RectMask2D>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineBrain.PostFXHandlerDelegate>((act) =>
            {
                return new Cinemachine.CinemachineBrain.PostFXHandlerDelegate((dest, vcam, state) =>
                {
                    return ((System.Func<UnityEngine.Camera, Cinemachine.ICinemachineCamera, Cinemachine.CameraState, System.Boolean>)act)(dest, vcam, state);
                });
            });


            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineVirtualCamera.CreatePipelineDelegate>((act) =>
            {
                return new Cinemachine.CinemachineVirtualCamera.CreatePipelineDelegate((vcam, name, copyFrom) =>
                {
                    return ((System.Func<Cinemachine.CinemachineVirtualCamera, System.String, Cinemachine.ICinemachineComponent[], UnityEngine.Transform>)act)(vcam, name, copyFrom);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineFreeLook.CreateRigDelegate>((act) =>
            {
                return new Cinemachine.CinemachineFreeLook.CreateRigDelegate((vcam, name, copyFrom) =>
                {
                    return ((System.Func<Cinemachine.CinemachineFreeLook, System.String, Cinemachine.CinemachineVirtualCamera, Cinemachine.CinemachineVirtualCamera>)act)(vcam, name, copyFrom);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.CinemachineCore.AxisInputDelegate>((act) =>
            {
                return new Cinemachine.CinemachineCore.AxisInputDelegate((axisName) =>
                {
                    return ((System.Func<System.String, System.Single>)act)(axisName);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Cinemachine.Blackboard.Reactor.GameObjectFieldScanner.OnLeafFieldDelegate>((act) =>
            {
                return new Cinemachine.Blackboard.Reactor.GameObjectFieldScanner.OnLeafFieldDelegate((fullName, fieldInfo, rootFieldOwner, value) =>
                {
                    return ((System.Func<System.String, System.Collections.Generic.List<System.Reflection.FieldInfo>, System.Object, System.Object, System.Boolean>)act)(fullName, fieldInfo, rootFieldOwner, value);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Neptune.Tag>>((act) =>
            {
                return new System.Predicate<Neptune.Tag>((obj) =>
                {
                    return ((System.Func<Neptune.Tag, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Neptune.Tag>>((act) =>
            {
                return new System.Comparison<Neptune.Tag>((x, y) =>
                {
                    return ((System.Func<Neptune.Tag, Neptune.Tag, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<Neptune.BaseGenericNode>>((act) =>
            {
                return new System.Predicate<Neptune.BaseGenericNode>((obj) =>
                {
                    return ((System.Func<Neptune.BaseGenericNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<Neptune.BaseGenericNode>>((act) =>
            {
                return new System.Comparison<Neptune.BaseGenericNode>((x, y) =>
                {
                    return ((System.Func<Neptune.BaseGenericNode, Neptune.BaseGenericNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DynamicScorll.OnSetItemFunc>((act) =>
            {
                return new DynamicScorll.OnSetItemFunc((idx, go) =>
                {
                    ((System.Action<System.Int32, UnityEngine.GameObject>)act)(idx, go);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.RawImage>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.RawImage>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.RawImage, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.RawImage>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.RawImage>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.RawImage, UnityEngine.UI.RawImage, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Texture>>((act) =>
            {
                return new System.Predicate<UnityEngine.Texture>((obj) =>
                {
                    return ((System.Func<UnityEngine.Texture, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Texture>>((act) =>
            {
                return new System.Comparison<UnityEngine.Texture>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Texture, UnityEngine.Texture, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Text>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Text>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Text, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Text>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Text>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Text, UnityEngine.UI.Text, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Text.RegularExpressions.MatchEvaluator>((act) =>
            {
                return new System.Text.RegularExpressions.MatchEvaluator((match) =>
                {
                    return ((System.Func<System.Text.RegularExpressions.Match, System.String>)act)(match);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UITweener.OnFinished>((act) =>
            {
                return new xc.ui.ugui.UITweener.OnFinished((tweener) =>
                {
                    ((System.Action<xc.ui.ugui.UITweener>)act)(tweener);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UIWrapContent.OnItemInit>((act) =>
            {
                return new xc.ui.ugui.UIWrapContent.OnItemInit((go, wrapIndex) =>
                {
                    ((System.Action<UnityEngine.GameObject, System.Int32>)act)(go, wrapIndex);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xc.ui.ugui.UIWrapContent.OnItemRefresh>((act) =>
            {
                return new xc.ui.ugui.UIWrapContent.OnItemRefresh((go, wrapIndex, realIndex) =>
                {
                    ((System.Action<UnityEngine.GameObject, System.Int32, System.Int32>)act)(go, wrapIndex, realIndex);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UICommonTips.OnTipsNotification>((act) =>
            {
                return new UICommonTips.OnTipsNotification((tips, go) =>
                {
                    ((System.Action<UICommonTips, UnityEngine.GameObject>)act)(tips, go);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<BuglyAgent.LogCallbackDelegate>((act) =>
            {
                return new BuglyAgent.LogCallbackDelegate((condition, stackTrace, type) =>
                {
                    ((System.Action<System.String, System.String, UnityEngine.LogType>)act)(condition, stackTrace, type);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<AssetBundleOffsetInfoItem>>((act) =>
            {
                return new System.Predicate<AssetBundleOffsetInfoItem>((obj) =>
                {
                    return ((System.Func<AssetBundleOffsetInfoItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<AssetBundleOffsetInfoItem>>((act) =>
            {
                return new System.Comparison<AssetBundleOffsetInfoItem>((x, y) =>
                {
                    return ((System.Func<AssetBundleOffsetInfoItem, AssetBundleOffsetInfoItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<xpatch.DL_BinContext.delStateChangeHanlder>((act) =>
            {
                return new xpatch.DL_BinContext.delStateChangeHanlder((dl_ctx, state) =>
                {
                    ((System.Action<xpatch.DL_BinContext, xpatch.EDownloadState>)act)(dl_ctx, state);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.AdvancedText.CharOffest>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.AdvancedText.CharOffest>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.AdvancedText.CharOffest, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.AdvancedText.CharOffest>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.AdvancedText.CharOffest>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.AdvancedText.CharOffest, UnityEngine.UI.AdvancedText.CharOffest, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<DynamicBoneCollider>>((act) =>
            {
                return new System.Predicate<DynamicBoneCollider>((obj) =>
                {
                    return ((System.Func<DynamicBoneCollider, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<DynamicBoneCollider>>((act) =>
            {
                return new System.Comparison<DynamicBoneCollider>((x, y) =>
                {
                    return ((System.Func<DynamicBoneCollider, DynamicBoneCollider, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Transform>>((act) =>
            {
                return new System.Predicate<UnityEngine.Transform>((obj) =>
                {
                    return ((System.Func<UnityEngine.Transform, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Transform>>((act) =>
            {
                return new System.Comparison<UnityEngine.Transform>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Transform, UnityEngine.Transform, System.Int32>)act)(x, y);
                });
            });


            appdomain.DelegateManager.RegisterDelegateConvertor<Interpolate.Function>((act) =>
            {
                return new Interpolate.Function((a, b, c, d) =>
                {
                    return ((System.Func<System.Single, System.Single, System.Single, System.Single, System.Single>)act)(a, b, c, d);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TimelineRef.TimelineRefInfo>>((act) =>
            {
                return new System.Predicate<TimelineRef.TimelineRefInfo>((obj) =>
                {
                    return ((System.Func<TimelineRef.TimelineRefInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TimelineRef.TimelineRefInfo>>((act) =>
            {
                return new System.Comparison<TimelineRef.TimelineRefInfo>((x, y) =>
                {
                    return ((System.Func<TimelineRef.TimelineRefInfo, TimelineRef.TimelineRefInfo, System.Int32>)act)(x, y);
                });
            });


        }

        static public void RegisterMethodDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Component>();
            appdomain.DelegateManager.RegisterMethodDelegate<CEventBaseArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgKvMin>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAttrElm>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.UInt32>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.LeaveBuff>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<Neptune.Path.PathNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<Neptune.BindPathNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Machine.State>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector3>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.SkillAttackInstance>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSkill.SkillActionData>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Skill>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<Actor>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Buff, xc.Buff.BuffInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Buff>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPet.UnLockGoodsCondition>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBTextResource.DBAttrItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBAvatarPart.BODY_PART>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rect>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector2>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Matrix4x4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Camera>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.RectTransform>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UIVertex>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color32>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.BoneWeight>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UICharInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UILineInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Font>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Goods>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<Guide.ICondition>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPlayerBrief>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgKv>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.UInt16, System.Byte[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AsyncOperation>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.PackRecorder.PackData>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, Newtonsoft.Json.Serialization.ErrorEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32[], System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.Int32, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<gcloud_voice.IGCloudVoice.GCloudVoiceCompleteCode, System.String, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<System.UInt32>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMagic.DBMagicItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Equip.IEquipAttribute>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgExotic>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgStrStr>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsLightWeaponSoul>();
            appdomain.DelegateManager.RegisterMethodDelegate<SGameEngine.BundleObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.UInt64>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsMountEquip>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSpecialMon.DBSpecialMonItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ServerRoleInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ServerInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.RegionInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsEquip>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSuit.DBSuitInfo.NeedInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.TaskDefine.TaskStep>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBReward.RewardInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<NpcScenePosition>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<System.String>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Task.StepProgress>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Task>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTeamMember>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTeamUserIntro>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.S2CTeamBeInvite>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.SocietyManagerEx.MemberInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.EquipPosInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DecoratePosInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DecorateAppendAttr>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSysConfig.SysConfig>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSkillsPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSkillsOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.MailInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAttachment>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Money>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.Dictionary<System.UInt32, System.Single>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.Dictionary<System.UInt16, System.UInt32>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsSoul>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Equip.EquipHelper.AttributeDescItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<DropComponent>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.RaycastResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AnimatorClipInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Selectable>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.FriendsInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.FriendShipInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String, System.String, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ValueRange>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsLuaEx>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsMagicEquip>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsGodEquip>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsDecorate>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBDecorate.LegendAttrDescItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossKiller>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Byte[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.UIItemNewSlot>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Goods, xc.ui.UIItemNewSlot>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, xc.ui.UIItemNewSlot>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.ugui.UIBaseWindow.BackupWin>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Goods, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.ugui.UIBaseWindow>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.debug.CommandPanel.CommandInfo, System.String[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.debug.CommandPanel.CommandInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<MiniMapPointInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<QuadTreeSceneManager.CubeTime>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject, UIRollNumWidget>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIExpandScrollView.FirstClassNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIExpandScrollView.SecondClassNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIExpandScrollView.ThirdClassNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDropGive>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Single[], System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collision>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.ControllerColliderHit>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.RenderTexture, UnityEngine.RenderTexture>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collider>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Type>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<SGameEngine.AssetResource>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String, System.Byte[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<SGameFirstPass.AssetBundleInfoItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Tuple<UnityEngine.GameObject, SGameEngine.AssetObject>>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject, SGameEngine.AssetObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, ProtoBuf.Meta.TypeFormatEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, ProtoBuf.Meta.LockContentedEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<Uranus.Runtime.ICondition>();
            appdomain.DelegateManager.RegisterMethodDelegate<Uranus.Runtime.Blackboard, Uranus.Runtime.BlackboardUpdateType>();
            appdomain.DelegateManager.RegisterMethodDelegate<BinItemInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<SGameFirstPass.AssetPatchInfoItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xpatch.DL_PatchContext>();
            appdomain.DelegateManager.RegisterMethodDelegate<xpatch.DL_BundleContext, xpatch.EDownloadState>();
            appdomain.DelegateManager.RegisterMethodDelegate<xpatch.DL_BundleContext>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Single, System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<MikuLuaProfiler.Sample>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Byte>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAccPhoneInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAccSysSetting>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgKvStr>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPlayerPersonality>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGoodsGidnum>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGoodsInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgStrengthInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBaptizeInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBaptizeGroove>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPlayerClientData>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgWorldMemberInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgNotice>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMapLineState>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgNwarBarPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgNwarNpcPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTrialBossPass>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgWorshipHuman>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgWorshipAnswer>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTombInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGleagueResource>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGleagueWarGuild>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGleagueAchieve>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBattleFieldOpponent>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBattleFieldHistory>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLordComeBossInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLordComeBossLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLordComeRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeakArenaRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeakRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeakClanMini>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeakClan>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeak3PMatchOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeak3PResultOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMeleeScore>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodDemonDuelRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSkillsCd>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGoodsCd>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGoodsDailyLimit>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGoodsUsageCounter>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMoneyInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEpShapeRefine>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEpQuenchSpirits>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgElementEpStrength>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLightSoulOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLightEquipOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFiveElemStrength>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFiveElemTrain>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFiveElemSuit>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgQuotaList>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShopInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMshopItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMshopOrder>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgArtifactSpirit>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgArtifactSpiritDecompose>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDecorateAttr>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDecoratePosInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodEquipAttr>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodEquipPosInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodEquipSkill>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodBaptizeGroove>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodBaptizeInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEngrave>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEngravePosInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRideEquipPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEquipZhuhun>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEquipCarve>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPetEquipPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgHolySuit>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLeg>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLegInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTaskInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTaskTitleInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMail>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMarqueeInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRankLine>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int64>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFinalRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActDaily>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActState>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActYunying>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAccPayTarget>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgHolidayAccPayTarget>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgAccTreasureTower>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureTowerCostConf>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureTowerItemConf>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureTowerResetConf>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureTowerGradeConf>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureTowerConf>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBargainInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPainKill>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildCompeteInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgConsumeRankSb>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgConsumeRankSbReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgConsumeRankSpring>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgConsumeRankSpringReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossActBuyLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRedpackActLucky>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRedpackAct>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgCollectCompose>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgKnockEgg>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEggLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgEggGoods>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActReturnGoal>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDtaskIndexInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDtaskDayInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLuckyTurntableLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActPrayLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActPrayDo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanCostRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgStarWishLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgHonorableGiftGoods>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTimeLimitItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTimeLimitBuy>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTransferSaleItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgExaltedGiftGoods>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgActFestivalInvest>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureReplaceInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureBigAward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTeamIntro>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMemberPos>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgInviteMember>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossFight>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossAffRank>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBossDropInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanBossMon>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanBossGroupOne>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFiveEmperorsBoss>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFiveEmperorsTotem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSaintBeastDng>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSaintBox>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSaintBossLv>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTrigram>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRune>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildIntro>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildMember>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildWareLogGoods>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildWareLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGlRoundInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGlLevelInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGlBattleInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildTask>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildRedpackLucky>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGuildRedpackInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSgbBattleGuild>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSgbRankGuild>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSgbBattleInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMarketGoods>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDtIndexInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgDtDayInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgResourceRetrieve>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPrayInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSubTargetInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTargetInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSubPhaseInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPhaseInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSevenGiftInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgImpactRankInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLvReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgVipLvReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSepcReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgBuyLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgChosenResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgVipInvestUnit>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureHuntInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTreasureInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSuperHuntInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSubGodExpInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGodExpInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgZeroGift>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitSaleItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitSaleShop>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSoulInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitCollect>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitTask>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPayRed>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPayRedBorn>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPayRedTaker>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFireworkCelebrationLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLightEquip>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPeakHuntInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRedPacket>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgConPay>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShopGiftSale>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShopGiftBuy>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShopDay>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShopGift>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanSepcReward>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanChosenInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPlayerBuy>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanBuyLog>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgSpanChosenResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitSaleSpanItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgLimitSaleSpanShop>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgQiankunHuntInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMarryReserveCouple>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgWeddingGift>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgMarryPerfitRecords>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgStigma>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgPetSkin>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgGrowInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgRideSkin>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFruitInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgFashion>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgExpJade>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgVipBonus>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTitleInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgTalentSystem>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgShowInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgArtifactInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgArtifactSkillInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<Net.PkgQualityAdvance>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBAttrs.DBAttrsItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt32>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBDecoratePos.DBDecoratePosItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBEngrave.EngraveInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGem.GemInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGuildWareColorFilter.DBGuildWareColorFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGuildWareStepFilter.DBGuildWareStepFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBTextResource.DBGoodsItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketFilter.OneDBMarketFilter>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketFilter.DBMarketFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketPasswordFilter.DBMarketPasswordFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketQualityAndStarFilter.DBMarketQualityAndStarFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketQualityFilter.DBMarketQualityFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBMarketStepFilter.DBMarketStepFilterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.PreloadInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.KeyValuePair<System.UInt32, System.UInt64>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSuitAttr.DBSuitAttrInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSuitRefine.DBSuitRefineItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBDataAllSkill.AllSkillInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGrowSkin.DBGrowSkinItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGuildBoss.DBGuildBossItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGuildBoss.DBGuildBossStatisticItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBGuildSkill.DBCommonAttrItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.HangInfo.TagInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPet.PetSkillItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPet.PetInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPetFetter.DBPetFetterItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPetFetter.FetterSkillItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPet.UnLockPrePetCondition>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSkillSelection.SkillSelectionInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBStigma.DBStigmaSkillItemSkillItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBStigma.DBStigmaInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBTrialBoss.TrialBossItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBWidgetShield.WidgetInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBWorldBoss.DBWorldBossRewardItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBWorldBoss.DBWorldBossItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<xc.RegionInfo>, System.Collections.Generic.List<xc.ServerInfo>, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<xc.RegionInfo>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<xc.ServerInfo>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<xc.ServerInfo>, System.Collections.Generic.List<xc.ServerInfo>, System.Collections.Generic.List<xc.ServerInfo>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ServerInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.EquipAttrData>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSysGroupConfig.SysGroup>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GuideData>();
            appdomain.DelegateManager.RegisterMethodDelegate<Guide.Step>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBManager.ColumnInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.Dictionary<System.String, System.String>>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.GoodsDropFrom.DropType>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Sprite>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBPay.PayItemInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.DBSuitEffect.BindInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.Dungeon.ColliderObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<Neptune.Data.Container>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.UILockCDSlot>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.UINewLockCDSlot>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Boolean, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<UGUIAtlas>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.ugui.LoginNoticeContent>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.ugui.LoginNoticeItemInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.EventTrigger.Entry>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Dropdown.OptionData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.RectMask2D>();
            appdomain.DelegateManager.RegisterMethodDelegate<Neptune.Tag>();
            appdomain.DelegateManager.RegisterMethodDelegate<Neptune.BaseGenericNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.RawImage>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Texture>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Text>();
            appdomain.DelegateManager.RegisterMethodDelegate<xc.ui.ugui.UITweener>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UICommonTips, UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String, UnityEngine.LogType>();
            appdomain.DelegateManager.RegisterMethodDelegate<AssetBundleOffsetInfoItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<xpatch.DL_BinContext, xpatch.EDownloadState>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.AdvancedText.CharOffest>();
            appdomain.DelegateManager.RegisterMethodDelegate<DynamicBoneCollider>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Transform>();
            appdomain.DelegateManager.RegisterMethodDelegate<TimelineRef.TimelineRefInfo>();

        }

        static public void Fame()
        {
            System.Type v = null;

        }
    }
}
#endif