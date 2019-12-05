//-------------------------------------------
// File: SkillButtonManager.cs
// Desc: 技能按键的管理类
// Author: raorui
// Date: 2017/9/26
//-------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using xc;
using xc.ui;
using xc.ui.ugui;

namespace xc
{
    class SkillButtonManager: xc.Singleton<SkillButtonManager>
    {
        static Dictionary<uint, GameObject> m_AllSkillButton = new Dictionary<uint, GameObject>();

        /// <summary>
        /// 将指定的RockButton添加到管理类中
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="btn"></param>
        public void AddButton(uint idx, GameObject btn)
        {
            m_AllSkillButton[idx] = btn;
        }

        /// <summary>
        /// 将指定的RockButton从管理类中移除
        /// </summary>
        /// <param name="idx"></param>
        public void RemoveButton(uint idx)
        {
            if(m_AllSkillButton.ContainsKey(idx))
                m_AllSkillButton.Remove(idx);
        }

        public GameObject GetButton(uint idx)
        {
            GameObject btn = null;
            m_AllSkillButton.TryGetValue(idx, out btn);
            return btn;
        }
    }
}
