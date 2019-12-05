//--------------------------------------------
// File: SkillHoleManager.cs
// Desc: 技能槽开放的管理类，用于给lua层提供接口（已开启的八卦牌的数据层共用）
// Author: raorui
// Date: 2017.9.5
//--------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace xc
{
    [wxb.Hotfix]
    public class SkillHoleManager: xc.Singleton<SkillHoleManager>
    {
        /// <summary>
        /// 默认开启的技能槽
        /// </summary>
        public static uint ForceOpenHole = 1;

        /// <summary>
        /// 已经开启的技能槽
        /// </summary>
        List<uint> m_OpenSkillHoles = new List<uint>();

        /// <summary>
        /// 即将开启的技能槽（用来表现技能按钮的开启效果）
        /// </summary>
        List<uint> m_WillOpenSkillHoles = new List<uint>();

        public List<uint> WillOpenSkillHoles
        {
            get { return m_WillOpenSkillHoles; }
        }

        //即将开放的孔和技能ID（key：孔编号；value：对于的总表技能ID）
        Dictionary<uint, uint> WillOpenHoleAndAllSkillIdMap = new Dictionary<uint, uint>();

        /// <summary>
        /// 重设管理类
        /// </summary>
        public void Reset()
        {
            m_OpenSkillHoles.Clear();
            m_OpenSkillHoles.Add(ForceOpenHole);// 第一个技能槽默认开启
            m_WillOpenSkillHoles.Clear();
            WillOpenHoleAndAllSkillIdMap.Clear();
        }

        /// <summary>
        /// 开启指定的技能(skill_id:技能总表id)的时候，开启对应的技能槽
        /// </summary>
        /// <param name="trigram_id"></param>
        public void OpenSkill(uint skill_id)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                // 如果技能孔还未开启，并且不在即将开启的技能孔列表中
                if (!m_OpenSkillHoles.Contains(skill_hole) && !m_WillOpenSkillHoles.Contains(skill_hole))
                    m_OpenSkillHoles.Add(skill_hole);
            }

            if (SkillManager.Instance.IsMateSkill(skill_id))
            {
                //情侣技能在这里FireEvent，保证情侣技能被删除后，再次添加可以显示icon
                xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.SKILL_MATE_UPDATE, null);
            }
        }

        /// <summary>
        /// 开启新的技能(skill_id:技能总表id)
        /// </summary>
        /// <param name="trigram_id"></param>
        public void OpenNewSkill(uint skill_id)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0 && skill_hole != ForceOpenHole)
            {
                var isFurySkill = SkillManager.Instance.IsFurySkill(skill_id);

                // 对于非怒气技能，如果技能槽已经开启了，则不处理
                if (!isFurySkill && m_OpenSkillHoles.Contains(skill_hole))
                    return;

                if(!m_WillOpenSkillHoles.Contains(skill_hole))
                    m_WillOpenSkillHoles.Add(skill_hole);

                WillOpenHoleAndAllSkillIdMap[skill_hole] = skill_id;
                if (SceneHelp.Instance.IsInWildInstance())
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SKILL_OPENNEW, new CEventBaseArgs(skill_id));
                else
                    ClientEventMgr.Instance.PostEvent((int)ClientEvent.CE_SKILL_OPENNEW, new CEventBaseArgs(skill_id));
            }
        }

        /// <summary>
        /// 技能槽开启效果完毕后调用
        /// </summary>
        /// <param name="trigram_id"></param>
        public void OpenNewHoleFinish(uint skill_id)
        {
            //GameDebug.LogError("OpenNewHoleFinish " + skill_id);
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                if (!m_OpenSkillHoles.Contains(skill_hole))
                    m_OpenSkillHoles.Add(skill_hole);

                if (m_WillOpenSkillHoles.Contains(skill_hole))
                {
                    m_WillOpenSkillHoles.Remove(skill_hole);
                    xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.SKILL_KEY_POS_SET, null);
                }
            }
        }

        public void ClearSkill(uint skill_id)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                if (m_OpenSkillHoles.Contains(skill_hole))
                    m_OpenSkillHoles.Remove(skill_hole);

                if (!m_WillOpenSkillHoles.Contains(skill_hole))
                {
                    m_WillOpenSkillHoles.Add(skill_hole);
                }
            }
        }


        /// <summary>
        /// 根据技能id删除hole
        /// </summary>
        /// <param name="skill_id">技能id</param>
        public void DeleteSkill(uint skill_id)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                if (m_OpenSkillHoles.Contains(skill_hole))
                    m_OpenSkillHoles.Remove(skill_hole);

                if (m_WillOpenSkillHoles.Contains(skill_hole))
                    m_WillOpenSkillHoles.Remove(skill_hole);

            }
        }




        /// <summary>
        /// 获取技能槽的位置
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
        public Vector3 GetSkillHolePosition(uint skill_id)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                var btn = SkillButtonManager.Instance.GetButton(skill_hole);
                if(btn != null)
                {
                    return btn.transform.position;
                }
            }

            return Vector3.zero;
        }

        /// <summary>
        /// 获取当前的界面移动在技能槽位置时，所需要进行的缩放
        /// </summary>
        /// <param name="trigram_id"></param>
        /// <param name="widget"></param>
        /// <returns></returns>
        public float GetScaleToSkillHole(uint skill_id, GameObject widget)
        {
            uint skill_hole = GetOpenSkillHole(skill_id);
            if (skill_hole != 0)
            {
                var btn = SkillButtonManager.Instance.GetButton(skill_hole);
                if (btn != null)
                {
                    var widget_trans = widget.GetComponent<RectTransform>();
                    var btn_trans = btn.GetComponent<RectTransform>();
                    if(btn_trans != null && widget_trans != null)
                    {
                        Vector3[] world_corner = new Vector3[4];
                        widget_trans.GetWorldCorners(world_corner);
                        float widget_size_x = world_corner[2].x - world_corner[0].x;
                        btn_trans.GetWorldCorners(world_corner);
                        float btn_size_x = world_corner[2].x - world_corner[0].x;

                        if (widget_size_x != 0)
                            return btn_size_x / widget_size_x;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 指定的技能槽是否已经开启
        /// skil_hole 从1开始
        /// </summary>
        /// <param name="skil_hole"></param>
        /// <returns></returns>
        public bool IsHoleOpen(uint skil_hole)
        {
            return m_OpenSkillHoles.Contains(skil_hole);
        }

        /// <summary>
        /// 指定的技能槽是否即将开启
        /// </summary>
        /// <param name="skill_hole"></param>
        /// <returns></returns>
        public bool IsHoleWillOpen(uint skill_hole)
        {
            return m_WillOpenSkillHoles.Contains(skill_hole);
        }

        /// <summary>
        /// 通过技能总表的id，来获取开启技能槽的位置
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
        public uint GetOpenSkillHole(uint skill_id)
        {
            var data_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
            var skill_info = data_all_skill.GetOneAllSkillInfo(skill_id);
            if (skill_info != null)
                return skill_info.OpenHole;
            else
                return 0;
        }

        public uint GetNextWillOpenSkillHole()
        {
            if (m_WillOpenSkillHoles.Count == 0)
                return 0;
            return m_WillOpenSkillHoles[0];
        }

        public uint GetWillOpenSkillId(uint hole_id)
        {
            if (WillOpenHoleAndAllSkillIdMap.ContainsKey(hole_id) == false)
                return 0;

            return WillOpenHoleAndAllSkillIdMap[hole_id];
        }
    }
}
