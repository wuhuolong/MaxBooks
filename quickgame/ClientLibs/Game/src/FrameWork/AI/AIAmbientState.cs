using UnityEngine;
using System.Collections.Generic;
using xc;

public class AIAmbientState
{
    private class PartnerState
    {
        public uint Value;
        public Actor TargetActor;
    }

    private BehaviourAI mAI;

    private LinkedList<PartnerState> mHatredPartners = new LinkedList<PartnerState>();
    private LinkedList<PartnerState> mWillRemoveHatredPartners = new LinkedList<PartnerState>();

    public AIAmbientState(BehaviourAI parent)
    {
        mAI = parent;
    }

    public void Update()
    {
        foreach (var item in mWillRemoveHatredPartners)
        {
            mHatredPartners.Remove(item);
        }

        mWillRemoveHatredPartners.Clear();

        foreach (var item in mHatredPartners)
        {
            float value = item.Value;
            value = value * (1.0f - GameConst.AI_HATRED_DECAY_RATIO * (Time.deltaTime / 1.0f));

            item.Value = (uint)value;

            if(item.Value <= 0 || item.TargetActor == null || item.TargetActor.IsDead())
            {
                mWillRemoveHatredPartners.AddLast(item);
            }

        }
    }

    public Actor GetMostHateActor()
    {
        PartnerState state = null;

        foreach (var item in mHatredPartners)
        {
            if(item == null || item.TargetActor == null)
            {
                continue;
            }

            if(state == null)
            {
                state = item;
                continue;
            }

            if(state != null && item.Value > state.Value)
            {
                state = item;
            }
        }

        if(state != null)
        {
            return state.TargetActor;
        }

        return null;
    }

    public void BeAttacked(Damage damage)
    {
        if (damage == null)
            return;

        var src_actor = damage.src;
        if (src_actor == null)
            return;

        var target_actor = damage.target;
        if (target_actor == null)
            return;

        PartnerState state = GetHatredPartnerState(src_actor);

        if(state == null)
            return;

        state.Value += (uint)damage.DamageValue;
    }

    private PartnerState GetHatredPartnerState(Actor actor)
    {
        if(actor == null)
        {
            return null;
        }

        foreach (var item in mHatredPartners)
        {
            if(item.TargetActor == actor)
            {
                return item;
            }
        }

        PartnerState state = new PartnerState();
        state.TargetActor = actor;
        state.Value = 0;

        mHatredPartners.AddLast(state);

        return state;
    }
}