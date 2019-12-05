//----------------------------------
// MatrtialEffectCtrl.cs
// 控制角色材质效果
// @raorui
// 2017.6.7
//----------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using SGameEngine;
namespace xc
{
    [wxb.Hotfix]
    public class MaterialEffectCtrl : BaseCtrl
    {
        public MaterialEffectCtrl(Actor owner)
            : base(owner)
        {
            // 在变身时要恢复角色的材质
            mOwner.SubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);
            // 在换装属性发生变化时要恢复角色的材质
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE, OnAvatarPropertyChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE_BEGIN, OnAvatarPropertyChangeBegin);
        }

        /// <summary>
        /// 角色受击的材质
        /// </summary>
        public static Material MAT_HURT_HIGHLIGHT = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Materials/HurtHighLight.mat") as Material;

        /// <summary>
        /// 角色溶解的材质
        /// </summary>
        public static Material MAT_DEAD_DISSOLVE = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Materials/Dissolve.mat") as Material;

        /// <summary>
        /// Boss死亡后变成墓碑的材质
        /// </summary>
        public static Material MAT_TOMB_STONE = ResourceLoader.Instance.try_load_cached_asset("Assets/" + ResPath.MAT_TOMBSTONE) as Material;

        /// <summary>
        /// 角色勾边的材质
        /// </summary>
        public static Material MAT_OUTLING = ResourceLoader.Instance.try_load_cached_asset("Assets/" + ResPath.MAT_OUTLING) as Material;

        /// <summary>
        /// 材质的类型定义
        /// </summary>
        public enum MAT_TYPE 
        {
            OUTLING,
            HURT_HIGHLIGHT,
            DEAD_DISSOLVE,
            DEAD_TOMBSTONE
        }

        /// <summary>
        /// 材质显示的优先级
        /// </summary>
        public enum Priority //hightest -> lowest
        {
            OUTLING = 0,
            TOMB = 1,
            DEAD = 2,
            HURT = 3,
        }

        /// <summary>
        /// 添加的特效材质的属性
        /// </summary>
        public class MatInfo : IComparable
        {
            public float startTime;//开始的时间
            public float endTime;// 结束的时间
            public MAT_TYPE type;// 材质的类型
            public int priority;// 显示的优先级
            public bool needDelete = false;// 是否需要删除

            public int CompareTo(object obj)
            {
                MatInfo b = obj as MatInfo;
                if (b.priority < priority)// 先比较优先级，priority值越小则优先级越高
                    return 1;
                if (b.priority > priority)
                    return -1;
                else
                {
                    if (b.startTime > startTime)// 比较开始时间，开始时间越晚则优先级越高
                        return 1;
                    else if (b.startTime < startTime)
                        return -1;
                    else
                        return 0;
                }
            }
        }

        /// <summary>
        /// 保存原始材质的参数信息
        /// </summary>
        public class ExtraMatInf
        {
            /// <summary>
            /// 材质的原始颜色
            /// </summary>
            public Color OriColor = Color.white;

            /// <summary>
            /// 是否材质进行过实例化
            /// </summary>
            public bool Instance = false;
        }

        public readonly string MainColorName = "_Color";

        public Dictionary<Renderer, Material> m_InitMat = new Dictionary<Renderer, Material>();// 记录角色的原始材质
        public Dictionary<Renderer, ExtraMatInf> m_InitMatExtra = new Dictionary<Renderer, ExtraMatInf>();// 记录角色原始材质的参数信息
        private List<MatInfo> m_MatList = new List<MatInfo>();// 当前添加的所有材质特效
        private bool m_RecoverState = true;// 是否已经恢复成原始的材质

        /// <summary>
        /// 初始化材质信息
        /// </summary>
        public void InitMat()
        {
            m_InitMat.Clear();
            m_InitMatExtra.Clear();

            if (mOwner == null || mOwner.IsDestroy)
                return;

            var game_obeject = mOwner.gameObject;
            if (game_obeject == null)
                return;

            Renderer[] renderes = mOwner.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderes)
            {
                if (r.sharedMaterial == null)
                {
                    continue;
                }

                string tag_name = r.gameObject.tag;// 只有标记tag的节点才替换材质
                if (tag_name.ToLower() != "matreplace")
                    continue;

                ExtraMatInf mat_info = new ExtraMatInf();
                if (r.sharedMaterial.HasProperty(MainColorName))
                    mat_info.OriColor = r.sharedMaterial.color;
                mat_info.Instance = false;

                m_InitMatExtra.Add(r, mat_info);
                m_InitMat.Add(r, r.sharedMaterial);
            }
        }

        /// <summary>
        /// 添加材质特效
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="pri"></param>
        /// <returns></returns>
        public MatInfo AddEffectMat(float time, MAT_TYPE type, Priority pri)
        {
            MatInfo m = new MatInfo();
            m.startTime = Time.time;
            m.endTime = m.startTime + time;
            m.type = type;
            m.priority = (int)pri;

            m_MatList.Add(m);
            OnMatListChange();
            return m;
        }

        public void RemoveEffectMat(MAT_TYPE type)
        {
            List<int> remove_list = new List<int>();
            int i = 0;
            foreach(var info in m_MatList)
            {
                if(info.type == type)
                {
                    remove_list.Add(i);
                }

                i++;
            }

            for (i = remove_list.Count -1; i >=0; --i )
            {
                m_MatList.RemoveAt(i);
            }

            if(remove_list.Count > 0)
                OnMatListChange();
        }

        /// <summary>
        /// 材质列表发生变化时调用
        /// </summary>
        private void OnMatListChange()
        {
            if (m_InitMat.Count == 0)
                InitMat();

            // 如果材质列表为空，则恢复原始的材质
            if (m_MatList.Count < 1)
            {
                Recover();
                return;
            }

            // 先恢复原始材质
            Recover();

            // 开启新材质效果
            m_MatList.Sort();
            MatInfo m = m_MatList[0];
            BeginMat(m);
            m_RecoverState = false;
        }

        /// <summary>
        /// 开启材质特效
        /// </summary>
        /// <param name="m"></param>
        private void BeginMat(MatInfo m)
        {
            foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
            {
                if (kvp.Key == null)
                    continue;

                var mat_info = m_InitMatExtra[kvp.Key];

                Material new_mat = null;
                switch (m.type)
                {
                    case MAT_TYPE.HURT_HIGHLIGHT:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_HURT_HIGHLIGHT;// 将原始材质修改为HURT_HIGHLIGHT的材质
                        kvp.Key.material.mainTexture = kvp.Value.mainTexture;// texture赋值

                        break;
                    case MAT_TYPE.DEAD_DISSOLVE:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_DEAD_DISSOLVE;// 将原始材质修改为HURT_HIGHLIGHT的材质
                        new_mat = kvp.Key.material;
                        new_mat.mainTexture = kvp.Value.mainTexture;// texture赋值
                        if(new_mat.HasProperty("_Normal") && kvp.Value.HasProperty("_Normal"))
                            new_mat.SetTexture("_Normal", kvp.Value.GetTexture("_Normal"));// normalmap texture
                        m_Dissolve_Time = 0;
                        m_DissolveActive = true;
                        break;
                    case MAT_TYPE.DEAD_TOMBSTONE:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_TOMB_STONE;// 将原始材质修改为STONE的材质
                        new_mat = kvp.Key.material;
                        new_mat.mainTexture = kvp.Value.mainTexture;// texture赋值
                        if (new_mat.HasProperty("_Normal") && kvp.Value.HasProperty("_Normal"))
                            new_mat.SetTexture("_Normal", kvp.Value.GetTexture("_Normal"));// normalmap texture
                        m_StoneTime = 0;
                        m_StoneActive = true;
                        break;
                    case MAT_TYPE.OUTLING:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_OUTLING;// 将原始材质修改为Outing的材质
                        break;
                    default:
                        break;
                }
            }
        }

        bool m_DissolveActive = false;
        float m_DissolveProgress = 0;
        float m_Dissolve_Life = 3.0f;
        float m_Dissolve_Time = 0.0f;
        float m_Dissolve_Delay = 2.0f;
        void UpdateDissolve()
        {
            if (!m_DissolveActive)
                return;
            
            if (m_Dissolve_Time >= m_Dissolve_Delay)
            {
                m_DissolveProgress = (m_Dissolve_Time - m_Dissolve_Delay) / m_Dissolve_Life;
            }

            if (m_Dissolve_Time > (m_Dissolve_Delay + m_Dissolve_Life))
            {
                m_Dissolve_Time = 0.0f;
            }
            m_Dissolve_Time += Time.deltaTime;

            m_DissolveProgress = Mathf.Clamp01(m_DissolveProgress);
        }

        bool m_StoneActive = false;
        float m_StoneProgress = 0;
        float m_StoneLife = 2.0f;
        float m_StoneTime = 0.0f;
        void UpdateStone()
        {
            if (!m_StoneActive)
                return;

            if (m_StoneTime >= 0)
            {
                m_StoneProgress = m_StoneTime / m_Dissolve_Life;
            }

            m_StoneTime += Time.deltaTime;

            m_StoneProgress = Mathf.Clamp01(m_StoneProgress);
        }

        public override void Update()
        {
            base.Update();

            UpdateDissolve();
            UpdateStone();

            if(m_StoneActive || m_DissolveActive)
            {
                foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
                {
                    if (kvp.Key == null || kvp.Value == null)
                        continue;

                    var mat_info = m_InitMatExtra[kvp.Key];
                    if (mat_info.Instance == false)
                        continue;

                    Material mat = kvp.Key.sharedMaterial; // 在m_InitMat列表中的Material已经在初始化的时候进行了Instance
                    if (mat.HasProperty("_Progress"))
                        mat.SetFloat("_Progress", 1 - m_DissolveProgress);
                    else if (mat.HasProperty("_StoneProgress"))
                        mat.SetFloat("_StoneProgress", 1 - m_StoneProgress);

                }
            }
            
            if (m_MatList.Count < 1)
                return;

            float t = Time.time;

            bool currentChanged = false;
            MatInfo current = m_MatList[0];
            foreach (MatInfo m in m_MatList)
            {
                // 如果材质效果的时间周期已到，则将其从列表中移除
                if (m.endTime != m.startTime && t > m.endTime)
                {
                    m.needDelete = true;
                    if (m == current)
                        currentChanged = true;
                }
            }

            // 从列表中移除
            m_MatList.RemoveAll(item => item.needDelete == true);

            // 如果移除的是当前正在使用的特效，则要进行其他更新操作
            if (currentChanged)
                OnMatListChange();
        }

        /// <summary>
        /// 恢复原始的材质
        /// </summary>
        public void Recover()
        {
            if (m_RecoverState)
                return;

            foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
            {
                if (kvp.Key == null || kvp.Value == null)
                    continue;

                var mat_info = m_InitMatExtra[kvp.Key];
                if (mat_info.Instance)
                {
                    mat_info.Instance = false;

                    // 要先销毁instance的材质
                    var instance_mat = kvp.Key.material;
                    kvp.Key.sharedMaterial = kvp.Value;
                    GameObject.Destroy(instance_mat);
                }
                else
                {
                    kvp.Key.sharedMaterial = kvp.Value;
                }
                ExtraMatInf emi = m_InitMatExtra[kvp.Key];
                if (kvp.Value.HasProperty(MainColorName))
                {
                    kvp.Key.sharedMaterial.SetColor(MainColorName, emi.OriColor);
                }

            }
            m_RecoverState = true;
        }

        public override void Destroy()
        {
            // 在变身时要恢复角色的材质
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);
            // 在换装属性发生变化时要恢复角色的材质
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE, OnAvatarPropertyChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE_BEGIN, OnAvatarPropertyChangeBegin);

            base.Destroy();

            ClearMat();
        }

        void ClearMat()
        {
            Recover();
            m_MatList.Clear();
            // 初始保存的材质也clear
            m_InitMat.Clear();
            m_InitMatExtra.Clear();
        }

        void OnShapeShift(CEventBaseArgs data)
        {
            ClearMat();
        }

        void OnAvatarPropertyChange(CEventBaseArgs data)
        {
            if (mIsDestroy || mOwner == null || mOwner.IsDestroy)
                return;

            ClearMat();
            InitMat();

            // 变身结束后，如果死亡，需要再次添加死亡效果
            if (mOwner.IsMonster() && mOwner.IsDead())
                AddEffectMat(GlobalConst.MonsterDestroyDelay, MaterialEffectCtrl.MAT_TYPE.DEAD_DISSOLVE, MaterialEffectCtrl.Priority.DEAD);
        }

        void OnAvatarPropertyChangeBegin(CEventBaseArgs data)
        {
            if (mOwner == null || mOwner.IsDestroy)
                return;

            ClearMat();
        }
    }
}

