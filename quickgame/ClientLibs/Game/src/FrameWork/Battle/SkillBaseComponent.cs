using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

public class SkillBaseComponent : MonoBehaviour
{
    // 控制组件激活 
	class MonoEnableOption
	{
		float mfDelayTime;
		MonoBehaviour mkTarget;
		bool mbEnable;
		public bool mbActive = true;
		
		public MonoEnableOption(MonoBehaviour kTarget, bool bEnable, float fDelayTime)
		{
			mkTarget = kTarget;
			mbEnable = bEnable;
			mfDelayTime = fDelayTime;

            mkTarget.enabled = !bEnable;
		}
		
		public void Update(float fCurrentTime)
		{
			if (mbActive)
			{
				if (fCurrentTime >= mfDelayTime)
				{
					mkTarget.enabled = mbEnable;
					mbActive = false;
				}
			}
		}
	}
	
	List<MonoEnableOption> mkEnableOptionList = new List<MonoEnableOption>();// 所有激活触发的组件
	
    /// <summary>
    /// 增加需要延迟激活的MonoBehavior组件
    /// </summary>
	public void AddMonoEnableOption(MonoBehaviour kTarget, bool bEnable, float fDelayTime)
	{		
		mkEnableOptionList.Add(new MonoEnableOption(kTarget, bEnable, fDelayTime));
	}
	
	// Update is called once per frame
    public void UpdateCycle (float elapseTime)
	{
		foreach(MonoEnableOption kOption in mkEnableOptionList)
		{
            kOption.Update(elapseTime);
		}
	}

    /// <summary>
    /// 销毁GameObject前要进行的操作
    /// </summary>
    public void DestroyAll()
    {
        CommonTool.DestroyObjectImmediate(gameObject);
    }

    /*public void DestroyEffect()
    {       
        mkSkillEffectCtrl.ClearSkillEffect(mID);
    }*/

    SkillAttackInstance attackInst; 
    public SkillAttackInstance SkillAttackInst
    {
        get
        {
            return attackInst;
        }
    }

    public void Init(SkillAttackInstance inst)
    {
        attackInst = inst;
    }
}

