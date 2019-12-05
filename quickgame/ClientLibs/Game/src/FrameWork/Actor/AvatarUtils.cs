using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    class AvatarUtils
    {
        //剧情换装
        public static IEnumerator ChangeModel(GameObject model, AvatarProperty ap,bool isLocalPlayer = true)
        {
            if (ap == null)
                yield break;

            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(model, ap.BodyId, isLocalPlayer));
            yield return ResourceLoader.Instance.StartCoroutine(ChangePart(model, ap.WeaponId, isLocalPlayer));
            yield return ResourceLoader.Instance.StartCoroutine(SetSuitEffect(model, ap, isLocalPlayer));

        }

        private static IEnumerator ChangePart(GameObject model, uint partId, bool isLocalPlayer = true)
        {
            if(model == null)
            {
                yield break;
            }

            DBAvatarPart.Data data = DBManager.Instance.GetDB<DBAvatarPart>().mData[partId];
            string part_name = data.part == DBAvatarPart.BODY_PART.BODY ? xc.AvatarCtrl.BODY_NAME : xc.AvatarCtrl.WEAPON_NAME;

            // 查找旧资源中的换装节点
            Transform old_part = CommonTool.FindChildInHierarchy(model.transform, part_name);
            if (old_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", model.name, part_name));
                yield break;
            }
            string path = data.SuitablePath(isLocalPlayer);
            // 加载换装部件的模型
            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(string.Format("{0}/{1}.prefab", xc.AvatarCtrl.AVATAR_PATH_PREFIX, path), typeof(GameObject), ar));
            GameObject gameObjectAsset = ar.asset_ as GameObject;
            if (gameObjectAsset == null)
            {
                Debug.LogError(string.Format("the res {0} does not exist", path));
                yield break;
            }

            if (model == null)
            {
                ar.destroy();
                yield break;
            }

            old_part = CommonTool.FindChildInHierarchy(model.transform, part_name);
            if (old_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", model.name, part_name));
                ar.destroy();
                yield break;
            }

            // 将asset资源的生命周期与角色GameObject关联起来
            ResourceUtilEx.Instance.host_res_to_gameobj(model, ar);

            // 查找新资源的换装节点
            Transform new_part = CommonTool.FindChildInHierarchy(gameObjectAsset.transform, part_name);
            if (new_part == null)
            {
                Debug.LogError(string.Format("the model {0} does not have a part named {1}", gameObjectAsset.name, part_name));
                yield break;
            }

            SkinnedMeshRenderer new_mesh_renderer = new_part.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer old_mesh_renderer = old_part.GetComponent<SkinnedMeshRenderer>();

            Transform[] old_bones = (Transform[])old_part.GetComponent<SkinnedMeshRenderer>().bones.Clone();
            ReplaceSkinnedMesh(old_bones, model, old_mesh_renderer, new_mesh_renderer);
        }

        /// <summary>
        /// 替换换装部件的蒙皮信息
        /// old_bones : 换装骨骼信息
        /// model : 角色模型对应的GameObject
        /// old_mesh_renderer ： 旧的换装蒙皮网格
        /// new_mesh_renderer ： 新的换装蒙皮网格
        /// </summary>
        private static void ReplaceSkinnedMesh(Transform[] old_bones, GameObject model, SkinnedMeshRenderer old_mesh_renderer, SkinnedMeshRenderer new_mesh_renderer)
        {
            if (old_bones == null || old_mesh_renderer == null || new_mesh_renderer == null)
            {
                return;
            }

            //创建与new_mesh_renderer匹配的骨骼
            Transform[] new_mesh_bones = new_mesh_renderer.bones;
            Transform[] new_bones = new Transform[new_mesh_bones.Length];

            bool found = false;
            for (int i = 0; i < new_mesh_bones.Length; i++)
            {
                var new_bone = new_mesh_bones[i];
                if (new_bone == null)
                {
                    Debug.LogError("new_mesh_bones is invalid");
                    continue;
                }

                found = false;

                //在旧骨骼中查找与new_mesh_renderer中骨骼名字一致的transform
                foreach (Transform old_bone in old_bones)
                {
                    if (old_bone == null)
                    {
                        Debug.LogError("old_bones is invalid");
                        continue;
                    }

                    if (old_bone.name == new_bone.name)
                    {
                        new_bones[i] = old_bone;
                        found = true;
                        break;
                    }
                }

                //如果没找到，则在角色模型的子节点中寻找
                if (!found)
                {
                    Transform[] all = model.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in all)
                    {
                        if (t.name == new_mesh_bones[i].name)
                        {
                            new_bones[i] = t;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Debug.LogError(string.Format("old_bones do not have a bone named {0} when change skinned mesh,make sure they use the same bones, change from {1} to {2}", new_mesh_bones[i].name, old_mesh_renderer.transform.parent.name, new_mesh_renderer.transform.parent.name));
                        return;
                    }
                }
            }

            old_mesh_renderer.sharedMesh = new_mesh_renderer.sharedMesh;
            //TODO: 所有装备的骨骼信息一致时，可以直接使用旧的骨骼
            old_mesh_renderer.bones = new_bones;
            old_mesh_renderer.sharedMaterials = new_mesh_renderer.sharedMaterials;
        }

        /// <summary>
        /// 设置套装特效
        /// </summary>
        /// <param name="effect_id_list"></param>
        /// <returns></returns>
        private static IEnumerator SetSuitEffect(GameObject model, AvatarProperty ap, bool isLocalPlayer = true)
        {
            List<uint> effect_id_list = ap.SuitEffectIds;

            if (effect_id_list == null || effect_id_list.Count == 0 || model == null)
                yield break;

            // 屏蔽特效显示
            /*if (!EnableEffect)
            {
                if (mOwner == null || !mOwner.UID.Equals(Game.GetInstance().LocalPlayerID))
                    yield return null;
            }*/

            //var avartaPartData = DBManager.GetInstance().GetDB<DBAvatarPart>().mData;

            foreach (var id in effect_id_list)
            {
                var effect_id = id;
                if (id == 1 || id == 2)
                {
                    effect_id = id == 1 ? ap.BodyId : ap.WeaponId;
                }

                var effect_info = DBManager.Instance.GetDB<DBSuitEffect>().GetEffectInfo(effect_id);
                if (effect_info == null)
                {
                    GameDebug.Log("Cannot find suit effect info, id: " + effect_id);
                    continue;
                }

                // 检查特效id是否与当前的装备或武器匹配
                if (effect_info.effect_type == 1)
                {
                    if (effect_id != ap.BodyId)
                        continue;
                }
                else if (effect_info.effect_type == 2)
                {
                    if (effect_id != ap.WeaponId)
                        continue;
                }

                bool is_local_player_model = isLocalPlayer;
                foreach (var bind_info in effect_info.bind_infos)
                {
                    // 本地玩家才使用高配的特效
                    string res_path = "";

                    if (is_local_player_model)// 本地玩家
                    {
                        if (QualitySetting.GraphicLevel == 2) // 低配也使用低配特效
                            res_path = ModelHelper.GetModelPrefab(bind_info.low_model_id);
                        else
                            res_path = ModelHelper.GetModelPrefab(bind_info.model_id);
                    }
                    else// 其他玩家
                        res_path = ModelHelper.GetModelPrefab(bind_info.low_model_id);

                    if (string.IsNullOrEmpty(res_path))
                    {
                        GameDebug.LogError("Cannot find suit res info, model_id: " + bind_info.model_id);
                        continue;
                    }

                    var mount_point = CommonTool.FindChildInHierarchy(model.transform, bind_info.bind_node);
                    if (mount_point == null)
                    {
                        GameDebug.LogError("Cannot find suit mount point, bind_node: " + bind_info.bind_node);
                        continue;
                    }

                    ObjectWrapper ow = new ObjectWrapper();
                    yield return ResourceLoader.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(res_path, ObjCachePoolType.SFX, res_path, ow));
                    GameObject effect_object = ow.obj as GameObject;

                    if (effect_object == null)
                    {
                        GameDebug.LogError("Cannot load suit effect point, res_path: " + res_path);
                        continue;
                    }

                    GameObject.DontDestroyOnLoad(effect_object);
                    if (model == null)
                    {
                        ObjCachePoolMgr.Instance.RecyclePrefab(effect_object, ObjCachePoolType.SFX, res_path);
                        break;
                    }

                    //int layer = 0;
                    //if (mModelParent != null)
                    //    layer = mModelParent.layer;
                    //SetRenderLayer(effect_object, layer, false, false);
                    //m_EffectObjs[res_path] = effect_object;

                    var trans = effect_object.transform;
                    trans.parent = mount_point;
                    trans.localPosition = Vector3.zero;
                    trans.localRotation = Quaternion.identity;
                    trans.localScale = Vector3.one;

                    ListTrailRenderer trail_render_list = effect_object.GetComponent<ListTrailRenderer>();
                    if (trail_render_list == null)
                        trail_render_list = effect_object.AddComponent<ListTrailRenderer>();
                    if (trail_render_list != null)
                        trail_render_list.ResetPos();

                    // 设置层级
                    xc.ui.ugui.UIHelper.SetLayer(effect_object.transform, model.layer);
                }
            }
        }



    }
}
