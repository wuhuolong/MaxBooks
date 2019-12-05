using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class TestAnimationCtrl : MonoBehaviour
{
    public string AnimationName;
    public bool m_UseHighEffect = true;

    void Awake()
    {
        AssemblyBridge.Instance.ComponentEmployer = new xc.XComponent();
    }

    void OnEnable()
    {
        SkillEffectPlayer.UseHighEffect = m_UseHighEffect;
        AnimationController mAnimatonCtrl= GetComponent<AnimationController>();
        if (mAnimatonCtrl != null)
            mAnimatonCtrl.PlayAnimation(AnimationName);
    }
}

