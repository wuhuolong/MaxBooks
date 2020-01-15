#if USE_HOT
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class xc_SceneHelp_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(xc.SceneHelp);
            args = new Type[]{};
            method = type.GetMethod("get_loadedLevelName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_loadedLevelName_0);
            args = new Type[]{};
            method = type.GetMethod("get_AutoHideLoadingUI", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_AutoHideLoadingUI_1);
            args = new Type[]{};
            method = type.GetMethod("get_CurSceneName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CurSceneName_2);
            args = new Type[]{};
            method = type.GetMethod("get_CurSceneResPath", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CurSceneResPath_3);
            args = new Type[]{};
            method = type.GetMethod("get_MapInfo", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_MapInfo_4);
            args = new Type[]{};
            method = type.GetMethod("get_WillSwitchScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_WillSwitchScene_5);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_WillSwitchScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_WillSwitchScene_6);
            args = new Type[]{};
            method = type.GetMethod("get_IsAutoFightingAfterSwitchInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsAutoFightingAfterSwitchInstance_7);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsAutoFightingAfterSwitchInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsAutoFightingAfterSwitchInstance_8);
            args = new Type[]{};
            method = type.GetMethod("get_IsAutoFightingWhenShowExitTips", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsAutoFightingWhenShowExitTips_9);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsAutoFightingWhenShowExitTips", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsAutoFightingWhenShowExitTips_10);
            args = new Type[]{};
            method = type.GetMethod("get_CurSceneID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CurSceneID_11);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("set_CurSceneID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_CurSceneID_12);
            args = new Type[]{};
            method = type.GetMethod("get_PreSceneID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_PreSceneID_13);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("set_PreSceneID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_PreSceneID_14);
            args = new Type[]{};
            method = type.GetMethod("get_CanHidePlayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CanHidePlayer_15);
            args = new Type[]{};
            method = type.GetMethod("get_PrecedentPlayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_PrecedentPlayer_16);
            args = new Type[]{};
            method = type.GetMethod("get_PKLevelLimit", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_PKLevelLimit_17);
            args = new Type[]{};
            method = type.GetMethod("get_IgnoreClickPlayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IgnoreClickPlayer_18);
            args = new Type[]{};
            method = type.GetMethod("get_ForceShowHpBar", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ForceShowHpBar_19);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("ForbidUseGoods", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ForbidUseGoods_20);
            args = new Type[]{};
            method = type.GetMethod("get_ForbidChangePkMode", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ForbidChangePkMode_21);
            args = new Type[]{};
            method = type.GetMethod("get_ShowDanmakuSwitch", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ShowDanmakuSwitch_22);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("ShowDanmakuInChatChannel", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowDanmakuInChatChannel_23);
            args = new Type[]{};
            method = type.GetMethod("get_ForbidOpenWorldMap", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ForbidOpenWorldMap_24);
            args = new Type[]{};
            method = type.GetMethod("get_ForbidTeam", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ForbidTeam_25);
            args = new Type[]{};
            method = type.GetMethod("get_IsKungfuInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsKungfuInstance_26);
            args = new Type[]{};
            method = type.GetMethod("get_IsInGuildBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInGuildBossInstance_27);
            args = new Type[]{};
            method = type.GetMethod("get_IsInDeadSpaceInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInDeadSpaceInstance_28);
            args = new Type[]{};
            method = type.GetMethod("get_IsInTrialBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInTrialBossInstance_29);
            args = new Type[]{};
            method = type.GetMethod("get_IsInPeakBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInPeakBossInstance_30);
            args = new Type[]{};
            method = type.GetMethod("get_IsInSecretDefendInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInSecretDefendInstance_31);
            args = new Type[]{};
            method = type.GetMethod("get_IsInSouthLandInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInSouthLandInstance_32);
            args = new Type[]{};
            method = type.GetMethod("get_IsInElementAreaInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInElementAreaInstance_33);
            args = new Type[]{};
            method = type.GetMethod("get_IsInBossHomeInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInBossHomeInstance_34);
            args = new Type[]{};
            method = type.GetMethod("get_IsInDeedInheritInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInDeedInheritInstance_35);
            args = new Type[]{};
            method = type.GetMethod("get_IsInFirstWorldBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInFirstWorldBossInstance_36);
            args = new Type[]{};
            method = type.GetMethod("get_IsInFairyValleyInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInFairyValleyInstance_37);
            args = new Type[]{};
            method = type.GetMethod("get_IsInWorshipMeetingInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInWorshipMeetingInstance_38);
            args = new Type[]{};
            method = type.GetMethod("get_IsInCatchBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInCatchBossInstance_39);
            args = new Type[]{};
            method = type.GetMethod("get_IsInWorldBossExperienceInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInWorldBossExperienceInstance_40);
            args = new Type[]{};
            method = type.GetMethod("get_IsInWorldBossFirstInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInWorldBossFirstInstance_41);
            args = new Type[]{};
            method = type.GetMethod("get_IsInPersonalBossInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInPersonalBossInstance_42);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("IsInGuildLeagueInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInGuildLeagueInstance_43);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("IsInSpanGuildWarInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInSpanGuildWarInstance_44);
            args = new Type[]{};
            method = type.GetMethod("get_IsInLoveInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInLoveInstance_45);
            args = new Type[]{};
            method = type.GetMethod("get_IsInWeddingInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInWeddingInstance_46);
            args = new Type[]{};
            method = type.GetMethod("get_IsInInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInInstance_47);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("IsInWildInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInWildInstance_48);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("IsInNormalWild", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInNormalWild_49);
            args = new Type[]{};
            method = type.GetMethod("get_IsPlayingInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsPlayingInstance_50);
            args = new Type[]{};
            method = type.GetMethod("get_IsInGuildManor", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInGuildManor_51);
            args = new Type[]{};
            method = type.GetMethod("get_IsInDevilComeInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsInDevilComeInstance_52);
            args = new Type[]{};
            method = type.GetMethod("IsInstanceUseAoi", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInstanceUseAoi_53);
            args = new Type[]{};
            method = type.GetMethod("get_UsePKMode", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_UsePKMode_54);
            args = new Type[]{};
            method = type.GetMethod("get_NoShowAtkCampTips", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_NoShowAtkCampTips_55);
            args = new Type[]{};
            method = type.GetMethod("get_CanRide", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CanRide_56);
            args = new Type[]{};
            method = type.GetMethod("get_IsCanExitBtnInWild", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsCanExitBtnInWild_57);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("ProcessLineCD", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ProcessLineCD_58);
            args = new Type[]{typeof(Net.S2CMapLineState)};
            method = type.GetMethod("ProcessLineInfo", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ProcessLineInfo_59);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("PreCheckInstanceIsDownloaded", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, PreCheckInstanceIsDownloaded_60);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("PostCheckInstanceIsDownloaded", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, PostCheckInstanceIsDownloaded_61);
            args = new Type[]{typeof(System.UInt32), typeof(System.UInt32), typeof(System.UInt32), typeof(System.Boolean)};
            method = type.GetMethod("JumpToScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, JumpToScene_62);
            args = new Type[]{};
            method = type.GetMethod("get_IsReEnterScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsReEnterScene_63);
            args = new Type[]{};
            method = type.GetMethod("ReenterScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ReenterScene_64);
            args = new Type[]{};
            method = type.GetMethod("CheckCanSwitch", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CheckCanSwitch_65);
            args = new Type[]{};
            method = type.GetMethod("JumpToPreScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, JumpToPreScene_66);
            args = new Type[]{typeof(UnityEngine.Vector3), typeof(System.UInt32), typeof(System.Boolean), typeof(System.UInt32), typeof(System.Boolean)};
            method = type.GetMethod("TravelBootsJump", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TravelBootsJump_67);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("GetFirstStageId", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetFirstStageId_68);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("GetFirstMapIdByInstanceId", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetFirstMapIdByInstanceId_69);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("GetMapIdByStageId", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetMapIdByStageId_70);
            args = new Type[]{};
            method = type.GetMethod("get_IsSwitchingScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsSwitchingScene_71);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsSwitchingScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsSwitchingScene_72);
            args = new Type[]{};
            method = type.GetMethod("get_IsLoadingQuadTreeScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsLoadingQuadTreeScene_73);
            args = new Type[]{typeof(xc.SceneHelp.LoadQuadTreeSceneState)};
            method = type.GetMethod("set_IsLoadingQuadTreeScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsLoadingQuadTreeScene_74);
            args = new Type[]{typeof(System.UInt32), typeof(System.Boolean), typeof(System.Boolean)};
            method = type.GetMethod("SwitchScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SwitchScene_75);
            args = new Type[]{typeof(xc.DBMap.MapInfo), typeof(System.Boolean), typeof(System.Boolean)};
            method = type.GetMethod("SwitchScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SwitchScene_76);
            args = new Type[]{typeof(System.String), typeof(System.Boolean)};
            method = type.GetMethod("SwitchPreposeScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SwitchPreposeScene_77);
            args = new Type[]{typeof(System.UInt32), typeof(System.UInt32), typeof(System.Boolean)};
            method = type.GetMethod("CheckCanSwitch", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CheckCanSwitch_78);
            args = new Type[]{typeof(System.UInt32), typeof(System.Boolean)};
            method = type.GetMethod("CheckCanSwitch", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CheckCanSwitch_79);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("CheckLocalPlayerEscortTaskState", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CheckLocalPlayerEscortTaskState_80);

            field = type.GetField("mLineInfos", flag);
            app.RegisterCLRFieldGetter(field, get_mLineInfos_0);
            app.RegisterCLRFieldSetter(field, set_mLineInfos_0);
            field = type.GetField("mChangeLineCDTime", flag);
            app.RegisterCLRFieldGetter(field, get_mChangeLineCDTime_1);
            app.RegisterCLRFieldSetter(field, set_mChangeLineCDTime_1);
            field = type.GetField("mDelyLineCdTime", flag);
            app.RegisterCLRFieldGetter(field, get_mDelyLineCdTime_2);
            app.RegisterCLRFieldSetter(field, set_mDelyLineCdTime_2);
            field = type.GetField("CurLine", flag);
            app.RegisterCLRFieldGetter(field, get_CurLine_3);
            app.RegisterCLRFieldSetter(field, set_CurLine_3);


            app.RegisterCLRCreateDefaultInstance(type, () => new xc.SceneHelp());
            app.RegisterCLRCreateArrayInstance(type, s => new xc.SceneHelp[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* get_loadedLevelName_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.SceneHelp.loadedLevelName;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_AutoHideLoadingUI_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.AutoHideLoadingUI;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_CurSceneName_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CurSceneName;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_CurSceneResPath_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CurSceneResPath;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_MapInfo_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.MapInfo;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_WillSwitchScene_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.WillSwitchScene;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_WillSwitchScene_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.WillSwitchScene = value;

            return __ret;
        }

        static StackObject* get_IsAutoFightingAfterSwitchInstance_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsAutoFightingAfterSwitchInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsAutoFightingAfterSwitchInstance_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsAutoFightingAfterSwitchInstance = value;

            return __ret;
        }

        static StackObject* get_IsAutoFightingWhenShowExitTips_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsAutoFightingWhenShowExitTips;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsAutoFightingWhenShowExitTips_10(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsAutoFightingWhenShowExitTips = value;

            return __ret;
        }

        static StackObject* get_CurSceneID_11(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CurSceneID;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* set_CurSceneID_12(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @value = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.CurSceneID = value;

            return __ret;
        }

        static StackObject* get_PreSceneID_13(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.PreSceneID;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* set_PreSceneID_14(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @value = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.PreSceneID = value;

            return __ret;
        }

        static StackObject* get_CanHidePlayer_15(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CanHidePlayer;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_PrecedentPlayer_16(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.PrecedentPlayer;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_PKLevelLimit_17(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.PKLevelLimit;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IgnoreClickPlayer_18(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IgnoreClickPlayer;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ForceShowHpBar_19(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForceShowHpBar;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ForbidUseGoods_20(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @goodsId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForbidUseGoods(@goodsId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ForbidChangePkMode_21(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForbidChangePkMode;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ShowDanmakuSwitch_22(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ShowDanmakuSwitch;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ShowDanmakuInChatChannel_23(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @chatChannel = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ShowDanmakuInChatChannel(@chatChannel);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ForbidOpenWorldMap_24(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForbidOpenWorldMap;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ForbidTeam_25(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForbidTeam;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsKungfuInstance_26(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsKungfuInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInGuildBossInstance_27(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInGuildBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInDeadSpaceInstance_28(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInDeadSpaceInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInTrialBossInstance_29(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInTrialBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInPeakBossInstance_30(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInPeakBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInSecretDefendInstance_31(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInSecretDefendInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInSouthLandInstance_32(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInSouthLandInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInElementAreaInstance_33(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInElementAreaInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInBossHomeInstance_34(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInBossHomeInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInDeedInheritInstance_35(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInDeedInheritInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInFirstWorldBossInstance_36(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInFirstWorldBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInFairyValleyInstance_37(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInFairyValleyInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInWorshipMeetingInstance_38(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInWorshipMeetingInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInCatchBossInstance_39(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInCatchBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInWorldBossExperienceInstance_40(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInWorldBossExperienceInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInWorldBossFirstInstance_41(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInWorldBossFirstInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInPersonalBossInstance_42(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInPersonalBossInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* IsInGuildLeagueInstance_43(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInGuildLeagueInstance(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* IsInSpanGuildWarInstance_44(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInSpanGuildWarInstance(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInLoveInstance_45(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInLoveInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInWeddingInstance_46(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInWeddingInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInInstance_47(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* IsInWildInstance_48(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInWildInstance(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* IsInNormalWild_49(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInNormalWild(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsPlayingInstance_50(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsPlayingInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInGuildManor_51(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInGuildManor;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsInDevilComeInstance_52(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInDevilComeInstance;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* IsInstanceUseAoi_53(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInstanceUseAoi();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_UsePKMode_54(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.UsePKMode;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_NoShowAtkCampTips_55(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.NoShowAtkCampTips;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_CanRide_56(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CanRide;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_IsCanExitBtnInWild_57(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsCanExitBtnInWild;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ProcessLineCD_58(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @time = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ProcessLineCD(@time);

            return __ret;
        }

        static StackObject* ProcessLineInfo_59(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            Net.S2CMapLineState @msg = (Net.S2CMapLineState)typeof(Net.S2CMapLineState).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ProcessLineInfo(@msg);

            return __ret;
        }

        static StackObject* PreCheckInstanceIsDownloaded_60(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instance_id = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.PreCheckInstanceIsDownloaded(@instance_id);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* PostCheckInstanceIsDownloaded_61(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instance_id = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.PostCheckInstanceIsDownloaded(@instance_id);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* JumpToScene_62(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @checkAttr = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt32 @transferPosId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.UInt32 @line = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.UInt32 @id = (uint)ptr_of_this_method->Value;


            xc.SceneHelp.JumpToScene(@id, @line, @transferPosId, @checkAttr);

            return __ret;
        }

        static StackObject* get_IsReEnterScene_63(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.SceneHelp.IsReEnterScene;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ReenterScene_64(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            xc.SceneHelp.ReenterScene();

            return __ret;
        }

        static StackObject* CheckCanSwitch_65(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.SceneHelp.CheckCanSwitch();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* JumpToPreScene_66(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            xc.SceneHelp.JumpToPreScene();

            return __ret;
        }

        static StackObject* TravelBootsJump_67(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 5);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @isAutoFighting = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt32 @line = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Boolean @isFree = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            UnityEngine.Vector3 @pos = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = xc.SceneHelp.TravelBootsJump(@pos, @instanceId, @isFree, @line, @isAutoFighting);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* GetFirstStageId_68(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.GetFirstStageId(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetFirstMapIdByInstanceId_69(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.GetFirstMapIdByInstanceId(@instanceId);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetMapIdByStageId_70(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @stage_id = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.GetMapIdByStageId(@stage_id);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_IsSwitchingScene_71(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsSwitchingScene;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsSwitchingScene_72(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsSwitchingScene = value;

            return __ret;
        }

        static StackObject* get_IsLoadingQuadTreeScene_73(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsLoadingQuadTreeScene;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_IsLoadingQuadTreeScene_74(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.SceneHelp.LoadQuadTreeSceneState @value = (xc.SceneHelp.LoadQuadTreeSceneState)typeof(xc.SceneHelp.LoadQuadTreeSceneState).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsLoadingQuadTreeScene = value;

            return __ret;
        }

        static StackObject* SwitchScene_75(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @willSwitchScene = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Boolean @auto_hide_loadingUI = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.UInt32 @map_id = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SwitchScene(@map_id, @auto_hide_loadingUI, @willSwitchScene);

            return __ret;
        }

        static StackObject* SwitchScene_76(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @willSwitchScene = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Boolean @auto_hide_loadingUI = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.DBMap.MapInfo @map_info = (xc.DBMap.MapInfo)typeof(xc.DBMap.MapInfo).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SwitchScene(@map_info, @auto_hide_loadingUI, @willSwitchScene);

            return __ret;
        }

        static StackObject* SwitchPreposeScene_77(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @auto_hide_loading_ui = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @name = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.SceneHelp instance_of_this_method = (xc.SceneHelp)typeof(xc.SceneHelp).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SwitchPreposeScene(@name, @auto_hide_loading_ui);

            return __ret;
        }

        static StackObject* CheckCanSwitch_78(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @show_notice = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt32 @warSubType = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.UInt32 @warType = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.CheckCanSwitch(@warType, @warSubType, @show_notice);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* CheckCanSwitch_79(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @show_notice = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt32 @instanceId = (uint)ptr_of_this_method->Value;


            var result_of_this_method = xc.SceneHelp.CheckCanSwitch(@instanceId, @show_notice);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* CheckLocalPlayerEscortTaskState_80(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @showTips = ptr_of_this_method->Value == 1;


            var result_of_this_method = xc.SceneHelp.CheckLocalPlayerEscortTaskState(@showTips);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }


        static object get_mLineInfos_0(ref object o)
        {
            return ((xc.SceneHelp)o).mLineInfos;
        }
        static void set_mLineInfos_0(ref object o, object v)
        {
            ((xc.SceneHelp)o).mLineInfos = (System.Collections.Generic.Dictionary<System.UInt32, System.UInt32>)v;
        }
        static object get_mChangeLineCDTime_1(ref object o)
        {
            return ((xc.SceneHelp)o).mChangeLineCDTime;
        }
        static void set_mChangeLineCDTime_1(ref object o, object v)
        {
            ((xc.SceneHelp)o).mChangeLineCDTime = (System.UInt32)v;
        }
        static object get_mDelyLineCdTime_2(ref object o)
        {
            return ((xc.SceneHelp)o).mDelyLineCdTime;
        }
        static void set_mDelyLineCdTime_2(ref object o, object v)
        {
            ((xc.SceneHelp)o).mDelyLineCdTime = (System.Single)v;
        }
        static object get_CurLine_3(ref object o)
        {
            return ((xc.SceneHelp)o).CurLine;
        }
        static void set_CurLine_3(ref object o, object v)
        {
            ((xc.SceneHelp)o).CurLine = (System.UInt32)v;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new xc.SceneHelp();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
