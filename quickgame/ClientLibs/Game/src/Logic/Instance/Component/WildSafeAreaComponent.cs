using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc;

[wxb.Hotfix]
public class WildSafeAreaComponent : MonoBehaviour
{
    private int mPlayerMask;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        mPlayerMask = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == null || other.gameObject.layer != mPlayerMask)
            return;

        ActorMono actor_mono = ActorHelper.GetActorMono(other.gameObject);
        if (actor_mono == null)
            return;

        var actor = actor_mono.BindActor;
        if (actor == null || actor.UnitType != EUnitType.UNITTYPE_PLAYER)
            return;

        actor.IsInSafeArea = true;

        if (actor == Game.GetInstance().GetLocalPlayer())
        {
            UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_44"));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == null || other.gameObject.layer != mPlayerMask)
            return;

        ActorMono actor_mono = ActorHelper.GetActorMono(other.gameObject);
        if (actor_mono == null)
            return;

        var actor = actor_mono.BindActor;
        if (actor == null || actor.UnitType != EUnitType.UNITTYPE_PLAYER)
            return;

        actor.IsInSafeArea = false;

        if (actor == Game.GetInstance().GetLocalPlayer())
        {
            UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_45"));
        }
    }
}
