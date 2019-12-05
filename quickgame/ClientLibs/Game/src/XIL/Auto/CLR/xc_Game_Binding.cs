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
    unsafe class xc_Game_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(xc.Game);
            args = new Type[]{};
            method = type.GetMethod("GetScreenWidth", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenWidth_0);
            args = new Type[]{};
            method = type.GetMethod("GetScreenHeight", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetScreenHeight_1);
            args = new Type[]{};
            method = type.GetMethod("get_IsRebooting", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsRebooting_2);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsRebooting", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsRebooting_3);
            args = new Type[]{};
            method = type.GetMethod("get_ManualCancelReconnect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ManualCancelReconnect_4);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_ManualCancelReconnect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_ManualCancelReconnect_5);
            args = new Type[]{};
            method = type.GetMethod("get_MainCamera", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_MainCamera_6);
            args = new Type[]{};
            method = type.GetMethod("get_CameraControl", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CameraControl_7);
            args = new Type[]{};
            method = type.GetMethod("get_GameObjectControl", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_GameObjectControl_8);
            args = new Type[]{};
            method = type.GetMethod("get_AccountIdx", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_AccountIdx_9);
            args = new Type[]{};
            method = type.GetMethod("get_CharacterList", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CharacterList_10);
            args = new Type[]{};
            method = type.GetMethod("get_CharactorMaxCount", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_CharactorMaxCount_11);
            args = new Type[]{};
            method = type.GetMethod("GetInstance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetInstance_12);
            args = new Type[]{};
            method = type.GetMethod("get_Instance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Instance_13);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerID_14);
            args = new Type[]{typeof(xc.UnitID)};
            method = type.GetMethod("set_LocalPlayerID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_LocalPlayerID_15);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerName_16);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("set_LocalPlayerName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_LocalPlayerName_17);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerTypeID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerTypeID_18);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("set_LocalPlayerTypeID", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_LocalPlayerTypeID_19);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerVocation", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerVocation_20);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerRadius", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerRadius_21);
            args = new Type[]{typeof(System.Single)};
            method = type.GetMethod("set_LocalPlayerRadius", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_LocalPlayerRadius_22);
            args = new Type[]{};
            method = type.GetMethod("get_LocalPlayerAOIInfo", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LocalPlayerAOIInfo_23);
            args = new Type[]{typeof(xc.UnitEnterAOI._Player)};
            method = type.GetMethod("set_LocalPlayerAOIInfo", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_LocalPlayerAOIInfo_24);
            args = new Type[]{};
            method = type.GetMethod("GetCurStateId", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetCurStateId_25);
            args = new Type[]{};
            method = type.GetMethod("get_IsSwitchingScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsSwitchingScene_26);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsSwitchingScene", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsSwitchingScene_27);
            args = new Type[]{};
            method = type.GetMethod("GetLoadAsyncOp", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetLoadAsyncOp_28);
            args = new Type[]{typeof(UnityEngine.AsyncOperation)};
            method = type.GetMethod("SetLoadAsyncOp", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetLoadAsyncOp_29);
            args = new Type[]{typeof(global::Actor)};
            method = type.GetMethod("SetLocalPlayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetLocalPlayer_30);
            args = new Type[]{};
            method = type.GetMethod("GetLocalPlayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetLocalPlayer_31);
            args = new Type[]{typeof(System.UInt16), typeof(xc.Game.DataReplyDelegate)};
            method = type.GetMethod("SubscribeNetNotify", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SubscribeNetNotify_32);
            args = new Type[]{typeof(System.UInt16), typeof(xc.Game.DataReplyDelegate)};
            method = type.GetMethod("UnsubscribeNetNotify", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, UnsubscribeNetNotify_33);
            args = new Type[]{typeof(System.UInt16), typeof(xc.Game.DataReplyDelegate)};
            method = type.GetMethod("SubscribeLuaNetNotify", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SubscribeLuaNetNotify_34);
            args = new Type[]{typeof(System.UInt16), typeof(xc.Game.DataReplyDelegate)};
            method = type.GetMethod("UnsubscribeLuaNetNotify", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, UnsubscribeLuaNetNotify_35);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("Quit", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Quit_36);
            args = new Type[]{};
            method = type.GetMethod("Init", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Init_37);
            args = new Type[]{typeof(System.String), typeof(System.String), typeof(UnityEngine.LogType)};
            method = type.GetMethod("OnLog", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnLog_38);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("Reset", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Reset_39);
            args = new Type[]{};
            method = type.GetMethod("IsNetMode", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsNetMode_40);
            args = new Type[]{};
            method = type.GetMethod("GetFSM", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetFSM_41);
            args = new Type[]{};
            method = type.GetMethod("InitFSM", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, InitFSM_42);
            args = new Type[]{};
            method = type.GetMethod("Update", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Update_43);
            args = new Type[]{};
            method = type.GetMethod("WaitForSceneLoadAsyncOp", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, WaitForSceneLoadAsyncOp_44);
            args = new Type[]{};
            method = type.GetMethod("Rebot", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Rebot_45);
            args = new Type[]{};
            method = type.GetMethod("RebotWithoutSdkLogout", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RebotWithoutSdkLogout_46);
            args = new Type[]{};
            method = type.GetMethod("ChangeRole", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ChangeRole_47);
            args = new Type[]{};
            method = type.GetMethod("get_IsCreateRoleEnter", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsCreateRoleEnter_48);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_IsCreateRoleEnter", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_IsCreateRoleEnter_49);
            args = new Type[]{};
            method = type.GetMethod("get_Connected", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Connected_50);
            args = new Type[]{};
            method = type.GetMethod("get_Converted", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Converted_51);
            args = new Type[]{};
            method = type.GetMethod("get_ServerOpenTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ServerOpenTime_52);
            args = new Type[]{};
            method = type.GetMethod("get_ServerOpenDateTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ServerOpenDateTime_53);
            args = new Type[]{};
            method = type.GetMethod("get_TimeZone", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_TimeZone_54);
            args = new Type[]{};
            method = type.GetMethod("TimeZoneHour", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TimeZoneHour_55);
            args = new Type[]{};
            method = type.GetMethod("TimeZoneMin", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TimeZoneMin_56);
            args = new Type[]{};
            method = type.GetMethod("GetOpenDay", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetOpenDay_57);
            args = new Type[]{};
            method = type.GetMethod("get_MergeServerTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_MergeServerTime_58);
            args = new Type[]{};
            method = type.GetMethod("get_MergeServerDateTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_MergeServerDateTime_59);
            args = new Type[]{};
            method = type.GetMethod("get_AllSystemInited", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_AllSystemInited_60);
            args = new Type[]{};
            method = type.GetMethod("get_PackRecorder", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_PackRecorder_61);
            args = new Type[]{typeof(Net.NetType)};
            method = type.GetMethod("OnNetConnect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnNetConnect_62);
            args = new Type[]{};
            method = type.GetMethod("get_QueueMax", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_QueueMax_63);
            args = new Type[]{};
            method = type.GetMethod("get_LoginConflict", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LoginConflict_64);
            args = new Type[]{};
            method = type.GetMethod("get_MaintainServer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_MaintainServer_65);
            args = new Type[]{};
            method = type.GetMethod("get_ForceDisconnect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ForceDisconnect_66);
            args = new Type[]{typeof(Net.NetType), typeof(System.Int32)};
            method = type.GetMethod("OnNetDisconnect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnNetDisconnect_67);
            args = new Type[]{typeof(Net.NetType), typeof(System.UInt16), typeof(System.Byte[])};
            method = type.GetMethod("OnNetDataReply", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnNetDataReply_68);
            args = new Type[]{typeof(System.UInt16), typeof(System.Byte[])};
            method = type.GetMethod("ProcessServerData", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ProcessServerData_69);
            args = new Type[]{typeof(System.UInt16), typeof(System.Byte[])};
            method = type.GetMethod("HandleServerData", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HandleServerData_70);
            args = new Type[]{};
            method = type.GetMethod("Login", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Login_71);
            args = new Type[]{typeof(System.String), typeof(System.Int32)};
            method = type.GetMethod("Login", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Login_72);
            args = new Type[]{};
            method = type.GetMethod("StopNetClient", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, StopNetClient_73);
            args = new Type[]{};
            method = type.GetMethod("GetServerDateTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetServerDateTime_74);
            args = new Type[]{};
            method = type.GetMethod("get_ServerTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_ServerTime_75);
            args = new Type[]{};
            method = type.GetMethod("CancelQueueTime", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CancelQueueTime_76);

            field = type.GetField("IsSkillEditorScene", flag);
            app.RegisterCLRFieldGetter(field, get_IsSkillEditorScene_0);
            app.RegisterCLRFieldSetter(field, set_IsSkillEditorScene_0);
            field = type.GetField("GameMode", flag);
            app.RegisterCLRFieldGetter(field, get_GameMode_1);
            app.RegisterCLRFieldSetter(field, set_GameMode_1);
            field = type.GetField("ServerIP", flag);
            app.RegisterCLRFieldGetter(field, get_ServerIP_2);
            app.RegisterCLRFieldSetter(field, set_ServerIP_2);
            field = type.GetField("ServerPort", flag);
            app.RegisterCLRFieldGetter(field, get_ServerPort_3);
            app.RegisterCLRFieldSetter(field, set_ServerPort_3);
            field = type.GetField("Account", flag);
            app.RegisterCLRFieldGetter(field, get_Account_4);
            app.RegisterCLRFieldSetter(field, set_Account_4);
            field = type.GetField("Password", flag);
            app.RegisterCLRFieldGetter(field, get_Password_5);
            app.RegisterCLRFieldSetter(field, set_Password_5);
            field = type.GetField("ServerID", flag);
            app.RegisterCLRFieldGetter(field, get_ServerID_6);
            app.RegisterCLRFieldSetter(field, set_ServerID_6);
            field = type.GetField("mIsInited", flag);
            app.RegisterCLRFieldGetter(field, get_mIsInited_7);
            app.RegisterCLRFieldSetter(field, set_mIsInited_7);
            field = type.GetField("IsEnterGame", flag);
            app.RegisterCLRFieldGetter(field, get_IsEnterGame_8);
            app.RegisterCLRFieldSetter(field, set_IsEnterGame_8);


            app.RegisterCLRCreateArrayInstance(type, s => new xc.Game[s]);


        }


        static StackObject* GetScreenWidth_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetScreenWidth();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetScreenHeight_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetScreenHeight();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_IsRebooting_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsRebooting;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsRebooting_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsRebooting = value;

            return __ret;
        }

        static StackObject* get_ManualCancelReconnect_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ManualCancelReconnect;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_ManualCancelReconnect_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ManualCancelReconnect = value;

            return __ret;
        }

        static StackObject* get_MainCamera_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.MainCamera;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_CameraControl_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CameraControl;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_GameObjectControl_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GameObjectControl;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_AccountIdx_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.AccountIdx;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_CharacterList_10(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CharacterList;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_CharactorMaxCount_11(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.CharactorMaxCount;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetInstance_12(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.Game.GetInstance();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Instance_13(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.Game.Instance;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_LocalPlayerID_14(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerID;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_LocalPlayerID_15(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.UnitID @value = (xc.UnitID)typeof(xc.UnitID).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.LocalPlayerID = value;

            return __ret;
        }

        static StackObject* get_LocalPlayerName_16(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerName;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_LocalPlayerName_17(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @value = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.LocalPlayerName = value;

            return __ret;
        }

        static StackObject* get_LocalPlayerTypeID_18(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerTypeID;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* set_LocalPlayerTypeID_19(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @value = (uint)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.LocalPlayerTypeID = value;

            return __ret;
        }

        static StackObject* get_LocalPlayerVocation_20(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerVocation;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_LocalPlayerRadius_21(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerRadius;

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* set_LocalPlayerRadius_22(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Single @value = *(float*)&ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.LocalPlayerRadius = value;

            return __ret;
        }

        static StackObject* get_LocalPlayerAOIInfo_23(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LocalPlayerAOIInfo;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_LocalPlayerAOIInfo_24(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.UnitEnterAOI._Player @value = (xc.UnitEnterAOI._Player)typeof(xc.UnitEnterAOI._Player).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.LocalPlayerAOIInfo = value;

            return __ret;
        }

        static StackObject* GetCurStateId_25(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetCurStateId();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_IsSwitchingScene_26(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsSwitchingScene;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsSwitchingScene_27(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsSwitchingScene = value;

            return __ret;
        }

        static StackObject* GetLoadAsyncOp_28(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetLoadAsyncOp();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetLoadAsyncOp_29(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.AsyncOperation @op = (UnityEngine.AsyncOperation)typeof(UnityEngine.AsyncOperation).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetLoadAsyncOp(@op);

            return __ret;
        }

        static StackObject* SetLocalPlayer_30(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            global::Actor @player = (global::Actor)typeof(global::Actor).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetLocalPlayer(@player);

            return __ret;
        }

        static StackObject* GetLocalPlayer_31(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetLocalPlayer();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SubscribeNetNotify_32(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game.DataReplyDelegate @func = (xc.Game.DataReplyDelegate)typeof(xc.Game.DataReplyDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SubscribeNetNotify(@protocol, @func);

            return __ret;
        }

        static StackObject* UnsubscribeNetNotify_33(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game.DataReplyDelegate @func = (xc.Game.DataReplyDelegate)typeof(xc.Game.DataReplyDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.UnsubscribeNetNotify(@protocol, @func);

            return __ret;
        }

        static StackObject* SubscribeLuaNetNotify_34(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game.DataReplyDelegate @func = (xc.Game.DataReplyDelegate)typeof(xc.Game.DataReplyDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SubscribeLuaNetNotify(@protocol, @func);

            return __ret;
        }

        static StackObject* UnsubscribeLuaNetNotify_35(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game.DataReplyDelegate @func = (xc.Game.DataReplyDelegate)typeof(xc.Game.DataReplyDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.UnsubscribeLuaNetNotify(@protocol, @func);

            return __ret;
        }

        static StackObject* Quit_36(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @callApplicationQuit = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Quit(@callApplicationQuit);

            return __ret;
        }

        static StackObject* Init_37(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Init();

            return __ret;
        }

        static StackObject* OnLog_38(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.LogType @type = (UnityEngine.LogType)typeof(UnityEngine.LogType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @stackTrace = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @log = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnLog(@log, @stackTrace, @type);

            return __ret;
        }

        static StackObject* Reset_39(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @ignore_reconnect = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Reset(@ignore_reconnect);

            return __ret;
        }

        static StackObject* IsNetMode_40(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsNetMode();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* GetFSM_41(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetFSM();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* InitFSM_42(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.InitFSM();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* Update_43(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Update();

            return __ret;
        }

        static StackObject* WaitForSceneLoadAsyncOp_44(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = xc.Game.WaitForSceneLoadAsyncOp();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* Rebot_45(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Rebot();

            return __ret;
        }

        static StackObject* RebotWithoutSdkLogout_46(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RebotWithoutSdkLogout();

            return __ret;
        }

        static StackObject* ChangeRole_47(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ChangeRole();

            return __ret;
        }

        static StackObject* get_IsCreateRoleEnter_48(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsCreateRoleEnter;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_IsCreateRoleEnter_49(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IsCreateRoleEnter = value;

            return __ret;
        }

        static StackObject* get_Connected_50(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Connected;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_Converted_51(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Converted;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_ServerOpenTime_52(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ServerOpenTime;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_ServerOpenDateTime_53(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ServerOpenDateTime;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_TimeZone_54(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.TimeZone;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* TimeZoneHour_55(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.TimeZoneHour();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* TimeZoneMin_56(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.TimeZoneMin();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* GetOpenDay_57(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetOpenDay();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_MergeServerTime_58(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.MergeServerTime;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_MergeServerDateTime_59(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.MergeServerDateTime;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_AllSystemInited_60(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.AllSystemInited;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_PackRecorder_61(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.PackRecorder;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* OnNetConnect_62(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            Net.NetType @netType = (Net.NetType)typeof(Net.NetType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnNetConnect(@netType);

            return __ret;
        }

        static StackObject* get_QueueMax_63(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.QueueMax;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_LoginConflict_64(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.LoginConflict;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_MaintainServer_65(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.MaintainServer;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* get_ForceDisconnect_66(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ForceDisconnect;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* OnNetDisconnect_67(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @e = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            Net.NetType @netType = (Net.NetType)typeof(Net.NetType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnNetDisconnect(@netType, @e);

            return __ret;
        }

        static StackObject* OnNetDataReply_68(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @data = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            Net.NetType @netType = (Net.NetType)typeof(Net.NetType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnNetDataReply(@netType, @protocol, @data);

            return __ret;
        }

        static StackObject* ProcessServerData_69(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @data = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ProcessServerData(@protocol, @data);

            return __ret;
        }

        static StackObject* HandleServerData_70(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @data = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @protocol = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HandleServerData(@protocol, @data);

            return __ret;
        }

        static StackObject* Login_71(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Login();

            return __ret;
        }

        static StackObject* Login_72(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @port = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @ip = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Login(@ip, @port);

            return __ret;
        }

        static StackObject* StopNetClient_73(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.StopNetClient();

            return __ret;
        }

        static StackObject* GetServerDateTime_74(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetServerDateTime();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_ServerTime_75(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ServerTime;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static StackObject* CancelQueueTime_76(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            xc.Game instance_of_this_method = (xc.Game)typeof(xc.Game).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.CancelQueueTime();

            return __ret;
        }


        static object get_IsSkillEditorScene_0(ref object o)
        {
            return ((xc.Game)o).IsSkillEditorScene;
        }
        static void set_IsSkillEditorScene_0(ref object o, object v)
        {
            ((xc.Game)o).IsSkillEditorScene = (System.Boolean)v;
        }
        static object get_GameMode_1(ref object o)
        {
            return ((xc.Game)o).GameMode;
        }
        static void set_GameMode_1(ref object o, object v)
        {
            ((xc.Game)o).GameMode = (xc.Game.EGameMode)v;
        }
        static object get_ServerIP_2(ref object o)
        {
            return ((xc.Game)o).ServerIP;
        }
        static void set_ServerIP_2(ref object o, object v)
        {
            ((xc.Game)o).ServerIP = (System.String)v;
        }
        static object get_ServerPort_3(ref object o)
        {
            return ((xc.Game)o).ServerPort;
        }
        static void set_ServerPort_3(ref object o, object v)
        {
            ((xc.Game)o).ServerPort = (System.Int32)v;
        }
        static object get_Account_4(ref object o)
        {
            return ((xc.Game)o).Account;
        }
        static void set_Account_4(ref object o, object v)
        {
            ((xc.Game)o).Account = (System.String)v;
        }
        static object get_Password_5(ref object o)
        {
            return ((xc.Game)o).Password;
        }
        static void set_Password_5(ref object o, object v)
        {
            ((xc.Game)o).Password = (System.String)v;
        }
        static object get_ServerID_6(ref object o)
        {
            return ((xc.Game)o).ServerID;
        }
        static void set_ServerID_6(ref object o, object v)
        {
            ((xc.Game)o).ServerID = (System.UInt32)v;
        }
        static object get_mIsInited_7(ref object o)
        {
            return ((xc.Game)o).mIsInited;
        }
        static void set_mIsInited_7(ref object o, object v)
        {
            ((xc.Game)o).mIsInited = (System.Boolean)v;
        }
        static object get_IsEnterGame_8(ref object o)
        {
            return ((xc.Game)o).IsEnterGame;
        }
        static void set_IsEnterGame_8(ref object o, object v)
        {
            ((xc.Game)o).IsEnterGame = (System.Boolean)v;
        }



    }
}
#endif
