//--------------------------------
// File : InterObject.cs
// Desc： 互动物体的基类
// Author: raorui
// Date: 2017.7.20
//-------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;
using static UI3DText;

namespace xc
{
    [wxb.Hotfix]
    public class InterObject
    {
        public InterObject()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, OnSceneLoaded);
        }

        protected UI3DText mNameComponent = null;
        public StyleInfo m_StyleInfo;
        string m_name_label = string.Empty;

        private bool m_isVisible = true;

        private Vector3 mCachePos = Vector3.zero;
        private bool mIsInEndFrameSetVisible = false;
        float m_collider_radius = 0.66f;
        float m_collider_height = 2.6f;
        Vector3 m_collider_center = new Vector3(0, 1.3f, 0);
        public bool IsVisible
        {
            set
            {
                m_isVisible = value;
                if (m_ModelParent != null && m_Model != null)
                {
                    //if(m_isVisible == false)
                    m_ModelParent.SetActive(m_isVisible);
                    if(m_isVisible)
                    {
                        Animator[] animation_array = m_Model.GetComponentsInChildren<Animator>();
                        foreach (Animator item in animation_array)
                        {
                            item.Play("die", 0, 1);
                            item.speed = 0;
                            item.cullingMode = AnimatorCullingMode.AlwaysAnimate;
                        }
                        
                        m_ModelParent.transform.position = new Vector3(100000, 100000, 0);
                        mIsInEndFrameSetVisible = true;
                        ActorManager.Instance.StartCoroutine(EndFrameSetVisible());
                        //m_ModelParent.SetActive(m_isVisible);
                    }
                }
            }
        }

        public IEnumerator EndFrameSetVisible()
        {
            yield return new WaitForEndOfFrame();
            if(m_ModelParent != null)
            {
                m_ModelParent.transform.position = mCachePos;
                FixPos();
            }
            mIsInEndFrameSetVisible = false;
        }
        /// <summary>
        /// 是否已经被销毁
        /// </summary>
        bool m_IsDestory = false;

        public void OnCreate()
        {
            m_StyleInfo = new StyleInfo();
        }


        public void Destroy()
        {
            if (m_IsDestory)
                return;

            if (null != mNameComponent)
            {
                UnityEngine.GameObject.Destroy(mNameComponent);
                mNameComponent = null;
            }

            m_IsDestory = true;
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, OnSceneLoaded);
            DestroyModle();
        }

        /// <summary>
        /// 模型的资源路径
        /// </summary>
        string m_ResPath = "";

        /// <summary>
        /// 根节点的物体
        /// </summary>
        GameObject m_ModelParent;

        /// <summary>
        /// 模型物体
        /// </summary>
        GameObject m_Model;

        public GameObject Model
        {
            get { return m_Model; }
        }

        public GameObject ModelParent
        {
            get { return m_ModelParent; }
        }

        public void CreateModel(string res_path, Vector3 pos, Quaternion rot, Vector3 scale)
        {
            InitEmptyModel(pos, rot, scale);

            m_ResPath = res_path;
            ResourceLoader.Instance.StartCoroutine(LoadModel(m_ResPath));
        }

        public void NotifyTriggerEnter(Collider other)
        {

        }

        public void NotifyTriggerExit(Collider other)
        {

        }

        public void InitEmptyModel(Vector3 pos, Quaternion rot, Vector3 scale)
        {
            if (m_ModelParent != null)
                return;

            GameObject go_parent = new GameObject();
            go_parent.name = "InterObjectParent";
            m_ModelParent = go_parent;
            GameObject.DontDestroyOnLoad(m_ModelParent);

            Transform tans = go_parent.transform;
            tans.position = pos;
            FixPos();
            tans.rotation = rot;
            tans.localScale = scale;
            //go_parent.layer = LayerMask.NameToLayer("InterObject");

            ResetLayer();
            //xc.ui.ugui.UIHelper.SetLayer(m_ModelParent.transform, LayerMask.NameToLayer("Monster"));
            //xc.ui.ugui.UIHelper.SetLayer(m_ModelParent.transform, LayerMask.NameToLayer("InterObject"));

            // 没加载模型的时候也要可以点击
            var collider = go_parent.AddComponent<CapsuleCollider>();
            collider.radius = m_collider_radius;
            collider.height = m_collider_height;
            collider.center = m_collider_center;
            collider.isTrigger = true;

            InterObjectMono mono = go_parent.AddComponent<InterObjectMono>();
            mono.BindObject = this;


        }

        public void ResetLayer()
        {
            int layer = LayerMask.NameToLayer("InterObject");
            m_ModelParent.layer = layer;
            for (int index = 0; index < m_ModelParent.transform.childCount; ++index)
            {
                Transform child = m_ModelParent.transform.GetChild(index);
                xc.ui.ugui.UIHelper.SetLayer(child.transform, LayerMask.NameToLayer("Monster"));
                child.gameObject.layer = layer;
            }
        }

        /// <summary>
        /// 加载模型物体
        /// </summary>
        public IEnumerator LoadModel(string res_path)
        {
            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(res_path, typeof(Object), ar));
            if (ar.asset_ == null)
            {
                GameDebug.LogError(string.Format("the res {0} does not exist", res_path));
                yield break;
            }
//             while(true)
//             {
//                 yield return null;
//             }
            if(!m_IsDestory)
            {
                ResourceUtilEx.Instance.host_res_to_gameobj(m_ModelParent, ar);// 将asset资源的生命周期与GameObject关联起来

                GameObject model_object = GameObject.Instantiate(ar.asset_) as GameObject;
                SetModel(model_object);
            }
            else
            {
                ar.destroy();
            }
        }

        public void SetModel(GameObject model)
        {
            m_Model = model;

            Transform model_trans = model.transform;

            model_trans.parent = m_ModelParent.transform;
            model_trans.localPosition = Vector3.zero;
            model_trans.localRotation = Quaternion.identity;
            model_trans.localScale = Vector3.one;

            if (mNameComponent == null)
                mNameComponent = m_Model.AddComponent<UI3DText>();
            
            if (m_StyleInfo != null)
                mNameComponent.ResetStyleInfo(m_StyleInfo);

            Transform mHeadTrans = ModelHelper.FindChildInHierarchy(model_trans, Actor.SlotHeadName);
            mNameComponent.SetHeadTrans(mHeadTrans);

            SetNameLabel(m_name_label);

            //石化效果
            Renderer[] renderes = m_Model.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderes)
            {
                if (r.sharedMaterial == null)
                {
                    continue;
                }

                string tag_name = r.gameObject.tag;// 只有标记tag的节点才替换材质
                if (tag_name.ToLower() != "matreplace")
                    continue;
                Material tmp_r = r.material;
                r.material = MaterialEffectCtrl.MAT_TOMB_STONE;// 将原始材质修改为STONE的材质
                r.material.mainTexture = tmp_r.mainTexture;// texture赋值
                if (r.material.HasProperty("_Normal") && tmp_r.HasProperty("_Normal"))
                    r.material.SetTexture("_Normal", tmp_r.GetTexture("_Normal"));// normalmap texture
                r.material.SetFloat("_StoneProgress", 0);
            }

            List<GameObject> ef_link_array;
            ui.ugui.UIHelper.FindAllChildrenInHierarchy_out(m_ModelParent.transform, "EF_BOSS_LINK", out ef_link_array);
            for (int index = 0; index < ef_link_array.Count; ++index)
            {
                if(ef_link_array[index] != null)
                    ef_link_array[index].gameObject.SetActive(false);
            }

            //xc.ui.ugui.UIHelper.SetLayer(m_ModelParent.transform, LayerMask.NameToLayer("InterObject"));
            ResetLayer();
            IsVisible = m_isVisible;
        }

        public void DestroyModle()
        {
            if (m_ModelParent != null)
                GameObject.Destroy(m_ModelParent);
        }

        public void OnSceneLoaded(CEventBaseArgs data)
        {
            if (m_ModelParent == null)
                return;

            FixPos();
        }

        public void FixPos()
        {
            Transform trans = m_ModelParent.transform;
            trans.position = PhysicsHelp.GetPosition(trans.position.x, trans.position.z);
            //trans.position = InstanceHelper.ClampInWalkableRange(trans.position);

            //if (Mathf.Approximately(trans.position.y, PhysicsHelp.ILLEGAL_HEIGHT))
            //{
            //    GameDebug.LogWarning(string.Format("InterObject ILLEGAL_HEIGHT {0}", trans.position.ToString()));
            //    trans.position = InstanceHelper.ClampInWalkableRange(trans.position);
            //}
        }

        public void SetNameLabel(string txt)
        {
            m_name_label = txt;
            if (mNameComponent != null)
                mNameComponent.Text = m_name_label;
        }

        public void SetPosAndQuaternion(Vector3 pos, Quaternion model_Quaternion)
        {
            if (m_ModelParent == null)
                return;
            mCachePos = pos;
            if (mIsInEndFrameSetVisible == false)
            {
                m_ModelParent.transform.position = pos;
                FixPos();
            }
            m_ModelParent.transform.rotation = model_Quaternion;

        }
        
        public void SetCollider(Vector3 center, float radius)
        {
            m_collider_center = center;
            m_collider_radius = radius;
            if(m_ModelParent != null)
            {
                var collider = m_ModelParent.GetComponent<CapsuleCollider>();
                collider.radius = m_collider_radius;
                collider.height = m_collider_height;
                collider.center = m_collider_center;
                collider.isTrigger = true;
            }
        }
    }
}
