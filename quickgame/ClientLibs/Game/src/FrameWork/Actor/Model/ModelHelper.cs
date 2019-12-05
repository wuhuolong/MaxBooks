using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class ModelHelper
    {
        public static ModelInfo GetModel(uint id)
        {
            DBModel dbModel = DBManager.GetInstance().GetDB<DBModel>();

            return dbModel.GetModel(id);
        }

        public static string GetModelPrefab(uint id, bool is_ui_model = false)
        {
            ModelInfo info = GetModel(id);

            if(info != null)
            {
                if (is_ui_model)
                {
                    if (QualitySetting.GraphicLevel == 2) // 低配
                        return info.Model;
                    else if (string.IsNullOrEmpty(info.UIModel) == false)
                        return info.UIModel;
                    else
                        return info.Model;
                }
                return info.Model;
            }

            return string.Empty;
        }

        public static string GetModelIcon(uint id)
        {
            ModelInfo info = GetModel(id);

            if (info != null)
            {
                return info.Icon;
            }

            return string.Empty;
        }

        public static float GetModelScale(uint id)
        {
            ModelInfo info = GetModel(id);

            if (info != null)
            {
                return info.Scale;
            }

            return 1f;
        }

        public static Vector3 GetModelCamOffsetInDialogWnd(uint id)
        {
            ModelInfo info = GetModel(id);

            if (info != null)
            {
                return info.CamOffsetInDialogWnd;
            }

            return Vector3.zero;
        }

        public static Vector3 GetModelCamRotateInDialogWnd(uint id)
        {
            ModelInfo info = GetModel(id);

            if (info != null)
            {
                return info.CamRotateInDialogWnd;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// 查找到属于这个节点下面的子节点(无论多深)
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Transform FindChildInHierarchy(Transform parent, string name)
        {
            if (parent == null)
                return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform childTrans = parent.GetChild(i);
                if (childTrans.name == name)
                    return childTrans;
                else
                {
                    Transform t = FindChildInHierarchy(childTrans, name);
                    if (t != null)
                        return t;
                }
            }

            return null;
        }

        /// <summary>
        /// 查找到属于这个节点下面的子节点(无论多深)绑定的Component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T FindChildComponentInHierarchy<T>(Transform parent, string name) where T : Component
        {
            Transform target = FindChildInHierarchy(parent, name);

            if(target != null)
            {
                return target.GetComponent<T>();
            }

            return null;
        }

        /// <summary>
        /// 将一个节点的子节点都转换到另外一个节点上
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void TransferChildrenNode(Transform target, Transform source)
        {
            if(target == null || source == null)
            {
                return;
            }

            List<Transform> childrens = new List<Transform>();
            List<Vector3> localPositions = new List<Vector3>();
            List<Quaternion> localRotations = new List<Quaternion>();
            List<Vector3> localScales = new List<Vector3>();

            for(int i = 0; i < source.childCount; i++)
            {
                Transform child = source.GetChild(i);

                childrens.Add(child);

                localPositions.Add(child.localPosition);
                localRotations.Add(child.localRotation);
                localScales.Add(child.localScale);
            }

            int index = 0;
            foreach(var itr in childrens)
            {
                itr.parent = target;
                itr.localPosition = localPositions[index];
                itr.localRotation = localRotations[index];
                itr.localScale = localScales[index];

                ++index;
            }
        }

        /// <summary>
        /// 转移一个节点模型资源到另外一个节点
        /// </summary>
        /// <param name="targetTrans"></param>
        /// <param name="sourceTrans"></param>
        public static void TransferMesh(Transform targetTrans, Transform sourceTrans)
        {
            if(targetTrans == null || sourceTrans == null)
            {
                return;
            }

            targetTrans.localPosition = sourceTrans.localPosition;
            targetTrans.localRotation = sourceTrans.localRotation;
            targetTrans.localScale = sourceTrans.localScale;

            // 替换Renderer
            Renderer sourceRenderer = sourceTrans.GetComponent<Renderer>();
            MeshRenderer sourceMeshRenderer = sourceRenderer as MeshRenderer;
            SkinnedMeshRenderer sourceSkinnedRenderer = sourceRenderer as SkinnedMeshRenderer;

            if(sourceMeshRenderer != null)
            {
                MeshRenderer targetMeshRenderer = targetTrans.GetComponent<MeshRenderer>();

                if(targetMeshRenderer == null)
                {
                    targetMeshRenderer = targetTrans.gameObject.AddComponent<MeshRenderer>();
                }

                MeshFilter targetMeshFilter = targetTrans.GetComponent<MeshFilter>();

                if(targetMeshFilter == null)
                {
                    targetMeshFilter = targetTrans.gameObject.AddComponent<MeshFilter>();
                }

                MeshFilter sourceMeshFilter = sourceTrans.GetComponent<MeshFilter>();

                targetMeshFilter.mesh = sourceMeshFilter.mesh;
                targetMeshRenderer.materials = sourceMeshRenderer.materials;
            }
            else if (sourceSkinnedRenderer != null)
            {
                SkinnedMeshRenderer targetSkinnedRenderer = targetTrans.GetComponent<SkinnedMeshRenderer>();

                if (targetSkinnedRenderer == null)
                {
                    targetSkinnedRenderer = targetTrans.gameObject.AddComponent<SkinnedMeshRenderer>();
                }

                Transform[] transforms = targetTrans.GetComponentsInChildren<Transform>();

                List<Material> materials = new List<Material>();
                List<Transform> bones = new List<Transform>();

                materials.AddRange(sourceSkinnedRenderer.materials);

                //Transform rootBone = null;
                //string rootBoneName = sourceSkinnedRenderer.rootBone.name;

                // 每个顶点相关的骨头矩阵必须按照源模型的骨头顺序一样，这样才能保证shader中利用索引查找出的矩阵正确
                foreach (Transform bone in sourceSkinnedRenderer.bones)
                {
                    if (bone == null)
                        continue;

                    foreach (Transform transform in targetSkinnedRenderer.bones)
                    {
                        //通过名字找到实际的骨骼
//                         if(transform.name == rootBoneName)
//                         {
//                             rootBone = transform;
//                         }

                        if (transform.name != bone.name)
                            continue;
                        bones.Add(transform);
                        break;
                    }
                }

                targetSkinnedRenderer.sharedMesh = sourceSkinnedRenderer.sharedMesh;           
                targetSkinnedRenderer.bones = bones.ToArray();
                targetSkinnedRenderer.materials = materials.ToArray();
                //targetSkinnedRenderer.rootBone = rootBone;

                //targetSkinnedRenderer.rootBone = sourceSkinnedRenderer.rootBone;
                //targetSkinnedRenderer.localBounds = sourceSkinnedRenderer.localBounds;
                //targetSkinnedRenderer.updateWhenOffscreen = sourceSkinnedRenderer.updateWhenOffscreen;
                //targetSkinnedRenderer.quality = sourceSkinnedRenderer.quality;
            }

            // 替换子节点(可能武器上绑定了特效)
            while (targetTrans.childCount > 0)
            {
                Transform child = targetTrans.GetChild(0);
                child.parent = null;
                GameObject.Destroy(child.gameObject);
            }

            targetTrans.DetachChildren();

            for (int i = 0; i < sourceTrans.childCount; ++i)
            {
                Transform child = sourceTrans.GetChild(i);
                Vector3 localPos = child.localPosition;
                Quaternion localRot = child.localRotation;
                Vector3 localScl = child.localScale;

                child.parent = targetTrans;
                child.localPosition = localPos;
                child.localRotation = localRot;
                child.localScale = localScl;
            }
        }

        /// <summary>
        /// 清除模型节点的信息
        /// </summary>
        /// <param name="node"></param>
        public static void ClearMeshNode(Transform node)
        {
            if(node == null)
            {
                return;
            }

            while (node.childCount > 0)
            {
                Transform child = node.GetChild(0);
                child.parent = null;
                GameObject.Destroy(child.gameObject);
            }

            Renderer renderer = node.GetComponent<Renderer>();

            if(renderer != null)
            {
                UnityEngine.Object.DestroyImmediate(renderer);
                renderer = null;
            }

            MeshFilter meshFilter = node.GetComponent<MeshFilter>();

            if(meshFilter != null)
            {
                UnityEngine.Object.DestroyImmediate(meshFilter);
                meshFilter = null;
            }
        }

        public static void ClearChildren(Transform node)
        {
            if (node == null)
            {
                return;
            }

            while (node.childCount > 0)
            {
                Transform child = node.GetChild(0);
                child.parent = null;
                GameObject.Destroy(child.gameObject);
            }

            node.DetachChildren();
        }

        public static void ClearChildren(GameObject node)
        {
            if(node == null)
            {
                return;
            }

            ClearChildren(node.transform);
        }

        public static void SetMeshNodeToGray(Transform node)
        {
            if(node == null)
            {
                return;
            }

            SkinnedMeshRenderer[] renderers = node.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (var item in renderers)
            {
                if(item == null)
                {
                    continue;
                }

                Material material = item.material;

                if(material == null)
                {
                    continue;
                }

                material.shader = Shader.Find("Custom/GrayTexture");
            }
        }

        public static void SetMeshNodeToCommonColor(Transform node)
        {
            if (node == null)
            {
                return;
            }

            SkinnedMeshRenderer[] renderers = node.GetComponentsInChildren<SkinnedMeshRenderer>(true);

            foreach (var item in renderers)
            {
                if (item == null)
                {
                    continue;
                }

                Material material = item.material;

                if (material == null)
                {
                    continue;
                }

                material.shader = Shader.Find("Simple/SHLight");
            }
        }

        public static void SetActorScale(Actor actor, float modelScale, Vector2 modelOffset, bool isPlayer, UIPreviewTexture previewTexture)
        {
            if (actor != null && actor.MoveImplement != null)
            {
                actor.transform.rotation = new Quaternion(0f, 180f, 0f, 1f);
                actor.Play("idle");

                var actorRq = actor.gameObject.AddComponent<ActorRenderqueueComponent>();
                actorRq.ExplicitRenderQueue = 4000;

                int layer = LayerMask.NameToLayer("UI");
                actor.gameObject.layer = layer;
                CommonTool.SetChildLayer(actor.transform, layer);

                // 设置模型缩放和位置
                Vector3 scale = actor.transform.localScale * modelScale;
                if (isPlayer)
                {
                    if (actor.MoveImplement.CharacterRadius > 0f)
                    {
                        scale = scale * 0.375f / actor.MoveImplement.CharacterRadius;
                    }
                    previewTexture.CameraPosOffset = new Vector3(0f, 1.5f, -4.5f);
                }
                else
                {
                    if (actor.MoveImplement.CharacterRadius > 0f)
                    {
                        scale = scale * 1f / actor.MoveImplement.CharacterRadius;
                    }
                    previewTexture.CameraPosOffset = new Vector3(0f, 1.09f, -4.37f);

                    Vector3 oldOffset = previewTexture.CameraPosOffset;
                    previewTexture.CameraPosOffset = new Vector3(oldOffset.x + modelOffset.x, oldOffset.y + modelOffset.y, oldOffset.z);
                }
                actor.transform.localScale = scale;

                //actor.transform.position = new Vector3(mActorParentTransform.position.x + mDialogContentInfo.x, mActorParentTransform.position.y + mDialogContentInfo.y, mActorParentTransform.position.z);
            }
        }
    }
}
