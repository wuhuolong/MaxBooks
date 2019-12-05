using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIFollow3DObject : MonoBehaviour
{
    WeakReference mFollowTarget;
    Vector3 mOffset3D;

    void Awake()
    {
        
    }

    public void SetFollowObject(Actor target, Vector3 offset3D)
    {
        mFollowTarget = new WeakReference(target);

        mOffset3D = offset3D;
    }

    void LateUpdate()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (mFollowTarget == null && !mFollowTarget.IsAlive)
            return;

        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        if (mFollowTarget.Target == null)
        {
            return;
        }

        var actor = ((Actor)mFollowTarget.Target);
        if (actor == null)
        {
            return;
        }

        var followTrans = actor.transform;
        if (followTrans == null)
        {
            return;
        }

        Vector3 pos = mainCamera.WorldToScreenPoint(followTrans.position + mOffset3D);
        pos.z = 0f;

        Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
        Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
        transform.position = lblPos;
    }
}
