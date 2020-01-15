///// <summary>
///// 拾取装备时，控制物体特效飞向角色的组件
///// </summary>
//using UnityEngine;
//using System.Collections;
//using xc;
//using Spartan;
//using Destiny;
//using Net;

//public class PickDropAnimationComponent : MonoBehaviour
//{
//    Transform mThisTran;
//    Transform mTargetTran;
//    Vector3 mTargetOffset;
//    float mSpeed = 10f;
//    float mAcceleration = 0.02f;
//    bool mHasFinished;

//    PkgGoodsGive mDropInfo;
//    Utils.Timer mDestroyTimer;

//    void Awake()
//    {
//        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
//    }

//    void Start()
//    {
//        mThisTran = transform;
//        mHasFinished = false;
//    }

//    void OnDestroy()
//    {
//        if (mDestroyTimer != null)
//        {
//            mDestroyTimer.Destroy();
//            mDestroyTimer = null;
//        }
//    }

//    void DestroyImpl(float remainTime)
//    {
//        NGUITools.DestroyImmediate(this.gameObject);

//        if (mDestroyTimer != null)
//        {
//            mDestroyTimer.Destroy();
//            mDestroyTimer = null;
//        }
//    }

//    void Update()
//    {
//        if (mThisTran != null && mTargetTran != null)
//        {
//            Vector3 targetPosition = mTargetTran.localPosition + mTargetOffset;
//            Vector3 next = Vector3.MoveTowards(mThisTran.localPosition, targetPosition, mSpeed * Time.deltaTime);
//            mSpeed += mAcceleration;
//            mThisTran.localPosition = next;
//            if (mThisTran.localPosition.Equals(targetPosition) && mHasFinished == false)
//            {
//                if (mDestroyTimer != null)
//                {
//                    mDestroyTimer.Destroy();
//                    mDestroyTimer = null;
//                }
//                mDestroyTimer = new Utils.Timer(500, false, 500, DestroyImpl);

//                mHasFinished = true;

//                mSpeed = 10f;
//            }
//        }
//    }

//    public Transform TargetTran
//    {
//        set { mTargetTran = value; }
//    }

//    public Vector3 TargetOffset
//    {
//        set { mTargetOffset = value; }
//    }

//    public PkgGoodsGive DropInfo
//    {
//        set { mDropInfo = value; }
//    }
//}
