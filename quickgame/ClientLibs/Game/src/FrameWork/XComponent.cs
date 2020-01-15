using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SGameEngine;

namespace xc
{
    class XComponent : IComponentEmployee
    {
        Dictionary<string, Type> mTypeCache = new Dictionary<string, Type>();

        /// <summary>
        /// 给GameObject添加指定类型的组件
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        public void AddComponent(GameObject owner, string name)
        {
            if (owner != null)
            {
                Type behavior_type = null;
                if(!mTypeCache.TryGetValue(name, out behavior_type))
                {
                    behavior_type = System.Type.GetType(name);
                    if(behavior_type != null)
                        mTypeCache[name] = behavior_type;
                }

                if(behavior_type != null)
                    owner.AddComponent(behavior_type);
            }
        }

        /// <summary>
        /// 点击触碰到角色
        /// </summary>
        /// <param name="hoverObj"></param>
        /// <param name="hitPos"></param>
        public void OnHover(GameObject hover_object, Vector3 hitPos)
        {
            int player_Layer = LayerMask.NameToLayer("Player");// 主角
            int npc_layer = LayerMask.NameToLayer("Npc");// npc
            int chest_layer = LayerMask.NameToLayer("Chest"); // 宝箱
            int monster_layer = LayerMask.NameToLayer("Monster");// 怪物
            int collision_Layer = LayerMask.NameToLayer("Collision"); // 地面
            int inter_object_layer = LayerMask.NameToLayer("InterObject"); //interObject的层级

            int layer = hover_object.layer;
            if (layer == player_Layer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKPLAYER, new CEventBaseArgs(hover_object));
            }
            else if (layer == npc_layer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKNPC, new CEventBaseArgs(hover_object));
            }
            else if (layer == chest_layer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKCHEST, new CEventBaseArgs(hover_object));
            }
            else if (layer == monster_layer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKMONSTER, new CEventBaseArgs(hover_object));
            }
            else if (layer == collision_Layer)
            {
                // CE_CLICKCOLLISION事件在Lua下响应，不带参数
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKCOLLISION, null);
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKCOLLISION_INFO, new CEventBaseArgs(hitPos));
            }
            else if (layer == inter_object_layer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CLICKINTEROBJECTLAYER, new CEventBaseArgs(hover_object));
            }
        }

        /// <summary>
        /// 主角被场景遮挡的状态发生变化
        /// </summary>
        /// <param name="status"></param>
        public void OnCover(bool status)
        {
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_COVER_STATE_CHANGE, new CEventBaseArgs(status));
        }

        /// <summary>
        /// 获取当前预览的物体，更新预览界面的角色灯光
        /// </summary>
        public void UpdatePreviewLight(GameObject preview_object)
        {
            var role_ids = GameConstHelper.GetUintList("GAME_AVAILABLE_ROLE_ID");
            var type_ids = new List<uint>(role_ids.Count);
            foreach(var rid in role_ids)
            {
                type_ids.Add(ActorHelper.RoleIdToTypeId(rid));
            }

            uint actor_type_id = 0;
            var client_model = preview_object.GetComponentInChildren<ActorMono>(true);
            if(client_model != null && client_model.BindActor != null)
            {
                actor_type_id = client_model.BindActor.TypeIdx;
            }

            if(type_ids.Contains(actor_type_id))
            {
                PreviewLight.SelectLight(0,ActorHelper.TypeIdToRoleId(actor_type_id));
            }
            else
            {
                PreviewLight.SelectLight(0,0);
            }
        }

        public Camera GetUICamera()
        {
            return xc.ui.ugui.UIMainCtrl.MainCam;
        }

        public UnityEngine.Object GetEmojiTxt(EmojiText.EmojiMaterialType material_type)
        {
            if (material_type == EmojiText.EmojiMaterialType.EquipTips)
                return MainGame.mEmojiTxt_equipTips;
            else
                return MainGame.mEmojiTxt;
        }

        public void FireNotTouchUIEvent(GameObject hoverObj)
        {
            if ( (hoverObj != null && hoverObj.layer != LayerMask.NameToLayer("UI"))|| hoverObj == null)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TOUCH_NOT_UI, null);
            }
        }

        /// <summary>
        /// 显示PreviewTexture中的反射平面
        /// </summary>
        /// <param name="inst_id"></param>
        public void ShowReflectionPlane(int inst_id, Vector3 pos)
        {
            m_IsShow = true;

            GameObject plane_reflection = GetCurrentObject(inst_id);
            if (plane_reflection != null)
            {
                plane_reflection.SetActive(true);
                plane_reflection.transform.position = pos;
                return;
            }

            if (m_IsLoadingRes == false)
            {
                string path = string.Format("Assets/{0}", ResPath.PlaneReflection);
                m_IsLoadingRes = true;
                ResourceLoader.Instance.StartCoroutine(LoadReflectionPlane(path, inst_id, pos));
            }
        }

        /// <summary>
        /// 销毁某一反射平面的物体
        /// </summary>
        /// <param name="inst_id"></param>
        public void DestroyReflectionPlane(int inst_id)
        {
            m_IsShow = false;
            RemoveObject(inst_id);
        }

        Dictionary<int,GameObject> m_PlaneReflectionMap = new Dictionary<int,GameObject>();

        /// <summary>
        /// 获取当前的反射平面的物体
        /// </summary>
        /// <param name="inst_id"></param>
        /// <returns></returns>
        GameObject GetCurrentObject(int inst_id)
        {
            GameObject obj = null;
            m_PlaneReflectionMap.TryGetValue(inst_id, out obj);
            return obj;
        }

        /// <summary>
        /// 设置当前的反射平面的物体
        /// </summary>
        /// <param name="inst_id"></param>
        /// <param name="obj"></param>
        void SetCurrentObject(int inst_id, GameObject obj)
        {
            if(obj != null)
            {
                obj.transform.position = Vector3.zero;
                m_PlaneReflectionMap[inst_id] = obj;
            }
        }

        /// <summary>
        /// 移除当前反射平面的物体
        /// </summary>
        /// <param name="inst_id"></param>
        /// <returns></returns>
        bool RemoveObject(int inst_id)
        {
            GameObject inst_obj = GetCurrentObject(inst_id);
            if (inst_obj != null)
            {
                GameObject.Destroy(inst_obj);
                m_PlaneReflectionMap.Remove(inst_id);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否正在加载资源过程中
        /// </summary>
        bool m_IsLoadingRes = false;
        bool m_IsShow = false;

        IEnumerator LoadReflectionPlane(string path,int inst_id, Vector3 pos)
        {
            PrefabResource pr = new PrefabResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_prefab(path, pr));
            GameObject obj = pr.obj_;
            if(obj != null)
                SetCurrentObject(inst_id, obj);

            m_IsLoadingRes = false;

            if(m_IsShow)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                    obj.transform.position = pos;
                }
            }
        }

        public void HideReflectionPlane(int inst_id)
        {
            m_IsShow = false;

            // 如果在销毁的时候，还在加载资源，则需要在加载资源后再销毁
            if (m_IsLoadingRes)
                return;

            GameObject obj = GetCurrentObject(inst_id);
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        public uint GetWarType()
        {
            DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
            if (instanceInfo != null)
            {
                return instanceInfo.mWarType;
            }

            return 0;
        }

        public uint GetWarSubType()
        {
            DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
            if (instanceInfo != null)
            {
                return instanceInfo.mWarSubType;
            }

            return 0;
        }


        /// <summary>
        /// 判断是否需要额外控制组件的可见性
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// 
        /// <param name="can_set_visible">是否设置可见性</param>
        /// <param name="new_visible">最新的可见性；（注：只有当 can_set_visible 为 true 时，才有效）</param>
        public void CheckCanShowComponent(uint war_type, uint war_sub_type, string special_flag_str, ref bool can_set_visible, ref bool new_visible)
        {
            can_set_visible = false;
            new_visible = false;

            if (special_flag_str == "ExitButton")
            {
                if (war_type != GameConst.WAR_TYPE_WILD)
                {
                    return;
                }

                if (war_type == GameConst.WAR_TYPE_WILD && DBInstanceTypeControl.Instance.GetCanExit(war_type, war_sub_type))
                {
                    new_visible = true;
                    can_set_visible = true;
                    return;
                }
                can_set_visible = false;
                return;
            }
            else if (special_flag_str == "TaskAndTeam")
            {
                if (war_type == GameConst.WAR_TYPE_DUNGEON && war_sub_type == GameConst.WAR_SUBTYPE_WORLD_BOSS_EXPERIENCE)
                {
                    new_visible = true;
                    can_set_visible = true;
                    return;
                }
                else if (war_type == GameConst.WAR_TYPE_DUNGEON && war_sub_type == GameConst.WAR_SUBTYPE_WORLD_BOSS_FIRST)
                {
                    new_visible = true;
                    can_set_visible = true;
                    return;
                }
                else if (war_type == GameConst.WAR_TYPE_DUNGEON && war_sub_type == GameConst.WAR_SUBTYPE_LORD_COME) // 魔王降临
                {
                    new_visible = true;
                    can_set_visible = true;
                    return;
                }
            }


        }

        /// <summary>
        /// 当选中某一UI控件
        /// </summary>
        /// <param name="select_ui"></param>
        /// <param name="image_name"></param>
        public void OnSelectUI(Selectable select_ui, string sprite_name, string check_sprite_name)
        {
            if (select_ui != null && (string.IsNullOrEmpty(sprite_name) == false || string.IsNullOrEmpty(check_sprite_name) == false))
            {
                AudioManager.Instance.OnSelectUI(select_ui, sprite_name, check_sprite_name);
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.SELECT_UI, new CEventEventParamArgs(select_ui, sprite_name, check_sprite_name));
        }

        public GameObject GetRedPointGameObj()
        {
            return ui.ugui.UIManager.Instance.UICache.GetRedPointGameObj();
        }

        public GameObject GetLockIconGameObj()
        {
            return ui.ugui.UIManager.Instance.UICache.GetLockIconGameObj();
        }

        public GameObject GetNewMarkerGameObj()
        {
            return ui.ugui.UIManager.Instance.UICache.GetNewMarkerGameObj();
        }

        public GameObject GetPreivewBackGround()
        {
            return ui.ugui.UIManager.Instance.UICache.GetPreivewBackGround();
        }
        public int GetClientEvent_REDPOINT_BIND()
        {
            return (int)xc.ClientEvent.CE_NEW_REDPOINT_BIND;
        }
        public int GetClientEvent_REDPOINT_UNBIND()
        {
            return (int)xc.ClientEvent.CE_NEW_REDPOINT_UNBIND;
        }



        public int GetClientEvent_Lock_Bind()
        {
            return (int)xc.ClientEvent.CE_LOCK_ICON_BIND;
        }
        public int GetClientEvent_Lock_UnBind()
        {
            return (int)xc.ClientEvent.CE_LOCK_ICON_UNBIND;
        }
        public void ClickLockIcon(uint systemId)
        {
            xc.LockIconDataMgr.GetInstance().HandleLockIcon(systemId);
        }

        public int GetClientEvent_New_Marker_Bind()
        {
            return (int)xc.ClientEvent.CE_NEW_MARKER_BIND;
        }

        public int GetClientEvent_New_Marker_Unbind()
        {
            return (int) xc.ClientEvent.CE_NEW_MARKER_UNBIND;
        }

        public bool GetRedPointVisible(uint id)
        {
            return RedPointDataMgr.Instance.GetRedPointVisible(id);
        }

        public void FireClientEvent(int event_id, object param)
        {
            ClientEventMgr.Instance.FireEvent(event_id, new CEventBaseArgs(param));
        }

        /// <summary>
        /// 获取屏幕位置处碰撞到的UI物体
        /// </summary>
        public GameObject GetRaycastObj(Vector3 inPos, UnityEngine.EventSystems.PointerEventData eventDataCurrentPosition, List<GameObject> excludeGameObjects)
        {
            return UGUIMath.GetRaycastObj(inPos, eventDataCurrentPosition, excludeGameObjects);
        }

        /// <summary>
        /// 新手引导是否暂停
        /// </summary>
        /// <returns></returns>
        public bool GuideIsPause()
        {
            return GuideManager.Instance.IsPause;
        }

        /// <summary>
        /// 是否在新手开放中
        /// </summary>
        /// <returns></returns>
        public bool SysOpenIsWaiting()
        {
            return SysConfigManager.Instance.IsWaiting();
        }

        /// <summary>
        /// 是否有新手引导
        /// </summary>
        /// <returns></returns>
        public bool HavePlayingGuides()
        {
            return GuideManager.Instance.GetPlayingGuides().Count > 0;
        }

        /// <summary>
        /// 系统按钮是否显示锁
        /// </summary>
        /// <returns></returns>
        public bool IsSysBtnShowLock(uint sysId)
        {
            return !SysConfigManager.Instance.CheckSysHasOpened(sysId, false) && DBSysConfig.Instance.IsShowLock(sysId);
        }

        /// <summary>
        /// 图片置灰(go上要绑定GreyMaterialComponent组件)
        /// </summary>
        /// <returns></returns>
        public void SetGrey(GameObject go, bool grey)
        {
            GreyMaterialComponent greyComponent = go.GetComponent<GreyMaterialComponent>();
            if (greyComponent != null)
            {
                greyComponent.IsGrey = grey;
            }
        }

        public void SetMajiaPath(GameObject go, string path, bool isNative)
        {
            LoadMaJiaImage majiaImage = go.GetComponent<LoadMaJiaImage>();
            if (majiaImage == null)
            {
                majiaImage = go.AddComponent<LoadMaJiaImage>();
                majiaImage.mPath = path;
                majiaImage.mIsNativeSize = isNative;
            }
        }

        public string GetTranslatedStr(String rawContent)
        {
            string content = DBTranslate.Instance.GetTranslateText("", rawContent);
            return content;
        }

        public void setLocaleLanguage(string lan)
        {
            var bridge = DBOSManager.getDBOSManager().getBridge();
            bridge.setLocaleLanguage(lan);
        }

        public string getLocaleLanguage()
        {
            var bridge = DBOSManager.getDBOSManager().getBridge();
            return bridge.getLocaleLanguage();
        }

        public void PostResDownloadFailPlayerFollowRecord(string desc)
        {
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ResDownloadFail, desc, false);
        }

        public string AESEncode(string text, string key, string iv)
        {
            return Utils.AES.Encode(text, key, iv);
        }

        public string AESDecode(string text, string key, string iv)
        {
            return Utils.AES.Decode(text, key, iv);
        }
    }
}
