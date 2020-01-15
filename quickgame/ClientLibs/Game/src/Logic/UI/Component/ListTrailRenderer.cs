
using UnityEngine;
using System.Collections.Generic;
public class ListTrailRenderer : MonoBehaviour
{
    private List<TrailRenderer> m_TrailItemArray;
    private List<ParticleSystemEx> m_particleSysExArray;
    public void Awake()
    {
        m_TrailItemArray = new List<TrailRenderer>();
        TrailRenderer[] trail_array = transform.GetComponentsInChildren<TrailRenderer>(true);
        for (int index = 0; index < trail_array.Length; ++index)
            m_TrailItemArray.Add(trail_array[index]);
        m_particleSysExArray = new List<ParticleSystemEx>();
        ParticleSystemEx[] particle_array = transform.GetComponentsInChildren<ParticleSystemEx>(true);
        for (int index = 0; index < particle_array.Length; ++index)
            m_particleSysExArray.Add(particle_array[index]);
    }
    public void ResetPos()
    {
        if (m_TrailItemArray == null)
            return;
        for (int index = 0; index < m_TrailItemArray.Count; ++index)
        {
            if (m_TrailItemArray[index] != null)
            {
                m_TrailItemArray[index].Clear();
            }
        }
        for (int index = 0; index < m_particleSysExArray.Count; ++index)
        {
            if (m_particleSysExArray[index] != null)
            {
                //m_particleSysExArray[index].Clear();
                m_particleSysExArray[index].stop();
                m_particleSysExArray[index].play();
            }
        }
    }

    void OnEnable()
    {
        ResetPos();
    }
}
