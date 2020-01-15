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


namespace XLua
{
    public partial class ObjectTranslator
    {
        
        class IniterAdderUnityEngineVector2
        {
            static IniterAdderUnityEngineVector2()
            {
                LuaEnv.AddIniter(Init);
            }
			
			static void Init(LuaEnv luaenv, ObjectTranslator translator)
			{
			
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector2>(translator.PushUnityEngineVector2, translator.Get, translator.UpdateUnityEngineVector2);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector3>(translator.PushUnityEngineVector3, translator.Get, translator.UpdateUnityEngineVector3);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector4>(translator.PushUnityEngineVector4, translator.Get, translator.UpdateUnityEngineVector4);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Color>(translator.PushUnityEngineColor, translator.Get, translator.UpdateUnityEngineColor);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Quaternion>(translator.PushUnityEngineQuaternion, translator.Get, translator.UpdateUnityEngineQuaternion);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray>(translator.PushUnityEngineRay, translator.Get, translator.UpdateUnityEngineRay);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Bounds>(translator.PushUnityEngineBounds, translator.Get, translator.UpdateUnityEngineBounds);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray2D>(translator.PushUnityEngineRay2D, translator.Get, translator.UpdateUnityEngineRay2D);
				translator.RegisterPushAndGetAndUpdate<xc.Game.EGameMode>(translator.PushxcGameEGameMode, translator.Get, translator.UpdatexcGameEGameMode);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.RectTransform.Axis>(translator.PushUnityEngineRectTransformAxis, translator.Get, translator.UpdateUnityEngineRectTransformAxis);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.RectTransform.Edge>(translator.PushUnityEngineRectTransformEdge, translator.Get, translator.UpdateUnityEngineRectTransformEdge);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.RuntimePlatform>(translator.PushUnityEngineRuntimePlatform, translator.Get, translator.UpdateUnityEngineRuntimePlatform);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.AnimatorCullingMode>(translator.PushUnityEngineAnimatorCullingMode, translator.Get, translator.UpdateUnityEngineAnimatorCullingMode);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Texture2D.EXRFlags>(translator.PushUnityEngineTexture2DEXRFlags, translator.Get, translator.UpdateUnityEngineTexture2DEXRFlags);
				translator.RegisterPushAndGetAndUpdate<Net.NetClient.ENetState>(translator.PushNetNetClientENetState, translator.Get, translator.UpdateNetNetClientENetState);
				translator.RegisterPushAndGetAndUpdate<xc.ObjCachePoolType>(translator.PushxcObjCachePoolType, translator.Get, translator.UpdatexcObjCachePoolType);
				translator.RegisterPushAndGetAndUpdate<xc.PlayerFollowRecordSceneId>(translator.PushxcPlayerFollowRecordSceneId, translator.Get, translator.UpdatexcPlayerFollowRecordSceneId);
				translator.RegisterPushAndGetAndUpdate<xc.ClientEvent>(translator.PushxcClientEvent, translator.Get, translator.UpdatexcClientEvent);
				translator.RegisterPushAndGetAndUpdate<CameraControl.EMode>(translator.PushCameraControlEMode, translator.Get, translator.UpdateCameraControlEMode);
				translator.RegisterPushAndGetAndUpdate<xc.DBManager.CommandTag>(translator.PushxcDBManagerCommandTag, translator.Get, translator.UpdatexcDBManagerCommandTag);
				translator.RegisterPushAndGetAndUpdate<xc.DBNotice.EFillType>(translator.PushxcDBNoticeEFillType, translator.Get, translator.UpdatexcDBNoticeEFillType);
				translator.RegisterPushAndGetAndUpdate<xc.DBDataAllSkill.SET_SLOT_TYPE>(translator.PushxcDBDataAllSkillSET_SLOT_TYPE, translator.Get, translator.UpdatexcDBDataAllSkillSET_SLOT_TYPE);
				translator.RegisterPushAndGetAndUpdate<xc.DBDataAllSkill.SKILL_TYPE>(translator.PushxcDBDataAllSkillSKILL_TYPE, translator.Get, translator.UpdatexcDBDataAllSkillSKILL_TYPE);
				translator.RegisterPushAndGetAndUpdate<DBBuffSev.BindPos>(translator.PushDBBuffSevBindPos, translator.Get, translator.UpdateDBBuffSevBindPos);
				translator.RegisterPushAndGetAndUpdate<xc.DBGrowSkin.SkinUnLockType>(translator.PushxcDBGrowSkinSkinUnLockType, translator.Get, translator.UpdatexcDBGrowSkinSkinUnLockType);
				translator.RegisterPushAndGetAndUpdate<xc.DBAvatarPart.BODY_PART>(translator.PushxcDBAvatarPartBODY_PART, translator.Get, translator.UpdatexcDBAvatarPartBODY_PART);
				translator.RegisterPushAndGetAndUpdate<xc.DBPet.PetUnLockType>(translator.PushxcDBPetPetUnLockType, translator.Get, translator.UpdatexcDBPetPetUnLockType);
				translator.RegisterPushAndGetAndUpdate<xc.DBSysConfig.ESysBtnFixType>(translator.PushxcDBSysConfigESysBtnFixType, translator.Get, translator.UpdatexcDBSysConfigESysBtnFixType);
				translator.RegisterPushAndGetAndUpdate<xc.DBSysConfig.ESysBtnPos>(translator.PushxcDBSysConfigESysBtnPos, translator.Get, translator.UpdatexcDBSysConfigESysBtnPos);
				translator.RegisterPushAndGetAndUpdate<xc.DBSysConfig.ESysTaskType>(translator.PushxcDBSysConfigESysTaskType, translator.Get, translator.UpdatexcDBSysConfigESysTaskType);
				translator.RegisterPushAndGetAndUpdate<xc.DBEquipPos.EquipPosType>(translator.PushxcDBEquipPosEquipPosType, translator.Get, translator.UpdatexcDBEquipPosEquipPosType);
				translator.RegisterPushAndGetAndUpdate<xc.Buff.BuffFlags>(translator.PushxcBuffBuffFlags, translator.Get, translator.UpdatexcBuffBuffFlags);
				translator.RegisterPushAndGetAndUpdate<xc.RockCommandSystem.ClickRockButtonTipsType>(translator.PushxcRockCommandSystemClickRockButtonTipsType, translator.Get, translator.UpdatexcRockCommandSystemClickRockButtonTipsType);
				translator.RegisterPushAndGetAndUpdate<Actor.EHeadIcon>(translator.PushActorEHeadIcon, translator.Get, translator.UpdateActorEHeadIcon);
				translator.RegisterPushAndGetAndUpdate<Actor.EVocationType>(translator.PushActorEVocationType, translator.Get, translator.UpdateActorEVocationType);
				translator.RegisterPushAndGetAndUpdate<Actor.ActorEvent>(translator.PushActorActorEvent, translator.Get, translator.UpdateActorActorEvent);
				translator.RegisterPushAndGetAndUpdate<Actor.EAnimation>(translator.PushActorEAnimation, translator.Get, translator.UpdateActorEAnimation);
				translator.RegisterPushAndGetAndUpdate<Actor.SlotBoneNameType>(translator.PushActorSlotBoneNameType, translator.Get, translator.UpdateActorSlotBoneNameType);
				translator.RegisterPushAndGetAndUpdate<Actor.EWildState>(translator.PushActorEWildState, translator.Get, translator.UpdateActorEWildState);
				translator.RegisterPushAndGetAndUpdate<Monster.MonsterSpawnType>(translator.PushMonsterMonsterSpawnType, translator.Get, translator.UpdateMonsterMonsterSpawnType);
				translator.RegisterPushAndGetAndUpdate<Monster.MonsterType>(translator.PushMonsterMonsterType, translator.Get, translator.UpdateMonsterMonsterType);
				translator.RegisterPushAndGetAndUpdate<Monster.BeSummonType>(translator.PushMonsterBeSummonType, translator.Get, translator.UpdateMonsterBeSummonType);
				translator.RegisterPushAndGetAndUpdate<Monster.QualityColor>(translator.PushMonsterQualityColor, translator.Get, translator.UpdateMonsterQualityColor);
				translator.RegisterPushAndGetAndUpdate<xc.MoveCtrl.EActorStepType>(translator.PushxcMoveCtrlEActorStepType, translator.Get, translator.UpdatexcMoveCtrlEActorStepType);
				translator.RegisterPushAndGetAndUpdate<xc.ActorMachine.EWalkMode>(translator.PushxcActorMachineEWalkMode, translator.Get, translator.UpdatexcActorMachineEWalkMode);
				translator.RegisterPushAndGetAndUpdate<xc.ActorMachine.EFSMEvent>(translator.PushxcActorMachineEFSMEvent, translator.Get, translator.UpdatexcActorMachineEFSMEvent);
				translator.RegisterPushAndGetAndUpdate<xc.ActorMachine.EFSMState>(translator.PushxcActorMachineEFSMState, translator.Get, translator.UpdatexcActorMachineEFSMState);
				translator.RegisterPushAndGetAndUpdate<xc.NpcDefine.EFunction>(translator.PushxcNpcDefineEFunction, translator.Get, translator.UpdatexcNpcDefineEFunction);
				translator.RegisterPushAndGetAndUpdate<xc.NpcDefine.ELightMode>(translator.PushxcNpcDefineELightMode, translator.Get, translator.UpdatexcNpcDefineELightMode);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Toggle.ToggleTransition>(translator.PushUnityEngineUIToggleToggleTransition, translator.Get, translator.UpdateUnityEngineUIToggleToggleTransition);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Slider.Direction>(translator.PushUnityEngineUISliderDirection, translator.Get, translator.UpdateUnityEngineUISliderDirection);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.Origin360>(translator.PushUnityEngineUIImageOrigin360, translator.Get, translator.UpdateUnityEngineUIImageOrigin360);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.Origin180>(translator.PushUnityEngineUIImageOrigin180, translator.Get, translator.UpdateUnityEngineUIImageOrigin180);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.Origin90>(translator.PushUnityEngineUIImageOrigin90, translator.Get, translator.UpdateUnityEngineUIImageOrigin90);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.OriginVertical>(translator.PushUnityEngineUIImageOriginVertical, translator.Get, translator.UpdateUnityEngineUIImageOriginVertical);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.OriginHorizontal>(translator.PushUnityEngineUIImageOriginHorizontal, translator.Get, translator.UpdateUnityEngineUIImageOriginHorizontal);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.FillMethod>(translator.PushUnityEngineUIImageFillMethod, translator.Get, translator.UpdateUnityEngineUIImageFillMethod);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.Image.Type>(translator.PushUnityEngineUIImageType, translator.Get, translator.UpdateUnityEngineUIImageType);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.TextAnchor>(translator.PushUnityEngineTextAnchor, translator.Get, translator.UpdateUnityEngineTextAnchor);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.InputField.LineType>(translator.PushUnityEngineUIInputFieldLineType, translator.Get, translator.UpdateUnityEngineUIInputFieldLineType);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.InputField.CharacterValidation>(translator.PushUnityEngineUIInputFieldCharacterValidation, translator.Get, translator.UpdateUnityEngineUIInputFieldCharacterValidation);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.InputField.InputType>(translator.PushUnityEngineUIInputFieldInputType, translator.Get, translator.UpdateUnityEngineUIInputFieldInputType);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.InputField.ContentType>(translator.PushUnityEngineUIInputFieldContentType, translator.Get, translator.UpdateUnityEngineUIInputFieldContentType);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.ScrollRect.ScrollbarVisibility>(translator.PushUnityEngineUIScrollRectScrollbarVisibility, translator.Get, translator.UpdateUnityEngineUIScrollRectScrollbarVisibility);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.ScrollRect.MovementType>(translator.PushUnityEngineUIScrollRectMovementType, translator.Get, translator.UpdateUnityEngineUIScrollRectMovementType);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.GridLayoutGroup.Constraint>(translator.PushUnityEngineUIGridLayoutGroupConstraint, translator.Get, translator.UpdateUnityEngineUIGridLayoutGroupConstraint);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.GridLayoutGroup.Axis>(translator.PushUnityEngineUIGridLayoutGroupAxis, translator.Get, translator.UpdateUnityEngineUIGridLayoutGroupAxis);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.GridLayoutGroup.Corner>(translator.PushUnityEngineUIGridLayoutGroupCorner, translator.Get, translator.UpdateUnityEngineUIGridLayoutGroupCorner);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.UI.ContentSizeFitter.FitMode>(translator.PushUnityEngineUIContentSizeFitterFitMode, translator.Get, translator.UpdateUnityEngineUIContentSizeFitterFitMode);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.EventSystems.EventTriggerType>(translator.PushUnityEngineEventSystemsEventTriggerType, translator.Get, translator.UpdateUnityEngineEventSystemsEventTriggerType);
				translator.RegisterPushAndGetAndUpdate<AutoScale.ScaleMode>(translator.PushAutoScaleScaleMode, translator.Get, translator.UpdateAutoScaleScaleMode);
				translator.RegisterPushAndGetAndUpdate<EmojiText.EmojiMaterialType>(translator.PushEmojiTextEmojiMaterialType, translator.Get, translator.UpdateEmojiTextEmojiMaterialType);
				translator.RegisterPushAndGetAndUpdate<xc.ui.LockIcon.State>(translator.PushxcuiLockIconState, translator.Get, translator.UpdatexcuiLockIconState);
				translator.RegisterPushAndGetAndUpdate<xc.ui.ugui.UIManager.RefreshOrder>(translator.PushxcuiuguiUIManagerRefreshOrder, translator.Get, translator.UpdatexcuiuguiUIManagerRefreshOrder);
				translator.RegisterPushAndGetAndUpdate<xc.ui.ugui.UIBaseWindow.CloseWinsType>(translator.PushxcuiuguiUIBaseWindowCloseWinsType, translator.Get, translator.UpdatexcuiuguiUIBaseWindowCloseWinsType);
				translator.RegisterPushAndGetAndUpdate<xc.ui.ugui.UIType>(translator.PushxcuiuguiUIType, translator.Get, translator.UpdatexcuiuguiUIType);
				translator.RegisterPushAndGetAndUpdate<xc.ui.UIWidgetHelp.DragDropGroup>(translator.PushxcuiUIWidgetHelpDragDropGroup, translator.Get, translator.UpdatexcuiUIWidgetHelpDragDropGroup);
				translator.RegisterPushAndGetAndUpdate<xc.ui.ugui.UINoticeWindow.EWindowType>(translator.PushxcuiuguiUINoticeWindowEWindowType, translator.Get, translator.UpdatexcuiuguiUINoticeWindowEWindowType);
				translator.RegisterPushAndGetAndUpdate<xc.GoodsHelper.ItemMainType>(translator.PushxcGoodsHelperItemMainType, translator.Get, translator.UpdatexcGoodsHelperItemMainType);
				translator.RegisterPushAndGetAndUpdate<xc.TaskDefine.EAutoRunType>(translator.PushxcTaskDefineEAutoRunType, translator.Get, translator.UpdatexcTaskDefineEAutoRunType);
				translator.RegisterPushAndGetAndUpdate<xc.VoiceControlComponent.State>(translator.PushxcVoiceControlComponentState, translator.Get, translator.UpdatexcVoiceControlComponentState);
				translator.RegisterPushAndGetAndUpdate<xc.EquipBaptizeInfo.EquipBaptizeState>(translator.PushxcEquipBaptizeInfoEquipBaptizeState, translator.Get, translator.UpdatexcEquipBaptizeInfoEquipBaptizeState);
				translator.RegisterPushAndGetAndUpdate<xc.InteractiveType>(translator.PushxcInteractiveType, translator.Get, translator.UpdatexcInteractiveType);
				translator.RegisterPushAndGetAndUpdate<xc.FriendType>(translator.PushxcFriendType, translator.Get, translator.UpdatexcFriendType);
				translator.RegisterPushAndGetAndUpdate<xc.MailInfo.JumpType>(translator.PushxcMailInfoJumpType, translator.Get, translator.UpdatexcMailInfoJumpType);
				translator.RegisterPushAndGetAndUpdate<xc.SceneHelp.LoadQuadTreeSceneState>(translator.PushxcSceneHelpLoadQuadTreeSceneState, translator.Get, translator.UpdatexcSceneHelpLoadQuadTreeSceneState);
				translator.RegisterPushAndGetAndUpdate<xc.InstanceManager.InstaneOpenState>(translator.PushxcInstanceManagerInstaneOpenState, translator.Get, translator.UpdatexcInstanceManagerInstaneOpenState);
				translator.RegisterPushAndGetAndUpdate<xc.InstanceManager.ERewardState>(translator.PushxcInstanceManagerERewardState, translator.Get, translator.UpdatexcInstanceManagerERewardState);
				translator.RegisterPushAndGetAndUpdate<xc.EHookRangeType>(translator.PushxcEHookRangeType, translator.Get, translator.UpdatexcEHookRangeType);
				translator.RegisterPushAndGetAndUpdate<xc.CustomDataType>(translator.PushxcCustomDataType, translator.Get, translator.UpdatexcCustomDataType);
			
			}
        }
        
        static IniterAdderUnityEngineVector2 s_IniterAdderUnityEngineVector2_dumb_obj = new IniterAdderUnityEngineVector2();
        static IniterAdderUnityEngineVector2 IniterAdderUnityEngineVector2_dumb_obj {get{return s_IniterAdderUnityEngineVector2_dumb_obj;}}
        
        
        int UnityEngineVector2_TypeID = -1;
        public void PushUnityEngineVector2(RealStatePtr L, UnityEngine.Vector2 val)
        {
            if (UnityEngineVector2_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector2_TypeID = getTypeId(L, typeof(UnityEngine.Vector2), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 8, UnityEngineVector2_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector2 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector2 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector2");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector2)objectCasters.GetCaster(typeof(UnityEngine.Vector2))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector2(RealStatePtr L, int index, UnityEngine.Vector2 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector2 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector3_TypeID = -1;
        public void PushUnityEngineVector3(RealStatePtr L, UnityEngine.Vector3 val)
        {
            if (UnityEngineVector3_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector3_TypeID = getTypeId(L, typeof(UnityEngine.Vector3), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 12, UnityEngineVector3_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector3 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector3 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector3");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector3)objectCasters.GetCaster(typeof(UnityEngine.Vector3))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector3(RealStatePtr L, int index, UnityEngine.Vector3 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector3 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector4_TypeID = -1;
        public void PushUnityEngineVector4(RealStatePtr L, UnityEngine.Vector4 val)
        {
            if (UnityEngineVector4_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector4_TypeID = getTypeId(L, typeof(UnityEngine.Vector4), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineVector4_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector4 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector4 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector4");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector4)objectCasters.GetCaster(typeof(UnityEngine.Vector4))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector4(RealStatePtr L, int index, UnityEngine.Vector4 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector4 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineColor_TypeID = -1;
        public void PushUnityEngineColor(RealStatePtr L, UnityEngine.Color val)
        {
            if (UnityEngineColor_TypeID == -1)
            {
			    bool is_first;
                UnityEngineColor_TypeID = getTypeId(L, typeof(UnityEngine.Color), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineColor_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Color ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Color val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Color");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Color)objectCasters.GetCaster(typeof(UnityEngine.Color))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineColor(RealStatePtr L, int index, UnityEngine.Color val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Color ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineQuaternion_TypeID = -1;
        public void PushUnityEngineQuaternion(RealStatePtr L, UnityEngine.Quaternion val)
        {
            if (UnityEngineQuaternion_TypeID == -1)
            {
			    bool is_first;
                UnityEngineQuaternion_TypeID = getTypeId(L, typeof(UnityEngine.Quaternion), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineQuaternion_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Quaternion ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Quaternion val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Quaternion");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Quaternion)objectCasters.GetCaster(typeof(UnityEngine.Quaternion))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineQuaternion(RealStatePtr L, int index, UnityEngine.Quaternion val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Quaternion ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay_TypeID = -1;
        public void PushUnityEngineRay(RealStatePtr L, UnityEngine.Ray val)
        {
            if (UnityEngineRay_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay_TypeID = getTypeId(L, typeof(UnityEngine.Ray), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineRay_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray)objectCasters.GetCaster(typeof(UnityEngine.Ray))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay(RealStatePtr L, int index, UnityEngine.Ray val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineBounds_TypeID = -1;
        public void PushUnityEngineBounds(RealStatePtr L, UnityEngine.Bounds val)
        {
            if (UnityEngineBounds_TypeID == -1)
            {
			    bool is_first;
                UnityEngineBounds_TypeID = getTypeId(L, typeof(UnityEngine.Bounds), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineBounds_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Bounds ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Bounds val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Bounds");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Bounds)objectCasters.GetCaster(typeof(UnityEngine.Bounds))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineBounds(RealStatePtr L, int index, UnityEngine.Bounds val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Bounds ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay2D_TypeID = -1;
        public void PushUnityEngineRay2D(RealStatePtr L, UnityEngine.Ray2D val)
        {
            if (UnityEngineRay2D_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay2D_TypeID = getTypeId(L, typeof(UnityEngine.Ray2D), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineRay2D_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray2D ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray2D val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray2D");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray2D)objectCasters.GetCaster(typeof(UnityEngine.Ray2D))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay2D(RealStatePtr L, int index, UnityEngine.Ray2D val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray2D ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcGameEGameMode_TypeID = -1;
		int xcGameEGameMode_EnumRef = -1;
        
        public void PushxcGameEGameMode(RealStatePtr L, xc.Game.EGameMode val)
        {
            if (xcGameEGameMode_TypeID == -1)
            {
			    bool is_first;
                xcGameEGameMode_TypeID = getTypeId(L, typeof(xc.Game.EGameMode), out is_first);
				
				if (xcGameEGameMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.Game.EGameMode));
				    xcGameEGameMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcGameEGameMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcGameEGameMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.Game.EGameMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcGameEGameMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.Game.EGameMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcGameEGameMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.Game.EGameMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.Game.EGameMode");
                }
				val = (xc.Game.EGameMode)e;
                
            }
            else
            {
                val = (xc.Game.EGameMode)objectCasters.GetCaster(typeof(xc.Game.EGameMode))(L, index, null);
            }
        }
		
        public void UpdatexcGameEGameMode(RealStatePtr L, int index, xc.Game.EGameMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcGameEGameMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.Game.EGameMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.Game.EGameMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRectTransformAxis_TypeID = -1;
		int UnityEngineRectTransformAxis_EnumRef = -1;
        
        public void PushUnityEngineRectTransformAxis(RealStatePtr L, UnityEngine.RectTransform.Axis val)
        {
            if (UnityEngineRectTransformAxis_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRectTransformAxis_TypeID = getTypeId(L, typeof(UnityEngine.RectTransform.Axis), out is_first);
				
				if (UnityEngineRectTransformAxis_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.RectTransform.Axis));
				    UnityEngineRectTransformAxis_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineRectTransformAxis_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineRectTransformAxis_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.RectTransform.Axis ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineRectTransformAxis_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.RectTransform.Axis val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRectTransformAxis_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RectTransform.Axis");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.RectTransform.Axis");
                }
				val = (UnityEngine.RectTransform.Axis)e;
                
            }
            else
            {
                val = (UnityEngine.RectTransform.Axis)objectCasters.GetCaster(typeof(UnityEngine.RectTransform.Axis))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRectTransformAxis(RealStatePtr L, int index, UnityEngine.RectTransform.Axis val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRectTransformAxis_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RectTransform.Axis");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.RectTransform.Axis ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRectTransformEdge_TypeID = -1;
		int UnityEngineRectTransformEdge_EnumRef = -1;
        
        public void PushUnityEngineRectTransformEdge(RealStatePtr L, UnityEngine.RectTransform.Edge val)
        {
            if (UnityEngineRectTransformEdge_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRectTransformEdge_TypeID = getTypeId(L, typeof(UnityEngine.RectTransform.Edge), out is_first);
				
				if (UnityEngineRectTransformEdge_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.RectTransform.Edge));
				    UnityEngineRectTransformEdge_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineRectTransformEdge_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineRectTransformEdge_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.RectTransform.Edge ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineRectTransformEdge_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.RectTransform.Edge val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRectTransformEdge_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RectTransform.Edge");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.RectTransform.Edge");
                }
				val = (UnityEngine.RectTransform.Edge)e;
                
            }
            else
            {
                val = (UnityEngine.RectTransform.Edge)objectCasters.GetCaster(typeof(UnityEngine.RectTransform.Edge))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRectTransformEdge(RealStatePtr L, int index, UnityEngine.RectTransform.Edge val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRectTransformEdge_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RectTransform.Edge");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.RectTransform.Edge ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRuntimePlatform_TypeID = -1;
		int UnityEngineRuntimePlatform_EnumRef = -1;
        
        public void PushUnityEngineRuntimePlatform(RealStatePtr L, UnityEngine.RuntimePlatform val)
        {
            if (UnityEngineRuntimePlatform_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRuntimePlatform_TypeID = getTypeId(L, typeof(UnityEngine.RuntimePlatform), out is_first);
				
				if (UnityEngineRuntimePlatform_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.RuntimePlatform));
				    UnityEngineRuntimePlatform_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineRuntimePlatform_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineRuntimePlatform_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.RuntimePlatform ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineRuntimePlatform_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.RuntimePlatform val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRuntimePlatform_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RuntimePlatform");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.RuntimePlatform");
                }
				val = (UnityEngine.RuntimePlatform)e;
                
            }
            else
            {
                val = (UnityEngine.RuntimePlatform)objectCasters.GetCaster(typeof(UnityEngine.RuntimePlatform))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRuntimePlatform(RealStatePtr L, int index, UnityEngine.RuntimePlatform val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRuntimePlatform_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.RuntimePlatform");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.RuntimePlatform ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineAnimatorCullingMode_TypeID = -1;
		int UnityEngineAnimatorCullingMode_EnumRef = -1;
        
        public void PushUnityEngineAnimatorCullingMode(RealStatePtr L, UnityEngine.AnimatorCullingMode val)
        {
            if (UnityEngineAnimatorCullingMode_TypeID == -1)
            {
			    bool is_first;
                UnityEngineAnimatorCullingMode_TypeID = getTypeId(L, typeof(UnityEngine.AnimatorCullingMode), out is_first);
				
				if (UnityEngineAnimatorCullingMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.AnimatorCullingMode));
				    UnityEngineAnimatorCullingMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineAnimatorCullingMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineAnimatorCullingMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.AnimatorCullingMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineAnimatorCullingMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.AnimatorCullingMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineAnimatorCullingMode_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.AnimatorCullingMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.AnimatorCullingMode");
                }
				val = (UnityEngine.AnimatorCullingMode)e;
                
            }
            else
            {
                val = (UnityEngine.AnimatorCullingMode)objectCasters.GetCaster(typeof(UnityEngine.AnimatorCullingMode))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineAnimatorCullingMode(RealStatePtr L, int index, UnityEngine.AnimatorCullingMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineAnimatorCullingMode_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.AnimatorCullingMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.AnimatorCullingMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineTexture2DEXRFlags_TypeID = -1;
		int UnityEngineTexture2DEXRFlags_EnumRef = -1;
        
        public void PushUnityEngineTexture2DEXRFlags(RealStatePtr L, UnityEngine.Texture2D.EXRFlags val)
        {
            if (UnityEngineTexture2DEXRFlags_TypeID == -1)
            {
			    bool is_first;
                UnityEngineTexture2DEXRFlags_TypeID = getTypeId(L, typeof(UnityEngine.Texture2D.EXRFlags), out is_first);
				
				if (UnityEngineTexture2DEXRFlags_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.Texture2D.EXRFlags));
				    UnityEngineTexture2DEXRFlags_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineTexture2DEXRFlags_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineTexture2DEXRFlags_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.Texture2D.EXRFlags ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineTexture2DEXRFlags_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Texture2D.EXRFlags val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineTexture2DEXRFlags_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Texture2D.EXRFlags");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.Texture2D.EXRFlags");
                }
				val = (UnityEngine.Texture2D.EXRFlags)e;
                
            }
            else
            {
                val = (UnityEngine.Texture2D.EXRFlags)objectCasters.GetCaster(typeof(UnityEngine.Texture2D.EXRFlags))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineTexture2DEXRFlags(RealStatePtr L, int index, UnityEngine.Texture2D.EXRFlags val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineTexture2DEXRFlags_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Texture2D.EXRFlags");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.Texture2D.EXRFlags ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int NetNetClientENetState_TypeID = -1;
		int NetNetClientENetState_EnumRef = -1;
        
        public void PushNetNetClientENetState(RealStatePtr L, Net.NetClient.ENetState val)
        {
            if (NetNetClientENetState_TypeID == -1)
            {
			    bool is_first;
                NetNetClientENetState_TypeID = getTypeId(L, typeof(Net.NetClient.ENetState), out is_first);
				
				if (NetNetClientENetState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Net.NetClient.ENetState));
				    NetNetClientENetState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, NetNetClientENetState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, NetNetClientENetState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Net.NetClient.ENetState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, NetNetClientENetState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Net.NetClient.ENetState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != NetNetClientENetState_TypeID)
				{
				    throw new Exception("invalid userdata for Net.NetClient.ENetState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Net.NetClient.ENetState");
                }
				val = (Net.NetClient.ENetState)e;
                
            }
            else
            {
                val = (Net.NetClient.ENetState)objectCasters.GetCaster(typeof(Net.NetClient.ENetState))(L, index, null);
            }
        }
		
        public void UpdateNetNetClientENetState(RealStatePtr L, int index, Net.NetClient.ENetState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != NetNetClientENetState_TypeID)
				{
				    throw new Exception("invalid userdata for Net.NetClient.ENetState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Net.NetClient.ENetState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcObjCachePoolType_TypeID = -1;
		int xcObjCachePoolType_EnumRef = -1;
        
        public void PushxcObjCachePoolType(RealStatePtr L, xc.ObjCachePoolType val)
        {
            if (xcObjCachePoolType_TypeID == -1)
            {
			    bool is_first;
                xcObjCachePoolType_TypeID = getTypeId(L, typeof(xc.ObjCachePoolType), out is_first);
				
				if (xcObjCachePoolType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ObjCachePoolType));
				    xcObjCachePoolType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcObjCachePoolType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcObjCachePoolType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ObjCachePoolType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcObjCachePoolType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ObjCachePoolType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcObjCachePoolType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ObjCachePoolType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ObjCachePoolType");
                }
				val = (xc.ObjCachePoolType)e;
                
            }
            else
            {
                val = (xc.ObjCachePoolType)objectCasters.GetCaster(typeof(xc.ObjCachePoolType))(L, index, null);
            }
        }
		
        public void UpdatexcObjCachePoolType(RealStatePtr L, int index, xc.ObjCachePoolType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcObjCachePoolType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ObjCachePoolType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ObjCachePoolType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcPlayerFollowRecordSceneId_TypeID = -1;
		int xcPlayerFollowRecordSceneId_EnumRef = -1;
        
        public void PushxcPlayerFollowRecordSceneId(RealStatePtr L, xc.PlayerFollowRecordSceneId val)
        {
            if (xcPlayerFollowRecordSceneId_TypeID == -1)
            {
			    bool is_first;
                xcPlayerFollowRecordSceneId_TypeID = getTypeId(L, typeof(xc.PlayerFollowRecordSceneId), out is_first);
				
				if (xcPlayerFollowRecordSceneId_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.PlayerFollowRecordSceneId));
				    xcPlayerFollowRecordSceneId_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcPlayerFollowRecordSceneId_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcPlayerFollowRecordSceneId_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.PlayerFollowRecordSceneId ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcPlayerFollowRecordSceneId_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.PlayerFollowRecordSceneId val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcPlayerFollowRecordSceneId_TypeID)
				{
				    throw new Exception("invalid userdata for xc.PlayerFollowRecordSceneId");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.PlayerFollowRecordSceneId");
                }
				val = (xc.PlayerFollowRecordSceneId)e;
                
            }
            else
            {
                val = (xc.PlayerFollowRecordSceneId)objectCasters.GetCaster(typeof(xc.PlayerFollowRecordSceneId))(L, index, null);
            }
        }
		
        public void UpdatexcPlayerFollowRecordSceneId(RealStatePtr L, int index, xc.PlayerFollowRecordSceneId val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcPlayerFollowRecordSceneId_TypeID)
				{
				    throw new Exception("invalid userdata for xc.PlayerFollowRecordSceneId");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.PlayerFollowRecordSceneId ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcClientEvent_TypeID = -1;
		int xcClientEvent_EnumRef = -1;
        
        public void PushxcClientEvent(RealStatePtr L, xc.ClientEvent val)
        {
            if (xcClientEvent_TypeID == -1)
            {
			    bool is_first;
                xcClientEvent_TypeID = getTypeId(L, typeof(xc.ClientEvent), out is_first);
				
				if (xcClientEvent_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ClientEvent));
				    xcClientEvent_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcClientEvent_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcClientEvent_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ClientEvent ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcClientEvent_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ClientEvent val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcClientEvent_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ClientEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ClientEvent");
                }
				val = (xc.ClientEvent)e;
                
            }
            else
            {
                val = (xc.ClientEvent)objectCasters.GetCaster(typeof(xc.ClientEvent))(L, index, null);
            }
        }
		
        public void UpdatexcClientEvent(RealStatePtr L, int index, xc.ClientEvent val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcClientEvent_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ClientEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ClientEvent ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int CameraControlEMode_TypeID = -1;
		int CameraControlEMode_EnumRef = -1;
        
        public void PushCameraControlEMode(RealStatePtr L, CameraControl.EMode val)
        {
            if (CameraControlEMode_TypeID == -1)
            {
			    bool is_first;
                CameraControlEMode_TypeID = getTypeId(L, typeof(CameraControl.EMode), out is_first);
				
				if (CameraControlEMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(CameraControl.EMode));
				    CameraControlEMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, CameraControlEMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, CameraControlEMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for CameraControl.EMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, CameraControlEMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out CameraControl.EMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != CameraControlEMode_TypeID)
				{
				    throw new Exception("invalid userdata for CameraControl.EMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for CameraControl.EMode");
                }
				val = (CameraControl.EMode)e;
                
            }
            else
            {
                val = (CameraControl.EMode)objectCasters.GetCaster(typeof(CameraControl.EMode))(L, index, null);
            }
        }
		
        public void UpdateCameraControlEMode(RealStatePtr L, int index, CameraControl.EMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != CameraControlEMode_TypeID)
				{
				    throw new Exception("invalid userdata for CameraControl.EMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for CameraControl.EMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBManagerCommandTag_TypeID = -1;
		int xcDBManagerCommandTag_EnumRef = -1;
        
        public void PushxcDBManagerCommandTag(RealStatePtr L, xc.DBManager.CommandTag val)
        {
            if (xcDBManagerCommandTag_TypeID == -1)
            {
			    bool is_first;
                xcDBManagerCommandTag_TypeID = getTypeId(L, typeof(xc.DBManager.CommandTag), out is_first);
				
				if (xcDBManagerCommandTag_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBManager.CommandTag));
				    xcDBManagerCommandTag_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBManagerCommandTag_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBManagerCommandTag_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBManager.CommandTag ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBManagerCommandTag_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBManager.CommandTag val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBManagerCommandTag_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBManager.CommandTag");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBManager.CommandTag");
                }
				val = (xc.DBManager.CommandTag)e;
                
            }
            else
            {
                val = (xc.DBManager.CommandTag)objectCasters.GetCaster(typeof(xc.DBManager.CommandTag))(L, index, null);
            }
        }
		
        public void UpdatexcDBManagerCommandTag(RealStatePtr L, int index, xc.DBManager.CommandTag val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBManagerCommandTag_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBManager.CommandTag");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBManager.CommandTag ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBNoticeEFillType_TypeID = -1;
		int xcDBNoticeEFillType_EnumRef = -1;
        
        public void PushxcDBNoticeEFillType(RealStatePtr L, xc.DBNotice.EFillType val)
        {
            if (xcDBNoticeEFillType_TypeID == -1)
            {
			    bool is_first;
                xcDBNoticeEFillType_TypeID = getTypeId(L, typeof(xc.DBNotice.EFillType), out is_first);
				
				if (xcDBNoticeEFillType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBNotice.EFillType));
				    xcDBNoticeEFillType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBNoticeEFillType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBNoticeEFillType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBNotice.EFillType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBNoticeEFillType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBNotice.EFillType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBNoticeEFillType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBNotice.EFillType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBNotice.EFillType");
                }
				val = (xc.DBNotice.EFillType)e;
                
            }
            else
            {
                val = (xc.DBNotice.EFillType)objectCasters.GetCaster(typeof(xc.DBNotice.EFillType))(L, index, null);
            }
        }
		
        public void UpdatexcDBNoticeEFillType(RealStatePtr L, int index, xc.DBNotice.EFillType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBNoticeEFillType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBNotice.EFillType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBNotice.EFillType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBDataAllSkillSET_SLOT_TYPE_TypeID = -1;
		int xcDBDataAllSkillSET_SLOT_TYPE_EnumRef = -1;
        
        public void PushxcDBDataAllSkillSET_SLOT_TYPE(RealStatePtr L, xc.DBDataAllSkill.SET_SLOT_TYPE val)
        {
            if (xcDBDataAllSkillSET_SLOT_TYPE_TypeID == -1)
            {
			    bool is_first;
                xcDBDataAllSkillSET_SLOT_TYPE_TypeID = getTypeId(L, typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), out is_first);
				
				if (xcDBDataAllSkillSET_SLOT_TYPE_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBDataAllSkill.SET_SLOT_TYPE));
				    xcDBDataAllSkillSET_SLOT_TYPE_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBDataAllSkillSET_SLOT_TYPE_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBDataAllSkillSET_SLOT_TYPE_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBDataAllSkill.SET_SLOT_TYPE ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBDataAllSkillSET_SLOT_TYPE_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBDataAllSkill.SET_SLOT_TYPE val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBDataAllSkillSET_SLOT_TYPE_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBDataAllSkill.SET_SLOT_TYPE");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBDataAllSkill.SET_SLOT_TYPE");
                }
				val = (xc.DBDataAllSkill.SET_SLOT_TYPE)e;
                
            }
            else
            {
                val = (xc.DBDataAllSkill.SET_SLOT_TYPE)objectCasters.GetCaster(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE))(L, index, null);
            }
        }
		
        public void UpdatexcDBDataAllSkillSET_SLOT_TYPE(RealStatePtr L, int index, xc.DBDataAllSkill.SET_SLOT_TYPE val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBDataAllSkillSET_SLOT_TYPE_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBDataAllSkill.SET_SLOT_TYPE");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBDataAllSkill.SET_SLOT_TYPE ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBDataAllSkillSKILL_TYPE_TypeID = -1;
		int xcDBDataAllSkillSKILL_TYPE_EnumRef = -1;
        
        public void PushxcDBDataAllSkillSKILL_TYPE(RealStatePtr L, xc.DBDataAllSkill.SKILL_TYPE val)
        {
            if (xcDBDataAllSkillSKILL_TYPE_TypeID == -1)
            {
			    bool is_first;
                xcDBDataAllSkillSKILL_TYPE_TypeID = getTypeId(L, typeof(xc.DBDataAllSkill.SKILL_TYPE), out is_first);
				
				if (xcDBDataAllSkillSKILL_TYPE_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBDataAllSkill.SKILL_TYPE));
				    xcDBDataAllSkillSKILL_TYPE_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBDataAllSkillSKILL_TYPE_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBDataAllSkillSKILL_TYPE_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBDataAllSkill.SKILL_TYPE ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBDataAllSkillSKILL_TYPE_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBDataAllSkill.SKILL_TYPE val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBDataAllSkillSKILL_TYPE_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBDataAllSkill.SKILL_TYPE");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBDataAllSkill.SKILL_TYPE");
                }
				val = (xc.DBDataAllSkill.SKILL_TYPE)e;
                
            }
            else
            {
                val = (xc.DBDataAllSkill.SKILL_TYPE)objectCasters.GetCaster(typeof(xc.DBDataAllSkill.SKILL_TYPE))(L, index, null);
            }
        }
		
        public void UpdatexcDBDataAllSkillSKILL_TYPE(RealStatePtr L, int index, xc.DBDataAllSkill.SKILL_TYPE val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBDataAllSkillSKILL_TYPE_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBDataAllSkill.SKILL_TYPE");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBDataAllSkill.SKILL_TYPE ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DBBuffSevBindPos_TypeID = -1;
		int DBBuffSevBindPos_EnumRef = -1;
        
        public void PushDBBuffSevBindPos(RealStatePtr L, DBBuffSev.BindPos val)
        {
            if (DBBuffSevBindPos_TypeID == -1)
            {
			    bool is_first;
                DBBuffSevBindPos_TypeID = getTypeId(L, typeof(DBBuffSev.BindPos), out is_first);
				
				if (DBBuffSevBindPos_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(DBBuffSev.BindPos));
				    DBBuffSevBindPos_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DBBuffSevBindPos_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DBBuffSevBindPos_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DBBuffSev.BindPos ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DBBuffSevBindPos_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DBBuffSev.BindPos val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DBBuffSevBindPos_TypeID)
				{
				    throw new Exception("invalid userdata for DBBuffSev.BindPos");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DBBuffSev.BindPos");
                }
				val = (DBBuffSev.BindPos)e;
                
            }
            else
            {
                val = (DBBuffSev.BindPos)objectCasters.GetCaster(typeof(DBBuffSev.BindPos))(L, index, null);
            }
        }
		
        public void UpdateDBBuffSevBindPos(RealStatePtr L, int index, DBBuffSev.BindPos val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DBBuffSevBindPos_TypeID)
				{
				    throw new Exception("invalid userdata for DBBuffSev.BindPos");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DBBuffSev.BindPos ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBGrowSkinSkinUnLockType_TypeID = -1;
		int xcDBGrowSkinSkinUnLockType_EnumRef = -1;
        
        public void PushxcDBGrowSkinSkinUnLockType(RealStatePtr L, xc.DBGrowSkin.SkinUnLockType val)
        {
            if (xcDBGrowSkinSkinUnLockType_TypeID == -1)
            {
			    bool is_first;
                xcDBGrowSkinSkinUnLockType_TypeID = getTypeId(L, typeof(xc.DBGrowSkin.SkinUnLockType), out is_first);
				
				if (xcDBGrowSkinSkinUnLockType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBGrowSkin.SkinUnLockType));
				    xcDBGrowSkinSkinUnLockType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBGrowSkinSkinUnLockType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBGrowSkinSkinUnLockType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBGrowSkin.SkinUnLockType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBGrowSkinSkinUnLockType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBGrowSkin.SkinUnLockType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBGrowSkinSkinUnLockType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBGrowSkin.SkinUnLockType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBGrowSkin.SkinUnLockType");
                }
				val = (xc.DBGrowSkin.SkinUnLockType)e;
                
            }
            else
            {
                val = (xc.DBGrowSkin.SkinUnLockType)objectCasters.GetCaster(typeof(xc.DBGrowSkin.SkinUnLockType))(L, index, null);
            }
        }
		
        public void UpdatexcDBGrowSkinSkinUnLockType(RealStatePtr L, int index, xc.DBGrowSkin.SkinUnLockType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBGrowSkinSkinUnLockType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBGrowSkin.SkinUnLockType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBGrowSkin.SkinUnLockType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBAvatarPartBODY_PART_TypeID = -1;
		int xcDBAvatarPartBODY_PART_EnumRef = -1;
        
        public void PushxcDBAvatarPartBODY_PART(RealStatePtr L, xc.DBAvatarPart.BODY_PART val)
        {
            if (xcDBAvatarPartBODY_PART_TypeID == -1)
            {
			    bool is_first;
                xcDBAvatarPartBODY_PART_TypeID = getTypeId(L, typeof(xc.DBAvatarPart.BODY_PART), out is_first);
				
				if (xcDBAvatarPartBODY_PART_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBAvatarPart.BODY_PART));
				    xcDBAvatarPartBODY_PART_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBAvatarPartBODY_PART_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBAvatarPartBODY_PART_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBAvatarPart.BODY_PART ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBAvatarPartBODY_PART_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBAvatarPart.BODY_PART val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBAvatarPartBODY_PART_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBAvatarPart.BODY_PART");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBAvatarPart.BODY_PART");
                }
				val = (xc.DBAvatarPart.BODY_PART)e;
                
            }
            else
            {
                val = (xc.DBAvatarPart.BODY_PART)objectCasters.GetCaster(typeof(xc.DBAvatarPart.BODY_PART))(L, index, null);
            }
        }
		
        public void UpdatexcDBAvatarPartBODY_PART(RealStatePtr L, int index, xc.DBAvatarPart.BODY_PART val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBAvatarPartBODY_PART_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBAvatarPart.BODY_PART");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBAvatarPart.BODY_PART ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBPetPetUnLockType_TypeID = -1;
		int xcDBPetPetUnLockType_EnumRef = -1;
        
        public void PushxcDBPetPetUnLockType(RealStatePtr L, xc.DBPet.PetUnLockType val)
        {
            if (xcDBPetPetUnLockType_TypeID == -1)
            {
			    bool is_first;
                xcDBPetPetUnLockType_TypeID = getTypeId(L, typeof(xc.DBPet.PetUnLockType), out is_first);
				
				if (xcDBPetPetUnLockType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBPet.PetUnLockType));
				    xcDBPetPetUnLockType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBPetPetUnLockType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBPetPetUnLockType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBPet.PetUnLockType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBPetPetUnLockType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBPet.PetUnLockType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBPetPetUnLockType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBPet.PetUnLockType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBPet.PetUnLockType");
                }
				val = (xc.DBPet.PetUnLockType)e;
                
            }
            else
            {
                val = (xc.DBPet.PetUnLockType)objectCasters.GetCaster(typeof(xc.DBPet.PetUnLockType))(L, index, null);
            }
        }
		
        public void UpdatexcDBPetPetUnLockType(RealStatePtr L, int index, xc.DBPet.PetUnLockType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBPetPetUnLockType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBPet.PetUnLockType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBPet.PetUnLockType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBSysConfigESysBtnFixType_TypeID = -1;
		int xcDBSysConfigESysBtnFixType_EnumRef = -1;
        
        public void PushxcDBSysConfigESysBtnFixType(RealStatePtr L, xc.DBSysConfig.ESysBtnFixType val)
        {
            if (xcDBSysConfigESysBtnFixType_TypeID == -1)
            {
			    bool is_first;
                xcDBSysConfigESysBtnFixType_TypeID = getTypeId(L, typeof(xc.DBSysConfig.ESysBtnFixType), out is_first);
				
				if (xcDBSysConfigESysBtnFixType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBSysConfig.ESysBtnFixType));
				    xcDBSysConfigESysBtnFixType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBSysConfigESysBtnFixType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBSysConfigESysBtnFixType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBSysConfig.ESysBtnFixType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBSysConfigESysBtnFixType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBSysConfig.ESysBtnFixType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysBtnFixType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysBtnFixType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBSysConfig.ESysBtnFixType");
                }
				val = (xc.DBSysConfig.ESysBtnFixType)e;
                
            }
            else
            {
                val = (xc.DBSysConfig.ESysBtnFixType)objectCasters.GetCaster(typeof(xc.DBSysConfig.ESysBtnFixType))(L, index, null);
            }
        }
		
        public void UpdatexcDBSysConfigESysBtnFixType(RealStatePtr L, int index, xc.DBSysConfig.ESysBtnFixType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysBtnFixType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysBtnFixType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBSysConfig.ESysBtnFixType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBSysConfigESysBtnPos_TypeID = -1;
		int xcDBSysConfigESysBtnPos_EnumRef = -1;
        
        public void PushxcDBSysConfigESysBtnPos(RealStatePtr L, xc.DBSysConfig.ESysBtnPos val)
        {
            if (xcDBSysConfigESysBtnPos_TypeID == -1)
            {
			    bool is_first;
                xcDBSysConfigESysBtnPos_TypeID = getTypeId(L, typeof(xc.DBSysConfig.ESysBtnPos), out is_first);
				
				if (xcDBSysConfigESysBtnPos_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBSysConfig.ESysBtnPos));
				    xcDBSysConfigESysBtnPos_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBSysConfigESysBtnPos_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBSysConfigESysBtnPos_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBSysConfig.ESysBtnPos ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBSysConfigESysBtnPos_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBSysConfig.ESysBtnPos val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysBtnPos_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysBtnPos");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBSysConfig.ESysBtnPos");
                }
				val = (xc.DBSysConfig.ESysBtnPos)e;
                
            }
            else
            {
                val = (xc.DBSysConfig.ESysBtnPos)objectCasters.GetCaster(typeof(xc.DBSysConfig.ESysBtnPos))(L, index, null);
            }
        }
		
        public void UpdatexcDBSysConfigESysBtnPos(RealStatePtr L, int index, xc.DBSysConfig.ESysBtnPos val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysBtnPos_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysBtnPos");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBSysConfig.ESysBtnPos ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBSysConfigESysTaskType_TypeID = -1;
		int xcDBSysConfigESysTaskType_EnumRef = -1;
        
        public void PushxcDBSysConfigESysTaskType(RealStatePtr L, xc.DBSysConfig.ESysTaskType val)
        {
            if (xcDBSysConfigESysTaskType_TypeID == -1)
            {
			    bool is_first;
                xcDBSysConfigESysTaskType_TypeID = getTypeId(L, typeof(xc.DBSysConfig.ESysTaskType), out is_first);
				
				if (xcDBSysConfigESysTaskType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBSysConfig.ESysTaskType));
				    xcDBSysConfigESysTaskType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBSysConfigESysTaskType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBSysConfigESysTaskType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBSysConfig.ESysTaskType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBSysConfigESysTaskType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBSysConfig.ESysTaskType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysTaskType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysTaskType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBSysConfig.ESysTaskType");
                }
				val = (xc.DBSysConfig.ESysTaskType)e;
                
            }
            else
            {
                val = (xc.DBSysConfig.ESysTaskType)objectCasters.GetCaster(typeof(xc.DBSysConfig.ESysTaskType))(L, index, null);
            }
        }
		
        public void UpdatexcDBSysConfigESysTaskType(RealStatePtr L, int index, xc.DBSysConfig.ESysTaskType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBSysConfigESysTaskType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBSysConfig.ESysTaskType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBSysConfig.ESysTaskType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcDBEquipPosEquipPosType_TypeID = -1;
		int xcDBEquipPosEquipPosType_EnumRef = -1;
        
        public void PushxcDBEquipPosEquipPosType(RealStatePtr L, xc.DBEquipPos.EquipPosType val)
        {
            if (xcDBEquipPosEquipPosType_TypeID == -1)
            {
			    bool is_first;
                xcDBEquipPosEquipPosType_TypeID = getTypeId(L, typeof(xc.DBEquipPos.EquipPosType), out is_first);
				
				if (xcDBEquipPosEquipPosType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.DBEquipPos.EquipPosType));
				    xcDBEquipPosEquipPosType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcDBEquipPosEquipPosType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcDBEquipPosEquipPosType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.DBEquipPos.EquipPosType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcDBEquipPosEquipPosType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.DBEquipPos.EquipPosType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBEquipPosEquipPosType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBEquipPos.EquipPosType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.DBEquipPos.EquipPosType");
                }
				val = (xc.DBEquipPos.EquipPosType)e;
                
            }
            else
            {
                val = (xc.DBEquipPos.EquipPosType)objectCasters.GetCaster(typeof(xc.DBEquipPos.EquipPosType))(L, index, null);
            }
        }
		
        public void UpdatexcDBEquipPosEquipPosType(RealStatePtr L, int index, xc.DBEquipPos.EquipPosType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcDBEquipPosEquipPosType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.DBEquipPos.EquipPosType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.DBEquipPos.EquipPosType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcBuffBuffFlags_TypeID = -1;
		int xcBuffBuffFlags_EnumRef = -1;
        
        public void PushxcBuffBuffFlags(RealStatePtr L, xc.Buff.BuffFlags val)
        {
            if (xcBuffBuffFlags_TypeID == -1)
            {
			    bool is_first;
                xcBuffBuffFlags_TypeID = getTypeId(L, typeof(xc.Buff.BuffFlags), out is_first);
				
				if (xcBuffBuffFlags_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.Buff.BuffFlags));
				    xcBuffBuffFlags_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcBuffBuffFlags_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcBuffBuffFlags_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.Buff.BuffFlags ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcBuffBuffFlags_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.Buff.BuffFlags val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcBuffBuffFlags_TypeID)
				{
				    throw new Exception("invalid userdata for xc.Buff.BuffFlags");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.Buff.BuffFlags");
                }
				val = (xc.Buff.BuffFlags)e;
                
            }
            else
            {
                val = (xc.Buff.BuffFlags)objectCasters.GetCaster(typeof(xc.Buff.BuffFlags))(L, index, null);
            }
        }
		
        public void UpdatexcBuffBuffFlags(RealStatePtr L, int index, xc.Buff.BuffFlags val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcBuffBuffFlags_TypeID)
				{
				    throw new Exception("invalid userdata for xc.Buff.BuffFlags");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.Buff.BuffFlags ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcRockCommandSystemClickRockButtonTipsType_TypeID = -1;
		int xcRockCommandSystemClickRockButtonTipsType_EnumRef = -1;
        
        public void PushxcRockCommandSystemClickRockButtonTipsType(RealStatePtr L, xc.RockCommandSystem.ClickRockButtonTipsType val)
        {
            if (xcRockCommandSystemClickRockButtonTipsType_TypeID == -1)
            {
			    bool is_first;
                xcRockCommandSystemClickRockButtonTipsType_TypeID = getTypeId(L, typeof(xc.RockCommandSystem.ClickRockButtonTipsType), out is_first);
				
				if (xcRockCommandSystemClickRockButtonTipsType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.RockCommandSystem.ClickRockButtonTipsType));
				    xcRockCommandSystemClickRockButtonTipsType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcRockCommandSystemClickRockButtonTipsType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcRockCommandSystemClickRockButtonTipsType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.RockCommandSystem.ClickRockButtonTipsType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcRockCommandSystemClickRockButtonTipsType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.RockCommandSystem.ClickRockButtonTipsType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcRockCommandSystemClickRockButtonTipsType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.RockCommandSystem.ClickRockButtonTipsType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.RockCommandSystem.ClickRockButtonTipsType");
                }
				val = (xc.RockCommandSystem.ClickRockButtonTipsType)e;
                
            }
            else
            {
                val = (xc.RockCommandSystem.ClickRockButtonTipsType)objectCasters.GetCaster(typeof(xc.RockCommandSystem.ClickRockButtonTipsType))(L, index, null);
            }
        }
		
        public void UpdatexcRockCommandSystemClickRockButtonTipsType(RealStatePtr L, int index, xc.RockCommandSystem.ClickRockButtonTipsType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcRockCommandSystemClickRockButtonTipsType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.RockCommandSystem.ClickRockButtonTipsType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.RockCommandSystem.ClickRockButtonTipsType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorEHeadIcon_TypeID = -1;
		int ActorEHeadIcon_EnumRef = -1;
        
        public void PushActorEHeadIcon(RealStatePtr L, Actor.EHeadIcon val)
        {
            if (ActorEHeadIcon_TypeID == -1)
            {
			    bool is_first;
                ActorEHeadIcon_TypeID = getTypeId(L, typeof(Actor.EHeadIcon), out is_first);
				
				if (ActorEHeadIcon_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.EHeadIcon));
				    ActorEHeadIcon_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorEHeadIcon_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorEHeadIcon_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.EHeadIcon ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorEHeadIcon_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.EHeadIcon val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEHeadIcon_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EHeadIcon");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.EHeadIcon");
                }
				val = (Actor.EHeadIcon)e;
                
            }
            else
            {
                val = (Actor.EHeadIcon)objectCasters.GetCaster(typeof(Actor.EHeadIcon))(L, index, null);
            }
        }
		
        public void UpdateActorEHeadIcon(RealStatePtr L, int index, Actor.EHeadIcon val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEHeadIcon_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EHeadIcon");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.EHeadIcon ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorEVocationType_TypeID = -1;
		int ActorEVocationType_EnumRef = -1;
        
        public void PushActorEVocationType(RealStatePtr L, Actor.EVocationType val)
        {
            if (ActorEVocationType_TypeID == -1)
            {
			    bool is_first;
                ActorEVocationType_TypeID = getTypeId(L, typeof(Actor.EVocationType), out is_first);
				
				if (ActorEVocationType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.EVocationType));
				    ActorEVocationType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorEVocationType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorEVocationType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.EVocationType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorEVocationType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.EVocationType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEVocationType_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EVocationType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.EVocationType");
                }
				val = (Actor.EVocationType)e;
                
            }
            else
            {
                val = (Actor.EVocationType)objectCasters.GetCaster(typeof(Actor.EVocationType))(L, index, null);
            }
        }
		
        public void UpdateActorEVocationType(RealStatePtr L, int index, Actor.EVocationType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEVocationType_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EVocationType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.EVocationType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorActorEvent_TypeID = -1;
		int ActorActorEvent_EnumRef = -1;
        
        public void PushActorActorEvent(RealStatePtr L, Actor.ActorEvent val)
        {
            if (ActorActorEvent_TypeID == -1)
            {
			    bool is_first;
                ActorActorEvent_TypeID = getTypeId(L, typeof(Actor.ActorEvent), out is_first);
				
				if (ActorActorEvent_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.ActorEvent));
				    ActorActorEvent_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorActorEvent_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorActorEvent_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.ActorEvent ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorActorEvent_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.ActorEvent val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorActorEvent_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.ActorEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.ActorEvent");
                }
				val = (Actor.ActorEvent)e;
                
            }
            else
            {
                val = (Actor.ActorEvent)objectCasters.GetCaster(typeof(Actor.ActorEvent))(L, index, null);
            }
        }
		
        public void UpdateActorActorEvent(RealStatePtr L, int index, Actor.ActorEvent val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorActorEvent_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.ActorEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.ActorEvent ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorEAnimation_TypeID = -1;
		int ActorEAnimation_EnumRef = -1;
        
        public void PushActorEAnimation(RealStatePtr L, Actor.EAnimation val)
        {
            if (ActorEAnimation_TypeID == -1)
            {
			    bool is_first;
                ActorEAnimation_TypeID = getTypeId(L, typeof(Actor.EAnimation), out is_first);
				
				if (ActorEAnimation_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.EAnimation));
				    ActorEAnimation_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorEAnimation_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorEAnimation_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.EAnimation ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorEAnimation_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.EAnimation val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEAnimation_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EAnimation");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.EAnimation");
                }
				val = (Actor.EAnimation)e;
                
            }
            else
            {
                val = (Actor.EAnimation)objectCasters.GetCaster(typeof(Actor.EAnimation))(L, index, null);
            }
        }
		
        public void UpdateActorEAnimation(RealStatePtr L, int index, Actor.EAnimation val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEAnimation_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EAnimation");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.EAnimation ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorSlotBoneNameType_TypeID = -1;
		int ActorSlotBoneNameType_EnumRef = -1;
        
        public void PushActorSlotBoneNameType(RealStatePtr L, Actor.SlotBoneNameType val)
        {
            if (ActorSlotBoneNameType_TypeID == -1)
            {
			    bool is_first;
                ActorSlotBoneNameType_TypeID = getTypeId(L, typeof(Actor.SlotBoneNameType), out is_first);
				
				if (ActorSlotBoneNameType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.SlotBoneNameType));
				    ActorSlotBoneNameType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorSlotBoneNameType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorSlotBoneNameType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.SlotBoneNameType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorSlotBoneNameType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.SlotBoneNameType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorSlotBoneNameType_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.SlotBoneNameType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.SlotBoneNameType");
                }
				val = (Actor.SlotBoneNameType)e;
                
            }
            else
            {
                val = (Actor.SlotBoneNameType)objectCasters.GetCaster(typeof(Actor.SlotBoneNameType))(L, index, null);
            }
        }
		
        public void UpdateActorSlotBoneNameType(RealStatePtr L, int index, Actor.SlotBoneNameType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorSlotBoneNameType_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.SlotBoneNameType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.SlotBoneNameType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int ActorEWildState_TypeID = -1;
		int ActorEWildState_EnumRef = -1;
        
        public void PushActorEWildState(RealStatePtr L, Actor.EWildState val)
        {
            if (ActorEWildState_TypeID == -1)
            {
			    bool is_first;
                ActorEWildState_TypeID = getTypeId(L, typeof(Actor.EWildState), out is_first);
				
				if (ActorEWildState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Actor.EWildState));
				    ActorEWildState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, ActorEWildState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, ActorEWildState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Actor.EWildState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, ActorEWildState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Actor.EWildState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEWildState_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EWildState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Actor.EWildState");
                }
				val = (Actor.EWildState)e;
                
            }
            else
            {
                val = (Actor.EWildState)objectCasters.GetCaster(typeof(Actor.EWildState))(L, index, null);
            }
        }
		
        public void UpdateActorEWildState(RealStatePtr L, int index, Actor.EWildState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != ActorEWildState_TypeID)
				{
				    throw new Exception("invalid userdata for Actor.EWildState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Actor.EWildState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MonsterMonsterSpawnType_TypeID = -1;
		int MonsterMonsterSpawnType_EnumRef = -1;
        
        public void PushMonsterMonsterSpawnType(RealStatePtr L, Monster.MonsterSpawnType val)
        {
            if (MonsterMonsterSpawnType_TypeID == -1)
            {
			    bool is_first;
                MonsterMonsterSpawnType_TypeID = getTypeId(L, typeof(Monster.MonsterSpawnType), out is_first);
				
				if (MonsterMonsterSpawnType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Monster.MonsterSpawnType));
				    MonsterMonsterSpawnType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MonsterMonsterSpawnType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MonsterMonsterSpawnType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Monster.MonsterSpawnType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MonsterMonsterSpawnType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Monster.MonsterSpawnType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterMonsterSpawnType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.MonsterSpawnType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Monster.MonsterSpawnType");
                }
				val = (Monster.MonsterSpawnType)e;
                
            }
            else
            {
                val = (Monster.MonsterSpawnType)objectCasters.GetCaster(typeof(Monster.MonsterSpawnType))(L, index, null);
            }
        }
		
        public void UpdateMonsterMonsterSpawnType(RealStatePtr L, int index, Monster.MonsterSpawnType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterMonsterSpawnType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.MonsterSpawnType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Monster.MonsterSpawnType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MonsterMonsterType_TypeID = -1;
		int MonsterMonsterType_EnumRef = -1;
        
        public void PushMonsterMonsterType(RealStatePtr L, Monster.MonsterType val)
        {
            if (MonsterMonsterType_TypeID == -1)
            {
			    bool is_first;
                MonsterMonsterType_TypeID = getTypeId(L, typeof(Monster.MonsterType), out is_first);
				
				if (MonsterMonsterType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Monster.MonsterType));
				    MonsterMonsterType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MonsterMonsterType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MonsterMonsterType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Monster.MonsterType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MonsterMonsterType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Monster.MonsterType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterMonsterType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.MonsterType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Monster.MonsterType");
                }
				val = (Monster.MonsterType)e;
                
            }
            else
            {
                val = (Monster.MonsterType)objectCasters.GetCaster(typeof(Monster.MonsterType))(L, index, null);
            }
        }
		
        public void UpdateMonsterMonsterType(RealStatePtr L, int index, Monster.MonsterType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterMonsterType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.MonsterType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Monster.MonsterType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MonsterBeSummonType_TypeID = -1;
		int MonsterBeSummonType_EnumRef = -1;
        
        public void PushMonsterBeSummonType(RealStatePtr L, Monster.BeSummonType val)
        {
            if (MonsterBeSummonType_TypeID == -1)
            {
			    bool is_first;
                MonsterBeSummonType_TypeID = getTypeId(L, typeof(Monster.BeSummonType), out is_first);
				
				if (MonsterBeSummonType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Monster.BeSummonType));
				    MonsterBeSummonType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MonsterBeSummonType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MonsterBeSummonType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Monster.BeSummonType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MonsterBeSummonType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Monster.BeSummonType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterBeSummonType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.BeSummonType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Monster.BeSummonType");
                }
				val = (Monster.BeSummonType)e;
                
            }
            else
            {
                val = (Monster.BeSummonType)objectCasters.GetCaster(typeof(Monster.BeSummonType))(L, index, null);
            }
        }
		
        public void UpdateMonsterBeSummonType(RealStatePtr L, int index, Monster.BeSummonType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterBeSummonType_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.BeSummonType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Monster.BeSummonType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MonsterQualityColor_TypeID = -1;
		int MonsterQualityColor_EnumRef = -1;
        
        public void PushMonsterQualityColor(RealStatePtr L, Monster.QualityColor val)
        {
            if (MonsterQualityColor_TypeID == -1)
            {
			    bool is_first;
                MonsterQualityColor_TypeID = getTypeId(L, typeof(Monster.QualityColor), out is_first);
				
				if (MonsterQualityColor_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(Monster.QualityColor));
				    MonsterQualityColor_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MonsterQualityColor_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MonsterQualityColor_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Monster.QualityColor ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MonsterQualityColor_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Monster.QualityColor val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterQualityColor_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.QualityColor");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Monster.QualityColor");
                }
				val = (Monster.QualityColor)e;
                
            }
            else
            {
                val = (Monster.QualityColor)objectCasters.GetCaster(typeof(Monster.QualityColor))(L, index, null);
            }
        }
		
        public void UpdateMonsterQualityColor(RealStatePtr L, int index, Monster.QualityColor val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MonsterQualityColor_TypeID)
				{
				    throw new Exception("invalid userdata for Monster.QualityColor");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Monster.QualityColor ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcMoveCtrlEActorStepType_TypeID = -1;
		int xcMoveCtrlEActorStepType_EnumRef = -1;
        
        public void PushxcMoveCtrlEActorStepType(RealStatePtr L, xc.MoveCtrl.EActorStepType val)
        {
            if (xcMoveCtrlEActorStepType_TypeID == -1)
            {
			    bool is_first;
                xcMoveCtrlEActorStepType_TypeID = getTypeId(L, typeof(xc.MoveCtrl.EActorStepType), out is_first);
				
				if (xcMoveCtrlEActorStepType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.MoveCtrl.EActorStepType));
				    xcMoveCtrlEActorStepType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcMoveCtrlEActorStepType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcMoveCtrlEActorStepType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.MoveCtrl.EActorStepType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcMoveCtrlEActorStepType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.MoveCtrl.EActorStepType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcMoveCtrlEActorStepType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.MoveCtrl.EActorStepType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.MoveCtrl.EActorStepType");
                }
				val = (xc.MoveCtrl.EActorStepType)e;
                
            }
            else
            {
                val = (xc.MoveCtrl.EActorStepType)objectCasters.GetCaster(typeof(xc.MoveCtrl.EActorStepType))(L, index, null);
            }
        }
		
        public void UpdatexcMoveCtrlEActorStepType(RealStatePtr L, int index, xc.MoveCtrl.EActorStepType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcMoveCtrlEActorStepType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.MoveCtrl.EActorStepType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.MoveCtrl.EActorStepType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcActorMachineEWalkMode_TypeID = -1;
		int xcActorMachineEWalkMode_EnumRef = -1;
        
        public void PushxcActorMachineEWalkMode(RealStatePtr L, xc.ActorMachine.EWalkMode val)
        {
            if (xcActorMachineEWalkMode_TypeID == -1)
            {
			    bool is_first;
                xcActorMachineEWalkMode_TypeID = getTypeId(L, typeof(xc.ActorMachine.EWalkMode), out is_first);
				
				if (xcActorMachineEWalkMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ActorMachine.EWalkMode));
				    xcActorMachineEWalkMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcActorMachineEWalkMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcActorMachineEWalkMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ActorMachine.EWalkMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcActorMachineEWalkMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ActorMachine.EWalkMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEWalkMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EWalkMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ActorMachine.EWalkMode");
                }
				val = (xc.ActorMachine.EWalkMode)e;
                
            }
            else
            {
                val = (xc.ActorMachine.EWalkMode)objectCasters.GetCaster(typeof(xc.ActorMachine.EWalkMode))(L, index, null);
            }
        }
		
        public void UpdatexcActorMachineEWalkMode(RealStatePtr L, int index, xc.ActorMachine.EWalkMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEWalkMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EWalkMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ActorMachine.EWalkMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcActorMachineEFSMEvent_TypeID = -1;
		int xcActorMachineEFSMEvent_EnumRef = -1;
        
        public void PushxcActorMachineEFSMEvent(RealStatePtr L, xc.ActorMachine.EFSMEvent val)
        {
            if (xcActorMachineEFSMEvent_TypeID == -1)
            {
			    bool is_first;
                xcActorMachineEFSMEvent_TypeID = getTypeId(L, typeof(xc.ActorMachine.EFSMEvent), out is_first);
				
				if (xcActorMachineEFSMEvent_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ActorMachine.EFSMEvent));
				    xcActorMachineEFSMEvent_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcActorMachineEFSMEvent_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcActorMachineEFSMEvent_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ActorMachine.EFSMEvent ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcActorMachineEFSMEvent_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ActorMachine.EFSMEvent val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEFSMEvent_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EFSMEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ActorMachine.EFSMEvent");
                }
				val = (xc.ActorMachine.EFSMEvent)e;
                
            }
            else
            {
                val = (xc.ActorMachine.EFSMEvent)objectCasters.GetCaster(typeof(xc.ActorMachine.EFSMEvent))(L, index, null);
            }
        }
		
        public void UpdatexcActorMachineEFSMEvent(RealStatePtr L, int index, xc.ActorMachine.EFSMEvent val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEFSMEvent_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EFSMEvent");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ActorMachine.EFSMEvent ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcActorMachineEFSMState_TypeID = -1;
		int xcActorMachineEFSMState_EnumRef = -1;
        
        public void PushxcActorMachineEFSMState(RealStatePtr L, xc.ActorMachine.EFSMState val)
        {
            if (xcActorMachineEFSMState_TypeID == -1)
            {
			    bool is_first;
                xcActorMachineEFSMState_TypeID = getTypeId(L, typeof(xc.ActorMachine.EFSMState), out is_first);
				
				if (xcActorMachineEFSMState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ActorMachine.EFSMState));
				    xcActorMachineEFSMState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcActorMachineEFSMState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcActorMachineEFSMState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ActorMachine.EFSMState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcActorMachineEFSMState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ActorMachine.EFSMState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEFSMState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EFSMState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ActorMachine.EFSMState");
                }
				val = (xc.ActorMachine.EFSMState)e;
                
            }
            else
            {
                val = (xc.ActorMachine.EFSMState)objectCasters.GetCaster(typeof(xc.ActorMachine.EFSMState))(L, index, null);
            }
        }
		
        public void UpdatexcActorMachineEFSMState(RealStatePtr L, int index, xc.ActorMachine.EFSMState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcActorMachineEFSMState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ActorMachine.EFSMState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ActorMachine.EFSMState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcNpcDefineEFunction_TypeID = -1;
		int xcNpcDefineEFunction_EnumRef = -1;
        
        public void PushxcNpcDefineEFunction(RealStatePtr L, xc.NpcDefine.EFunction val)
        {
            if (xcNpcDefineEFunction_TypeID == -1)
            {
			    bool is_first;
                xcNpcDefineEFunction_TypeID = getTypeId(L, typeof(xc.NpcDefine.EFunction), out is_first);
				
				if (xcNpcDefineEFunction_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.NpcDefine.EFunction));
				    xcNpcDefineEFunction_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcNpcDefineEFunction_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcNpcDefineEFunction_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.NpcDefine.EFunction ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcNpcDefineEFunction_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.NpcDefine.EFunction val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcNpcDefineEFunction_TypeID)
				{
				    throw new Exception("invalid userdata for xc.NpcDefine.EFunction");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.NpcDefine.EFunction");
                }
				val = (xc.NpcDefine.EFunction)e;
                
            }
            else
            {
                val = (xc.NpcDefine.EFunction)objectCasters.GetCaster(typeof(xc.NpcDefine.EFunction))(L, index, null);
            }
        }
		
        public void UpdatexcNpcDefineEFunction(RealStatePtr L, int index, xc.NpcDefine.EFunction val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcNpcDefineEFunction_TypeID)
				{
				    throw new Exception("invalid userdata for xc.NpcDefine.EFunction");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.NpcDefine.EFunction ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcNpcDefineELightMode_TypeID = -1;
		int xcNpcDefineELightMode_EnumRef = -1;
        
        public void PushxcNpcDefineELightMode(RealStatePtr L, xc.NpcDefine.ELightMode val)
        {
            if (xcNpcDefineELightMode_TypeID == -1)
            {
			    bool is_first;
                xcNpcDefineELightMode_TypeID = getTypeId(L, typeof(xc.NpcDefine.ELightMode), out is_first);
				
				if (xcNpcDefineELightMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.NpcDefine.ELightMode));
				    xcNpcDefineELightMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcNpcDefineELightMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcNpcDefineELightMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.NpcDefine.ELightMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcNpcDefineELightMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.NpcDefine.ELightMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcNpcDefineELightMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.NpcDefine.ELightMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.NpcDefine.ELightMode");
                }
				val = (xc.NpcDefine.ELightMode)e;
                
            }
            else
            {
                val = (xc.NpcDefine.ELightMode)objectCasters.GetCaster(typeof(xc.NpcDefine.ELightMode))(L, index, null);
            }
        }
		
        public void UpdatexcNpcDefineELightMode(RealStatePtr L, int index, xc.NpcDefine.ELightMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcNpcDefineELightMode_TypeID)
				{
				    throw new Exception("invalid userdata for xc.NpcDefine.ELightMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.NpcDefine.ELightMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIToggleToggleTransition_TypeID = -1;
		int UnityEngineUIToggleToggleTransition_EnumRef = -1;
        
        public void PushUnityEngineUIToggleToggleTransition(RealStatePtr L, UnityEngine.UI.Toggle.ToggleTransition val)
        {
            if (UnityEngineUIToggleToggleTransition_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIToggleToggleTransition_TypeID = getTypeId(L, typeof(UnityEngine.UI.Toggle.ToggleTransition), out is_first);
				
				if (UnityEngineUIToggleToggleTransition_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Toggle.ToggleTransition));
				    UnityEngineUIToggleToggleTransition_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIToggleToggleTransition_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIToggleToggleTransition_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Toggle.ToggleTransition ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIToggleToggleTransition_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Toggle.ToggleTransition val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIToggleToggleTransition_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Toggle.ToggleTransition");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Toggle.ToggleTransition");
                }
				val = (UnityEngine.UI.Toggle.ToggleTransition)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Toggle.ToggleTransition)objectCasters.GetCaster(typeof(UnityEngine.UI.Toggle.ToggleTransition))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIToggleToggleTransition(RealStatePtr L, int index, UnityEngine.UI.Toggle.ToggleTransition val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIToggleToggleTransition_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Toggle.ToggleTransition");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Toggle.ToggleTransition ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUISliderDirection_TypeID = -1;
		int UnityEngineUISliderDirection_EnumRef = -1;
        
        public void PushUnityEngineUISliderDirection(RealStatePtr L, UnityEngine.UI.Slider.Direction val)
        {
            if (UnityEngineUISliderDirection_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUISliderDirection_TypeID = getTypeId(L, typeof(UnityEngine.UI.Slider.Direction), out is_first);
				
				if (UnityEngineUISliderDirection_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Slider.Direction));
				    UnityEngineUISliderDirection_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUISliderDirection_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUISliderDirection_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Slider.Direction ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUISliderDirection_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Slider.Direction val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUISliderDirection_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Slider.Direction");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Slider.Direction");
                }
				val = (UnityEngine.UI.Slider.Direction)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Slider.Direction)objectCasters.GetCaster(typeof(UnityEngine.UI.Slider.Direction))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUISliderDirection(RealStatePtr L, int index, UnityEngine.UI.Slider.Direction val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUISliderDirection_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Slider.Direction");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Slider.Direction ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageOrigin360_TypeID = -1;
		int UnityEngineUIImageOrigin360_EnumRef = -1;
        
        public void PushUnityEngineUIImageOrigin360(RealStatePtr L, UnityEngine.UI.Image.Origin360 val)
        {
            if (UnityEngineUIImageOrigin360_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageOrigin360_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.Origin360), out is_first);
				
				if (UnityEngineUIImageOrigin360_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.Origin360));
				    UnityEngineUIImageOrigin360_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageOrigin360_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageOrigin360_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.Origin360 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageOrigin360_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.Origin360 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin360_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin360");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.Origin360");
                }
				val = (UnityEngine.UI.Image.Origin360)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.Origin360)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.Origin360))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageOrigin360(RealStatePtr L, int index, UnityEngine.UI.Image.Origin360 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin360_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin360");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.Origin360 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageOrigin180_TypeID = -1;
		int UnityEngineUIImageOrigin180_EnumRef = -1;
        
        public void PushUnityEngineUIImageOrigin180(RealStatePtr L, UnityEngine.UI.Image.Origin180 val)
        {
            if (UnityEngineUIImageOrigin180_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageOrigin180_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.Origin180), out is_first);
				
				if (UnityEngineUIImageOrigin180_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.Origin180));
				    UnityEngineUIImageOrigin180_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageOrigin180_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageOrigin180_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.Origin180 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageOrigin180_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.Origin180 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin180_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin180");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.Origin180");
                }
				val = (UnityEngine.UI.Image.Origin180)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.Origin180)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.Origin180))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageOrigin180(RealStatePtr L, int index, UnityEngine.UI.Image.Origin180 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin180_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin180");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.Origin180 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageOrigin90_TypeID = -1;
		int UnityEngineUIImageOrigin90_EnumRef = -1;
        
        public void PushUnityEngineUIImageOrigin90(RealStatePtr L, UnityEngine.UI.Image.Origin90 val)
        {
            if (UnityEngineUIImageOrigin90_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageOrigin90_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.Origin90), out is_first);
				
				if (UnityEngineUIImageOrigin90_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.Origin90));
				    UnityEngineUIImageOrigin90_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageOrigin90_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageOrigin90_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.Origin90 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageOrigin90_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.Origin90 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin90_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin90");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.Origin90");
                }
				val = (UnityEngine.UI.Image.Origin90)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.Origin90)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.Origin90))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageOrigin90(RealStatePtr L, int index, UnityEngine.UI.Image.Origin90 val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOrigin90_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Origin90");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.Origin90 ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageOriginVertical_TypeID = -1;
		int UnityEngineUIImageOriginVertical_EnumRef = -1;
        
        public void PushUnityEngineUIImageOriginVertical(RealStatePtr L, UnityEngine.UI.Image.OriginVertical val)
        {
            if (UnityEngineUIImageOriginVertical_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageOriginVertical_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.OriginVertical), out is_first);
				
				if (UnityEngineUIImageOriginVertical_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.OriginVertical));
				    UnityEngineUIImageOriginVertical_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageOriginVertical_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageOriginVertical_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.OriginVertical ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageOriginVertical_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.OriginVertical val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOriginVertical_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.OriginVertical");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.OriginVertical");
                }
				val = (UnityEngine.UI.Image.OriginVertical)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.OriginVertical)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.OriginVertical))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageOriginVertical(RealStatePtr L, int index, UnityEngine.UI.Image.OriginVertical val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOriginVertical_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.OriginVertical");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.OriginVertical ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageOriginHorizontal_TypeID = -1;
		int UnityEngineUIImageOriginHorizontal_EnumRef = -1;
        
        public void PushUnityEngineUIImageOriginHorizontal(RealStatePtr L, UnityEngine.UI.Image.OriginHorizontal val)
        {
            if (UnityEngineUIImageOriginHorizontal_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageOriginHorizontal_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.OriginHorizontal), out is_first);
				
				if (UnityEngineUIImageOriginHorizontal_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.OriginHorizontal));
				    UnityEngineUIImageOriginHorizontal_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageOriginHorizontal_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageOriginHorizontal_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.OriginHorizontal ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageOriginHorizontal_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.OriginHorizontal val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOriginHorizontal_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.OriginHorizontal");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.OriginHorizontal");
                }
				val = (UnityEngine.UI.Image.OriginHorizontal)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.OriginHorizontal)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.OriginHorizontal))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageOriginHorizontal(RealStatePtr L, int index, UnityEngine.UI.Image.OriginHorizontal val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageOriginHorizontal_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.OriginHorizontal");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.OriginHorizontal ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageFillMethod_TypeID = -1;
		int UnityEngineUIImageFillMethod_EnumRef = -1;
        
        public void PushUnityEngineUIImageFillMethod(RealStatePtr L, UnityEngine.UI.Image.FillMethod val)
        {
            if (UnityEngineUIImageFillMethod_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageFillMethod_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.FillMethod), out is_first);
				
				if (UnityEngineUIImageFillMethod_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.FillMethod));
				    UnityEngineUIImageFillMethod_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageFillMethod_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageFillMethod_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.FillMethod ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageFillMethod_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.FillMethod val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageFillMethod_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.FillMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.FillMethod");
                }
				val = (UnityEngine.UI.Image.FillMethod)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.FillMethod)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.FillMethod))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageFillMethod(RealStatePtr L, int index, UnityEngine.UI.Image.FillMethod val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageFillMethod_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.FillMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.FillMethod ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIImageType_TypeID = -1;
		int UnityEngineUIImageType_EnumRef = -1;
        
        public void PushUnityEngineUIImageType(RealStatePtr L, UnityEngine.UI.Image.Type val)
        {
            if (UnityEngineUIImageType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIImageType_TypeID = getTypeId(L, typeof(UnityEngine.UI.Image.Type), out is_first);
				
				if (UnityEngineUIImageType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.Image.Type));
				    UnityEngineUIImageType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIImageType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIImageType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.Image.Type ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIImageType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.Image.Type val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Type");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.Image.Type");
                }
				val = (UnityEngine.UI.Image.Type)e;
                
            }
            else
            {
                val = (UnityEngine.UI.Image.Type)objectCasters.GetCaster(typeof(UnityEngine.UI.Image.Type))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIImageType(RealStatePtr L, int index, UnityEngine.UI.Image.Type val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIImageType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.Image.Type");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.Image.Type ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineTextAnchor_TypeID = -1;
		int UnityEngineTextAnchor_EnumRef = -1;
        
        public void PushUnityEngineTextAnchor(RealStatePtr L, UnityEngine.TextAnchor val)
        {
            if (UnityEngineTextAnchor_TypeID == -1)
            {
			    bool is_first;
                UnityEngineTextAnchor_TypeID = getTypeId(L, typeof(UnityEngine.TextAnchor), out is_first);
				
				if (UnityEngineTextAnchor_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.TextAnchor));
				    UnityEngineTextAnchor_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineTextAnchor_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineTextAnchor_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.TextAnchor ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineTextAnchor_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.TextAnchor val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineTextAnchor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.TextAnchor");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.TextAnchor");
                }
				val = (UnityEngine.TextAnchor)e;
                
            }
            else
            {
                val = (UnityEngine.TextAnchor)objectCasters.GetCaster(typeof(UnityEngine.TextAnchor))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineTextAnchor(RealStatePtr L, int index, UnityEngine.TextAnchor val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineTextAnchor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.TextAnchor");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.TextAnchor ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIInputFieldLineType_TypeID = -1;
		int UnityEngineUIInputFieldLineType_EnumRef = -1;
        
        public void PushUnityEngineUIInputFieldLineType(RealStatePtr L, UnityEngine.UI.InputField.LineType val)
        {
            if (UnityEngineUIInputFieldLineType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIInputFieldLineType_TypeID = getTypeId(L, typeof(UnityEngine.UI.InputField.LineType), out is_first);
				
				if (UnityEngineUIInputFieldLineType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.InputField.LineType));
				    UnityEngineUIInputFieldLineType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIInputFieldLineType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIInputFieldLineType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.InputField.LineType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIInputFieldLineType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.InputField.LineType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldLineType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.LineType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.InputField.LineType");
                }
				val = (UnityEngine.UI.InputField.LineType)e;
                
            }
            else
            {
                val = (UnityEngine.UI.InputField.LineType)objectCasters.GetCaster(typeof(UnityEngine.UI.InputField.LineType))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIInputFieldLineType(RealStatePtr L, int index, UnityEngine.UI.InputField.LineType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldLineType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.LineType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.InputField.LineType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIInputFieldCharacterValidation_TypeID = -1;
		int UnityEngineUIInputFieldCharacterValidation_EnumRef = -1;
        
        public void PushUnityEngineUIInputFieldCharacterValidation(RealStatePtr L, UnityEngine.UI.InputField.CharacterValidation val)
        {
            if (UnityEngineUIInputFieldCharacterValidation_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIInputFieldCharacterValidation_TypeID = getTypeId(L, typeof(UnityEngine.UI.InputField.CharacterValidation), out is_first);
				
				if (UnityEngineUIInputFieldCharacterValidation_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.InputField.CharacterValidation));
				    UnityEngineUIInputFieldCharacterValidation_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIInputFieldCharacterValidation_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIInputFieldCharacterValidation_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.InputField.CharacterValidation ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIInputFieldCharacterValidation_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.InputField.CharacterValidation val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldCharacterValidation_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.CharacterValidation");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.InputField.CharacterValidation");
                }
				val = (UnityEngine.UI.InputField.CharacterValidation)e;
                
            }
            else
            {
                val = (UnityEngine.UI.InputField.CharacterValidation)objectCasters.GetCaster(typeof(UnityEngine.UI.InputField.CharacterValidation))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIInputFieldCharacterValidation(RealStatePtr L, int index, UnityEngine.UI.InputField.CharacterValidation val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldCharacterValidation_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.CharacterValidation");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.InputField.CharacterValidation ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIInputFieldInputType_TypeID = -1;
		int UnityEngineUIInputFieldInputType_EnumRef = -1;
        
        public void PushUnityEngineUIInputFieldInputType(RealStatePtr L, UnityEngine.UI.InputField.InputType val)
        {
            if (UnityEngineUIInputFieldInputType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIInputFieldInputType_TypeID = getTypeId(L, typeof(UnityEngine.UI.InputField.InputType), out is_first);
				
				if (UnityEngineUIInputFieldInputType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.InputField.InputType));
				    UnityEngineUIInputFieldInputType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIInputFieldInputType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIInputFieldInputType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.InputField.InputType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIInputFieldInputType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.InputField.InputType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldInputType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.InputType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.InputField.InputType");
                }
				val = (UnityEngine.UI.InputField.InputType)e;
                
            }
            else
            {
                val = (UnityEngine.UI.InputField.InputType)objectCasters.GetCaster(typeof(UnityEngine.UI.InputField.InputType))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIInputFieldInputType(RealStatePtr L, int index, UnityEngine.UI.InputField.InputType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldInputType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.InputType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.InputField.InputType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIInputFieldContentType_TypeID = -1;
		int UnityEngineUIInputFieldContentType_EnumRef = -1;
        
        public void PushUnityEngineUIInputFieldContentType(RealStatePtr L, UnityEngine.UI.InputField.ContentType val)
        {
            if (UnityEngineUIInputFieldContentType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIInputFieldContentType_TypeID = getTypeId(L, typeof(UnityEngine.UI.InputField.ContentType), out is_first);
				
				if (UnityEngineUIInputFieldContentType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.InputField.ContentType));
				    UnityEngineUIInputFieldContentType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIInputFieldContentType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIInputFieldContentType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.InputField.ContentType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIInputFieldContentType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.InputField.ContentType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldContentType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.ContentType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.InputField.ContentType");
                }
				val = (UnityEngine.UI.InputField.ContentType)e;
                
            }
            else
            {
                val = (UnityEngine.UI.InputField.ContentType)objectCasters.GetCaster(typeof(UnityEngine.UI.InputField.ContentType))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIInputFieldContentType(RealStatePtr L, int index, UnityEngine.UI.InputField.ContentType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIInputFieldContentType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.InputField.ContentType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.InputField.ContentType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIScrollRectScrollbarVisibility_TypeID = -1;
		int UnityEngineUIScrollRectScrollbarVisibility_EnumRef = -1;
        
        public void PushUnityEngineUIScrollRectScrollbarVisibility(RealStatePtr L, UnityEngine.UI.ScrollRect.ScrollbarVisibility val)
        {
            if (UnityEngineUIScrollRectScrollbarVisibility_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIScrollRectScrollbarVisibility_TypeID = getTypeId(L, typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), out is_first);
				
				if (UnityEngineUIScrollRectScrollbarVisibility_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility));
				    UnityEngineUIScrollRectScrollbarVisibility_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIScrollRectScrollbarVisibility_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIScrollRectScrollbarVisibility_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.ScrollRect.ScrollbarVisibility ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIScrollRectScrollbarVisibility_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.ScrollRect.ScrollbarVisibility val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIScrollRectScrollbarVisibility_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ScrollRect.ScrollbarVisibility");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.ScrollRect.ScrollbarVisibility");
                }
				val = (UnityEngine.UI.ScrollRect.ScrollbarVisibility)e;
                
            }
            else
            {
                val = (UnityEngine.UI.ScrollRect.ScrollbarVisibility)objectCasters.GetCaster(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIScrollRectScrollbarVisibility(RealStatePtr L, int index, UnityEngine.UI.ScrollRect.ScrollbarVisibility val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIScrollRectScrollbarVisibility_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ScrollRect.ScrollbarVisibility");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.ScrollRect.ScrollbarVisibility ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIScrollRectMovementType_TypeID = -1;
		int UnityEngineUIScrollRectMovementType_EnumRef = -1;
        
        public void PushUnityEngineUIScrollRectMovementType(RealStatePtr L, UnityEngine.UI.ScrollRect.MovementType val)
        {
            if (UnityEngineUIScrollRectMovementType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIScrollRectMovementType_TypeID = getTypeId(L, typeof(UnityEngine.UI.ScrollRect.MovementType), out is_first);
				
				if (UnityEngineUIScrollRectMovementType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.ScrollRect.MovementType));
				    UnityEngineUIScrollRectMovementType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIScrollRectMovementType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIScrollRectMovementType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.ScrollRect.MovementType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIScrollRectMovementType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.ScrollRect.MovementType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIScrollRectMovementType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ScrollRect.MovementType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.ScrollRect.MovementType");
                }
				val = (UnityEngine.UI.ScrollRect.MovementType)e;
                
            }
            else
            {
                val = (UnityEngine.UI.ScrollRect.MovementType)objectCasters.GetCaster(typeof(UnityEngine.UI.ScrollRect.MovementType))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIScrollRectMovementType(RealStatePtr L, int index, UnityEngine.UI.ScrollRect.MovementType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIScrollRectMovementType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ScrollRect.MovementType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.ScrollRect.MovementType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIGridLayoutGroupConstraint_TypeID = -1;
		int UnityEngineUIGridLayoutGroupConstraint_EnumRef = -1;
        
        public void PushUnityEngineUIGridLayoutGroupConstraint(RealStatePtr L, UnityEngine.UI.GridLayoutGroup.Constraint val)
        {
            if (UnityEngineUIGridLayoutGroupConstraint_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIGridLayoutGroupConstraint_TypeID = getTypeId(L, typeof(UnityEngine.UI.GridLayoutGroup.Constraint), out is_first);
				
				if (UnityEngineUIGridLayoutGroupConstraint_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.GridLayoutGroup.Constraint));
				    UnityEngineUIGridLayoutGroupConstraint_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIGridLayoutGroupConstraint_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIGridLayoutGroupConstraint_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.GridLayoutGroup.Constraint ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIGridLayoutGroupConstraint_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.GridLayoutGroup.Constraint val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupConstraint_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Constraint");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.GridLayoutGroup.Constraint");
                }
				val = (UnityEngine.UI.GridLayoutGroup.Constraint)e;
                
            }
            else
            {
                val = (UnityEngine.UI.GridLayoutGroup.Constraint)objectCasters.GetCaster(typeof(UnityEngine.UI.GridLayoutGroup.Constraint))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIGridLayoutGroupConstraint(RealStatePtr L, int index, UnityEngine.UI.GridLayoutGroup.Constraint val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupConstraint_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Constraint");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.GridLayoutGroup.Constraint ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIGridLayoutGroupAxis_TypeID = -1;
		int UnityEngineUIGridLayoutGroupAxis_EnumRef = -1;
        
        public void PushUnityEngineUIGridLayoutGroupAxis(RealStatePtr L, UnityEngine.UI.GridLayoutGroup.Axis val)
        {
            if (UnityEngineUIGridLayoutGroupAxis_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIGridLayoutGroupAxis_TypeID = getTypeId(L, typeof(UnityEngine.UI.GridLayoutGroup.Axis), out is_first);
				
				if (UnityEngineUIGridLayoutGroupAxis_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.GridLayoutGroup.Axis));
				    UnityEngineUIGridLayoutGroupAxis_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIGridLayoutGroupAxis_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIGridLayoutGroupAxis_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.GridLayoutGroup.Axis ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIGridLayoutGroupAxis_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.GridLayoutGroup.Axis val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupAxis_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Axis");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.GridLayoutGroup.Axis");
                }
				val = (UnityEngine.UI.GridLayoutGroup.Axis)e;
                
            }
            else
            {
                val = (UnityEngine.UI.GridLayoutGroup.Axis)objectCasters.GetCaster(typeof(UnityEngine.UI.GridLayoutGroup.Axis))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIGridLayoutGroupAxis(RealStatePtr L, int index, UnityEngine.UI.GridLayoutGroup.Axis val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupAxis_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Axis");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.GridLayoutGroup.Axis ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIGridLayoutGroupCorner_TypeID = -1;
		int UnityEngineUIGridLayoutGroupCorner_EnumRef = -1;
        
        public void PushUnityEngineUIGridLayoutGroupCorner(RealStatePtr L, UnityEngine.UI.GridLayoutGroup.Corner val)
        {
            if (UnityEngineUIGridLayoutGroupCorner_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIGridLayoutGroupCorner_TypeID = getTypeId(L, typeof(UnityEngine.UI.GridLayoutGroup.Corner), out is_first);
				
				if (UnityEngineUIGridLayoutGroupCorner_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.GridLayoutGroup.Corner));
				    UnityEngineUIGridLayoutGroupCorner_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIGridLayoutGroupCorner_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIGridLayoutGroupCorner_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.GridLayoutGroup.Corner ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIGridLayoutGroupCorner_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.GridLayoutGroup.Corner val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupCorner_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Corner");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.GridLayoutGroup.Corner");
                }
				val = (UnityEngine.UI.GridLayoutGroup.Corner)e;
                
            }
            else
            {
                val = (UnityEngine.UI.GridLayoutGroup.Corner)objectCasters.GetCaster(typeof(UnityEngine.UI.GridLayoutGroup.Corner))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIGridLayoutGroupCorner(RealStatePtr L, int index, UnityEngine.UI.GridLayoutGroup.Corner val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIGridLayoutGroupCorner_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.GridLayoutGroup.Corner");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.GridLayoutGroup.Corner ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineUIContentSizeFitterFitMode_TypeID = -1;
		int UnityEngineUIContentSizeFitterFitMode_EnumRef = -1;
        
        public void PushUnityEngineUIContentSizeFitterFitMode(RealStatePtr L, UnityEngine.UI.ContentSizeFitter.FitMode val)
        {
            if (UnityEngineUIContentSizeFitterFitMode_TypeID == -1)
            {
			    bool is_first;
                UnityEngineUIContentSizeFitterFitMode_TypeID = getTypeId(L, typeof(UnityEngine.UI.ContentSizeFitter.FitMode), out is_first);
				
				if (UnityEngineUIContentSizeFitterFitMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.UI.ContentSizeFitter.FitMode));
				    UnityEngineUIContentSizeFitterFitMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineUIContentSizeFitterFitMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineUIContentSizeFitterFitMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.UI.ContentSizeFitter.FitMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineUIContentSizeFitterFitMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.UI.ContentSizeFitter.FitMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIContentSizeFitterFitMode_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ContentSizeFitter.FitMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.UI.ContentSizeFitter.FitMode");
                }
				val = (UnityEngine.UI.ContentSizeFitter.FitMode)e;
                
            }
            else
            {
                val = (UnityEngine.UI.ContentSizeFitter.FitMode)objectCasters.GetCaster(typeof(UnityEngine.UI.ContentSizeFitter.FitMode))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineUIContentSizeFitterFitMode(RealStatePtr L, int index, UnityEngine.UI.ContentSizeFitter.FitMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineUIContentSizeFitterFitMode_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.UI.ContentSizeFitter.FitMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.UI.ContentSizeFitter.FitMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineEventSystemsEventTriggerType_TypeID = -1;
		int UnityEngineEventSystemsEventTriggerType_EnumRef = -1;
        
        public void PushUnityEngineEventSystemsEventTriggerType(RealStatePtr L, UnityEngine.EventSystems.EventTriggerType val)
        {
            if (UnityEngineEventSystemsEventTriggerType_TypeID == -1)
            {
			    bool is_first;
                UnityEngineEventSystemsEventTriggerType_TypeID = getTypeId(L, typeof(UnityEngine.EventSystems.EventTriggerType), out is_first);
				
				if (UnityEngineEventSystemsEventTriggerType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(UnityEngine.EventSystems.EventTriggerType));
				    UnityEngineEventSystemsEventTriggerType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, UnityEngineEventSystemsEventTriggerType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, UnityEngineEventSystemsEventTriggerType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for UnityEngine.EventSystems.EventTriggerType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, UnityEngineEventSystemsEventTriggerType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.EventSystems.EventTriggerType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineEventSystemsEventTriggerType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.EventSystems.EventTriggerType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for UnityEngine.EventSystems.EventTriggerType");
                }
				val = (UnityEngine.EventSystems.EventTriggerType)e;
                
            }
            else
            {
                val = (UnityEngine.EventSystems.EventTriggerType)objectCasters.GetCaster(typeof(UnityEngine.EventSystems.EventTriggerType))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineEventSystemsEventTriggerType(RealStatePtr L, int index, UnityEngine.EventSystems.EventTriggerType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineEventSystemsEventTriggerType_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.EventSystems.EventTriggerType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for UnityEngine.EventSystems.EventTriggerType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int AutoScaleScaleMode_TypeID = -1;
		int AutoScaleScaleMode_EnumRef = -1;
        
        public void PushAutoScaleScaleMode(RealStatePtr L, AutoScale.ScaleMode val)
        {
            if (AutoScaleScaleMode_TypeID == -1)
            {
			    bool is_first;
                AutoScaleScaleMode_TypeID = getTypeId(L, typeof(AutoScale.ScaleMode), out is_first);
				
				if (AutoScaleScaleMode_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(AutoScale.ScaleMode));
				    AutoScaleScaleMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, AutoScaleScaleMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, AutoScaleScaleMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for AutoScale.ScaleMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, AutoScaleScaleMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out AutoScale.ScaleMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AutoScaleScaleMode_TypeID)
				{
				    throw new Exception("invalid userdata for AutoScale.ScaleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for AutoScale.ScaleMode");
                }
				val = (AutoScale.ScaleMode)e;
                
            }
            else
            {
                val = (AutoScale.ScaleMode)objectCasters.GetCaster(typeof(AutoScale.ScaleMode))(L, index, null);
            }
        }
		
        public void UpdateAutoScaleScaleMode(RealStatePtr L, int index, AutoScale.ScaleMode val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AutoScaleScaleMode_TypeID)
				{
				    throw new Exception("invalid userdata for AutoScale.ScaleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for AutoScale.ScaleMode ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int EmojiTextEmojiMaterialType_TypeID = -1;
		int EmojiTextEmojiMaterialType_EnumRef = -1;
        
        public void PushEmojiTextEmojiMaterialType(RealStatePtr L, EmojiText.EmojiMaterialType val)
        {
            if (EmojiTextEmojiMaterialType_TypeID == -1)
            {
			    bool is_first;
                EmojiTextEmojiMaterialType_TypeID = getTypeId(L, typeof(EmojiText.EmojiMaterialType), out is_first);
				
				if (EmojiTextEmojiMaterialType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(EmojiText.EmojiMaterialType));
				    EmojiTextEmojiMaterialType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, EmojiTextEmojiMaterialType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, EmojiTextEmojiMaterialType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for EmojiText.EmojiMaterialType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, EmojiTextEmojiMaterialType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out EmojiText.EmojiMaterialType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != EmojiTextEmojiMaterialType_TypeID)
				{
				    throw new Exception("invalid userdata for EmojiText.EmojiMaterialType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for EmojiText.EmojiMaterialType");
                }
				val = (EmojiText.EmojiMaterialType)e;
                
            }
            else
            {
                val = (EmojiText.EmojiMaterialType)objectCasters.GetCaster(typeof(EmojiText.EmojiMaterialType))(L, index, null);
            }
        }
		
        public void UpdateEmojiTextEmojiMaterialType(RealStatePtr L, int index, EmojiText.EmojiMaterialType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != EmojiTextEmojiMaterialType_TypeID)
				{
				    throw new Exception("invalid userdata for EmojiText.EmojiMaterialType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for EmojiText.EmojiMaterialType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiLockIconState_TypeID = -1;
		int xcuiLockIconState_EnumRef = -1;
        
        public void PushxcuiLockIconState(RealStatePtr L, xc.ui.LockIcon.State val)
        {
            if (xcuiLockIconState_TypeID == -1)
            {
			    bool is_first;
                xcuiLockIconState_TypeID = getTypeId(L, typeof(xc.ui.LockIcon.State), out is_first);
				
				if (xcuiLockIconState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.LockIcon.State));
				    xcuiLockIconState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiLockIconState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiLockIconState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.LockIcon.State ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiLockIconState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.LockIcon.State val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiLockIconState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.LockIcon.State");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.LockIcon.State");
                }
				val = (xc.ui.LockIcon.State)e;
                
            }
            else
            {
                val = (xc.ui.LockIcon.State)objectCasters.GetCaster(typeof(xc.ui.LockIcon.State))(L, index, null);
            }
        }
		
        public void UpdatexcuiLockIconState(RealStatePtr L, int index, xc.ui.LockIcon.State val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiLockIconState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.LockIcon.State");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.LockIcon.State ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiuguiUIManagerRefreshOrder_TypeID = -1;
		int xcuiuguiUIManagerRefreshOrder_EnumRef = -1;
        
        public void PushxcuiuguiUIManagerRefreshOrder(RealStatePtr L, xc.ui.ugui.UIManager.RefreshOrder val)
        {
            if (xcuiuguiUIManagerRefreshOrder_TypeID == -1)
            {
			    bool is_first;
                xcuiuguiUIManagerRefreshOrder_TypeID = getTypeId(L, typeof(xc.ui.ugui.UIManager.RefreshOrder), out is_first);
				
				if (xcuiuguiUIManagerRefreshOrder_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.ugui.UIManager.RefreshOrder));
				    xcuiuguiUIManagerRefreshOrder_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiuguiUIManagerRefreshOrder_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiuguiUIManagerRefreshOrder_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.ugui.UIManager.RefreshOrder ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiuguiUIManagerRefreshOrder_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.ugui.UIManager.RefreshOrder val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIManagerRefreshOrder_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIManager.RefreshOrder");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.ugui.UIManager.RefreshOrder");
                }
				val = (xc.ui.ugui.UIManager.RefreshOrder)e;
                
            }
            else
            {
                val = (xc.ui.ugui.UIManager.RefreshOrder)objectCasters.GetCaster(typeof(xc.ui.ugui.UIManager.RefreshOrder))(L, index, null);
            }
        }
		
        public void UpdatexcuiuguiUIManagerRefreshOrder(RealStatePtr L, int index, xc.ui.ugui.UIManager.RefreshOrder val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIManagerRefreshOrder_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIManager.RefreshOrder");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.ugui.UIManager.RefreshOrder ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiuguiUIBaseWindowCloseWinsType_TypeID = -1;
		int xcuiuguiUIBaseWindowCloseWinsType_EnumRef = -1;
        
        public void PushxcuiuguiUIBaseWindowCloseWinsType(RealStatePtr L, xc.ui.ugui.UIBaseWindow.CloseWinsType val)
        {
            if (xcuiuguiUIBaseWindowCloseWinsType_TypeID == -1)
            {
			    bool is_first;
                xcuiuguiUIBaseWindowCloseWinsType_TypeID = getTypeId(L, typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), out is_first);
				
				if (xcuiuguiUIBaseWindowCloseWinsType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType));
				    xcuiuguiUIBaseWindowCloseWinsType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiuguiUIBaseWindowCloseWinsType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiuguiUIBaseWindowCloseWinsType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.ugui.UIBaseWindow.CloseWinsType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiuguiUIBaseWindowCloseWinsType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.ugui.UIBaseWindow.CloseWinsType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIBaseWindowCloseWinsType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIBaseWindow.CloseWinsType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.ugui.UIBaseWindow.CloseWinsType");
                }
				val = (xc.ui.ugui.UIBaseWindow.CloseWinsType)e;
                
            }
            else
            {
                val = (xc.ui.ugui.UIBaseWindow.CloseWinsType)objectCasters.GetCaster(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType))(L, index, null);
            }
        }
		
        public void UpdatexcuiuguiUIBaseWindowCloseWinsType(RealStatePtr L, int index, xc.ui.ugui.UIBaseWindow.CloseWinsType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIBaseWindowCloseWinsType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIBaseWindow.CloseWinsType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.ugui.UIBaseWindow.CloseWinsType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiuguiUIType_TypeID = -1;
		int xcuiuguiUIType_EnumRef = -1;
        
        public void PushxcuiuguiUIType(RealStatePtr L, xc.ui.ugui.UIType val)
        {
            if (xcuiuguiUIType_TypeID == -1)
            {
			    bool is_first;
                xcuiuguiUIType_TypeID = getTypeId(L, typeof(xc.ui.ugui.UIType), out is_first);
				
				if (xcuiuguiUIType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.ugui.UIType));
				    xcuiuguiUIType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiuguiUIType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiuguiUIType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.ugui.UIType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiuguiUIType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.ugui.UIType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.ugui.UIType");
                }
				val = (xc.ui.ugui.UIType)e;
                
            }
            else
            {
                val = (xc.ui.ugui.UIType)objectCasters.GetCaster(typeof(xc.ui.ugui.UIType))(L, index, null);
            }
        }
		
        public void UpdatexcuiuguiUIType(RealStatePtr L, int index, xc.ui.ugui.UIType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUIType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UIType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.ugui.UIType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiUIWidgetHelpDragDropGroup_TypeID = -1;
		int xcuiUIWidgetHelpDragDropGroup_EnumRef = -1;
        
        public void PushxcuiUIWidgetHelpDragDropGroup(RealStatePtr L, xc.ui.UIWidgetHelp.DragDropGroup val)
        {
            if (xcuiUIWidgetHelpDragDropGroup_TypeID == -1)
            {
			    bool is_first;
                xcuiUIWidgetHelpDragDropGroup_TypeID = getTypeId(L, typeof(xc.ui.UIWidgetHelp.DragDropGroup), out is_first);
				
				if (xcuiUIWidgetHelpDragDropGroup_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.UIWidgetHelp.DragDropGroup));
				    xcuiUIWidgetHelpDragDropGroup_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiUIWidgetHelpDragDropGroup_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiUIWidgetHelpDragDropGroup_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.UIWidgetHelp.DragDropGroup ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiUIWidgetHelpDragDropGroup_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.UIWidgetHelp.DragDropGroup val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiUIWidgetHelpDragDropGroup_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.UIWidgetHelp.DragDropGroup");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.UIWidgetHelp.DragDropGroup");
                }
				val = (xc.ui.UIWidgetHelp.DragDropGroup)e;
                
            }
            else
            {
                val = (xc.ui.UIWidgetHelp.DragDropGroup)objectCasters.GetCaster(typeof(xc.ui.UIWidgetHelp.DragDropGroup))(L, index, null);
            }
        }
		
        public void UpdatexcuiUIWidgetHelpDragDropGroup(RealStatePtr L, int index, xc.ui.UIWidgetHelp.DragDropGroup val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiUIWidgetHelpDragDropGroup_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.UIWidgetHelp.DragDropGroup");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.UIWidgetHelp.DragDropGroup ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcuiuguiUINoticeWindowEWindowType_TypeID = -1;
		int xcuiuguiUINoticeWindowEWindowType_EnumRef = -1;
        
        public void PushxcuiuguiUINoticeWindowEWindowType(RealStatePtr L, xc.ui.ugui.UINoticeWindow.EWindowType val)
        {
            if (xcuiuguiUINoticeWindowEWindowType_TypeID == -1)
            {
			    bool is_first;
                xcuiuguiUINoticeWindowEWindowType_TypeID = getTypeId(L, typeof(xc.ui.ugui.UINoticeWindow.EWindowType), out is_first);
				
				if (xcuiuguiUINoticeWindowEWindowType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.ui.ugui.UINoticeWindow.EWindowType));
				    xcuiuguiUINoticeWindowEWindowType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcuiuguiUINoticeWindowEWindowType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcuiuguiUINoticeWindowEWindowType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.ui.ugui.UINoticeWindow.EWindowType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcuiuguiUINoticeWindowEWindowType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.ui.ugui.UINoticeWindow.EWindowType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUINoticeWindowEWindowType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UINoticeWindow.EWindowType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.ui.ugui.UINoticeWindow.EWindowType");
                }
				val = (xc.ui.ugui.UINoticeWindow.EWindowType)e;
                
            }
            else
            {
                val = (xc.ui.ugui.UINoticeWindow.EWindowType)objectCasters.GetCaster(typeof(xc.ui.ugui.UINoticeWindow.EWindowType))(L, index, null);
            }
        }
		
        public void UpdatexcuiuguiUINoticeWindowEWindowType(RealStatePtr L, int index, xc.ui.ugui.UINoticeWindow.EWindowType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcuiuguiUINoticeWindowEWindowType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.ui.ugui.UINoticeWindow.EWindowType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.ui.ugui.UINoticeWindow.EWindowType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcGoodsHelperItemMainType_TypeID = -1;
		int xcGoodsHelperItemMainType_EnumRef = -1;
        
        public void PushxcGoodsHelperItemMainType(RealStatePtr L, xc.GoodsHelper.ItemMainType val)
        {
            if (xcGoodsHelperItemMainType_TypeID == -1)
            {
			    bool is_first;
                xcGoodsHelperItemMainType_TypeID = getTypeId(L, typeof(xc.GoodsHelper.ItemMainType), out is_first);
				
				if (xcGoodsHelperItemMainType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.GoodsHelper.ItemMainType));
				    xcGoodsHelperItemMainType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcGoodsHelperItemMainType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcGoodsHelperItemMainType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.GoodsHelper.ItemMainType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcGoodsHelperItemMainType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.GoodsHelper.ItemMainType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcGoodsHelperItemMainType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.GoodsHelper.ItemMainType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.GoodsHelper.ItemMainType");
                }
				val = (xc.GoodsHelper.ItemMainType)e;
                
            }
            else
            {
                val = (xc.GoodsHelper.ItemMainType)objectCasters.GetCaster(typeof(xc.GoodsHelper.ItemMainType))(L, index, null);
            }
        }
		
        public void UpdatexcGoodsHelperItemMainType(RealStatePtr L, int index, xc.GoodsHelper.ItemMainType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcGoodsHelperItemMainType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.GoodsHelper.ItemMainType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.GoodsHelper.ItemMainType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcTaskDefineEAutoRunType_TypeID = -1;
		int xcTaskDefineEAutoRunType_EnumRef = -1;
        
        public void PushxcTaskDefineEAutoRunType(RealStatePtr L, xc.TaskDefine.EAutoRunType val)
        {
            if (xcTaskDefineEAutoRunType_TypeID == -1)
            {
			    bool is_first;
                xcTaskDefineEAutoRunType_TypeID = getTypeId(L, typeof(xc.TaskDefine.EAutoRunType), out is_first);
				
				if (xcTaskDefineEAutoRunType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.TaskDefine.EAutoRunType));
				    xcTaskDefineEAutoRunType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcTaskDefineEAutoRunType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcTaskDefineEAutoRunType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.TaskDefine.EAutoRunType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcTaskDefineEAutoRunType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.TaskDefine.EAutoRunType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcTaskDefineEAutoRunType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.TaskDefine.EAutoRunType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.TaskDefine.EAutoRunType");
                }
				val = (xc.TaskDefine.EAutoRunType)e;
                
            }
            else
            {
                val = (xc.TaskDefine.EAutoRunType)objectCasters.GetCaster(typeof(xc.TaskDefine.EAutoRunType))(L, index, null);
            }
        }
		
        public void UpdatexcTaskDefineEAutoRunType(RealStatePtr L, int index, xc.TaskDefine.EAutoRunType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcTaskDefineEAutoRunType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.TaskDefine.EAutoRunType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.TaskDefine.EAutoRunType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcVoiceControlComponentState_TypeID = -1;
		int xcVoiceControlComponentState_EnumRef = -1;
        
        public void PushxcVoiceControlComponentState(RealStatePtr L, xc.VoiceControlComponent.State val)
        {
            if (xcVoiceControlComponentState_TypeID == -1)
            {
			    bool is_first;
                xcVoiceControlComponentState_TypeID = getTypeId(L, typeof(xc.VoiceControlComponent.State), out is_first);
				
				if (xcVoiceControlComponentState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.VoiceControlComponent.State));
				    xcVoiceControlComponentState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcVoiceControlComponentState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcVoiceControlComponentState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.VoiceControlComponent.State ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcVoiceControlComponentState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.VoiceControlComponent.State val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcVoiceControlComponentState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.VoiceControlComponent.State");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.VoiceControlComponent.State");
                }
				val = (xc.VoiceControlComponent.State)e;
                
            }
            else
            {
                val = (xc.VoiceControlComponent.State)objectCasters.GetCaster(typeof(xc.VoiceControlComponent.State))(L, index, null);
            }
        }
		
        public void UpdatexcVoiceControlComponentState(RealStatePtr L, int index, xc.VoiceControlComponent.State val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcVoiceControlComponentState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.VoiceControlComponent.State");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.VoiceControlComponent.State ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcEquipBaptizeInfoEquipBaptizeState_TypeID = -1;
		int xcEquipBaptizeInfoEquipBaptizeState_EnumRef = -1;
        
        public void PushxcEquipBaptizeInfoEquipBaptizeState(RealStatePtr L, xc.EquipBaptizeInfo.EquipBaptizeState val)
        {
            if (xcEquipBaptizeInfoEquipBaptizeState_TypeID == -1)
            {
			    bool is_first;
                xcEquipBaptizeInfoEquipBaptizeState_TypeID = getTypeId(L, typeof(xc.EquipBaptizeInfo.EquipBaptizeState), out is_first);
				
				if (xcEquipBaptizeInfoEquipBaptizeState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.EquipBaptizeInfo.EquipBaptizeState));
				    xcEquipBaptizeInfoEquipBaptizeState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcEquipBaptizeInfoEquipBaptizeState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcEquipBaptizeInfoEquipBaptizeState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.EquipBaptizeInfo.EquipBaptizeState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcEquipBaptizeInfoEquipBaptizeState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.EquipBaptizeInfo.EquipBaptizeState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcEquipBaptizeInfoEquipBaptizeState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.EquipBaptizeInfo.EquipBaptizeState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.EquipBaptizeInfo.EquipBaptizeState");
                }
				val = (xc.EquipBaptizeInfo.EquipBaptizeState)e;
                
            }
            else
            {
                val = (xc.EquipBaptizeInfo.EquipBaptizeState)objectCasters.GetCaster(typeof(xc.EquipBaptizeInfo.EquipBaptizeState))(L, index, null);
            }
        }
		
        public void UpdatexcEquipBaptizeInfoEquipBaptizeState(RealStatePtr L, int index, xc.EquipBaptizeInfo.EquipBaptizeState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcEquipBaptizeInfoEquipBaptizeState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.EquipBaptizeInfo.EquipBaptizeState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.EquipBaptizeInfo.EquipBaptizeState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcInteractiveType_TypeID = -1;
		int xcInteractiveType_EnumRef = -1;
        
        public void PushxcInteractiveType(RealStatePtr L, xc.InteractiveType val)
        {
            if (xcInteractiveType_TypeID == -1)
            {
			    bool is_first;
                xcInteractiveType_TypeID = getTypeId(L, typeof(xc.InteractiveType), out is_first);
				
				if (xcInteractiveType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.InteractiveType));
				    xcInteractiveType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcInteractiveType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcInteractiveType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.InteractiveType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcInteractiveType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.InteractiveType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInteractiveType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InteractiveType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.InteractiveType");
                }
				val = (xc.InteractiveType)e;
                
            }
            else
            {
                val = (xc.InteractiveType)objectCasters.GetCaster(typeof(xc.InteractiveType))(L, index, null);
            }
        }
		
        public void UpdatexcInteractiveType(RealStatePtr L, int index, xc.InteractiveType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInteractiveType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InteractiveType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.InteractiveType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcFriendType_TypeID = -1;
		int xcFriendType_EnumRef = -1;
        
        public void PushxcFriendType(RealStatePtr L, xc.FriendType val)
        {
            if (xcFriendType_TypeID == -1)
            {
			    bool is_first;
                xcFriendType_TypeID = getTypeId(L, typeof(xc.FriendType), out is_first);
				
				if (xcFriendType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.FriendType));
				    xcFriendType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcFriendType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcFriendType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.FriendType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcFriendType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.FriendType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcFriendType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.FriendType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.FriendType");
                }
				val = (xc.FriendType)e;
                
            }
            else
            {
                val = (xc.FriendType)objectCasters.GetCaster(typeof(xc.FriendType))(L, index, null);
            }
        }
		
        public void UpdatexcFriendType(RealStatePtr L, int index, xc.FriendType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcFriendType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.FriendType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.FriendType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcMailInfoJumpType_TypeID = -1;
		int xcMailInfoJumpType_EnumRef = -1;
        
        public void PushxcMailInfoJumpType(RealStatePtr L, xc.MailInfo.JumpType val)
        {
            if (xcMailInfoJumpType_TypeID == -1)
            {
			    bool is_first;
                xcMailInfoJumpType_TypeID = getTypeId(L, typeof(xc.MailInfo.JumpType), out is_first);
				
				if (xcMailInfoJumpType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.MailInfo.JumpType));
				    xcMailInfoJumpType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcMailInfoJumpType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcMailInfoJumpType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.MailInfo.JumpType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcMailInfoJumpType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.MailInfo.JumpType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcMailInfoJumpType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.MailInfo.JumpType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.MailInfo.JumpType");
                }
				val = (xc.MailInfo.JumpType)e;
                
            }
            else
            {
                val = (xc.MailInfo.JumpType)objectCasters.GetCaster(typeof(xc.MailInfo.JumpType))(L, index, null);
            }
        }
		
        public void UpdatexcMailInfoJumpType(RealStatePtr L, int index, xc.MailInfo.JumpType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcMailInfoJumpType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.MailInfo.JumpType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.MailInfo.JumpType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcSceneHelpLoadQuadTreeSceneState_TypeID = -1;
		int xcSceneHelpLoadQuadTreeSceneState_EnumRef = -1;
        
        public void PushxcSceneHelpLoadQuadTreeSceneState(RealStatePtr L, xc.SceneHelp.LoadQuadTreeSceneState val)
        {
            if (xcSceneHelpLoadQuadTreeSceneState_TypeID == -1)
            {
			    bool is_first;
                xcSceneHelpLoadQuadTreeSceneState_TypeID = getTypeId(L, typeof(xc.SceneHelp.LoadQuadTreeSceneState), out is_first);
				
				if (xcSceneHelpLoadQuadTreeSceneState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.SceneHelp.LoadQuadTreeSceneState));
				    xcSceneHelpLoadQuadTreeSceneState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcSceneHelpLoadQuadTreeSceneState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcSceneHelpLoadQuadTreeSceneState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.SceneHelp.LoadQuadTreeSceneState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcSceneHelpLoadQuadTreeSceneState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.SceneHelp.LoadQuadTreeSceneState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcSceneHelpLoadQuadTreeSceneState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.SceneHelp.LoadQuadTreeSceneState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.SceneHelp.LoadQuadTreeSceneState");
                }
				val = (xc.SceneHelp.LoadQuadTreeSceneState)e;
                
            }
            else
            {
                val = (xc.SceneHelp.LoadQuadTreeSceneState)objectCasters.GetCaster(typeof(xc.SceneHelp.LoadQuadTreeSceneState))(L, index, null);
            }
        }
		
        public void UpdatexcSceneHelpLoadQuadTreeSceneState(RealStatePtr L, int index, xc.SceneHelp.LoadQuadTreeSceneState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcSceneHelpLoadQuadTreeSceneState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.SceneHelp.LoadQuadTreeSceneState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.SceneHelp.LoadQuadTreeSceneState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcInstanceManagerInstaneOpenState_TypeID = -1;
		int xcInstanceManagerInstaneOpenState_EnumRef = -1;
        
        public void PushxcInstanceManagerInstaneOpenState(RealStatePtr L, xc.InstanceManager.InstaneOpenState val)
        {
            if (xcInstanceManagerInstaneOpenState_TypeID == -1)
            {
			    bool is_first;
                xcInstanceManagerInstaneOpenState_TypeID = getTypeId(L, typeof(xc.InstanceManager.InstaneOpenState), out is_first);
				
				if (xcInstanceManagerInstaneOpenState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.InstanceManager.InstaneOpenState));
				    xcInstanceManagerInstaneOpenState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcInstanceManagerInstaneOpenState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcInstanceManagerInstaneOpenState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.InstanceManager.InstaneOpenState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcInstanceManagerInstaneOpenState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.InstanceManager.InstaneOpenState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInstanceManagerInstaneOpenState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InstanceManager.InstaneOpenState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.InstanceManager.InstaneOpenState");
                }
				val = (xc.InstanceManager.InstaneOpenState)e;
                
            }
            else
            {
                val = (xc.InstanceManager.InstaneOpenState)objectCasters.GetCaster(typeof(xc.InstanceManager.InstaneOpenState))(L, index, null);
            }
        }
		
        public void UpdatexcInstanceManagerInstaneOpenState(RealStatePtr L, int index, xc.InstanceManager.InstaneOpenState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInstanceManagerInstaneOpenState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InstanceManager.InstaneOpenState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.InstanceManager.InstaneOpenState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcInstanceManagerERewardState_TypeID = -1;
		int xcInstanceManagerERewardState_EnumRef = -1;
        
        public void PushxcInstanceManagerERewardState(RealStatePtr L, xc.InstanceManager.ERewardState val)
        {
            if (xcInstanceManagerERewardState_TypeID == -1)
            {
			    bool is_first;
                xcInstanceManagerERewardState_TypeID = getTypeId(L, typeof(xc.InstanceManager.ERewardState), out is_first);
				
				if (xcInstanceManagerERewardState_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.InstanceManager.ERewardState));
				    xcInstanceManagerERewardState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcInstanceManagerERewardState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcInstanceManagerERewardState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.InstanceManager.ERewardState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcInstanceManagerERewardState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.InstanceManager.ERewardState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInstanceManagerERewardState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InstanceManager.ERewardState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.InstanceManager.ERewardState");
                }
				val = (xc.InstanceManager.ERewardState)e;
                
            }
            else
            {
                val = (xc.InstanceManager.ERewardState)objectCasters.GetCaster(typeof(xc.InstanceManager.ERewardState))(L, index, null);
            }
        }
		
        public void UpdatexcInstanceManagerERewardState(RealStatePtr L, int index, xc.InstanceManager.ERewardState val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcInstanceManagerERewardState_TypeID)
				{
				    throw new Exception("invalid userdata for xc.InstanceManager.ERewardState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.InstanceManager.ERewardState ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcEHookRangeType_TypeID = -1;
		int xcEHookRangeType_EnumRef = -1;
        
        public void PushxcEHookRangeType(RealStatePtr L, xc.EHookRangeType val)
        {
            if (xcEHookRangeType_TypeID == -1)
            {
			    bool is_first;
                xcEHookRangeType_TypeID = getTypeId(L, typeof(xc.EHookRangeType), out is_first);
				
				if (xcEHookRangeType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.EHookRangeType));
				    xcEHookRangeType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcEHookRangeType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcEHookRangeType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.EHookRangeType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcEHookRangeType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.EHookRangeType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcEHookRangeType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.EHookRangeType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.EHookRangeType");
                }
				val = (xc.EHookRangeType)e;
                
            }
            else
            {
                val = (xc.EHookRangeType)objectCasters.GetCaster(typeof(xc.EHookRangeType))(L, index, null);
            }
        }
		
        public void UpdatexcEHookRangeType(RealStatePtr L, int index, xc.EHookRangeType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcEHookRangeType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.EHookRangeType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.EHookRangeType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int xcCustomDataType_TypeID = -1;
		int xcCustomDataType_EnumRef = -1;
        
        public void PushxcCustomDataType(RealStatePtr L, xc.CustomDataType val)
        {
            if (xcCustomDataType_TypeID == -1)
            {
			    bool is_first;
                xcCustomDataType_TypeID = getTypeId(L, typeof(xc.CustomDataType), out is_first);
				
				if (xcCustomDataType_EnumRef == -1)
				{
				    XUtils.LoadCSTable(L, typeof(xc.CustomDataType));
				    xcCustomDataType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, xcCustomDataType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, xcCustomDataType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for xc.CustomDataType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, xcCustomDataType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out xc.CustomDataType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcCustomDataType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.CustomDataType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for xc.CustomDataType");
                }
				val = (xc.CustomDataType)e;
                
            }
            else
            {
                val = (xc.CustomDataType)objectCasters.GetCaster(typeof(xc.CustomDataType))(L, index, null);
            }
        }
		
        public void UpdatexcCustomDataType(RealStatePtr L, int index, xc.CustomDataType val)
        {
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != xcCustomDataType_TypeID)
				{
				    throw new Exception("invalid userdata for xc.CustomDataType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for xc.CustomDataType ,value="+val);
                }
            }
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        
		// table cast optimze
		
        
    }
	
	public partial class StaticLuaCallbacks
    {
	    static bool __tryArrayGet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int index)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.PushUnityEngineVector2(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.PushUnityEngineVector3(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.PushUnityEngineVector4(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.PushUnityEngineColor(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.PushUnityEngineQuaternion(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.PushUnityEngineRay(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.PushUnityEngineBounds(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.PushUnityEngineRay2D(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.Game.EGameMode[]))
			{
			    xc.Game.EGameMode[] array = obj as xc.Game.EGameMode[];
				translator.PushxcGameEGameMode(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.RectTransform.Axis[]))
			{
			    UnityEngine.RectTransform.Axis[] array = obj as UnityEngine.RectTransform.Axis[];
				translator.PushUnityEngineRectTransformAxis(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.RectTransform.Edge[]))
			{
			    UnityEngine.RectTransform.Edge[] array = obj as UnityEngine.RectTransform.Edge[];
				translator.PushUnityEngineRectTransformEdge(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.RuntimePlatform[]))
			{
			    UnityEngine.RuntimePlatform[] array = obj as UnityEngine.RuntimePlatform[];
				translator.PushUnityEngineRuntimePlatform(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.AnimatorCullingMode[]))
			{
			    UnityEngine.AnimatorCullingMode[] array = obj as UnityEngine.AnimatorCullingMode[];
				translator.PushUnityEngineAnimatorCullingMode(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Texture2D.EXRFlags[]))
			{
			    UnityEngine.Texture2D.EXRFlags[] array = obj as UnityEngine.Texture2D.EXRFlags[];
				translator.PushUnityEngineTexture2DEXRFlags(L, array[index]);
				return true;
			}
			else if (type == typeof(Net.NetClient.ENetState[]))
			{
			    Net.NetClient.ENetState[] array = obj as Net.NetClient.ENetState[];
				translator.PushNetNetClientENetState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ObjCachePoolType[]))
			{
			    xc.ObjCachePoolType[] array = obj as xc.ObjCachePoolType[];
				translator.PushxcObjCachePoolType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.PlayerFollowRecordSceneId[]))
			{
			    xc.PlayerFollowRecordSceneId[] array = obj as xc.PlayerFollowRecordSceneId[];
				translator.PushxcPlayerFollowRecordSceneId(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ClientEvent[]))
			{
			    xc.ClientEvent[] array = obj as xc.ClientEvent[];
				translator.PushxcClientEvent(L, array[index]);
				return true;
			}
			else if (type == typeof(CameraControl.EMode[]))
			{
			    CameraControl.EMode[] array = obj as CameraControl.EMode[];
				translator.PushCameraControlEMode(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBManager.CommandTag[]))
			{
			    xc.DBManager.CommandTag[] array = obj as xc.DBManager.CommandTag[];
				translator.PushxcDBManagerCommandTag(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBNotice.EFillType[]))
			{
			    xc.DBNotice.EFillType[] array = obj as xc.DBNotice.EFillType[];
				translator.PushxcDBNoticeEFillType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBDataAllSkill.SET_SLOT_TYPE[]))
			{
			    xc.DBDataAllSkill.SET_SLOT_TYPE[] array = obj as xc.DBDataAllSkill.SET_SLOT_TYPE[];
				translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBDataAllSkill.SKILL_TYPE[]))
			{
			    xc.DBDataAllSkill.SKILL_TYPE[] array = obj as xc.DBDataAllSkill.SKILL_TYPE[];
				translator.PushxcDBDataAllSkillSKILL_TYPE(L, array[index]);
				return true;
			}
			else if (type == typeof(DBBuffSev.BindPos[]))
			{
			    DBBuffSev.BindPos[] array = obj as DBBuffSev.BindPos[];
				translator.PushDBBuffSevBindPos(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBGrowSkin.SkinUnLockType[]))
			{
			    xc.DBGrowSkin.SkinUnLockType[] array = obj as xc.DBGrowSkin.SkinUnLockType[];
				translator.PushxcDBGrowSkinSkinUnLockType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBAvatarPart.BODY_PART[]))
			{
			    xc.DBAvatarPart.BODY_PART[] array = obj as xc.DBAvatarPart.BODY_PART[];
				translator.PushxcDBAvatarPartBODY_PART(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBPet.PetUnLockType[]))
			{
			    xc.DBPet.PetUnLockType[] array = obj as xc.DBPet.PetUnLockType[];
				translator.PushxcDBPetPetUnLockType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysBtnFixType[]))
			{
			    xc.DBSysConfig.ESysBtnFixType[] array = obj as xc.DBSysConfig.ESysBtnFixType[];
				translator.PushxcDBSysConfigESysBtnFixType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysBtnPos[]))
			{
			    xc.DBSysConfig.ESysBtnPos[] array = obj as xc.DBSysConfig.ESysBtnPos[];
				translator.PushxcDBSysConfigESysBtnPos(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysTaskType[]))
			{
			    xc.DBSysConfig.ESysTaskType[] array = obj as xc.DBSysConfig.ESysTaskType[];
				translator.PushxcDBSysConfigESysTaskType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.DBEquipPos.EquipPosType[]))
			{
			    xc.DBEquipPos.EquipPosType[] array = obj as xc.DBEquipPos.EquipPosType[];
				translator.PushxcDBEquipPosEquipPosType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.Buff.BuffFlags[]))
			{
			    xc.Buff.BuffFlags[] array = obj as xc.Buff.BuffFlags[];
				translator.PushxcBuffBuffFlags(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.RockCommandSystem.ClickRockButtonTipsType[]))
			{
			    xc.RockCommandSystem.ClickRockButtonTipsType[] array = obj as xc.RockCommandSystem.ClickRockButtonTipsType[];
				translator.PushxcRockCommandSystemClickRockButtonTipsType(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.EHeadIcon[]))
			{
			    Actor.EHeadIcon[] array = obj as Actor.EHeadIcon[];
				translator.PushActorEHeadIcon(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.EVocationType[]))
			{
			    Actor.EVocationType[] array = obj as Actor.EVocationType[];
				translator.PushActorEVocationType(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.ActorEvent[]))
			{
			    Actor.ActorEvent[] array = obj as Actor.ActorEvent[];
				translator.PushActorActorEvent(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.EAnimation[]))
			{
			    Actor.EAnimation[] array = obj as Actor.EAnimation[];
				translator.PushActorEAnimation(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.SlotBoneNameType[]))
			{
			    Actor.SlotBoneNameType[] array = obj as Actor.SlotBoneNameType[];
				translator.PushActorSlotBoneNameType(L, array[index]);
				return true;
			}
			else if (type == typeof(Actor.EWildState[]))
			{
			    Actor.EWildState[] array = obj as Actor.EWildState[];
				translator.PushActorEWildState(L, array[index]);
				return true;
			}
			else if (type == typeof(Monster.MonsterSpawnType[]))
			{
			    Monster.MonsterSpawnType[] array = obj as Monster.MonsterSpawnType[];
				translator.PushMonsterMonsterSpawnType(L, array[index]);
				return true;
			}
			else if (type == typeof(Monster.MonsterType[]))
			{
			    Monster.MonsterType[] array = obj as Monster.MonsterType[];
				translator.PushMonsterMonsterType(L, array[index]);
				return true;
			}
			else if (type == typeof(Monster.BeSummonType[]))
			{
			    Monster.BeSummonType[] array = obj as Monster.BeSummonType[];
				translator.PushMonsterBeSummonType(L, array[index]);
				return true;
			}
			else if (type == typeof(Monster.QualityColor[]))
			{
			    Monster.QualityColor[] array = obj as Monster.QualityColor[];
				translator.PushMonsterQualityColor(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.MoveCtrl.EActorStepType[]))
			{
			    xc.MoveCtrl.EActorStepType[] array = obj as xc.MoveCtrl.EActorStepType[];
				translator.PushxcMoveCtrlEActorStepType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EWalkMode[]))
			{
			    xc.ActorMachine.EWalkMode[] array = obj as xc.ActorMachine.EWalkMode[];
				translator.PushxcActorMachineEWalkMode(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EFSMEvent[]))
			{
			    xc.ActorMachine.EFSMEvent[] array = obj as xc.ActorMachine.EFSMEvent[];
				translator.PushxcActorMachineEFSMEvent(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EFSMState[]))
			{
			    xc.ActorMachine.EFSMState[] array = obj as xc.ActorMachine.EFSMState[];
				translator.PushxcActorMachineEFSMState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.NpcDefine.EFunction[]))
			{
			    xc.NpcDefine.EFunction[] array = obj as xc.NpcDefine.EFunction[];
				translator.PushxcNpcDefineEFunction(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.NpcDefine.ELightMode[]))
			{
			    xc.NpcDefine.ELightMode[] array = obj as xc.NpcDefine.ELightMode[];
				translator.PushxcNpcDefineELightMode(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Toggle.ToggleTransition[]))
			{
			    UnityEngine.UI.Toggle.ToggleTransition[] array = obj as UnityEngine.UI.Toggle.ToggleTransition[];
				translator.PushUnityEngineUIToggleToggleTransition(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Slider.Direction[]))
			{
			    UnityEngine.UI.Slider.Direction[] array = obj as UnityEngine.UI.Slider.Direction[];
				translator.PushUnityEngineUISliderDirection(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin360[]))
			{
			    UnityEngine.UI.Image.Origin360[] array = obj as UnityEngine.UI.Image.Origin360[];
				translator.PushUnityEngineUIImageOrigin360(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin180[]))
			{
			    UnityEngine.UI.Image.Origin180[] array = obj as UnityEngine.UI.Image.Origin180[];
				translator.PushUnityEngineUIImageOrigin180(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin90[]))
			{
			    UnityEngine.UI.Image.Origin90[] array = obj as UnityEngine.UI.Image.Origin90[];
				translator.PushUnityEngineUIImageOrigin90(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.OriginVertical[]))
			{
			    UnityEngine.UI.Image.OriginVertical[] array = obj as UnityEngine.UI.Image.OriginVertical[];
				translator.PushUnityEngineUIImageOriginVertical(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.OriginHorizontal[]))
			{
			    UnityEngine.UI.Image.OriginHorizontal[] array = obj as UnityEngine.UI.Image.OriginHorizontal[];
				translator.PushUnityEngineUIImageOriginHorizontal(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.FillMethod[]))
			{
			    UnityEngine.UI.Image.FillMethod[] array = obj as UnityEngine.UI.Image.FillMethod[];
				translator.PushUnityEngineUIImageFillMethod(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Type[]))
			{
			    UnityEngine.UI.Image.Type[] array = obj as UnityEngine.UI.Image.Type[];
				translator.PushUnityEngineUIImageType(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.TextAnchor[]))
			{
			    UnityEngine.TextAnchor[] array = obj as UnityEngine.TextAnchor[];
				translator.PushUnityEngineTextAnchor(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.LineType[]))
			{
			    UnityEngine.UI.InputField.LineType[] array = obj as UnityEngine.UI.InputField.LineType[];
				translator.PushUnityEngineUIInputFieldLineType(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.CharacterValidation[]))
			{
			    UnityEngine.UI.InputField.CharacterValidation[] array = obj as UnityEngine.UI.InputField.CharacterValidation[];
				translator.PushUnityEngineUIInputFieldCharacterValidation(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.InputType[]))
			{
			    UnityEngine.UI.InputField.InputType[] array = obj as UnityEngine.UI.InputField.InputType[];
				translator.PushUnityEngineUIInputFieldInputType(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.ContentType[]))
			{
			    UnityEngine.UI.InputField.ContentType[] array = obj as UnityEngine.UI.InputField.ContentType[];
				translator.PushUnityEngineUIInputFieldContentType(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility[]))
			{
			    UnityEngine.UI.ScrollRect.ScrollbarVisibility[] array = obj as UnityEngine.UI.ScrollRect.ScrollbarVisibility[];
				translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ScrollRect.MovementType[]))
			{
			    UnityEngine.UI.ScrollRect.MovementType[] array = obj as UnityEngine.UI.ScrollRect.MovementType[];
				translator.PushUnityEngineUIScrollRectMovementType(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Constraint[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Constraint[] array = obj as UnityEngine.UI.GridLayoutGroup.Constraint[];
				translator.PushUnityEngineUIGridLayoutGroupConstraint(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Axis[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Axis[] array = obj as UnityEngine.UI.GridLayoutGroup.Axis[];
				translator.PushUnityEngineUIGridLayoutGroupAxis(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Corner[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Corner[] array = obj as UnityEngine.UI.GridLayoutGroup.Corner[];
				translator.PushUnityEngineUIGridLayoutGroupCorner(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ContentSizeFitter.FitMode[]))
			{
			    UnityEngine.UI.ContentSizeFitter.FitMode[] array = obj as UnityEngine.UI.ContentSizeFitter.FitMode[];
				translator.PushUnityEngineUIContentSizeFitterFitMode(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.EventSystems.EventTriggerType[]))
			{
			    UnityEngine.EventSystems.EventTriggerType[] array = obj as UnityEngine.EventSystems.EventTriggerType[];
				translator.PushUnityEngineEventSystemsEventTriggerType(L, array[index]);
				return true;
			}
			else if (type == typeof(AutoScale.ScaleMode[]))
			{
			    AutoScale.ScaleMode[] array = obj as AutoScale.ScaleMode[];
				translator.PushAutoScaleScaleMode(L, array[index]);
				return true;
			}
			else if (type == typeof(EmojiText.EmojiMaterialType[]))
			{
			    EmojiText.EmojiMaterialType[] array = obj as EmojiText.EmojiMaterialType[];
				translator.PushEmojiTextEmojiMaterialType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.LockIcon.State[]))
			{
			    xc.ui.LockIcon.State[] array = obj as xc.ui.LockIcon.State[];
				translator.PushxcuiLockIconState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIManager.RefreshOrder[]))
			{
			    xc.ui.ugui.UIManager.RefreshOrder[] array = obj as xc.ui.ugui.UIManager.RefreshOrder[];
				translator.PushxcuiuguiUIManagerRefreshOrder(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType[]))
			{
			    xc.ui.ugui.UIBaseWindow.CloseWinsType[] array = obj as xc.ui.ugui.UIBaseWindow.CloseWinsType[];
				translator.PushxcuiuguiUIBaseWindowCloseWinsType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIType[]))
			{
			    xc.ui.ugui.UIType[] array = obj as xc.ui.ugui.UIType[];
				translator.PushxcuiuguiUIType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.UIWidgetHelp.DragDropGroup[]))
			{
			    xc.ui.UIWidgetHelp.DragDropGroup[] array = obj as xc.ui.UIWidgetHelp.DragDropGroup[];
				translator.PushxcuiUIWidgetHelpDragDropGroup(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UINoticeWindow.EWindowType[]))
			{
			    xc.ui.ugui.UINoticeWindow.EWindowType[] array = obj as xc.ui.ugui.UINoticeWindow.EWindowType[];
				translator.PushxcuiuguiUINoticeWindowEWindowType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.GoodsHelper.ItemMainType[]))
			{
			    xc.GoodsHelper.ItemMainType[] array = obj as xc.GoodsHelper.ItemMainType[];
				translator.PushxcGoodsHelperItemMainType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.TaskDefine.EAutoRunType[]))
			{
			    xc.TaskDefine.EAutoRunType[] array = obj as xc.TaskDefine.EAutoRunType[];
				translator.PushxcTaskDefineEAutoRunType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.VoiceControlComponent.State[]))
			{
			    xc.VoiceControlComponent.State[] array = obj as xc.VoiceControlComponent.State[];
				translator.PushxcVoiceControlComponentState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.EquipBaptizeInfo.EquipBaptizeState[]))
			{
			    xc.EquipBaptizeInfo.EquipBaptizeState[] array = obj as xc.EquipBaptizeInfo.EquipBaptizeState[];
				translator.PushxcEquipBaptizeInfoEquipBaptizeState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.InteractiveType[]))
			{
			    xc.InteractiveType[] array = obj as xc.InteractiveType[];
				translator.PushxcInteractiveType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.FriendType[]))
			{
			    xc.FriendType[] array = obj as xc.FriendType[];
				translator.PushxcFriendType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.MailInfo.JumpType[]))
			{
			    xc.MailInfo.JumpType[] array = obj as xc.MailInfo.JumpType[];
				translator.PushxcMailInfoJumpType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.SceneHelp.LoadQuadTreeSceneState[]))
			{
			    xc.SceneHelp.LoadQuadTreeSceneState[] array = obj as xc.SceneHelp.LoadQuadTreeSceneState[];
				translator.PushxcSceneHelpLoadQuadTreeSceneState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.InstanceManager.InstaneOpenState[]))
			{
			    xc.InstanceManager.InstaneOpenState[] array = obj as xc.InstanceManager.InstaneOpenState[];
				translator.PushxcInstanceManagerInstaneOpenState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.InstanceManager.ERewardState[]))
			{
			    xc.InstanceManager.ERewardState[] array = obj as xc.InstanceManager.ERewardState[];
				translator.PushxcInstanceManagerERewardState(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.EHookRangeType[]))
			{
			    xc.EHookRangeType[] array = obj as xc.EHookRangeType[];
				translator.PushxcEHookRangeType(L, array[index]);
				return true;
			}
			else if (type == typeof(xc.CustomDataType[]))
			{
			    xc.CustomDataType[] array = obj as xc.CustomDataType[];
				translator.PushxcCustomDataType(L, array[index]);
				return true;
			}
            return false;
		}
		
		static bool __tryArraySet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.Game.EGameMode[]))
			{
			    xc.Game.EGameMode[] array = obj as xc.Game.EGameMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.RectTransform.Axis[]))
			{
			    UnityEngine.RectTransform.Axis[] array = obj as UnityEngine.RectTransform.Axis[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.RectTransform.Edge[]))
			{
			    UnityEngine.RectTransform.Edge[] array = obj as UnityEngine.RectTransform.Edge[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.RuntimePlatform[]))
			{
			    UnityEngine.RuntimePlatform[] array = obj as UnityEngine.RuntimePlatform[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.AnimatorCullingMode[]))
			{
			    UnityEngine.AnimatorCullingMode[] array = obj as UnityEngine.AnimatorCullingMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Texture2D.EXRFlags[]))
			{
			    UnityEngine.Texture2D.EXRFlags[] array = obj as UnityEngine.Texture2D.EXRFlags[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Net.NetClient.ENetState[]))
			{
			    Net.NetClient.ENetState[] array = obj as Net.NetClient.ENetState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ObjCachePoolType[]))
			{
			    xc.ObjCachePoolType[] array = obj as xc.ObjCachePoolType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.PlayerFollowRecordSceneId[]))
			{
			    xc.PlayerFollowRecordSceneId[] array = obj as xc.PlayerFollowRecordSceneId[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ClientEvent[]))
			{
			    xc.ClientEvent[] array = obj as xc.ClientEvent[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(CameraControl.EMode[]))
			{
			    CameraControl.EMode[] array = obj as CameraControl.EMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBManager.CommandTag[]))
			{
			    xc.DBManager.CommandTag[] array = obj as xc.DBManager.CommandTag[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBNotice.EFillType[]))
			{
			    xc.DBNotice.EFillType[] array = obj as xc.DBNotice.EFillType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBDataAllSkill.SET_SLOT_TYPE[]))
			{
			    xc.DBDataAllSkill.SET_SLOT_TYPE[] array = obj as xc.DBDataAllSkill.SET_SLOT_TYPE[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBDataAllSkill.SKILL_TYPE[]))
			{
			    xc.DBDataAllSkill.SKILL_TYPE[] array = obj as xc.DBDataAllSkill.SKILL_TYPE[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DBBuffSev.BindPos[]))
			{
			    DBBuffSev.BindPos[] array = obj as DBBuffSev.BindPos[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBGrowSkin.SkinUnLockType[]))
			{
			    xc.DBGrowSkin.SkinUnLockType[] array = obj as xc.DBGrowSkin.SkinUnLockType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBAvatarPart.BODY_PART[]))
			{
			    xc.DBAvatarPart.BODY_PART[] array = obj as xc.DBAvatarPart.BODY_PART[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBPet.PetUnLockType[]))
			{
			    xc.DBPet.PetUnLockType[] array = obj as xc.DBPet.PetUnLockType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysBtnFixType[]))
			{
			    xc.DBSysConfig.ESysBtnFixType[] array = obj as xc.DBSysConfig.ESysBtnFixType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysBtnPos[]))
			{
			    xc.DBSysConfig.ESysBtnPos[] array = obj as xc.DBSysConfig.ESysBtnPos[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBSysConfig.ESysTaskType[]))
			{
			    xc.DBSysConfig.ESysTaskType[] array = obj as xc.DBSysConfig.ESysTaskType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.DBEquipPos.EquipPosType[]))
			{
			    xc.DBEquipPos.EquipPosType[] array = obj as xc.DBEquipPos.EquipPosType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.Buff.BuffFlags[]))
			{
			    xc.Buff.BuffFlags[] array = obj as xc.Buff.BuffFlags[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.RockCommandSystem.ClickRockButtonTipsType[]))
			{
			    xc.RockCommandSystem.ClickRockButtonTipsType[] array = obj as xc.RockCommandSystem.ClickRockButtonTipsType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.EHeadIcon[]))
			{
			    Actor.EHeadIcon[] array = obj as Actor.EHeadIcon[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.EVocationType[]))
			{
			    Actor.EVocationType[] array = obj as Actor.EVocationType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.ActorEvent[]))
			{
			    Actor.ActorEvent[] array = obj as Actor.ActorEvent[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.EAnimation[]))
			{
			    Actor.EAnimation[] array = obj as Actor.EAnimation[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.SlotBoneNameType[]))
			{
			    Actor.SlotBoneNameType[] array = obj as Actor.SlotBoneNameType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Actor.EWildState[]))
			{
			    Actor.EWildState[] array = obj as Actor.EWildState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Monster.MonsterSpawnType[]))
			{
			    Monster.MonsterSpawnType[] array = obj as Monster.MonsterSpawnType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Monster.MonsterType[]))
			{
			    Monster.MonsterType[] array = obj as Monster.MonsterType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Monster.BeSummonType[]))
			{
			    Monster.BeSummonType[] array = obj as Monster.BeSummonType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Monster.QualityColor[]))
			{
			    Monster.QualityColor[] array = obj as Monster.QualityColor[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.MoveCtrl.EActorStepType[]))
			{
			    xc.MoveCtrl.EActorStepType[] array = obj as xc.MoveCtrl.EActorStepType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EWalkMode[]))
			{
			    xc.ActorMachine.EWalkMode[] array = obj as xc.ActorMachine.EWalkMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EFSMEvent[]))
			{
			    xc.ActorMachine.EFSMEvent[] array = obj as xc.ActorMachine.EFSMEvent[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ActorMachine.EFSMState[]))
			{
			    xc.ActorMachine.EFSMState[] array = obj as xc.ActorMachine.EFSMState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.NpcDefine.EFunction[]))
			{
			    xc.NpcDefine.EFunction[] array = obj as xc.NpcDefine.EFunction[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.NpcDefine.ELightMode[]))
			{
			    xc.NpcDefine.ELightMode[] array = obj as xc.NpcDefine.ELightMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Toggle.ToggleTransition[]))
			{
			    UnityEngine.UI.Toggle.ToggleTransition[] array = obj as UnityEngine.UI.Toggle.ToggleTransition[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Slider.Direction[]))
			{
			    UnityEngine.UI.Slider.Direction[] array = obj as UnityEngine.UI.Slider.Direction[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin360[]))
			{
			    UnityEngine.UI.Image.Origin360[] array = obj as UnityEngine.UI.Image.Origin360[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin180[]))
			{
			    UnityEngine.UI.Image.Origin180[] array = obj as UnityEngine.UI.Image.Origin180[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Origin90[]))
			{
			    UnityEngine.UI.Image.Origin90[] array = obj as UnityEngine.UI.Image.Origin90[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.OriginVertical[]))
			{
			    UnityEngine.UI.Image.OriginVertical[] array = obj as UnityEngine.UI.Image.OriginVertical[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.OriginHorizontal[]))
			{
			    UnityEngine.UI.Image.OriginHorizontal[] array = obj as UnityEngine.UI.Image.OriginHorizontal[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.FillMethod[]))
			{
			    UnityEngine.UI.Image.FillMethod[] array = obj as UnityEngine.UI.Image.FillMethod[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.Image.Type[]))
			{
			    UnityEngine.UI.Image.Type[] array = obj as UnityEngine.UI.Image.Type[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.TextAnchor[]))
			{
			    UnityEngine.TextAnchor[] array = obj as UnityEngine.TextAnchor[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.LineType[]))
			{
			    UnityEngine.UI.InputField.LineType[] array = obj as UnityEngine.UI.InputField.LineType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.CharacterValidation[]))
			{
			    UnityEngine.UI.InputField.CharacterValidation[] array = obj as UnityEngine.UI.InputField.CharacterValidation[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.InputType[]))
			{
			    UnityEngine.UI.InputField.InputType[] array = obj as UnityEngine.UI.InputField.InputType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.InputField.ContentType[]))
			{
			    UnityEngine.UI.InputField.ContentType[] array = obj as UnityEngine.UI.InputField.ContentType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility[]))
			{
			    UnityEngine.UI.ScrollRect.ScrollbarVisibility[] array = obj as UnityEngine.UI.ScrollRect.ScrollbarVisibility[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ScrollRect.MovementType[]))
			{
			    UnityEngine.UI.ScrollRect.MovementType[] array = obj as UnityEngine.UI.ScrollRect.MovementType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Constraint[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Constraint[] array = obj as UnityEngine.UI.GridLayoutGroup.Constraint[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Axis[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Axis[] array = obj as UnityEngine.UI.GridLayoutGroup.Axis[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.GridLayoutGroup.Corner[]))
			{
			    UnityEngine.UI.GridLayoutGroup.Corner[] array = obj as UnityEngine.UI.GridLayoutGroup.Corner[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.UI.ContentSizeFitter.FitMode[]))
			{
			    UnityEngine.UI.ContentSizeFitter.FitMode[] array = obj as UnityEngine.UI.ContentSizeFitter.FitMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.EventSystems.EventTriggerType[]))
			{
			    UnityEngine.EventSystems.EventTriggerType[] array = obj as UnityEngine.EventSystems.EventTriggerType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(AutoScale.ScaleMode[]))
			{
			    AutoScale.ScaleMode[] array = obj as AutoScale.ScaleMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(EmojiText.EmojiMaterialType[]))
			{
			    EmojiText.EmojiMaterialType[] array = obj as EmojiText.EmojiMaterialType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.LockIcon.State[]))
			{
			    xc.ui.LockIcon.State[] array = obj as xc.ui.LockIcon.State[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIManager.RefreshOrder[]))
			{
			    xc.ui.ugui.UIManager.RefreshOrder[] array = obj as xc.ui.ugui.UIManager.RefreshOrder[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType[]))
			{
			    xc.ui.ugui.UIBaseWindow.CloseWinsType[] array = obj as xc.ui.ugui.UIBaseWindow.CloseWinsType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UIType[]))
			{
			    xc.ui.ugui.UIType[] array = obj as xc.ui.ugui.UIType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.UIWidgetHelp.DragDropGroup[]))
			{
			    xc.ui.UIWidgetHelp.DragDropGroup[] array = obj as xc.ui.UIWidgetHelp.DragDropGroup[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.ui.ugui.UINoticeWindow.EWindowType[]))
			{
			    xc.ui.ugui.UINoticeWindow.EWindowType[] array = obj as xc.ui.ugui.UINoticeWindow.EWindowType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.GoodsHelper.ItemMainType[]))
			{
			    xc.GoodsHelper.ItemMainType[] array = obj as xc.GoodsHelper.ItemMainType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.TaskDefine.EAutoRunType[]))
			{
			    xc.TaskDefine.EAutoRunType[] array = obj as xc.TaskDefine.EAutoRunType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.VoiceControlComponent.State[]))
			{
			    xc.VoiceControlComponent.State[] array = obj as xc.VoiceControlComponent.State[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.EquipBaptizeInfo.EquipBaptizeState[]))
			{
			    xc.EquipBaptizeInfo.EquipBaptizeState[] array = obj as xc.EquipBaptizeInfo.EquipBaptizeState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.InteractiveType[]))
			{
			    xc.InteractiveType[] array = obj as xc.InteractiveType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.FriendType[]))
			{
			    xc.FriendType[] array = obj as xc.FriendType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.MailInfo.JumpType[]))
			{
			    xc.MailInfo.JumpType[] array = obj as xc.MailInfo.JumpType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.SceneHelp.LoadQuadTreeSceneState[]))
			{
			    xc.SceneHelp.LoadQuadTreeSceneState[] array = obj as xc.SceneHelp.LoadQuadTreeSceneState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.InstanceManager.InstaneOpenState[]))
			{
			    xc.InstanceManager.InstaneOpenState[] array = obj as xc.InstanceManager.InstaneOpenState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.InstanceManager.ERewardState[]))
			{
			    xc.InstanceManager.ERewardState[] array = obj as xc.InstanceManager.ERewardState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.EHookRangeType[]))
			{
			    xc.EHookRangeType[] array = obj as xc.EHookRangeType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(xc.CustomDataType[]))
			{
			    xc.CustomDataType[] array = obj as xc.CustomDataType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
            return false;
		}
		
		static StaticLuaCallbacks()
        {
            genTryArrayGetPtr = __tryArrayGet;
            GenTryArraySetPtr = __tryArraySet;
        }
	}
}